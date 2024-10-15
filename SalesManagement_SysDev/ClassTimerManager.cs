using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public class ClassTimerManager
    {
        private System.Windows.Forms.Timer timer; // System.Windows.Forms.Timerを指定
        private Label labelTime;
        private Label labelDate;

        public ClassTimerManager(System.Windows.Forms.Timer timer, Label timeLabel, Label dateLabel)
        {
            this.timer = timer;
            this.labelTime = timeLabel;
            this.labelDate = dateLabel;

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
