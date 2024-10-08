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
            button1 = new Button();
            clear = new Button();
            close = new Button();
            label_ename = new Label();
            b_flg = new Button();
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
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            maskedTextBox1 = new MaskedTextBox();
            label5 = new Label();
            date = new DateTimePicker();
            label18 = new Label();
            tb_riyuu = new MaskedTextBox();
            label17 = new Label();
            TBShainId = new MaskedTextBox();
            TBShopId = new MaskedTextBox();
            TBJyutyu = new MaskedTextBox();
            label14 = new Label();
            label12 = new Label();
            LBTantouShain = new Label();
            label7 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // kakutei
            // 
            kakutei.Location = new Point(0, 0);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(75, 23);
            kakutei.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(794, 78);
            button1.Name = "button1";
            button1.Size = new Size(129, 48);
            button1.TabIndex = 257;
            button1.Text = "確定";
            button1.UseVisualStyleBackColor = false;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(934, 78);
            clear.Name = "clear";
            clear.Size = new Size(112, 48);
            clear.TabIndex = 256;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            close.Location = new Point(924, 13);
            close.Name = "close";
            close.Size = new Size(129, 48);
            close.TabIndex = 242;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(664, 28);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(96, 25);
            label_ename.TabIndex = 255;
            label_ename.Text = "------------";
            // 
            // b_flg
            // 
            b_flg.BackColor = Color.FromArgb(192, 255, 255);
            b_flg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_flg.Location = new Point(609, 78);
            b_flg.Name = "b_flg";
            b_flg.Size = new Size(129, 48);
            b_flg.TabIndex = 241;
            b_flg.Text = "非表示";
            b_flg.UseVisualStyleBackColor = false;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(444, 28);
            label_id.Name = "label_id";
            label_id.Size = new Size(54, 25);
            label_id.TabIndex = 254;
            label_id.Text = "------";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(454, 78);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(129, 48);
            b_ser.TabIndex = 240;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(599, 28);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 253;
            label4.Text = "社員名";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(299, 78);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(129, 48);
            b_upd.TabIndex = 239;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(399, 28);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 252;
            label3.Text = "権限";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(144, 78);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(129, 48);
            b_reg.TabIndex = 238;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            // 
            // b_ord
            // 
            b_ord.BackColor = Color.FromArgb(255, 255, 192);
            b_ord.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.ForeColor = Color.Black;
            b_ord.Location = new Point(14, 228);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(120, 50);
            b_ord.TabIndex = 251;
            b_ord.Text = "注文";
            b_ord.UseVisualStyleBackColor = false;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(255, 255, 192);
            b_sal.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.ForeColor = Color.Black;
            b_sal.Location = new Point(14, 508);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(120, 47);
            b_sal.TabIndex = 250;
            b_sal.Text = "売上";
            b_sal.UseVisualStyleBackColor = false;
            // 
            // b_add
            // 
            b_add.BackColor = Color.Navy;
            b_add.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_add.ForeColor = Color.White;
            b_add.Location = new Point(14, 138);
            b_add.Name = "b_add";
            b_add.Size = new Size(120, 75);
            b_add.TabIndex = 249;
            b_add.Text = "受注";
            b_add.UseVisualStyleBackColor = false;
            // 
            // b_shi
            // 
            b_shi.BackColor = Color.FromArgb(255, 255, 192);
            b_shi.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.ForeColor = Color.Black;
            b_shi.Location = new Point(14, 438);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(120, 47);
            b_shi.TabIndex = 248;
            b_shi.Text = "出荷";
            b_shi.UseVisualStyleBackColor = false;
            // 
            // b_arr
            // 
            b_arr.BackColor = Color.FromArgb(255, 255, 192);
            b_arr.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.ForeColor = Color.Black;
            b_arr.Location = new Point(14, 368);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(120, 47);
            b_arr.TabIndex = 247;
            b_arr.Text = "入荷";
            b_arr.UseVisualStyleBackColor = false;
            // 
            // b_lss
            // 
            b_lss.BackColor = Color.FromArgb(255, 255, 192);
            b_lss.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_lss.ForeColor = Color.Black;
            b_lss.Location = new Point(14, 298);
            b_lss.Name = "b_lss";
            b_lss.Size = new Size(120, 50);
            b_lss.TabIndex = 246;
            b_lss.Text = "出庫";
            b_lss.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(maskedTextBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(date);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(tb_riyuu);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(TBShainId);
            panel1.Controls.Add(TBShopId);
            panel1.Controls.Add(TBJyutyu);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(LBTantouShain);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(149, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 520);
            panel1.TabIndex = 245;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox2.ForeColor = Color.LavenderBlush;
            checkBox2.Location = new Point(706, 64);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(110, 29);
            checkBox2.TabIndex = 79;
            checkBox2.Text = "注文状態";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.LavenderBlush;
            checkBox1.Location = new Point(15, 109);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(92, 29);
            checkBox1.TabIndex = 78;
            checkBox1.Text = "非表示";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(620, 20);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(103, 31);
            maskedTextBox1.TabIndex = 77;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(550, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 76;
            label5.Text = "顧客ID";
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(386, 65);
            date.Name = "date";
            date.Size = new Size(300, 31);
            date.TabIndex = 75;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(278, 65);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 74;
            label18.Text = "受注年月日";
            // 
            // tb_riyuu
            // 
            tb_riyuu.Location = new Point(210, 110);
            tb_riyuu.Name = "tb_riyuu";
            tb_riyuu.Size = new Size(325, 31);
            tb_riyuu.TabIndex = 73;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(110, 110);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 72;
            label17.Text = "非表示理由";
            // 
            // TBShainId
            // 
            TBShainId.Location = new Point(440, 20);
            TBShainId.Name = "TBShainId";
            TBShainId.Size = new Size(103, 31);
            TBShainId.TabIndex = 69;
            // 
            // TBShopId
            // 
            TBShopId.Location = new Point(310, 20);
            TBShopId.Name = "TBShopId";
            TBShopId.Size = new Size(50, 31);
            TBShopId.TabIndex = 66;
            // 
            // TBJyutyu
            // 
            TBJyutyu.Location = new Point(80, 20);
            TBJyutyu.Name = "TBJyutyu";
            TBJyutyu.Size = new Size(130, 31);
            TBJyutyu.TabIndex = 64;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(370, 20);
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
            label12.Location = new Point(220, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 60;
            label12.Text = "営業所ID";
            // 
            // LBTantouShain
            // 
            LBTantouShain.AutoSize = true;
            LBTantouShain.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LBTantouShain.ForeColor = Color.White;
            LBTantouShain.Location = new Point(123, 65);
            LBTantouShain.Name = "LBTantouShain";
            LBTantouShain.Size = new Size(68, 25);
            LBTantouShain.TabIndex = 59;
            LBTantouShain.Text = "--------";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(15, 65);
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
            label6.Location = new Point(15, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 54;
            label6.Text = "受注ID";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(870, 345);
            dataGridView1.TabIndex = 52;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 28);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 244;
            label2.Text = "yyyy年mm月dd日";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 28);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 243;
            label1.Text = "11:11:11";
            // 
            // acceptingorders
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 667);
            Controls.Add(button1);
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
            Controls.Add(b_ord);
            Controls.Add(b_sal);
            Controls.Add(b_add);
            Controls.Add(b_shi);
            Controls.Add(b_arr);
            Controls.Add(b_lss);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "acceptingorders";
            Text = "Form1";
            Load += acceptingorders_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button kakutei;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private Button clear;
        private Button close;
        private Label label_ename;
        private Button b_flg;
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
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private MaskedTextBox maskedTextBox1;
        private Label label5;
        private DateTimePicker date;
        private Label label18;
        private MaskedTextBox tb_riyuu;
        private Label label17;
        private MaskedTextBox TBShainId;
        private MaskedTextBox TBShopId;
        private MaskedTextBox TBJyutyu;
        private Label label14;
        private Label label12;
        private Label LBTantouShain;
        private Label label7;
        private Label label6;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
    }
}