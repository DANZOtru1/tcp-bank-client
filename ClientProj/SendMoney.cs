using System;
using System.Threading;
using System.Windows.Forms;

namespace ClientProj
{
    public partial class SendMoney : Form
    {
        #region Ordinary fields

        public readonly SynchronizationContext SynchronizationContext;

        #endregion

        #region Constructor

        public SendMoney()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
        }

        #endregion

        #region Private methods

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            Hide();
            textBoxUserId.Text = "";
            textBoxSendSum.Text = "";
        }

        private void ButtonSendSum_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            if (textBoxUserId.Text == Program.MainForm.Client.Id)
            {
                MessageBox.Show("Номер счета принадлежит вам.");
                return;
            }

            if (decimal.TryParse(textBoxSendSum.Text, out decimal sendSum))
            {
                if (sendSum < Program.MainForm.Client.Sum)
                {
                    if (Program.MainForm.Client.SendMoney(textBoxUserId.Text, sendSum,
                        false))
                    {
                        MessageBox.Show("Перевод выполнен.");
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Перевод не выполнен. Причина: Недостаточно средств.");
                }
            }
            else
            {
                MessageBox.Show(
                    "Перевод не выполнен. Причина: Введена некорректная сумма.");
            }
        }

        #endregion
    }
}