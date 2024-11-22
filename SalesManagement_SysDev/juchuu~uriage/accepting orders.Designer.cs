using SalesManagement_SysDev.juchuu_uriage;

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
            label6 = new Label();
            label7 = new Label();
            label12 = new Label();
            TBJyutyuID = new TextBox();
            TBShopID = new TextBox();
            TBShainID = new TextBox();
            label17 = new Label();
            TBRiyuu = new TextBox();
            label18 = new Label();
            date = new DateTimePicker();
            label5 = new Label();
            TBKokyakuID = new TextBox();
            DelFlag = new CheckBox();
            TyumonFlag = new CheckBox();
            TBTantoName = new TextBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label14 = new UpdateLabel2();
            b_reg = new Button();
            label3 = new Label();
            b_upd = new Button();
            label4 = new Label();
            b_ser = new Button();
            label_id = new Label();
            label_ename = new Label();
            close = new Button();
            clear = new Button();
            b_kakutei = new Button();
            B_iti = new Button();
            TBJyutyuIDS = new TextBox();
            label10 = new Label();
            TBSyohinID = new TextBox();
            label13 = new Label();
            label9 = new Label();
            label15 = new Label();
            TBSuryou = new TextBox();
            dataGridView2 = new DataGridView();
            TBJyutyuSyosaiID = new TextBox();
            label11 = new Label();
            TBGoukeiKingaku = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            b_FormSelector = new Button();
            checkBoxDateFilter = new CheckBox();
            checkBox_2 = new CheckBox();
            b_arr = new Button();
            b_sal = new Button();
            b_ord = new Button();
            b_shi = new Button();
            b_acc = new Button();
            b_lss = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // kakutei
            // 
            kakutei.Location = new Point(0, 0);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(75, 23);
            kakutei.TabIndex = 0;
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
            label6.Text = "受注ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(20, 70);
            label7.Name = "label7";
            label7.Size = new Size(102, 25);
            label7.TabIndex = 8;
            label7.Text = "担当社員名";
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
            // TBJyutyuID
            // 
            TBJyutyuID.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            TBJyutyuID.Location = new Point(90, 20);
            TBJyutyuID.Name = "TBJyutyuID";
            TBJyutyuID.Size = new Size(100, 31);
            TBJyutyuID.TabIndex = 1;
            TBJyutyuID.TextChanged += TBJyutyuID_TextChanged;
            // 
            // TBShopID
            // 
            TBShopID.Location = new Point(290, 20);
            TBShopID.Name = "TBShopID";
            TBShopID.Size = new Size(40, 31);
            TBShopID.TabIndex = 3;
            TBShopID.TextChanged += TBShopID_TextChanged;
            // 
            // TBShainID
            // 
            TBShainID.Location = new Point(410, 20);
            TBShainID.Name = "TBShainID";
            TBShainID.Size = new Size(100, 31);
            TBShainID.TabIndex = 5;
            TBShainID.TextChanged += TBShainID_TextChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(120, 120);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 14;
            label17.Text = "非表示理由";
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(230, 120);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 15;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(280, 70);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 10;
            label18.Text = "受注年月日";
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(390, 70);
            date.Name = "date";
            date.Size = new Size(185, 31);
            date.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(520, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 6;
            label5.Text = "顧客ID";
            // 
            // TBKokyakuID
            // 
            TBKokyakuID.Location = new Point(590, 20);
            TBKokyakuID.Name = "TBKokyakuID";
            TBKokyakuID.Size = new Size(100, 31);
            TBKokyakuID.TabIndex = 7;
            TBKokyakuID.TextChanged += TBKokyakuID_TextChanged;
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.Black;
            DelFlag.Location = new Point(20, 120);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 13;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // TyumonFlag
            // 
            TyumonFlag.AutoSize = true;
            TyumonFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TyumonFlag.ForeColor = Color.Black;
            TyumonFlag.Location = new Point(590, 70);
            TyumonFlag.Name = "TyumonFlag";
            TyumonFlag.Size = new Size(110, 29);
            TyumonFlag.TabIndex = 12;
            TyumonFlag.Text = "受注状態";
            TyumonFlag.UseVisualStyleBackColor = true;
            // 
            // TBTantoName
            // 
            TBTantoName.Location = new Point(130, 70);
            TBTantoName.Name = "TBTantoName";
            TBTantoName.Size = new Size(140, 31);
            TBTantoName.TabIndex = 9;
            TBTantoName.TextChanged += TBTantoName_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(10, 190);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(800, 490);
            dataGridView1.TabIndex = 16;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(dataGridView1);
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
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(340, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 4;
            label14.Text = "社員ID";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(255, 224, 192);
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
            label3.TabIndex = 252;
            label3.Text = "権限:";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(255, 224, 192);
            b_upd.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(330, 70);
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
            label4.TabIndex = 253;
            label4.Text = "社員名:";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(255, 224, 192);
            b_ser.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(690, 70);
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
            label_id.TabIndex = 254;
            label_id.Text = "------";
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
            // close
            // 
            close.Location = new Point(1460, 10);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 15;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(1400, 70);
            clear.Name = "clear";
            clear.Size = new Size(150, 70);
            clear.TabIndex = 8;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // b_kakutei
            // 
            b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
            b_kakutei.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_kakutei.Location = new Point(1200, 70);
            b_kakutei.Name = "b_kakutei";
            b_kakutei.Size = new Size(150, 70);
            b_kakutei.TabIndex = 0;
            b_kakutei.Text = "確定";
            b_kakutei.UseVisualStyleBackColor = false;
            b_kakutei.Click += b_kakutei_Click;
            // 
            // B_iti
            // 
            B_iti.BackColor = Color.FromArgb(255, 224, 192);
            B_iti.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            B_iti.Location = new Point(510, 70);
            B_iti.Name = "B_iti";
            B_iti.Size = new Size(150, 70);
            B_iti.TabIndex = 2;
            B_iti.Text = "一覧";
            B_iti.UseVisualStyleBackColor = false;
            B_iti.Click += B_iti_Click;
            // 
            // TBJyutyuIDS
            // 
            TBJyutyuIDS.Location = new Point(310, 20);
            TBJyutyuIDS.Name = "TBJyutyuIDS";
            TBJyutyuIDS.Size = new Size(100, 31);
            TBJyutyuIDS.TabIndex = 2;
            TBJyutyuIDS.TextChanged += TBJyutyuIDS_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(420, 20);
            label10.Name = "label10";
            label10.Size = new Size(66, 25);
            label10.TabIndex = 3;
            label10.Text = "商品ID";
            // 
            // TBSyohinID
            // 
            TBSyohinID.Location = new Point(490, 20);
            TBSyohinID.Name = "TBSyohinID";
            TBSyohinID.Size = new Size(100, 31);
            TBSyohinID.TabIndex = 4;
            TBSyohinID.TextChanged += TBSyohinID_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(20, 20);
            label13.Name = "label13";
            label13.Size = new Size(102, 25);
            label13.TabIndex = 0;
            label13.Text = "受注詳細ID";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(20, 70);
            label9.Name = "label9";
            label9.Size = new Size(48, 25);
            label9.TabIndex = 5;
            label9.Text = "数量";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(240, 20);
            label15.Name = "label15";
            label15.Size = new Size(66, 25);
            label15.TabIndex = 1;
            label15.Text = "受注ID";
            // 
            // TBSuryou
            // 
            TBSuryou.Location = new Point(80, 70);
            TBSuryou.Name = "TBSuryou";
            TBSuryou.Size = new Size(100, 31);
            TBSuryou.TabIndex = 6;
            TBSuryou.TextChanged += TBSuryou_TextChanged;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(10, 190);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.Size = new Size(580, 490);
            dataGridView2.TabIndex = 9;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // TBJyutyuSyosaiID
            // 
            TBJyutyuSyosaiID.Location = new Point(130, 20);
            TBJyutyuSyosaiID.Name = "TBJyutyuSyosaiID";
            TBJyutyuSyosaiID.Size = new Size(100, 31);
            TBJyutyuSyosaiID.TabIndex = 0;
            TBJyutyuSyosaiID.TextChanged += TBJyutyuSyosaiID_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(190, 70);
            label11.Name = "label11";
            label11.Size = new Size(84, 25);
            label11.TabIndex = 7;
            label11.Text = "合計金額";
            // 
            // TBGoukeiKingaku
            // 
            TBGoukeiKingaku.Location = new Point(280, 70);
            TBGoukeiKingaku.Name = "TBGoukeiKingaku";
            TBGoukeiKingaku.Size = new Size(100, 31);
            TBGoukeiKingaku.TabIndex = 8;
            TBGoukeiKingaku.TextChanged += TBGoukeiKingaku_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 128, 128);
            panel2.Controls.Add(TBGoukeiKingaku);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(TBJyutyuSyosaiID);
            panel2.Controls.Add(dataGridView2);
            panel2.Controls.Add(TBSuryou);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(TBSyohinID);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(TBJyutyuIDS);
            panel2.Location = new Point(970, 145);
            panel2.Name = "panel2";
            panel2.Size = new Size(600, 690);
            panel2.TabIndex = 6;
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
            label2.Text = "未設定";
            // 
            // b_FormSelector
            // 
            b_FormSelector.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_FormSelector.Location = new Point(900, 70);
            b_FormSelector.Name = "b_FormSelector";
            b_FormSelector.Size = new Size(150, 70);
            b_FormSelector.TabIndex = 17;
            b_FormSelector.Text = "button1";
            b_FormSelector.UseVisualStyleBackColor = true;
            b_FormSelector.Click += b_FormSelector_Click;
            // 
            // checkBoxDateFilter
            // 
            checkBoxDateFilter.AutoSize = true;
            checkBoxDateFilter.Location = new Point(967, 17);
            checkBoxDateFilter.Name = "checkBoxDateFilter";
            checkBoxDateFilter.Size = new Size(225, 29);
            checkBoxDateFilter.TabIndex = 266;
            checkBoxDateFilter.Text = "受注年月日を検索に含む";
            checkBoxDateFilter.UseVisualStyleBackColor = true;
            // 
            // checkBox_2
            // 
            checkBox_2.AutoSize = true;
            checkBox_2.Location = new Point(680, 17);
            checkBox_2.Name = "checkBox_2";
            checkBox_2.Size = new Size(225, 29);
            checkBox_2.TabIndex = 267;
            checkBox_2.Text = "一覧表示に非表示も含む";
            checkBox_2.UseVisualStyleBackColor = true;
            // 
            // b_arr
            // 
            b_arr.BackColor = Color.FromArgb(252, 252, 192);
            b_arr.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.ForeColor = Color.Black;
            b_arr.Location = new Point(15, 405);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(120, 70);
            b_arr.TabIndex = 268;
            b_arr.Text = "入荷";
            b_arr.UseVisualStyleBackColor = false;
            b_arr.Click += b_arr_Click;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(252, 252, 192);
            b_sal.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.ForeColor = Color.Black;
            b_sal.Location = new Point(15, 565);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(120, 70);
            b_sal.TabIndex = 273;
            b_sal.Text = "売上";
            b_sal.UseVisualStyleBackColor = false;
            b_sal.Click += b_sal_Click;
            // 
            // b_ord
            // 
            b_ord.BackColor = Color.FromArgb(252, 252, 192);
            b_ord.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.Location = new Point(15, 245);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(120, 70);
            b_ord.TabIndex = 269;
            b_ord.Text = "注文";
            b_ord.UseVisualStyleBackColor = false;
            b_ord.Click += b_ord_Click;
            b_ord.Paint += b_ord_Paint;
            // 
            // b_shi
            // 
            b_shi.BackColor = Color.FromArgb(252, 252, 192);
            b_shi.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.Location = new Point(15, 485);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(120, 70);
            b_shi.TabIndex = 272;
            b_shi.Text = "出荷";
            b_shi.UseVisualStyleBackColor = false;
            b_shi.Click += b_shi_Click;
            // 
            // b_acc
            // 
            b_acc.BackColor = Color.FromArgb(255, 192, 128);
            b_acc.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_acc.ForeColor = Color.Black;
            b_acc.Location = new Point(15, 145);
            b_acc.Name = "b_acc";
            b_acc.Size = new Size(120, 90);
            b_acc.TabIndex = 271;
            b_acc.Text = "受注";
            b_acc.UseVisualStyleBackColor = false;
            // 
            // b_lss
            // 
            b_lss.BackColor = Color.FromArgb(252, 252, 192);
            b_lss.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_lss.ForeColor = Color.Black;
            b_lss.Location = new Point(15, 325);
            b_lss.Name = "b_lss";
            b_lss.Size = new Size(120, 70);
            b_lss.TabIndex = 270;
            b_lss.Text = "出庫";
            b_lss.UseVisualStyleBackColor = false;
            b_lss.Click += b_lss_Click;
            // 
            // acceptingorders
            // 
            AcceptButton = b_kakutei;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            CancelButton = clear;
            ClientSize = new Size(1578, 844);
            Controls.Add(b_arr);
            Controls.Add(b_sal);
            Controls.Add(b_ord);
            Controls.Add(b_shi);
            Controls.Add(b_acc);
            Controls.Add(b_lss);
            Controls.Add(panel1);
            Controls.Add(checkBox_2);
            Controls.Add(checkBoxDateFilter);
            Controls.Add(b_FormSelector);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
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
            Name = "acceptingorders";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "受注";
            Load += acceptingorders_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Panel panel1;
        private CheckBox TyumonFlag;
        private CheckBox DelFlag;
        private TextBox TBKokyakuID;
        private Label label5;
        private DateTimePicker date;
        private Label label18;
        private TextBox TBRiyuu;
        private Label label17;
        private TextBox TBShainID;
        private TextBox TBShopID;
        private TextBox TBJyutyuID;
        private Label label12;
        private Label label7;
        private Label label6;
        private TextBox TBTantoName;
        private Button B_iti;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button Next;
        private Button Prev;
        private Label label8;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView2;
        private TextBox TBJyutyuSyosaiID;
        private TextBox TBSuryou;
        private Label label15;
        private Label label9;
        private Label label13;
        private TextBox TBSyohinID;
        private Label label10;
        private TextBox TBJyutyuIDS;
        private TextBox TBGoukeiKingaku;
        private Label label11;
        private Label 現在オフ;
        private Button b_FormSelector;
        private CheckBox checkBoxDateFilter;
        private CheckBox checkBox_2;
        private UpdateLabel2 label14;
        private Panel kengen2;
        private ComboBox CB2;
        private Panel kengen3;
        private ComboBox CB3;
        private Panel kengen1;
        private Button b_arr;
        private Button b_sal;
        private Button b_ord;
        private Button b_shi;
        private Button b_acc;
        private Button b_lss;
    }
}