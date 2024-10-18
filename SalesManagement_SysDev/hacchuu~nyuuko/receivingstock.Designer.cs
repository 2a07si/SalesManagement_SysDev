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
            b_flg = new Button();
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
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(665, 30);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 229;
            label_ename.Text = "label7";
            // 
            // b_flg
            // 
            b_flg.BackColor = Color.FromArgb(192, 255, 255);
            b_flg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_flg.Location = new Point(710, 80);
            b_flg.Name = "b_flg";
            b_flg.Size = new Size(130, 50);
            b_flg.TabIndex = 218;
            b_flg.Text = "非表示";
            b_flg.UseVisualStyleBackColor = false;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(445, 30);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 228;
            label_id.Text = "label6";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(570, 80);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(130, 50);
            b_ser.TabIndex = 217;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 30);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 227;
            label4.Text = "社員名";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(290, 80);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(130, 50);
            b_upd.TabIndex = 216;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(400, 30);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 226;
            label3.Text = "権限";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(150, 80);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(130, 50);
            b_reg.TabIndex = 215;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            // 
            // b_rec
            // 
            b_rec.BackColor = Color.Navy;
            b_rec.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_rec.ForeColor = Color.White;
            b_rec.Location = new Point(15, 215);
            b_rec.Name = "b_rec";
            b_rec.Size = new Size(120, 70);
            b_rec.TabIndex = 225;
            b_rec.Text = "入庫";
            b_rec.UseVisualStyleBackColor = false;
            // 
            // b_hor
            // 
            b_hor.BackColor = Color.FromArgb(255, 255, 192);
            b_hor.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_hor.ForeColor = Color.Black;
            b_hor.Location = new Point(15, 150);
            b_hor.Name = "b_hor";
            b_hor.Size = new Size(120, 50);
            b_hor.TabIndex = 224;
            b_hor.Text = "発注";
            b_hor.UseVisualStyleBackColor = false;
            b_hor.Click += b_hor_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
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
            panel1.Location = new Point(150, 135);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 600);
            panel1.TabIndex = 223;
            // 
            // NyuukoFlag
            // 
            NyuukoFlag.AutoSize = true;
            NyuukoFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NyuukoFlag.ForeColor = Color.LavenderBlush;
            NyuukoFlag.Location = new Point(435, 65);
            NyuukoFlag.Name = "NyuukoFlag";
            NyuukoFlag.Size = new Size(92, 29);
            NyuukoFlag.TabIndex = 264;
            NyuukoFlag.Text = "入庫済";
            NyuukoFlag.UseVisualStyleBackColor = true;
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
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(120, 65);
            date.Name = "date";
            date.Size = new Size(300, 31);
            date.TabIndex = 260;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(225, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 253;
            label6.Text = "発注ID";
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.LavenderBlush;
            DelFlag.Location = new Point(20, 110);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 263;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(20, 65);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 259;
            label18.Text = "入庫年月日";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(430, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 255;
            label14.Text = "社員ID";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(15, 20);
            label8.Name = "label8";
            label8.Size = new Size(66, 25);
            label8.TabIndex = 254;
            label8.Text = "入庫ID";
            label8.Click += label8_Click;
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(220, 110);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 262;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(115, 110);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 261;
            label17.Text = "非表示理由";
            // 
            // TBShainID
            // 
            TBShainID.Location = new Point(500, 20);
            TBShainID.Name = "TBShainID";
            TBShainID.Size = new Size(130, 31);
            TBShainID.TabIndex = 258;
            // 
            // TBHattyuuID
            // 
            TBHattyuuID.Location = new Point(290, 20);
            TBHattyuuID.Name = "TBHattyuuID";
            TBHattyuuID.Size = new Size(130, 31);
            TBHattyuuID.TabIndex = 256;
            // 
            // TBNyukoID
            // 
            TBNyukoID.Location = new Point(85, 20);
            TBNyukoID.Name = "TBNyukoID";
            TBNyukoID.Size = new Size(130, 31);
            TBNyukoID.TabIndex = 257;
            // 
            // labeldate
            // 
            labeldate.AutoSize = true;
            labeldate.Location = new Point(140, 30);
            labeldate.Name = "labeldate";
            labeldate.Size = new Size(156, 25);
            labeldate.TabIndex = 221;
            labeldate.Text = "yyyy年mm月dd日";
            // 
            // labeltime
            // 
            labeltime.AutoSize = true;
            labeltime.Location = new Point(40, 30);
            labeltime.Name = "labeltime";
            labeltime.Size = new Size(80, 25);
            labeltime.TabIndex = 220;
            labeltime.Text = "11:11:11";
            // 
            // kakutei
            // 
            kakutei.BackColor = Color.FromArgb(255, 192, 192);
            kakutei.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            kakutei.Location = new Point(910, 80);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(130, 50);
            kakutei.TabIndex = 252;
            kakutei.Text = "確定";
            kakutei.UseVisualStyleBackColor = false;
            kakutei.Click += kakutei_Click;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(1050, 80);
            clear.Name = "clear";
            clear.Size = new Size(115, 50);
            clear.TabIndex = 251;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            close.Location = new Point(1060, 15);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 250;
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
            // receivingstock
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 744);
            Controls.Add(B_iti);
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
            Controls.Add(b_rec);
            Controls.Add(b_hor);
            Controls.Add(panel1);
            Controls.Add(labeldate);
            Controls.Add(labeltime);
            Name = "receivingstock";
            Text = "入庫";
            Load += receivingstock_Load;
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
        private Button b_rec;
        private Button b_hor;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Label labeldate;
        private Label labeltime;
        private Button kakutei;
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
    }
}