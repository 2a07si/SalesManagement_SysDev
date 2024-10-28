using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class CurrentStatus2
    {
        // 状態を表す列挙型
        public enum Status
        {
            未設定, // デフォルトの状態
            登録,
            更新,
            検索,
            一覧
        }

        // 現在の状態を保持
        public static Status CurrentStatusValue { get; private set; } = Status.未設定;

        // モードを表す列挙型
        public enum Mode
        {
            通常, // 通常モード
            詳細  // 詳細モード
        }

        // 現在のモードを保持
        public static Mode CurrentMode { get; private set; } = Mode.通常;

        // 状態の変更メソッド
        public static void SetStatus(Status status, Label label2)
        {
            CurrentStatusValue = status;
            label2.Text = status.ToString();
        }

        // モードの設定メソッド
        public static void SetMode(Mode mode)
        {
            CurrentMode = mode;
        }

        // 状態をリセットするメソッド
        public static void ResetStatus(Label label2)
        {
            CurrentStatusValue = Status.未設定;
            label2.Text = "未設定";
        }
    }
}
