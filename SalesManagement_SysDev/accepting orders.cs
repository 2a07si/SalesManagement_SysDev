using System;
using System.Windows.Forms;
using static SalesManagement_SysDev.Class1;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        private ClassChangeForms formChanger;

        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.Load += new EventHandler(acceptingorders_Load);
            timer1.Start();
        }

        public acceptingorders()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            label1.Text = dateTime.ToLongTimeString();

            var now = DateTime.Now;
            label2.Text = now.ToString("yyyy年MM月dd日");
        }

        // メインメニューに戻る
        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu();
        }

        // 受注管理画面に遷移
        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm();
        }

        // 発注書発行画面に遷移
        private void b_lss_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm();
        }

        // 入荷管理画面に遷移
        private void b_arr_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm();
        }

        // 出荷管理画面に遷移
        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm();
        }

        // 売上管理画面に遷移
        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm();
        }

        // 他のクリックイベントも同様に簡潔化
        private void b_ord_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm();
        }

        private void b_lss_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm();
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm();
        }

        private void b_ord_Click_2(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm();
        }
    }
}
