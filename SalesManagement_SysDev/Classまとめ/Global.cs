////////////////////////// 
//・クラス名 
//-Global 
//・解説の内容 
//-アプリケーション全体で使用されるグローバル変数を管理するクラス。 
//-役職名、社員名、社員IDのプロパティを持ち、アプリケーションの各所でアクセス可能。 
//-Resetメソッドにより、これらの変数を初期化することができ、必要に応じてクリーンな状態に戻すことが可能。 
//・その他特筆事項 
//-グローバル変数の管理を行うことで、アプリケーション全体の状態を一元化し、管理の効率化を図ることができる。 
//-必要に応じて、他のグローバルな設定や状態管理のためのメソッドを追加することができる。 
////////////////////////// 

using System;

namespace SalesManagement_SysDev.Classまとめ
{
    // グローバル変数を管理するクラス 
    internal static class Global
    {
        // グローバル変数: 社員ID 
        public static int EmployeeID { get; set; } // ここをintに変更 

        // グローバル変数: 社員名 
        public static string EmployeeName { get; set; }

        // グローバル変数: 権限名 
        public static string PositionName { get; set; }

        // グローバル変数をリセットするメソッド 
        public static string Reset()
        {
            // 社員ID、社員名、権限名をnullに設定 
            EmployeeID = 0; // intなので0にリセット 
            EmployeeName = null;
            PositionName = null;
            return "リセット完了"; // リセット完了のメッセージを返す 
        }
    }
}
