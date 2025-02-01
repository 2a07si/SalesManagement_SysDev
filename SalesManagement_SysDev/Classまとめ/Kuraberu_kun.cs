using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.Classまとめ
{

    public class Kuraberu_kun
    {
        public static void Timestamp_kuh()
        {
            DateTime Timestamp = DateTime.Now;   
        }

        public static bool Kuraberu_chan(string Display, string Mode, string Process, int LogID, DateTime timestamp)
        {
            //MessageBox.Show("くらべるちゃん起動！");
            string data = null;
            switch(Display)
            {
                case "受注":
                    {
                        if(Mode == "通常")
                            data = Accepting(LogID, data);
                        else if(Mode == "詳細")
                            data = AcceptingDetail(LogID, data);
                    }
                    break;
                case "注文":
                    {
                        if(Mode =="通常")
                            data = Order(LogID, data);
                        else if (Mode == "詳細")
                            data = OrderDetail(LogID, data);
                    }
                    break;
                case "出庫":
                    {
                        if(Mode =="通常")
                            data = Syukko(LogID, data);
                       else if (Mode == "詳細")
                            data = SyukkoDetail(LogID, data);
                    }
                    break;

                case "入荷":
                    {
                        if (Mode == "通常")
                            data = Arrival(LogID, data);
                       else if (Mode == "詳細")
                            data = ArrivalDetail(LogID, data);
                    }
                    break;

                case "出荷":
                    {
                        if (Mode == "通常")
                            data = Shipment(LogID, data);
                       else if (Mode == "詳細")
                            data = ShipmentDetail(LogID, data);
                    }
                    break;

                case "売上":
                    {
                        if (Mode == "通常")
                            data = Sale(LogID, data);
                       else if (Mode == "詳細")
                            data = SaleDetail(LogID, data);
                    }
                    break;
                case "発注":
                    {
                        if (Mode == "通常")
                            data = Hattyu(LogID, data);  
                        else if (Mode == "詳細")
                            data = HattyuDetail(LogID, data);
                    }
                    break;

                case "入庫":
                    {
                        if (Mode == "通常")
                            data = Warehousing(LogID, data);
                        else if (Mode == "詳細")
                            data = WarehousingDetail(LogID, data);
                    }
                    break;
                case "商品":
                    {
                        data = Product(LogID, data);
                    }
                    break;
                case "社員":
                    {
                        data = Employee(LogID, data);
                    }
                    break;
                case "顧客":
                    {
                        data = Client(LogID, data);
                    }
                    break;
                case "在庫":
                    {
                        data = Stock(LogID, data);
                    }
                    break;
            }
            try
            {
                //MessageBox.Show(data);
                using (var context = new SalesManagementContext())
                {
                    var latestLog = context.LoginHistoryLogDetails
                        .Where(log => log.Display == Display
                                   && log.Mode == Mode
                                   && log.Process == Process
                                   && log.LogID == LogID)
                        .OrderByDescending(log => log.AcceptDateTime) // Dateで降順に並べる
                        .FirstOrDefault(); // 最初のレコードを取得（最も遅いもの）

                    if (latestLog == null)
                    {
                        // latestLog が null の場合の処理
                        //MessageBox.Show("一致するログが見つかりませんでした。");
                        return true; // 処理を継続
                    }

                    if (latestLog.AcceptDateTime > timestamp)
                    {
                        DialogResult result = MessageBox.Show(
                            "このデータには最新の情報が存在します。上書き保存しますか？\n" + data,
                            "確認",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            // ユーザーが「はい」を選択した場合の処理
                            //Console.WriteLine("データを上書き保存します。");
                            return true;
                        }
                        else
                        {
                            // ユーザーが「いいえ」を選択した場合の処理
                            //Console.WriteLine("操作をキャンセルしました。");
                            return false;
                        }
                    }
                    else
                    {
                        // 条件が一致しない場合の処理
                        //MessageBox.Show("条件に一致するログが見つかりませんでした。");
                        return true; // 処理を継続
                    }
                }
            }
            catch (Exception ex)
            {
                // 例外が発生した場合の処理
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 処理を中断
            }


        }
        public static string Accepting(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var acc = context.TOrders.FirstOrDefault(o => o.OrID == id);
                data = "受注ID:" + acc.OrID + "営業所ID:" + acc.SoID + "社員ID:" +  acc.EmID + "顧客ID:" +  acc.ClID + "顧客担当者名:" + acc.ClCharge + "受注日:" + acc.OrDate + "受注状態:" +  acc.OrStateFlag + "管理フラグ:" + acc.OrFlag + "備考:" +  acc.OrHidden;
                return data;
            }
        }
        public static string AcceptingDetail(int id , string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TOrderDetails.FirstOrDefault(o => o.OrDetailID == id);
                data = "受注詳細ID:" + a.OrDetailID + "受注ID:" + a.OrID + "商品ID:" + a.PrID + "数量:" + a.OrQuantity + "合計金額:" + a.OrTotalPrice;
                return data;
            }
        }
        public static string Order(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TChumons.FirstOrDefault(o => o.ChID == id);
                data = "注文ID:" + a.ChID + "営業所ID:" + a.SoID + "社員ID:" + a.EmID + "顧客ID:" + a.ClID + "受注ID:" + a.OrID + "注文日:" + a.OrID + "注文状態:" + a.ChStateFlag + "注文管理:" + a.ChFlag + "備考:" + a.ChHidden;
                return data;
            }
        }
        public static string OrderDetail(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TChumonDetails.FirstOrDefault(o => o.ChDetailID == id);
                data = "注文詳細ID:" + a.ChDetailID + "注文ID:" + a.ChID + "商品ID:" + a.PrID + "数量:" + a.ChQuantity;
                return data;
            }
        }
        public static string Syukko(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TSyukkos.FirstOrDefault(o => o.SyID == id);
                data = "出庫ID:" + a.SyID + "社員ID:" + a.EmID + "顧客ID:" + a.ClID + "営業所ID:" + a.SoID + "受注ID:" + a.OrID + "出庫日:" + a.SyDate + "出庫状態:" + a.SyStateFlag + "出庫管理:" + a.SyFlag + "備考:" + a.SyHidden;
                return data;
            }
        }
        public static string SyukkoDetail(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TSyukkoDetails.FirstOrDefault(o => o.SyDetailID == id);
                data = "出庫詳細ID:" + a.SyDetailID + "出庫ID:" + a.SyID + "商品ID:" + a.PrID + "数量:" + a.SyQuantity;
                return data;
            }
        }
        public static string Arrival(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TArrivals.FirstOrDefault(o => o.ArID == id);
                data = "入荷ID:" + a.ArID + "営業所ID:" + a.SoID + "社員ID:" + a.EmID + "顧客ID:" + a.ClID + "受注ID:" + a.OrID + "入荷日:" + a.ArDate + "入荷状態:" + a.ArStateFlag + "入荷管理:" + a.ArFlag + "備考:" + a.ArHidden;
                return data;
            }
        }
        public static string ArrivalDetail(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TArrivalDetails.FirstOrDefault(o => o.ArDetailID == id);
                data = "入荷詳細ID:" + a.ArDetailID + "入荷ID:" + a.ArID + "商品ID:" + a.PrID + "数量:" + a.ArQuantity;
                return data;
            }
        }
        public static string Shipment(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TShipments.FirstOrDefault(o => o.ShID == id);
                data = "出荷ID:" + a.ShID + "顧客ID:" + a.ClID + "社員ID:" + a.EmID + "営業所ID:" + a.SoID + "受注ID:" + a.OrID + "出荷状態:" + a.ShStateFlag + "出荷管理:" + a.ShFlag + "備考:" + a.ShHidden; 
                return data;
            }
        }
        public static string ShipmentDetail(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TShipmentDetails.FirstOrDefault(o => o.ShDetailID == id);
                data = "出荷詳細ID:" + a.ShDetailID + "出荷ID:" + a.ShID + "商品ID:" + a.PrID + "数量:" + a.ShQuantity; 
                return data;
            }
        }
        public static string Sale(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TSales.FirstOrDefault(o => o.SaID == id);
                data = "売上ID:" + a.SaID + "顧客ID:" + a.ClID + "営業所ID:" + a.SoID + "社員ID:" + a.EmID + "受注ID:" + a.OrID + "売上日時:" + a.SaDate;
                return data;
            }
        }
        public static string SaleDetail(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TSaleDetails.FirstOrDefault(o => o.SaID == id);
                data = "売上詳細ID:" + a.SaDetailID + "売上ID:" + a.SaID + "商品ID:" + a.PrID + "数量:" + a.SaQuantity + "合計金額:" + a.SaPrTotalPrice;
                return data;
            }
        }
        public static string Hattyu(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.THattyus.FirstOrDefault(o => o.HaID == id);
                data = "発注ID:" + a.HaID + "メーカーID:" + a.MaID + "社員ID:" + a.EmID + "発注日:" + a.HaDate + "入庫状態:" + a.WaWarehouseFlag + "発注管理:" + a.HaFlag + "備考:" + a.HaHidden;
                 return data;
            }
        }
        public static string HattyuDetail(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.THattyuDetails.FirstOrDefault(o => o.HaDetailID == id);
                data = "発注詳細ID:" + a.HaDetailID + "発注ID:" + a.HaID + "商品ID:" + a.PrID + "数量:" + a.HaQuantity;
                return data;
            }
        }
        public static string Warehousing(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TWarehousings.FirstOrDefault(o => o.WaID == id);
                data = "入庫ID:" + a.WaID + "発注ID:" + a.HaID + "社員ID:" + a.EmID + "入庫日:" + a.WaDate + "入庫完了:" + a.WaShelfFlag + "入庫管理:" + a.WaFlag + "備考:" + a.WaHidden;
                return data;
            }
        }
        public static string WarehousingDetail(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TWarehousingDetails.FirstOrDefault(o => o.WaDetailID == id);
                data = "入庫詳細ID" + a.WaDetailID + "入庫ID:" + a.WaID + "商品ID:" + a.PrID + "数量:" + a.WaQuantity; 
                return data;
            }
        }
        public static string Product(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.MProducts.FirstOrDefault(o => o.PrID == id);
                data = "商品ID:" + a.PrID + "メーカーID:" + a.MaID + "商品名:" + a.PrName + "価格:" + a.Price + "JANコード:" + a.PrJcode + "安全在庫数:" +  a.PrSafetyStock + "小分類ID:" + a.ScID + "型番:" + a.PrModelNumber + "色:" + a.PrColor + "発売日:" + a.PrReleaseDate + "商品管理:" + a.PrFlag + "備考:" + a.PrHidden;
                return data;
            }
        }
        public static string Client(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.MClients.FirstOrDefault(o => o.ClID == id);
                data = "顧客ID:" + a.ClID + "営業所ID:" + a.SoID + "顧客名:" + a.ClName + "住所:" + a.ClAddress + "電話番号:" + a.ClPhone + "郵便番号:" + a.ClPostal + "FAX:" + a.ClFax + "顧客管理:" + a.ClFlag + "備考:" + a.ClHidden;  
                return data;
            }
        }
        public static string Stock(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.TStocks.FirstOrDefault(o => o.StID == id);
                data = "在庫ID:" + a.StID + "商品ID" + a.PrID + "在庫数:" + a.StQuantity + "在庫管理:" + a.StFlag;
                return data;
            }
        }
        public static string Employee(int id, string data)
        {
            using (var context = new SalesManagementContext())
            {
                var a = context.MEmployees.FirstOrDefault(o => o.EmID == id);
                data = "社員ID:" + a.EmID + "社員名:" + a.EmName + "営業所ID:" + a.SoID + "役職ID:" + a.PoID + "入社年月日:" + a.EmHiredate + "パスワード:" + a.EmPassword + "電話番号:" + a.EmPhone + "社員管理:" + a.EmFlag + "備考:" + a.EmHidden;
                return data;
            }
        }
    }

}