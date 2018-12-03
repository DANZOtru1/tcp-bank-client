using System;
using System.Threading;
using System.Windows.Forms;

namespace ClientProj
{
    public partial class CreatePinCode : Form
    {
        #region Readonly fields

        public readonly SynchronizationContext SynchronizationContext;

        #endregion

        #region Private fields

        private int _pin;

        #endregion

        #region Constructor

        public CreatePinCode()
        {
            InitializeComponent();
            SynchronizationContext = SynchronizationContext.Current;
        }

        #endregion

        #region Private methods

        private void CreatePinCode_Load(object sender, EventArgs e)
        {
            buttonPinConfirm.Enabled = false;
        }

        private void CheckPin()
        {
            if (maskedTextBoxNewPin.Text.Length < 6 ||
                maskedTextBoxNewPinConf.Text.Length < 6)
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

            if (maskedTextBoxNewPin.Text.Contains(maskedTextBoxNewPinConf.Text)
            ) 
            {
                buttonPinConfirm.Enabled = false;
                _pin = Convert.ToInt32(maskedTextBoxNewPin.Text);
                label2.Text = "Пин корректный";
                buttonPinConfirm.Enabled = true;
                return;
            }

            label2.Text = "Некорректный Пин";
            buttonPinConfirm.Enabled = false;
        }

        private void
            CreatePinCode_KeyPress(object sender,
                KeyPressEventArgs e) 
        {
            if (e.KeyChar == (int) Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void MaskedTextBoxNewPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void MaskedTextBoxNewPinConf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Space)
            {
                e.KeyChar = '\0';
            }
        }

        private void MaskedTextBoxNewPin_TextChanged(object sender, EventArgs e)
        {
            CheckPin();
        }

        private void MaskedTextBoxNewPinConf_TextChanged(object sender, EventArgs e)
        {
            CheckPin();
        }

        private void ButtonPinConfirm_Click(object sender, EventArgs e)
        {
            Hide();
            Program.MainForm.FormMenu.Show();
            Program.MainForm.Client = new Client(_pin);
            Program.MainForm.Client.AddLoggerFunction(Program.MainForm.FormInfo.AddLog);
            Program.MainForm.FormMenu.timerUpdateBalance.Start();
            Program.MainForm.RunBlockerFormAsync();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Program.MainForm.Show();
            Hide();
        }

        #endregion
    }
}