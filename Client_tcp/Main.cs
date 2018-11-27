using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_tcp
{
    public partial class Main : Form
    {
        public CreatePinCode FormCreatePin = new CreatePinCode();
        public CheckPinCode FormCheckPin = new CheckPinCode();
        public Info FormInfo = new Info();
        public SendMoney FormSendMoney = new SendMoney();
        public Menu FormMenu = new Menu();

        public Client Client;
        public int SleepTime = 0;
        public bool ProgramBlocked = false;
        public SynchronizationContext SynchronizationContext;
        public CancellationTokenSource TokenBlockProgramSource;
        public CancellationToken TokenBlockProgram;

        public Main()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
        }

        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCreatePin.Show();
        }

        private void buttonOldClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCheckPin.Show();
        }

        internal async void RunBlockerFormAsync()
        {
            await Task.Run(() =>
            {
                TokenBlockProgramSource = new CancellationTokenSource();
                TokenBlockProgram = TokenBlockProgramSource.Token;
               
                while (true)
                {
                    if(TokenBlockProgram.IsCancellationRequested)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                    if (SleepTime >= 60 && !ProgramBlocked)
                    {
                        Client.DisconnectFromServer();
                        FormMenu.SaveInformation();
                        ProgramBlocked = true;

                        FormCreatePin.SynchronizationContext.Post ((o) =>
                        {
                            FormCreatePin.Hide();
                            FormCreatePin.Enabled = false;
                        }, null);

                        FormInfo.SynchronizationContext.Post((o) =>
                        {
                            FormInfo.Hide();
                            FormInfo.Enabled = false;
                        }, null);

                        FormMenu.SynchronizationContext.Post((o) =>
                        {
                            FormMenu.Hide();
                            FormMenu.Enabled = false;
                        }, null);

                        FormSendMoney.SynchronizationContext.Post((o) =>
                        {
                            FormSendMoney.Hide();
                            FormSendMoney.Enabled = false;
                        }, null);

                        FormCheckPin.synchronizationContext.Post((o) =>
                        {
                            FormCheckPin.PinCode = Client.Pin;
                            FormCheckPin.ReLogin = true;
                            FormCheckPin.buttonOpenFile.Enabled = false;
                            FormCheckPin.buttonOpenFile.Text = "Программа заблокирована за бездействие";
                            FormCheckPin.labelFileOpen.Text = "Введите Пин";
                            FormCheckPin.maskedTextBox1.Enabled = true;
                            FormCheckPin.maskedTextBox1.Text = "";
                            FormCheckPin.Show();
                        }, null);

                        this.SynchronizationContext.Post((o) =>
                        {
                            this.Hide();
                            this.Enabled = false;
                        }, null);
                        
                    }
                    else
                    {
                        SleepTime++;
                    }
                }
            });
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
