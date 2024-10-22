using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager; // 権限管理クラス 

        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);

            // ボタンアクセス制御を設定
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_shi,
                b_sal,
                b_lss
            });
        }

        // メインメニューに戻る 
        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移 
        }

        // 注文管理画面に遷移 
        private void b_ord_Click_2(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
        }

        // 入荷管理画面に遷移 
        private void b_arr_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移 
        }

        // 出荷管理画面に遷移 
        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm(); // 出荷管理画面に遷移 
        }

        // 売上管理画面に遷移 
        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移 
        }

        // 出庫管理画面に遷移

        private void b_lss_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm(); // 出庫管理画面に遷移
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void b_reg_Click(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void b_ser_Click(object sender, EventArgs e)
        {

        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
        }

        private void b_upd_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void B_iti_Click(object sender, EventArgs e)
        {

        }
    }
}
