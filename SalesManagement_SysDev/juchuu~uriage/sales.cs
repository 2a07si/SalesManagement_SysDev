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

namespace SalesManagement_SysDev
{
    public partial class sales : Form
    {
        string empID = GlobalEmp.EmployeeID;
        private bool isSaleSelected = true; // 初期状態を受注(TOrder)に設定
        private string saleFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;
        private DateTime timestamp = DateTime.Now;
        private int lastFocusedPanelID = 1;
        public sales()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //  this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(sales_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

            // パネル1とパネル2のコントロールにイベントを設定
            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel4, 2);  // パネル2の場合
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;

        }

        private void sales_Load(object sender, EventArgs e)
        {
            labelStatus.labelstatus(label2, b_kakutei);

            GlobalUtility.UpdateLabels(label_id, label_ename);
            // timerManager.UpdateDateTime(); // この行を削除またはコメントアウト 
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_shi,
                b_acc,
                b_iss
            });

            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplaySales();
            DisplaySaleDetails();
            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
            UpdateTextBoxState(checkBoxSyain.Checked);
            b_reg.Enabled = false;
            b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            TBTotal.Enabled = false;
            TBTotal.BackColor = Color.Gray;
            SetupNumericOnlyTextBoxes();
            CurrentStatus.UpDateStatus(label2);
        }

        // メインメニューに戻る 
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        // 受注管理画面に遷移 
        private void b_acc_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToAcceptingOrderForm(); // 受注管理画面に遷移 
        }

        // 注文管理画面に遷移 
        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
        }

        // 発注書発行画面に遷移 
        private void b_iss_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm(); // 発注書発行画面に遷移 
        }

        // 入荷管理画面に遷移 
        private void b_arr_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移 
        }

        // 出荷管理画面に遷移 
        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm(); // 出荷管理画面に遷移 
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            RegisterStatus();
            tbfalse();
        }

        private void RegisterStatus()
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplaySales();
            DisplaySaleDetails();
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            tbtrue();
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplaySales();
            DisplaySaleDetails();
            tbtrue();

        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            tbtrue();

        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
            UpdateClose_kun(saleFlag);
            UpdateClose_Chan();
        }
        private void cleartext()
        {
            TBSalesID.Text = "";
            TBKokyakuID.Text = "";
            TBShopID.Text = "";
            TBJyutyuID.Text = "";
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBUriageSyosaiID.Text = "";
            TBUriageIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            TBTotal.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            tbtrue();
            checkBoxDateFilter.Checked = false;
            checkBox_2.Checked = false;
            colorReset();
            if (checkBoxSyain.Checked == false)
            {
                TBShainID.Text = "";
            }
            ResetYellowBackgrounds(this);

        }

        private void tbfalse()
        {
            TBSalesID.Enabled = false;
            TBUriageSyosaiID.Enabled = false;
            TBTotal.Enabled = false;
            TBSalesID.BackColor = Color.Gray;
            TBUriageSyosaiID.BackColor = Color.Gray;
            TBTotal.BackColor = Color.Gray;
            TBSalesID.Text = "";
            TBUriageSyosaiID.Text = "";
            TBTotal.Text = "";
        }

        private void tbtrue()
        {
            TBSalesID.Enabled = true;
            TBUriageSyosaiID.Enabled = true;
            TBSalesID.BackColor = Color.White;
            TBUriageSyosaiID.BackColor = Color.White;
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
                        HandleSaleOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        colorReset();
                        HandleSaleDetailOperation();
                        break;
                    default:
                        MessageBox.Show(":100\n無効な操作です", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSaleOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateSale();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterSales();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplaySales();
                    break;
                case CurrentStatus.Status.検索:
                    SearchSales();
                    break;
                default:
                    MessageBox.Show(":100\n無効な操作です", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void HandleSaleDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateSaleDetails();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterSaleDetails();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplaySaleDetails();
                    break;
                case CurrentStatus.Status.検索:
                    SearchSaleDetails();
                    break;
                default:
                    MessageBox.Show(":100\n無効な操作です", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void UpdateSale()
        {
            string JyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string salesID = TBSalesID.Text;
            DateTime salesDate = date.Value;
            bool delFlag = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;

            // 必要な入力チェックを行う
            if (CheckTBValue(TBSalesID, salesID, "売上ID")) return;
            if (CheckTBValue(TBShopID, shopID, "店舗ID")) return;
            if (CheckTBValue(TBShainID, shainID, "社員ID")) return;
            if (CheckTBValue(TBKokyakuID, kokyakuID, "顧客ID")) return;
            if (CheckTBValue(TBJyutyuID, JyutyuID, "受注ID")) return;
            {
                // 入力が足りない場合は処理を終了
            }

            // ログインIDとの照合
            if (shainID != empID)
            {
                MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                return;
            }

            // 売上日が未来日付の場合の確認
            if (salesDate > DateTime.Now)
            {
                var result = MessageBox.Show(
                    "売上日が未来を指していますが、よろしいですか？",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return; // 処理を中断
                }
            }

            // 競合チェック（売上データの更新）
            if (Kuraberu_kun.Kuraberu_chan("売上", "通常", "更新", int.Parse(salesID), timestamp) == false)
            {
                return;
            }

            // DBでの各項目の存在確認
            using (var context = new SalesManagementContext())
            {
                // 売上IDが存在するか確認
                if (!int.TryParse(salesID, out int sale) || !context.TSales.Any(s => s.SaID == sale))
                {
                    NotFound(TBSalesID, "売上", salesID);
                    return;
                }

                // 店舗IDが存在するか確認
                if (!int.TryParse(shopID, out int shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    NotFound(TBShopID, "店舗", shopID);
                    return;
                }

                // 社員IDが存在するか確認
                if (!int.TryParse(shainID, out int employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    NotFound(TBShainID, "社員", shainID);
                    return;
                }

                // 顧客IDが存在するか確認
                if (!int.TryParse(kokyakuID, out int kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    NotFound(TBKokyakuID, "顧客", kokyakuID);
                    return;
                }

                // 受注IDが存在するか確認
                if (!int.TryParse(JyutyuID, out int juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    NotFound(TBJyutyuID, "受注", JyutyuID);
                    return;
                }

                // 売上情報の更新
                var sales = context.TSales.SingleOrDefault(s => s.SaID.ToString() == salesID);
                if (sales != null)
                {
                    sales.SoID = int.Parse(shopID);
                    sales.EmID = int.Parse(shainID);
                    sales.ClID = int.Parse(kokyakuID);
                    sales.SaID = int.Parse(salesID);
                    sales.OrID = int.Parse(JyutyuID);
                    sales.SaDate = salesDate;
                    sales.SaFlag = delFlag ? 1 : 0;
                    sales.SaHidden = Riyuu;

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    DisplaySales();
                    DisplaySaleDetails();
                    Log_Sale(sales.SaID);
                    ResetYellowBackgrounds(this);
                }
                else
                {
                    MessageBox.Show("該当する売上情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterSales()
        {
            try
            {
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string JyutyuID = TBJyutyuID.Text;
                DateTime salesDate = date.Value;
                bool delFlag = DelFlag.Checked;

                // 入力が不足している項目をチェック
                if (CheckTBValue(TBShopID, shopID, "店舗ID")) return;
                if (CheckTBValue(TBShainID, shainID, "社員ID")) return;
                if (CheckTBValue(TBKokyakuID, kokyakuID, "顧客ID")) return;
                if (CheckTBValue(TBJyutyuID, JyutyuID, "受注ID")) return;

                // ログインIDとの照合
                if (shainID != empID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }

                // 売上日が未来日付の場合の確認
                if (salesDate > DateTime.Now)
                {
                    var result = MessageBox.Show(
                        "売上日が未来を指していますが、よろしいですか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return; // 処理を中断
                    }
                }

                // DBでの各項目の存在確認
                using (var context = new SalesManagementContext())
                {
                    // 店舗IDが存在するか確認
                    if (!int.TryParse(shopID, out int shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                    {
                        NotFound(TBShopID, "店舗", shopID);
                        return;
                    }

                    // 社員IDが存在するか確認
                    if (!int.TryParse(shainID, out int employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                    {
                        NotFound(TBShainID, "社員", shainID);
                        return;
                    }

                    // 顧客IDが存在するか確認
                    if (!int.TryParse(kokyakuID, out int kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                    {
                        NotFound(TBKokyakuID, "顧客", kokyakuID);
                        return;
                    }

                    // 受注IDが存在するか確認
                    if (!int.TryParse(JyutyuID, out int juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                    {
                        NotFound(TBJyutyuID, "受注", JyutyuID);
                        return;
                    }

                    // 新規売上の登録
                    var newSale = new TSale
                    {
                        SoID = shop,
                        EmID = employeeID,
                        ClID = kokyaku,
                        OrID = juchu,
                        SaDate = salesDate,
                        SaHidden = delFlag ? "1" : "0"
                    };

                    context.TSales.Add(newSale);
                    context.SaveChanges();
                    MessageBox.Show("登録が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplaySales();
                    Log_Sale(newSale.SaID);
                    ResetYellowBackgrounds(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("入力された値の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("登録中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DisplaySales()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {// checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての売上を表示
                    var sales = checkBox_2.Checked
                        ? (checkBox1.Checked
                            ? context.TSales.OrderByDescending(s => s.SaID).ToList() // 降順
                            : context.TSales.OrderBy(s => s.SaID).ToList())          // 昇順
                        : (checkBox1.Checked
                            ? context.TSales
                                .Where(s => s.SaFlag != 1)
                                .OrderByDescending(s => s.SaID) // 条件に合致するものを降順で取得
                                .ToList()
                            : context.TSales
                                .Where(s => s.SaFlag != 1)
                                .OrderBy(s => s.SaID)          // 条件に合致するものを昇順で取得
                                .ToList());

                    dataGridView1.DataSource = sales.Select(s => new
                    {
                        売上ID = s.SaID,
                        顧客ID = s.ClID,
                        営業所ID = s.SoID,
                        社員ID = s.EmID,
                        受注ID = s.OrID,
                        売上日 = s.SaDate,
                        売上フラグ = s.SaFlag,
                        備考 = s.SaHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchSales()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得  
                var JyutyuID = TBJyutyuID.Text.Trim();       // 受注ID  
                var shopID = TBShopID.Text.Trim();           // 営業所ID  
                var shainID = TBShainID.Text.Trim();         // 社員ID  
                var kokyakuID = TBKokyakuID.Text.Trim();     // 顧客ID  
                var salesID = TBSalesID.Text.Trim();         // 担当者  
                var riyuu = TBRiyuu.Text.Trim();             // 理由

                // 基本的なクエリ  
                var query = context.TSales.AsQueryable();

                // 受注IDを検索条件に追加  
                if (!string.IsNullOrEmpty(JyutyuID) && int.TryParse(JyutyuID, out int parsedJyutyuID))
                {
                    query = query.Where(s => s.OrID == parsedJyutyuID);
                }

                // 営業所IDを検索条件に追加  
                if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                {
                    query = query.Where(s => s.SoID == parsedShopID);
                }

                // 社員IDを検索条件に追加  
                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(s => s.EmID == parsedShainID);
                }

                // 顧客IDを検索条件に追加  
                if (!string.IsNullOrEmpty(kokyakuID) && int.TryParse(kokyakuID, out int parsedKokyakuID))
                {
                    query = query.Where(s => s.ClID == parsedKokyakuID);
                }

                // 担当者名を検索条件に追加  
                if (!string.IsNullOrEmpty(salesID) && int.TryParse(salesID, out int parsedSalesID))
                {
                    query = query.Where(s => s.SaID == parsedSalesID);
                }

                // 理由を検索条件に追加  
                if (!string.IsNullOrEmpty(riyuu))
                {
                    query = query.Where(s => s.SaHidden.Contains(riyuu));
                }

                // 売上フラグ(SaleFlag)の検索条件を追加  
                if (DelFlag.Checked)
                {
                    query = query.Where(s => s.SaFlag == 1); // 削除済みの売上
                }
                else
                {
                    query = query.Where(s => s.SaFlag == 0); // 有効な売上
                }

                // 受注日を検索条件に追加（チェックボックスがチェックされている場合）  
                if (checkBoxDateFilter.Checked)
                {
                    DateTime jyutyuDate = date.Value; // DateTimePickerからの値 
                    query = query.Where(s => s.SaDate.Date == jyutyuDate.Date);
                }

                // 結果を取得  
                var sales = query.ToList();

                if (sales.Any())
                {
                    // dataGridView1 に結果を表示  
                    dataGridView1.DataSource = sales.Select(sale => new
                    {
                        売上ID = sale.SaID,
                        顧客ID = sale.ClID,
                        営業所ID = sale.SoID,
                        社員ID = sale.EmID,
                        受注ID = sale.OrID,
                        受注日 = sale.SaDate,
                        削除フラグ = sale.SaFlag,
                        理由 = sale.SaHidden
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する売上情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア  
                }
            }
        }

        private void UpdateSaleDetails()
        {
            string UriageSyosaiID = TBUriageSyosaiID.Text;
            string uriageID = TBUriageIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;
            string total = TBTotal.Text;

            // 入力チェックを行う
            if (CheckTBValue(TBUriageSyosaiID, UriageSyosaiID, "売上詳細ID")) return;
            if (CheckTBValue(TBUriageIDS, uriageID, "売上ID")) return;
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, suryou, "数量")) return;
            if (CheckTBValue(TBTotal, total, "合計")) return;

            // 競合チェック（売上詳細データの更新）
            if (Kuraberu_kun.Kuraberu_chan("売上", "詳細", "更新", int.Parse(UriageSyosaiID), timestamp) == false)
            {
                return;
            }

            // DBでの各項目の存在確認
            using (var context = new SalesManagementContext())
            {
                // 売上詳細IDが存在するか確認
                int syosai;
                if (!int.TryParse(UriageSyosaiID, out syosai) || !context.TSaleDetails.Any(s => s.SaDetailID == syosai))
                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 売上IDが存在するか確認
                // 売上IDが存在しない場合
                int uriage;
                if (!int.TryParse(uriageID, out uriage) || !context.TSales.Any(s => s.SaID == uriage))
                {
                    NotFound(TBUriageIDS, "売上", uriageID);
                    return;
                }

                // 商品IDが存在しない場合
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    NotFound(TBSyohinID, "商品", syohinID);
                    return;
                }

                // 売上詳細の更新
                var saleDetail = context.TSaleDetails.SingleOrDefault(sa => sa.SaDetailID.ToString() == UriageSyosaiID);
                if (saleDetail != null)
                {
                    saleDetail.SaDetailID = int.Parse(UriageSyosaiID);
                    saleDetail.PrID = int.Parse(syohinID);
                    saleDetail.SaID = int.Parse(uriageID);
                    saleDetail.SaQuantity = int.Parse(suryou);
                    saleDetail.SaPrTotalPrice = int.Parse(total);

                    context.SaveChanges();
                    MessageBox.Show("売上詳細の更新が成功しました。");
                    DisplaySaleDetails();
                    Log_Sale(saleDetail.SaDetailID);
                    ResetYellowBackgrounds(this);
                }
                else
                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterSaleDetails()
        {
            try
            {
                string uriageID = TBUriageIDS.Text;
                string syohinID = TBSyohinID.Text;
                string suryou = TBSuryou.Text;
                string total = TBTotal.Text;

                // 入力チェック
                if (CheckTBValue(TBUriageIDS, uriageID, "売上ID"))
                    if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
                if (CheckTBValue(TBSuryou, suryou, "数量")) return;

                using (var context = new SalesManagementContext())
                {
                    // 売上IDの検証
                    int uriage;
                    if (!int.TryParse(uriageID, out uriage) || !context.TSales.Any(s => s.SaID == uriage))
                    {
                        NotFound(TBUriageIDS, "売上", uriageID);
                        return;
                    }

                    // 商品IDが存在しない場合
                    int shouhin;
                    if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                    {
                        NotFound(TBSyohinID, "商品", syohinID);
                        return;
                    }

                    // 数量の検証
                    int quantity;
                    if (!int.TryParse(suryou, out quantity) || quantity <= 0)
                    {
                        MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 売上詳細が既に登録されていないか確認
                    var existingOrderDetail = context.TSaleDetails.FirstOrDefault(o => o.SaID == uriage && o.PrID == shouhin);
                    if (existingOrderDetail != null)
                    {
                        MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newSaleDetail = new TSaleDetail
                    {
                        SaID = uriage,
                        PrID = shouhin,
                        SaQuantity = quantity
                    };

                    // 合計金額が入力されていない場合は自動で計算
                    if (string.IsNullOrEmpty(total))
                    {
                        var product = context.MProducts.SingleOrDefault(p => p.PrID == newSaleDetail.PrID);
                        if (product != null)
                        {
                            newSaleDetail.SaPrTotalPrice = product.Price * newSaleDetail.SaQuantity;
                        }
                        else
                        {
                            MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else if (!decimal.TryParse(total, out decimal totalPrice))
                    {
                        MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        newSaleDetail.SaPrTotalPrice = totalPrice;
                    }

                    // 新規売上詳細をデータベースに追加
                    context.TSaleDetails.Add(newSaleDetail);
                    context.SaveChanges();
                    MessageBox.Show("売上詳細の登録が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplaySaleDetails();
                    Log_Sale(newSaleDetail.SaDetailID);
                    ResetYellowBackgrounds(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void DisplaySaleDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 売上詳細のリストを取得（checkBox1の状態に応じて並べ替え）
                    var saleDetails = checkBox1.Checked
                        ? context.TSaleDetails.OrderByDescending(sd => sd.SaID).ToList() // 降順
                        : context.TSaleDetails.OrderBy(sd => sd.SaID).ToList();          // 昇順

                    // checkBox_2がチェックされている場合、フィルタリングを無視してすべての詳細を表示
                    var visibleUriageDetails = checkBox_2.Checked
                        ? saleDetails // チェックされていれば全て表示（並び替え済み）
                        : saleDetails.Where(sd =>
                        {
                            var Sale = context.TSales.FirstOrDefault(s => s.SaID == sd.SaID);
                            return Sale == null || (Sale.SaFlag != 1);
                        }).ToList();

                    dataGridView3.DataSource = visibleUriageDetails.Select(sa => new
                    {
                        売上詳細ID = sa.SaDetailID,
                        売上ID = sa.SaID,
                        商品ID = sa.PrID,
                        数量 = sa.SaQuantity.ToString("N0"),
                        合計金額 = sa.SaPrTotalPrice.ToString("N0")

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchSaleDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                string uriagesyosaiID = TBUriageSyosaiID.Text;
                string uriageID = TBUriageIDS.Text;
                string syohinID = TBSyohinID.Text;
                string suryou = TBSuryou.Text;
                string total = TBTotal.Text;

                // 基本的なクエリ
                var query = context.TSaleDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(uriagesyosaiID))
                {
                    // 受注詳細IDを検索条件に追加
                    query = query.Where(sa => sa.SaDetailID.ToString() == uriagesyosaiID);
                }

                if (!string.IsNullOrEmpty(uriageID))
                {
                    // 受注IDを検索条件に追加
                    query = query.Where(sa => sa.SaID.ToString() == uriageID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(sa => sa.PrID.ToString() == syohinID);
                }

                if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                {
                    // 数量を検索条件に追加
                    query = query.Where(sa => sa.SaQuantity == quantity);
                }

                if (!string.IsNullOrEmpty(total) && int.TryParse(total, out int Gkingaku))
                {
                    // 数量を検索条件に追加
                    query = query.Where(sa => sa.SaPrTotalPrice == Gkingaku);
                }
                // 結果を取得
                var saleDetails = query.ToList();

                if (saleDetails.Any())
                {
                    dataGridView3.DataSource = saleDetails.Select(sa => new
                    {
                        売上詳細ID = sa.SaDetailID,
                        売上ID = sa.SaID,
                        商品ID = sa.PrID,
                        数量 = sa.SaQuantity,
                        合計金額 = sa.SaPrTotalPrice.ToString("N0")
                    }).ToList();
                }
                else

                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToggleSaleSelection()
        {
            isSaleSelected = !isSaleSelected;
            saleFlag = isSaleSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isSaleSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);

            if (saleFlag == "←通常")
                lastFocusedPanelID = 1;
            else if (saleFlag == "詳細→")
                lastFocusedPanelID = 2;
        }

        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleSaleSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
            UpdateClose_kun(saleFlag);
        }

        private void UpdateFlagButtonText()
        {
            // b_FlagSelectorのテキストを現在の状態に合わせる
            b_FormSelector.Text = saleFlag;
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
                        TBSalesID.Text = "";
                    }
                    else
                    {
                        TBSalesID.Text = row.Cells["売上ID"].Value.ToString();
                    }
                    // 各テキストボックスにデータを入力
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["売上日"].Value);
                    // 注文状態や非表示ボタン、備考も必要に応じて設定
                    // 非表示ボタンや備考もここで設定
                    // 例: hiddenButton.Text = row.Cells["非表示ボタン"].Value.ToString();
                    // 例: hiddenReason.Text = row.Cells["備考"].Value.ToString();
                    UpdateTextBoxState(checkBoxSyain.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (label2.Text == "登録")
                    {
                        TBUriageSyosaiID.Text = "";
                        TBTotal.Text = "";
                    }
                    else
                    {
                        TBUriageSyosaiID.Text = row.Cells["売上詳細ID"].Value.ToString();
                        TBTotal.Text = "";
                    }
                    // 各テキストボックスにデータを入力
                    TBUriageSyosaiID.Text = row.Cells["売上詳細ID"].Value.ToString();
                    TBUriageIDS.Text = row.Cells["売上ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // クリックした行のインデックスを取得 
                int rowIndex = e.RowIndex;

                // 行インデックスが有効かどうかをチェック 
                if (rowIndex >= 0)
                {
                    // 行データを取得 
                    DataGridViewRow row = dataGridView3.Rows[rowIndex];
                    if (label2.Text == "登録")
                    {
                        TBUriageSyosaiID.Text = "";
                        TBTotal.Text = "";
                    }
                    else
                    {
                        TBUriageSyosaiID.Text = row.Cells["売上詳細ID"].Value.ToString();
                        TBTotal.Text = row.Cells["合計金額"].Value.ToString();
                    }
                    // 各テキストボックスにデータを入力
                    TBUriageIDS.Text = row.Cells["売上ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ToggleSaleSelection();
                UpdateFlagButtonText();
                lastFocusedPanelID = panelID; // 現在のパネルIDを更新
                UpdateClose_kun(saleFlag);
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
        private void TBSalesID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBKokyakuID_TextChanged(object sender, EventArgs e)
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

        private void TBJyutyuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }
        //
        private void TBUriageSyosaiID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBUriageIDS_TextChanged(object sender, EventArgs e)
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

        private void TBTotal_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 10);
        }
        private void colorReset()
        {

            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    tbfalse();
                    break;
                default:
                    TBSalesID.BackColor = SystemColors.Window;
                    TBKokyakuID.BackColor = SystemColors.Window;
                    TBShopID.BackColor = SystemColors.Window;
                    TBShainID.BackColor = SystemColors.Window;
                    TBJyutyuID.BackColor = SystemColors.Window;

                    TBUriageSyosaiID.BackColor = SystemColors.Window;
                    TBUriageIDS.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBSuryou.BackColor = SystemColors.Window;
                    TBTotal.BackColor = SystemColors.Window;
                    break;
            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBSalesID.KeyPress += NumericTextBox_KeyPress;
            TBKokyakuID.KeyPress += NumericTextBox_KeyPress;
            TBShopID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBJyutyuID.KeyPress += NumericTextBox_KeyPress;

            TBUriageSyosaiID.KeyPress += NumericTextBox_KeyPress;
            TBUriageIDS.KeyPress += NumericTextBox_KeyPress;
            TBSyohinID.KeyPress += NumericTextBox_KeyPress;
            TBSuryou.KeyPress += NumericTextBox_KeyPress;
            TBTotal.KeyPress += NumericTextBox_KeyPress;
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
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // ボタンを取得
                    Button button = sender as Button;

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
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // ボタンを取得
                    Button button = sender as Button;

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
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // ボタンを取得
                    Button button = sender as Button;

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
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // ボタンを取得
                    Button button = sender as Button;

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
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // ボタンを取得
                    Button button = sender as Button;

                    // バッジを描画
                    if (button != null)
                    {
                        badge.pinpoint(e, button);
                    }
                }
            }
        }
        private void Log_Sale(int id)
        {
            string ModeFlag = "";
            if (saleFlag == "←通常")
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
                            Display = "売上",
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
                        MessageBox.Show("最新のログ履歴が見つかりませんでした。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

