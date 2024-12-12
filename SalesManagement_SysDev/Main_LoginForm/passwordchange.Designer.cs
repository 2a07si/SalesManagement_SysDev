using Microsoft.VisualBasic.ApplicationServices;

namespace SalesManagement_SysDev.Main_LoginForm
{
    partial class passwordchange
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
            TBID = new TextBox();
            TBold = new TextBox();
            TBnew = new TextBox();
            user = new Label();
            old = new Label();
            ne = new Label();
            kakutei = new Button();
            label1 = new Label();
            B_return = new Button();
            b_pwHyouji = new Button();
            b_newHyouji = new Button();
            SuspendLayout();
            // 
            // TBID
            // 
            TBID.Location = new Point(495, 196);
            TBID.Name = "TBID";
            TBID.Size = new Size(200, 31);
            TBID.TabIndex = 0;
            // 
            // TBold
            // 
            TBold.Location = new Point(495, 296);
            TBold.Name = "TBold";
            TBold.PasswordChar = '●';
            TBold.Size = new Size(200, 31);
            TBold.TabIndex = 1;
            // 
            // TBnew
            // 
            TBnew.Location = new Point(495, 396);
            TBnew.Name = "TBnew";
            TBnew.PasswordChar = '●';
            TBnew.Size = new Size(200, 31);
            TBnew.TabIndex = 2;
            // 
            // user
            // 
            user.AutoSize = true;
            user.Location = new Point(406, 202);
            user.Name = "user";
            user.Size = new Size(66, 25);
            user.TabIndex = 1;
            user.Text = "社員ID";
            // 
            // old
            // 
            old.AutoSize = true;
            old.Location = new Point(390, 299);
            old.Name = "old";
            old.Size = new Size(97, 25);
            old.TabIndex = 1;
            old.Text = "現パスワード";
            // 
            // ne
            // 
            ne.AutoSize = true;
            ne.Location = new Point(390, 399);
            ne.Name = "ne";
            ne.Size = new Size(97, 25);
            ne.TabIndex = 1;
            ne.Text = "新パスワード";
            // 
            // kakutei
            // 
            kakutei.BackColor = Color.FromArgb(255, 192, 192);
            kakutei.Font = new Font("Yu Gothic UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point);
            kakutei.Location = new Point(520, 476);
            kakutei.Name = "kakutei";
            kakutei.Size = new Size(150, 70);
            kakutei.TabIndex = 3;
            kakutei.Text = "確定";
            kakutei.UseVisualStyleBackColor = false;
            kakutei.Click += kakutei_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(540, 106);
            label1.Name = "label1";
            label1.Size = new Size(115, 25);
            label1.TabIndex = 1;
            label1.Text = "パスワード変更";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // B_return
            // 
            B_return.Location = new Point(1037, 26);
            B_return.Name = "B_return";
            B_return.Size = new Size(112, 34);
            B_return.TabIndex = 4;
            B_return.Text = "閉じる";
            B_return.UseVisualStyleBackColor = true;
            B_return.Click += B_return_Click;
            // 
            // b_pwHyouji
            // 
            b_pwHyouji.Location = new Point(690, 293);
            b_pwHyouji.Name = "b_pwHyouji";
            b_pwHyouji.Size = new Size(35, 35);
            b_pwHyouji.TabIndex = 9;
            b_pwHyouji.Text = "閉";
            b_pwHyouji.UseVisualStyleBackColor = true;
            b_pwHyouji.Click += b_pwHyouji_Click;
            // 
            // b_newHyouji
            // 
            b_newHyouji.Location = new Point(690, 394);
            b_newHyouji.Name = "b_newHyouji";
            b_newHyouji.Size = new Size(35, 35);
            b_newHyouji.TabIndex = 10;
            b_newHyouji.Text = "閉";
            b_newHyouji.UseVisualStyleBackColor = true;
            b_newHyouji.Click += b_newHyouji_Click;
            // 
            // passwordchange
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 644);
            Controls.Add(b_newHyouji);
            Controls.Add(b_pwHyouji);
            Controls.Add(B_return);
            Controls.Add(kakutei);
            Controls.Add(ne);
            Controls.Add(old);
            Controls.Add(label1);
            Controls.Add(user);
            Controls.Add(TBnew);
            Controls.Add(TBold);
            Controls.Add(TBID);
            Name = "passwordchange";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "passwordchange";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TBID;
        private TextBox TBold;
        private TextBox TBnew;
        private Label user;
        private Label old;
        private Label ne;
        private Button kakutei;
        private Label label1;
        private Button B_return;
        private Button b_pwHyouji;
        private Button b_newHyouji;
    }
}