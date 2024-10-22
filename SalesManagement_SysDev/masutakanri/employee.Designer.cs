namespace SalesManagement_SysDev
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
            kakutei = new Button();
            clear = new Button();
            close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            B_iti = new Button();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dataGridView2 = new DataGridView();
            Next = new Button();
            Prev = new Button();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.Navy;
            b_emp.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.ForeColor = Color.White;
            b_emp.Location = new Point(15, 150);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(120, 90);
            b_emp.TabIndex = 197;
            b_emp.Text = "社員";
            b_emp.UseVisualStyleBackColor = false;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(255, 255, 192);
            b_mer.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.Location = new Point(15, 250);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(120, 70);
            b_mer.TabIndex = 195;
            b_mer.Text = "商品";
            b_mer.UseVisualStyleBackColor = false;
            b_mer.Click += b_mer_Click;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.FromArgb(255, 255, 192);
            b_cus.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.ForeColor = Color.Black;
            b_cus.Location = new Point(15, 410);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(120, 70);
            b_cus.TabIndex = 193;
            b_cus.Text = "顧客";
            b_cus.UseVisualStyleBackColor = false;
            b_cus.Click += b_cus_Click;
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(255, 255, 192);
            b_sto.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.ForeColor = Color.Black;
            b_sto.Location = new Point(15, 330);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(120, 70);
            b_sto.TabIndex = 192;
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
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(750, 70);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(150, 70);
            b_ser.TabIndex = 181;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
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
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(350, 70);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(150, 70);
            b_upd.TabIndex = 180;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
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
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(150, 70);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(150, 70);
            b_reg.TabIndex = 179;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
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
            panel1.Size = new Size(820, 690);
            panel1.TabIndex = 187;
            // 
            // date
            // 
            date.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(125, 65);
            date.Name = "date";
            date.Size = new Size(300, 31);
            date.TabIndex = 294;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(15, 65);
            label18.Name = "label18";
            label18.Size = new Size(102, 25);
            label18.TabIndex = 293;
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
            dataGridView1.Size = new Size(800, 490);
            dataGridView1.TabIndex = 52;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(15, 20);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 286;
            label5.Text = "社員ID";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(465, 20);
            label12.Name = "label12";
            label12.Size = new Size(84, 25);
            label12.TabIndex = 280;
            label12.Text = "営業所ID";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(190, 20);
            label14.Name = "label14";
            label14.Size = new Size(66, 25);
            label14.TabIndex = 281;
            label14.Text = "社員名";
            // 
            // TBTellNo
            // 
            TBTellNo.Location = new Point(520, 65);
            TBTellNo.Name = "TBTellNo";
            TBTellNo.Size = new Size(200, 31);
            TBTellNo.TabIndex = 292;
            // 
            // TBRiyuu
            // 
            TBRiyuu.Location = new Point(210, 110);
            TBRiyuu.Name = "TBRiyuu";
            TBRiyuu.Size = new Size(325, 31);
            TBRiyuu.TabIndex = 285;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(430, 65);
            label8.Name = "label8";
            label8.Size = new Size(84, 25);
            label8.TabIndex = 291;
            label8.Text = "電話番号";
            // 
            // TBSyainID
            // 
            TBSyainID.Location = new Point(80, 20);
            TBSyainID.Name = "TBSyainID";
            TBSyainID.Size = new Size(103, 31);
            TBSyainID.TabIndex = 287;
            // 
            // TBJobID
            // 
            TBJobID.Location = new Point(690, 20);
            TBJobID.Name = "TBJobID";
            TBJobID.Size = new Size(50, 31);
            TBJobID.TabIndex = 279;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(110, 110);
            label17.Name = "label17";
            label17.Size = new Size(102, 25);
            label17.TabIndex = 284;
            label17.Text = "非表示理由";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(620, 20);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 278;
            label7.Text = "役職ID";
            // 
            // TBShopId
            // 
            TBShopId.Location = new Point(555, 20);
            TBShopId.Name = "TBShopId";
            TBShopId.Size = new Size(50, 31);
            TBShopId.TabIndex = 282;
            // 
            // TBSyainName
            // 
            TBSyainName.Location = new Point(260, 20);
            TBSyainName.Name = "TBSyainName";
            TBSyainName.Size = new Size(200, 31);
            TBSyainName.TabIndex = 283;
            // 
            // DelFlag
            // 
            DelFlag.AutoSize = true;
            DelFlag.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DelFlag.ForeColor = Color.LavenderBlush;
            DelFlag.Location = new Point(15, 109);
            DelFlag.Name = "DelFlag";
            DelFlag.Size = new Size(92, 29);
            DelFlag.TabIndex = 288;
            DelFlag.Text = "非表示";
            DelFlag.UseVisualStyleBackColor = true;
            // 
            // kakutei
            // 
            kakutei.BackColor = Color.FromArgb(255, 192, 192);
            kakutei.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            kakutei.Location = new Point(1200, 70);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(150, 70);
            kakutei.TabIndex = 240;
            kakutei.Text = "確定";
            kakutei.UseVisualStyleBackColor = false;
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
            // 
            // close
            // 
            close.Location = new Point(1460, 10);
            close.Name = "close";
            close.Size = new Size(100, 40);
            close.TabIndex = 238;
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
            B_iti.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            B_iti.Location = new Point(550, 70);
            B_iti.Name = "B_iti";
            B_iti.Size = new Size(150, 70);
            B_iti.TabIndex = 259;
            B_iti.Text = "一覧";
            B_iti.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(1100, 101);
            label2.Name = "label2";
            label2.Size = new Size(62, 32);
            label2.TabIndex = 293;
            label2.Text = "更新";
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
            // panel2
            // 
            panel2.BackColor = Color.DarkRed;
            panel2.Controls.Add(dataGridView2);
            panel2.Location = new Point(970, 145);
            panel2.Name = "panel2";
            panel2.Size = new Size(600, 690);
            panel2.TabIndex = 291;
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
            // Next
            // 
            Next.Location = new Point(770, 144);
            Next.Name = "Next";
            Next.Size = new Size(40, 40);
            Next.TabIndex = 297;
            Next.Text = "▶";
            Next.UseVisualStyleBackColor = true;
            // 
            // Prev
            // 
            Prev.Location = new Point(640, 144);
            Prev.Name = "Prev";
            Prev.Size = new Size(40, 40);
            Prev.TabIndex = 296;
            Prev.Text = "◀";
            Prev.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Snow;
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(690, 152);
            label6.Name = "label6";
            label6.Size = new Size(72, 25);
            label6.TabIndex = 295;
            label6.Text = "何ページ";
            // 
            // employee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(B_iti);
            Controls.Add(kakutei);
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
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private Button kakutei;
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
        private Panel panel2;
        private DataGridView dataGridView2;
        private Button Next;
        private Button Prev;
        private Label label6;
    }
}