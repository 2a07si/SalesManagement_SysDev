// sales.cs
using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;


namespace SalesManagement_SysDev
{
    public partial class sales : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;
        public sales()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //  this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(sales_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

        }

        private void sales_Load(object sender, EventArgs e)
        {
            labelStatus.labelstatus(label2, b_kakutei);

            GlobalUtility.UpdateLabels(label_id, label_ename);
            // timerManager.UpdateDateTime(); // この行を削除またはコメントアウト 
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_shi,
                b_acc,
                b_lss
            });
        }

        // メインメニューに戻る 
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移 
        }

        // 受注管理画面に遷移 
        private void b_acc_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToAcceptingOrderForm(); // 受注管理画面に遷移 
        }

        // 注文管理画面に遷移 
        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
        }

        // 発注書発行画面に遷移 
        private void b_lss_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm(); // 発注書発行画面に遷移 
        }

        // 入荷管理画面に遷移 
        private void b_arr_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移 
        }

        // 出荷管理画面に遷移 
        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm(); // 出荷管理画面に遷移 
        }

        private void b_flg_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kakutei_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            currentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            currentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            currentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            currentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }
        private void cleartext()
        {
            TBSalesID.Text = "";
            TBKokyakuID.Text = "";
            TBShopID.Text = "";
            TBShainID.Text = "";
            TBJyutyuID.Text = "";
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBUriageSyosaiID.Text = "";
            TBUriageIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            date.Value = DateTime.Now;
        }
    }
}
