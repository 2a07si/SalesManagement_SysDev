using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    internal class ClassDateNamelabel
    {
        private Label timeLabel; // 時間を表示するラベル
        private Label dateLabel; // 日付を表示するラベル

        // コンストラクタでラベルを受け取る
        public ClassDateNamelabel(Label timeLabel, Label dateLabel)
        {
            this.timeLabel = timeLabel;
            this.dateLabel = dateLabel;
        }

        // ラベルを更新するメソッド
        public void UpdateDateTime()
        {
            DateTime now = DateTime.Now;
            timeLabel.Text = now.ToLongTimeString(); // 時間を更新
            dateLabel.Text = now.ToString("yyyy年MM月dd日"); // 日付を更新
        }
    }
}
