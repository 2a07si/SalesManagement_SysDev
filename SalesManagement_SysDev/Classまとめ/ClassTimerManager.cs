//////////////////////////
//・クラス名
//ClassTimerManager
//・解説の内容
//- タイマーを利用して定期的に時間と日付を更新するクラス。
//- コンストラクタで受け取ったタイマーとラベルを使用して、1秒ごとに日時を更新する。
//- タイマーのイベントハンドラを設定し、時間が更新されるたびにラベルに新しい時間と日付を表示する。
//- フォームのコードを簡素化し、タイマーの管理を容易にする。
//・その他特筆事項
//- このクラスを使用することで、UIの更新が自動化され、ユーザー体験が向上する。
//////////////////////////

using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    public class ClassTimerManager
    {
        private System.Windows.Forms.Timer timer; // System.Windows.Forms.Timerを指定 
        private Label labelTime;
        private Label labelDate;

        public ClassTimerManager(System.Windows.Forms.Timer timer, Label timeLabel, Label dateLabel)
        {
            this.timer = timer;
            labelTime = timeLabel;
            labelDate = dateLabel;

            this.timer.Interval = 1000; // 1秒 
            this.timer.Tick += Timer_Tick; // タイマーのTickイベントにハンドラを追加 
            this.timer.Start(); // タイマーを開始 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime(); // 日付と時間を更新 
        }

        public void UpdateDateTime()
        {
            DateTime dateTime = DateTime.Now;
            labelTime.Text = dateTime.ToLongTimeString(); // 時間を更新 
            labelDate.Text = dateTime.ToString("yyyy年MM月dd日"); // 日付を更新 
        }
    }
}
