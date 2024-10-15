//////////////////////////
//・クラス名
//Global
//・解説の内容
//- アプリケーション全体で共通して使用されるグローバルデータを管理する静的クラス。
//- 社員ID、社員名、ポジション名を保持し、必要に応じてアクセスできるようにする。
//- グローバルデータのリセットを行うメソッドを提供。
//・その他特筆事項
//- グローバルデータを使用することで、各フォームやクラス間で情報の共有が容易になる。
//- 状態管理を簡素化し、コードの可読性を向上させる。
//////////////////////////

// Global.cs
namespace SalesManagement_SysDev.Classまとめ
{
    public static class Global
    {
        public static int EmployeeID { get; set; }
        public static string EmployeeName { get; set; }
        public static string PositionName { get; set; } // ポジション名を保存 

        /// <summary> 
        /// グローバルデータをリセットする。 
        /// </summary> 
        public static void Reset()
        {
            EmployeeID = 0;
            EmployeeName = string.Empty;
            PositionName = string.Empty;
        }
    }
}
