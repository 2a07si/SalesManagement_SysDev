namespace SalesManagement_SysDev
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
            tb_riyuu = new MaskedTextBox();
            label17 = new Label();
            tb_eigyoushoid = new MaskedTextBox();
            tb_shainid = new MaskedTextBox();
            tb_shouhinid = new MaskedTextBox();
            tb_juchuuid = new MaskedTextBox();
            tb_suuryou = new MaskedTextBox();
            tb_kokyakuid = new MaskedTextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label_shouhinmei = new Label();
            label11 = new Label();
            label_kokyakumei = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
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
            panel1.Controls.Add(date);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(tb_riyuu);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(tb_eigyoushoid);
            panel1.Controls.Add(tb_shainid);
            panel1.Controls.Add(tb_shouhinid);
            panel1.Controls.Add(tb_juchuuid);
            panel1.Controls.Add(tb_suuryou);
            panel1.Controls.Add(tb_kokyakuid);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label_shouhinmei);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label_kokyakumei);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
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
            date.Location = new Point(589, 109);
            date.Name = "date";
            date.Size = new Size(300, 31);
            date.TabIndex = 75;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(478, 114);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 74;
            label18.Text = "受注年月日";
            // 
            // tb_riyuu
            // 
            tb_riyuu.Location = new Point(123, 109);
            tb_riyuu.Name = "tb_riyuu";
            tb_riyuu.Size = new Size(325, 31);
            tb_riyuu.TabIndex = 73;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(15, 112);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 72;
            label17.Text = "非表示理由";
            // 
            // tb_eigyoushoid
            // 
            tb_eigyoushoid.Location = new Point(786, 63);
            tb_eigyoushoid.Name = "tb_eigyoushoid";
            tb_eigyoushoid.Size = new Size(103, 31);
            tb_eigyoushoid.TabIndex = 70;
            // 
            // tb_shainid
            // 
            tb_shainid.Location = new Point(786, 16);
            tb_shainid.Name = "tb_shainid";
            tb_shainid.Size = new Size(103, 31);
            tb_shainid.TabIndex = 69;
            // 
            // tb_shouhinid
            // 
            tb_shouhinid.Location = new Point(99, 63);
            tb_shouhinid.Name = "tb_shouhinid";
            tb_shouhinid.Size = new Size(150, 31);
            tb_shouhinid.TabIndex = 67;
            // 
            // tb_juchuuid
            // 
            tb_juchuuid.Location = new Point(572, 16);
            tb_juchuuid.Name = "tb_juchuuid";
            tb_juchuuid.Size = new Size(104, 31);
            tb_juchuuid.TabIndex = 66;
            // 
            // tb_suuryou
            // 
            tb_suuryou.Location = new Point(572, 63);
            tb_suuryou.Name = "tb_suuryou";
            tb_suuryou.Size = new Size(104, 31);
            tb_suuryou.TabIndex = 65;
            // 
            // tb_kokyakuid
            // 
            tb_kokyakuid.Location = new Point(99, 19);
            tb_kokyakuid.Name = "tb_kokyakuid";
            tb_kokyakuid.Size = new Size(150, 31);
            tb_kokyakuid.TabIndex = 64;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(482, 69);
            label15.Name = "label15";
            label15.Size = new Size(48, 25);
            label15.TabIndex = 63;
            label15.Text = "数量";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(696, 22);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 62;
            label14.Text = "社員ID";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(696, 69);
            label13.Name = "label13";
            label13.Size = new Size(84, 25);
            label13.TabIndex = 61;
            label13.Text = "営業所ID";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(482, 22);
            label12.Name = "label12";
            label12.Size = new Size(66, 25);
            label12.TabIndex = 60;
            label12.Text = "受注ID";
            // 
            // label_shouhinmei
            // 
            label_shouhinmei.AutoSize = true;
            label_shouhinmei.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_shouhinmei.ForeColor = Color.White;
            label_shouhinmei.Location = new Point(357, 66);
            label_shouhinmei.Name = "label_shouhinmei";
            label_shouhinmei.Size = new Size(69, 25);
            label_shouhinmei.TabIndex = 59;
            label_shouhinmei.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(273, 66);
            label11.Name = "label11";
            label11.Size = new Size(66, 25);
            label11.TabIndex = 58;
            label11.Text = "商品名";
            // 
            // label_kokyakumei
            // 
            label_kokyakumei.AutoSize = true;
            label_kokyakumei.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_kokyakumei.ForeColor = Color.White;
            label_kokyakumei.Location = new Point(357, 19);
            label_kokyakumei.Name = "label_kokyakumei";
            label_kokyakumei.Size = new Size(62, 25);
            label_kokyakumei.TabIndex = 57;
            label_kokyakumei.Text = "label9";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(273, 19);
            label8.Name = "label8";
            label8.Size = new Size(66, 25);
            label8.TabIndex = 56;
            label8.Text = "顧客名";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(15, 69);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 55;
            label7.Text = "商品ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(15, 22);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 54;
            label6.Text = "顧客ID";
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
        private MaskedTextBox tb_riyuu;
        private Label label17;
        private MaskedTextBox tb_eigyoushoid;
        private MaskedTextBox tb_shainid;
        private MaskedTextBox tb_shouhinid;
        private MaskedTextBox tb_juchuuid;
        private MaskedTextBox tb_suuryou;
        private MaskedTextBox tb_kokyakuid;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label_shouhinmei;
        private Label label11;
        private Label label_kokyakumei;
        private Label label8;
        private Label label7;
        private Label label6;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
        private Button kakutei;
        private Button clear;
        private Button close;
        private System.Windows.Forms.Timer timer1;
    }
}