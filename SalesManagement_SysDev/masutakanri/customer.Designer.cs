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
            b_flg = new Button();
            label_id = new Label();
            b_ser = new Button();
            label4 = new Label();
            b_upd = new Button();
            label3 = new Label();
            b_reg = new Button();
            panel1 = new Panel();
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
            labeldate = new Label();
            labeltime = new Label();
            kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            B_iti = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.FromArgb(255, 255, 192);
            b_emp.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.ForeColor = Color.Black;
            b_emp.Location = new Point(15, 150);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(120, 50);
            b_emp.TabIndex = 248;
            b_emp.Text = "社員";
            b_emp.UseVisualStyleBackColor = false;
            b_emp.Click += b_emp_Click;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(255, 255, 192);
            b_mer.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.ForeColor = Color.Black;
            b_mer.Location = new Point(15, 220);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(120, 50);
            b_mer.TabIndex = 247;
            b_mer.Text = "商品";
            b_mer.UseVisualStyleBackColor = false;
            b_mer.Click += b_mer_Click;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.Navy;
            b_cus.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.ForeColor = Color.White;
            b_cus.Location = new Point(15, 355);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(120, 70);
            b_cus.TabIndex = 246;
            b_cus.Text = "顧客";
            b_cus.UseVisualStyleBackColor = false;
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(255, 255, 192);
            b_sto.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.ForeColor = Color.Black;
            b_sto.Location = new Point(15, 290);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(120, 50);
            b_sto.TabIndex = 245;
            b_sto.Text = "在庫";
            b_sto.UseVisualStyleBackColor = false;
            b_sto.Click += b_sto_Click;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(665, 30);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 244;
            label_ename.Text = "label7";
            // 
            // b_flg
            // 
            b_flg.BackColor = Color.FromArgb(192, 255, 255);
            b_flg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_flg.Location = new Point(710, 80);
            b_flg.Name = "b_flg";
            b_flg.Size = new Size(130, 50);
            b_flg.TabIndex = 235;
            b_flg.Text = "非表示";
            b_flg.UseVisualStyleBackColor = false;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(445, 30);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 243;
            label_id.Text = "label6";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(570, 80);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(130, 50);
            b_ser.TabIndex = 234;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 30);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 242;
            label4.Text = "社員名";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(290, 80);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(130, 50);
            b_upd.TabIndex = 233;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(400, 30);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 241;
            label3.Text = "権限";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(150, 80);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(130, 50);
            b_reg.TabIndex = 232;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
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
            panel1.Location = new Point(150, 135);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 600);
            panel1.TabIndex = 240;
            // 
            // TBFax
            // 
            TBFax.Location = new Point(585, 65);
            TBFax.Name = "TBFax";
            TBFax.Size = new Size(200, 31);
            TBFax.TabIndex = 277;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(540, 65);
            label9.Name = "label9";
            label9.Size = new Size(43, 25);
            label9.TabIndex = 276;
            label9.Text = "FAX";
            // 
            // TBYuubinNo
            // 
            TBYuubinNo.Location = new Point(395, 65);
            TBYuubinNo.Name = "TBYuubinNo";
            TBYuubinNo.Size = new Size(140, 31);
            TBYuubinNo.TabIndex = 273;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(310, 65);
            label6.Name = "label6";
            label6.Size = new Size(84, 25);
            label6.TabIndex = 272;
            label6.Text = "郵便番号";
            // 
            // TBTellNo
            // 
            TBTellNo.Location = new Point(105, 65);
            TBTellNo.Name = "TBTellNo";
            TBTellNo.Size = new Size(200, 31);
            TBTellNo.TabIndex = 275;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(15, 65);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 274;
            label8.Text = "電話番号";
            // 
            // TBJyusyo
            // 
            TBJyusyo.Location = new Point(675, 20);
            TBJyusyo.Name = "TBJyusyo";
            TBJyusyo.Size = new Size(200, 31);
            TBJyusyo.TabIndex = 259;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1000, 430);
            dataGridView1.TabIndex = 52;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(620, 20);
            label7.Name = "label7";
            label7.Size = new Size(48, 25);
            label7.TabIndex = 257;
            label7.Text = "住所";
            // 
            // TBKokyakuName
            // 
            TBKokyakuName.Location = new Point(410, 20);
            TBKokyakuName.Name = "TBKokyakuName";
            TBKokyakuName.Size = new Size(200, 31);
            TBKokyakuName.TabIndex = 264;
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.LavenderBlush;
            DelFlag.Location = new Point(15, 109);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 271;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // TBShopID
            // 
            TBShopID.Location = new Point(280, 20);
            TBShopID.Name = "TBShopID";
            TBShopID.Size = new Size(50, 31);
            TBShopID.TabIndex = 263;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(110, 110);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 265;
            label17.Text = "非表示理由";
            // 
            // TBKokyakuID
            // 
            TBKokyakuID.Location = new Point(80, 20);
            TBKokyakuID.Name = "TBKokyakuID";
            TBKokyakuID.Size = new Size(103, 31);
            TBKokyakuID.TabIndex = 270;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(15, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 269;
            label5.Text = "顧客ID";
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(210, 110);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 266;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(340, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 261;
            label14.Text = "顧客名";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(190, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 260;
            label12.Text = "営業所ID";
            // 
            // labeldate
            // 
            labeldate.AutoSize = true;
            labeldate.Location = new Point(140, 30);
            labeldate.Name = "labeldate";
            labeldate.Size = new Size(156, 25);
            labeldate.TabIndex = 238;
            labeldate.Text = "yyyy年mm月dd日";
            // 
            // labeltime
            // 
            labeltime.AutoSize = true;
            labeltime.Location = new Point(40, 30);
            labeltime.Name = "labeltime";
            labeltime.Size = new Size(80, 25);
            labeltime.TabIndex = 237;
            labeltime.Text = "11:11:11";
            // 
            // kakutei
            // 
            kakutei.BackColor = Color.FromArgb(255, 192, 192);
            kakutei.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            kakutei.Location = new Point(910, 80);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(130, 50);
            kakutei.TabIndex = 251;
            kakutei.Text = "確定";
            kakutei.UseVisualStyleBackColor = false;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(1050, 80);
            clear.Name = "clear";
            clear.Size = new Size(115, 50);
            clear.TabIndex = 250;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            close.Location = new Point(1060, 15);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 249;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // B_iti
            // 
            B_iti.BackColor = Color.FromArgb(192, 255, 255);
            B_iti.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            B_iti.Location = new Point(430, 80);
            B_iti.Name = "B_iti";
            B_iti.Size = new Size(130, 50);
            B_iti.TabIndex = 260;
            B_iti.Text = "一覧";
            B_iti.UseVisualStyleBackColor = false;
            // 
            // customer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(B_iti);
            Controls.Add(kakutei);
            Controls.Add(clear);
            Controls.Add(close);
            Controls.Add(b_emp);
            Controls.Add(b_mer);
            Controls.Add(b_cus);
            Controls.Add(b_sto);
            Controls.Add(label_ename);
            Controls.Add(b_flg);
            Controls.Add(label_id);
            Controls.Add(b_ser);
            Controls.Add(label4);
            Controls.Add(b_upd);
            Controls.Add(label3);
            Controls.Add(b_reg);
            Controls.Add(panel1);
            Controls.Add(labeldate);
            Controls.Add(labeltime);
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
        private Button kakutei;
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
        private Button B_iti;
    }
}