using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class mainmenu3 : Form
    {
        private ClassChangeForms changeForm;
        private ClassAccessManager accessManager;
        public mainmenu3()
        {
            InitializeComponent();
            this.Load += new EventHandler(mainmenu3_Load);
            changeForm = new ClassChangeForms(this); // インスタンスを作成  
            accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
        }
        private void LoadEmployeeName()
        {
            using (var context = new SalesManagementContext())
            {
                // グローバル変数からEmployeeIDを取得し、該当する従業員を取得  
                var employee = context.MEmployees
                    .Include(e => e.Po) // 職位情報を含めて取得
                    .SingleOrDefault(e => e.EmId == Global.EmployeeID); // EmployeeIDを直接比較  

                if (employee != null)
                {
                    label_id.Text = employee.Po.PoName; // 職位名をラベルに表示  
                }
                else
                {
                    label_id.Text = "未登録"; // もし従業員が見つからなかった場合のフォールバック
                }
            }
        }
        private void b_logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("ログアウトしてもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // グローバル変数のリセット
                Global.EmployeeID = 0; // または適切な初期値にリセット 
                Global.EmployeeName = string.Empty;
                Global.PositionName = string.Empty;

                this.Close();
                F_login loginForm = new F_login();
                loginForm.Show();
            }
        }
        private void mainmenu3_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベルを更新 
            LoadEmployeeName(); // 従業員名を読み込む 

            SetButtonPermissions();//buttonけしシステム
        }
        private void b_JU_Click(object sender, EventArgs e)
        {
            HN.Visible = false;
            mas.Visible = false;
            JU.Visible = true;
        }

        private void b_HN_Click(object sender, EventArgs e)
        {
            JU.Visible = false;
            mas.Visible = false;
            HN.Visible = true;
        }

        private void b_mas_Click(object sender, EventArgs e)
        {
            HN.Visible = false;
            JU.Visible = false;
            mas.Visible = true;
        }


        private void SetButtonPermissions()
        {
            // ボタンをリスト化
            List<Button> buttons = new List<Button>
    {
        b_hor, b_rec, b_cus, b_mer, b_sto, b_emp,
        b_add, b_ord, b_lss, b_arr, b_shi, b_sal,
        b_JU,b_HN,b_mas,Loginkanri
    };
            List<Button> allowedButtons = new List<Button>();
            // ボタンの権限に応じて有効・無効を設定
            switch (Global.EmployeePermission)
            {


                case 2: // 営業 (フラグ2): b_cus, b_emp, b_add, b_ord, b_shi, b_sal のみ有効
                    foreach (var button in buttons)
                        button.Enabled = new[] { b_cus, b_add, b_arr, b_ord, b_shi, b_sal, b_JU, b_mas }.Contains(button);
                    break;

                case 3:
                    // 物流 (フラグ3): b_rec, b_cus, b_ord, b_hor, b_add のみ有効
                    foreach (var button in buttons)
                        button.Enabled = new[] { b_mer, b_sto, b_rec, b_lss, b_hor, b_JU, b_HN, b_mas }.Contains(button);
                    break;

                case 1: // 管理者 (フラグ1): すべてのボタンを有効
                    foreach (var button in buttons)
                        button.Enabled = true;
                    break;
                default:
                    // 無効にするなど、その他の処理があれば追加
                    break;
            }
            foreach (var button in buttons)
            {
                if (allowedButtons.Contains(button))
                {
                    button.Enabled = true;
                    button.BackColor = SystemColors.Control; // デフォルトの背景色
                }
                else
                {
                    button.Enabled = false;
                    button.BackColor = Color.DarkGray; // 入れないボタンの色を濃い灰色に
                }
            }
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToAcceptingOrderForm();
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToOrderForm();
        }


        private void b_lss_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToIssueForm();
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToArrivalForm();
        }

        private void b_shi_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToShippingForm();
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToSalesForm();
        }

        private void b_emp_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToEmployeeForm();
        }

        private void b_mer_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToMerchandiseForm();
        }

        private void b_sto_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToStockForm();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToCustomerForm();
        }

        private void b_hor_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToHorderForm();
        }

        private void b_rec_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToReceivingstockForm();
        }

        private void JU_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
