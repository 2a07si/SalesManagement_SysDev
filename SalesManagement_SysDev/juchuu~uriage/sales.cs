using System;
using System.Windows.Forms;
using static SalesManagement_SysDev.labelChange;

namespace SalesManagement_SysDev
{
    public partial class sales : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassTimerManager timerManager; // タイマー管理クラス

        public sales()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化
            this.Load += new EventHandler(sales_Load);
        }

        private void sales_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            timerManager.UpdateDateTime(); // 初回表示時に日付と時間を更新
        }

        // メインメニューに戻る
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移
        }

        // 受注管理画面に遷移
        private void b_acc_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 受注管理画面に遷移
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
    }
}
