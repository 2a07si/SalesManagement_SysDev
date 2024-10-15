using System;
using System.Linq;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class mainmenu1 : Form
    {
        private ClassChangeForms changeForm;

        public mainmenu1()
        {
            InitializeComponent();
            this.Load += new EventHandler(mainmenu1_Load);
            timer1.Start();
            changeForm = new ClassChangeForms(this); // インスタンスを作成  
        }

        private void LoadEmployeeName()
        {
            using (var context = new SalesManagementContext())
            {
                // グローバル変数からEmployeeIDを取得し、該当する従業員を取得 
                var employee = context.MEmployees.SingleOrDefault(e => e.EmId == Global.EmployeeID); // EmployeeIDを直接比較 
                if (employee != null)
                {
                    label_id.Text = employee.EmName; // 従業員名をラベルに表示 
                }
            }
        }

        private void b_logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("ログアウトしてもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // グローバル変数のリセットメソッドが存在しない場合、代わりに値をリセット 
                Global.EmployeeID = 0; // または適切な初期値にリセット 
                Global.EmployeeName = string.Empty;
                Global.PositionName = string.Empty;

                this.Close();
                F_login loginForm = new F_login();
                loginForm.Show();
            }
        }

        private void mainmenu1_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベルを更新 
            LoadEmployeeName(); // 従業員名を読み込む 
        }

        private void b_juchuu_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToOrderForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeForm.NavigateTo(new horder());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            labeltime.Text = dateTime.ToLongTimeString();
            labeldate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        private void b_masuta_Click(object sender, EventArgs e)
        {
            changeForm.NavigateTo(new employee());
        }
    }
}
