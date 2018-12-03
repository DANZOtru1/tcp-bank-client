using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace ClientProj
{
    public partial class Menu : Form
    {
        #region Ordinary fields

        public readonly SynchronizationContext SynchronizationContext;

        #endregion

        #region Constructor

        public Menu()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
        }

        #endregion

        #region Private methods

        private void ButtonInfoShow_Click(object sender, EventArgs e)
        {
            Program.MainForm.FormInfo.Show();
            Program.MainForm.SleepTime = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.MainForm.FormSendMoney.Show();
            Program.MainForm.SleepTime = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e) 
        {
            labelClientId.Text = Program.MainForm.Client.Id;
            labelBalance.Text = Convert.ToString(Program.MainForm.Client.Sum);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            Program.MainForm.Client.DisconnectFromServer();
            Program.MainForm.TokenBlockProgramSource.Cancel();
            SaveInformation();
            Application.Exit();
        }

        private void ButtonBuffer_Click(object sender, EventArgs e)
        {
            if (labelClientId.Text != null)
            {
                Clipboard.SetText(labelClientId.Text);
            }
        }

        #endregion

        internal void SaveInformation()
        {
            string fileName = Program.MainForm.Client.Id.Remove(14);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Program.MainForm.Client.Id);
                formatter.Serialize(fs, Program.MainForm.Client.Pin);
                formatter.Serialize(fs, Program.MainForm.Client.Sum);
                formatter.Serialize(fs, Program.MainForm.FormInfo.Logs);
            }
        }
    }
}