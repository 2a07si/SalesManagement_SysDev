﻿namespace SalesManagement_SysDev
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
            components = new System.ComponentModel.Container();
            labeltime = new Label();
            labeldate = new Label();
            label3 = new Label();
            label4 = new Label();
            b_logout = new Button();
            b_juchuu = new Button();
            b_hacchuu = new Button();
            b_masuta = new Button();
            label_ename = new Label();
            label_id = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labeltime
            // 
            labeltime.AutoSize = true;
            labeltime.Location = new Point(34, 17);
            labeltime.Name = "labeltime";
            labeltime.Size = new Size(80, 25);
            labeltime.TabIndex = 0;
            labeltime.Text = "11:11:11";
            // 
            // labeldate
            // 
            labeldate.AutoSize = true;
            labeldate.Location = new Point(34, 58);
            labeldate.Name = "labeldate";
            labeldate.Size = new Size(156, 25);
            labeldate.TabIndex = 1;
            labeldate.Text = "yyyy年mm月dd日";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1160, 17);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 2;
            label3.Text = "権限";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1160, 58);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 3;
            label4.Text = "社員名";
            // 
            // b_logout
            // 
            b_logout.Location = new Point(1417, 10);
            b_logout.Name = "b_logout";
            b_logout.Size = new Size(155, 56);
            b_logout.TabIndex = 21;
            b_logout.Text = "ログアウト";
            b_logout.UseVisualStyleBackColor = true;
            b_logout.Click += b_logout_Click;
            // 
            // b_juchuu
            // 
            b_juchuu.BackColor = Color.FromArgb(255, 255, 192);
            b_juchuu.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_juchuu.Location = new Point(268, 189);
            b_juchuu.Name = "b_juchuu";
            b_juchuu.Size = new Size(331, 493);
            b_juchuu.TabIndex = 23;
            b_juchuu.Text = "受注～売上";
            b_juchuu.UseVisualStyleBackColor = false;
            b_juchuu.Click += b_juchuu_Click;
            // 
            // b_hacchuu
            // 
            b_hacchuu.BackColor = Color.FromArgb(255, 255, 192);
            b_hacchuu.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_hacchuu.Location = new Point(605, 189);
            b_hacchuu.Name = "b_hacchuu";
            b_hacchuu.Size = new Size(331, 493);
            b_hacchuu.TabIndex = 24;
            b_hacchuu.Text = "発注～入庫";
            b_hacchuu.UseVisualStyleBackColor = false;
            b_hacchuu.Click += button2_Click;
            // 
            // b_masuta
            // 
            b_masuta.BackColor = Color.FromArgb(255, 255, 192);
            b_masuta.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_masuta.Location = new Point(942, 189);
            b_masuta.Name = "b_masuta";
            b_masuta.Size = new Size(331, 493);
            b_masuta.TabIndex = 25;
            b_masuta.Text = "マスタ管理";
            b_masuta.UseVisualStyleBackColor = false;
            b_masuta.Click += b_masuta_Click_1;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Location = new Point(1251, 59);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(59, 25);
            label_ename.TabIndex = 110;
            label_ename.Text = "label5";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(1251, 17);
            label_id.Name = "label_id";
            label_id.Size = new Size(110, 25);
            label_id.TabIndex = 109;
            label_id.Text = "label_empID";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // mainmenu1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1578, 844);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(b_masuta);
            Controls.Add(b_hacchuu);
            Controls.Add(b_juchuu);
            Controls.Add(b_logout);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labeldate);
            Controls.Add(labeltime);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "mainmenu1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "mainmenu1";
            Load += mainmenu1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labeltime;
        private Label labeldate;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button b_logout;
        private Button b_juchuu;
        private Button b_hacchuu;
        private Button b_masuta;
        private Label label_ename;
        private Label label_id;
        private System.Windows.Forms.Timer timer1;
    }
}