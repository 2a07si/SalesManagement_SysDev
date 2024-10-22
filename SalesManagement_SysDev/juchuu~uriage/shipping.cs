using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class shipping : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;

        // コンストラクターでmainFormを引数として受け取る 
        public shipping(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(shipping_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

        }

        private void shipping_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベルの初期化
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_acc,
                b_sal,
                b_lss
            });
        }
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移 
        }

        private void b_acc_Click(object sender, EventArgs e)
        {
            // 受注管理画面に遷移
            formChanger.NavigateToAcceptingOrderForm(); // acceptingorders フォームに遷移
        }

        // 注文管理画面に遷移 
        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移 
        }

        private void b_lss_Click_2(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm();//出庫管理画面に遷移
        }

        private void b_acc_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToAcceptingOrderForm(); // acceptingorders フォームに遷移
        }

        private void b_sal_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移 
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            // 登録ボタンの処理を追加 
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            // 更新ボタンの処理を追加 
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            // 検索ボタンの処理を追加 
        }

        private void b_flg_Click(object sender, EventArgs e)
        {
            // フラグボタンの処理を追加 
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            // 次へボタンの処理を追加 
        }

        private void b_logout_Click(object sender, EventArgs e)
        {
            // ログアウト処理を追加 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }


    }
}
