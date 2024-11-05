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

            labelStatus.labelstatus(label2, b_kakutei);
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
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool OrderFlg = TyumonFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Orderdate = date.Value;
            CurrentStatus.ResetStatus(label2);



            using (var context = new SalesManagementContext())
            {
                var order = context.TOrders.SingleOrDefault(o => o.OrId.ToString() == JyutyuId);
                if (order != null)
                {
                    // 新しい注文情報を作成
                    var Order = new TOrder
                    {
                        SoId = int.Parse(ShopId),                    // 店舗ID
                        EmId = int.Parse(ShainId),// 社員ID（null許容）
                        ClId = int.Parse(KokyakuId),                 // クライアントID
                        OrId = int.Parse(JyutyuId),                       // 受注ID
                        OrDate = Orderdate,                         // 注文日
                        OrStateFlag = OrderFlg ? 1 : 0,             // 注文状態フラグ
                        OrFlag = DelFlg ? 1 : 0,                     // 削除フラグ
                        OrHidden = Riyuu                              // 理由
                    };

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する注文が見つかりません。");
                }
            }
        }



        private void RegisterOrder()
        {
            string OrderId = TBTyumonId.Text;
            string ShopId = TBShopId.Text;
            string ShainId = TBShainId.Text;
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool OrderFlg = TyumonFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Orderdate = date.Value;
            CurrentStatus.ResetStatus(label2);

            using (var context = new SalesManagementContext())
            {
                // 注文が既に存在するか確認
                var order = context.TOrders.SingleOrDefault(o => o.OrId.ToString() == OrderId);
                if (order == null)
                {
                    try
                    { // 新しい注文情報を作成
                        var newOrder = new TOrder
                        {
                            SoId = int.Parse(ShopId),                           // 店舗ID
                            EmId = int.Parse(ShainId), // 社員ID（null許容）
                            ClId = int.Parse(KokyakuId),                        // クライアントID
                            OrId = int.Parse(JyutyuId),                         // 受注ID
                            OrDate = Orderdate,                                // 注文日
                            OrStateFlag = OrderFlg ? 1 : 0,                    // 注文状態フラグ
                            OrFlag = DelFlg ? 1 : 0,                            // 削除フラグ
                            OrHidden = Riyuu
                        };

                        // 注文情報をコンテキストに追加
                        context.TOrders.Add(newOrder);


                        context.SaveChanges();
                        MessageBox.Show("登録が成功しました。");
                    }
                    catch (DbUpdateException ex)
                    {
                        // inner exception の詳細を表示する
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"エラーの詳細: {ex.InnerException.Message}");
                        }
                        else
                        {
                            MessageBox.Show("エンティティの変更を保存中にエラーが発生しました。");
                        }
                    }

                    catch (Exception ex)
                    {
                        // その他のエラーに対処する
                        MessageBox.Show($"エラーが発生しました: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("既に注文が存在しています。");
                }
            }
        }




        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orders = context.TOrders.ToList();

                    // データを選択してDataGridViewに表示
                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        TyumonID = o.OrId,            // 注文ID
                        StoreID = o.SoId,              // 店舗ID
                        EmployeeID = o.EmId,           // 社員ID
                        ClientID = o.ClId,             // クライアントID
                        JyutyuID = o.OrId,              // 受注ID
                        OrderDate = o.OrDate,        // 注文日
                        StateFlag = o.OrStateFlag,     // 注文状態フラグ
                        DeleteFlag = o.OrFlag,         // 削除フラグ
                        Reason = o.OrHidden            // 理由
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
                string nyuukaId = TBTyumonId.Text;
                string shopId = TBShopId.Text;
                string shainId = TBShainId.Text;
                string kokyakuId = TBKokyakuId.Text;
                string jyutyuId = TBJyutyuId.Text;
                DateTime? nyuukodate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TOrders.AsQueryable();

                // 注文IDを検索条件に追加
                if (!string.IsNullOrEmpty(nyuukaId))
                {
                    int arId = int.Parse(nyuukaId);
                    query = query.Where(order => order.OrId == arId);
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
                    query = query.Where(order => order.OrDate == nyuukodate.Value);
                }

                // 結果を取得
                var orders = query.ToList();

                if (orders.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = orders.Select(order => new
                    {
                        TyumonID = order.OrId,         // 注文ID
                        StoreID = order.SoId,           // 店舗ID
                        EmployeeID = order.EmId,        // 社員ID
                        ClientID = order.ClId,          // クライアントID
                        JyutyuID = order.OrId,           // 受注ID
                        OrderDate = order.OrDate,     // 注文日
                        StateFlag = order.OrStateFlag,  // 注文状態フラグ
                        DeleteFlag = order.OrFlag,      // 削除フラグ
                        Reason = order.OrHidden         // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する注文が見つかりません。");
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
                var orderDetail = context.TOrderDetails.SingleOrDefault(od => od.OrDetailId.ToString() == NyutyuSyosaiID);
                if (orderDetail != null)
                {
                    orderDetail.OrId = int.Parse(jyutyuID);
                    orderDetail.PrId = int.Parse(syohinID);
                    orderDetail.OrQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("注文詳細の更新が成功しました。");
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
            string jyutyuID = TBTyumonIDS.Text;
            string syohinID = TBSyohinId.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                var newOrderDetail = new TOrderDetail
                {
                    OrId = int.Parse(jyutyuID),
                    PrId = int.Parse(syohinID),
                    OrQuantity = int.Parse(suryou),
                };

                context.TOrderDetails.Add(newOrderDetail);
                context.SaveChanges();
                MessageBox.Show("注文詳細の登録が成功しました。");
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
                        注文詳細ID = od.OrDetailId,
                        注文ID = od.OrId,
                        商品ID = od.PrId,
                        数量 = od.OrQuantity,
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
                var query = context.TOrderDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(OrderSyosaiID))
                {
                    // 注文詳細IDを検索条件に追加
                    query = query.Where(od => od.OrDetailId.ToString() == OrderSyosaiID);
                }

                if (!string.IsNullOrEmpty(OrderIdS))
                {
                    //注文IDを検索条件に追加
                    query = query.Where(od => od.OrId.ToString() == OrderIdS);
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



                // 結果を取得
                var orderDetails = query.ToList();

                if (orderDetails.Any())
                {
                    dataGridView2.DataSource = orderDetails.Select(od => new
                    {
                        注文詳細ID = od.OrDetailId,
                        注文ID = od.OrId,
                        商品ID = od.PrId,
                        数量 = od.OrQuantity,
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void Orderflag_CheckedChanged(object sender, EventArgs e)
        {

        }


    }


}

