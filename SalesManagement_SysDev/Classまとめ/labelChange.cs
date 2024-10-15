//////////////////////////
//・クラス名
//labelChange
//・解説の内容
//- グローバル変数を使用してラベルのテキストを更新するための静的ユーティリティクラス。
//- 主に、ログイン時に取得した社員名やポジション名をラベルに表示するための機能を提供する。
//・その他特筆事項
//- グローバル変数を使用することで、アプリケーション全体で一貫した情報表示が可能。
//- ラベル更新の処理を別のクラスに分離することで、コードの可読性と保守性を向上させている。
//////////////////////////

// labelChange.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SalesManagement_SysDev.F_login;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class labelChange
    {
        public static class GlobalUtility
        {
            // ラベルのテキストを更新するメソッド 
            public static void UpdateLabels(Label labelId, Label labelEname)
            {
                labelId.Text = Global.PositionName;  // グローバル変数の権限名をラベルに設定 
                labelEname.Text = Global.EmployeeName;  // グローバル変数の社員名をラベルに設定 
            }
            //日付 

        }
    }
}
