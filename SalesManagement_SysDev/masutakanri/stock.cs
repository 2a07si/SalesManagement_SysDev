using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;

namespace SalesManagement_SysDev
{
    public partial class stock : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger;
        public stock()
        {
            InitializeComponent();
            this.mainForm = new Form();
            timer1.Start();
        }

        private void button14_Click(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            labeltime.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            labeldate.Text = now.ToString("yyyy年MM月dd日");
        }

        private void close_Click(object sender, EventArgs e)
        {
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを閉じる
            this.Close();
        }

        private void b_emp_Click(object sender, EventArgs e)
        {
            formChanger.NavigateEmployeeForm();
        }

        private void b_mer_Click(object sender, EventArgs e)
        {
            formChanger.NavigateMerchandiseForm();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            formChanger.NavigateCustomerForm();
        }
    }
}
