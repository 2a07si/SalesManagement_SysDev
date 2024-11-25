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
            p_NA = new Panel();
            ComboLog = new ComboBox();
            LoginKensaku = new Button();
            listBox1 = new ListBox();
            dataGridView1 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            TB_Log = new TextBox();
            panel1 = new Panel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            TB_ID = new TextBox();
            ShousaiKensaku = new Button();
            dataGridView2 = new DataGridView();
            ComboGamen = new ComboBox();
            ComboMode = new ComboBox();
            ComboShori = new ComboBox();
            label1 = new Label();
            clear = new Button();
            p_NA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.Location = new Point(1264, 42);
            close.Name = "close";
            close.Size = new Size(136, 70);
            close.TabIndex = 245;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // p_NA
            // 
            p_NA.BackColor = Color.FromArgb(212, 222, 255);
            p_NA.Controls.Add(ComboLog);
            p_NA.Controls.Add(LoginKensaku);
            p_NA.Controls.Add(listBox1);
            p_NA.Controls.Add(dataGridView1);
            p_NA.Controls.Add(dateTimePicker1);
            p_NA.Controls.Add(TB_Log);
            p_NA.Location = new Point(160, 145);
            p_NA.Name = "p_NA";
            p_NA.Size = new Size(489, 690);
            p_NA.TabIndex = 249;
            // 
            // ComboLog
            // 
            ComboLog.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            ComboLog.FormattingEnabled = true;
            ComboLog.Items.AddRange(new object[] { "社員ID", "社員名", "ログイン日" });
            ComboLog.Location = new Point(16, 18);
            ComboLog.Name = "ComboLog";
            ComboLog.Size = new Size(248, 54);
            ComboLog.TabIndex = 255;
            // 
            // LoginKensaku
            // 
            LoginKensaku.BackColor = Color.FromArgb(255, 255, 192);
            LoginKensaku.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            LoginKensaku.Location = new Point(300, 18);
            LoginKensaku.Name = "LoginKensaku";
            LoginKensaku.Size = new Size(167, 113);
            LoginKensaku.TabIndex = 251;
            LoginKensaku.Text = "検索";
            LoginKensaku.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Items.AddRange(new object[] { "社員ID", "社員名", "ログイン日時" });
            listBox1.Location = new Point(16, 29);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(0, 4);
            listBox1.TabIndex = 251;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 144);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(451, 527);
            dataGridView1.TabIndex = 250;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Font = new Font("Yu Gothic UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Location = new Point(16, 84);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(248, 47);
            dateTimePicker1.TabIndex = 254;
            // 
            // TB_Log
            // 
            TB_Log.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Log.Location = new Point(16, 78);
            TB_Log.Name = "TB_Log";
            TB_Log.Size = new Size(246, 53);
            TB_Log.TabIndex = 259;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(TB_ID);
            panel1.Controls.Add(ShousaiKensaku);
            panel1.Controls.Add(dataGridView2);
            panel1.Controls.Add(ComboGamen);
            panel1.Controls.Add(ComboMode);
            panel1.Controls.Add(ComboShori);
            panel1.Location = new Point(649, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(751, 690);
            panel1.TabIndex = 250;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(19, 29);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 254;
            label3.Text = "画面";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(154, 29);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 255;
            label4.Text = "モード";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(289, 29);
            label5.Name = "label5";
            label5.Size = new Size(48, 25);
            label5.TabIndex = 256;
            label5.Text = "処理";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            label6.Location = new Point(427, 29);
            label6.Name = "label6";
            label6.Size = new Size(30, 25);
            label6.TabIndex = 257;
            label6.Text = "ID";
            // 
            // TB_ID
            // 
            TB_ID.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            TB_ID.Location = new Point(427, 66);
            TB_ID.Name = "TB_ID";
            TB_ID.Size = new Size(116, 53);
            TB_ID.TabIndex = 258;
            TB_ID.KeyDown += TB_ID_KeyDown_1;
            // 
            // ShousaiKensaku
            // 
            ShousaiKensaku.BackColor = Color.FromArgb(255, 255, 192);
            ShousaiKensaku.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            ShousaiKensaku.Location = new Point(565, 18);
            ShousaiKensaku.Name = "ShousaiKensaku";
            ShousaiKensaku.Size = new Size(167, 102);
            ShousaiKensaku.TabIndex = 252;
            ShousaiKensaku.Text = "検索";
            ShousaiKensaku.UseVisualStyleBackColor = false;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(19, 144);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(713, 527);
            dataGridView2.TabIndex = 251;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // ComboGamen
            // 
            ComboGamen.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            ComboGamen.FormattingEnabled = true;
            ComboGamen.Items.AddRange(new object[] { "受注", "注文", "出庫", "入荷", "出荷", "売上", "発注", "入庫", "社員", "商品", "在庫", "顧客" });
            ComboGamen.Location = new Point(19, 66);
            ComboGamen.Name = "ComboGamen";
            ComboGamen.Size = new Size(116, 54);
            ComboGamen.TabIndex = 255;
            // 
            // ComboMode
            // 
            ComboMode.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            ComboMode.FormattingEnabled = true;
            ComboMode.Items.AddRange(new object[] { "通常", "詳細" });
            ComboMode.Location = new Point(154, 66);
            ComboMode.Name = "ComboMode";
            ComboMode.Size = new Size(116, 54);
            ComboMode.TabIndex = 256;
            // 
            // ComboShori
            // 
            ComboShori.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            ComboShori.FormattingEnabled = true;
            ComboShori.Items.AddRange(new object[] { "登録", "更新", "確定" });
            ComboShori.Location = new Point(289, 66);
            ComboShori.Name = "ComboShori";
            ComboShori.Size = new Size(116, 54);
            ComboShori.TabIndex = 257;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(160, 42);
            label1.Name = "label1";
            label1.Size = new Size(246, 54);
            label1.TabIndex = 252;
            label1.Text = "ログ履歴画面";
            label1.Click += label1_Click;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(1093, 42);
            clear.Name = "clear";
            clear.Size = new Size(150, 70);
            clear.TabIndex = 253;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click_1;
            // 
            // LoginKanriGamen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(clear);
            Controls.Add(p_NA);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(close);
            Name = "LoginKanriGamen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ログイン管理画面";
            Load += LoginKanriGamen_Load;
            p_NA.ResumeLayout(false);
            p_NA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PasswordChange;
        private Button NewAccount;
        private Button close;
        private Panel p_NA;
        private DataGridView dataGridView1;
        private Panel panel1;
        private DataGridView dataGridView2;
        private Button LoginKensaku;
        private ListBox listBox1;
        private Button ShousaiKensaku;
        private Label label1;
        private ComboBox ComboLog;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox TB_ID;
        private ComboBox ComboGamen;
        private ComboBox ComboMode;
        private ComboBox ComboShori;
        private Label label3;
        private TextBox TB_Log;
        private Button clear;
        private DateTimePicker dateTimePicker1;
    }
}