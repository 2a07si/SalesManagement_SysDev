// lssue.cs
using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;


namespace SalesManagement_SysDev
{
    public partial class lssue : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;

        public lssue()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(lssue_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

        }

        private void lssue_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            // timerManager.UpdateDateTime(); // この行を削除またはコメントアウト 
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_shi,
                b_sal,
                b_acc
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

        // 注文管理画面に遷移 
        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
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

        private void clear_Click_1(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBSyukkoID.Text = "";
            TBShainId.Text = "";
            TBKokyakuId.Text = "";
            TBShopId.Text = "";
            TBJyutyu.Text = "";
            SyukkoFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBSyukkoSyosaiID.Text = "";
            TBSyukkoIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
        }
    }
}
