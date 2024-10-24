using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;


namespace SalesManagement_SysDev
{
    public partial class order : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;
        public order()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            // this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(order_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

        }

        private void order_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            // timerManager.UpdateDateTime(); // 削除またはコメントアウト
            accessManager.SetButtonAccess(new Control[] {
                b_acc,
                b_arr,
                b_shi,
                b_sal,
                b_lss
            });
            labelStatus.labelstatus(label2, b_kakutei);
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

        // 売上管理画面に遷移 
        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移 
        }

        private void clear_Click(object sender, EventArgs e)
        {
            // クリア機能の実装 
            cleartext();
        }

        private void label_ename_Click(object sender, EventArgs e)
        {

        }


        private void b_reg_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            CurrentStatus.RegistrationStatus(label2);
=======
            currentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
>>>>>>> 6a1b639335110a2011b32b2ee8e14bb94ff21d06

        }

        private void b_upd_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            CurrentStatus.UpDateStatus(label2);
=======
            currentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
>>>>>>> 6a1b639335110a2011b32b2ee8e14bb94ff21d06

        }

        private void B_iti_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            CurrentStatus.ListStatus(label2);
=======
            currentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
>>>>>>> 6a1b639335110a2011b32b2ee8e14bb94ff21d06

        }

        private void b_ser_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            CurrentStatus.SearchStatus(label2);
=======
            currentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
>>>>>>> 6a1b639335110a2011b32b2ee8e14bb94ff21d06

        }
        private void cleartext()
        {
            TBTyumonID.Text = "";
            TBShopId.Text = "";
            TBShainId.Text = "";
            TBKokyakuId.Text = "";
            TBJyutyuID.Text = "";
            TyumonFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBTyumonSyosaiID.Text = "";
            TBTyumonIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            date.Value = DateTime.Now;
        }
    }
}
