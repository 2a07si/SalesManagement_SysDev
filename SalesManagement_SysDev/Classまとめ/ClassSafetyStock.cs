using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesManagement_SysDev.Classまとめ
{
    public static class StockManager
    {
        // 商品IDごとの安全在庫数を保持
        public static Dictionary<int, int> SafetyStock { get; private set; } = new Dictionary<int, int>();

        // 初期設定メソッド（1～11の商品に安全在庫数を設定）
        public static void InitializeSafetyStock()
        {
            // 商品IDごとに安全在庫数を設定（仮の例）
            SafetyStock[1] = 30;
            SafetyStock[2] = 50;
            SafetyStock[3] = 20;
            SafetyStock[4] = 60;
            SafetyStock[5] = 30;
            SafetyStock[6] = 40;
            SafetyStock[7] = 15;
            SafetyStock[8] = 70;
            SafetyStock[9] = 5;
            SafetyStock[10] = 50;
            SafetyStock[11] = 20;
        }

        // 安全在庫数を取得
        public static int GetSafetyStock(int productId)
        {
            return SafetyStock.ContainsKey(productId) ? SafetyStock[productId] : -1; // 未設定の場合は -1 を返す
        }

        // TStockから在庫数を取得するメソッド
        public static int GetStockFromTStock(int productId)
        {
            int Quantity = 0;

            using (var context = new SalesManagementContext())
            {
                // TStockテーブルから指定されたproductIdの在庫を検索
                var stock = context.TStocks
                    .Where(s => s.PrID == productId) // PrIDが一致するレコードを検索
                    .FirstOrDefault(); // 一致する最初のレコードを取得

                // 見つかった場合、Quantityを取得
                if (stock != null)
                {
                    Quantity = stock.StQuantity; // TStockテーブルにあるQuantityを取得
                }
                else
                {
                    Console.WriteLine($"商品ID {productId} の在庫が見つかりません。");
                }
            }

            return Quantity;
        }
        // 在庫数と安全在庫数を比較し、発注が必要かどうかを判定
        public static void CompareStockWithSafetyStock(int productId)
        {
            // TStockから指定された商品IDの在庫数を取得
            int stockQuantity = GetStockFromTStock(productId);
            if (stockQuantity == -1)
            {
                Console.WriteLine($"商品ID {productId} の在庫は設定されていません。");
                return;
            }

            // 安全在庫数を取得
            int safetyStock = GetSafetyStock(productId);
            if (safetyStock == -1)
            {
                Console.WriteLine($"商品ID {productId} の安全在庫数は設定されていません。");
                return;
            }

            // 比較して結果を表示
            if (stockQuantity <= safetyStock)
            {
                //在庫が不足している場合の処理
            }
            else
            {
                //在庫が十分な場合の処理
            }
        }
    }
}
