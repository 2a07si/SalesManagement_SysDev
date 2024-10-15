using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    internal class datetime
    {
        internal void DateTimeLabels(Label labeltime, Label labeldate)
        {
            throw new NotImplementedException();
        }

        public static class labeldate           
        {
            public static void DateTimeLabels(Label label1, Label label2)
            {
                DateTime dateTime = DateTime.Now;
                label1.Text = dateTime.ToLongTimeString();
                var now = System.DateTime.Now;
                label2.Text = now.ToString("yyyy年MM月dd日");
            }
        }
    }
}
