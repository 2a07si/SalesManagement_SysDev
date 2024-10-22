using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Classまとめ
{
    internal class LabelStatus
    {
        public static class labelStatus
        {
            public static void labelstatus(Label label2 , Button b_kakutei)
            {
                if (label2.Text == "未選択")
                {
                    b_kakutei.Enabled = false;
                }
            }
        }
    }
}
