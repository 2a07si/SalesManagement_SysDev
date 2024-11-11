namespace SalesManagement_SysDev
{
    partial class receivingstock
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
            b_rec = new Button();
            b_hor = new Button();
            panel1 = new Panel();
            NyuukoFlag = new CheckBox();
            dataGridView1 = new DataGridView();
            date = new DateTimePicker();
            label6 = new Label();
            DelFlag = new CheckBox();
            label18 = new Label();
            label14 = new Label();
            label8 = new Label();
            TBRiyuu = new MaskedTextBox();
            label17 = new Label();
            TBShainID = new MaskedTextBox();
            TBHattyuuID = new MaskedTextBox();
            TBNyukoID = new MaskedTextBox();
            b_kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            B_iti = new Button();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            TBNyuukoSyosaiID = new MaskedTextBox();
            dataGridView2 = new DataGridView();
            TBSuryou = new MaskedTextBox();
            label15 = new Label();
            label9 = new Label();
            label13 = new Label();
            TBSyohinID = new MaskedTextBox();
            label10 = new Label();
            TBNyuukoIDS = new MaskedTextBox();
            b_FormSelector = new Button();
            checkBox_2 = new CheckBox();
            checkBoxDateFilter = new CheckBox();
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
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 229;
            label_ename.Text = "label7";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(310, 25);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 228;
            label_id.Text = "label6";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(212, 222, 255);
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
            label4.TabIndex = 227;
            label4.Text = "社員名:";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(212, 222, 255);
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
            label3.TabIndex = 226;
            label3.Text = "権限:";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(212, 222, 255);
            b_reg.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(150, 70);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(150, 70);
            b_reg.TabIndex = 0;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            b_reg.Click += b_reg_Click;
            // 
            // b_rec
            // 
            b_rec.BackColor = Color.FromArgb(190, 190, 255);
            b_rec.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_rec.ForeColor = Color.Black;
            b_rec.Location = new Point(15, 230);
            b_rec.Name = "b_rec";
            b_rec.Size = new Size(120, 90);
            b_rec.TabIndex = 9;
            b_rec.Text = "入庫";
            b_rec.UseVisualStyleBackColor = false;
            // 
            // b_hor
            // 
            b_hor.BackColor = Color.FromArgb(255, 230, 255);
            b_hor.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_hor.ForeColor = Color.Black;
            b_hor.Location = new Point(15, 150);
            b_hor.Name = "b_hor";
            b_hor.Size = new Size(120, 70);
            b_hor.TabIndex = 8;
            b_hor.Text = "発注";
            b_hor.UseVisualStyleBackColor = false;
            b_hor.Click += b_hor_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(190, 190, 255);
            panel1.Controls.Add(NyuukoFlag);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(date);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(DelFlag);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(TBShainID);
            panel1.Controls.Add(TBHattyuuID);
            panel1.Controls.Add(TBNyukoID);
            panel1.Location = new Point(150, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(820, 690);
            panel1.TabIndex = 4;
            // 
            // NyuukoFlag
            // 
            NyuukoFlag.AutoSize = true;
            NyuukoFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NyuukoFlag.ForeColor = Color.Black;
            NyuukoFlag.Location = new Point(320, 70);
            NyuukoFlag.Name = "NyuukoFlag";
            NyuukoFlag.Size = new Size(92, 29);
            NyuukoFlag.TabIndex = 8;
            NyuukoFlag.Text = "入庫済";
            NyuukoFlag.UseVisualStyleBackColor = true;
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
            dataGridView1.Size = new Size(800, 490);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(130, 70);
            date.Name = "date";
            date.Size = new Size(185, 31);
            date.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(200, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 2;
            label6.Text = "発注ID";
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.Black;
            DelFlag.Location = new Point(20, 120);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 9;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(20, 70);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 6;
            label18.Text = "入庫年月日";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(380, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 4;
            label14.Text = "社員ID";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(20, 20);
            label8.Name = "label8";
            label8.Size = new Size(66, 25);
            label8.TabIndex = 0;
            label8.Text = "入庫ID";
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(230, 120);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 11;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(120, 120);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 10;
            label17.Text = "非表示理由";
            // 
            // TBShainID
            // 
            TBShainID.Location = new Point(450, 20);
            TBShainID.Name = "TBShainID";
            TBShainID.Size = new Size(100, 31);
            TBShainID.TabIndex = 5;
            // 
            // TBHattyuuID
            // 
            TBHattyuuID.Location = new Point(270, 20);
            TBHattyuuID.Name = "TBHattyuuID";
            TBHattyuuID.Size = new Size(100, 31);
            TBHattyuuID.TabIndex = 3;
            // 
            // TBNyukoID
            // 
            TBNyukoID.Location = new Point(90, 20);
            TBNyukoID.Name = "TBNyukoID";
            TBNyukoID.Size = new Size(100, 31);
            TBNyukoID.TabIndex = 1;
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
            b_kakutei.Click += kakutei_Click;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(1400, 70);
            clear.Name = "clear";
            clear.Size = new Size(130, 70);
            clear.TabIndex = 7;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // close
            // 
            close.Location = new Point(1460, 10);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 10;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // B_iti
            // 
            B_iti.BackColor = Color.FromArgb(212, 222, 255);
            B_iti.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            B_iti.Location = new Point(510, 70);
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(160, 160, 255);
            panel3.Controls.Add(TBNyuukoSyosaiID);
            panel3.Controls.Add(dataGridView2);
            panel3.Controls.Add(TBSuryou);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(TBSyohinID);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(TBNyuukoIDS);
            panel3.Location = new Point(970, 145);
            panel3.Name = "panel3";
            panel3.Size = new Size(600, 690);
            panel3.TabIndex = 5;
            // 
            // TBNyuukoSyosaiID
            // 
            TBNyuukoSyosaiID.Location = new Point(130, 20);
            TBNyuukoSyosaiID.Name = "TBNyuukoSyosaiID";
            TBNyuukoSyosaiID.Size = new Size(100, 31);
            TBNyuukoSyosaiID.TabIndex = 1;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(10, 190);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.RowTemplate.Height = 33;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(580, 490);
            dataGridView2.TabIndex = 8;
            dataGridView2.CellClick += dataGridView2_CellClick_1;
            // 
            // TBSuryou
            // 
            TBSuryou.Location = new Point(80, 70);
            TBSuryou.Name = "TBSuryou";
            TBSuryou.Size = new Size(100, 31);
            TBSuryou.TabIndex = 7;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(240, 20);
            label15.Name = "label15";
            label15.Size = new Size(66, 25);
            label15.TabIndex = 2;
            label15.Text = "入庫ID";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(20, 70);
            label9.Name = "label9";
            label9.Size = new Size(48, 25);
            label9.TabIndex = 6;
            label9.Text = "数量";
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
            label13.Text = "入庫詳細ID";
            // 
            // TBSyohinID
            // 
            TBSyohinID.Location = new Point(490, 20);
            TBSyohinID.Name = "TBSyohinID";
            TBSyohinID.Size = new Size(100, 31);
            TBSyohinID.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(420, 20);
            label10.Name = "label10";
            label10.Size = new Size(66, 25);
            label10.TabIndex = 4;
            label10.Text = "商品ID";
            // 
            // TBNyuukoIDS
            // 
            TBNyuukoIDS.Location = new Point(310, 20);
            TBNyuukoIDS.Name = "TBNyuukoIDS";
            TBNyuukoIDS.Size = new Size(100, 31);
            TBNyuukoIDS.TabIndex = 3;
            // 
            // b_FormSelector
            // 
            b_FormSelector.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_FormSelector.Location = new Point(900, 70);
            b_FormSelector.Name = "b_FormSelector";
            b_FormSelector.Size = new Size(150, 70);
            b_FormSelector.TabIndex = 12;
            b_FormSelector.Text = "button1";
            b_FormSelector.UseVisualStyleBackColor = true;
            b_FormSelector.Click += b_FormSelector_Click_1;
            // 
            // checkBox_2
            // 
            checkBox_2.AutoSize = true;
            checkBox_2.Location = new Point(675, 8);
            checkBox_2.Name = "checkBox_2";
            checkBox_2.Size = new Size(225, 29);
            checkBox_2.TabIndex = 268;
            checkBox_2.Text = "一覧表示に非表示も含む";
            checkBox_2.UseVisualStyleBackColor = true;
            // 
            // checkBoxDateFilter
            // 
            checkBoxDateFilter.AutoSize = true;
            checkBoxDateFilter.Location = new Point(961, 8);
            checkBoxDateFilter.Name = "checkBoxDateFilter";
            checkBoxDateFilter.Size = new Size(225, 29);
            checkBoxDateFilter.TabIndex = 276;
            checkBoxDateFilter.Text = "受注年月日を検索に含む";
            checkBoxDateFilter.UseVisualStyleBackColor = true;
            // 
            // receivingstock
            // 
            AcceptButton = b_kakutei;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = clear;
            ClientSize = new Size(1578, 844);
            Controls.Add(checkBoxDateFilter);
            Controls.Add(checkBox_2);
            Controls.Add(b_FormSelector);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(label1);
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
            Controls.Add(b_rec);
            Controls.Add(b_hor);
            Controls.Add(panel1);
            Name = "receivingstock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "入庫";
            Load += receivingstock_Load;
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
        private Button b_rec;
        private Button b_hor;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button b_kakutei;
        private Button clear;
        private Button close;
        private System.Windows.Forms.Timer timer1;
        private CheckBox NyuukoFlag;
        private DateTimePicker date;
        private Label label6;
        private CheckBox DelFlag;
        private Label label8;
        private Label label18;
        private Label label14;
        private MaskedTextBox TBRiyuu;
        private MaskedTextBox TBHattyuuID;
        private Label label17;
        private MaskedTextBox TBNyukoID;
        private MaskedTextBox TBShainID;
        private Button B_iti;
        private Label label2;
        private Label label1;
        private Panel panel3;
        private MaskedTextBox TBNyuukoSyosaiID;
        private DataGridView dataGridView2;
        private MaskedTextBox TBSuryou;
        private Label label15;
        private Label label9;
        private Label label13;
        private MaskedTextBox TBSyohinID;
        private Label label10;
        private MaskedTextBox TBNyuukoIDS;
        private Button Next;
        private Button Prev;
        private Label label5;
        private Button b_FormSelector;
        private Button colord;
        private CheckBox checkBox_2;
        private CheckBox checkBoxDateFilter;
    }
}