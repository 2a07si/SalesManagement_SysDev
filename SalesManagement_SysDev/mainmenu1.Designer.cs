namespace SalesManagement_SysDev
{
    partial class mainmenu1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            b_logout = new Button();
            b_next = new Button();
            b_bar = new Button();
            b_cus = new Button();
            b_mer = new Button();
            b_sto = new Button();
            b_emp = new Button();
            b_sal = new Button();
            b_acc = new Button();
            label_ename = new Label();
            label_id = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 47);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 0;
            label1.Text = "11:11:11";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 88);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 1;
            label2.Text = "yyyy年mm月dd日";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(635, 47);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 2;
            label3.Text = "社員ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(635, 88);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 3;
            label4.Text = "社員名";
            // 
            // b_logout
            // 
            b_logout.Location = new Point(923, 66);
            b_logout.Name = "b_logout";
            b_logout.Size = new Size(112, 47);
            b_logout.TabIndex = 21;
            b_logout.Text = "ログアウト";
            b_logout.UseVisualStyleBackColor = true;
            // 
            // b_next
            // 
            b_next.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            b_next.Location = new Point(862, 581);
            b_next.Name = "b_next";
            b_next.Size = new Size(173, 58);
            b_next.TabIndex = 22;
            b_next.Text = "次ページへ";
            b_next.UseVisualStyleBackColor = true;
            // 
            // b_bar
            // 
            b_bar.BackColor = Color.FromArgb(255, 255, 192);
            b_bar.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_bar.Location = new Point(18, 220);
            b_bar.Name = "b_bar";
            b_bar.Size = new Size(254, 164);
            b_bar.TabIndex = 23;
            b_bar.Text = "バーコード管理";
            b_bar.UseVisualStyleBackColor = false;
            // 
            // b_cus
            // 
            b_cus.BackColor = Color.FromArgb(255, 255, 192);
            b_cus.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.Location = new Point(269, 220);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(259, 164);
            b_cus.TabIndex = 24;
            b_cus.Text = "顧客管理";
            b_cus.UseVisualStyleBackColor = false;
            b_cus.Click += button2_Click;
            // 
            // b_mer
            // 
            b_mer.BackColor = Color.FromArgb(255, 255, 192);
            b_mer.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.Location = new Point(523, 220);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(262, 164);
            b_mer.TabIndex = 25;
            b_mer.Text = "商品管理";
            b_mer.UseVisualStyleBackColor = false;
            // 
            // b_sto
            // 
            b_sto.BackColor = Color.FromArgb(255, 255, 192);
            b_sto.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.Location = new Point(781, 220);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(271, 164);
            b_sto.TabIndex = 26;
            b_sto.Text = "在庫管理";
            b_sto.UseVisualStyleBackColor = false;
            // 
            // b_emp
            // 
            b_emp.BackColor = Color.FromArgb(255, 255, 192);
            b_emp.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.Location = new Point(140, 390);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(259, 164);
            b_emp.TabIndex = 27;
            b_emp.Text = "社員管理";
            b_emp.UseVisualStyleBackColor = false;
            // 
            // b_sal
            // 
            b_sal.BackColor = Color.FromArgb(255, 255, 192);
            b_sal.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.Location = new Point(394, 390);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(262, 164);
            b_sal.TabIndex = 28;
            b_sal.Text = "売上管理";
            b_sal.UseVisualStyleBackColor = false;
            // 
            // b_acc
            // 
            b_acc.BackColor = Color.FromArgb(255, 255, 192);
            b_acc.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_acc.Location = new Point(652, 390);
            b_acc.Name = "b_acc";
            b_acc.Size = new Size(271, 164);
            b_acc.TabIndex = 29;
            b_acc.Text = "受注管理";
            b_acc.UseVisualStyleBackColor = false;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(726, 89);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 110;
            label_ename.Text = "label5";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(726, 47);
            label_id.Name = "label_id";
            label_id.Size = new Size(59, 25);
            label_id.TabIndex = 109;
            label_id.Text = "label8";
            // 
            // mainmenu1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1067, 667);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(b_acc);
            Controls.Add(b_sal);
            Controls.Add(b_emp);
            Controls.Add(b_sto);
            Controls.Add(b_mer);
            Controls.Add(b_cus);
            Controls.Add(b_bar);
            Controls.Add(b_next);
            Controls.Add(b_logout);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "mainmenu1";
            Text = "mainmenu1";
            Load += mainmenu1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button b_logout;
        private Button b_next;
        private Button b_bar;
        private Button b_cus;
        private Button b_mer;
        private Button b_sto;
        private Button b_emp;
        private Button b_sal;
        private Button b_acc;
        private Label label_ename;
        private Label label_id;
    }
}