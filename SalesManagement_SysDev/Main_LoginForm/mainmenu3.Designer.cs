namespace SalesManagement_SysDev.Main_LoginForm
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
            b_iss = new Button();
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
            b_rank = new Button();
            listViewLog = new ListView();
            JU.SuspendLayout();
            mas.SuspendLayout();
            HN.SuspendLayout();
            SuspendLayout();
            // 
            // Loginkanri
            // 
            Loginkanri.Location = new Point(27, 118);
            Loginkanri.Name = "Loginkanri";
            Loginkanri.Size = new Size(129, 45);
            Loginkanri.TabIndex = 1000;
            Loginkanri.TabStop = false;
            Loginkanri.Text = "ログイン履歴";
            Loginkanri.UseVisualStyleBackColor = true;
            Loginkanri.Click += Loginkanri_Click;
            // 
            // label_ename
            // 
            label_ename.AutoSize = true;
            label_ename.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_ename.Location = new Point(97, 72);
            label_ename.Name = "label_ename";
            label_ename.Size = new Size(62, 25);
            label_ename.TabIndex = 131;
            label_ename.Text = "label5";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_id.Location = new Point(97, 37);
            label_id.Name = "label_id";
            label_id.Size = new Size(114, 25);
            label_id.TabIndex = 130;
            label_id.Text = "label_empID";
            // 
            // b_mas
            // 
            b_mas.BackColor = Color.FromArgb(178, 228, 210);
            b_mas.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_mas.Location = new Point(980, 136);
            b_mas.Name = "b_mas";
            b_mas.Size = new Size(400, 75);
            b_mas.TabIndex = 2;
            b_mas.Text = "マスタ管理";
            b_mas.UseVisualStyleBackColor = false;
            b_mas.Click += b_mas_Click;
            // 
            // JU
            // 
            JU.BackColor = Color.FromArgb(244, 226, 207);
            JU.Controls.Add(b_sal);
            JU.Controls.Add(b_iss);
            JU.Controls.Add(b_arr);
            JU.Controls.Add(b_shi);
            JU.Controls.Add(b_ord);
            JU.Controls.Add(b_add);
            JU.Location = new Point(180, 210);
            JU.Name = "JU";
            JU.Size = new Size(1200, 600);
            JU.TabIndex = 0;
            // 
            // b_sal
            // 
            b_sal.BackColor = SystemColors.ControlLightLight;
            b_sal.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_sal.Location = new Point(800, 330);
            b_sal.Name = "b_sal";
            b_sal.Size = new Size(250, 150);
            b_sal.TabIndex = 5;
            b_sal.Text = "売上管理";
            b_sal.UseVisualStyleBackColor = false;
            b_sal.Click += b_sal_Click;
            // 
            // b_iss
            // 
            b_iss.BackColor = SystemColors.ControlLightLight;
            b_iss.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_iss.Location = new Point(800, 120);
            b_iss.Name = "b_iss";
            b_iss.Size = new Size(250, 150);
            b_iss.TabIndex = 2;
            b_iss.Text = "出庫管理";
            b_iss.UseVisualStyleBackColor = false;
            b_iss.Click += b_iss_Click;
            b_iss.Paint += b_iss_Paint;
            // 
            // b_arr
            // 
            b_arr.BackColor = SystemColors.ControlLightLight;
            b_arr.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_arr.Location = new Point(150, 330);
            b_arr.Name = "b_arr";
            b_arr.Size = new Size(250, 150);
            b_arr.TabIndex = 3;
            b_arr.Text = "入荷管理";
            b_arr.UseVisualStyleBackColor = false;
            b_arr.Click += b_arr_Click;
            b_arr.Paint += b_arr_Paint;
            // 
            // b_shi
            // 
            b_shi.BackColor = SystemColors.ControlLightLight;
            b_shi.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_shi.Location = new Point(475, 330);
            b_shi.Name = "b_shi";
            b_shi.Size = new Size(250, 150);
            b_shi.TabIndex = 4;
            b_shi.Text = "出荷管理";
            b_shi.UseVisualStyleBackColor = false;
            b_shi.Click += b_shi_Click;
            b_shi.Paint += b_shi_Paint;
            // 
            // b_ord
            // 
            b_ord.BackColor = SystemColors.ControlLightLight;
            b_ord.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_ord.Location = new Point(475, 120);
            b_ord.Name = "b_ord";
            b_ord.Size = new Size(250, 150);
            b_ord.TabIndex = 1;
            b_ord.Text = "注文管理";
            b_ord.UseVisualStyleBackColor = false;
            b_ord.Click += b_ord_Click;
            b_ord.Paint += b_ord_Paint;
            // 
            // b_add
            // 
            b_add.BackColor = SystemColors.ControlLightLight;
            b_add.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_add.Location = new Point(150, 120);
            b_add.Name = "b_add";
            b_add.Size = new Size(250, 150);
            b_add.TabIndex = 0;
            b_add.Text = "受注管理";
            b_add.UseVisualStyleBackColor = false;
            b_add.Click += b_add_Click;
            b_add.Paint += b_add_Paint;
            // 
            // b_HN
            // 
            b_HN.BackColor = Color.FromArgb(212, 222, 255);
            b_HN.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_HN.Location = new Point(580, 136);
            b_HN.Name = "b_HN";
            b_HN.Size = new Size(400, 75);
            b_HN.TabIndex = 1;
            b_HN.Text = "発注～入庫";
            b_HN.UseVisualStyleBackColor = false;
            b_HN.Click += b_HN_Click;
            b_HN.Paint += b_HN_Paint;
            // 
            // b_JU
            // 
            b_JU.BackColor = Color.FromArgb(244, 226, 207);
            b_JU.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_JU.Location = new Point(180, 136);
            b_JU.Name = "b_JU";
            b_JU.Size = new Size(400, 75);
            b_JU.TabIndex = 0;
            b_JU.Text = "受注～売上";
            b_JU.UseVisualStyleBackColor = false;
            b_JU.Click += b_JU_Click;
            b_JU.Paint += b_JU_Paint;
            // 
            // b_logout
            // 
            b_logout.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            b_logout.Location = new Point(1397, 37);
            b_logout.Name = "b_logout";
            b_logout.Size = new Size(155, 56);
            b_logout.TabIndex = 999;
            b_logout.TabStop = false;
            b_logout.Text = "ログアウト(Esc)";
            b_logout.UseVisualStyleBackColor = true;
            b_logout.Click += b_logout_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(27, 72);
            label4.Name = "label4";
            label4.Size = new Size(66, 25);
            label4.TabIndex = 125;
            label4.Text = "社員名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(27, 37);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 124;
            label3.Text = "権限";
            // 
            // mas
            // 
            mas.BackColor = Color.FromArgb(178, 228, 210);
            mas.Controls.Add(b_sto);
            mas.Controls.Add(b_cus);
            mas.Controls.Add(b_mer);
            mas.Controls.Add(b_emp);
            mas.Location = new Point(180, 210);
            mas.Name = "mas";
            mas.Size = new Size(1200, 600);
            mas.TabIndex = 135;
            mas.Visible = false;
            // 
            // b_sto
            // 
            b_sto.BackColor = SystemColors.ControlLightLight;
            b_sto.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_sto.Location = new Point(280, 330);
            b_sto.Name = "b_sto";
            b_sto.Size = new Size(250, 150);
            b_sto.TabIndex = 2;
            b_sto.Text = "在庫管理";
            b_sto.UseVisualStyleBackColor = false;
            b_sto.Click += b_sto_Click;
            // 
            // b_cus
            // 
            b_cus.BackColor = SystemColors.ControlLightLight;
            b_cus.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_cus.Location = new Point(675, 330);
            b_cus.Name = "b_cus";
            b_cus.Size = new Size(250, 150);
            b_cus.TabIndex = 3;
            b_cus.Text = "顧客管理";
            b_cus.UseVisualStyleBackColor = false;
            b_cus.Click += b_cus_Click;
            // 
            // b_mer
            // 
            b_mer.BackColor = SystemColors.ControlLightLight;
            b_mer.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_mer.Location = new Point(675, 120);
            b_mer.Name = "b_mer";
            b_mer.Size = new Size(250, 150);
            b_mer.TabIndex = 1;
            b_mer.Text = "商品管理";
            b_mer.UseVisualStyleBackColor = false;
            b_mer.Click += b_mer_Click;
            // 
            // b_emp
            // 
            b_emp.BackColor = SystemColors.ControlLightLight;
            b_emp.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_emp.Location = new Point(275, 120);
            b_emp.Name = "b_emp";
            b_emp.Size = new Size(250, 150);
            b_emp.TabIndex = 0;
            b_emp.Text = "社員管理";
            b_emp.UseVisualStyleBackColor = false;
            b_emp.Click += b_emp_Click;
            // 
            // HN
            // 
            HN.BackColor = Color.FromArgb(212, 222, 255);
            HN.Controls.Add(b_rec);
            HN.Controls.Add(b_hor);
            HN.Location = new Point(180, 210);
            HN.Name = "HN";
            HN.Size = new Size(1200, 600);
            HN.TabIndex = 0;
            HN.Visible = false;
            // 
            // b_rec
            // 
            b_rec.BackColor = SystemColors.ControlLightLight;
            b_rec.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_rec.Location = new Point(675, 225);
            b_rec.Name = "b_rec";
            b_rec.Size = new Size(260, 150);
            b_rec.TabIndex = 1;
            b_rec.Text = "入庫管理";
            b_rec.UseVisualStyleBackColor = false;
            b_rec.Click += b_rec_Click;
            b_rec.Paint += b_rec_Paint;
            // 
            // b_hor
            // 
            b_hor.BackColor = SystemColors.ControlLightLight;
            b_hor.Font = new Font("Yu Gothic UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            b_hor.Location = new Point(275, 225);
            b_hor.Name = "b_hor";
            b_hor.Size = new Size(260, 150);
            b_hor.TabIndex = 0;
            b_hor.Text = "発注管理";
            b_hor.UseVisualStyleBackColor = false;
            b_hor.Click += b_hor_Click;
            b_hor.Paint += b_hor_Paint;
            // 
            // b_rank
            // 
            b_rank.Location = new Point(27, 180);
            b_rank.Name = "b_rank";
            b_rank.Size = new Size(129, 45);
            b_rank.TabIndex = 1001;
            b_rank.TabStop = false;
            b_rank.Text = "ランキング画面";
            b_rank.UseVisualStyleBackColor = true;
            b_rank.Click += b_rank_Click;
            // 
            // listViewLog
            // 
            listViewLog.Location = new Point(806, 23);
            listViewLog.Name = "listViewLog";
            listViewLog.Size = new Size(574, 96);
            listViewLog.TabIndex = 1002;
            listViewLog.UseCompatibleStateImageBehavior = false;
            // 
            // mainmenu3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = b_logout;
            ClientSize = new Size(1578, 844);
            Controls.Add(listViewLog);
            Controls.Add(b_rank);
            Controls.Add(Loginkanri);
            Controls.Add(label_ename);
            Controls.Add(label_id);
            Controls.Add(b_mas);
            Controls.Add(b_HN);
            Controls.Add(b_JU);
            Controls.Add(b_logout);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(JU);
            Controls.Add(mas);
            Controls.Add(HN);
            Name = "mainmenu3";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button b_iss;
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
        private Button b_rank;
        private ListView listViewLog;
    }
}