using System;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class CurrentStatus
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

        // グローバル変数としての現在の状態を保持
        public static Status CurrentStatusValue { get; private set; } = Status.未設定;

        // 状態の変更とラベルの更新
        public static void RegistrationStatus(Label label2)
        {
            CurrentStatusValue = Status.登録;
            label2.Text = "登録";
        }

        public static void UpDateStatus(Label label2)
        {
            CurrentStatusValue = Status.更新;
            label2.Text = "更新";
        }

        public static void SearchStatus(Label label2)
        {
            CurrentStatusValue = Status.検索;
            label2.Text = "検索";
        }

        public static void ListStatus(Label label2)
        {
            CurrentStatusValue = Status.一覧;
            label2.Text = "一覧";
        }

        // 状態をリセットするメソッド
        public static void ResetStatus(Label label2)
        {
            CurrentStatusValue = Status.未設定;
            label2.Text = "未設定";
        }
    }
}
