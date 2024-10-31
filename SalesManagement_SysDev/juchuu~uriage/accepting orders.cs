﻿using System;
using System.Linq;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ; // 各種クラスを使用する
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using SalesManagement_SysDev.juchuu_uriage;
using Microsoft.EntityFrameworkCore;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定


        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            formChanger = new ClassChangeForms(this);
            accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            // ボタンアクセス制御を設定
            accessManager.SetButtonAccess(new Control[]
            {
                b_ord,
                b_arr,
                b_shi,
                b_sal,
                b_lss
            });
            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
        }

        // メインメニューに戻る
        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移
        }

        // 各ボタンでの画面遷移
        private void b_ord_Click(object sender, EventArgs e) => formChanger.NavigateToOrderForm();
        private void b_arr_Click_1(object sender, EventArgs e) => formChanger.NavigateToArrivalForm();
        private void b_shi_Click(object sender, EventArgs e) => formChanger.NavigateToShippingForm();
        private void b_sal_Click(object sender, EventArgs e) => formChanger.NavigateToSalesForm();
        private void b_lss_Click_1(object sender, EventArgs e) => formChanger.NavigateToIssueForm();

        private void clear_Click(object sender, EventArgs e) => ClearText();

        private void ClearText()
        {
            TBJyutyuID.Text = "";
            TBShopID.Text = "";
            TBShainID.Text = "";
            TBKokyakuID.Text = "";
            TBTantoName.Text = "";
            TyumonFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBJyutyuSyosaiID.Text = "";
            TBJyutyuIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            TBGoukeiKingaku.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
        }

        private void b_ser_Click(object sender, EventArgs e) => PerformSearch();

        private void PerformSearch()
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e) => UpdateStatus();

        private void UpdateStatus()
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_reg_Click(object sender, EventArgs e) => RegisterStatus();

        private void RegisterStatus()
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e) => ListStatus();

        private void ListStatus()
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }

        private void b_kakutei_Click_1(object sender, EventArgs e)
        {
            try
            {
                // モードに基づいて処理を分岐
                switch (CurrentStatus.CurrentMode)
                {
                    case CurrentStatus.Mode.通常:
                        HandleOrderOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        HandleOrderDetailOperation();
                        break;
                    default:
                        MessageBox.Show("現在のモードは無効です。");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void HandleOrderOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateOrder();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterOrder();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayOrders();
                    break;
                case CurrentStatus.Status.検索:
                    SearchOrders();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }

        private void HandleOrderDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateOrderDetails();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterOrderDetails();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayOrderDetails();
                    break;
                case CurrentStatus.Status.検索:
                    SearchOrderDetails();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }


        private void UpdateOrder()
        {
            string jyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string tantoName = TBTantoName.Text;
            DateTime jyutyuDate = date.Value;
            bool tyumonFlag = TyumonFlag.Checked;
            bool delFlag = DelFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                var order = context.TOrders.SingleOrDefault(o => o.OrId.ToString() == jyutyuID);
                if (order != null)
                {
                    order.SoId = int.Parse(shopID);
                    order.EmId = int.Parse(shainID);
                    order.ClId = int.Parse(kokyakuID);
                    order.ClCharge = tantoName;
                    order.OrDate = jyutyuDate;
                    order.OrStateFlag = null; // 適宜初期化
                    order.OrFlag = tyumonFlag ? 1 : 0;
                    order.OrHidden = delFlag ? "1" : "0";

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する受注が見つかりません。");
                }
            }
        }

        private void RegisterOrder()
        {
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string tantoName = TBTantoName.Text;
            DateTime jyutyuDate = date.Value;
            bool tyumonFlag = TyumonFlag.Checked;
            bool delFlag = DelFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                var newOrder = new TOrder
                {
                    SoId = int.Parse(shopID),
                    EmId = int.Parse(shainID),
                    ClId = int.Parse(kokyakuID),
                    ClCharge = tantoName,
                    OrDate = jyutyuDate,
                    OrStateFlag = null,
                    OrFlag = tyumonFlag ? 1 : 0,
                    OrHidden = delFlag ? "1" : "0"
                };

                context.TOrders.Add(newOrder);
                context.SaveChanges();
                MessageBox.Show("登録が成功しました。");
            }
        }

        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orders = context.TOrders.ToList();

                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        受注ID = o.OrId,
                        営業所ID = o.SoId,
                        社員ID = o.EmId,
                        顧客ID = o.ClId,
                        顧客担当者 = o.ClCharge,
                        受注日 = o.OrDate,
                        受注フラグ = o.OrFlag,
                        非表示フラグ = o.OrHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchOrders()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var jyutyuID = TBJyutyuID.Text.Trim();       // 受注ID
                var shopID = TBShopID.Text.Trim();           // 営業所ID
                var shainID = TBShainID.Text.Trim();         // 社員ID
                var kokyakuID = TBKokyakuID.Text.Trim();     // 顧客ID
                var tantoName = TBTantoName.Text.Trim();     // 担当者

                // 基本的なクエリ
                var query = context.TOrders.AsQueryable();

                // 受注IDを検索条件に追加
                if (!string.IsNullOrEmpty(jyutyuID) && int.TryParse(jyutyuID, out int parsedJyutyuID))
                {
                    query = query.Where(o => o.OrId == parsedJyutyuID);
                }

                // 営業所IDを検索条件に追加
                if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                {
                    query = query.Where(o => o.SoId == parsedShopID);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(o => o.EmId == parsedShainID);
                }

                // 顧客IDを検索条件に追加
                if (!string.IsNullOrEmpty(kokyakuID) && int.TryParse(kokyakuID, out int parsedKokyakuID))
                {
                    query = query.Where(o => o.ClId == parsedKokyakuID);
                }

                // 担当者名を検索条件に追加
                if (!string.IsNullOrEmpty(tantoName))
                {
                    query = query.Where(o => o.ClCharge.Contains(tantoName));
                }

                
                // 結果を取得
                var orders = query.ToList();

                if (orders.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = orders.Select(order => new
                    {
                        受注ID = order.OrId,
                        営業所ID = order.SoId,
                        社員ID = order.EmId,
                        顧客ID = order.ClId,
                        担当者 = order.ClCharge,
                        受注日 = order.OrDate,
                        注文フラグ = TyumonFlag.Checked ? "〇" : "×",
                        削除フラグ = DelFlag.Checked ? "〇" : "×"
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する受注が見つかりません。");
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }


        private void UpdateOrderDetails()
        {
            string jyutyuSyosaiID = TBJyutyuSyosaiID.Text;
            string jyutyuID = TBJyutyuIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;
            string goukeiKingaku = TBGoukeiKingaku.Text;

            using (var context = new SalesManagementContext())
            {
                var orderDetail = context.TOrderDetails.SingleOrDefault(od => od.OrDetailId.ToString() == jyutyuSyosaiID);
                if (orderDetail != null)
                {
                    orderDetail.OrId = int.Parse(jyutyuID);
                    orderDetail.PrId = int.Parse(syohinID);
                    orderDetail.OrQuantity = int.Parse(suryou);
                    orderDetail.OrTotalPrice = decimal.Parse(goukeiKingaku);

                    context.SaveChanges();
                    MessageBox.Show("受注詳細の更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する受注詳細が見つかりません。");
                }
            }
        }

        private void RegisterOrderDetails()
        {
            string jyutyuID = TBJyutyuIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;
            string goukeiKingaku = TBGoukeiKingaku.Text;

            using (var context = new SalesManagementContext())
            {
                var newOrderDetail = new TOrderDetail
                {
                    OrId = int.Parse(jyutyuID),
                    PrId = int.Parse(syohinID),
                    OrQuantity = int.Parse(suryou),
                    OrTotalPrice = decimal.Parse(goukeiKingaku)
                };

                context.TOrderDetails.Add(newOrderDetail);
                context.SaveChanges();
                MessageBox.Show("受注詳細の登録が成功しました。");
            }
        }

        private void DisplayOrderDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orderDetails = context.TOrderDetails.ToList();

                    dataGridView2.DataSource = orderDetails.Select(od => new
                    {
                        受注詳細ID = od.OrDetailId,
                        受注ID = od.OrId,
                        商品ID = od.PrId,
                        数量 = od.OrQuantity,
                        合計金額 = od.OrTotalPrice
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchOrderDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var jyutyuSyosaiID = TBJyutyuSyosaiID.Text;
                var jyutyuID = TBJyutyuIDS.Text;
                var syohinID = TBSyohinID.Text;
                var suryou = TBSuryou.Text;
                var goukeiKingaku = TBGoukeiKingaku.Text;

                // 基本的なクエリ
                var query = context.TOrderDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(jyutyuSyosaiID))
                {
                    // 受注詳細IDを検索条件に追加
                    query = query.Where(od => od.OrDetailId.ToString() == jyutyuSyosaiID);
                }

                if (!string.IsNullOrEmpty(jyutyuID))
                {
                    // 受注IDを検索条件に追加
                    query = query.Where(od => od.OrId.ToString() == jyutyuID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrId.ToString() == syohinID);
                }

                if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                {
                    // 数量を検索条件に追加
                    query = query.Where(od => od.OrQuantity == quantity);
                }

                if (!string.IsNullOrEmpty(goukeiKingaku) && decimal.TryParse(goukeiKingaku, out decimal totalPrice))
                {
                    // 合計金額を検索条件に追加
                    query = query.Where(od => od.OrTotalPrice == totalPrice);
                }

                // 結果を取得
                var orderDetails = query.ToList();

                if (orderDetails.Any())
                {
                    dataGridView2.DataSource = orderDetails.Select(od => new
                    {
                        受注詳細ID = od.OrDetailId,
                        受注ID = od.OrId,
                        商品ID = od.PrId,
                        数量 = od.OrQuantity,
                        合計金額 = od.OrTotalPrice
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する受注詳細が見つかりません。");
                }
            }
        }




        private void ToggleOrderSelection()
        {
            isOrderSelected = !isOrderSelected;
            orderFlag = isOrderSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isOrderSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);
        }


        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleOrderSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
        }


        private void UpdateFlagButtonText()
        {
            // b_FlagSelectorのテキストを現在の状態に合わせる
            b_FormSelector.Text = orderFlag;
        }

    }
}
