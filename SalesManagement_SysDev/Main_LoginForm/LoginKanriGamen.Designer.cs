﻿namespace SalesManagement_SysDev.Main_LoginForm
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
            PasswordChange.BackColor = Color.RoyalBlue;
            PasswordChange.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordChange.ForeColor = Color.White;
            PasswordChange.Location = new Point(561, 356);
            PasswordChange.Name = "PasswordChange";
            PasswordChange.Size = new Size(200, 90);
            PasswordChange.TabIndex = 0;
            PasswordChange.Text = "パスワード変更";
            PasswordChange.UseVisualStyleBackColor = false;
            // 
            // NewAccount
            // 
            NewAccount.BackColor = Color.RoyalBlue;
            NewAccount.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            NewAccount.ForeColor = Color.White;
            NewAccount.Location = new Point(941, 356);
            NewAccount.Name = "NewAccount";
            NewAccount.Size = new Size(200, 90);
            NewAccount.TabIndex = 1;
            NewAccount.Text = "新規アカウント作成";
            NewAccount.UseVisualStyleBackColor = false;
            // 
            // close
            // 
            close.Location = new Point(1435, 31);
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
            ClientSize = new Size(1578, 844);
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