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
            labeltime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            tb_Pass = new TextBox();
            labeldate = new Label();
            b_pwHyouji = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            passwordchange = new Button();
            SuspendLayout();
            // 
            // btn_CleateDabase
            // 
            btn_CleateDabase.Location = new Point(1337, 562);
            btn_CleateDabase.Margin = new Padding(5, 6, 5, 6);
            btn_CleateDabase.Name = "btn_CleateDabase";
            btn_CleateDabase.Size = new Size(177, 102);
            btn_CleateDabase.TabIndex = 0;
            btn_CleateDabase.Text = "データベース生成";
            btn_CleateDabase.TextImageRelation = TextImageRelation.TextAboveImage;
            btn_CleateDabase.UseVisualStyleBackColor = true;
            btn_CleateDabase.Visible = false;
            btn_CleateDabase.Click += btn_CleateDabase_Click;
            // 
            // btn_InsertSampleData
            // 
            btn_InsertSampleData.AutoSize = true;
            btn_InsertSampleData.Location = new Point(1337, 698);
            btn_InsertSampleData.Margin = new Padding(5, 6, 5, 6);
            btn_InsertSampleData.Name = "btn_InsertSampleData";
            btn_InsertSampleData.Size = new Size(177, 102);
            btn_InsertSampleData.TabIndex = 0;
            btn_InsertSampleData.Text = "サンプルデータ登録";
            btn_InsertSampleData.UseVisualStyleBackColor = true;
            btn_InsertSampleData.Visible = false;
            btn_InsertSampleData.Click += btn_InsertSampleData_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(405, 337);
            label2.Name = "label2";
            label2.Size = new Size(158, 60);
            label2.TabIndex = 1;
            label2.Text = "社員ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(405, 519);
            label3.Name = "label3";
            label3.Size = new Size(190, 60);
            label3.TabIndex = 2;
            label3.Text = "パスワード";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(597, 158);
            label4.Name = "label4";
            label4.Size = new Size(397, 96);
            label4.TabIndex = 0;
            label4.Text = "ログイン画面";
            // 
            // tb_ID
            // 
            tb_ID.BackColor = Color.FromArgb(252, 252, 192);
            tb_ID.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            tb_ID.Location = new Point(676, 339);
            tb_ID.Name = "tb_ID";
            tb_ID.Size = new Size(250, 45);
            tb_ID.TabIndex = 5;
            // 
            // B_login
            // 
            B_login.BackColor = Color.FromArgb(244, 226, 207);
            B_login.Font = new Font("Yu Gothic UI", 26F, FontStyle.Bold, GraphicsUnit.Point);
            B_login.ForeColor = Color.Black;
            B_login.Location = new Point(1032, 491);
            B_login.Name = "B_login";
            B_login.Size = new Size(203, 90);
            B_login.TabIndex = 7;
            B_login.Text = "ログイン";
            B_login.UseVisualStyleBackColor = false;
            B_login.Click += B_login_Click;
            // 
            // labeltime
            // 
            labeltime.AutoSize = true;
            labeltime.Font = new Font("Yu Gothic UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            labeltime.Location = new Point(1032, 410);
            labeltime.Name = "labeltime";
            labeltime.Size = new Size(142, 62);
            labeltime.TabIndex = 4;
            labeltime.Text = "22:22";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // tb_Pass
            // 
            tb_Pass.BackColor = Color.FromArgb(252, 252, 192);
            tb_Pass.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            tb_Pass.Location = new Point(676, 523);
            tb_Pass.Name = "tb_Pass";
            tb_Pass.PasswordChar = '●';
            tb_Pass.Size = new Size(250, 45);
            tb_Pass.TabIndex = 6;
            tb_Pass.UseSystemPasswordChar = true;
            // 
            // labeldate
            // 
            labeldate.AutoSize = true;
            labeldate.Font = new Font("Yu Gothic UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            labeldate.Location = new Point(1038, 355);
            labeldate.Name = "labeldate";
            labeldate.Size = new Size(276, 41);
            labeldate.TabIndex = 3;
            labeldate.Text = "YYYY年MM月DD日";
            // 
            // b_pwHyouji
            // 
            b_pwHyouji.Location = new Point(875, 527);
            b_pwHyouji.Name = "b_pwHyouji";
            b_pwHyouji.Size = new Size(40, 40);
            b_pwHyouji.TabIndex = 8;
            b_pwHyouji.Text = "閉";
            b_pwHyouji.UseVisualStyleBackColor = true;
            b_pwHyouji.Click += b_pwHyouji_Click;
            // 
            // button1
            // 
            button1.Location = new Point(811, 735);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 11;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(970, 735);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 12;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            // 
            // button3
            // 
            button3.Location = new Point(1123, 735);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 13;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            // 
            // passwordchange
            // 
            passwordchange.Location = new Point(12, 12);
            passwordchange.Name = "passwordchange";
            passwordchange.Size = new Size(173, 48);
            passwordchange.TabIndex = 14;
            passwordchange.Text = "パスワード変更";
            passwordchange.UseVisualStyleBackColor = true;
            passwordchange.Click += passwordchange_Click;
            // 
            // F_login
            // 
            AcceptButton = B_login;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 844);
            Controls.Add(passwordchange);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(b_pwHyouji);
            Controls.Add(labeldate);
            Controls.Add(labeltime);
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
            StartPosition = FormStartPosition.CenterScreen;
            Text = "販売管理システムログイン画面";
            Load += F_login_Load;
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
        private Label labeltime;
        private System.Windows.Forms.Timer timer1;
        private TextBox tb_Pass;
        private Label labeldate;
        private Button b_pwHyouji;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button passwordchange;
    }
}
