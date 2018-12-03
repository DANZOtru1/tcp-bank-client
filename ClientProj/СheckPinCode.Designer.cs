namespace ClientProj
{
    partial class CheckPinCode
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.labelFileOpen = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this._buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Program File (*.*)|*.*";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(100, 55);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Открыть файл";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // labelFileOpen
            // 
            this.labelFileOpen.AutoSize = true;
            this.labelFileOpen.ForeColor = System.Drawing.Color.Black;
            this.labelFileOpen.Location = new System.Drawing.Point(9, 70);
            this.labelFileOpen.Name = "labelFileOpen";
            this.labelFileOpen.Size = new System.Drawing.Size(0, 13);
            this.labelFileOpen.TabIndex = 1;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(12, 86);
            this.maskedTextBox1.Mask = "000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 2;
            this.maskedTextBox1.UseSystemPasswordChar = true;
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.MaskedTextBox1_TextChanged);
            this.maskedTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaskedTextBox1_KeyPress);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 112);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 23);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // _buttonExit
            // 
            this._buttonExit.Location = new System.Drawing.Point(12, 141);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(98, 23);
            this._buttonExit.TabIndex = 7;
            this._buttonExit.Text = "Назад";
            this._buttonExit.UseVisualStyleBackColor = true;
            this._buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // CheckPinCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(122, 171);
            this.ControlBox = false;
            this.Controls.Add(this._buttonExit);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.labelFileOpen);
            this.Controls.Add(this.buttonOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CheckPinCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проверка пин";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonLogin;
        internal System.Windows.Forms.Label labelFileOpen;
        internal System.Windows.Forms.Button buttonOpenFile;
        internal System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button _buttonExit;
    }
}