﻿namespace SalesManagement_SysDev
{
    partial class horder
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
            b_flg = new Button();
            label_id = new Label();
            b_ser = new Button();
            label4 = new Label();
            b_upd = new Button();
            label3 = new Label();
            b_reg = new Button();
            b_hor = new Button();
            b_rec = new Button();
            panel1 = new Panel();
            date = new DateTimePicker();
            label18 = new Label();
            TBShainID = new MaskedTextBox();
            TBMakerID = new MaskedTextBox();
            TBHattyuuID = new MaskedTextBox();
            label14 = new Label();
            label8 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            NyuukoFlag = new CheckBox();
            DelFlag = new CheckBox();
            TBRiyuu = new MaskedTextBox();
            label17 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(696, 35);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 214;
            label_ename.Text = "label7";
            // 
            // b_flg
            // 
            b_flg.BackColor = Color.FromArgb(192, 255, 255);
            b_flg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_flg.Location = new Point(626, 79);
            b_flg.Name = "b_flg";
            b_flg.Size = new Size(129, 48);
            b_flg.TabIndex = 199;
            b_flg.Text = "非表示";
            b_flg.UseVisualStyleBackColor = false;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(454, 35);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 213;
            label_id.Text = "label6";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(467, 79);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(129, 48);
            b_ser.TabIndex = 198;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(603, 34);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 212;
            label4.Text = "社員名";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(305, 79);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(129, 48);
            b_upd.TabIndex = 197;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(386, 35);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 211;
            label3.Text = "権限";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(147, 79);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(129, 48);
            b_reg.TabIndex = 196;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            // 
            // b_hor
            // 
            b_hor.BackColor = Color.Navy;
            b_hor.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_hor.ForeColor = Color.White;
            b_hor.Location = new Point(15, 133);
            b_hor.Name = "b_hor";
            b_hor.Size = new Size(120, 74);
            b_hor.TabIndex = 207;
            b_hor.Text = "発注";
            b_hor.UseVisualStyleBackColor = false;
            // 
            // b_rec
            // 
            b_rec.BackColor = Color.FromArgb(255, 255, 192);
            b_rec.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_rec.ForeColor = Color.Black;
            b_rec.Location = new Point(15, 235);
            b_rec.Name = "b_rec";
            b_rec.Size = new Size(120, 47);
            b_rec.TabIndex = 205;
            b_rec.Text = "入庫";
            b_rec.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(NyuukoFlag);
            panel1.Controls.Add(date);
            panel1.Controls.Add(DelFlag);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(TBShainID);
            panel1.Controls.Add(TBMakerID);
            panel1.Controls.Add(TBHattyuuID);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(147, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(905, 520);
            panel1.TabIndex = 204;
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(127, 60);
            date.Name = "date";
            date.Size = new Size(300, 31);
            date.TabIndex = 75;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(16, 65);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 74;
            label18.Text = "発注年月日";
            // 
            // TBShainID
            // 
            TBShainID.Location = new Point(460, 20);
            TBShainID.Name = "TBShainID";
            TBShainID.Size = new Size(130, 31);
            TBShainID.TabIndex = 69;
            // 
            // TBMakerID
            // 
            TBMakerID.Location = new Point(290, 20);
            TBMakerID.Name = "TBMakerID";
            TBMakerID.Size = new Size(90, 31);
            TBMakerID.TabIndex = 66;
            // 
            // TBHattyuuID
            // 
            TBHattyuuID.Location = new Point(80, 20);
            TBHattyuuID.Name = "TBHattyuuID";
            TBHattyuuID.Size = new Size(130, 31);
            TBHattyuuID.TabIndex = 64;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(390, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 62;
            label14.Text = "社員ID";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(220, 20);
            label8.Name = "label8";
            label8.Size = new Size(69, 25);
            label8.TabIndex = 56;
            label8.Text = "メーカID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(15, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 54;
            label6.Text = "発注ID";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(874, 345);
            dataGridView1.TabIndex = 52;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(147, 35);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 202;
            label2.Text = "yyyy年mm月dd日";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 35);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 201;
            label1.Text = "11:11:11";
            // 
            // kakutei
            // 
            kakutei.BackColor = Color.FromArgb(255, 192, 192);
            kakutei.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            kakutei.Location = new Point(795, 80);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(129, 48);
            kakutei.TabIndex = 243;
            kakutei.Text = "確定";
            kakutei.UseVisualStyleBackColor = false;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(935, 80);
            clear.Name = "clear";
            clear.Size = new Size(112, 48);
            clear.TabIndex = 242;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            close.Location = new Point(925, 15);
            close.Name = "close";
            close.Size = new Size(129, 48);
            close.TabIndex = 241;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // NyuukoFlag
            // 
            NyuukoFlag.AutoSize = true;
            NyuukoFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NyuukoFlag.ForeColor = Color.LavenderBlush;
            NyuukoFlag.Location = new Point(433, 64);
            NyuukoFlag.Name = "NyuukoFlag";
            NyuukoFlag.Size = new Size(110, 29);
            NyuukoFlag.TabIndex = 247;
            NyuukoFlag.Text = "入庫状態";
            NyuukoFlag.UseVisualStyleBackColor = true;
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.LavenderBlush;
            DelFlag.Location = new Point(15, 110);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 246;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(215, 110);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 245;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(110, 110);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 244;
            label17.Text = "非表示理由";
            // 
            // horder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 667);
            Controls.Add(kakutei);
            Controls.Add(clear);
            Controls.Add(close);
            Controls.Add(label_ename);
            Controls.Add(b_flg);
            Controls.Add(label_id);
            Controls.Add(b_ser);
            Controls.Add(label4);
            Controls.Add(b_upd);
            Controls.Add(label3);
            Controls.Add(b_reg);
            Controls.Add(b_hor);
            Controls.Add(b_rec);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "horder";
            Text = "horder";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_ename;
        private Button b_flg;
        private Label label_id;
        private Button b_ser;
        private Label label4;
        private Button b_upd;
        private Label label3;
        private Button b_reg;
        private Button b_hor;
        private Button b_rec;
        private Panel panel1;
        private DateTimePicker date;
        private Label label18;
        private MaskedTextBox TBShainID;
        private MaskedTextBox TBMakerID;
        private MaskedTextBox TBHattyuuID;
        private Label label14;
        private Label label8;
        private Label label6;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
        private Button kakutei;
        private Button clear;
        private Button close;
        private System.Windows.Forms.Timer timer1;
        private CheckBox NyuukoFlag;
        private CheckBox DelFlag;
        private MaskedTextBox TBRiyuu;
        private Label label17;
    }
}