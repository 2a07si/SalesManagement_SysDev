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
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using SalesManagement_SysDev.Entity;
using static SalesManagement_SysDev.Classまとめ.StockManager;

namespace SalesManagement_SysDev
{
    public partial class order : Form
    {
        string empID = GlobalEmp.EmployeeID;
        private bool isOrderSelected = true; // 初期状態を注文(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス


        private int lastFocusedPanelID = 1;
        public order()
        {

            InitializeComponent();
            StockManager.InitializeSafetyStock();
            this.formChanger = new ClassChangeForms(this);
            this.Load += new EventHandler(order_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット


            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);

            // パネル1とパネル2のコントロールにイベントを設定
            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel3, 2);  // パネル2の場合
        }


        private void order_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_acc,
                b_shi,
                b_sal,
                b_iss
            });

            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayOrders();
            DisplayOrderDetails();
            TyumonFlag.Enabled = false;
　          b_reg.Enabled = false;
            b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            SetupNumericOnlyTextBoxes();
            CurrentStatus.UpDateStatus(label2);
            UpdateTextBoxState(checkBoxSyain.Checked);

        }
        // メインメニューに戻る 
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        // 各ボタンでの画面遷移
        private void b_iss_Click(object sender, EventArgs e) => formChanger.NavigateToIssueForm();
        private void b_acc_Click(object sender, EventArgs e) => formChanger.NavigateToAcceptingOrderForm();
        private void b_shi_Click(object sender, EventArgs e) => formChanger.NavigateToShippingForm();
        private void b_sal_Click(object sender, EventArgs e) => formChanger.NavigateToSalesForm();
        private void b_arr_Click(object sender, EventArgs e) => formChanger.NavigateToArrivalForm();
        private void clear_Click(object sender, EventArgs e) => ClearText();

        private void ClearText()
        {
            TBTyumonID.Text = "";
            TBShopID.Text = "";
            TBShainID.Text = "";
            TBKokyakuID.Text = "";
            TBJyutyuID.Text = "";
            TyumonFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBTyumonSyosaiID.Text = "";
            TBTyumonIDS.Text = "";
            TBSuryou.Text = "";
            TBSyohinID.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            tbtrue();
            dateCheckBox.Checked = false;
            checkBox_2.Checked = false;
            colorReset();
        }
        private void b_ser_Click(object sender, EventArgs e)
        {
            PerformSearch();
            tbtrue();
            TyumonFlag.Enabled = false;
        }
        private void PerformSearch()
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            UpdateStatus();
            tbtrue();
            TyumonFlag.Enabled = false;
        }
        private void UpdateStatus()
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            RegisterStatus();
            tbfalse();
            TyumonFlag.Enabled = true;
        }

        private void RegisterStatus()
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            ListStatus();
            tbtrue();
            TyumonFlag.Enabled = false;
        }
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

        private void tbfalse()
        {
            TBTyumonID.Enabled = false;
            TBTyumonSyosaiID.Enabled = false;
            TBTyumonID.BackColor = Color.Gray;
            TBTyumonSyosaiID.BackColor = Color.Gray;
            TBTyumonID.Text = "";
            TBTyumonSyosaiID.Text = "";
        }
        private void tbtrue()
        {
            TBTyumonID.Enabled = true;
            TBTyumonSyosaiID.Enabled = true;
            TBTyumonID.BackColor = Color.White;
            TBTyumonSyosaiID.BackColor = Color.White;
        }
        private void b_kakutei_Click(object sender, EventArgs e)
        {

            try
            {
                // モードに基づいて処理を分岐
                switch (CurrentStatus.CurrentMode)
                {
                    case CurrentStatus.Mode.通常:
                        colorReset();
                        HandleOrderOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        colorReset();
                        HandleOrderDetailOperation();
                        break;
                    default:
                        MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void UpdateOrder()
        {
            string OrderID = TBTyumonID.Text;
            string ShopID = TBShopID.Text;
            string ShainID = TBShainID.Text;
            string ChumonID = TBTyumonID.Text;
            string KokyakuID = TBKokyakuID.Text;
            string JyutyuID = TBJyutyuID.Text;
            bool OrderFlg = TyumonFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Orderdate = date.Value;

            if (TBTyumonID.Text == "")
            {
                TBTyumonID.BackColor = Color.Yellow;
                TBTyumonID.Focus();
                MessageBox.Show("注文IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShopID.Text == "")
            {
                TBShopID.BackColor = Color.Yellow;
                TBShopID.Focus();
                MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShainID.Text == "")
            {
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBKokyakuID.Text == "")
            {
                TBKokyakuID.BackColor = Color.Yellow;
                TBKokyakuID.Focus();
                MessageBox.Show("顧客IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBJyutyuID.Text == "")
            {
                TBJyutyuID.BackColor = Color.Yellow;
                TBJyutyuID.Focus();
                MessageBox.Show("受注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   
            if (TBShainID.Text != empID)
            {
                MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                return;
            }
            if (date.Value > DateTime.Today)
            {
                var result = MessageBox.Show(
                    "注文" +
                    "日が未来を指していますが、よろしいですか？",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return; // 処理を中断
                }
            }

            using (var context = new SalesManagementContext())
            {
                int chumon;
                if (!int.TryParse(OrderID, out chumon) || !context.TChumons.Any(s => s.ChID == chumon))
                {
                    TBTyumonID.BackColor = Color.Yellow;
                    TBTyumonID.Focus();
                    MessageBox.Show("注文IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int shop;
                if (!int.TryParse(ShopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int employeeID;
                if (!int.TryParse(ShainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kokyaku;
                if (!int.TryParse(KokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    TBKokyakuID.BackColor = Color.Yellow;
                    TBKokyakuID.Focus();
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int juchu;
                if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    TBJyutyuID.BackColor = Color.Yellow;
                    TBJyutyuID.Focus();
                    MessageBox.Show("受注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var order = context.TChumons.FirstOrDefault(o => o.ChID.ToString() == ChumonID);


                if (order != null)
                {
                    order.SoID = int.Parse(ShopID);
                    order.EmID = int.Parse(ShainID);
                    order.ClID = int.Parse(KokyakuID);
                    order.OrID = int.Parse(JyutyuID);
                    order.ChDate = Orderdate;
                    order.ChStateFlag = OrderFlg ? 2 : 0;
                    order.ChFlag = DelFlg ? 1 : 0;
                    order.ChHidden = Riyuu;

                    context.SaveChanges();
                    // checkBox_2のチェックがある場合、出庫処理へ 
                    if (TyumonFlag.Checked)
                    {
                        // 受注IDの重複チェック
                        bool isDuplicate = context.TSyukkos.Any(c => c.OrID == order.OrID);
                        if (isDuplicate)
                        {
                            MessageBox.Show($"この受注ID ({order.OrID}) は既に登録されています。更新を中止します。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // 更新処理を中止
                        }
                        var orderDetailExists = context.TChumonDetails.Any(d => d.ChID == int.Parse(ChumonID));
                        if (!orderDetailExists)
                        {
                            MessageBox.Show("注文詳細が登録されていません。出庫処理を実行できません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        var details = context.TChumonDetails.Where(d => d.ChID == int.Parse(ChumonID)).ToList();
                        foreach (var detail in details)
                        {
                            var stock = context.TStocks.FirstOrDefault(s => s.PrID == detail.PrID);
                            if (stock == null || stock.StQuantity < detail.ChQuantity)
                            {
                                // 在庫が不足している場合 
                                var shortageQuantity = detail.ChQuantity - (stock?.StQuantity ?? 0);
                                stock.StQuantity -= detail.ChQuantity;
                                // 発注処理を行う 
                                Checker(order.OrID, shortageQuantity);
                                ProductOrder(int.Parse(OrderID), int.Parse(ChumonID), shortageQuantity);


                                MessageBox.Show($"商品ID: {detail.PrID}の在庫が不足しているため発注処理を行いました。");

                                // 非表示フラグと理由を設定して出庫登録 
                                OrdersConfirm(int.Parse(OrderID), int.Parse(ChumonID), 1, "在庫不足のため非表示中");
                            }
                            else
                            {

                                // 在庫が足りている場合、出庫処理 
                                stock.StQuantity -= detail.ChQuantity;
                                MessageBox.Show($"商品ID: {detail.PrID}、残り在庫: {stock.StQuantity}");
                                OrdersConfirm(int.Parse(OrderID), int.Parse(ChumonID), 0, null);
                                StockManager.CompareStock(detail.PrID, stock.StQuantity);

                            }
                        }
                        var orders = context.TChumons;
                        order.ChFlag = 1;
                        order.ChHidden = "注文処理確定済";
                        Log_Order(order.OrID);
                        // 出庫処理が完了した場合、注文情報を保存 
                        try
                        {
                            context.SaveChanges();
                            DisplayOrders();
                            DisplayOrderDetails();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出庫処理の保存に失敗しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("注文更新が成功しました。");
                            DisplayOrders();
                            DisplayOrderDetails();

                            Log_Order(order.OrID);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("更新処理に失敗しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    DisplayOrders(); // 注文情報を表示 
                }
                else
                {
                    MessageBox.Show("該当する注文情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            countFlag();
            FlagCount();
        }

        private void RegisterOrder()
        {
            string ShopID = TBShopID.Text;
            string ShainID = TBShainID.Text;
            string KokyakuID = TBKokyakuID.Text;
            string JyutyuID = TBJyutyuID.Text;
            bool OrderFlg = TyumonFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Orderdate = date.Value;

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (TBShopID.Text == "")
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBShainID.Text == "")
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBKokyakuID.Text == "")
                {
                    TBKokyakuID.BackColor = Color.Yellow;
                    TBKokyakuID.Focus();
                    MessageBox.Show("顧客IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBJyutyuID.Text == "")
                {
                    TBJyutyuID.BackColor = Color.Yellow;
                    TBJyutyuID.Focus();
                    MessageBox.Show("受注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(ShopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int employeeID;
                if (!int.TryParse(ShainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kokyaku;
                if (!int.TryParse(KokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    TBKokyakuID.BackColor = Color.Yellow;
                    TBKokyakuID.Focus();
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int juchu;
                if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    TBJyutyuID.BackColor = Color.Yellow;
                    TBJyutyuID.Focus();
                    MessageBox.Show("受注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (TBShainID.Text != empID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }
                if (date.Value < DateTime.Now)
                {
                    var result = MessageBox.Show(
                        "受注年月日が未来を指していますが、よろしいですか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return; // 処理を中断
                    }
                }

                // 注文が存在しない場合、新規作成 
                var order = context.TChumons.SingleOrDefault(o => o.OrID == int.Parse(JyutyuID));
                if (order == null)
                {
                    try
                    {
                        var newOrder = new TChumon
                        {
                            SoID = int.Parse(ShopID),
                            EmID = int.Parse(ShainID),
                            ClID = int.Parse(KokyakuID),
                            OrID = int.Parse(JyutyuID),
                            ChDate = Orderdate,
                            ChStateFlag = OrderFlg ? 2 : 0,
                            ChFlag = DelFlg ? 1 : 0,
                            ChHidden = Riyuu
                        };

                        context.TChumons.Add(newOrder);
                        context.SaveChanges(); // 保存後に自動で ChID が設定される 
                        Log_Order(newOrder.OrID);

                        // 新規登録した注文の ChID を取得 
                        int newChID = newOrder.ChID;

                        // 注文詳細が登録されていなければ出庫処理は行わない 
                        if (TyumonFlag.Checked)
                        {
                            var orderDetailExists = context.TChumonDetails.Any(d => d.ChID == newChID);
                            if (!orderDetailExists)
                            {
                                MessageBox.Show("注文詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            var details = context.TChumonDetails.Where(d => d.ChID == newChID).ToList();
                            bool isStockSufficient = true; // 初期状態で在庫が足りていると仮定

                            foreach (var detail in details)
                            {
                                var stock = context.TStocks.SingleOrDefault(s => s.PrID == detail.PrID);
                                if (stock == null)
                                {
                                    TBSyohinID.BackColor = Color.White;
                                    TBSyohinID.Focus();
                                    MessageBox.Show($"商品ID: {detail.PrID} が存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // 在庫確認、足りない場合は発注処理を行う 
                                int remainingStock = stock.StQuantity - detail.ChQuantity;
                                if (remainingStock < 0)
                                {
                                    // 在庫が足りない場合、発注処理を行う 
                                    int shortageQuantity = Math.Abs(remainingStock); // 足りない数量 
                                    ProductOrder(newOrder.OrID, newOrder.ChID, shortageQuantity);
                                    MessageBox.Show($"商品ID: {detail.PrID} の在庫が{shortageQuantity}個の不足しています。発注処理を行いました。");

                                    // 在庫不足が発生したので非表示設定で出庫登録
                                    isStockSufficient = false;
                                }
                                else
                                {
                                    // 在庫が足りている場合は出庫処理 
                                    stock.StQuantity -= detail.ChQuantity;
                                    MessageBox.Show($"商品ID: {detail.PrID}, 残り在庫: {stock.StQuantity}"); // 残り在庫を表示 
                                }
                            }

                            // 在庫の状況に応じて出庫処理を実行
                            if (isStockSufficient)
                            {
                                OrdersConfirm(int.Parse(JyutyuID), newOrder.ChID, 0, null); // 在庫が足りている場合
                            }
                            else
                            {
                                OrdersConfirm(int.Parse(JyutyuID), newOrder.ChID, 1, "在庫不足のため非表示中"); // 在庫不足の場合
                            }

                            MessageBox.Show("出庫登録が完了しました。");
                        }
                        else
                        {
                            MessageBox.Show("登録が成功しました。");
                        }

                        DisplayOrders();
                        DisplayOrderDetails();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("エラー: " + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("既に注文情報が存在しています。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        注文ID = o.ChID,           // 注文ID 
                        営業所ID = o.SoID,         // 営業所ID 
                        社員ID = o.EmID,           // 社員ID 
                        顧客ID = o.ClID,           // 顧客ID 
                        受注ID = o.OrID,           // 受注ID 
                        注文日 = o.ChDate,         // 注文日 
                        状態フラグ = o.ChStateFlag,// 注文状態フラグ 
                        非表示フラグ = o.ChFlag,  // 削除フラグ 
                        非表示理由 = o.ChHidden  // 非表示理由 
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SearchOrders()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                string tyumonID = TBTyumonID.Text;
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string JyutyuID = TBJyutyuID.Text;
                DateTime? nyuukodate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TChumons.AsQueryable();

                // 注文IDを検索条件に追加
                if (!string.IsNullOrEmpty(tyumonID))
                {
                    int chID = int.Parse(tyumonID);
                    query = query.Where(order => order.ChID == chID);
                }

                // 店舗IDを検索条件に追加
                if (!string.IsNullOrEmpty(shopID))
                {
                    int soID = int.Parse(shopID);
                    query = query.Where(order => order.SoID == soID);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainID))
                {
                    int emID = int.Parse(shainID);
                    query = query.Where(order => order.EmID == emID);
                }

                // 顧客IDを検索条件に追加
                if (!string.IsNullOrEmpty(kokyakuID))
                {
                    int clID = int.Parse(kokyakuID);
                    query = query.Where(order => order.ClID == clID);
                }

                // 受注IDを検索条件に追加
                if (!string.IsNullOrEmpty(JyutyuID))
                {
                    int orID = int.Parse(JyutyuID);
                    query = query.Where(order => order.OrID == orID);
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
                        注文ID = o.ChID,            // 注文ID
                        営業所ID = o.SoID,              // 店舗ID
                        社員ID = o.EmID,           // 社員ID
                        顧客ID = o.ClID,             // クライアントID
                        受注ID = o.OrID,              // 受注ID
                        注文日 = o.ChDate,        // 注文日
                        状態フラグ = o.ChStateFlag,     // 注文状態フラグ
                        非表示フラグ = o.ChFlag,         // 削除フラグ
                        非表示理由 = o.ChHidden            // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する注文情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }

        private void UpdateOrderDetails()
        {
            string TyumonSyosaiID = TBTyumonSyosaiID.Text;
            string TyumonID = TBTyumonIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            if (TBTyumonSyosaiID.Text == null)
            {
                TBTyumonSyosaiID.BackColor = Color.Yellow;
                TBTyumonSyosaiID.Focus();
                MessageBox.Show("注文詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBTyumonIDS.Text == null)
            {
                TBTyumonIDS.BackColor = Color.Yellow;
                TBTyumonIDS.Focus();
                MessageBox.Show("注文IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (TBSyohinID.Text == null)
            {
                TBSyohinID.BackColor = Color.Yellow;
                TBSyohinID.Focus();
                MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSuryou.Text == null)
            {
                TBSuryou.BackColor = Color.Yellow;
                TBSyohinID.Focus();
                MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {
                int syousai;
                if (!int.TryParse(TyumonSyosaiID, out syousai) || !context.TChumonDetails.Any(s => s.ChDetailID == syousai))
                {
                    TBTyumonSyosaiID.BackColor = Color.Yellow;
                    TBTyumonSyosaiID.Focus();
                    MessageBox.Show("注文IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int tyuumon;
                if (!int.TryParse(TyumonID, out tyuumon) || !context.TChumons.Any(s => s.ChID == tyuumon))
                {
                    TBTyumonIDS.BackColor = Color.Yellow;
                    TBTyumonIDS.Focus();
                    MessageBox.Show("注文IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var orderDetail = context.TChumonDetails.SingleOrDefault(od => od.ChDetailID.ToString() == TyumonSyosaiID);
                if (orderDetail != null)
                {
                    orderDetail.ChID = int.Parse(TyumonID);
                    orderDetail.PrID = int.Parse(syohinID);
                    orderDetail.ChQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("注文詳細の更新が成功しました。");
                    DisplayOrderDetails();
                    Log_Order(orderDetail.ChDetailID);
                }
                else
                {
                    MessageBox.Show("該当する注文詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterOrderDetails()
        {
            string OrderSyosaiID = TBTyumonSyosaiID.Text;
            string chuumon = TBTyumonIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                int tyuumon;
                if (TBTyumonIDS.Text == null)
                {
                    TBTyumonIDS.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("注文IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBSyohinID.Text == null)
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBSuryou.Text == null)
                {
                    TBSuryou.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(chuumon, out tyuumon) || !context.TChumons.Any(s => s.ChID == tyuumon))
                {
                    TBTyumonIDS.BackColor = Color.Yellow;
                    TBTyumonIDS.Focus();
                    MessageBox.Show("注文IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var existingOrderDetail = context.TChumonDetails.FirstOrDefault(o => o.ChID == tyuumon);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show("この注文IDにはすでに注文詳細が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 処理を終了
                }
                var newOrderDetail = new TChumonDetail
                {
                    ChID = int.Parse(chuumon),
                    PrID = int.Parse(syohinID),
                    ChQuantity = int.Parse(suryou),
                };

                context.TChumonDetails.Add(newOrderDetail);
                context.SaveChanges();
                MessageBox.Show("注文詳細の登録が成功しました。");
                DisplayOrderDetails();
                Log_Order(newOrderDetail.ChDetailID);
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
                            var Chumon = context.TChumons.FirstOrDefault(o => o.ChID == od.ChID);

                            return Chumon == null || (Chumon.ChFlag != 1 && Chumon.ChStateFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleChumonDetails.Select(od => new
                    {
                        注文詳細ID = od.ChDetailID,
                        注文ID = od.ChID,
                        商品ID = od.PrID,
                        数量 = od.ChQuantity.ToString("N0"),
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SearchOrderDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var OrderSyosaiID = TBTyumonSyosaiID.Text;
                var OrderIDS = TBTyumonIDS.Text;
                var syohinID = TBSyohinID.Text;
                var suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.TChumonDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(OrderSyosaiID))
                {
                    // 注文詳細IDを検索条件に追加
                    query = query.Where(od => od.ChDetailID.ToString() == OrderSyosaiID);
                }

                if (!string.IsNullOrEmpty(OrderIDS))
                {
                    //注文IDを検索条件に追加
                    query = query.Where(od => od.ChID.ToString() == OrderIDS);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrID.ToString() == syohinID);
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
                        注文詳細ID = od.ChDetailID,
                        注文ID = od.ChID,
                        商品ID = od.PrID,
                        数量 = od.ChQuantity,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する注文詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToggleOrderSelection()
        {
            isOrderSelected = !isOrderSelected;
            orderFlag = isOrderSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isOrderSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);
            if (orderFlag == "←通常")
                lastFocusedPanelID = 1;
            else if (orderFlag == "詳細→")
                lastFocusedPanelID = 2;

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
            try
            {
                // クリックした行のインデックスを取得 
                int rowIndex = e.RowIndex;

                // 行インデックスが有効かどうかをチェック 
                if (rowIndex >= 0)
                {
                    // 行データを取得 
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];
                    if (label2.Text == "登録")
                    {
                        TBTyumonID.Text = "";
                    }
                    else
                    {
                        TBTyumonID.Text = row.Cells["注文ID"].Value?.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力 (null許可)
                    TBShopID.Text = row.Cells["営業所ID"].Value?.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value?.ToString() ?? string.Empty;
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value?.ToString() ?? string.Empty;
                    TBJyutyuID.Text = row.Cells["受注ID"].Value?.ToString() ?? string.Empty;
                    date.Value = row.Cells["注文日"].Value != null
                                 ? Convert.ToDateTime(row.Cells["注文日"].Value)
                                 : DateTime.Now; // nullの場合は現在の日付を設定
                    UpdateTextBoxState(checkBoxSyain.Checked);
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
                if (label2.Text == "登録")
                {
                    TBTyumonSyosaiID.Text = "";
                }
                else
                {
                    TBTyumonSyosaiID.Text = row.Cells["注文詳細ID"].Value.ToString() ?? string.Empty;
                }
                // 各テキストボックスにデータを入力
                TBTyumonIDS.Text = row.Cells["注文ID"].Value.ToString() ?? string.Empty;
                TBSyohinID.Text = row.Cells["商品ID"].Value.ToString() ?? string.Empty;
                TBSuryou.Text = row.Cells["数量"].Value.ToString() ?? string.Empty;
            }
        }

        private void OrdersConfirm(int JyutyuID, int ChID, int SyFlag, string SyHidden)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                var order = context.TChumons.SingleOrDefault(o => o.ChID == ChID);

                if (order == null)
                {
                    throw new Exception("注文IDが見つかりません。");
                }

                // 出庫情報をTSyukkoに追加 
                var newSyukko = new TSyukko
                {
                    SoID = order.SoID,
                    EmID = null,
                    ClID = order.ClID,
                    OrID = order.OrID,
                    SyFlag = SyFlag,                  // ここでフラグを設定
                    SyHidden = SyHidden,              // 非表示理由も設定
                    SyDate = null,
                    SyStateFlag = 0
                };
                try
                {
                    // データが正しいか事前にチェック 
                    if (newSyukko.SoID == 0 || newSyukko.EmID == 0 || newSyukko.ClID == 0 || newSyukko.OrID == 0 || newSyukko.SyDate == default(DateTime))
                    {
                        throw new Exception("出庫情報に必要なデータが不足しています。");
                    }
                    context.TSyukkos.Add(newSyukko);
                    context.SaveChanges();
                    MessageBox.Show("出庫登録が完了しました。"); // ここでメッセージが表示されることを確認 
                    Checker2(newSyukko.OrID, newSyukko.SyID);
                }
                catch (Exception ex)
                {
                    throw new Exception("TSyukkoへの登録に失敗しました: " + ex.Message);
                }

                var orderDetail = context.TOrderDetails.FirstOrDefault(o => o.OrID == order.OrID);
                if (orderDetail == null)
                {
                    throw new Exception("注文詳細が見つかりません。");
                }

                // 注文詳細をすべて取得
                var orderDetails = context.TOrderDetails.Where(o => o.OrID == order.OrID).ToList();

                // 注文詳細が存在しない場合のエラー処理
                if (orderDetails == null || orderDetails.Count == 0)
                {
                    throw new Exception("注文詳細が見つかりません。");
                }

                // 各注文詳細に対して処理を実行
                foreach (var detail in orderDetails)
                {
                    var chumonDetail = context.TChumonDetails.SingleOrDefault(o => o.ChID == ChID && o.PrID == detail.PrID);
                    if (chumonDetail == null)
                    {
                        throw new Exception($"注文詳細（ChID: {ChID}, PrID: {detail.PrID}）が見つかりません。");
                    }

                    // 出庫詳細を作成
                    var newSyukkoDetail = new TSyukkoDetail
                    {
                        SyID = newSyukko.SyID,
                        PrID = detail.PrID,
                        SyQuantity = chumonDetail.ChQuantity
                    };

                    try
                    {
                        Checker3(newSyukko.SyID, detail.PrID); // チェック処理
                        context.TSyukkoDetails.Add(newSyukkoDetail);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"TSyukkoDetailへの登録に失敗しました: {ex.Message}");
                    }
                }

            }
        }

        // 発注処理
        private void ProductOrder(int OrID, int ChID, int shortageQuantity)
        {
            MessageBox.Show("発注登録を開始します");
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 注文データの取得 
                    var order = context.TChumons.SingleOrDefault(o => o.ChID == ChID);
                    if (order == null)
                    {
                        MessageBox.Show("注文情報が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 注文詳細データの取得 
                    var orderDetail = context.TChumonDetails.SingleOrDefault(o => o.ChID == ChID);
                    if (orderDetail == null)
                    {
                        MessageBox.Show("注文詳細情報が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int prID = orderDetail.PrID;

                    // 商品データの取得 
                    var product = context.MProducts.SingleOrDefault(p => p.PrID == prID);
                    if (product == null)
                    {
                        MessageBox.Show("指定された商品情報が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // 新しい発注情報の登録 
                    var newHattyu = new THattyu
                    {
                        MaID = product.MaID,
                        EmID = int.Parse(order.EmID.ToString()),
                        HaDate = order.ChDate ?? DateTime.Now, // 日付が空なら現在日時 
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
                        PrID = orderDetail.PrID,
                        HaQuantity = shortageQuantity,
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
        //発注入庫との中間テーブル登録処理 1
        private void Checker(int OrID, int Quantity)
        {
            MessageBox.Show("チェッカー処理");
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var checker = new NyuukoChecker
                    {
                        SyukkoID = "未設定",
                        JyutyuID = OrID.ToString(),
                        PrID = "未設定",
                        Flag = false,
                        Quantity = Quantity,
                        DelFlag = false

                    };
                    context.NyuukoCheckers.Add(checker);
                    context.SaveChanges();
                    MessageBox.Show(checker.JyutyuID.ToString());
                    MessageBox.Show("チェッカー処理確定");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("予期しないエラーが発生しました: " + ex.Message + "内部のやつ" + ex.InnerException.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Checker2(int OrID, int SyID)
        {
            MessageBox.Show("チェッカー２処理");
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // OrIDをStringに変換して比較
                    var checkers = context.NyuukoCheckers
                                          .Where(c => c.JyutyuID == OrID.ToString())
                                          .ToList();

                    if (checkers.Any()) // レコードが1件以上見つかった場合
                    {
                        foreach (var checker in checkers)
                        {
                            // SyukkoIDをSyIDで更新
                            checker.SyukkoID = SyID.ToString();
                        }

                        // 変更を保存
                        context.SaveChanges();

                        // 確定後のチェッカーデータをメッセージボックスで表示
                        string checkerData = "チェッカー２時点のデータ:\n";
                        foreach (var checker in checkers)
                        {
                            checkerData += $"Checker ID: {checker.ID}\n" +
                                           $"SyukkoID: {checker.SyukkoID}\n" +
                                           $"JyutyuID: {checker.JyutyuID}\n" +
                                           $"PrID: {checker.PrID}\n" +
                                           $"Flag: {checker.Flag}\n" +
                                           $"Quantity: {checker.Quantity}\n" +
                                           $"DelFlag: {checker.DelFlag}\n\n";
                        }

                        MessageBox.Show(checkerData, "チェッカー２確定後のデータ");
                    }
                    else
                    {
                        MessageBox.Show("指定されたOrIDに一致するレコードが見つかりませんでした。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期しないエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Checker3(int SyID, int PrID)
        {
            MessageBox.Show("チェッカー３処理");
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // SyukkoIDをStringに変換して比較
                    var checkers = context.NyuukoCheckers
                                          .Where(c => c.SyukkoID == SyID.ToString())
                                          .ToList();

                    if (checkers.Any()) // レコードが1件以上見つかった場合
                    {
                        foreach (var checker in checkers)
                        {
                            // PrIDを更新
                            checker.PrID = PrID.ToString();
                        }

                        // 変更を保存
                        context.SaveChanges();

                        // 確定後のチェッカーデータをメッセージボックスで表示
                        string checkerData = "チェッカー３時点のデータ:\n";
                        foreach (var checker in checkers)
                        {
                            checkerData += $"ID: {checker.ID}\n" +
                                           $"SyukkoID: {checker.SyukkoID}\n" +
                                           $"JyutyuID: {checker.JyutyuID}\n" +
                                           $"PrID: {checker.PrID}\n" +
                                           $"Flag: {checker.Flag}\n" +
                                           $"Quantity: {checker.Quantity}\n" +
                                           $"DelFlag: {checker.DelFlag}\n\n";
                        }

                        MessageBox.Show(checkerData, "チェッカー３確定後のデータ");
                    }
                    else
                    {
                        MessageBox.Show("指定されたSyukkoIDに一致するレコードが見つかりませんでした。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期しないエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // パネル内のすべてのコントロールにEnterイベントを追加
        private void AddControlEventHandlers(Control panel, int panelID)
        {
            foreach (Control control in panel.Controls)
            {
                // コントロールにEnterイベントを追加
                control.Enter += (sender, e) => Control_Enter(sender, e, panelID);
            }
        }

        // コントロールが選択（フォーカス）された時
        private void Control_Enter(object sender, EventArgs e, int panelID)
        {
            // 異なるパネルに移動したときのみイベントを発生させる
            if (panelID != lastFocusedPanelID)
            {
                ToggleOrderSelection();
                UpdateFlagButtonText();
                lastFocusedPanelID = panelID; // 現在のパネルIDを更新
            }
        }
        //↓以下北島匙投げゾーン
        private void LimitTextLength(TextBox textBox, int maxLength)
        {
            if (textBox.Text.Length > maxLength)
            {
                // 文字数制限を超えたら、超過部分を切り捨てる
                textBox.Text = textBox.Text.Substring(0, maxLength);
                textBox.SelectionStart = maxLength;  // カーソル位置を末尾に設定
            }
        }
        private void TBTyumonID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBShopID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 2);
        }

        private void TBShainID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBKokyakuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBJyutyuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }


        private void TBTyumonSyosaiID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBTyumonIDS_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyohinID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSuryou_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 4);
        }
        private void colorReset()
        {

            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    tbfalse();
                    break;
                default:
                    TBTyumonID.BackColor = SystemColors.Window;
                    TBShopID.BackColor = SystemColors.Window;
                    TBShainID.BackColor = SystemColors.Window;
                    TBKokyakuID.BackColor = SystemColors.Window;
                    TBJyutyuID.BackColor = SystemColors.Window;

                    TBTyumonSyosaiID.BackColor = SystemColors.Window;
                    TBTyumonIDS.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBSuryou.BackColor = SystemColors.Window;
                    break;
            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBTyumonID.KeyPress += NumericTextBox_KeyPress;
            TBShopID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBKokyakuID.KeyPress += NumericTextBox_KeyPress;
            TBJyutyuID.KeyPress += NumericTextBox_KeyPress;

            TBTyumonSyosaiID.KeyPress += NumericTextBox_KeyPress;
            TBTyumonIDS.KeyPress += NumericTextBox_KeyPress;
            TBSyohinID.KeyPress += NumericTextBox_KeyPress;
            TBSuryou.KeyPress += NumericTextBox_KeyPress;
        }

        // 半角数字のみを許可するKeyPressイベントハンドラ
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字とBackspace以外は入力を無効化
            if ((e.KeyChar < '0' || e.KeyChar > '9') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void b_acc_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TOrders.Count(order => order.OrStateFlag == 0 || order.OrStateFlag == null);
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // バッジを描画
                    if (button != null)
                    {
                        badge.pinpoint(e, button);
                    }
                }
            }
        }

        private void b_ord_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TChumons.Count(order => order.ChStateFlag == 0 || order.ChStateFlag == null);
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // バッジを描画
                    if (button != null)
                    {
                        badge.pinpoint(e, button);
                    }
                }
            }
        }

        private void b_iss_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TSyukkos.Count(order => order.SyStateFlag == 0 || order.SyStateFlag == null);
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // バッジを描画
                    if (button != null)
                    {
                        badge.pinpoint(e, button);
                    }
                }
            }
        }

        private void b_arr_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TArrivals.Count(order => order.ArStateFlag == 0 || order.ArStateFlag == null);
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // バッジを描画
                    if (button != null)
                    {
                        badge.pinpoint(e, button);
                    }
                }
            }
        }

        private void b_shi_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TShipments.Count(order => order.ShStateFlag == 0 || order.ShStateFlag == null);
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // バッジを描画
                    if (button != null)
                    {
                        badge.pinpoint(e, button);
                    }
                }
            }
        }


        private void countFlag()
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TChumons.Count(order => order.ChStateFlag == 0 || order.ChStateFlag == null);
                if (count == 0)
                {
                    GlobalBadge badge = new GlobalBadge("");
                    b_ord.Refresh();
                }
            }
        }

        private void FlagCount()
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TSyukkos.Count(order => order.SyStateFlag == 0 || order.SyStateFlag == null);
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" ");
                    b_iss.Refresh();
                }
            }
        }
        private void Log_Order(int id)
        {
            string ModeFlag = "";
            if (orderFlag == "←通常")
            {
                ModeFlag = "通常";
            }
            else
            {
                ModeFlag = "詳細";
            }
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 最新のLoginHistoryLogを取得
                    var latestLoginHistory = context.LoginHistoryLogs
                                                    .OrderByDescending(l => l.LoginDateTime)  // LogDateを基準に降順に並べる
                                                    .FirstOrDefault();  // 最新のログを取得
                    if (latestLoginHistory != null)
                    {
                        // 最新のログが見つかった場合、そのIDを設定
                        var LogDet = new LoginHistoryLogDetail
                        {
                            ID = latestLoginHistory.ID,  // 最新のLogHistoryLogのIDを使用
                            Display = "注文",
                            Mode = ModeFlag,
                            Process = label2.Text,
                            LogID = id,  //
                            AcceptDateTime = DateTime.Now
                        };

                        context.LoginHistoryLogDetails.Add(LogDet);  // 新しいログ履歴を登録
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("最新のログ履歴が見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Logへの登録に失敗しました:" + ex.Message);
            }
        }
        // フラグを定義して、干渉を防ぐ
        private bool isProgrammaticChange = false;

        // チェックボックス変更時のイベントハンドラ
        private void checkBoxSyain_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBoxState(checkBoxSyain.Checked);
        }

        // テキストボックスの状態を更新するメソッド
        private void UpdateTextBoxState(bool isChecked)
        {
            // テキストをプログラムで変更していることを示すフラグをオン
            isProgrammaticChange = true;

            if (isChecked)
            {
                TBShainID.Text = empID;  // テキストを設定
                TBShainID.Enabled = false; // 無効化
            }
            else
            {
                TBShainID.Enabled = true; // 有効化
            }

            // フラグをオフに戻す
            isProgrammaticChange = false;
        }


    }
}

