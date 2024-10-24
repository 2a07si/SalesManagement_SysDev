namespace SalesManagement_SysDev
{
    partial class acceptingorders
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
            kakutei = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            b_kakutei = new Button();
            clear = new Button();
            close = new Button();
            label_ename = new Label();
            label_id = new Label();
            b_ser = new Button();
            label4 = new Label();
            b_upd = new Button();
            label3 = new Label();
            b_reg = new Button();
            b_ord = new Button();
            b_sal = new Button();
            b_add = new Button();
            b_shi = new Button();
            b_arr = new Button();
            b_lss = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            Next = new Button();
            Prev = new Button();
            label8 = new Label();
            TBTantoName = new MaskedTextBox();
            TyumonFlag = new CheckBox();
            DelFlag = new CheckBox();
            TBKokyakuID = new MaskedTextBox();
            label5 = new Label();
            date = new DateTimePicker();
            label18 = new Label();
            TBRiyuu = new MaskedTextBox();
            label17 = new Label();
            TBShainID = new MaskedTextBox();
            TBShopID = new MaskedTextBox();
            TBJyutyuID = new MaskedTextBox();
            label14 = new Label();
            label12 = new Label();
            label7 = new Label();
            label6 = new Label();
            B_iti = new Button();
            panel3 = new Panel();
            TBGoukeiKingaku = new MaskedTextBox();
            label11 = new Label();
            TBJyutyuSyosaiID = new MaskedTextBox();
            dataGridView2 = new DataGridView();
            TBSuryou = new MaskedTextBox();
            label15 = new Label();
            label9 = new Label();
            label13 = new Label();
            TBSyohinID = new MaskedTextBox();
            label10 = new Label();
            TBJyutyuIDS = new MaskedTextBox();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // kakutei
            // 
            kakutei.Location = new Point(0, 0);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(75, 23);
            kakutei.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // b_kakutei
            // 
            b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
            b_kakutei.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_kakutei.Location = new Point(1200, 70);
            b_kakutei.Name = "b_kakutei";
            b_kakutei.Size = new Size(150, 70);
            b_kakutei.TabIndex = 257;
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
            clear.TabIndex = 256;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // close
            // 
            close.Location = new Point(1460, 10);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 242;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click_1;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(165, 25);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(96, 25);
            label_ename.TabIndex = 255;
            label_ename.Text = "------------";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(310, 25);
            label_id.Name = "label_id";
            label_id.Size = new Size(54, 25);
            label_id.TabIndex = 254;
            label_id.Text = "------";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(750, 70);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(150, 70);
            b_ser.TabIndex = 240;
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
            label4.TabIndex = 253;
            label4.Text = "社員名:";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(350, 70);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(150, 70);
            b_upd.TabIndex = 239;
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
            label3.TabIndex = 252;
            label3.Text = "権限:";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(150, 70);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(150, 70);
            b_reg.TabIndex = 238;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            //b_reg.Click += b_reg_Click;
            // 
            // b_ord
            // 
            b_ord.BackColor = Color.FromArgb(255, 255, 192);
            b_ord.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.ForeColor = Color.Black;
            b_ord.Location = new Point(15, 250);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(120, 70);
            b_ord.TabIndex = 251;
            b_ord.Text = "注文";
            b_ord.UseVisualStyleBackColor = false;
            b_ord.Click += b_ord_Click;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(255, 255, 192);
            b_sal.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.ForeColor = Color.Black;
            b_sal.Location = new Point(15, 570);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(120, 70);
            b_sal.TabIndex = 250;
            b_sal.Text = "売上";
            b_sal.UseVisualStyleBackColor = false;
            b_sal.Click += b_sal_Click;
            // 
            // b_add
            // 
            b_add.BackColor = Color.Navy;
            b_add.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_add.ForeColor = Color.White;
            b_add.Location = new Point(15, 150);
            b_add.Name = "b_add";
            b_add.Size = new Size(120, 90);
            b_add.TabIndex = 249;
            b_add.Text = "受注";
            b_add.UseVisualStyleBackColor = false;
            // 
            // b_shi
            // 
            b_shi.BackColor = Color.FromArgb(255, 255, 192);
            b_shi.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.ForeColor = Color.Black;
            b_shi.Location = new Point(15, 490);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(120, 70);
            b_shi.TabIndex = 248;
            b_shi.Text = "出荷";
            b_shi.UseVisualStyleBackColor = false;
            b_shi.Click += b_shi_Click;
            // 
            // b_arr
            // 
            b_arr.BackColor = Color.FromArgb(255, 255, 192);
            b_arr.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.ForeColor = Color.Black;
            b_arr.Location = new Point(15, 410);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(120, 70);
            b_arr.TabIndex = 247;
            b_arr.Text = "入荷";
            b_arr.UseVisualStyleBackColor = false;
            b_arr.Click += b_arr_Click_1;
            // 
            // b_lss
            // 
            b_lss.BackColor = Color.FromArgb(255, 255, 192);
            b_lss.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_lss.ForeColor = Color.Black;
            b_lss.Location = new Point(15, 330);
            b_lss.Name = "b_lss";
            b_lss.Size = new Size(120, 70);
            b_lss.TabIndex = 246;
            b_lss.Text = "出庫";
            b_lss.UseVisualStyleBackColor = false;
            b_lss.Click += b_lss_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(Next);
            panel1.Controls.Add(Prev);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TBTantoName);
            panel1.Controls.Add(TyumonFlag);
            panel1.Controls.Add(DelFlag);
            panel1.Controls.Add(TBKokyakuID);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(date);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(TBShainID);
            panel1.Controls.Add(TBShopID);
            panel1.Controls.Add(TBJyutyuID);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(150, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(820, 690);
            panel1.TabIndex = 245;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 190);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(800, 490);
            dataGridView1.TabIndex = 52;
            // 
            // Next
            // 
            Next.Location = new Point(770, 144);
            Next.Name = "Next";
            Next.Size = new Size(40, 40);
            Next.TabIndex = 2;
            Next.Text = "▶";
            Next.UseVisualStyleBackColor = true;
            // 
            // Prev
            // 
            Prev.Location = new Point(640, 144);
            Prev.Name = "Prev";
            Prev.Size = new Size(40, 40);
            Prev.TabIndex = 1;
            Prev.Text = "◀";
            Prev.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Snow;
            label8.ImageAlign = ContentAlignment.MiddleRight;
            label8.Location = new Point(690, 152);
            label8.Name = "label8";
            label8.Size = new Size(72, 25);
            label8.TabIndex = 0;
            label8.Text = "何ページ";
            // 
            // TBTantoName
            // 
            TBTantoName.Location = new Point(130, 70);
            TBTantoName.Name = "TBTantoName";
            TBTantoName.Size = new Size(140, 31);
            TBTantoName.TabIndex = 267;
            // 
            // TyumonFlag
            // 
            TyumonFlag.AutoSize = true;
            TyumonFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TyumonFlag.ForeColor = Color.LavenderBlush;
            TyumonFlag.Location = new Point(590, 70);
            TyumonFlag.Name = "TyumonFlag";
            TyumonFlag.Size = new Size(110, 29);
            TyumonFlag.TabIndex = 79;
            TyumonFlag.Text = "注文状態";
            TyumonFlag.UseVisualStyleBackColor = true;
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.FlatStyle = FlatStyle.Flat;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.LavenderBlush;
            DelFlag.Location = new Point(20, 120);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(87, 29);
            DelFlag.TabIndex = 78;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // TBKokyakuID
            // 
            TBKokyakuID.Location = new Point(590, 20);
            TBKokyakuID.Name = "TBKokyakuID";
            TBKokyakuID.Size = new Size(100, 31);
            TBKokyakuID.TabIndex = 77;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(520, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 76;
            label5.Text = "顧客ID";
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(390, 70);
            date.Name = "date";
            date.Size = new Size(185, 31);
            date.TabIndex = 75;
            date.ValueChanged += date_ValueChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(280, 70);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 74;
            label18.Text = "受注年月日";
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(230, 120);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 73;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(120, 120);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 72;
            label17.Text = "非表示理由";
            // 
            // TBShainID
            // 
            TBShainID.Location = new Point(410, 20);
            TBShainID.Name = "TBShainID";
            TBShainID.Size = new Size(100, 31);
            TBShainID.TabIndex = 69;
            // 
            // TBShopID
            // 
            TBShopID.Location = new Point(290, 20);
            TBShopID.Name = "TBShopID";
            TBShopID.Size = new Size(40, 31);
            TBShopID.TabIndex = 66;
            // 
            // TBJyutyuID
            // 
            TBJyutyuID.Location = new Point(90, 20);
            TBJyutyuID.Name = "TBJyutyuID";
            TBJyutyuID.Size = new Size(100, 31);
            TBJyutyuID.TabIndex = 64;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(340, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 62;
            label14.Text = "社員ID";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(200, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 60;
            label12.Text = "営業所ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(20, 70);
            label7.Name = "label7";
            label7.Size = new Size(102, 25);
            label7.TabIndex = 55;
            label7.Text = "担当社員名";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(20, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 54;
            label6.Text = "受注ID";
            // 
            // B_iti
            // 
            B_iti.BackColor = Color.FromArgb(192, 255, 255);
            B_iti.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            B_iti.Location = new Point(550, 70);
            B_iti.Name = "B_iti";
            B_iti.Size = new Size(150, 70);
            B_iti.TabIndex = 258;
            B_iti.Text = "一覧";
            B_iti.UseVisualStyleBackColor = false;
            B_iti.Click += B_iti_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkRed;
            panel3.Controls.Add(TBGoukeiKingaku);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(TBJyutyuSyosaiID);
            panel3.Controls.Add(dataGridView2);
            panel3.Controls.Add(TBSuryou);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(TBSyohinID);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(TBJyutyuIDS);
            panel3.Location = new Point(970, 145);
            panel3.Name = "panel3";
            panel3.Size = new Size(600, 690);
            panel3.TabIndex = 260;
            // 
            // TBGoukeiKingaku
            // 
            TBGoukeiKingaku.Location = new Point(280, 70);
            TBGoukeiKingaku.Name = "TBGoukeiKingaku";
            TBGoukeiKingaku.Size = new Size(100, 31);
            TBGoukeiKingaku.TabIndex = 279;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(190, 70);
            label11.Name = "label11";
            label11.Size = new Size(84, 25);
            label11.TabIndex = 278;
            label11.Text = "合計金額";
            // 
            // TBJyutyuSyosaiID
            // 
            TBJyutyuSyosaiID.Location = new Point(130, 20);
            TBJyutyuSyosaiID.Name = "TBJyutyuSyosaiID";
            TBJyutyuSyosaiID.Size = new Size(100, 31);
            TBJyutyuSyosaiID.TabIndex = 277;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(10, 190);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.Size = new Size(580, 490);
            dataGridView2.TabIndex = 52;
            // 
            // TBSuryou
            // 
            TBSuryou.Location = new Point(80, 70);
            TBSuryou.Name = "TBSuryou";
            TBSuryou.Size = new Size(100, 31);
            TBSuryou.TabIndex = 276;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(240, 20);
            label15.Name = "label15";
            label15.Size = new Size(66, 25);
            label15.TabIndex = 268;
            label15.Text = "受注ID";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(20, 70);
            label9.Name = "label9";
            label9.Size = new Size(48, 25);
            label9.TabIndex = 275;
            label9.Text = "数量";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(20, 20);
            label13.Name = "label13";
            label13.Size = new Size(102, 25);
            label13.TabIndex = 269;
            label13.Text = "受注詳細ID";
            // 
            // TBSyohinID
            // 
            TBSyohinID.Location = new Point(490, 20);
            TBSyohinID.Name = "TBSyohinID";
            TBSyohinID.Size = new Size(100, 31);
            TBSyohinID.TabIndex = 274;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(420, 20);
            label10.Name = "label10";
            label10.Size = new Size(66, 25);
            label10.TabIndex = 271;
            label10.Text = "商品ID";
            // 
            // TBJyutyuIDS
            // 
            TBJyutyuIDS.Location = new Point(310, 20);
            TBJyutyuIDS.Name = "TBJyutyuIDS";
            TBJyutyuIDS.Size = new Size(100, 31);
            TBJyutyuIDS.TabIndex = 272;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1080, 70);
            label1.Name = "label1";
            label1.Size = new Size(108, 28);
            label1.TabIndex = 261;
            label1.Text = "現在の状態";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(1100, 98);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 262;
            label2.Text = "未選択";
            label2.Click += label2_Click;
            // 
            // acceptingorders
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(B_iti);
            Controls.Add(b_kakutei);
            Controls.Add(clear);
            Controls.Add(close);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(b_ser);
            Controls.Add(label4);
            Controls.Add(b_upd);
            Controls.Add(label3);
            Controls.Add(b_reg);
            Controls.Add(b_ord);
            Controls.Add(b_sal);
            Controls.Add(b_add);
            Controls.Add(b_shi);
            Controls.Add(b_arr);
            Controls.Add(b_lss);
            Controls.Add(panel1);
            Name = "acceptingorders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "受注";
            Load += acceptingorders_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button kakutei;
        private System.Windows.Forms.Timer timer1;
        private Button b_kakutei;
        private Button clear;
        private Button close;
        private Label label_ename;
        private Label label_id;
        private Button b_ser;
        private Label label4;
        private Button b_upd;
        private Label label3;
        private Button b_reg;
        private Button b_ord;
        private Button b_sal;
        private Button b_add;
        private Button b_shi;
        private Button b_arr;
        private Button b_lss;
        private Panel panel1;
        private CheckBox TyumonFlag;
        private CheckBox DelFlag;
        private MaskedTextBox TBKokyakuID;
        private Label label5;
        private DateTimePicker date;
        private Label label18;
        private MaskedTextBox TBRiyuu;
        private Label label17;
        private MaskedTextBox TBShainID;
        private MaskedTextBox TBShopID;
        private MaskedTextBox TBJyutyuID;
        private Label label14;
        private Label label12;
        private Label label7;
        private Label label6;
        private MaskedTextBox TBTantoName;
        private Button B_iti;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Button Next;
        private Button Prev;
        private Label label8;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView2;
        private MaskedTextBox TBJyutyuSyosaiID;
        private MaskedTextBox TBSuryou;
        private Label label15;
        private Label label9;
        private Label label13;
        private MaskedTextBox TBSyohinID;
        private Label label10;
        private MaskedTextBox TBJyutyuIDS;
        private MaskedTextBox TBGoukeiKingaku;
        private Label label11;
    }
}