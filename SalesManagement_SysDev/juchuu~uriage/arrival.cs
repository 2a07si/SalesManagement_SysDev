using System;
using System.Windows.Forms;
using static SalesManagement_SysDev.labelChange;

namespace SalesManagement_SysDev
{
    public partial class arrival : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassDateNamelabel dateNameLabel; // 日付と時間ラベル管理用クラス

        public arrival(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.dateNameLabel = new ClassDateNamelabel(labeltime, labeldate); // ラベルを設定
            this.Load += new EventHandler(arrival_Load);
            timer1.Interval = 1000; // タイマーの間隔を1秒に設定
            timer1.Tick += new EventHandler(Timer1_Tick); // タイマーのTickイベントにハンドラを追加
            timer1.Start(); // タイマーを開始
        }

        private void arrival_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            dateNameLabel.UpdateDateTime(); // 初回表示時に日付と時間を更新
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dateNameLabel.UpdateDateTime(); // 日付と時間のラベルを更新
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに戻る
        }

        private void b_acc_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 受注管理画面に遷移
        }

        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm(); // 出荷管理画面に遷移
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移
        }

        private void b_lss_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm(); // 発注書発行画面に遷移
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 受注管理画面に遷移
        }
    }
}
