//////////////////////////  
//・クラス名  
//-Global  
//・解説の内容  
//-アプリケーション全体で使用されるグローバル変数を管理するクラス。  
//-役職名、社員名、社員IDのプロパティを持ち、アプリケーションの各所でアクセス可能。  
//-Resetメソッドにより、これらの変数を初期化することができ、必要に応じてクリーンな状態に戻すことが可能。  
//・その他特筆事項  
//-グローバル変数の管理を行うことで、アプリケーション全体の状態を一元化し、管理の効率化を図ることができる。  
//-必要に応じて、他のグローバルな設定や状態管理のためのメソッドを追加することができる。  
//////////////////////////  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Classまとめ
{
    // グローバル変数を管理するクラス  
    internal static class Global
    {
        // グローバル変数: 社員ID  
        public static int EmployeeID { get; set; } // ここをintに変更  

        // グローバル変数: 社員名  
        public static string EmployeeName { get; set; }

        // グローバル変数: 権限名  
        public static string PositionName { get; set; }

        // グローバル変数: 権限レベル  
        public static int EmployeePermission { get; set; }  // 1, 2, 3の権限レベルを想定

        // グローバル変数をリセットするメソッド  
        public static string Reset()
        {
            // 社員ID、社員名、権限名をリセット  
            EmployeeID = 0; // intなので0にリセット  
            EmployeeName = null;
            PositionName = null;
            return "リセット完了"; // リセット完了のメッセージを返す  
        }

        // 在庫更新メッセージを保存するためのリスト
        public static List<string> StockUpdateMessages = new List<string>();

        // 在庫更新メッセージを追加するメソッド  
        public static void AddStockUpdateMessage(int prID, int waQuantity)
        {
            string message = $"在庫の更新がありました。商品ID：{prID} 在庫数：{waQuantity}";
            StockUpdateMessages.Add(message);
        }

        // 在庫更新メッセージを一括で取得するメソッド  
        public static string GetStockUpdateMessages()
        {
            // メッセージを改行でつなげる  
            string combinedMessages = string.Join(Environment.NewLine, StockUpdateMessages);
            // メッセージリストをクリアして次回のために準備  
            StockUpdateMessages.Clear();
            return combinedMessages;
        }

        // 在庫不足のため非表示の出庫情報がある場合にのみメッセージを取得する
        public static string GetStockUpdateMessagesForOutbound(SalesManagementContext context)
        {
            var messages = new List<string>();

            // Syukkoテーブルから"在庫不足のため、非表示"という理由で非表示のデータを検索
            var hiddenStockUpdates = context.TSyukkos
                .Where(s => s.SyHidden == "在庫不足のため非表示中")
                .ToList();

            // 非表示のSyukko情報に関連するTSyukkoDetailsを取得してメッセージを作成
            foreach (var syukko in hiddenStockUpdates)
            {
                // Syukkoに関連するTSyukkoDetailsを検索
                var syukkoDetails = context.TSyukkoDetails
                    .Where(d => d.SyID == syukko.SyID)
                    .ToList();

                foreach (var detail in syukkoDetails)
                {
                    // PrIDとSyQuantityをTSyukkoDetailsから取得し、メッセージを作成
                    messages.Add($"在庫不足のため非表示となった出庫情報があります。商品ID：{detail.PrID} 出庫数量：{detail.SyQuantity}");
                }
            }

            // メッセージを改行でつなげる
            string combinedMessages = string.Join(Environment.NewLine, messages);
            return combinedMessages;
        }

        // 特定のメッセージを削除するメソッド
        public static void RemoveStockUpdateMessage(string message)
        {
            // メッセージがリスト内に存在する場合のみ削除
            if (StockUpdateMessages.Contains(message))
            {
                StockUpdateMessages.Remove(message);
            }
        }

        // すべてのメッセージを削除するメソッド
        public static void ClearStockUpdateMessages()
        {
            // メッセージリストを完全にクリア
            StockUpdateMessages.Clear();
        }

    }
}
