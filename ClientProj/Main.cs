using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProj
{
    public partial class Main : Form
    {
        #region Readonly fields

        private readonly CheckPinCode _formCheckPin = new CheckPinCode();
        private readonly CreatePinCode _formCreatePin = new CreatePinCode();
        private readonly SynchronizationContext _synchronizationContext;
        public readonly Info FormInfo = new Info();
        public readonly Menu FormMenu = new Menu();
        public readonly SendMoney FormSendMoney = new SendMoney();

        #endregion

        #region Private fields

        private CancellationToken _tokenBlockProgram;

        #endregion

        #region Ordinary fields

        public Client Client;
        public bool ProgramBlocked;
        public int SleepTime;
        public CancellationTokenSource TokenBlockProgramSource;

        #endregion

        #region Constructor

        public Main()
        {
            InitializeComponent();
            _synchronizationContext = SynchronizationContext.Current;
        }

        #endregion

        #region Private methods

        private void ButtonNewClient_Click(object sender, EventArgs e)
        {
            Hide();
            _formCreatePin.Show();
        }

        private void ButtonOldClient_Click(object sender, EventArgs e)
        {
            Hide();
            _formCheckPin.Show();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        internal async void RunBlockerFormAsync()
        {
            await Task.Run(() =>
            {
                TokenBlockProgramSource = new CancellationTokenSource();
                _tokenBlockProgram = TokenBlockProgramSource.Token;

                while (true)
                {
                    if (_tokenBlockProgram.IsCancellationRequested)
                    {
                        break;
                    }

                    Thread.Sleep(1000);
                    if (SleepTime >= 60 && !ProgramBlocked)
                    {
                        Client.DisconnectFromServer();
                        FormMenu.SaveInformation();
                        ProgramBlocked = true;

                        _formCreatePin.SynchronizationContext.Post(o =>
                        {
                            _formCreatePin.Hide();
                            _formCreatePin.Enabled = false;
                        }, null);

                        FormInfo.SynchronizationContext.Post(o =>
                        {
                            FormInfo.Hide();
                            FormInfo.Enabled = false;
                        }, null);

                        FormMenu.SynchronizationContext.Post(o =>
                        {
                            FormMenu.Hide();
                            FormMenu.Enabled = false;
                        }, null);

                        FormSendMoney.SynchronizationContext.Post(o =>
                        {
                            FormSendMoney.Hide();
                            FormSendMoney.Enabled = false;
                        }, null);

                        _formCheckPin.SynchronizationContext.Post(o =>
                        {
                            _formCheckPin.PinCode = Client.Pin;
                            _formCheckPin.ReLogin = true;
                            _formCheckPin.buttonOpenFile.Enabled = false;
                            _formCheckPin.buttonOpenFile.Text =
                                "Программа заблокирована за бездействие";

                            _formCheckPin.labelFileOpen.Text = "Введите Пин";
                            _formCheckPin.maskedTextBox1.Enabled = true;
                            _formCheckPin.maskedTextBox1.Text = "";
                            _formCheckPin.Show();
                        }, null);

                        _synchronizationContext.Post(o =>
                        {
                            Hide();
                            Enabled = false;
                        }, null);
                    }
                    else
                    {
                        SleepTime++;
                    }
                }
            }, _tokenBlockProgram);
        }
    }
}