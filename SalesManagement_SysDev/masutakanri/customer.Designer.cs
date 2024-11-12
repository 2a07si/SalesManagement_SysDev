namespace SalesManagement_SysDev
{
    partial class customer
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
            components = new System.ComponentModel.Container();
            b_emp = new Button();
            b_mer = new Button();
            b_cus = new Button();
            b_sto = new Button();
            label_ename = new Label();
            label_id = new Label();
            b_ser = new Button();
            label4 = new Label();
            b_upd = new Button();
            label3 = new Label();
            b_reg = new Button();
            panel1 = new Panel();
            CusFlag = new CheckBox();
            TBFax = new MaskedTextBox();
            label9 = new Label();
            TBYuubinNo = new MaskedTextBox();
            label6 = new Label();
            TBTellNo = new MaskedTextBox();
            label8 = new Label();
            TBJyusyo = new MaskedTextBox();
            dataGridView1 = new DataGridView();
            label7 = new Label();
            TBKokyakuName = new MaskedTextBox();
            DelFlag = new CheckBox();
            TBShopID = new MaskedTextBox();
            label17 = new Label();
            TBKokyakuID = new MaskedTextBox();
            label5 = new Label();
            TBRiyuu = new MaskedTextBox();
            label14 = new Label();
            label12 = new Label();
            b_kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            b_iti = new Button();
            label2 = new Label();
            label10 = new Label();
            checkBox_2 = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.FromArgb(190, 255, 255);
            b_emp.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.ForeColor = Color.Black;
            b_emp.Location = new Point(15, 150);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(120, 70);
            b_emp.TabIndex = 8;
            b_emp.Text = "社員";
            b_emp.UseVisualStyleBackColor = false;
            b_emp.Click += b_emp_Click;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(190, 255, 255);
            b_mer.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.ForeColor = Color.Black;
            b_mer.Location = new Point(15, 230);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(120, 70);
            b_mer.TabIndex = 9;
            b_mer.Text = "商品";
            b_mer.UseVisualStyleBackColor = false;
            b_mer.Click += b_mer_Click;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.FromArgb(160, 220, 190);
            b_cus.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.ForeColor = Color.Black;
            b_cus.Location = new Point(15, 390);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(120, 90);
            b_cus.TabIndex = 11;
            b_cus.Text = "顧客";
            b_cus.UseVisualStyleBackColor = false;
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(190, 255, 255);
            b_sto.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.ForeColor = Color.Black;
            b_sto.Location = new Point(15, 310);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(120, 70);
            b_sto.TabIndex = 10;
            b_sto.Text = "在庫";
            b_sto.UseVisualStyleBackColor = false;
            b_sto.Click += b_sto_Click;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(165, 25);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 244;
            label_ename.Text = "label7";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(310, 25);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 243;
            label_id.Text = "label6";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(190, 255, 200);
            b_ser.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(690, 70);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(150, 70);
            b_ser.TabIndex = 3;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            b_ser.Click += b_ser_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 25);
            label4.Name = "label4";
            label4.Size = new Size(70, 25);
            label4.TabIndex = 242;
            label4.Text = "社員名:";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(190, 255, 200);
            b_upd.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(330, 70);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(150, 70);
            b_upd.TabIndex = 1;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            b_upd.Click += b_upd_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 25);
            label3.Name = "label3";
            label3.Size = new Size(52, 25);
            label3.TabIndex = 241;
            label3.Text = "権限:";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(190, 255, 200);
            b_reg.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(150, 70);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(150, 70);
            b_reg.TabIndex = 0;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            b_reg.Click += b_reg_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(160, 220, 190);
            panel1.Controls.Add(CusFlag);
            panel1.Controls.Add(TBFax);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(TBYuubinNo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(TBTellNo);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TBJyusyo);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(TBKokyakuName);
            panel1.Controls.Add(DelFlag);
            panel1.Controls.Add(TBShopID);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(TBKokyakuID);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label12);
            panel1.Location = new Point(150, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(1420, 690);
            panel1.TabIndex = 5;
            // 
            // CusFlag
            // 
            CusFlag.AutoSize = true;
            CusFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            CusFlag.Location = new Point(26, 119);
            CusFlag.Name = "CusFlag";
            CusFlag.Size = new Size(110, 29);
            CusFlag.TabIndex = 288;
            CusFlag.Text = "顧客管理";
            CusFlag.UseVisualStyleBackColor = true;
            // 
            // TBFax
            // 
            TBFax.Location = new Point(759, 70);
            TBFax.Name = "TBFax";
            TBFax.Size = new Size(125, 31);
            TBFax.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(709, 70);
            label9.Name = "label9";
            label9.Size = new Size(43, 25);
            label9.TabIndex = 12;
            label9.Text = "FAX";
            // 
            // TBYuubinNo
            // 
            TBYuubinNo.Location = new Point(727, 20);
            TBYuubinNo.Name = "TBYuubinNo";
            TBYuubinNo.Size = new Size(84, 31);
            TBYuubinNo.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(637, 20);
            label6.Name = "label6";
            label6.Size = new Size(84, 25);
            label6.TabIndex = 8;
            label6.Text = "郵便番号";
            // 
            // TBTellNo
            // 
            TBTellNo.Location = new Point(561, 70);
            TBTellNo.Name = "TBTellNo";
            TBTellNo.Size = new Size(133, 31);
            TBTellNo.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(471, 70);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 10;
            label8.Text = "電話番号";
            // 
            // TBJyusyo
            // 
            TBJyusyo.Location = new Point(90, 70);
            TBJyusyo.Name = "TBJyusyo";
            TBJyusyo.Size = new Size(375, 31);
            TBJyusyo.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 190);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1400, 490);
            dataGridView1.TabIndex = 19;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(32, 73);
            label7.Name = "label7";
            label7.Size = new Size(48, 25);
            label7.TabIndex = 6;
            label7.Text = "住所";
            // 
            // TBKokyakuName
            // 
            TBKokyakuName.Location = new Point(420, 20);
            TBKokyakuName.Name = "TBKokyakuName";
            TBKokyakuName.Size = new Size(200, 31);
            TBKokyakuName.TabIndex = 5;
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.Black;
            DelFlag.Location = new Point(159, 120);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 14;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // TBShopID
            // 
            TBShopID.Location = new Point(290, 20);
            TBShopID.Name = "TBShopID";
            TBShopID.Size = new Size(50, 31);
            TBShopID.TabIndex = 3;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(259, 120);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 15;
            label17.Text = "非表示理由";
            // 
            // TBKokyakuID
            // 
            TBKokyakuID.Location = new Point(90, 20);
            TBKokyakuID.Name = "TBKokyakuID";
            TBKokyakuID.Size = new Size(100, 31);
            TBKokyakuID.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(20, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 0;
            label5.Text = "顧客ID";
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(369, 120);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 16;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(350, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 4;
            label14.Text = "顧客名";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(200, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 2;
            label12.Text = "営業所ID";
            // 
            // b_kakutei
            // 
            b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
            b_kakutei.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_kakutei.Location = new Point(1200, 70);
            b_kakutei.Name = "b_kakutei";
            b_kakutei.Size = new Size(150, 70);
            b_kakutei.TabIndex = 6;
            b_kakutei.Text = "確定";
            b_kakutei.UseVisualStyleBackColor = false;
            b_kakutei.Click += b_kakutei_Click;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(1400, 70);
            clear.Name = "clear";
            clear.Size = new Size(150, 70);
            clear.TabIndex = 7;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // close
            // 
            close.Location = new Point(1450, 10);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 12;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // b_iti
            // 
            b_iti.BackColor = Color.FromArgb(190, 255, 200);
            b_iti.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_iti.Location = new Point(490, 70);
            b_iti.Name = "b_iti";
            b_iti.Size = new Size(150, 70);
            b_iti.TabIndex = 2;
            b_iti.Text = "一覧";
            b_iti.UseVisualStyleBackColor = false;
            b_iti.Click += b_iti_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(1100, 101);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 271;
            label2.Text = "未設定";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(1080, 71);
            label10.Name = "label10";
            label10.Size = new Size(108, 28);
            label10.TabIndex = 270;
            label10.Text = "現在の状態";
            // 
            // checkBox_2
            // 
            checkBox_2.AutoSize = true;
            checkBox_2.Location = new Point(585, 10);
            checkBox_2.Name = "checkBox_2";
            checkBox_2.Size = new Size(225, 29);
            checkBox_2.TabIndex = 272;
            checkBox_2.Text = "一覧表示に非表示も含む";
            checkBox_2.UseVisualStyleBackColor = true;
            // 
            // customer
            // 
            AcceptButton = b_kakutei;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = clear;
            ClientSize = new Size(1578, 844);
            Controls.Add(checkBox_2);
            Controls.Add(label2);
            Controls.Add(b_iti);
            Controls.Add(b_kakutei);
            Controls.Add(label10);
            Controls.Add(clear);
            Controls.Add(close);
            Controls.Add(b_emp);
            Controls.Add(b_mer);
            Controls.Add(b_cus);
            Controls.Add(b_sto);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(b_ser);
            Controls.Add(label4);
            Controls.Add(b_upd);
            Controls.Add(label3);
            Controls.Add(b_reg);
            Controls.Add(panel1);
            Name = "customer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "顧客";
            Load += customer_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button b_emp;
        private Button b_mer;
        private Button b_cus;
        private Button b_sto;
        private Label label_ename;
        private Button b_flg;
        private Label label_id;
        private Button b_ser;
        private Label label4;
        private Button b_upd;
        private Label label3;
        private Button b_reg;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Label labeldate;
        private Label labeltime;
        private Button b_kakutei;
        private Button clear;
        private Button close;
        private System.Windows.Forms.Timer timer1;
        private MaskedTextBox TBFax;
        private Label label9;
        private MaskedTextBox TBYuubinNo;
        private Label label6;
        private MaskedTextBox TBTellNo;
        private Label label8;
        private MaskedTextBox TBJyusyo;
        private Label label7;
        private MaskedTextBox TBKokyakuName;
        private CheckBox DelFlag;
        private MaskedTextBox TBShopID;
        private Label label17;
        private MaskedTextBox TBKokyakuID;
        private Label label5;
        private MaskedTextBox TBRiyuu;
        private Label label14;
        private Label label12;
        private Button b_iti;
        private Button Next;
        private Button Prev;
        private Label label1;
        private Label label2;
        private Label label10;
        private CheckBox CusFlag;
        private CheckBox checkBox_2;
    }
}