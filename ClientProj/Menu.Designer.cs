namespace ClientProj
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.labelClientIdText = new System.Windows.Forms.Label();
            this.labelClientId = new System.Windows.Forms.Label();
            this.buttonInfoShow = new System.Windows.Forms.Button();
            this.labelBalanceText = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timerUpdateBalance = new System.Windows.Forms.Timer(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonBuffer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelClientIdText
            // 
            this.labelClientIdText.AutoSize = true;
            this.labelClientIdText.Location = new System.Drawing.Point(12, 9);
            this.labelClientIdText.Name = "labelClientIdText";
            this.labelClientIdText.Size = new System.Drawing.Size(79, 13);
            this.labelClientIdText.TabIndex = 0;
            this.labelClientIdText.Text = "Лицевой счет:";
            //this.labelClientIdText.Click += new System.EventHandler(this.labelClientIdText_Click);
            // 
            // labelClientId
            // 
            this.labelClientId.AutoSize = true;
            this.labelClientId.ForeColor = System.Drawing.Color.Red;
            this.labelClientId.Location = new System.Drawing.Point(12, 22);
            this.labelClientId.Name = "labelClientId";
            this.labelClientId.Size = new System.Drawing.Size(135, 13);
            this.labelClientId.TabIndex = 1;
            this.labelClientId.Text = "********************************";
          //  this.labelClientId.Click += new System.EventHandler(this.labelClientId_Click);
            // 
            // buttonInfoShow
            // 
            this.buttonInfoShow.Location = new System.Drawing.Point(12, 60);
            this.buttonInfoShow.Name = "buttonInfoShow";
            this.buttonInfoShow.Size = new System.Drawing.Size(61, 22);
            this.buttonInfoShow.TabIndex = 2;
            this.buttonInfoShow.Text = "Выписка";
            this.buttonInfoShow.UseVisualStyleBackColor = true;
            this.buttonInfoShow.Click += new System.EventHandler(this.ButtonInfoShow_Click);
            // 
            // labelBalanceText
            // 
            this.labelBalanceText.AutoSize = true;
            this.labelBalanceText.Location = new System.Drawing.Point(12, 44);
            this.labelBalanceText.Name = "labelBalanceText";
            this.labelBalanceText.Size = new System.Drawing.Size(47, 13);
            this.labelBalanceText.TabIndex = 3;
            this.labelBalanceText.Text = "Баланс:";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.ForeColor = System.Drawing.Color.Green;
            this.labelBalance.Location = new System.Drawing.Point(65, 44);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(27, 13);
            this.labelBalance.TabIndex = 4;
            this.labelBalance.Text = "*****";
         //   this.labelBalance.Click += new System.EventHandler(this.labelBalance_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 22);
            this.button1.TabIndex = 5;
            this.button1.Text = "Перевод";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // timerUpdateBalance
            // 
            this.timerUpdateBalance.Interval = 1000;
            this.timerUpdateBalance.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(144, 60);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(58, 22);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // buttonBuffer
            // 
            this.buttonBuffer.Location = new System.Drawing.Point(12, 88);
            this.buttonBuffer.Name = "buttonBuffer";
            this.buttonBuffer.Size = new System.Drawing.Size(190, 36);
            this.buttonBuffer.TabIndex = 7;
            this.buttonBuffer.Text = "Скопировать лицевой счет в буфер обмена";
            this.buttonBuffer.UseVisualStyleBackColor = true;
            this.buttonBuffer.Click += new System.EventHandler(this.ButtonBuffer_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 130);
            this.ControlBox = false;
            this.Controls.Add(this.buttonBuffer);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.labelBalanceText);
            this.Controls.Add(this.buttonInfoShow);
            this.Controls.Add(this.labelClientId);
            this.Controls.Add(this.labelClientIdText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClientIdText;
        public System.Windows.Forms.Label labelClientId;
        private System.Windows.Forms.Button buttonInfoShow;
        private System.Windows.Forms.Label labelBalanceText;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labelBalance;
        internal System.Windows.Forms.Timer timerUpdateBalance;
        internal System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonBuffer;
    }
}