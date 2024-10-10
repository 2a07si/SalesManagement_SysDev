using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class lssue : Form
    {
        private Form mainForm;
        public lssue()
        {
            InitializeComponent();
            this.mainForm = new Form();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            label1.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            label2.Text = now.ToString("yyyy年MM月dd日");
        }

        private void close_Click(object sender, EventArgs e)
        {
            // メインフォームを再表示
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを閉じる
            this.Close();
        }

        private void b_acc_Click(object sender, EventArgs e)
        {
            acceptingorders acceptingorders = new acceptingorders(this);
            acceptingorders.Show();
            this.Close();
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            order order = new order();
            order.Show();
            this.Close();
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            arrival arrival = new arrival(this);
            arrival.Show();
            this.Close();
        }

        private void b_shi_Click(object sender, EventArgs e)
        {
            shipping shipping = new shipping(this);
            shipping.Show();
            this.Close();
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            sales sales = new sales();
            sales.Show();
            this.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {
        }
    }
}
