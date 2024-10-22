using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class CurrentStatus
    {
        public static class currentStatus
        {
            public static void RegistrationStatus(Label label2)
            {
                label2.Text = "登録";
            }
            public static void UpDateStatus(Label label2)
            {
                label2.Text = "更新";
            }
            public static void SearchStatus(Label label2)
            {
                label2.Text = "検索";
            }
            public static void ListStatus(Label label2)
            {
                label2.Text = "一覧";
            }
        }
    }
}
