﻿namespace SalesManagement_SysDev.Main_LoginForm
{
    partial class mainmenu3
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
            Loginkanri = new Button();
            label_ename = new Label();
            label_id = new Label();
            b_mas = new Button();
            JU = new Panel();
            b_sal = new Button();
            b_lss = new Button();
            b_arr = new Button();
            b_shi = new Button();
            b_ord = new Button();
            b_add = new Button();
            b_HN = new Button();
            b_JU = new Button();
            b_logout = new Button();
            label4 = new Label();
            label3 = new Label();
            mas = new Panel();
            b_sto = new Button();
            b_cus = new Button();
            b_mer = new Button();
            b_emp = new Button();
            HN = new Panel();
            b_rec = new Button();
            b_hor = new Button();
            JU.SuspendLayout();
            mas.SuspendLayout();
            HN.SuspendLayout();
            SuspendLayout();
            // 
            // Loginkanri
            // 
            Loginkanri.Location = new Point(27, 95);
            Loginkanri.Name = "Loginkanri";
            Loginkanri.Size = new Size(112, 34);
            Loginkanri.TabIndex = 132;
            Loginkanri.Text = "ログイン管理";
            Loginkanri.UseVisualStyleBackColor = true;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(97, 67);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 131;
            label_ename.Text = "label5";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(97, 37);
            label_id.Name = "label_id";
            label_id.Size = new Size(110, 25);
            label_id.TabIndex = 130;
            label_id.Text = "label_empID";
            // 
            // b_mas
            // 
            b_mas.BackColor = Color.FromArgb(128, 255, 128);
            b_mas.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_mas.Location = new Point(977, 132);
            b_mas.Name = "b_mas";
            b_mas.Size = new Size(400, 75);
            b_mas.TabIndex = 129;
            b_mas.Text = "マスタ管理";
            b_mas.UseVisualStyleBackColor = false;
            b_mas.Click += b_mas_Click;
            // 
            // JU
            // 
            JU.BackColor = Color.FromArgb(255, 224, 192);
            JU.Controls.Add(b_sal);
            JU.Controls.Add(b_lss);
            JU.Controls.Add(b_arr);
            JU.Controls.Add(b_shi);
            JU.Controls.Add(b_ord);
            JU.Controls.Add(b_add);
            JU.Location = new Point(177, 207);
            JU.Name = "JU";
            JU.Size = new Size(1200, 600);
            JU.TabIndex = 133;
            JU.Paint += JU_Paint;
            // 
            // b_sal
            // 
            b_sal.BackColor = SystemColors.ControlLightLight;
            b_sal.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.Location = new Point(850, 300);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(259, 164);
            b_sal.TabIndex = 47;
            b_sal.Text = "売上管理";
            b_sal.UseVisualStyleBackColor = false;
            // 
            // b_lss
            // 
            b_lss.BackColor = SystemColors.ControlLightLight;
            b_lss.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_lss.Location = new Point(850, 100);
            b_lss.Name = "b_lss";
            b_lss.Size = new Size(259, 164);
            b_lss.TabIndex = 46;
            b_lss.Text = "出庫管理";
            b_lss.UseVisualStyleBackColor = false;
            // 
            // b_arr
            // 
            b_arr.BackColor = SystemColors.ControlLightLight;
            b_arr.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.Location = new Point(100, 300);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(259, 164);
            b_arr.TabIndex = 45;
            b_arr.Text = "入荷管理";
            b_arr.UseVisualStyleBackColor = false;
            // 
            // b_shi
            // 
            b_shi.BackColor = SystemColors.ControlLightLight;
            b_shi.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.Location = new Point(475, 300);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(259, 164);
            b_shi.TabIndex = 44;
            b_shi.Text = "出荷管理";
            b_shi.UseVisualStyleBackColor = false;
            // 
            // b_ord
            // 
            b_ord.BackColor = SystemColors.ControlLightLight;
            b_ord.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.Location = new Point(475, 100);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(259, 164);
            b_ord.TabIndex = 42;
            b_ord.Text = "注文管理";
            b_ord.UseVisualStyleBackColor = false;
            b_ord.Click += b_ord_Click;
            // 
            // b_add
            // 
            b_add.BackColor = SystemColors.ControlLightLight;
            b_add.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_add.Location = new Point(100, 100);
            b_add.Name = "b_add";
            b_add.Size = new Size(259, 164);
            b_add.TabIndex = 41;
            b_add.Text = "受注管理";
            b_add.UseVisualStyleBackColor = false;
            b_add.Click += b_add_Click;
            // 
            // b_HN
            // 
            b_HN.BackColor = Color.FromArgb(128, 255, 255);
            b_HN.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_HN.Location = new Point(577, 132);
            b_HN.Name = "b_HN";
            b_HN.Size = new Size(400, 75);
            b_HN.TabIndex = 128;
            b_HN.Text = "発注～入庫";
            b_HN.UseVisualStyleBackColor = false;
            b_HN.Click += b_HN_Click;
            // 
            // b_JU
            // 
            b_JU.BackColor = Color.FromArgb(255, 192, 128);
            b_JU.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_JU.Location = new Point(177, 132);
            b_JU.Name = "b_JU";
            b_JU.Size = new Size(400, 75);
            b_JU.TabIndex = 127;
            b_JU.Text = "受注～売上";
            b_JU.UseVisualStyleBackColor = false;
            b_JU.Click += b_JU_Click;
            // 
            // b_logout
            // 
            b_logout.Location = new Point(1397, 37);
            b_logout.Name = "b_logout";
            b_logout.Size = new Size(155, 56);
            b_logout.TabIndex = 126;
            b_logout.Text = "ログアウト";
            b_logout.UseVisualStyleBackColor = true;
            b_logout.Click += b_logout_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 67);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 125;
            label4.Text = "社員名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 37);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 124;
            label3.Text = "権限";
            // 
            // mas
            // 
            mas.BackColor = Color.FromArgb(192, 255, 192);
            mas.Controls.Add(b_sto);
            mas.Controls.Add(b_cus);
            mas.Controls.Add(b_mer);
            mas.Controls.Add(b_emp);
            mas.Location = new Point(177, 207);
            mas.Name = "mas";
            mas.Size = new Size(1200, 600);
            mas.TabIndex = 135;
            mas.Visible = false;
            // 
            // b_sto
            // 
            b_sto.BackColor = SystemColors.ControlLightLight;
            b_sto.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.Location = new Point(270, 300);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(259, 164);
            b_sto.TabIndex = 44;
            b_sto.Text = "在庫管理";
            b_sto.UseVisualStyleBackColor = false;
            // 
            // b_cus
            // 
            b_cus.BackColor = SystemColors.ControlLightLight;
            b_cus.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.Location = new Point(680, 300);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(259, 164);
            b_cus.TabIndex = 43;
            b_cus.Text = "顧客管理";
            b_cus.UseVisualStyleBackColor = false;
            // 
            // b_mer
            // 
            b_mer.BackColor = SystemColors.ControlLightLight;
            b_mer.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.Location = new Point(680, 100);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(259, 164);
            b_mer.TabIndex = 42;
            b_mer.Text = "商品管理";
            b_mer.UseVisualStyleBackColor = false;
            // 
            // b_emp
            // 
            b_emp.BackColor = SystemColors.ControlLightLight;
            b_emp.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.Location = new Point(270, 100);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(259, 164);
            b_emp.TabIndex = 41;
            b_emp.Text = "社員管理";
            b_emp.UseVisualStyleBackColor = false;
            // 
            // HN
            // 
            HN.BackColor = Color.FromArgb(192, 255, 255);
            HN.Controls.Add(b_rec);
            HN.Controls.Add(b_hor);
            HN.Location = new Point(177, 207);
            HN.Name = "HN";
            HN.Size = new Size(1200, 600);
            HN.TabIndex = 134;
            HN.Visible = false;
            // 
            // b_rec
            // 
            b_rec.BackColor = SystemColors.ControlLightLight;
            b_rec.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_rec.Location = new Point(680, 200);
            b_rec.Name = "b_rec";
            b_rec.Size = new Size(259, 164);
            b_rec.TabIndex = 42;
            b_rec.Text = "入庫管理";
            b_rec.UseVisualStyleBackColor = false;
            // 
            // b_hor
            // 
            b_hor.BackColor = SystemColors.ControlLightLight;
            b_hor.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_hor.Location = new Point(270, 200);
            b_hor.Name = "b_hor";
            b_hor.Size = new Size(259, 164);
            b_hor.TabIndex = 41;
            b_hor.Text = "発注管理";
            b_hor.UseVisualStyleBackColor = false;
            b_hor.Click += b_hor_Click;
            // 
            // mainmenu3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(Loginkanri);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(b_mas);
            Controls.Add(b_HN);
            Controls.Add(b_JU);
            Controls.Add(b_logout);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(mas);

            Controls.Add(HN);
            Controls.Add(JU);
            Controls.Add(HN);
            Controls.Add(JU);
            Controls.Add(mas);
            Name = "mainmenu3";
            Text = "mainmenu";
            Load += mainmenu3_Load;
            JU.ResumeLayout(false);
            mas.ResumeLayout(false);
            HN.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Loginkanri;
        private Label label_ename;
        private Label label_id;
        private Button b_mas;
        private Panel JU;
        private Button b_sal;
        private Button b_lss;
        private Button b_arr;
        private Button b_shi;
        private Button b_ord;
        private Button b_add;
        private Button b_HN;
        private Button b_JU;
        private Button b_logout;
        private Label label4;
        private Label label3;
        private Panel mas;
        private Button b_sto;
        private Button b_cus;
        private Button b_mer;
        private Button b_emp;
        private Panel HN;
        private Button b_rec;
        private Button b_hor;
    }
}