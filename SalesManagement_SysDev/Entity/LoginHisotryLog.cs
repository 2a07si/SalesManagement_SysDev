using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class LoginHistoryLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string LoginId { get; set; }
        // プライマリーキーとしてのログイン履歴のID 
        public int ID { get; set; }  // プライマリーキーのプロパティを追加

        // ログイン履歴のログインID（必要に応じてリネーム）
        public string LoginID { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LoginEmName { get; set; }

        public DateTime LoginDateTime { get; set; }

        public bool IsSuccessful { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        // デフォルトコンストラクタ  
        public LoginHistoryLog()
        {
        }

        // コンストラクタ 
        public LoginHistoryLog(int id, string loginID, string password, DateTime loginDateTime, bool isSuccessful)
        {
            ID = id; // プライマリーキーの初期化
            LoginID = loginID;
            Password = password;
            LoginDateTime = loginDateTime;
            IsSuccessful = isSuccessful;
        }
    }
}
