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
        public static void CompareStock(int productId)
        {
            MessageBox.Show("あんぱんまん");
            // TStockから指定された商品IDの在庫数を取得
            int stockQuantity = GetStockFromTStock(productId);
            if (stockQuantity == -1)
            {
                MessageBox.Show($"商品ID {productId} の在庫は設定されていません。");
                return;
            }

            // 安全在庫数を取得
            int safetyStock = GetSafetyStock(productId);
            if (safetyStock == -1)
            {
                MessageBox.Show($"商品ID {productId} の安全在庫数は設定されていません。");
                return;
            }

            // 比較して結果を表示
            if (stockQuantity < safetyStock)
            {
                int orderQuantity = safetyStock - stockQuantity + 10; // 余裕を持たせた発注量
                AutoOrder(productId, orderQuantity);
                MessageBox.Show($"商品ID {productId} の在庫が不足しています。自動発注を行います。");
                MessageBox.Show($"現在の在庫数: {stockQuantity}, 安全在庫数: {safetyStock}");
                MessageBox.Show($"発注数量: {orderQuantity} 個");
            }
            else
            {
                MessageBox.Show($"商品ID {productId} の在庫に変更はありません。");
            }
        }

        public static void AutoOrder(int PrID, int orderQuantity)
        {
            MessageBox.Show("発注登録を開始します");
            try
            {
                using (var context = new SalesManagementContext())
                {

                    // 商品データの取得 
                    var product = context.MProducts.SingleOrDefault(p => p.PrID == PrID);
                    if (product == null)
                    {
                        MessageBox.Show("指定された商品情報が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 新しい発注情報の登録 
                    var newHattyu = new THattyu
                    {
                        MaID = product.MaID,
                        EmID = Global.EmployeeID,
                        HaDate = DateTime.Now, // 日付が空なら現在日時 
                        WaWarehouseFlag = 0,
                        HaFlag = 0,
                        HaHidden = null
                    };

                    context.THattyus.Add(newHattyu);
                    context.SaveChanges();

                    // 新しい発注詳細情報の登録 
                    var newHattyuDetail = new THattyuDetail
                    {
                        HaID = newHattyu.HaID,
                        PrID = PrID,
                        HaQuantity = orderQuantity,
                    };

                    context.THattyuDetails.Add(newHattyuDetail);
                    context.SaveChanges();

                    MessageBox.Show("発注登録が完了しました");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("データの取得に失敗しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("データの形式が正しくありません: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期しないエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
