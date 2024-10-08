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

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        private void b_logout_Click(object sender, EventArgs e)
        {
            // 現在のフォームを閉じる
        this.Close();

            // ログインフォームを開く
            F_login loginForm = new F_login();
            loginForm.Show();
        }
<<<<<<< Updated upstream
=======

        private void mainmenu1_Load(object sender, EventArgs e)
        {

        }
>>>>>>> Stashed changes
    }
}
