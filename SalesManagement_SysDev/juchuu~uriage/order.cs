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
    public partial class order : Form
    {
        private bool isOrderSelected = true; // 初期状態を注文(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス

        public order()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.Load += new EventHandler(order_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット


            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
        }


        private void order_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_acc,
                b_shi,
                b_sal,
                b_lss
            });

            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayOrders();
            DisplayOrderDetails();

            if (Global.PositionName == "管理者")
            {
                b_reg.Enabled = true;
            }
            else
            {
                b_reg.Enabled = false;
                b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            }
        }

        // メインメニューに戻る 
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        // 各ボタンでの画面遷移
        private void b_lss_Click(object sender, EventArgs e) => formChanger.NavigateToIssueForm();
        private void b_acc_Click(object sender, EventArgs e) => formChanger.NavigateToAcceptingOrderForm();
        private void b_shi_Click(object sender, EventArgs e) => formChanger.NavigateToShippingForm();
        private void b_sal_Click(object sender, EventArgs e) => formChanger.NavigateToSalesForm();
        private void b_arr_Click(object sender, EventArgs e) => formChanger.NavigateToArrivalForm();
        private void clear_Click(object sender, EventArgs e) => ClearText();

        private void ClearText()
        {
            TBTyumonId.Text = "";
            TBShopId.Text = "";
            TBShainId.Text = "";
            TBKokyakuId.Text = "";
            TBJyutyuId.Text = "";
            TyumonFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBTyumonSyosaiId.Text = "";
            TBTyumonIDS.Text = "";
            TBSuryou.Text = "";
            TBSyohinId.Text = "";
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

            DisplayOrderDetails();
            DisplayOrders();
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }
        private void b_kakutei_Click(object sender, EventArgs e)
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
            string OrderId = TBTyumonId.Text;
            string ShopId = TBShopId.Text;
            string ShainId = TBShainId.Text;
            string ChumonId = TBTyumonId.Text;
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool OrderFlg = TyumonFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Orderdate = date.Value;

            using (var context = new SalesManagementContext())
            {
                var order = context.TChumons.FirstOrDefault(o => o.ChId.ToString() == ChumonId);

                if (order != null)
                {
                    order.SoId = int.Parse(ShopId);
                    order.EmId = int.Parse(ShainId);
                    order.ClId = int.Parse(KokyakuId);
                    order.OrId = int.Parse(JyutyuId);
                    order.ChDate = Orderdate;
                    order.ChStateFlag = OrderFlg ? 2 : 0;
                    order.ChFlag = DelFlg ? 1 : 0;
                    order.ChHidden = Riyuu;

                    context.SaveChanges();
                    // checkBox_2のチェックがある場合、出庫処理へ
                    if (TyumonFlag.Checked)
                    {
                        var orderDetailExists = context.TChumonDetails.Any(d => d.ChId == int.Parse(ChumonId));
                        if (!orderDetailExists)
                        {
                            MessageBox.Show("注文詳細が登録されていません。出庫処理を実行できません。");
                            return;
                        }

                        var details = context.TChumonDetails.Where(d => d.ChId == int.Parse(ChumonId)).ToList();
                        foreach (var detail in details)
                        {
                            var stock = context.TStocks.SingleOrDefault(s => s.PrId == detail.PrId);
                            if (stock == null || stock.StQuantity < detail.ChQuantity)
                            {
                                // 在庫が不足している場合
                                var shortageQuantity = detail.ChQuantity - (stock?.StQuantity ?? 0);

                                // 発注処理を行う
                                ProductOrder(int.Parse(OrderId), int.Parse(ChumonId), shortageQuantity);
                                // メッセージを表示
                                MessageBox.Show($"商品ID: {detail.PrId}の在庫が不足しているため発注処理を行いました。");
                                return; // 発注処理後、更新処理を終了
                            }
                            else
                            {
                                // 在庫が足りている場合、出庫処理
                                stock.StQuantity -= detail.ChQuantity;
                                MessageBox.Show($"商品ID: {detail.PrId}、残り在庫: {stock.StQuantity}");
                                OrdersConfirm(int.Parse(OrderId), int.Parse(ChumonId));

                            }
                        }

                        // 出庫処理が完了した場合、注文情報を保存
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("出庫登録が完了しました。");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出庫処理の保存に失敗しました: " + ex.Message);
                        }

                    }
                    else
                    {
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("注文更新が成功しました。");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("更新処理に失敗しました: " + ex.Message);
                        }
                    }

                    DisplayOrders(); // 注文情報を表示
                }
                else
                {
                    MessageBox.Show("該当する注文情報が見つかりません。");
                }
            }
        }


        private void RegisterOrder()
        {
            string ShopId = TBShopId.Text;
            string ShainId = TBShainId.Text;
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool OrderFlg = TyumonFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Orderdate = date.Value;

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (!int.TryParse(ShopId, out shop) || !context.MSalesOffices.Any(s => s.SoId == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。");
                    return;
                }

                int employeeId;
                if (!int.TryParse(ShainId, out employeeId) || !context.MEmployees.Any(e => e.EmId == employeeId))
                {
                    MessageBox.Show("社員IDが存在しません。");
                    return;
                }

                int kokyaku;
                if (!int.TryParse(KokyakuId, out kokyaku) || !context.MClients.Any(k => k.ClId == kokyaku))
                {
                    MessageBox.Show("顧客IDが存在しません。");
                    return;
                }

                int juchu;
                if (!int.TryParse(JyutyuId, out juchu) || !context.TOrders.Any(j => j.OrId == juchu))
                {
                    MessageBox.Show("受注IDが存在しません。");
                    return;
                }

                // 注文が存在しない場合、新規作成
                var order = context.TChumons.SingleOrDefault(o => o.OrId == int.Parse(JyutyuId));
                if (order == null)
                {
                    try
                    {
                        var newOrder = new TChumon
                        {
                            SoId = int.Parse(ShopId),
                            EmId = int.Parse(ShainId),
                            ClId = int.Parse(KokyakuId),
                            OrId = int.Parse(JyutyuId),
                            ChDate = Orderdate,
                            ChStateFlag = OrderFlg ? 2 : 0,
                            ChFlag = DelFlg ? 1 : 0,
                            ChHidden = Riyuu
                        };

                        context.TChumons.Add(newOrder);
                        context.SaveChanges(); // 保存後に自動で ChId が設定される

                        // 新規登録した注文の ChId を取得
                        int newChId = newOrder.ChId;

                        // 注文詳細が登録されていなければ出庫処理は行わない
                        if (TyumonFlag.Checked)
                        {
                            var orderDetailExists = context.TChumonDetails.Any(d => d.ChId == newChId);
                            if (!orderDetailExists)
                            {
                                MessageBox.Show("注文詳細が登録されていません。");
                                return;
                            }

                            var details = context.TChumonDetails.Where(d => d.ChId == newChId).ToList();
                            foreach (var detail in details)
                            {
                                var stock = context.TStocks.SingleOrDefault(s => s.PrId == detail.PrId);
                                if (stock == null)
                                {
                                    MessageBox.Show($"商品ID: {detail.PrId} が存在しません。");
                                    return;
                                }

                                // 在庫確認、足りない場合は発注処理を行う
                                int remainingStock = stock.StQuantity - detail.ChQuantity;
                                if (remainingStock < 0)
                                {
                                    // 在庫が足りない場合、発注処理を行う
                                    int shortageQuantity = Math.Abs(remainingStock); // 足りない数量
                                    ProductOrder(newOrder.OrId, newOrder.ChId, shortageQuantity);
                                    MessageBox.Show($"商品ID: {detail.PrId} の在庫が{shortageQuantity}個の不足しています。発注処理を行いました。");
                                    return; // 発注後に処理を終了
                                }
                                else
                                {
                                    // 在庫が足りている場合は出庫処理
                                    stock.StQuantity -= detail.ChQuantity;
                                    MessageBox.Show($"商品ID: {detail.PrId}, 残り在庫: {stock.StQuantity}"); // 残り在庫を表示
                                }
                            }

                            OrdersConfirm(int.Parse(JyutyuId), newOrder.ChId);
                            MessageBox.Show("出庫登録が完了しました。");
                        }
                        else
                        {
                            MessageBox.Show("登録が成功しました。");
                        }

                        DisplayOrders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"エラーが発生しました: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("既に注文情報が存在しています。");
                }
            }
        }




        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示 
                    var chumons = checkBox_2.Checked
                        ? context.TChumons.ToList()  // チェックされていれば全ての注文を表示 
                        : context.TChumons
                            .Where(o => o.ChFlag != 1 && o.ChStateFlag != 2)
                            .ToList();



                    // データを選択してDataGridViewに表示 
                    dataGridView1.DataSource = chumons.Select(o => new
                    {
                        注文ID = o.ChId,           // 注文ID 
                        営業所ID = o.SoId,         // 営業所ID 
                        社員ID = o.EmId,           // 社員ID 
                        顧客ID = o.ClId,           // 顧客ID 
                        受注ID = o.OrId,           // 受注ID 
                        注文日 = o.ChDate,         // 注文日 
                        状態フラグ = o.ChStateFlag,// 注文状態フラグ 
                        非表示フラグ = o.ChFlag,  // 削除フラグ 
                        非表示理由 = o.ChHidden  // 非表示理由 
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
                string tyumonId = TBTyumonId.Text;
                string shopId = TBShopId.Text;
                string shainId = TBShainId.Text;
                string kokyakuId = TBKokyakuId.Text;
                string jyutyuId = TBJyutyuId.Text;
                DateTime? nyuukodate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TChumons.AsQueryable();

                // 注文IDを検索条件に追加
                if (!string.IsNullOrEmpty(tyumonId))
                {
                    int chId = int.Parse(tyumonId);
                    query = query.Where(order => order.ChId == chId);
                }

                // 店舗IDを検索条件に追加
                if (!string.IsNullOrEmpty(shopId))
                {
                    int soId = int.Parse(shopId);
                    query = query.Where(order => order.SoId == soId);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainId))
                {
                    int emId = int.Parse(shainId);
                    query = query.Where(order => order.EmId == emId);
                }

                // 顧客IDを検索条件に追加
                if (!string.IsNullOrEmpty(kokyakuId))
                {
                    int clId = int.Parse(kokyakuId);
                    query = query.Where(order => order.ClId == clId);
                }

                // 受注IDを検索条件に追加
                if (!string.IsNullOrEmpty(jyutyuId))
                {
                    int orId = int.Parse(jyutyuId);
                    query = query.Where(order => order.OrId == orId);
                }

                // 注文日を検索条件に追加（チェックボックスがチェックされている場合）
                if (nyuukodate.HasValue)
                {
                    query = query.Where(order => order.ChDate == nyuukodate.Value);
                }

                // 結果を取得
                var orders = query.ToList();

                if (orders.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        注文ID = o.ChId,            // 注文ID
                        営業所ID = o.SoId,              // 店舗ID
                        社員ID = o.EmId,           // 社員ID
                        顧客ID = o.ClId,             // クライアントID
                        受注ID = o.OrId,              // 受注ID
                        注文日 = o.ChDate,        // 注文日
                        状態フラグ = o.ChStateFlag,     // 注文状態フラグ
                        非表示フラグ = o.ChFlag,         // 削除フラグ
                        非表示理由 = o.ChHidden            // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する注文情報が見つかりません。");
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }




        private void UpdateOrderDetails()
        {
            string NyutyuSyosaiID = TBTyumonSyosaiId.Text;
            string jyutyuID = TBTyumonIDS.Text;
            string syohinID = TBSyohinId.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                var orderDetail = context.TChumonDetails.SingleOrDefault(od => od.ChDetailId.ToString() == NyutyuSyosaiID);
                if (orderDetail != null)
                {
                    orderDetail.ChId = int.Parse(jyutyuID);
                    orderDetail.PrId = int.Parse(syohinID);
                    orderDetail.ChQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("注文詳細の更新が成功しました。");
                    DisplayOrderDetails();
                }
                else
                {
                    MessageBox.Show("該当する注文詳細が見つかりません。");
                }
            }
        }

        private void RegisterOrderDetails()
        {
            string OrderSyosaiID = TBTyumonSyosaiId.Text;
            string chuumon = TBTyumonIDS.Text;
            string syohinID = TBSyohinId.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                int tyuumon;
                if (!int.TryParse(chuumon, out tyuumon) || !context.TChumons.Any(s => s.ChId == tyuumon))
                {
                    MessageBox.Show("注文IDが存在しません。");
                    return;
                }
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrId == shouhin))
                {
                    MessageBox.Show("商品IDが存在しません。");
                    return;
                }
                var newOrderDetail = new TChumonDetail
                {
                    ChId = int.Parse(chuumon),
                    PrId = int.Parse(syohinID),
                    ChQuantity = int.Parse(suryou),
                };

                context.TChumonDetails.Add(newOrderDetail);
                context.SaveChanges();
                MessageBox.Show("注文詳細の登録が成功しました。");
                DisplayOrderDetails();
            }
        }

        private void DisplayOrderDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var ChumonDetails = context.TChumonDetails.ToList();

                    // checkBox_2がチェックされている場合、フィルタリングを無視してすべての詳細を表示
                    var visibleChumonDetails = checkBox_2.Checked
                        ? ChumonDetails
                        : ChumonDetails.Where(od =>
                        {
                            var Chumon = context.TChumons.FirstOrDefault(o => o.ChId == od.ChId);

                            return Chumon == null || (Chumon.ChFlag != 1 && Chumon.ChStateFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleChumonDetails.Select(od => new
                    {
                        注文詳細ID = od.ChDetailId,
                        注文ID = od.ChId,
                        商品ID = od.PrId,
                        数量 = od.ChQuantity,
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
                var OrderSyosaiID = TBTyumonSyosaiId.Text;
                var OrderIdS = TBTyumonIDS.Text;
                var syohinID = TBSyohinId.Text;
                var suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.TChumonDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(OrderSyosaiID))
                {
                    // 注文詳細IDを検索条件に追加
                    query = query.Where(od => od.ChDetailId.ToString() == OrderSyosaiID);
                }

                if (!string.IsNullOrEmpty(OrderIdS))
                {
                    //注文IDを検索条件に追加
                    query = query.Where(od => od.ChId.ToString() == OrderIdS);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrId.ToString() == syohinID);
                }

                if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                {
                    // 数量を検索条件に追加
                    query = query.Where(od => od.ChQuantity == quantity);
                }



                // 結果を取得
                var orderDetails = query.ToList();

                if (orderDetails.Any())
                {
                    dataGridView2.DataSource = orderDetails.Select(od => new
                    {
                        注文詳細ID = od.ChDetailId,
                        注文ID = od.ChId,
                        商品ID = od.PrId,
                        数量 = od.ChQuantity,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する注文詳細が見つかりません。");
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

        // CellClickイベントハンドラ
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                    TBTyumonId.Text = row.Cells["注文ID"].Value.ToString();
                    TBShopId.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainId.Text = row.Cells["社員ID"].Value.ToString();
                    TBKokyakuId.Text = row.Cells["顧客ID"].Value.ToString();
                    TBJyutyuId.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["注文日"].Value);
                    // 注文状態や非表示ボタン、非表示理由も必要に応じて設定
                    // 非表示ボタンや非表示理由もここで設定
                    // 例: hiddenButton.Text = row.Cells["非表示ボタン"].Value.ToString();
                    // 例: hiddenReason.Text = row.Cells["非表示理由"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // クリックした行のインデックスを取得 
            int rowIndex = e.RowIndex;

            // 行インデックスが有効かどうかをチェック 
            if (rowIndex >= 0)
            {
                // 行データを取得 
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                // 各テキストボックスにデータを入力
                TBTyumonSyosaiId.Text = row.Cells["注文詳細ID"].Value.ToString();
                TBTyumonIDS.Text = row.Cells["注文ID"].Value.ToString();
                TBSyohinId.Text = row.Cells["商品ID"].Value.ToString();
                TBSuryou.Text = row.Cells["数量"].Value.ToString();
            }
        }

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
                    TBTyumonId.Text = row.Cells["注文ID"].Value.ToString();
                    TBShopId.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainId.Text = row.Cells["社員ID"].Value.ToString();
                    TBKokyakuId.Text = row.Cells["顧客ID"].Value.ToString();
                    TBJyutyuId.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["注文日"].Value);
                    // 注文状態や非表示ボタン、非表示理由も必要に応じて設定
                    // 非表示ボタンや非表示理由もここで設定
                    // 例: hiddenButton.Text = row.Cells["非表示ボタン"].Value.ToString();
                    // 例: hiddenReason.Text = row.Cells["非表示理由"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // クリックした行のインデックスを取得 
            int rowIndex = e.RowIndex;

            // 行インデックスが有効かどうかをチェック 
            if (rowIndex >= 0)
            {
                // 行データを取得 
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                // 各テキストボックスにデータを入力
                TBTyumonSyosaiId.Text = row.Cells["注文詳細ID"].Value.ToString();
                TBTyumonIDS.Text = row.Cells["注文ID"].Value.ToString();
                TBSyohinId.Text = row.Cells["商品ID"].Value.ToString();
                TBSuryou.Text = row.Cells["数量"].Value.ToString();
            }
        }

        private void OrdersConfirm(int JyutyuId, int ChId)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                var order = context.TChumons.SingleOrDefault(o => o.ChId == ChId);

                if (order == null)
                {
                    throw new Exception("注文IDが見つかりません。");
                }


                // 出庫情報をTSyukkoに追加
                var newSyukko = new TSyukko
                {
                    SoId = order.SoId,
                    EmId = order.EmId,
                    ClId = order.ClId,
                    OrId = order.OrId,
                    SyDate = order.ChDate,
                    SyStateFlag = 0
                };

                try
                {
                    // データが正しいか事前にチェック
                    if (newSyukko.SoId == 0 || newSyukko.EmId == 0 || newSyukko.ClId == 0 || newSyukko.OrId == 0 || newSyukko.SyDate == default(DateTime))
                    {
                        throw new Exception("出庫情報に必要なデータが不足しています。");
                    }
                    context.TSyukkos.Add(newSyukko);
                    context.SaveChanges();
                    MessageBox.Show("出庫登録が完了しました。"); // ここでメッセージが表示されることを確認
                }
                catch (Exception ex)
                {
                    throw new Exception("TSyukkoへの登録に失敗しました: " + ex.Message);
                }

                var orderDetail = context.TOrderDetails.FirstOrDefault(o => o.OrId == order.OrId);
                if (orderDetail == null)
                {
                    throw new Exception("注文詳細が見つかりません。");
                }

                var chumonDetail = context.TChumonDetails.SingleOrDefault(o => o.ChId == ChId);
                if (chumonDetail == null)
                {
                    throw new Exception("注文詳細（ChId）が見つかりません。");
                }

                var newSyukkoDetail = new TSyukkoDetail
                {
                    SyId = newSyukko.SyId,
                    PrId = orderDetail.PrId,
                    SyQuantity = chumonDetail.ChQuantity
                };

                try
                {
                    context.TSyukkoDetails.Add(newSyukkoDetail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("TSyukkoDetailへの登録に失敗しました: " + ex.Message);
                }
            }
        }
        // 発注処理のやつ 
        private void ProductOrder(int OrId, int ChId, int shortageQuantity)
        {
            MessageBox.Show("発注登録を開始します");
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 注文データの取得
                    var order = context.TChumons.SingleOrDefault(o => o.ChId == ChId);
                    if (order == null)
                    {
                        MessageBox.Show("注文情報が見つかりません。発注処理を中止します。");
                        return;
                    }

                    // 注文詳細データの取得
                    var orderDetail = context.TChumonDetails.SingleOrDefault(o => o.ChId == ChId);
                    if (orderDetail == null)
                    {
                        MessageBox.Show("注文詳細情報が見つかりません。発注処理を中止します。");
                        return;
                    }

                    int prId = orderDetail.PrId;

                    // 商品データの取得
                    var product = context.MProducts.SingleOrDefault(p => p.PrId == prId);
                    if (product == null)
                    {
                        MessageBox.Show("指定された商品情報が見つかりません。発注処理を中止します。");
                        return;
                    }


                    // 新しい発注情報の登録
                    var newHattyu = new THattyu
                    {
                        MaId = product.MaId,
                        EmId = int.Parse(order.EmId.ToString()),
                        HaDate = order.ChDate.Value,
                        WaWarehouseFlag = 0,
                        HaFlag = 0,
                        HaHidden = null,
                    };

                    context.THattyus.Add(newHattyu);
                    context.SaveChanges();

                    // 新しい発注詳細情報の登録
                    var newHattyuDetail = new THattyuDetail
                    {
                        HaId = newHattyu.HaId,
                        PrId = orderDetail.PrId,
                        HaQuantity = shortageQuantity,
                    };

                    context.THattyuDetails.Add(newHattyuDetail);
                    context.SaveChanges();

                    MessageBox.Show("登録が完了しました");

                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("データの取得に失敗しました: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("データの形式が正しくありません: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期しないエラーが発生しました: " + ex.Message);
            }
        }

    }
}

