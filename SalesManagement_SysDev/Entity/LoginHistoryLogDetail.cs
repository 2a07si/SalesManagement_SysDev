using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Entity
{
    public class LoginHistoryLogDetail
    {
        public int DetailID { get; set; } // プライマリキー
        public int ID { get; set; } // 外部キー
        public string Display { get; set; }
        public string Mode { get; set; }
        public string Process { get; set; }
        public int LogID { get; set; }
        public DateTime AcceptDateTime { get; set; }

        // 外部キーリレーション
        public LoginHistoryLog LoginHistoryLog { get; set; }
    }

}
