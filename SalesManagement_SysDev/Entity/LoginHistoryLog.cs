using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Entity
{
     public class LoginHistoryLog
    {
        // 主キー
        public int ID { get; set; }

        // ログインID
        public string LoginID { get; set; }


        // パスワード
        public string Password { get; set; }

        // ログイン日時
        public DateTime LoginDateTime { get; set; }

        // ログイン成功・失敗フラグ
        public bool IsSuccessful { get; set; }
    }
}
