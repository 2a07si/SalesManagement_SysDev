using System;
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
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定
        private ClassDataGridViewClearer dgvClearer;

        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス


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

            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayOrders();
            DisplayOrderDetails();
        }

        // メインメニューに戻る
        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
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
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
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
            DisplayOrders();
            DisplayOrderDetails();
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
                        MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleOrderOperation()
        {
            try
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
                        DisplayOrderDetails();
                        break;
                    case CurrentStatus.Status.検索:
                        SearchOrders();
                        break;
                    default:
                        MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleOrderDetailOperation()
        {
            try
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
                        DisplayOrders();
                        break;
                    case CurrentStatus.Status.検索:
                        SearchOrderDetails();
                        break;
                    default:
                        MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrder()
        {
            try
            {
                string jyutyuID = TBJyutyuID.Text;
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string tantoName = TBTantoName.Text;
                DateTime jyutyuDate = date.Value;
                bool tyumonFlag = TyumonFlag.Checked;
                bool delFlag = DelFlag.Checked;
                string riyuu = TBRiyuu.Text;

                // 条件精査
                if (!int.TryParse(jyutyuID, out int parsedJyutyuID) || jyutyuID.Length > 6)
                {
                    MessageBox.Show("受注IDは半角整数で、最大6桁でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(shopID, out int parsedShopID) || shopID.Length > 2)
                {
                    MessageBox.Show("営業所IDは半角整数で、最大2桁でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(shainID, out int parsedShainID) || shainID.Length > 6)
                {
                    MessageBox.Show("社員IDは半角整数で、最大6桁でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(kokyakuID, out int parsedKokyakuID) || kokyakuID.Length > 6)
                {
                    MessageBox.Show("顧客IDは半角整数で、最大6桁でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tantoName.Length > 50)
                {
                    MessageBox.Show("担当者名は最大50文字でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                        order.OrStateFlag = tyumonFlag ? 2 : 0; // 適宜初期化 
                        order.OrFlag = delFlag ? 1 : 0;
                        order.OrHidden = riyuu;

                        context.SaveChanges();
                        if (TyumonFlag.Checked)
                        {
                            AcceptionConfirm(int.Parse(jyutyuID));
                            
                        }
                        MessageBox.Show("更新が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayOrders();
                        DisplayOrderDetails();
                    }
                    else
                    {
                        MessageBox.Show("該当する受注が見つかりません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("入力された値の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("受注の更新中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterOrder()
        {
            try
            {
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string tantoName = TBTantoName.Text;
                DateTime jyutyuDate = date.Value;
                string riyuu = TBRiyuu.Text;
                bool tyumonFlag = TyumonFlag.Checked;
                bool delFlag = DelFlag.Checked;

                // 条件精査
                if (!int.TryParse(shopID, out int parsedShopID) || shopID.Length > 2)
                {
                    MessageBox.Show("営業所IDは半角整数で、最大2桁でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(shainID, out int parsedShainID) || shainID.Length > 6)
                {
                    MessageBox.Show("社員IDは半角整数で、最大6桁でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(kokyakuID, out int parsedKokyakuID) || kokyakuID.Length > 6)
                {
                    MessageBox.Show("顧客IDは半角整数で、最大6桁でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (tantoName.Length > 50)
                {
                    MessageBox.Show("担当者名は最大50文字でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var context = new SalesManagementContext())

                {
                    
                    var newOrder = new TOrder
                    {
                        SoId = parsedShopID,
                        EmId = parsedShainID,
                        ClId = parsedKokyakuID,
                        ClCharge = tantoName,
                        OrDate = jyutyuDate,
                        OrStateFlag = tyumonFlag ? 2 : 0,
                        OrFlag = delFlag ? 1 : 0,
                        OrHidden = riyuu
                    };
                    context.TOrders.Add(newOrder);
                    context.SaveChanges();

                    if (TyumonFlag.Checked)
                    {
                        var orderDetailExists = context.TOrderDetails.Any(d => d.OrId == newOrder.OrId);
                        if (!orderDetailExists)
                        {
                            MessageBox.Show("受注詳細が登録されていません。");
                            return;
                        }
                        AcceptionConfirm(newOrder.OrId);
                    }
                    MessageBox.Show("登録が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayOrders();
                    DisplayOrderDetails();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("入力された値の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("受注の登録中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orders = checkBox_2.Checked
                      ? context.TOrders.ToList()  // チェックされていれば全ての注文を表示
                      : context.TOrders
                         .Where(o => o.OrFlag != 1 && o.OrStateFlag != 2)
                         .ToList();
                    // OrFlag が "1" または OrStateFlag が "2" でないものを取得
                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        受注ID = o.OrId,
                        営業所ID = o.SoId,
                        社員ID = o.EmId,
                        顧客ID = o.ClId,
                        担当社員名 = o.ClCharge,
                        受注日 = o.OrDate,
                        状態フラグ = o.OrStateFlag,
                        非表示フラグ = o.OrFlag,
                        非表示理由 = o.OrHidden
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
            try
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

                    // 受注日を検索条件に追加（チェックボックスがチェックされている場合）  
                    if (checkBoxDateFilter.Checked)
                    {
                        DateTime jyutyuDate = date.Value; // DateTimePickerからの値 
                        query = query.Where(o => o.OrDate.Date == jyutyuDate.Date);
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
                            担当社員名 = order.ClCharge,
                            受注日 = order.OrDate,
                            注文フラグ = TyumonFlag.Checked ? 1 : 0,
                            削除フラグ = DelFlag.Checked ? 1 : 0
                        }).ToList();
                    }
                    else
                    {
                        MessageBox.Show("該当する受注が見つかりません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("検索中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderDetails()
        {
            try
            {
                string jyutyuSyosaiID = TBJyutyuSyosaiID.Text;
                string jyutyuID = TBJyutyuIDS.Text;
                string syohinID = TBSyohinID.Text;
                string suryou = TBSuryou.Text;

                using (var context = new SalesManagementContext())
                {
                    var orderDetail = context.TOrderDetails.SingleOrDefault(od => od.OrDetailId.ToString() == jyutyuSyosaiID);
                    if (orderDetail != null)
                    {
                        orderDetail.OrId = int.Parse(jyutyuID);
                        orderDetail.PrId = int.Parse(syohinID);
                        orderDetail.OrQuantity = int.Parse(suryou);

                        context.SaveChanges();
                        MessageBox.Show("受注詳細の更新が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayOrderDetails();
                    }
                    else
                    {
                        MessageBox.Show("該当する受注詳細が見つかりません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("入力された値の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("受注詳細の更新中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterOrderDetails()
        {
            try
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
                        OrQuantity = int.Parse(suryou)
                    };

                    // 合計金額が入力されていない場合は自動で計算する
                    if (string.IsNullOrEmpty(goukeiKingaku))
                    {
                        // 商品の価格をMProductsから取得
                        var product = context.MProducts.SingleOrDefault(p => p.PrId == newOrderDetail.PrId);
                        if (product != null)
                        {
                            // 合計金額を計算
                            newOrderDetail.OrTotalPrice = product.Price * newOrderDetail.OrQuantity;
                        }
                        else
                        {
                            // 商品が見つからない場合の処理（適宜変更可能）
                            MessageBox.Show("該当する商品が見つかりません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;  // エラーが発生したため、処理を終了
                        }
                    }
                    else
                    {
                        // 入力された金額がある場合は、それを使用
                        newOrderDetail.OrTotalPrice = decimal.Parse(goukeiKingaku);
                    }

                    context.TOrderDetails.Add(newOrderDetail);
                    context.SaveChanges();
                    MessageBox.Show("受注詳細の登録が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayOrderDetails();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("入力された値の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("受注詳細の登録中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrderDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 受注詳細のリストを取得
                    var OrderDetails = context.TOrderDetails.ToList();

                    // 受注詳細の表示条件を設定（OrFlagが1またはOrStateFlagが2の受注IDを持つ受注詳細は非表示）
                    var visibleOrderDetails = checkBox_2.Checked
                        ? OrderDetails
                        : OrderDetails.Where(od =>
                        {
                            var Order = context.TOrders.FirstOrDefault(o => o.OrId == od.OrId);

                            return Order == null || (Order.OrFlag != 1 && Order.OrStateFlag != 2);
                        }).ToList();

                    // データグリッドに表示
                    dataGridView2.DataSource = visibleOrderDetails.Select(od => new
                    {
                        受注詳細ID = od.OrDetailId,
                        受注ID = od.OrId,
                        商品ID = od.PrId,
                        数量 = od.OrQuantity,
                        合計金額 = od.OrTotalPrice.ToString("N0")  // 3桁区切り 
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchOrderDetails()
        {
            try
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

                    if (!string.IsNullOrEmpty(syohinID) && int.TryParse(syohinID, out int productId))
                    {
                        // 商品IDを検索条件に追加 
                        query = query.Where(od => od.PrId == productId);
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
                        MessageBox.Show("該当する受注詳細が見つかりません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("受注詳細の検索中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleOrderSelection()
        {
            try
            {
                isOrderSelected = !isOrderSelected;
                orderFlag = isOrderSelected ? "←通常" : "詳細→";

                // CurrentStatusのモードを切り替える 
                CurrentStatus.SetMode(isOrderSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);
            }
            catch (Exception ex)
            {
                MessageBox.Show("選択状態の切り替え中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            try
            {
                // 状態を切り替える処理 
                ToggleOrderSelection();

                // b_FormSelectorのテキストを現在の状態に更新 
                UpdateFlagButtonText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ボタンのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFlagButtonText()
        {
            try
            {
                // b_FlagSelectorのテキストを現在の状態に合わせる 
                b_FormSelector.Text = orderFlag;
            }
            catch (Exception ex)
            {
                MessageBox.Show("フラグボタンのテキスト更新中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CellClickイベントハンドラ 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // クリックした行のインデックスを取得 
                int rowIndex = e.RowIndex;

                // 行インデックスが有効かどうかをチェック 
                if (rowIndex >= 0)
                {
                    // 行データを取得 
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    // 各テキストボックスにデータを入力 
                    TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString();
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                    TBTantoName.Text = row.Cells["担当社員名"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["受注日"].Value);

                    // 状態フラグと非表示フラグを取得
                    int orderFlag = Convert.ToInt32(row.Cells["状態フラグ"].Value);
                    int delFlag = Convert.ToInt32(row.Cells["非表示フラグ"].Value);

                    // チェックボックスの状態を設定
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // クリックした行のインデックスを取得  
                int rowIndex = e.RowIndex;

                // 行インデックスが有効かどうかをチェック  
                if (rowIndex >= 0)
                {
                    // 行データを取得  
                    DataGridViewRow row = dataGridView2.Rows[rowIndex];

                    // 各テキストボックスにデータを入力 
                    TBJyutyuSyosaiID.Text = row.Cells["受注詳細ID"].Value.ToString();
                    TBJyutyuIDS.Text = row.Cells["受注ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
                    TBGoukeiKingaku.Text = row.Cells["合計金額"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //注文に登録する部分
        private void AcceptionConfirm(int orderId)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言 
                var order = context.TOrders.SingleOrDefault(o => o.OrId == orderId);

                if (order == null)
                {
                    throw new Exception("受注IDが見つかりません。");
                }

                // 注文情報をTChumonに追加
                var newChumon = new TChumon
                {
                    SoId = order.SoId,  // 営業所ID    
                    EmId = order.EmId,
                    ClId = order.ClId,  // 顧客ID    
                    OrId = order.OrId,  // 受注ID 
                    ChDate = order.OrDate, // 注文日    
                    ChStateFlag = 0,
                    ChFlag = 0
                };

                try
                {
                    context.TChumons.Add(newChumon);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("TChumonへの登録に失敗しました: " + ex.Message);
                }

                var orderDetail = context.TOrderDetails.SingleOrDefault(o => o.OrId == orderId);
                var newChumonDetail = new TChumonDetail
                {
                    ChId = newChumon.ChId,
                    PrId = orderDetail.PrId,
                    ChQuantity = orderDetail.OrQuantity
                };
                try
                {
                    context.TChumonDetails.Add(newChumonDetail);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw new Exception("TChumonDetailへの登録に失敗しました:" + ex.Message);
                }
            }
        }
        


    }
}