﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class customer : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger;
        public customer()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(customer_Load);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            labeltime.Text = dateTime.ToLongTimeString();

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
            formChanger.NavigateEmployeeForm();   
        }

        private void b_mer_Click(object sender, EventArgs e)
        {
            formChanger.NavigateMerchandiseForm();
        }

        private void b_sto_Click(object sender, EventArgs e)
        {
            formChanger.NavigateStockForm();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
        }
    }
}
