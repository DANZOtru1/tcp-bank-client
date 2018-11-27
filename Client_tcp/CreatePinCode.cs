using System;
using System.Threading;
using System.Windows.Forms;

namespace Client_tcp
{
    public partial class CreatePinCode : Form
    {
        public SynchronizationContext SynchronizationContext;
        public int Pin;

        public CreatePinCode()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
        }

        private void CreatePinCode_Load(object sender, EventArgs e)
        {
            buttonPinConfirm.Enabled = false;
        }
        
        private void CheckPin()
        {
            if (maskedTextBoxNewPin.Text.Length < 6 || maskedTextBoxNewPinConf.Text.Length < 6)
            {
                label2.Text = "Некорректный Пин";
                buttonPinConfirm.Enabled = false;
                return;
            }

            for (int i = 0; i < maskedTextBoxNewPin.Text.Length; i++)
            {
                if (maskedTextBoxNewPin.Text[i] == ' ')
                {
                    label2.Text = "Некорректный Пин";
                    buttonPinConfirm.Enabled = false;
                    return;
                }
            }

            for (int i = 0; i < maskedTextBoxNewPinConf.Text.Length; i++)
            {
                if (maskedTextBoxNewPinConf.Text[i] == ' ')
                {
                    label2.Text = "Некорректный Пин";
                    buttonPinConfirm.Enabled = false;
                    return;
                }
            }

            if (maskedTextBoxNewPin.Text.Contains(maskedTextBoxNewPinConf.Text))
            {

                buttonPinConfirm.Enabled = false;
                Pin = Convert.ToInt32(maskedTextBoxNewPin.Text);
                label2.Text = "Пин корректный";
                buttonPinConfirm.Enabled = true;
                return;
            }

            label2.Text = "Некорректный Пин";
            buttonPinConfirm.Enabled = false;
            return;
        }

        private void CreatePinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void maskedTextBoxNewPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void maskedTextBoxNewPinConf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void maskedTextBoxNewPin_TextChanged(object sender, EventArgs e)
        {
            CheckPin();
        }

        private void maskedTextBoxNewPinConf_TextChanged(object sender, EventArgs e)
        {
            CheckPin();
        }

        private void buttonPinConfirm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.MainForm.FormMenu.Show();
            Program.MainForm.Client = new Client(Pin);
            Program.MainForm.Client.AddLoggerFunction(Program.MainForm.FormInfo.AddLog);
            Program.MainForm.FormMenu.timerUpdateBalance.Start();
            Program.MainForm.RunBlockerFormAsync();
        }
    }
}
