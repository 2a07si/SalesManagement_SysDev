using System;
using System.Windows.Forms;
using static SalesManagement_SysDev.labelChange;

namespace SalesManagement_SysDev
{
    public partial class lssue : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassDateNamelabel dateNameLabel; // 日付と時間ラベル管理用クラス

        public lssue()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.dateNameLabel = new ClassDateNamelabel(label1, label2); // ラベルを設定
            this.Load += new EventHandler(lssue_Load);
            timer1.Interval = 1000; // タイマーの間隔を1秒に設定
            timer1.Tick += new EventHandler(Timer1_Tick); // タイマーのTickイベントにハンドラを追加
            timer1.Start(); // タイマーを開始
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dateNameLabel.UpdateDateTime(); // 日付と時間のラベルを更新
        }

        private void close_Click(object sender, EventArgs e)
        {
            // メインフォームを再表示
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを閉じる
            this.Close();
        }

        private void b_acc_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 受注管理画面に遷移
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 受注管理画面に遷移
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移
        }

        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm(); // 出荷管理画面に遷移
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移
        }

        private void lssue_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            dateNameLabel.UpdateDateTime(); // 初回表示時に日付と時間を更新
        }
    }
}
