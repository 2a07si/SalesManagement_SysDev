////////////////////////// 
//・クラス名 
//-ClassDateNamelabel 
//・解説の内容 
//-日時を表示するラベルを管理するクラス 
//-コンストラクターで受け取ったラベルを使って、現在の時間と日付を更新する機能を提供する。 
//-引数なしのコンストラクターも実装し、時間と日付を表示するためのラベルを指定する必要がない場合にも対応。 
//-主にUIの日時表示を担当し、外部からの呼び出しにより自動で更新可能。 
//・その他特筆事項 
//-時間と日付のフォーマットを変更する機能を追加する余地がある。 
//-必要に応じて他のラベルや機能を追加することができる。 
////////////////////////// 

using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    public class ClassDateNamelabel
    {
        private Label labeltime; // 時間ラベル
        private Label labeldate; // 日付ラベル

        // 4つの引数を持つコンストラクター
        public ClassDateNamelabel(Label timeLabel, Label dateLabel, Label idLabel, Label nameLabel)
        {
            this.labeltime = timeLabel;
            this.labeldate = dateLabel;
            // 他の処理...
        }

        // 引数なしのコンストラクター
        public ClassDateNamelabel(Label timeLabel, Label dateLabel)
        {
            this.labeltime = timeLabel;
            this.labeldate = dateLabel;
            // 必要に応じてデフォルト処理...
        }

        // 日付と時間を更新するメソッド
        public void UpdateDateTime()
        {
            labeltime.Text = DateTime.Now.ToString("HH:mm:ss"); // 現在の時間を表示
            labeldate.Text = DateTime.Now.ToString("yyyy/MM/dd"); // 現在の日付を表示
        }
    }
}
