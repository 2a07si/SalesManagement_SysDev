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
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class merchandise : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger;
        private ClassDateNamelabel dateNamelabel;
        private ClassTimerManager timerManager;
        public merchandise()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(merchandise_Load);
            this.dateNamelabel = new ClassDateNamelabel(labeltime,labeldate,label_id,label_ename);
            this.timerManager = new ClassTimerManager(timer1,labeltime,labeldate);
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void b_sto_Click(object sender, EventArgs e)
        {
            formChanger.NavigateStockForm();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            formChanger.NavigateCustomerForm();  
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void merchandise_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            dateNamelabel.UpdateDateTime();
        }
    }
}
