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
            p_NA = new Panel();
            dataGridView1 = new DataGridView();
            p_NA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            b_NewAccount.Location = new Point(189, 91);
            b_NewAccount.Name = "b_NewAccount";
            b_NewAccount.Size = new Size(605, 75);
            b_NewAccount.TabIndex = 247;
            b_NewAccount.Text = "ログイン履歴";
            b_NewAccount.UseVisualStyleBackColor = false;
            b_NewAccount.Click += b_NewAccount_Click;
            // 
            // p_NA
            // 
            p_NA.BackColor = Color.FromArgb(212, 222, 255);
            p_NA.Controls.Add(dataGridView1);
            p_NA.Location = new Point(189, 160);
            p_NA.Name = "p_NA";
            p_NA.Size = new Size(1200, 600);
            p_NA.TabIndex = 249;
            p_NA.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1168, 574);
            dataGridView1.TabIndex = 250;
            // 
            // LoginKanriGamen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(p_NA);
            Controls.Add(b_NewAccount);
            Controls.Add(close);
            Name = "LoginKanriGamen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ログイン管理画面";
            Load += LoginKanriGamen_Load;
            p_NA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button PasswordChange;
        private Button NewAccount;
        private Button close;
        private Button b_NewAccount;
        private Panel p_NA;
        private DataGridView dataGridView1;
    }
}