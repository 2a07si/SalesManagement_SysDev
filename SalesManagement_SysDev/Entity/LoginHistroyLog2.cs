using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Entity
{
    public class LoginHistroyLog2
    {
        // 主キー
        public int ID { get; set; }

        // ログインID
        public string LoginID { get; set; }

        //社員名
        public string ShainName { get; set; }

        public DateTime LoginDateTime { get; set; }
    }
}
