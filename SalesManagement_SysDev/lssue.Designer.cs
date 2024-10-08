namespace SalesManagement_SysDev
{
    partial class lssue
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
            label_ename = new Label();
            label_id = new Label();
            label4 = new Label();
            label3 = new Label();
            b_next = new Button();
            b_ord = new Button();
            b_shi = new Button();
            b_arr = new Button();
            b_lss = new Button();
            b_rec = new Button();
            b_hor = new Button();
            panel1 = new Panel();
            close = new Button();
            b_flg = new Button();
            b_ser = new Button();
            b_upd = new Button();
            b_reg = new Button();
            dataGridView1 = new DataGridView();
            b_logout = new Button();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(719, 77);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 199;
            label_ename.Text = "label7";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(719, 35);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 198;
            label_id.Text = "label6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(626, 76);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 197;
            label4.Text = "社員名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(626, 35);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 196;
            label3.Text = "社員ID";
            // 
            // b_next
            // 
            b_next.BackColor = Color.FromArgb(192, 255, 255);
            b_next.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_next.Location = new Point(916, 65);
            b_next.Name = "b_next";
            b_next.Size = new Size(112, 47);
            b_next.TabIndex = 195;
            b_next.Text = "前ページへ";
            b_next.UseVisualStyleBackColor = false;
            // 
            // b_ord
            // 
            b_ord.BackColor = Color.FromArgb(255, 255, 192);
            b_ord.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.ForeColor = Color.Black;
            b_ord.Location = new Point(15, 128);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(120, 47);
            b_ord.TabIndex = 194;
            b_ord.Text = "注文";
            b_ord.UseVisualStyleBackColor = false;
            // 
            // b_shi
            // 
            b_shi.BackColor = Color.FromArgb(255, 255, 192);
            b_shi.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.ForeColor = Color.Black;
            b_shi.Location = new Point(15, 542);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(120, 47);
            b_shi.TabIndex = 193;
            b_shi.Text = "出荷";
            b_shi.UseVisualStyleBackColor = false;
            // 
            // b_arr
            // 
            b_arr.BackColor = Color.FromArgb(255, 255, 192);
            b_arr.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.Location = new Point(15, 467);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(120, 47);
            b_arr.TabIndex = 192;
            b_arr.Text = "入荷";
            b_arr.UseVisualStyleBackColor = false;
            // 
            // b_lss
            // 
            b_lss.BackColor = Color.Navy;
            b_lss.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_lss.ForeColor = Color.White;
            b_lss.Location = new Point(15, 360);
            b_lss.Name = "b_lss";
            b_lss.Size = new Size(120, 74);
            b_lss.TabIndex = 191;
            b_lss.Text = "出庫";
            b_lss.UseVisualStyleBackColor = false;
            // 
            // b_rec
            // 
            b_rec.BackColor = Color.FromArgb(255, 255, 192);
            b_rec.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_rec.ForeColor = Color.Black;
            b_rec.Location = new Point(15, 283);
            b_rec.Name = "b_rec";
            b_rec.Size = new Size(120, 47);
            b_rec.TabIndex = 190;
            b_rec.Text = "入庫";
            b_rec.UseVisualStyleBackColor = false;
            // 
            // b_hor
            // 
            b_hor.BackColor = Color.FromArgb(255, 255, 192);
            b_hor.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_hor.ForeColor = Color.Black;
            b_hor.Location = new Point(15, 204);
            b_hor.Name = "b_hor";
            b_hor.Size = new Size(120, 47);
            b_hor.TabIndex = 189;
            b_hor.Text = "発注";
            b_hor.UseVisualStyleBackColor = false;
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
            panel1.Location = new Point(147, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(905, 525);
            panel1.TabIndex = 188;
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
            // b_logout
            // 
            b_logout.Location = new Point(916, 13);
            b_logout.Name = "b_logout";
            b_logout.Size = new Size(112, 47);
            b_logout.TabIndex = 187;
            b_logout.Text = "ログアウト";
            b_logout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 76);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 186;
            label2.Text = "yyyy年mm月dd日";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 35);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 185;
            label1.Text = "11:11:11";
            // 
            // lssue
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 667);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(b_next);
            Controls.Add(b_ord);
            Controls.Add(b_shi);
            Controls.Add(b_arr);
            Controls.Add(b_lss);
            Controls.Add(b_rec);
            Controls.Add(b_hor);
            Controls.Add(panel1);
            Controls.Add(b_logout);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "lssue";
            Text = "lssue";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_ename;
        private Label label_id;
        private Label label4;
        private Label label3;
        private Button b_next;
        private Button b_ord;
        private Button b_shi;
        private Button b_arr;
        private Button b_lss;
        private Button b_rec;
        private Button b_hor;
        private Panel panel1;
        private Button close;
        private Button b_flg;
        private Button b_ser;
        private Button b_upd;
        private Button b_reg;
        private DataGridView dataGridView1;
        private Button b_logout;
        private Label label2;
        private Label label1;
    }
}