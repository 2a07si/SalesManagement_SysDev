namespace SalesManagement_SysDev
{
    partial class B_Bar
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
            b_logout = new Button();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            b_cus = new Button();
            b_mer = new Button();
            b_sto = new Button();
            b_emp = new Button();
            b_sal = new Button();
            b_acc = new Button();
            b_next = new Button();
            label3 = new Label();
            label4 = new Label();
            label_ename = new Label();
            label9 = new Label();
            label10 = new Label();
            label_id = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // b_logout
            // 
            b_logout.Location = new Point(919, 15);
            b_logout.Name = "b_logout";
            b_logout.Size = new Size(112, 47);
            b_logout.TabIndex = 42;
            b_logout.Text = "ログアウト";
            b_logout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 79);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 37;
            label2.Text = "yyyy年mm月dd日";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 37);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 36;
            label1.Text = "11:11:11";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(244, 226, 207);
            button1.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(12, 130);
            button1.Name = "button1";
            button1.Size = new Size(120, 74);
            button1.TabIndex = 43;
            button1.Text = "バーコード";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 226, 207);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(150, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(905, 525);
            panel1.TabIndex = 44;
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
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.FromArgb(252, 252, 192);
            b_cus.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.Location = new Point(12, 231);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(120, 47);
            b_cus.TabIndex = 45;
            b_cus.Text = "顧客";
            b_cus.UseVisualStyleBackColor = false;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(252, 252, 192);
            b_mer.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.Location = new Point(12, 309);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(120, 47);
            b_mer.TabIndex = 46;
            b_mer.Text = "商品";
            b_mer.UseVisualStyleBackColor = false;
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(252, 252, 192);
            b_sto.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.Location = new Point(12, 383);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(120, 47);
            b_sto.TabIndex = 47;
            b_sto.Text = "在庫";
            b_sto.UseVisualStyleBackColor = false;
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.FromArgb(252, 252, 192);
            b_emp.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.Location = new Point(12, 459);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(120, 47);
            b_emp.TabIndex = 48;
            b_emp.Text = "社員";
            b_emp.UseVisualStyleBackColor = false;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(252, 252, 192);
            b_sal.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.Location = new Point(12, 534);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(120, 47);
            b_sal.TabIndex = 49;
            b_sal.Text = "売上";
            b_sal.UseVisualStyleBackColor = false;
            // 
            // b_acc
            // 
            b_acc.BackColor = Color.FromArgb(252, 252, 192);
            b_acc.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_acc.Location = new Point(12, 605);
            b_acc.Name = "b_acc";
            b_acc.Size = new Size(120, 47);
            b_acc.TabIndex = 50;
            b_acc.Text = "受注";
            b_acc.UseVisualStyleBackColor = false;
            // 
            // b_next
            // 
            b_next.BackColor = Color.FromArgb(212, 222, 255);
            b_next.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            b_next.Location = new Point(919, 67);
            b_next.Name = "b_next";
            b_next.Size = new Size(112, 47);
            b_next.TabIndex = 51;
            b_next.Text = "次ページへ";
            b_next.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(629, 37);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 38;
            label3.Text = "社員ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(629, 78);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 39;
            label4.Text = "社員名";
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(722, 79);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 108;
            label_ename.Text = "label5";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(629, 78);
            label9.Name = "label9";
            label9.Size = new Size(66, 25);
            label9.TabIndex = 106;
            label9.Text = "社員名";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(629, 37);
            label10.Name = "label10";
            label10.Size = new Size(66, 25);
            label10.TabIndex = 105;
            label10.Text = "社員ID";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(722, 37);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 107;
            label_id.Text = "label8";
            // 
            // B_Bar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(b_next);
            Controls.Add(b_acc);
            Controls.Add(b_sal);
            Controls.Add(b_emp);
            Controls.Add(b_sto);
            Controls.Add(b_mer);
            Controls.Add(b_cus);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(b_logout);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "B_Bar";
            Text = "barcode";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button b_logout;
        private Label label2;
        private Label label1;
        private Button button1;
        private Panel panel1;
        private Button b_cus;
        private Button b_mer;
        private Button b_sto;
        private Button b_emp;
        private Button b_sal;
        private Button b_acc;
        private Button b_next;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label4;
        private Label label_ename;
        private Label label9;
        private Label label10;
        private Label label_id;
    }
}