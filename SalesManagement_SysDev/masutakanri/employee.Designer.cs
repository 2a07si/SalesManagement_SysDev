﻿namespace SalesManagement_SysDev
{
    partial class employee
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
            TBPass = new MaskedTextBox();
            label9 = new Label();
            Next = new Button();
            Prev = new Button();
            label6 = new Label();
            date = new DateTimePicker();
            label18 = new Label();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            label12 = new Label();
            label14 = new Label();
            TBTellNo = new MaskedTextBox();
            TBRiyuu = new MaskedTextBox();
            label8 = new Label();
            TBSyainID = new MaskedTextBox();
            TBJobID = new MaskedTextBox();
            label17 = new Label();
            label7 = new Label();
            TBShopId = new MaskedTextBox();
            TBSyainName = new MaskedTextBox();
            DelFlag = new CheckBox();
            b_kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            B_iti = new Button();
            label2 = new Label();
            label1 = new Label();
            checkBox_2 = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.FromArgb(160, 220, 190);
            b_emp.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.ForeColor = Color.Black;
            b_emp.Location = new Point(15, 150);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(120, 90);
            b_emp.TabIndex = 7;
            b_emp.Text = "社員";
            b_emp.UseVisualStyleBackColor = false;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(190, 255, 255);
            b_mer.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.Location = new Point(15, 250);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(120, 70);
            b_mer.TabIndex = 8;
            b_mer.Text = "商品";
            b_mer.UseVisualStyleBackColor = false;
            b_mer.Click += b_mer_Click;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.FromArgb(190, 255, 255);
            b_cus.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.ForeColor = Color.Black;
            b_cus.Location = new Point(15, 410);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(120, 70);
            b_cus.TabIndex = 10;
            b_cus.Text = "顧客";
            b_cus.UseVisualStyleBackColor = false;
            b_cus.Click += b_cus_Click;
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(190, 255, 255);
            b_sto.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.ForeColor = Color.Black;
            b_sto.Location = new Point(15, 330);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(120, 70);
            b_sto.TabIndex = 9;
            b_sto.Text = "在庫";
            b_sto.UseVisualStyleBackColor = false;
            b_sto.Click += b_sto_Click;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(165, 25);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(96, 25);
            label_ename.TabIndex = 191;
            label_ename.Text = "------------";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(310, 25);
            label_id.Name = "label_id";
            label_id.Size = new Size(54, 25);
            label_id.TabIndex = 190;
            label_id.Text = "------";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 25);
            label4.Name = "label4";
            label4.Size = new Size(70, 25);
            label4.TabIndex = 189;
            label4.Text = "社員名:";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 25);
            label3.Name = "label3";
            label3.Size = new Size(52, 25);
            label3.TabIndex = 188;
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
            panel1.Controls.Add(TBPass);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(Next);
            panel1.Controls.Add(Prev);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(date);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(TBTellNo);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TBSyainID);
            panel1.Controls.Add(TBJobID);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(TBShopId);
            panel1.Controls.Add(TBSyainName);
            panel1.Controls.Add(DelFlag);
            panel1.Location = new Point(150, 145);
            panel1.Name = "panel1";
            panel1.Size = new Size(1420, 690);
            panel1.TabIndex = 4;
            // 
            // TBPass
            // 
            TBPass.Location = new Point(110, 70);
            TBPass.Name = "TBPass";
            TBPass.Size = new Size(200, 31);
            TBPass.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(20, 70);
            label9.Name = "label9";
            label9.Size = new Size(80, 25);
            label9.TabIndex = 10;
            label9.Text = "パスワード";
            // 
            // Next
            // 
            Next.Location = new Point(1350, 144);
            Next.Name = "Next";
            Next.Size = new Size(40, 40);
            Next.TabIndex = 18;
            Next.Text = "▶";
            Next.UseVisualStyleBackColor = true;
            // 
            // Prev
            // 
            Prev.Location = new Point(1220, 144);
            Prev.Name = "Prev";
            Prev.Size = new Size(40, 40);
            Prev.TabIndex = 17;
            Prev.Text = "◀";
            Prev.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(1270, 152);
            label6.Name = "label6";
            label6.Size = new Size(72, 25);
            label6.TabIndex = 295;
            label6.Text = "何ページ";
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(870, 20);
            date.Name = "date";
            date.Size = new Size(165, 31);
            date.TabIndex = 9;
            date.ValueChanged += date_ValueChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(760, 20);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 8;
            label18.Text = "入社年月日";
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
            dataGridView1.TabIndex = 19;
            dataGridView1.CellClick += dataGridView1_CellClick_1;
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
            label5.Text = "社員ID";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(480, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 4;
            label12.Text = "営業所ID";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(200, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 2;
            label14.Text = "社員名";
            // 
            // TBTellNo
            // 
            TBTellNo.Location = new Point(406, 70);
            TBTellNo.Name = "TBTellNo";
            TBTellNo.Size = new Size(124, 31);
            TBTellNo.TabIndex = 13;
            TBTellNo.MaskInputRejected += TBTellNo_MaskInputRejected;
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(230, 120);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(316, 70);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 12;
            label8.Text = "電話番号";
            // 
            // TBSyainID
            // 
            TBSyainID.Location = new Point(90, 20);
            TBSyainID.Name = "TBSyainID";
            TBSyainID.Size = new Size(100, 31);
            TBSyainID.TabIndex = 1;
            // 
            // TBJobID
            // 
            TBJobID.Location = new Point(700, 20);
            TBJobID.Name = "TBJobID";
            TBJobID.Size = new Size(50, 31);
            TBJobID.TabIndex = 7;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(120, 120);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 15;
            label17.Text = "非表示理由";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(630, 20);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 6;
            label7.Text = "役職ID";
            // 
            // TBShopId
            // 
            TBShopId.Location = new Point(570, 20);
            TBShopId.Name = "TBShopId";
            TBShopId.Size = new Size(50, 31);
            TBShopId.TabIndex = 5;
            // 
            // TBSyainName
            // 
            TBSyainName.Location = new Point(270, 20);
            TBSyainName.Name = "TBSyainName";
            TBSyainName.Size = new Size(200, 31);
            TBSyainName.TabIndex = 3;
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.Black;
            DelFlag.Location = new Point(20, 120);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 14;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // b_kakutei
            // 
            b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
            b_kakutei.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_kakutei.Location = new Point(1200, 70);
            b_kakutei.Name = "b_kakutei";
            b_kakutei.Size = new Size(150, 70);
            b_kakutei.TabIndex = 5;
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
            clear.TabIndex = 6;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // close
            // 
            close.Location = new Point(1450, 10);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 11;
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
            label2.TabIndex = 293;
            label2.Text = "未設定";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1080, 71);
            label1.Name = "label1";
            label1.Size = new Size(108, 28);
            label1.TabIndex = 292;
            label1.Text = "現在の状態";
            // 
            // checkBox_2
            // 
            checkBox_2.AutoSize = true;
            checkBox_2.Location = new Point(675, 10);
            checkBox_2.Name = "checkBox_2";
            checkBox_2.Size = new Size(225, 29);
            checkBox_2.TabIndex = 294;
            checkBox_2.Text = "一覧表示に非表示も含む";
            checkBox_2.UseVisualStyleBackColor = true;
            // 
            // employee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(checkBox_2);
            Controls.Add(label2);
            Controls.Add(label1);
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
            Name = "employee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "社員";
            Load += employee_Load;
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
        private Label label5;
        private Label label12;
        private Label label14;
        private MaskedTextBox TBTellNo;
        private MaskedTextBox TBRiyuu;
        private Label label8;
        private MaskedTextBox TBSyainID;
        private MaskedTextBox TBJobID;
        private Label label17;
        private Label label7;
        private MaskedTextBox TBShopId;
        private MaskedTextBox TBSyainName;
        private CheckBox DelFlag;
        private DateTimePicker date;
        private Label label18;
        private Button B_iti;
        private Label label2;
        private Label label1;
        private Button Next;
        private Button Prev;
        private Label label6;
        private MaskedTextBox TBPass;
        private Label label9;
        private CheckBox checkBox_2;
    }
}