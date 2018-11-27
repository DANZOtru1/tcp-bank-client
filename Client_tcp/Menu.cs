using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Client_tcp
{
    public partial class Menu : Form
    {
        public SynchronizationContext SynchronizationContext;

        public Menu()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
        }

        private void buttonInfoShow_Click(object sender, EventArgs e)
        {
            Program.MainForm.FormInfo.Show();
            Program.MainForm.SleepTime = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.MainForm.FormSendMoney.Show();
            Program.MainForm.SleepTime = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelClientId.Text = Program.MainForm.Client.Id;
            labelBalance.Text = Convert.ToString(Program.MainForm.Client.Sum);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            Program.MainForm.Client.DisconnectFromServer();
            Program.MainForm.TokenBlockProgramSource.Cancel();
            SaveInformation();
            Application.Exit();
        }

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

        private void buttonBuffer_Click(object sender, EventArgs e)
        {
            if(labelClientId.Text != null)
            {
                Clipboard.SetText(labelClientId.Text);
            }
        }
    }
}
