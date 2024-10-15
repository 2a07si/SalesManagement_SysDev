﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class employee : Form
    {
        private Form mainForm;
        public employee()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(employee_Load);
            timer1.Start();
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

        private void b_mer_Click(object sender, EventArgs e)
        {
            merchandise merchandise = new merchandise();
            merchandise.Show();
            this.Close();
        }

        private void b_sto_Click(object sender, EventArgs e)
        {
            stock stock = new stock();
            stock.Show();
            this.Close();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.Show();
            this.Close();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
        }
    }
}
