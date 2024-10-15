using System;
using System.Linq;
using System.Windows.Forms;
using static SalesManagement_SysDev.labelChange;

namespace SalesManagement_SysDev
{
    public partial class mainmenu1 : Form
    {
        private acceptingorders acceptingOrdersForm;

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
            var result = MessageBox.Show("ログアウトしてもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Global.Reset();
                this.Close();
                new F_login().Show(); // ログインフォームを開く
            }
        }

        private void mainmenu1_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            LoadEmployeeName(); // 社員名を読み込む
        }

        private void OpenForm(Form form)
        {
            this.TransparencyKey = this.BackColor;
            this.Opacity = 0.5; // 半透明に設定
            form.Show();
            this.Hide();
        }

        private void b_juchuu_Click(object sender, EventArgs e)
        {
            if (acceptingOrdersForm == null || acceptingOrdersForm.IsDisposed)
            {
                acceptingOrdersForm = new acceptingorders(this);
            }
            OpenForm(acceptingOrdersForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new horder());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labeltime.Text = DateTime.Now.ToLongTimeString();
            labeldate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        private void b_masuta_Click(object sender, EventArgs e)
        {
            OpenForm(new employee());
        }
    }
}
