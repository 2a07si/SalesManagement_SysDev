﻿using System;
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
    public partial class stock : Form
    {
        private Form mainForm;
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
            label1.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            label2.Text = now.ToString("yyyy年MM月dd日");
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
            employee employee = new employee();
            employee.Show();
            this.Close();
        }

        private void b_mer_Click(object sender, EventArgs e)
        {
            merchandise merchandise = new merchandise();
            merchandise.Show();
            this.Close();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.Show();
            this.Close();
        }
    }
}
