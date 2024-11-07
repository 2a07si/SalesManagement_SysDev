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
            close = new Button();
            b_NewAccount = new Button();
            b_PassChange = new Button();
            p_PC = new Panel();
            tb_PCNP = new TextBox();
            label3 = new Label();
            tb_PCOP = new TextBox();
            label2 = new Label();
            tb_PCUI = new TextBox();
            b_PCOK = new Button();
            label1 = new Label();
            p_NA = new Panel();
            tb_NAJ = new TextBox();
            label4 = new Label();
            tb_NAP = new TextBox();
            label5 = new Label();
            tb_NAUI = new TextBox();
            b_NAOK = new Button();
            label6 = new Label();
            clear = new Button();
            p_PC.SuspendLayout();
            p_NA.SuspendLayout();
            SuspendLayout();
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
            // b_NewAccount
            // 
            b_NewAccount.BackColor = Color.FromArgb(212, 222, 255);
            b_NewAccount.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_NewAccount.Location = new Point(786, 85);
            b_NewAccount.Name = "b_NewAccount";
            b_NewAccount.Size = new Size(605, 75);
            b_NewAccount.TabIndex = 247;
            b_NewAccount.Text = "新規アカウント作成";
            b_NewAccount.UseVisualStyleBackColor = false;
            b_NewAccount.Click += b_NewAccount_Click;
            // 
            // b_PassChange
            // 
            b_PassChange.BackColor = Color.FromArgb(244, 226, 207);
            b_PassChange.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_PassChange.Location = new Point(187, 85);
            b_PassChange.Name = "b_PassChange";
            b_PassChange.Size = new Size(605, 75);
            b_PassChange.TabIndex = 246;
            b_PassChange.Text = "パスワード変更";
            b_PassChange.UseVisualStyleBackColor = false;
            b_PassChange.Click += b_PassChange_Click;
            // 
            // p_PC
            // 
            p_PC.BackColor = Color.FromArgb(244, 226, 207);
            p_PC.Controls.Add(tb_PCNP);
            p_PC.Controls.Add(label3);
            p_PC.Controls.Add(tb_PCOP);
            p_PC.Controls.Add(label2);
            p_PC.Controls.Add(tb_PCUI);
            p_PC.Controls.Add(b_PCOK);
            p_PC.Controls.Add(label1);
            p_PC.Location = new Point(189, 160);
            p_PC.Name = "p_PC";
            p_PC.Size = new Size(1200, 600);
            p_PC.TabIndex = 248;
            // 
            // tb_PCNP
            // 
            tb_PCNP.Location = new Point(350, 300);
            tb_PCNP.Name = "tb_PCNP";
            tb_PCNP.Size = new Size(500, 31);
            tb_PCNP.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(250, 300);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 5;
            label3.Text = "新パスワード";
            // 
            // tb_PCOP
            // 
            tb_PCOP.Location = new Point(350, 200);
            tb_PCOP.Name = "tb_PCOP";
            tb_PCOP.Size = new Size(500, 31);
            tb_PCOP.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 200);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 3;
            label2.Text = "現パスワード";
            // 
            // tb_PCUI
            // 
            tb_PCUI.Location = new Point(350, 100);
            tb_PCUI.Name = "tb_PCUI";
            tb_PCUI.Size = new Size(500, 31);
            tb_PCUI.TabIndex = 2;
            // 
            // b_PCOK
            // 
            b_PCOK.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_PCOK.Location = new Point(525, 400);
            b_PCOK.Name = "b_PCOK";
            b_PCOK.Size = new Size(150, 75);
            b_PCOK.TabIndex = 1;
            b_PCOK.Text = "確定";
            b_PCOK.UseVisualStyleBackColor = true;
            b_PCOK.Click += b_PCOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(260, 100);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 0;
            label1.Text = "ユーザーID";
            // 
            // p_NA
            // 
            p_NA.BackColor = Color.FromArgb(212, 222, 255);
            p_NA.Controls.Add(tb_NAJ);
            p_NA.Controls.Add(label4);
            p_NA.Controls.Add(tb_NAP);
            p_NA.Controls.Add(label5);
            p_NA.Controls.Add(tb_NAUI);
            p_NA.Controls.Add(b_NAOK);
            p_NA.Controls.Add(label6);
            p_NA.Location = new Point(189, 160);
            p_NA.Name = "p_NA";
            p_NA.Size = new Size(1200, 600);
            p_NA.TabIndex = 249;
            p_NA.Visible = false;
            // 
            // tb_NAJ
            // 
            tb_NAJ.Location = new Point(350, 300);
            tb_NAJ.Name = "tb_NAJ";
            tb_NAJ.Size = new Size(500, 31);
            tb_NAJ.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(291, 300);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 12;
            label4.Text = "役職";
            // 
            // tb_NAP
            // 
            tb_NAP.Location = new Point(350, 200);
            tb_NAP.Name = "tb_NAP";
            tb_NAP.Size = new Size(500, 31);
            tb_NAP.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(260, 200);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 10;
            label5.Text = "パスワード";
            // 
            // tb_NAUI
            // 
            tb_NAUI.Location = new Point(350, 100);
            tb_NAUI.Name = "tb_NAUI";
            tb_NAUI.Size = new Size(500, 31);
            tb_NAUI.TabIndex = 9;
            // 
            // b_NAOK
            // 
            b_NAOK.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_NAOK.Location = new Point(525, 400);
            b_NAOK.Name = "b_NAOK";
            b_NAOK.Size = new Size(150, 75);
            b_NAOK.TabIndex = 8;
            b_NAOK.Text = "確定";
            b_NAOK.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(260, 100);
            label6.Name = "label6";
            label6.Size = new Size(84, 25);
            label6.TabIndex = 7;
            label6.Text = "ユーザーID";
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(1000, 560);
            clear.Name = "clear";
            clear.Size = new Size(150, 75);
            clear.TabIndex = 7;
            clear.Text = "くりあ(仮)";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // LoginKanriGamen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(clear);
            Controls.Add(b_NewAccount);
            Controls.Add(b_PassChange);
            Controls.Add(close);
            Controls.Add(p_PC);
            Controls.Add(p_NA);
            Name = "LoginKanriGamen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ログイン管理画面";
            Load += LoginKanriGamen_Load;
            p_PC.ResumeLayout(false);
            p_PC.PerformLayout();
            p_NA.ResumeLayout(false);
            p_NA.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button PasswordChange;
        private Button NewAccount;
        private Button close;
        private Button b_NewAccount;
        private Button b_PassChange;
        private Panel p_PC;
        private Panel p_NA;
        private TextBox tb_PCNP;
        private Label label3;
        private TextBox tb_PCOP;
        private Label label2;
        private TextBox tb_PCUI;
        private Button b_PCOK;
        private Label label1;
        private TextBox tb_NAJ;
        private Label label4;
        private TextBox tb_NAP;
        private Label label5;
        private TextBox tb_NAUI;
        private Button b_NAOK;
        private Label label6;
        private Button clear;
    }
}