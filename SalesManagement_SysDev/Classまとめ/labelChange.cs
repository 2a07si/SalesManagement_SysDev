using System.Windows.Forms;

//////////////////////////
//・クラス名 
//-labelChange 
//・解説の内容 
//-ラベルのテキストを更新する機能を提供するクラス 
//-アプリケーション内で使用されるラベルの情報を設定するための静的メソッドを持つ。 
//-主に、グローバル変数からの情報をラベルに反映させる役割を果たす。 
//・その他特筆事項 
//-ラベルの更新処理を他のクラスやフォームから簡単に呼び出すことができる。 
//-将来的に、異なるラベルタイプへの対応を追加することができる。
//////////////////////////

namespace SalesManagement_SysDev.Classまとめ
{
    internal class labelChange
    {


        public static class GlobalUtility
        {
            // ラベルのテキストを更新するメソッド
            public static void UpdateLabels(Label labelId, Label labelEname)
            {
                // グローバル変数の権限名をラベルに設定  
                labelId.Text = Global.PositionName;

                // グローバル変数の社員名をラベルに設定  
                labelEname.Text = Global.EmployeeName;
            }
        }
    }
}
