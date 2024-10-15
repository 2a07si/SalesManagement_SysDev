using System;
using System.Windows.Forms;
using static SalesManagement_SysDev.labelChange;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassDateNamelabel dateNameLabel; // 日付と時間ラベル管理用クラス

        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.dateNameLabel = new ClassDateNamelabel(label1, label2); // ラベルを設定
            this.Load += new EventHandler(acceptingorders_Load);
            timer1.Interval = 1000; // タイマーの間隔を1秒に設定
            timer1.Tick += new EventHandler(Timer1_Tick); // タイマーのTickイベントにハンドラを追加
            timer1.Start(); // タイマーを開始
        }

        public acceptingorders()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.dateNameLabel = new ClassDateNamelabel(label1, label2); // ラベルを設定
        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            dateNameLabel.UpdateDateTime(); // 初回表示時に日付と時間を更新
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dateNameLabel.UpdateDateTime(); // 日付と時間のラベルを更新
        }

        // メインメニューに戻る
        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移
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

        // 他のクリックイベントも同様に簡潔化
        private void b_ord_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移
        }

        private void b_lss_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm(); // 発注書発行画面に遷移
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移
        }
        private void b_ord_Click_2(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移
        }
    }
}
