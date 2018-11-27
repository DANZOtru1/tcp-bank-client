using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_tcp
{
    public partial class CheckPinCode : Form
    {
        private string filePath;
        internal int PinCode;
        internal bool ReLogin;
        private string id;
        private decimal sum;
        private List<LogsInfo> logs;
        public SynchronizationContext synchronizationContext;

        public CheckPinCode()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
            maskedTextBox1.Enabled = false;
            buttonLogin.Enabled = false;
            ReLogin = false;
            
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
  
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        id = (string)formatter.Deserialize(fs);
                        PinCode = (int)formatter.Deserialize(fs);
                        sum = (decimal)formatter.Deserialize(fs);
                        logs = (List<LogsInfo>)formatter.Deserialize(fs);

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

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text.Length < 6)
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
            return;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(ReLogin)
            {
                Program.MainForm.FormInfo.Enabled = true;
                Program.MainForm.FormMenu.Enabled = true;
                Program.MainForm.FormSendMoney.Enabled = true;

                Program.MainForm.Client.ConnectToServer();
                this.Hide();
                Program.MainForm.FormMenu.Show();

                Program.MainForm.ProgramBlocked = false;
                Program.MainForm.SleepTime = 0;

                return;
            }

            this.Hide();
            Program.MainForm.RunBlockerFormAsync();
            Program.MainForm.Client = new Client(id, sum, PinCode);
            Program.MainForm.Client.AddLoggerFunction(Program.MainForm.FormInfo.AddLog);

            Program.MainForm.FormInfo.Logs = logs;

            Program.MainForm.FormMenu.timerUpdateBalance.Start();
            Program.MainForm.FormMenu.Show();
        }
    }
}
