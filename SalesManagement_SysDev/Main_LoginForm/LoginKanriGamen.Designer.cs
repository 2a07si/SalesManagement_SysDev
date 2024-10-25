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
            PasswordChange.BackColor = Color.Navy;
            PasswordChange.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordChange.ForeColor = Color.Snow;
            PasswordChange.Location = new Point(100, 189);
            PasswordChange.Name = "PasswordChange";
            PasswordChange.Size = new Size(200, 90);
            PasswordChange.TabIndex = 0;
            PasswordChange.Text = "パスワード変更";
            PasswordChange.UseVisualStyleBackColor = false;
            // 
            // NewAccount
            // 
            NewAccount.BackColor = Color.Navy;
            NewAccount.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            NewAccount.ForeColor = Color.Snow;
            NewAccount.Location = new Point(480, 189);
            NewAccount.Name = "NewAccount";
            NewAccount.Size = new Size(200, 90);
            NewAccount.TabIndex = 1;
            NewAccount.Text = "新規アカウント作成";
            NewAccount.UseVisualStyleBackColor = false;
            // 
            // close
            // 
            close.Location = new Point(650, 20);
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
            ClientSize = new Size(778, 444);
            Controls.Add(close);
            Controls.Add(NewAccount);
            Controls.Add(PasswordChange);
            Name = "LoginKanriGamen";
            Text = "ログイン管理画面";
            ResumeLayout(false);
        }

        #endregion

        private Button PasswordChange;
        private Button NewAccount;
        private Button close;
    }
}