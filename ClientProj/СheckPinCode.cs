using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace ClientProj
{
    public partial class CheckPinCode : Form
    {
        #region Private fields

        private string _filePath;
        private string _id;
        private List<LogsInfo> _logs;
        private decimal _sum;

        #endregion

        #region Ordinary fields

        internal int PinCode;
        internal bool ReLogin;
        public readonly SynchronizationContext SynchronizationContext;

        #endregion

        #region Constructor

        public CheckPinCode()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
            maskedTextBox1.Enabled = false;
            buttonLogin.Enabled = false;
            ReLogin = false;
        }

        #endregion

        #region Private methods

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialog1.FileName;

                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    using (FileStream fs = new FileStream(_filePath, FileMode.Open))
                    {
                        _id = (string) formatter.Deserialize(fs);
                        PinCode = (int) formatter.Deserialize(fs);
                        _sum = (decimal) formatter.Deserialize(fs);
                        _logs = (List<LogsInfo>) formatter.Deserialize(fs);

                        labelFileOpen.Text = "Файл открыт. Введите Пин";
                        maskedTextBox1.Enabled = true;
                    }
                }
                catch
                {
                    maskedTextBox1.Enabled = false;
                    labelFileOpen.Text = "Некорректный файл";
                }
            }
        }

        private void MaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Length < 6)
            {
                labelFileOpen.Text = "Пин не совпадает";
                buttonLogin.Enabled = false;
                return;
            }

            for (int i = 0; i < maskedTextBox1.Text.Length; i++)
            {
                if (maskedTextBox1.Text[i] == ' ')
                {
                    labelFileOpen.Text = "Некорректный Пин";
                    buttonLogin.Enabled = false;
                    return;
                }
            }

            if (PinCode == Convert.ToInt32(maskedTextBox1.Text))
            {
                labelFileOpen.Text = "Добро пожаловать";
                buttonLogin.Enabled = true;
                return;
            }

            labelFileOpen.Text = "Пин не совпадает";
            buttonLogin.Enabled = false;
        }

        private void MaskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (ReLogin)
            {
                Program.MainForm.FormInfo.Enabled = true;
                Program.MainForm.FormMenu.Enabled = true;
                Program.MainForm.FormSendMoney.Enabled = true;

                Program.MainForm.Client.ConnectToServer();
                Hide();
                Program.MainForm.FormMenu.Show();

                Program.MainForm.ProgramBlocked = false;
                Program.MainForm.SleepTime = 0;

                return;
            }

            Hide();
            Program.MainForm.RunBlockerFormAsync();
            Program.MainForm.Client = new Client(_id, _sum, PinCode);
            Program.MainForm.Client.AddLoggerFunction(Program.MainForm.FormInfo.AddLog);

            Program.MainForm.FormInfo.Logs = _logs;

            Program.MainForm.FormMenu.timerUpdateBalance.Start();
            Program.MainForm.FormMenu.Show();
        }

        #endregion

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Program.MainForm.Show();
            Hide();
        }
    }
}