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
    public partial class acceptingorders : Form
    {
        private Form mainForm;

        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            timer1.Start();
        }

        public acceptingorders()
        {
        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label_id_Click(object sender, EventArgs e)
        {
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            label1.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            label2.Text = now.ToString("yyyy年MM月dd日");
        }

        private void close_Click_1(object sender, EventArgs e)
        {
            // メインフォームを再表示
            mainForm.Opacity = 1.0;
            mainForm.TransparencyKey = Color.Empty; // 透明化を解除
            mainForm.Show();

            // 現在のフォームを閉じる
            this.Close();
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            order orderForm = new order();
            orderForm.ShowDialog();
            this.Close();
        }

        private void b_lss_Click(object sender, EventArgs e)
        {
            lssue lssueForm = new lssue();
            lssueForm.ShowDialog();
            this.Close();
        }


        private void b_arr_Click_1(object sender, EventArgs e)
        {
            arrival arrivalForm = new arrival(this);

            // arrival フォームを表示
            arrivalForm.Show();

            // 現在の acceptingorders フォームを閉じる
            this.Close();
        }

        private void b_shi_Click(object sender, EventArgs e)
        {
            shipping shippingForm = new shipping();
            shippingForm.ShowDialog();
            this.Close();
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            sales saleseForm = new sales();
            saleseForm.ShowDialog();
            this.Close();
        }

        private void b_ord_Click_1(object sender, EventArgs e)
        {
            order orderForm = new order();
            orderForm.ShowDialog();
            this.Close();
        }

        private void b_lss_Click_1(object sender, EventArgs e)
        {
            lssue lssue = new lssue();
            lssue.ShowDialog();
            this.Close();
        }
        private void b_arr_Click(object sender, EventArgs e)
        {
            arrival arrivalForm = new arrival(this);
            arrivalForm.ShowDialog();
            this.Close();
        }

        private void b_add_Click(object sender, EventArgs e)
        {

        }
    }
}
