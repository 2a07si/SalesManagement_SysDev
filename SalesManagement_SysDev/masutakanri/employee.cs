﻿using System;
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
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;

namespace SalesManagement_SysDev
{
    public partial class employee : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger;
        ///private ClassDateNamelabel dateNamelabel;
        private ClassTimerManager timerManager;
        private ClassAccessManager accessManager;
        public employee()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(employee_Load);
            //this.dateNamelabel = new ClassDateNamelabel(labeltime,labeldate,label_id,label_ename);
            //this.timerManager = new ClassTimerManager(timer1,labeltime,labeldate);
            timer1.Start();
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
            this.formChanger = new ClassChangeForms(this);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* DateTime dateTime = DateTime.Now;
             labeltime.Text = dateTime.ToLongTimeString();

             var now = System.DateTime.Now;
             labeldate.Text = now.ToString("yyyy年MM月dd日");*/
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
            formChanger.NavigateMerchandiseForm();
        }

        private void b_sto_Click(object sender, EventArgs e)
        {
            formChanger.NavigateStockForm();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            formChanger.NavigateCustomerForm();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_cus,
                b_mer,
                b_sto,
            });
        }

        private void clear_Click(object sender, EventArgs e)
        {

        }

        private void cleartext()
        {
            TBSyainID.Text = "";
            TBSyainName.Text = "";
            TBShopId.Text = "";
            TBJobID.Text = "";
            TBTellNo.Text = "";
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            CurrentStatus.ResetStatus(label2);
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }
    }
}
