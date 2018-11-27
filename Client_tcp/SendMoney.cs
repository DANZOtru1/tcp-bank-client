using System;
using System.Threading;
using System.Windows.Forms;

namespace Client_tcp
{
    public partial class SendMoney : Form
    {
        public SynchronizationContext SynchronizationContext;

        public SendMoney()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            this.Hide();
            textBoxUserId.Text = "";
            textBoxSendSum.Text = "";
        }

        private void buttonSendSum_Click(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
            if (textBoxUserId.Text == Program.MainForm.Client.Id)
            {
                MessageBox.Show("Номер счета принадлежит вам.");
                return;
            }

            decimal sendSum;
            if(Decimal.TryParse(textBoxSendSum.Text,out sendSum))
            {
                if(sendSum < Program.MainForm.Client.Sum)
                {
                    if(Program.MainForm.Client.SendMoney(textBoxUserId.Text, sendSum, false))
                    {
                        MessageBox.Show("Перевод выполнен.");
                    }
                }
                else
                {
                    MessageBox.Show("Перевод не выполнен. Причина: Недостаточно средств.");
                }
            }
            else
            {
                MessageBox.Show("Перевод не выполнен. Причина: Введена некорректная сумма.");
            }
        }

        private void textBoxUserId_TextChanged(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
        }

        private void textBoxSendSum_TextChanged(object sender, EventArgs e)
        {
            Program.MainForm.SleepTime = 0;
        }
    }
}
