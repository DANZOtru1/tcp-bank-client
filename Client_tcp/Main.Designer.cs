namespace Client_tcp
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNewClient = new System.Windows.Forms.Button();
            this.buttonOldClient = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNewClient
            // 
            this.buttonNewClient.Location = new System.Drawing.Point(12, 12);
            this.buttonNewClient.Name = "buttonNewClient";
            this.buttonNewClient.Size = new System.Drawing.Size(132, 23);
            this.buttonNewClient.TabIndex = 1;
            this.buttonNewClient.Text = "Новый клиент";
            this.buttonNewClient.UseVisualStyleBackColor = true;
            this.buttonNewClient.Click += new System.EventHandler(this.buttonNewClient_Click);
            // 
            // buttonOldClient
            // 
            this.buttonOldClient.Location = new System.Drawing.Point(12, 41);
            this.buttonOldClient.Name = "buttonOldClient";
            this.buttonOldClient.Size = new System.Drawing.Size(132, 23);
            this.buttonOldClient.TabIndex = 2;
            this.buttonOldClient.Text = "Существующий клиент";
            this.buttonOldClient.UseVisualStyleBackColor = true;
            this.buttonOldClient.Click += new System.EventHandler(this.buttonOldClient_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(12, 70);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(132, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 102);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOldClient);
            this.Controls.Add(this.buttonNewClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNewClient;
        private System.Windows.Forms.Button buttonOldClient;
        private System.Windows.Forms.Button buttonExit;
    }
}

