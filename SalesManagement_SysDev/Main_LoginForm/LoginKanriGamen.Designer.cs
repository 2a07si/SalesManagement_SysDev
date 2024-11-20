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
            LoginKensaku = new Button();
            listBox1 = new ListBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            ShousaiKensaku = new Button();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            p_NA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // close
            // 
            close.Location = new Point(1413, 31);
            close.Name = "close";
            close.Size = new Size(122, 56);
            close.TabIndex = 245;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // p_NA
            // 
            p_NA.BackColor = Color.FromArgb(212, 222, 255);
            p_NA.Controls.Add(label2);
            p_NA.Controls.Add(comboBox1);
            p_NA.Controls.Add(LoginKensaku);
            p_NA.Controls.Add(listBox1);
            p_NA.Controls.Add(dataGridView1);
            p_NA.Location = new Point(150, 122);
            p_NA.Name = "p_NA";
            p_NA.Size = new Size(489, 690);
            p_NA.TabIndex = 249;
            // 
            // LoginKensaku
            // 
            LoginKensaku.BackColor = Color.FromArgb(255, 255, 192);
            LoginKensaku.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            LoginKensaku.Location = new Point(300, 29);
            LoginKensaku.Name = "LoginKensaku";
            LoginKensaku.Size = new Size(167, 91);
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
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(451, 527);
            dataGridView1.TabIndex = 250;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(ShousaiKensaku);
            panel1.Controls.Add(dataGridView2);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox4);
            panel1.Location = new Point(639, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(750, 690);
            panel1.TabIndex = 250;
            // 
            // ShousaiKensaku
            // 
            ShousaiKensaku.BackColor = Color.FromArgb(255, 255, 192);
            ShousaiKensaku.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            ShousaiKensaku.Location = new Point(565, 29);
            ShousaiKensaku.Name = "ShousaiKensaku";
            ShousaiKensaku.Size = new Size(167, 91);
            ShousaiKensaku.TabIndex = 252;
            ShousaiKensaku.Text = "検索";
            ShousaiKensaku.UseVisualStyleBackColor = false;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(19, 144);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.Size = new Size(713, 527);
            dataGridView2.TabIndex = 251;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(188, 33);
            label1.Name = "label1";
            label1.Size = new Size(302, 54);
            label1.TabIndex = 252;
            label1.Text = "ログイン管理画面";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "社員ID", "社員名", "ログイン日時" });
            comboBox1.Location = new Point(16, 66);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(248, 54);
            comboBox1.TabIndex = 255;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "受注", "注文", "出庫", "入荷", "出荷", "売上", "発注", "入庫", "社員", "商品", "在庫", "顧客" });
            comboBox2.Location = new Point(19, 66);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(116, 54);
            comboBox2.TabIndex = 255;
            // 
            // comboBox3
            // 
            comboBox3.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "通常", "詳細" });
            comboBox3.Location = new Point(154, 66);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(116, 54);
            comboBox3.TabIndex = 256;
            // 
            // comboBox4
            // 
            comboBox4.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "登録", "更新", "確定" });
            comboBox4.Location = new Point(289, 66);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(116, 54);
            comboBox4.TabIndex = 257;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Yu Gothic UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(427, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(116, 53);
            textBox1.TabIndex = 258;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(16, 29);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 253;
            label2.Text = "検索条件";
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
            // LoginKanriGamen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
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
        private Label label2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Label label3;
    }
}