﻿namespace SalesManagement_SysDev
{
    partial class F_login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btn_CleateDabase = new Button();
            btn_InsertSampleData = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tb_ID = new TextBox();
            B_login = new Button();
            label5 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            tb_Pass = new TextBox();
            SuspendLayout();
            // 
            // btn_CleateDabase
            // 
            btn_CleateDabase.Location = new Point(1102, 665);
            btn_CleateDabase.Margin = new Padding(5, 6, 5, 6);
            btn_CleateDabase.Name = "btn_CleateDabase";
            btn_CleateDabase.Size = new Size(177, 102);
            btn_CleateDabase.TabIndex = 0;
            btn_CleateDabase.Text = "データベース生成";
            btn_CleateDabase.UseVisualStyleBackColor = true;
            btn_CleateDabase.Click += btn_CleateDabase_Click;
            // 
            // btn_InsertSampleData
            // 
            btn_InsertSampleData.AutoSize = true;
            btn_InsertSampleData.Location = new Point(1102, 810);
            btn_InsertSampleData.Margin = new Padding(5, 6, 5, 6);
            btn_InsertSampleData.Name = "btn_InsertSampleData";
            btn_InsertSampleData.Size = new Size(177, 102);
            btn_InsertSampleData.TabIndex = 0;
            btn_InsertSampleData.Text = "サンプルデータ登録";
            btn_InsertSampleData.UseVisualStyleBackColor = true;
            btn_InsertSampleData.Click += btn_InsertSampleData_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(259, 279);
            label2.Name = "label2";
            label2.Size = new Size(158, 60);
            label2.TabIndex = 2;
            label2.Text = "社員ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(259, 461);
            label3.Name = "label3";
            label3.Size = new Size(190, 60);
            label3.TabIndex = 3;
            label3.Text = "パスワード";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(488, 100);
            label4.Name = "label4";
            label4.Size = new Size(397, 96);
            label4.TabIndex = 4;
            label4.Text = "ログイン画面";
            label4.Click += label4_Click;
            // 
            // tb_ID
            // 
            tb_ID.BackColor = Color.FromArgb(255, 255, 192);
            tb_ID.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            tb_ID.Location = new Point(567, 287);
            tb_ID.Multiline = true;
            tb_ID.Name = "tb_ID";
            tb_ID.Size = new Size(229, 50);
            tb_ID.TabIndex = 5;
            // 
            // B_login
            // 
            B_login.BackColor = Color.Navy;
            B_login.Font = new Font("Yu Gothic UI", 26F, FontStyle.Bold, GraphicsUnit.Point);
            B_login.ForeColor = Color.White;
            B_login.Location = new Point(929, 431);
            B_login.Name = "B_login";
            B_login.Size = new Size(203, 90);
            B_login.TabIndex = 7;
            B_login.Text = "ログイン";
            B_login.UseVisualStyleBackColor = false;
            B_login.Click += B_login_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(929, 341);
            label5.Name = "label5";
            label5.Size = new Size(205, 62);
            label5.TabIndex = 8;
            label5.Text = "22:22:22";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(917, 279);
            label6.Name = "label6";
            label6.Size = new Size(173, 38);
            label6.TabIndex = 9;
            label6.Text = "YYYYMMDD";
            label6.Click += label6_Click;
            // 
            // tb_Pass
            // 
            tb_Pass.BackColor = Color.FromArgb(255, 255, 192);
            tb_Pass.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            tb_Pass.Location = new Point(567, 471);
            tb_Pass.Multiline = true;
            tb_Pass.Name = "tb_Pass";
            tb_Pass.Size = new Size(229, 50);
            tb_Pass.TabIndex = 6;
            // 
            // F_login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 937);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(B_login);
            Controls.Add(tb_Pass);
            Controls.Add(tb_ID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btn_InsertSampleData);
            Controls.Add(btn_CleateDabase);
            Margin = new Padding(5, 6, 5, 6);
            Name = "F_login";
            Text = "販売管理システムログイン画面";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_CleateDabase;
        private System.Windows.Forms.Button btn_InsertSampleData;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tb_ID;
        private Button B_login;
        private Label label5;
        private System.Windows.Forms.Timer timer1;
        private Label label6;
        private TextBox tb_Pass;
    }
}
