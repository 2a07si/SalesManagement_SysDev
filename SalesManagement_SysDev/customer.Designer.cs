namespace SalesManagement_SysDev
{
    partial class customer
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
            b_next = new Button();
            b_acc = new Button();
            b_sal = new Button();
            b_emp = new Button();
            b_sto = new Button();
            b_mer = new Button();
            b_cus = new Button();
            panel1 = new Panel();
            close = new Button();
            b_flg = new Button();
            b_ser = new Button();
            b_upd = new Button();
            b_reg = new Button();
            dataGridView1 = new DataGridView();
            b_bar = new Button();
            b_logout = new Button();
            label2 = new Label();
            label1 = new Label();
            label_ename = new Label();
            label_id = new Label();
            label5 = new Label();
            label8 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // b_next
            // 
            b_next.BackColor = Color.FromArgb(192, 255, 255);
            b_next.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_next.Location = new Point(913, 65);
            b_next.Name = "b_next";
            b_next.Size = new Size(112, 47);
            b_next.TabIndex = 67;
            b_next.Text = "次ページへ";
            b_next.UseVisualStyleBackColor = false;
            // 
            // b_acc
            // 
            b_acc.BackColor = Color.FromArgb(255, 255, 192);
            b_acc.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_acc.Location = new Point(12, 606);
            b_acc.Name = "b_acc";
            b_acc.Size = new Size(120, 47);
            b_acc.TabIndex = 66;
            b_acc.Text = "受注";
            b_acc.UseVisualStyleBackColor = false;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(255, 255, 192);
            b_sal.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.Location = new Point(12, 535);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(120, 47);
            b_sal.TabIndex = 65;
            b_sal.Text = "売上";
            b_sal.UseVisualStyleBackColor = false;
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.FromArgb(255, 255, 192);
            b_emp.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.Location = new Point(12, 460);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(120, 47);
            b_emp.TabIndex = 64;
            b_emp.Text = "社員";
            b_emp.UseVisualStyleBackColor = false;
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(255, 255, 192);
            b_sto.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.Location = new Point(12, 384);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(120, 47);
            b_sto.TabIndex = 63;
            b_sto.Text = "在庫";
            b_sto.UseVisualStyleBackColor = false;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(255, 255, 192);
            b_mer.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.Location = new Point(12, 310);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(120, 47);
            b_mer.TabIndex = 62;
            b_mer.Text = "商品";
            b_mer.UseVisualStyleBackColor = false;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.Navy;
            b_cus.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.ForeColor = Color.White;
            b_cus.Location = new Point(12, 203);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(120, 74);
            b_cus.TabIndex = 61;
            b_cus.Text = "顧客";
            b_cus.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(close);
            panel1.Controls.Add(b_flg);
            panel1.Controls.Add(b_ser);
            panel1.Controls.Add(b_upd);
            panel1.Controls.Add(b_reg);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(144, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(905, 525);
            panel1.TabIndex = 60;
            // 
            // close
            // 
            close.Location = new Point(740, 34);
            close.Name = "close";
            close.Size = new Size(129, 48);
            close.TabIndex = 57;
            close.Text = "閉じる";
            close.UseVisualStyleBackColor = true;
            // 
            // b_flg
            // 
            b_flg.BackColor = Color.FromArgb(192, 255, 255);
            b_flg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_flg.Location = new Point(479, 34);
            b_flg.Name = "b_flg";
            b_flg.Size = new Size(129, 48);
            b_flg.TabIndex = 56;
            b_flg.Text = "表示/非表示";
            b_flg.UseVisualStyleBackColor = false;
            // 
            // b_ser
            // 
            b_ser.BackColor = Color.FromArgb(192, 255, 255);
            b_ser.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ser.Location = new Point(332, 34);
            b_ser.Name = "b_ser";
            b_ser.Size = new Size(129, 48);
            b_ser.TabIndex = 55;
            b_ser.Text = "検索";
            b_ser.UseVisualStyleBackColor = false;
            // 
            // b_upd
            // 
            b_upd.BackColor = Color.FromArgb(192, 255, 255);
            b_upd.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_upd.Location = new Point(185, 34);
            b_upd.Name = "b_upd";
            b_upd.Size = new Size(129, 48);
            b_upd.TabIndex = 54;
            b_upd.Text = "更新";
            b_upd.UseVisualStyleBackColor = false;
            // 
            // b_reg
            // 
            b_reg.BackColor = Color.FromArgb(192, 255, 255);
            b_reg.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_reg.Location = new Point(38, 34);
            b_reg.Name = "b_reg";
            b_reg.Size = new Size(129, 48);
            b_reg.TabIndex = 53;
            b_reg.Text = "登録";
            b_reg.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(16, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(874, 493);
            dataGridView1.TabIndex = 52;
            // 
            // b_bar
            // 
            b_bar.BackColor = Color.FromArgb(255, 255, 192);
            b_bar.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_bar.ForeColor = Color.Black;
            b_bar.Location = new Point(12, 131);
            b_bar.Name = "b_bar";
            b_bar.Size = new Size(120, 47);
            b_bar.TabIndex = 59;
            b_bar.Text = "バーコード";
            b_bar.UseVisualStyleBackColor = false;
            b_bar.Click += button1_Click;
            // 
            // b_logout
            // 
            b_logout.Location = new Point(913, 13);
            b_logout.Name = "b_logout";
            b_logout.Size = new Size(112, 47);
            b_logout.TabIndex = 58;
            b_logout.Text = "ログアウト";
            b_logout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 76);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 53;
            label2.Text = "yyyy年mm月dd日";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 35);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 52;
            label1.Text = "11:11:11";
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(717, 77);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 106;
            label_ename.Text = "label7";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(717, 35);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 105;
            label_id.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(624, 76);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 104;
            label5.Text = "社員名";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(624, 35);
            label8.Name = "label8";
            label8.Size = new Size(66, 25);
            label8.TabIndex = 103;
            label8.Text = "社員ID";
            // 
            // customer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 667);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(b_next);
            Controls.Add(b_acc);
            Controls.Add(b_sal);
            Controls.Add(b_emp);
            Controls.Add(b_sto);
            Controls.Add(b_mer);
            Controls.Add(b_cus);
            Controls.Add(panel1);
            Controls.Add(b_bar);
            Controls.Add(b_logout);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "customer";
            Text = "customer";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button b_next;
        private Button b_acc;
        private Button b_sal;
        private Button b_emp;
        private Button b_sto;
        private Button b_mer;
        private Button b_cus;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button b_bar;
        private Button b_logout;
        private Label label2;
        private Label label1;
        private Button b_flg;
        private Button b_ser;
        private Button b_upd;
        private Button b_reg;
        private Button close;
        private Label label_ename;
        private Label label_id;
        private Label label5;
        private Label label8;
    }
}