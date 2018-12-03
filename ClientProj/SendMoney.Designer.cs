namespace ClientProj
{
    partial class SendMoney
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
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.textBoxSendSum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSendSum = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(16, 31);
            this.textBoxUserId.MaxLength = 32;
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(131, 20);
            this.textBoxUserId.TabIndex = 0;
            // 
            // textBoxSendSum
            // 
            this.textBoxSendSum.Location = new System.Drawing.Point(63, 57);
            this.textBoxSendSum.Name = "textBoxSendSum";
            this.textBoxSendSum.Size = new System.Drawing.Size(84, 20);
            this.textBoxSendSum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Лицевой счет получателя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сумма:";
            // 
            // buttonSendSum
            // 
            this.buttonSendSum.Location = new System.Drawing.Point(16, 83);
            this.buttonSendSum.Name = "buttonSendSum";
            this.buttonSendSum.Size = new System.Drawing.Size(131, 23);
            this.buttonSendSum.TabIndex = 4;
            this.buttonSendSum.Text = "Перевести";
            this.buttonSendSum.UseVisualStyleBackColor = true;
            this.buttonSendSum.Click += new System.EventHandler(this.ButtonSendSum_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(16, 112);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(131, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Отмена";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // SendMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 142);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSendSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSendSum);
            this.Controls.Add(this.textBoxUserId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SendMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевод";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.TextBox textBoxSendSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSendSum;
        private System.Windows.Forms.Button buttonClose;
    }
}