using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProj
{
    public partial class Info : Form
    {
        #region Private fields

        private readonly object _locker;

        #endregion

        #region Ordinary fields

        public List<LogsInfo> Logs;
        public readonly SynchronizationContext SynchronizationContext;

        #endregion

        #region Constructor

        public Info()
        {
            InitializeComponent();

            SynchronizationContext = SynchronizationContext.Current;
            _locker = new object();
            Logs = new List<LogsInfo>();
        }

        #endregion

        #region Private methods

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            Hide();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            lock (_locker)
            {
                listBox1.DataSource = Logs;
            }
            listBox1.DisplayMember = "log";
            listBox1.ValueMember = "log";
            int visibleItems = listBox1.ClientSize.Height / listBox1.ItemHeight;
            listBox1.TopIndex = Math.Max(listBox1.Items.Count - visibleItems + 1, 0);
        }

        #endregion

        #region Public methods

        public async Task AddLog(string log)
        {
            await Task.Run(() =>
            {
                lock (_locker)
                {
                    Logs.Add(new LogsInfo(log));
                }
            });
        }

        #endregion
    }
}