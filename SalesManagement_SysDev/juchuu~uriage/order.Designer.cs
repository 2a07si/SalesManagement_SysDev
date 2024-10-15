namespace SalesManagement_SysDev
{
    partial class order
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
            b_acc = new Button();
            b_sal = new Button();
            b_ord = new Button();
            b_shi = new Button();
            b_arr = new Button();
            b_lss = new Button();
            panel1 = new Panel();
            TBJyutyuID = new MaskedTextBox();
            label7 = new Label();
            TyumonFlag = new CheckBox();
            dataGridView1 = new DataGridView();
            DelFlag = new CheckBox();
            label6 = new Label();
            TBKokyakuId = new MaskedTextBox();
            label5 = new Label();
            date = new DateTimePicker();
            label12 = new Label();
            label18 = new Label();
            label14 = new Label();
            TBRiyuu = new MaskedTextBox();
            TBTyumonID = new MaskedTextBox();
            label17 = new Label();
            TBShopId = new MaskedTextBox();
            TBShainId = new MaskedTextBox();
            labeldate = new Label();
            labeltime = new Label();
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
            label_ename.Location = new Point(665, 30);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 214;
            label_ename.Text = "label7";
            // 
            // b_flg
            // 
            b_flg.BackColor = Color.FromArgb(192, 255, 255);
            b_flg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_flg.Location = new Point(610, 80);
            b_flg.Name = "b_flg";
            b_flg.Size = new Size(130, 50);
            b_flg.TabIndex = 199;
            b_flg.Text = "非表示";
            b_flg.UseVisualStyleBackColor = false;
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(445, 30);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 213;
            label_id.Text = "label6";
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(455, 80);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(130, 50);
            b_ser.TabIndex = 198;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 30);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 212;
            label4.Text = "社員名";
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(300, 80);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(130, 50);
            b_upd.TabIndex = 197;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(400, 30);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 211;
            label3.Text = "権限";
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(145, 80);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(130, 50);
            b_reg.TabIndex = 196;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            // 
            // b_acc
            // 
            b_acc.BackColor = Color.FromArgb(255, 255, 192);
            b_acc.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_acc.ForeColor = Color.Black;
            b_acc.Location = new Point(15, 150);
            b_acc.Name = "b_acc";
            b_acc.Size = new Size(120, 50);
            b_acc.TabIndex = 210;
            b_acc.Text = "受注";
            b_acc.UseVisualStyleBackColor = false;
            b_acc.Click += b_acc_Click;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(255, 255, 192);
            b_sal.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.ForeColor = Color.Black;
            b_sal.Location = new Point(15, 510);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(120, 50);
            b_sal.TabIndex = 209;
            b_sal.Text = "売上";
            b_sal.UseVisualStyleBackColor = false;
            b_sal.Click += b_sal_Click;
            // 
            // b_ord
            // 
            b_ord.BackColor = Color.Navy;
            b_ord.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.ForeColor = Color.White;
            b_ord.Location = new Point(15, 215);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(120, 70);
            b_ord.TabIndex = 208;
            b_ord.Text = "注文";
            b_ord.UseVisualStyleBackColor = false;
            // 
            // b_shi
            // 
            b_shi.BackColor = Color.FromArgb(255, 255, 192);
            b_shi.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.ForeColor = Color.Black;
            b_shi.Location = new Point(15, 440);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(120, 50);
            b_shi.TabIndex = 207;
            b_shi.Text = "出荷";
            b_shi.UseVisualStyleBackColor = false;
            b_shi.Click += b_shi_Click;
            // 
            // b_arr
            // 
            b_arr.BackColor = Color.FromArgb(255, 255, 192);
            b_arr.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.ForeColor = Color.Black;
            b_arr.Location = new Point(15, 370);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(120, 50);
            b_arr.TabIndex = 206;
            b_arr.Text = "入荷";
            b_arr.UseVisualStyleBackColor = false;
            b_arr.Click += b_arr_Click;
            // 
            // b_lss
            // 
            b_lss.BackColor = Color.FromArgb(255, 255, 192);
            b_lss.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_lss.ForeColor = Color.Black;
            b_lss.Location = new Point(15, 300);
            b_lss.Name = "b_lss";
            b_lss.Size = new Size(120, 50);
            b_lss.TabIndex = 205;
            b_lss.Text = "出庫";
            b_lss.UseVisualStyleBackColor = false;
            b_lss.Click += b_lss_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(TBJyutyuID);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(TyumonFlag);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(DelFlag);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(TBKokyakuId);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(date);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(TBRiyuu);
            panel1.Controls.Add(TBTyumonID);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(TBShopId);
            panel1.Controls.Add(TBShainId);
            panel1.Location = new Point(150, 135);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 520);
            panel1.TabIndex = 204;
            // 
            // TBJyutyuID
            // 
            TBJyutyuID.Location = new Point(81, 65);
            TBJyutyuID.Name = "TBJyutyuID";
            TBJyutyuID.Size = new Size(130, 31);
            TBJyutyuID.TabIndex = 267;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(16, 65);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 266;
            label7.Text = "受注ID";
            // 
            // TyumonFlag
            // 
            TyumonFlag.AutoSize = true;
            TyumonFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TyumonFlag.ForeColor = Color.LavenderBlush;
            TyumonFlag.Location = new Point(638, 64);
            TyumonFlag.Name = "TyumonFlag";
            TyumonFlag.Size = new Size(110, 29);
            TyumonFlag.TabIndex = 265;
            TyumonFlag.Text = "注文状態";
            TyumonFlag.UseVisualStyleBackColor = true;
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
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.LavenderBlush;
            DelFlag.Location = new Point(15, 110);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 264;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(15, 20);
            label6.Name = "label6";
            label6.Size = new Size(66, 25);
            label6.TabIndex = 250;
            label6.Text = "注文ID";
            // 
            // TBKokyakuId
            // 
            TBKokyakuId.Location = new Point(645, 20);
            TBKokyakuId.Name = "TBKokyakuId";
            TBKokyakuId.Size = new Size(130, 31);
            TBKokyakuId.TabIndex = 263;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(575, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 262;
            label5.Text = "顧客ID";
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(318, 65);
            date.Name = "date";
            date.Size = new Size(300, 31);
            date.TabIndex = 261;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(220, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 253;
            label12.Text = "営業所ID";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(210, 65);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 260;
            label18.Text = "受注年月日";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(370, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 254;
            label14.Text = "社員ID";
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(210, 110);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 259;
            // 
            // TBTyumonID
            // 
            TBTyumonID.Location = new Point(80, 20);
            TBTyumonID.Name = "TBTyumonID";
            TBTyumonID.Size = new Size(130, 31);
            TBTyumonID.TabIndex = 255;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(110, 110);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 258;
            label17.Text = "非表示理由";
            // 
            // TBShopId
            // 
            TBShopId.Location = new Point(310, 20);
            TBShopId.Name = "TBShopId";
            TBShopId.Size = new Size(50, 31);
            TBShopId.TabIndex = 256;
            // 
            // TBShainId
            // 
            TBShainId.Location = new Point(440, 20);
            TBShainId.Name = "TBShainId";
            TBShainId.Size = new Size(130, 31);
            TBShainId.TabIndex = 257;
            // 
            // labeldate
            // 
            labeldate.AutoSize = true;
            labeldate.Location = new Point(140, 30);
            labeldate.Name = "labeldate";
            labeldate.Size = new Size(156, 25);
            labeldate.TabIndex = 202;
            labeldate.Text = "yyyy年mm月dd日";
            // 
            // labeltime
            // 
            labeltime.AutoSize = true;
            labeltime.Location = new Point(40, 30);
            labeltime.Name = "labeltime";
            labeltime.Size = new Size(80, 25);
            labeltime.TabIndex = 201;
            labeltime.Text = "11:11:11";
            // 
            // kakutei
            // 
            kakutei.BackColor = Color.FromArgb(255, 192, 192);
            kakutei.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            kakutei.Location = new Point(795, 80);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(130, 50);
            kakutei.TabIndex = 249;
            kakutei.Text = "確定";
            kakutei.UseVisualStyleBackColor = false;
            // 
            // clear
            // 
            clear.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            clear.Location = new Point(935, 80);
            clear.Name = "clear";
            clear.Size = new Size(115, 50);
            clear.TabIndex = 248;
            clear.Text = "クリア";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // close
            // 
            close.Location = new Point(950, 15);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 247;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            close.Click += close_Click;
            // 
            // order
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
            Controls.Add(b_acc);
            Controls.Add(b_sal);
            Controls.Add(b_ord);
            Controls.Add(b_shi);
            Controls.Add(b_arr);
            Controls.Add(b_lss);
            Controls.Add(panel1);
            Controls.Add(labeldate);
            Controls.Add(labeltime);
            Name = "order";
            Text = "注文";
            Load += order_Load;
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
        private Button b_acc;
        private Button b_sal;
        private Button b_ord;
        private Button b_shi;
        private Button b_arr;
        private Button b_lss;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Label labeldate;
        private Label labeltime;
        private Button kakutei;
        private Button clear;
        private Button close;
        private System.Windows.Forms.Timer timer1;
        private CheckBox TyumonFlag;
        private CheckBox DelFlag;
        private Label label6;
        private MaskedTextBox TBKokyakuId;
        private Label label5;
        private DateTimePicker date;
        private Label label12;
        private Label label18;
        private Label label14;
        private MaskedTextBox TBRiyuu;
        private MaskedTextBox TBTyumonID;
        private Label label17;
        private MaskedTextBox TBShopId;
        private MaskedTextBox TBShainId;
        private MaskedTextBox TBJyutyuID;
        private Label label7;
    }
}