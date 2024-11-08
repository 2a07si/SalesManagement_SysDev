namespace SalesManagement_SysDev
{
    partial class merchandise
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
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            Next = new Button();
            Prev = new Button();
            TBColor = new MaskedTextBox();
            label16 = new Label();
            label10 = new Label();
            TBModel = new MaskedTextBox();
            label9 = new Label();
            TBSyoubunrui = new MaskedTextBox();
            label8 = new Label();
            DelFlag = new CheckBox();
            TBRiyuu = new MaskedTextBox();
            label17 = new Label();
            date = new DateTimePicker();
            TBSafeNum = new MaskedTextBox();
            label18 = new Label();
            label7 = new Label();
            TBSell = new MaskedTextBox();
            label12 = new Label();
            TBSyohinName = new MaskedTextBox();
            label5 = new Label();
            TBMakerId = new MaskedTextBox();
            label14 = new Label();
            TBSyohinID = new MaskedTextBox();
            label6 = new Label();
            b_reg = new Button();
            label3 = new Label();
            b_upd = new Button();
            label4 = new Label();
            b_ser = new Button();
            label_id = new Label();
            label_ename = new Label();
            b_sto = new Button();
            b_cus = new Button();
            b_mer = new Button();
            b_emp = new Button();
            b_kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            B_iti = new Button();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 190);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1400, 490);
            dataGridView1.TabIndex = 23;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(160, 220, 190);
            panel1.Controls.Add(Next);
            panel1.Controls.Add(Prev);
            panel1.Controls.Add(TBColor);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(TBModel);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(TBSyoubunrui);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(DelFlag);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(date);
            panel1.Controls.Add(TBSafeNum);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(TBSell);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(TBSyohinName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TBMakerId);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(TBSyohinID);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(150, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(1420, 690);
            panel1.TabIndex = 5;
            // 
            // Next
            // 
            Next.Location = new Point(1350, 144);
            Next.Name = "Next";
            Next.Size = new Size(40, 40);
            Next.TabIndex = 22;
            Next.Text = "▶";
            Next.UseVisualStyleBackColor = true;
            // 
            // Prev
            // 
            Prev.Location = new Point(1220, 144);
            Prev.Name = "Prev";
            Prev.Size = new Size(40, 40);
            Prev.TabIndex = 21;
            Prev.Text = "◀";
            Prev.UseVisualStyleBackColor = true;
            // 
            // TBColor
            // 
            TBColor.Location = new Point(290, 70);
            TBColor.Name = "TBColor";
            TBColor.Size = new Size(180, 31);
            TBColor.TabIndex = 15;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = Color.Black;
            label16.ImageAlign = ContentAlignment.MiddleRight;
            label16.Location = new Point(1270, 152);
            label16.Name = "label16";
            label16.Size = new Size(72, 25);
            label16.TabIndex = 290;
            label16.Text = "何ページ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(260, 70);
            label10.Name = "label10";
            label10.Size = new Size(30, 25);
            label10.TabIndex = 14;
            label10.Text = "色";
            // 
            // TBModel
            // 
            TBModel.Location = new Point(70, 70);
            TBModel.Name = "TBModel";
            TBModel.Size = new Size(180, 31);
            TBModel.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(20, 70);
            label9.Name = "label9";
            label9.Size = new Size(48, 25);
            label9.TabIndex = 12;
            label9.Text = "型番";
            // 
            // TBSyoubunrui
            // 
            TBSyoubunrui.Location = new Point(1090, 20);
            TBSyoubunrui.Name = "TBSyoubunrui";
            TBSyoubunrui.Size = new Size(40, 31);
            TBSyoubunrui.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(1000, 20);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 10;
            label8.Text = "小分類ID";
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.Black;
            DelFlag.Location = new Point(20, 120);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 18;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(230, 120);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 20;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(120, 120);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 19;
            label17.Text = "非表示理由";
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(550, 70);
            date.Name = "date";
            date.Size = new Size(160, 31);
            date.TabIndex = 17;
            date.ValueChanged += date_ValueChanged;
            // 
            // TBSafeNum
            // 
            TBSafeNum.Location = new Point(910, 20);
            TBSafeNum.Name = "TBSafeNum";
            TBSafeNum.Size = new Size(80, 31);
            TBSafeNum.TabIndex = 9;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(480, 70);
            label18.Name = "label18";
            label18.Size = new Size(66, 25);
            label18.TabIndex = 16;
            label18.Text = "発売日";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(800, 20);
            label7.Name = "label7";
            label7.Size = new Size(102, 25);
            label7.TabIndex = 8;
            label7.Text = "安全在庫数";
            // 
            // TBSell
            // 
            TBSell.Location = new Point(690, 20);
            TBSell.Name = "TBSell";
            TBSell.Size = new Size(100, 31);
            TBSell.TabIndex = 7;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(640, 21);
            label12.Name = "label12";
            label12.Size = new Size(48, 25);
            label12.TabIndex = 6;
            label12.Text = "値段";
            // 
            // TBSyohinName
            // 
            TBSyohinName.Location = new Point(450, 20);
            TBSyohinName.Name = "TBSyohinName";
            TBSyohinName.Size = new Size(180, 31);
            TBSyohinName.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(380, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 4;
            label5.Text = "商品名";
            // 
            // TBMakerId
            // 
            TBMakerId.Location = new Point(280, 20);
            TBMakerId.Name = "TBMakerId";
            TBMakerId.Size = new Size(80, 31);
            TBMakerId.TabIndex = 3;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(200, 20);
            label14.Name = "label14";
            label14.Size = new Size(81, 25);
            label14.TabIndex = 2;
            label14.Text = "メーカーID";
            // 
            // TBSyohinID
            // 
            TBSyohinID.Location = new Point(90, 20);
            TBSyohinID.Name = "TBSyohinID";
            TBSyohinID.Size = new Size(100, 31);
            TBSyohinID.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(20, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 0;
            label6.Text = "商品ID";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 25);
            label3.Name = "label3";
            label3.Size = new Size(52, 25);
            label3.TabIndex = 207;
            label3.Text = "権限:";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(190, 255, 200);
            b_upd.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(350, 70);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(150, 70);
            b_upd.TabIndex = 1;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            b_upd.Click += b_upd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 25);
            label4.Name = "label4";
            label4.Size = new Size(70, 25);
            label4.TabIndex = 208;
            label4.Text = "社員名:";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(190, 255, 200);
            b_ser.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(750, 70);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(150, 70);
            b_ser.TabIndex = 3;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            b_ser.Click += b_ser_Click;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(310, 25);
            label_id.Name = "label_id";
            label_id.Size = new Size(54, 25);
            label_id.TabIndex = 209;
            label_id.Text = "------";
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(165, 25);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(96, 25);
            label_ename.TabIndex = 210;
            label_ename.Text = "------------";
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(190, 255, 255);
            b_sto.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.ForeColor = Color.Black;
            b_sto.Location = new Point(13, 330);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(120, 70);
            b_sto.TabIndex = 11;
            b_sto.Text = "在庫";
            b_sto.UseVisualStyleBackColor = false;
            b_sto.Click += b_sto_Click;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.FromArgb(190, 255, 255);
            b_cus.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.ForeColor = Color.Black;
            b_cus.Location = new Point(13, 410);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(120, 70);
            b_cus.TabIndex = 12;
            b_cus.Text = "顧客";
            b_cus.UseVisualStyleBackColor = false;
            b_cus.Click += b_cus_Click;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(160, 220, 190);
            b_mer.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.ForeColor = Color.Black;
            b_mer.Location = new Point(15, 230);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(120, 90);
            b_mer.TabIndex = 10;
            b_mer.Text = "商品";
            b_mer.UseVisualStyleBackColor = false;
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.FromArgb(190, 255, 255);
            b_emp.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.ForeColor = Color.Black;
            b_emp.Location = new Point(15, 150);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(120, 70);
            b_emp.TabIndex = 9;
            b_emp.Text = "社員";
            b_emp.UseVisualStyleBackColor = false;
            b_emp.Click += b_emp_Click;
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
            b_kakutei.Click += b_kakutei_Click_1;
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
            close.Location = new Point(1450, 17);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 13;
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
            B_iti.BackColor = Color.FromArgb(190, 255, 200);
            B_iti.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            B_iti.Location = new Point(550, 70);
            B_iti.Name = "B_iti";
            B_iti.Size = new Size(150, 70);
            B_iti.TabIndex = 2;
            B_iti.Text = "一覧";
            B_iti.UseVisualStyleBackColor = false;
            B_iti.Click += B_iti_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(1100, 101);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 267;
            label2.Text = "未設定";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1080, 71);
            label1.Name = "label1";
            label1.Size = new Size(108, 28);
            label1.TabIndex = 269;
            label1.Text = "現在の状態";
            // 
            // merchandise
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(B_iti);
            Controls.Add(b_kakutei);
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
            Name = "merchandise";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "商品";
            Load += merchandise_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labeltime;
        private Label labeldate;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button b_reg;
        private Label label3;
        private Button b_upd;
        private Label label4;
        private Button b_ser;
        private Label label_id;
        private Button b_flg;
        private Label label_ename;
        private Button b_sto;
        private Button b_cus;
        private Button b_mer;
        private Button b_emp;
        private Button b_kakutei;
        private Button clear;
        private Button close;
        private System.Windows.Forms.Timer timer1;
        private CheckBox DelFlag;
        private MaskedTextBox TBRiyuu;
        private Label label17;
        private MaskedTextBox TBSafeNum;
        private Label label7;
        private MaskedTextBox TBSell;
        private Label label12;
        private MaskedTextBox TBSyohinName;
        private Label label5;
        private MaskedTextBox TBMakerId;
        private Label label14;
        private MaskedTextBox TBSyohinID;
        private Label label6;
        private Label label18;
        private MaskedTextBox TBSyoubunrui;
        private Label label8;
        private Label label10;
        private MaskedTextBox TBModel;
        private Label label9;
        private Button B_iti;
        private Label label1;
        private Label label2;
        private Button Next;
        private Button Prev;
        private Label label16;
        private MaskedTextBox TBColor;
        private DateTimePicker date;
    }
}