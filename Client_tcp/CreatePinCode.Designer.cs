namespace Client_tcp
{
    partial class CreatePinCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maskedTextBoxNewPin = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxNewPinConf = new System.Windows.Forms.MaskedTextBox();
            this.buttonPinConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // maskedTextBoxNewPin
            // 
            this.maskedTextBoxNewPin.Location = new System.Drawing.Point(12, 25);
            this.maskedTextBoxNewPin.Mask = "000000";
            this.maskedTextBoxNewPin.Name = "maskedTextBoxNewPin";
            this.maskedTextBoxNewPin.Size = new System.Drawing.Size(82, 20);
            this.maskedTextBoxNewPin.TabIndex = 0;
            this.maskedTextBoxNewPin.UseSystemPasswordChar = true;
            this.maskedTextBoxNewPin.TextChanged += new System.EventHandler(this.maskedTextBoxNewPin_TextChanged);
            this.maskedTextBoxNewPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBoxNewPin_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите Пин";
            // 
            // maskedTextBoxNewPinConf
            // 
            this.maskedTextBoxNewPinConf.Location = new System.Drawing.Point(12, 51);
            this.maskedTextBoxNewPinConf.Mask = "000000";
            this.maskedTextBoxNewPinConf.Name = "maskedTextBoxNewPinConf";
            this.maskedTextBoxNewPinConf.Size = new System.Drawing.Size(82, 20);
            this.maskedTextBoxNewPinConf.TabIndex = 2;
            this.maskedTextBoxNewPinConf.UseSystemPasswordChar = true;
            this.maskedTextBoxNewPinConf.TextChanged += new System.EventHandler(this.maskedTextBoxNewPinConf_TextChanged);
            this.maskedTextBoxNewPinConf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBoxNewPinConf_KeyPress);
            // 
            // buttonPinConfirm
            // 
            this.buttonPinConfirm.Location = new System.Drawing.Point(12, 90);
            this.buttonPinConfirm.Name = "buttonPinConfirm";
            this.buttonPinConfirm.Size = new System.Drawing.Size(82, 23);
            this.buttonPinConfirm.TabIndex = 3;
            this.buttonPinConfirm.Text = "Подтвердить";
            this.buttonPinConfirm.UseVisualStyleBackColor = true;
            this.buttonPinConfirm.Click += new System.EventHandler(this.buttonPinConfirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // CreatePinCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(105, 119);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonPinConfirm);
            this.Controls.Add(this.maskedTextBoxNewPinConf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBoxNewPin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreatePinCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создать Пин";
            this.Load += new System.EventHandler(this.CreatePinCode_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreatePinCode_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBoxNewPin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNewPinConf;
        private System.Windows.Forms.Button buttonPinConfirm;
        private System.Windows.Forms.Label label2;
    }
}