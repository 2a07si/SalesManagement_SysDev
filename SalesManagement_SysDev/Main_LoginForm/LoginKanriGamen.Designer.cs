namespace SalesManagement_SysDev.Main_LoginForm
{
    partial class LoginKanriGamen
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
            PasswordChange = new Button();
            NewAccount = new Button();
            close = new Button();
            SuspendLayout();
            // 
            // PasswordChange
            // 
            PasswordChange.Location = new Point(227, 178);
            PasswordChange.Name = "PasswordChange";
            PasswordChange.Size = new Size(169, 34);
            PasswordChange.TabIndex = 0;
            PasswordChange.Text = "パスワード変更";
            PasswordChange.UseVisualStyleBackColor = true;
            // 
            // NewAccount
            // 
            NewAccount.Location = new Point(440, 178);
            NewAccount.Name = "NewAccount";
            NewAccount.Size = new Size(178, 34);
            NewAccount.TabIndex = 1;
            NewAccount.Text = "新規アカウント作成";
            NewAccount.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            close.Location = new Point(641, 38);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 245;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // LoginKanriGamen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(close);
            Controls.Add(NewAccount);
            Controls.Add(PasswordChange);
            Name = "LoginKanriGamen";
            Text = "LoginKanriGamen";
            ResumeLayout(false);
        }

        #endregion

        private Button PasswordChange;
        private Button NewAccount;
        private Button close;
    }
}