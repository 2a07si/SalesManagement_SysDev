//////////////////////////
//・クラス名
//ClassDateNamelabel
//・解説の内容
//- 時間と日付を表示するためのラベルを管理するクラス。
//- コンストラクタで受け取ったラベルを使って、現在の時間と日付を更新するメソッドを提供。
//- このクラスを利用することで、フォーム上で時間や日付を簡単に表示・更新できる。
//- ラベルの更新処理をこのクラスにカプセル化することで、フォームのコードがシンプルになる。
//・その他特筆事項
//- 日時のフォーマットは日本語に対応しており、特に日本のユーザーに適した形式で表示される。
//////////////////////////

using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
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
