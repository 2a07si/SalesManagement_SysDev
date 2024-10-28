using System;

namespace SalesManagement_SysDev
{
    public partial class LoginHistoryLog
    {
        // プライマリーキーとしてのログイン履歴のID 
        public int Id { get; set; }  // プライマリーキーのプロパティを追加

        // ログイン履歴のログインID（必要に応じてリネーム）
        public string LoginId { get; set; } = null!;

        // ログインに用いられたパスワード（暗号化またはハッシュ化して保存することを推奨） 
        public string Password { get; set; } = null!;

        // ログイン日時 
        public DateTime LoginDateTime { get; set; }

        // 成功したログインかどうか 
        public bool IsSuccessful { get; set; }


        // デフォルトコンストラクタ  
        public LoginHistoryLog()
        {
        }

        // コンストラクタ 
        public LoginHistoryLog(int id, string loginId, string password, DateTime loginDateTime, bool isSuccessful)
        {
            Id = id; // プライマリーキーの初期化
            LoginId = loginId;
            Password = password;
            LoginDateTime = loginDateTime;
            IsSuccessful = isSuccessful;
        }
    }
}
