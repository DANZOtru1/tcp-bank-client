using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_tcp
{
    public partial class Info : Form
    {
        public List<LogsInfo> Logs;
        public SynchronizationContext SynchronizationContext;
        private object locker;
        
        public Info()
        {
            InitializeComponent();

            SynchronizationContext = SynchronizationContext.Current;
            locker = new object();
            Logs = new List<LogsInfo>();
        }

        public async Task AddLog(string log)
        {
            await Task.Run(() =>
            {
                lock(locker)
                {
                    Logs.Add(new LogsInfo(log));
                }
            });
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = Logs;
            listBox1.DisplayMember = "log";
            listBox1.ValueMember = "log";
            int visibleItems = listBox1.ClientSize.Height / listBox1.ItemHeight;
            listBox1.TopIndex = Math.Max(listBox1.Items.Count - visibleItems + 1, 0);
        }
    }
}
