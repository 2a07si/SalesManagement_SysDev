using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SalesManagement_SysDev.F_login;

namespace SalesManagement_SysDev
{
    internal class Class1
    {
        public static class GlobalUtility
        {
            // ラベルのテキストを更新するメソッド
            public static void UpdateLabels(Label labelId, Label labelEname)
            {
                labelId.Text = Global.PositionName;  // グローバル変数の権限名をラベルに設定
                labelEname.Text = Global.EmployeeName;  // グローバル変数の社員名をラベルに設定
            }
        }
    }
}
