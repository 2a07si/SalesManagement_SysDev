namespace SalesManagement_SysDev
{
    partial class arrival
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
            label_ename = new Label();
            label_id = new Label();
            b_ser = new Button();
            label4 = new Label();
            b_upd = new Button();
            label3 = new Label();
            b_reg = new Button();
            panel1 = new Panel();
            label8 = new Label();
            TBJyutyu = new MaskedTextBox();
            Nyuukaflag = new CheckBox();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            DelFlag = new CheckBox();
            label6 = new Label();
            TBKokyaku = new MaskedTextBox();
            label5 = new Label();
            date = new DateTimePicker();
            label12 = new Label();
            label18 = new Label();
            label14 = new Label();
            TBRiyuu = new MaskedTextBox();
            TBNyuuka = new MaskedTextBox();
            label17 = new Label();
            TBShopId = new MaskedTextBox();
            TBShainId = new MaskedTextBox();
            b_acc = new Button();
            b_sal = new Button();
            b_ord = new Button();
            b_shi = new Button();
            b_arr = new Button();
            b_lss = new Button();
            b_kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            B_iti = new Button();
            panel3 = new Panel();
            TBNyuukaIDS = new MaskedTextBox();
            TBNyukaSyosaiID = new MaskedTextBox();
            dataGridView2 = new DataGridView();
            TBSuryou = new MaskedTextBox();
            label15 = new Label();
            label9 = new Label();
            label13 = new Label();
            TBSyohinID = new MaskedTextBox();
            label10 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(165, 25);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(96, 25);
            label_ename.TabIndex = 157;
            label_ename.Text = "------------";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(310, 25);
            label_id.Name = "label_id";
            label_id.Size = new Size(54, 25);
            label_id.TabIndex = 156;
            label_id.Text = "------";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(750, 70);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(150, 70);
            b_ser.TabIndex = 141;
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
            label4.TabIndex = 155;
            label4.Text = "社員名:";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(350, 70);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(150, 70);
            b_upd.TabIndex = 140;
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
            label3.TabIndex = 154;
            label3.Text = "権限:";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(150, 70);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(150, 70);
            b_reg.TabIndex = 139;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            b_reg.Click += b_reg_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TBJyutyu);
            panel1.Controls.Add(Nyuukaflag);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(DelFlag);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(TBKokyaku);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(date);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(TBNyuuka);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(TBShopId);
            panel1.Controls.Add(TBShainId);
            panel1.Location = new Point(150, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(820, 690);
            panel1.TabIndex = 147;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.ImageAlign = ContentAlignment.MiddleRight;
            label8.Location = new Point(690, 152);
            label8.Name = "label8";
            label8.Size = new Size(72, 25);
            label8.TabIndex = 257;
            label8.Text = "何ページ";
            // 
            // TBJyutyu
            // 
            TBJyutyu.Location = new Point(90, 70);
            TBJyutyu.Name = "TBJyutyu";
            TBJyutyu.Size = new Size(100, 31);
            TBJyutyu.TabIndex = 242;
            // 
            // Nyuukaflag
            // 
            Nyuukaflag.AutoSize = true;
            Nyuukaflag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Nyuukaflag.ForeColor = Color.White;
            Nyuukaflag.Location = new Point(500, 70);
            Nyuukaflag.Name = "Nyuukaflag";
            Nyuukaflag.Size = new Size(110, 29);
            Nyuukaflag.TabIndex = 256;
            Nyuukaflag.Text = "注文状態";
            Nyuukaflag.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(20, 70);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 241;
            label7.Text = "受注ID";
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
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.White;
            DelFlag.Location = new Point(20, 120);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 255;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(20, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 241;
            label6.Text = "入荷ID";
            // 
            // TBKokyaku
            // 
            TBKokyaku.Location = new Point(590, 20);
            TBKokyaku.Name = "TBKokyaku";
            TBKokyaku.Size = new Size(100, 31);
            TBKokyaku.TabIndex = 254;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(520, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 253;
            label5.Text = "顧客ID";
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(300, 68);
            date.Name = "date";
            date.Size = new Size(185, 31);
            date.TabIndex = 252;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(200, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 244;
            label12.Text = "営業所ID";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(200, 70);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 251;
            label18.Text = "受注年月日";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(340, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 245;
            label14.Text = "社員ID";
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(230, 120);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 250;
            // 
            // TBNyuuka
            // 
            TBNyuuka.Location = new Point(90, 20);
            TBNyuuka.Name = "TBNyuuka";
            TBNyuuka.Size = new Size(100, 31);
            TBNyuuka.TabIndex = 246;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(120, 120);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 249;
            label17.Text = "非表示理由";
            // 
            // TBShopId
            // 
            TBShopId.Location = new Point(290, 20);
            TBShopId.Name = "TBShopId";
            TBShopId.Size = new Size(40, 31);
            TBShopId.TabIndex = 247;
            // 
            // TBShainId
            // 
            TBShainId.Location = new Point(410, 20);
            TBShainId.Name = "TBShainId";
            TBShainId.Size = new Size(100, 31);
            TBShainId.TabIndex = 248;
            // 
            // b_acc
            // 
            b_acc.BackColor = Color.FromArgb(255, 255, 192);
            b_acc.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_acc.ForeColor = Color.Black;
            b_acc.Location = new Point(15, 150);
            b_acc.Name = "b_acc";
            b_acc.Size = new Size(120, 70);
            b_acc.TabIndex = 178;
            b_acc.Text = "受注";
            b_acc.UseVisualStyleBackColor = false;
            b_acc.Click += b_acc_Click;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(255, 255, 192);
            b_sal.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.ForeColor = Color.Black;
            b_sal.Location = new Point(15, 570);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(120, 70);
            b_sal.TabIndex = 177;
            b_sal.Text = "売上";
            b_sal.UseVisualStyleBackColor = false;
            b_sal.Click += b_sal_Click;
            // 
            // b_ord
            // 
            b_ord.BackColor = Color.FromArgb(255, 255, 192);
            b_ord.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.Location = new Point(15, 230);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(120, 70);
            b_ord.TabIndex = 176;
            b_ord.Text = "注文";
            b_ord.UseVisualStyleBackColor = false;
            b_ord.Click += b_ord_Click;
            // 
            // b_shi
            // 
            b_shi.BackColor = Color.FromArgb(255, 255, 192);
            b_shi.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.Location = new Point(15, 490);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(120, 70);
            b_shi.TabIndex = 175;
            b_shi.Text = "出荷";
            b_shi.UseVisualStyleBackColor = false;
            b_shi.Click += b_shi_Click;
            // 
            // b_arr
            // 
            b_arr.BackColor = Color.Navy;
            b_arr.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.ForeColor = Color.White;
            b_arr.Location = new Point(15, 390);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(120, 90);
            b_arr.TabIndex = 174;
            b_arr.Text = "入荷";
            b_arr.UseVisualStyleBackColor = false;
            // 
            // b_lss
            // 
            b_lss.BackColor = Color.FromArgb(255, 255, 192);
            b_lss.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_lss.ForeColor = Color.Black;
            b_lss.Location = new Point(15, 310);
            b_lss.Name = "b_lss";
            b_lss.Size = new Size(120, 70);
            b_lss.TabIndex = 173;
            b_lss.Text = "出庫";
            b_lss.UseVisualStyleBackColor = false;
            b_lss.Click += b_lss_Click;
            // 
            // b_kakutei
            // 
            b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
            b_kakutei.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_kakutei.Location = new Point(1200, 70);
            b_kakutei.Name = "b_kakutei";
            b_kakutei.Size = new Size(150, 70);
            b_kakutei.TabIndex = 240;
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
            clear.TabIndex = 239;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // close
            // 
            close.Location = new Point(1460, 10);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 238;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += button3_Click;
            // 
            // B_iti
            // 
            B_iti.BackColor = Color.FromArgb(192, 255, 255);
            B_iti.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            B_iti.Location = new Point(550, 70);
            B_iti.Name = "B_iti";
            B_iti.Size = new Size(150, 70);
            B_iti.TabIndex = 259;
            B_iti.Text = "一覧";
            B_iti.UseVisualStyleBackColor = false;
            B_iti.Click += B_iti_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkRed;
            panel3.Controls.Add(TBNyuukaIDS);
            panel3.Controls.Add(TBNyukaSyosaiID);
            panel3.Controls.Add(dataGridView2);
            panel3.Controls.Add(TBSuryou);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(TBSyohinID);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(970, 145);
            panel3.Name = "panel3";
            panel3.Size = new Size(600, 690);
            panel3.TabIndex = 261;
            // 
            // TBNyuukaIDS
            // 
            TBNyuukaIDS.Location = new Point(310, 20);
            TBNyuukaIDS.Name = "TBNyuukaIDS";
            TBNyuukaIDS.Size = new Size(100, 31);
            TBNyuukaIDS.TabIndex = 258;
            // 
            // TBNyukaSyosaiID
            // 
            TBNyukaSyosaiID.Location = new Point(130, 20);
            TBNyukaSyosaiID.Name = "TBNyukaSyosaiID";
            TBNyukaSyosaiID.Size = new Size(100, 31);
            TBNyukaSyosaiID.TabIndex = 277;
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
            label15.Text = "入荷ID";
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
            label13.Text = "入荷詳細ID";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(1100, 100);
            label2.Name = "label2";
            label2.Size = new Size(86, 32);
            label2.TabIndex = 264;
            label2.Text = "未設定";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1080, 70);
            label1.Name = "label1";
            label1.Size = new Size(108, 28);
            label1.TabIndex = 263;
            label1.Text = "現在の状態";
            // 
            // arrival
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
            Controls.Add(b_acc);
            Controls.Add(b_sal);
            Controls.Add(b_ord);
            Controls.Add(b_shi);
            Controls.Add(b_arr);
            Controls.Add(b_lss);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(b_ser);
            Controls.Add(label4);
            Controls.Add(b_upd);
            Controls.Add(label3);
            Controls.Add(b_reg);
            Controls.Add(panel1);
            Name = "arrival";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "入荷";
            Load += arrival_Load;
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
        private Label label_ename;
        private Label label_id;
        private Button b_ser;
        private Label label4;
        private Button b_upd;
        private Label label3;
        private Button b_reg;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button b_acc;
        private Button b_sal;
        private Button b_ord;
        private Button b_shi;
        private Button b_arr;
        private Button b_lss;
        private Button b_kakutei;
        private Button clear;
        private Button close;
        private System.Windows.Forms.Timer timer1;
        private CheckBox Nyuukaflag;
        private CheckBox DelFlag;
        private Label label6;
        private MaskedTextBox TBKokyaku;
        private Label label5;
        private DateTimePicker date;
        private Label label12;
        private Label label18;
        private Label label14;
        private MaskedTextBox TBRiyuu;
        private MaskedTextBox TBNyuuka;
        private Label label17;
        private MaskedTextBox TBShopId;
        private MaskedTextBox TBShainId;
        private MaskedTextBox TBJyutyu;
        private Label label7;
        private Button B_iti;
        private Panel panel3;
        private MaskedTextBox TBGoukeiKingaku;
        private Label label11;
        private MaskedTextBox TBJyutyuSyosaiID;
        private DataGridView dataGridView2;
        private MaskedTextBox TBSuryou;
        private Label label15;
        private Label label9;
        private Label label13;
        private MaskedTextBox TBSyohinID;
        private Label label10;
        private MaskedTextBox TBNyuukaIDS;
        private Label label8;
        private Label label2;
        private Label label1;
        private MaskedTextBox TBNyukaSyosaiID;
    }
}
