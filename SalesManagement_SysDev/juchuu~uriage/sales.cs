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
            AddControlEventHandlers(panel3, 2);  // パネル2の場合
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
                b_lss
            });

            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplaySales();
            DisplaySaleDetails();

            if (Global.EmployeePermission == 1)
            {
                b_reg.Enabled = true;
            }
            else
            {
                b_reg.Enabled = false;
                b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            }
            TBTotal.Enabled = false;

            SetupNumericOnlyTextBoxes();
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
        private void b_lss_Click(object sender, EventArgs e)
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
        }
        private void cleartext()
        {
            TBSalesID.Text = "";
            TBKokyakuID.Text = "";
            TBShopID.Text = "";
            TBShainID.Text = "";
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
        }

        private void tbfalse()
        {
            TBSalesID.Enabled = false;
            TBUriageSyosaiID.Enabled = false;
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
                        MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
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

            if (TBSalesID.Text == "")
            {
                TBSalesID.BackColor = Color.Yellow;
                TBSalesID.Focus();
                MessageBox.Show("売上IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TBShopID.Focus();
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

            using (var context = new SalesManagementContext())
            {
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

                using (var context = new SalesManagementContext())
                {
                    int shop;
                    if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                    {
                        TBShopID.BackColor = Color.Yellow;
                        TBShopID.Focus();
                        MessageBox.Show("営業所IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int employeeID;
                    if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                    {
                        TBShainID.BackColor = Color.Yellow;
                        TBShainID.Focus();
                        MessageBox.Show("社員IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int kokyaku;
                    if (!int.TryParse(kokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                    {
                        TBKokyakuID.BackColor = Color.Yellow;
                        TBKokyakuID.Focus();
                        MessageBox.Show("顧客IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int juchu;
                    if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                    {
                        TBJyutyuID.BackColor = Color.Yellow;
                        TBJyutyuID.Focus();
                        MessageBox.Show("受注IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TBShopID.Text == null)
                    {
                        TBaaaaaID.BackColor = Color.Yellow;
                        TBaaaaaID.Focus();
                        MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TBShainID.Text == null)
                    {
                        TBShainID.BackColor = Color.Yellow;
                        TBShainID.Focus();
                        MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TBKokyakuID.Text == null)
                    {
                        TBKokyakuID.BackColor= Color.Yellow;
                        TBKokyakuID.Focus();
                        MessageBox.Show("顧客IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TBJyutyuID.Text == null)
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
                {
                    var sales = checkBox_2.Checked
                        ? context.TSales.ToList()  // チェックされていれば全ての注文を表示
                        : context.TSales.Where(s => s.SaFlag != 1).ToList();  // チェックされていなければ非表示フラグが "1" のものを除外

                    dataGridView1.DataSource = sales.Select(s => new
                    {
                        売上ID = s.SaID,
                        顧客ID = s.ClID,
                        営業所ID = s.SoID,
                        社員ID = s.EmID,
                        受注ID = s.OrID,
                        売上日 = s.SaDate,
                        売上フラグ = s.SaFlag,
                        非表示理由 = s.SaHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var salesID = TBSalesID.Text.Trim();     // 担当者 

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
                if (!string.IsNullOrEmpty(salesID) && int.TryParse(shainID, out int parsedsalesID))
                {
                    query = query.Where(s => s.SaID == parsedsalesID);
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
                        削除フラグ = DelFlag.Checked ? "〇" : "×"
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

            if (TBUriageSyosaiID.Text == "")
            {
                TBUriageIDS.BackColor = Color.Yellow;
                TBUriageIDS.Focus();
                MessageBox.Show("売上詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBUriageIDS.Text == "")
            {
                MessageBox.Show("売上IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (TBSyohinID.Text == "")
            {
                MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSuryou.Text == "")
            {
                MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {
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
                }
                else
                {
                    MessageBox.Show("該当する売上詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



                using (var context = new SalesManagementContext())
                {
                    // 売上IDの検証
                    if (!int.TryParse(uriageID, out int uriage) || !context.TSales.Any(s => s.SaID == uriage))
                    {
                        MessageBox.Show("売上IDが存在しません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 商品IDの検証
                    if (!int.TryParse(syohinID, out int shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                    {
                        MessageBox.Show("商品IDが存在しません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 数量の検証
                    if (!int.TryParse(suryou, out int quantity) || quantity <= 0)
                    {
                        MessageBox.Show("数量が正しく入力されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TBUriageIDS.Text == "")
                    {
                        MessageBox.Show("売上IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (TBSyohinID.Text == "")
                    {
                        MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (TBSuryou.Text == "")
                    {
                        MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var existingOrderDetail = context.TSaleDetails.FirstOrDefault(o => o.SaID == uriage);
                    if (existingOrderDetail != null)
                    {
                        MessageBox.Show("この売上IDにはすでに売上詳細が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // 処理を終了
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
                            MessageBox.Show("該当する商品が見つかりません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else if (!decimal.TryParse(total, out decimal totalPrice))
                    {
                        MessageBox.Show("合計金額の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // DisplaySaleDetailsの呼び出し
                    try
                    {
                        DisplaySaleDetails();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("売上詳細表示中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("入力された値の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("売上詳細の登録中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySaleDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var saleDetails = context.TSaleDetails.ToList();

                    var visibleUriageDetails = checkBox_2.Checked
                        ? saleDetails
                        : saleDetails.Where(od =>
                        {
                            var Sale = context.TSales.FirstOrDefault(o => o.SaID == od.SaID);
                            return Sale == null || (Sale.SaFlag != 1);
                        }).ToList();

                    dataGridView3.DataSource = visibleUriageDetails.Select(sa => new
                    {
                        売上詳細ID = sa.SaDetailID,
                        売上ID = sa.SaID,
                        商品ID = sa.PrID,
                        数量 = sa.SaQuantity,
                        合計金額 = sa.SaPrTotalPrice

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("該当する売上詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        TBTotal.Text = row.Cells["合計金額"].Value.ToString();
                    }
                    // 各テキストボックスにデータを入力
                    TBUriageSyosaiID.Text = row.Cells["売上詳細ID"].Value.ToString();
                    TBUriageIDS.Text = row.Cells["売上ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
                    TBTotal.Text = row.Cells["合計金額"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }



}

