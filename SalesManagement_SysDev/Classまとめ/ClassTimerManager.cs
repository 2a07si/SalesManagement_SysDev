//////////////////////////
//・クラス名 
//-ClassTimerManager 
//・解説の内容 
//-UIのラベルに日付と時間を表示するためのタイマー管理クラス 
//-指定されたラベルに現在の日時を1秒ごとに更新する機能を提供する。 
//-コンストラクタで受け取ったタイマーとラベルを使用して、タイマーの設定や更新処理を行う。 
//・その他特筆事項 
//-タイマーの間隔を変更することで、更新頻度を調整できる。
//-時間や日付のフォーマットを変更する機能を追加する余地がある。
//////////////////////////

using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    public class ClassTimerManager
    {
        private System.Windows.Forms.Timer timer; // System.Windows.Forms の Timer を使用
        private Label labeltime; // 時間表示ラベル
        private Label labeldate; // 日付表示ラベル

        public ClassTimerManager(System.Windows.Forms.Timer timer, Label timeLabel, Label dateLabel)
        {
            this.timer = timer;
            this.labeltime = timeLabel;
            this.labeldate = dateLabel;

            // タイマーの設定
            this.timer.Interval = 1000; // 1秒ごとに更新
            this.timer.Tick += new EventHandler(OnTimerTick); // タイマーイベントの設定
            this.timer.Start(); // タイマーを開始
        }

        // タイマーがTickしたときに呼ばれるメソッド
        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateDateTime(); // 日時を更新
        }

        // 日付と時間を更新するメソッド
        public void UpdateDateTime()
        {
            labeltime.Text = DateTime.Now.ToString("HH:mm"); // 現在の時間を表示
            labeldate.Text = DateTime.Now.ToString("yyyy年MM月dd日"); // 現在の日付を表示
        }
    }
}
