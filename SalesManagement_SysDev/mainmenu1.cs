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
        public mainmenu1()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {

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

        }
    }
}
