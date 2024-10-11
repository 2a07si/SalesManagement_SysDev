using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SalesManagement_SysDev.F_login;

namespace SalesManagement_SysDev
{
    public partial class mainmenu1 : Form
    {
        private acceptingorders acceptingOrdersForm;
        private shipping shippingForm;

        public mainmenu1()
        {
            InitializeComponent();
            this.Load += new EventHandler(mainmenu1_Load);
            timer1.Start();
        }

        private void LoadEmployeeName()
        {
            using (var context = new SalesManagementContext())
            {
                var employee = context.MEmployees.SingleOrDefault(e => e.EmId == Global.EmployeeID);
                if (employee != null)
                {
                    label_id.Text = employee.EmName;
                }
            }
        }

        private void b_logout_Click(object sender, EventArgs e)
        {
            // 確認ダイアログを表示
            var result = MessageBox.Show("ログアウトしてもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // グローバル変数を初期化
                Global.Reset();

                // 現在のフォームを閉じる
                this.Close();

                // ログインフォームを開く
                F_login loginForm = new F_login();
                loginForm.Show();
            }
        }

        private void mainmenu1_Load(object sender, EventArgs e)
        {
            // グローバル変数から権限名（PoName）を取得してラベルに表示
            label_id.Text = Global.PositionName; // 権限名を表示
            label_ename.Text = Global.EmployeeName;        // 社員名を表示
        }

        private void b_juchuu_Click(object sender, EventArgs e)
        {
            if (acceptingOrdersForm == null || acceptingOrdersForm.IsDisposed)
            {
                acceptingOrdersForm = new acceptingorders(this);
            }

            // 現在のフォームを透明化
            this.TransparencyKey = this.BackColor;
            this.Opacity = 0.5; // 半透明に設定

            // 新しいフォームを表示
            acceptingOrdersForm.Show();

            // 現在のフォームを非表示にする
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 現在のフォームを透明化
            this.TransparencyKey = this.BackColor;
            this.Opacity = 0.5; // 半透明に設定

            // 新しいフォームを表示
            horder newForm1 = new horder();
            newForm1.Show();

            // 現在のフォームを非表示にする
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            label1.Text = dateTime.ToLongTimeString();
        }

        private void b_masuta_Click(object sender, EventArgs e)
        {
            // 現在のフォームを透明化
            this.TransparencyKey = this.BackColor;
            this.Opacity = 0.5; // 半透明に設定

            // 新しいフォームを表示
            employee newForm2 = new employee();
            newForm2.Show();

            // 現在のフォームを非表示にする
            this.Hide();
            var now = System.DateTime.Now;
            label2.Text = now.ToString("yyyy年MM月dd日");
        }
    }
}
