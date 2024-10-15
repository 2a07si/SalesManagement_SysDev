// ////////////////////////// 
//・クラス名 
//-ClassTimerManager 
//・解説の内容 
//-タイマーを管理するクラス 
//-指定されたラベルに日付と時間を表示する機能を提供し、タイマーによる自動更新が可能。 
//-System.Windows.Forms.Timerを使用してUIスレッドで動作し、ラベルの内容を定期的に更新する。 
//・その他特筆事項 
//-タイマーの間隔やフォーマットをカスタマイズするオプションを追加する余地がある。 
//-例外処理を追加し、タイマーの開始や停止時に適切なエラーハンドリングを行うことが推奨される。 
// ////////////////////////// 

using System;
using System.Windows.Forms; 

namespace SalesManagement_SysDev.Classまとめ
{
    public class ClassTimerManager
    {
        private readonly System.Windows.Forms.Timer timer; // System.Windows.Forms.Timerを使用
        private readonly Label labelTime; // 時間表示用ラベル
        private readonly Label labelDate; // 日付表示用ラベル

        public ClassTimerManager(System.Windows.Forms.Timer timer, Label labelTime, Label labelDate)
        {
            this.timer = timer;
            this.labelTime = labelTime;
            this.labelDate = labelDate;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer.Interval = 1000; // 1秒ごとにタイマーを更新
            timer.Tick += (sender, e) => UpdateDateTime(); // タイマーイベントの設定
            timer.Start();
        }

        public void UpdateDateTime()
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss"); // 時間の更新
            labelDate.Text = DateTime.Now.ToString("yyyy/MM/dd"); // 日付の更新
        }
    }
}
