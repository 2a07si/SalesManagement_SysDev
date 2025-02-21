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
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using SalesManagement_SysDev.Entity;
using static SalesManagement_SysDev.Classまとめ.StockManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesManagement_SysDev
{
    public partial class order : Form
    {
        string empID = GlobalEmp.EmployeeID;
        private bool isOrderSelected = true; // 初期状態を注文(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定
        private List<int> shortageProducts = new List<int>();
        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス
        private DateTime timestamp = DateTime.Now;

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
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;

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
            b_reg.Enabled = false;
            b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            SetupNumericOnlyTextBoxes();
            CurrentStatus.UpDateStatus(label2);

            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
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
            if (checkBoxSyain.Checked == false)
            {
                TBShainID.Text = "";
            }
            ResetYellowBackgrounds(this);
            UpdateClose_kun(orderFlag);
            UpdateClose_Chan();
        }
        private void b_ser_Click(object sender, EventArgs e)
        {
            PerformSearch();
            tbtrue();
            TyumonFlag.Enabled = false;
            UpdateClose_kun(orderFlag);
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
            TyumonFlag.Enabled = true;
            UpdateClose_kun(orderFlag);
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
            TyumonFlag.Enabled = false;
            UpdateClose_kun(orderFlag);
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
            UpdateClose_kun(orderFlag);
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
                        MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void HandleOrderDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //UpdateOrderDetails();
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
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private bool CheckTBValue(TextBox textBox, string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                textBox.BackColor = Color.Yellow;
                textBox.Focus();
                MessageBox.Show($":101\n必要な入力がありません。（{fieldName}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            textBox.BackColor = SystemColors.Window; // 問題ない場合、背景色をリセット
            return false;
        }

        private void NotFound(TextBox textBox, string itemName, string itemId)
        {
            textBox.BackColor = Color.Yellow;
            textBox.Focus();
            MessageBox.Show($":204\n該当の{itemName}が見つかりません。（{itemName}ID: {itemId}）",
                            "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (CheckTBValue(TBTyumonID, OrderID, "注文ID")) return;
            if (CheckTBValue(TBShopID, ShopID, "ショップID")) return;
            if (CheckTBValue(TBShainID, ShainID, "社員ID")) return;
            if (CheckTBValue(TBKokyakuID, KokyakuID, "顧客ID")) return;
            if (CheckTBValue(TBJyutyuID, JyutyuID, "受注ID")) return;

            // ログイン時に使用した社員IDが一致しているかをチェック
            if (TBShainID.Text != empID)
            {
                MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                return;
            }

            // 注文日が未来日かどうかを確認
            if (date.Value > DateTime.Now)
            {
                var result = MessageBox.Show(
                    "注文日が未来を指していますが、よろしいですか？",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return; // 処理を中断
                }
            }

            // 注文IDが存在するか確認
            if (Kuraberu_kun.Kuraberu_chan("注文", "通常", "更新", int.Parse(ChumonID), timestamp) == false)
            {
                return;
            }

            using (var context = new SalesManagementContext())
            {
                // 注文IDの検証
                if (!int.TryParse(OrderID, out int orderID) || !context.TChumons.Any(s => s.ChID == orderID))
                {
                    NotFound(TBTyumonID, "注文", OrderID);
                    return; // 注文IDが見つからない場合
                }

                if (!int.TryParse(ShopID, out int shopID) || !context.MSalesOffices.Any(s => s.SoID == shopID))
                {
                    NotFound(TBShopID, "ショップ", ShopID);
                    return; // ショップIDが見つからない場合
                }

                if (!int.TryParse(ShainID, out int shainID) || !context.MEmployees.Any(e => e.EmID == shainID))
                {
                    NotFound(TBShainID, "社員", ShainID);
                    return; // 社員IDが見つからない場合
                }

                if (!int.TryParse(KokyakuID, out int kokyakuID) || !context.MClients.Any(k => k.ClID == kokyakuID))
                {
                    NotFound(TBKokyakuID, "顧客", KokyakuID);
                    return; // 顧客IDが見つからない場合
                }

                if (!int.TryParse(JyutyuID, out int jyutyuID) || !context.TOrders.Any(j => j.OrID == jyutyuID))
                {
                    NotFound(TBJyutyuID, "受注", JyutyuID);
                    return; // 受注IDが見つからない場合
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
                            MessageBox.Show(":104\n詳細が登録されていません。\n出庫処理を実行できません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // 対応するすべての注文詳細を取得 
                        var details = context.TChumonDetails.Where(d => d.ChID == int.Parse(ChumonID)).ToList();
                        bool hasShortage = false; // 在庫不足が1つでもあれば true にする
                        string hiddenReason = null; // 備考
                        int hiddenFlag = 0; // 非表示フラグ
                        int totalShortage = 0; // 総不足数

                        // 在庫不足商品のIDリスト

                        foreach (var detail in details)
                        {
                            var stock = context.TStocks.FirstOrDefault(s => s.PrID == detail.PrID);
                            if (stock == null || stock.StQuantity < detail.ChQuantity)
                            {
                                hasShortage = true; // 在庫不足が発生
                                hiddenReason = "在庫不足のため非表示中";
                                hiddenFlag = 1;

                                // 在庫不足処理
                                var shortageQuantity = detail.ChQuantity - (stock?.StQuantity ?? 0);
                                if (stock != null)
                                {
                                    //stock.StQuantity -= stock.StQuantity; // 在庫を可能な範囲で減らす
                                }
                                totalShortage += shortageQuantity; // 総不足数に加算

                                // 発注処理
                                ProductOrder(int.Parse(OrderID), detail.ChID, shortageQuantity, detail.PrID);

                                // 不足商品のIDをリストに追加
                                shortageProducts.Add(detail.PrID);

                                MessageBox.Show($"商品ID: {detail.PrID}の在庫が不足しているため発注処理を行いました。");
                            }
                            else
                            {
                                // 在庫充足処理
                                //stock.StQuantity -= detail.ChQuantity; // 在庫を減らす
                                //MessageBox.Show($"商品ID: {detail.PrID}、残り在庫: {stock.StQuantity}");

                            }
                        }

                        // 最終的に1回だけ OrdersConfirm を実行
                        if (hasShortage)
                        {
                            // 在庫不足があった場合の OrdersConfirm
                            OrdersConfirm(int.Parse(OrderID), int.Parse(ChumonID), hiddenFlag, hiddenReason, 1, totalShortage);

                            // 不足商品の一覧をメッセージで表示
                            var shortageMessage = $"在庫不足の商品ID一覧: {string.Join(", ", shortageProducts)}";
                            MessageBox.Show(shortageMessage);
                        }
                        else
                        {
                            // 在庫不足がなかった場合の OrdersConfirm
                            OrdersConfirm(int.Parse(OrderID), int.Parse(ChumonID), 0, null, 0, 0);
                        }

                        // データの保存
                        try
                        {
                            context.SaveChanges();
                            DisplayOrders();
                            DisplayOrderDetails();
                            MessageBox.Show("処理が正常に完了しました。");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(":201\n登録操作が失敗しました " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("出庫処理の保存に失敗しました\n: " + ex.Message, "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            ResetYellowBackgrounds(this);
                            Log_Order(order.OrID);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(":202\n更新操作が失敗しました\n: " + ex.Message, "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    DisplayOrders(); // 注文情報を表示 
                    DisplayOrderDetails();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // 各入力チェック
                if (CheckTBValue(TBShopID, ShopID, "店舗ID") ||
                    CheckTBValue(TBShainID, ShainID, "社員ID") ||
                    CheckTBValue(TBKokyakuID, KokyakuID, "顧客ID") ||
                    CheckTBValue(TBJyutyuID, JyutyuID, "受注ID"))
                {
                    return; // 必要な入力がない場合は、処理を中止
                }

                // 入力値の検証（データベース確認）
                if (!int.TryParse(ShopID, out int a) || !context.MSalesOffices.Any(s => s.SoID == a))
                {
                    NotFound(TBShopID, "店舗", ShopID);
                    return;
                }

                if (!int.TryParse(ShainID, out int employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    NotFound(TBShainID, "社員", ShainID);
                    return;
                }

                if (!int.TryParse(KokyakuID, out int kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    NotFound(TBKokyakuID, "顧客", KokyakuID);
                    return;
                }

                if (!int.TryParse(JyutyuID, out int juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    NotFound(TBJyutyuID, "受注", JyutyuID);
                    return;
                }

                // ログイン時の社員IDと一致するかチェック
                if (ShainID != empID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }

                // 受注日が未来日付の場合の確認
                if (Orderdate > DateTime.Now)
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
                var order = context.TChumons.FirstOrDefault(o => o.OrID == int.Parse(JyutyuID));
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
                                MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            var details = context.TChumonDetails.Where(d => d.ChID == newChID).ToList();
                            bool isStockSufficient = true; // 初期状態では全て在庫充足と仮定

                            foreach (var detail in details)
                            {
                                // 在庫情報を取得
                                var stock = context.TStocks.SingleOrDefault(s => s.PrID == detail.PrID);
                                if (stock == null)
                                {
                                    TBSyohinID.BackColor = Color.White;
                                    TBSyohinID.Focus();
                                    MessageBox.Show(":204\n該当の商品ID: {detail.PrID} が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // 在庫確認
                                int remainingStock = stock.StQuantity - detail.ChQuantity;
                                if (remainingStock < 0)
                                {
                                    // 在庫不足時
                                    int shortageQuantity = Math.Abs(remainingStock); // 足りない数量
                                    ProductOrder(newOrder.OrID, detail.ChID, shortageQuantity, detail.PrID); // 不足分を発注
                                    MessageBox.Show($"商品ID: {detail.PrID} の在庫が {shortageQuantity} 個不足しています。発注処理を行いました。");

                                    // 全体の状態を在庫不足に設定
                                    isStockSufficient = false;
                                }
                                else
                                {
                                    // 在庫が足りている場合
                                    stock.StQuantity -= detail.ChQuantity; // 在庫を減らす
                                    context.SaveChanges(); // 在庫情報をデータベースに保存
                                    MessageBox.Show($"商品ID: {detail.PrID}、残り在庫: {stock.StQuantity}"); // 残り在庫を表示
                                }
                            }

                            // 最終的な在庫状況に基づいて OrdersConfirm を実行
                            if (isStockSufficient)
                            {
                                OrdersConfirm(int.Parse(JyutyuID), newOrder.ChID, 0, null, 0, 0); // 在庫充足時の処理
                            }
                            else
                            {
                                OrdersConfirm(int.Parse(JyutyuID), newOrder.ChID, 1, "在庫不足のため非表示中", 0, 0); // 在庫不足時の処理
                            }

                            MessageBox.Show("出庫登録が完了しました。");

                        }
                        else
                        {
                            MessageBox.Show("登録が成功しました。");
                        }

                        DisplayOrders();
                        DisplayOrderDetails();
                        ResetYellowBackgrounds(this);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての注文を表示
                    var chumons = checkBox_2.Checked
                        ? (checkBox1.Checked
                            ? context.TChumons.OrderByDescending(c => c.ChID).ToList() // 降順
                            : context.TChumons.OrderBy(c => c.ChID).ToList())          // 昇順
                        : (checkBox1.Checked
                            ? context.TChumons
                                .Where(c => c.ChFlag != 1 && c.ChStateFlag != 2)
                                .OrderByDescending(c => c.ChID) // 条件に合致するものを降順で取得
                                .ToList()
                            : context.TChumons
                                .Where(c => c.ChFlag != 1 && c.ChStateFlag != 2)
                                .OrderBy(c => c.ChID)          // 条件に合致するものを昇順で取得
                                .ToList());


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
                        備考 = o.ChHidden  // 備考 
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message + "\n\nスタックトレース:\n" + ex.StackTrace, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DateTime? chumonDate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TChumons.AsQueryable();

                // 注文IDを検索条件に追加
                if (!string.IsNullOrEmpty(tyumonID))
                {
                    int chID = int.Parse(tyumonID);
                    query = query.Where(order => order.ChID == chID);
                }

                // 営業所IDを検索条件に追加
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
                if (chumonDate.HasValue)
                {
                    query = query.Where(order => order.ChDate == chumonDate.Value);
                }

                // 注文フラグ(ChumonFlag)の検索条件を追加
                if (TyumonFlag.Checked)
                {
                    query = query.Where(order => order.ChStateFlag == 2); // フラグが2の注文を検索
                }
                else
                {
                    query = query.Where(order => order.ChStateFlag == 0); // フラグが0の注文を検索
                }

                // 削除フラグ(DelFlag)の検索条件を追加
                if (DelFlag.Checked)
                {
                    query = query.Where(order => order.ChFlag == 1); // 削除済みの注文
                }
                else
                {
                    query = query.Where(order => order.ChFlag == 0); // 有効な注文
                }

                // 結果を取得
                var orders = query.ToList();

                if (orders.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        注文ID = o.ChID,            // 注文ID
                        営業所ID = o.SoID,         // 営業所ID
                        社員ID = o.EmID,           // 社員ID
                        顧客ID = o.ClID,           // クライアントID
                        受注ID = o.OrID,           // 受注ID
                        注文日 = o.ChDate,         // 注文日
                        状態フラグ = o.ChStateFlag, // 注文状態フラグ
                        非表示フラグ = o.ChFlag,   // 削除フラグ
                        備考 = o.ChHidden    // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // 入力項目のチェック
            if (CheckTBValue(TBTyumonSyosaiID, TyumonSyosaiID, "注文詳細ID")) return;
            if (CheckTBValue(TBTyumonIDS, TyumonID, "注文ID")) return;
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, suryou, "数量")) return;

            // 注文詳細IDの整合性チェック
            if (Kuraberu_kun.Kuraberu_chan("注文", "詳細", "更新", int.Parse(TyumonSyosaiID), timestamp) == false)
            {
                return; // 権限がない場合は処理を中止
            }

            using (var context = new SalesManagementContext())
            {
                // 注文詳細IDの検証
                if (!int.TryParse(TyumonSyosaiID, out int syousai) || !context.TChumonDetails.Any(s => s.ChDetailID == syousai))
                {
                    NotFound(TBTyumonSyosaiID, "注文詳細", TyumonSyosaiID);
                    return;
                }

                // 注文IDの検証
                if (!int.TryParse(TyumonID, out int tyuumon) || !context.TChumons.Any(s => s.ChID == tyuumon))
                {
                    NotFound(TBTyumonIDS, "注文", TyumonID);
                    return;
                }

                // 商品IDの検証
                if (!int.TryParse(syohinID, out int shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    NotFound(TBSyohinID, "商品", syohinID);
                    return;
                }

                // 注文詳細の更新処理
                var orderDetail = context.TChumonDetails.SingleOrDefault(od => od.ChDetailID.ToString() == TyumonSyosaiID);
                if (orderDetail != null)
                {
                    orderDetail.ChID = int.Parse(TyumonID);
                    orderDetail.PrID = int.Parse(syohinID);
                    orderDetail.ChQuantity = int.Parse(suryou);

                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("注文詳細の更新が成功しました。");
                        DisplayOrderDetails();
                        Log_Order(orderDetail.ChDetailID);
                        ResetYellowBackgrounds(this);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($":500\n不明なエラーが発生しました。\n{ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

            // 入力項目のチェック
            if (CheckTBValue(TBTyumonIDS, chuumon, "注文ID")) return;
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, suryou, "数量")) return;

            using (var context = new SalesManagementContext())
            {
                // 注文IDの検証
                if (!int.TryParse(chuumon, out int tyuumon) || !context.TChumons.Any(s => s.ChID == tyuumon))
                {
                    NotFound(TBTyumonIDS, "注文", chuumon);
                    return;
                }

                // 商品IDの検証
                if (!int.TryParse(syohinID, out int shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    NotFound(TBSyohinID, "商品", syohinID);
                    return;
                }

                // 注文詳細が既に存在するかのチェック
                var existingOrderDetail = context.TChumonDetails.FirstOrDefault(o => o.ChID == tyuumon);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show("この注文IDにはすでに注文詳細が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 処理を終了
                }

                // 新しい注文詳細の作成
                var newOrderDetail = new TChumonDetail
                {
                    ChID = tyuumon,
                    PrID = shouhin,
                    ChQuantity = int.Parse(suryou),
                };

                // 注文詳細の追加と保存
                try
                {
                    context.TChumonDetails.Add(newOrderDetail);
                    context.SaveChanges();
                    MessageBox.Show("注文詳細の登録が成功しました。");
                    DisplayOrderDetails();
                    Log_Order(newOrderDetail.ChDetailID);
                    ResetYellowBackgrounds(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($":500\n不明なエラーが発生しました。\n{ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DisplayOrderDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 注文詳細のリストを取得（checkBox1の状態に応じて並べ替え）
                    var ChumonDetails = checkBox1.Checked
                        ? context.TChumonDetails.OrderByDescending(cd => cd.ChID).ToList() // 降順
                        : context.TChumonDetails.OrderBy(cd => cd.ChID).ToList();          // 昇順

                    // checkBox_2がチェックされている場合、フィルタリングを無視してすべての詳細を表示
                    var visibleChumonDetails = checkBox_2.Checked
                        ? ChumonDetails // チェックされていれば全て表示（並び替え済み）
                        : ChumonDetails.Where(cd =>
                        {
                            var Chumon = context.TChumons.FirstOrDefault(c => c.ChID == cd.ChID);

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
            UpdateClose_kun(orderFlag);
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
                    UpdateClose_kun(orderFlag);
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
            UpdateClose_kun(orderFlag);
        }

        private void OrdersConfirm(int JyutyuID, int ChID, int SyFlag, string SyHidden, int fla, int shortageQuantity)
        {
            using (var context = new SalesManagementContext())
            {
                var order = context.TChumons.FirstOrDefault(o => o.ChID == ChID);

                if (order == null)
                {
                    throw new Exception("注文IDが見つかりません。");
                }

                bool isDuplicate = context.TSyukkos.Any(c => c.OrID == JyutyuID);
                if (isDuplicate)
                {
                    MessageBox.Show($"この受注ID ({JyutyuID}) はすでに登録されています。登録を中止します。");
                    return;
                }

                // 出庫情報をTSyukkoに追加 
                var newSyukko = new TSyukko
                {
                    SoID = order.SoID,
                    EmID = null,
                    ClID = order.ClID,
                    OrID = order.OrID,
                    SyFlag = SyFlag,                  // ここでフラグを設定
                    SyHidden = SyHidden,              // 備考も設定
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
                }
                catch (Exception ex)
                {
                    throw new Exception("TSyukkoへの登録に失敗しました: " + ex.Message);
                }

                // 注文詳細をすべて取得
                var orderDetails = context.TOrderDetails.Where(o => o.OrID == order.OrID).ToList();

                // 注文詳細が存在しない場合のエラー処理
                if (orderDetails == null || orderDetails.Count == 0)
                {
                    throw new Exception("注文詳細が見つかりません。");
                }

                // 不足商品のリストを取得
                var shortageProducts = context.TChumonDetails
                    .Where(cd => cd.ChID == ChID)
                    .Where(cd => context.TStocks.Any(stock => stock.PrID == cd.PrID && stock.StQuantity < cd.ChQuantity))
                    .Select(cd => cd.PrID)
                    .ToList();

                // 各注文詳細に対して処理を実行
                foreach (var detail in orderDetails)
                {
                    var chumonDetail = context.TChumonDetails.FirstOrDefault(o => o.ChID == ChID && o.PrID == detail.PrID);
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
                        if (fla == 1 && shortageProducts.Contains(newSyukkoDetail.PrID))
                        {
                            //不足商品リストを初期化
                            shortageProducts.Remove(newSyukkoDetail.PrID); // 要素を削除
                        }
                        //shortageProductsの要素削除
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
        private void ProductOrder(int OrID, int ChID, int shortageQuantity, int PrID)
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 注文データの取得  
                    var order = context.TChumons.FirstOrDefault(o => o.ChID == ChID);
                    if (order == null)
                    {
                        MessageBox.Show("注文情報が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 該当する注文詳細データの取得  
                    var orderDetail = context.TChumonDetails.FirstOrDefault(o => o.ChID == ChID && o.PrID == PrID);
                    if (orderDetail == null)
                    {
                        MessageBox.Show($"指定された商品ID: {PrID} に一致する注文詳細が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 商品データの取得  
                    var product = context.MProducts.FirstOrDefault(p => p.PrID == PrID);
                    if (product == null)
                    {
                        MessageBox.Show($"指定された商品ID: {PrID} の商品情報が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    MessageBox.Show($"商品ID: {PrID} の発注登録が完了しました");
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
                string errorMessage = "予期しないエラーが発生しました:\n" +
                                      ex.Message +
                                      (ex.InnerException != null ?
                                          "\n\n【詳細情報】\n" + ex.InnerException.Message : "");

                MessageBox.Show(errorMessage, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                UpdateClose_kun(orderFlag);
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

        private void UpdateClose_kun(string orderFlag)
        {
            if (orderFlag == "詳細→")
            {
                b_upd.Enabled = false;
                b_upd.BackColor = SystemColors.ControlDark; // 灰色に設定
                b_kakutei.Enabled = false;
                b_kakutei.BackColor = SystemColors.ControlDark;
            }
            else
            {
                b_upd.Enabled = true;
                b_upd.BackColor = Color.FromArgb(255, 224, 192); // 色コード255, 224, 192に設定
                b_kakutei.Enabled = true;
                b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
            }
        }
        private void UpdateClose_Chan()
        {
            b_upd.Enabled = true;
            b_upd.BackColor = Color.FromArgb(255, 224, 192); // 色コード255, 224, 192に設定
            b_kakutei.Enabled = true;
            b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
        }

        private void ResetYellowBackgrounds(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // テキストボックスかつ背景色が黄色かを判定
                if (control is TextBox textBox && textBox.BackColor == Color.Yellow)
                {
                    textBox.BackColor = SystemColors.Window; // 元の背景色に戻す
                }

                // 再帰的に子コントロールをチェック
                if (control.HasChildren)
                {
                    ResetYellowBackgrounds(control);
                }
            }
        }

    }
}

