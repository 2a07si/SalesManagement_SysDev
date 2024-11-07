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
    public partial class sales : Form
    {
        private bool isSaleSelected = true; // 初期状態を受注(TOrder)に設定
        private string saleFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;
        public sales()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //  this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(sales_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

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

        private void b_flg_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
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
        }

        private void b_kakutei_Click(object sender, EventArgs e)
        {
            try
            {
                // モードに基づいて処理を分岐
                switch (CurrentStatus.CurrentMode)
                {
                    case CurrentStatus.Mode.通常:
                        HandleSaleOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        HandleSaleDetailOperation();
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
                    MessageBox.Show("無効な操作です。");
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
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }


        private void UpdateSale()
        {
            string jyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string salesID = TBSalesID.Text;
            DateTime salesDate = date.Value;
            bool delFlag = DelFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                var sales = context.TSales.SingleOrDefault(s => s.SaId.ToString() == salesID);
                if (sales != null)
                {
                    sales.SoId = int.Parse(shopID);
                    sales.EmId = int.Parse(shainID);
                    sales.ClId = int.Parse(kokyakuID);
                    sales.SaId = int.Parse(salesID);
                    sales.OrId = int.Parse(jyutyuID);
                    sales.SaDate = salesDate;
                    sales.SaHidden = delFlag ? "1" : "0";

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する売上情報が見つかりません。");
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
                string jyutyuID = TBJyutyuID.Text;
                DateTime salesDate = date.Value;
                bool delFlag = DelFlag.Checked;

                using (var context = new SalesManagementContext())
                {
                    int shop;
                    if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoId == shop))
                    {
                        MessageBox.Show("営業所IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int employeeId;
                    if (!int.TryParse(shainID, out employeeId) || !context.MEmployees.Any(e => e.EmId == employeeId))
                    {
                        MessageBox.Show("社員IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int kokyaku;
                    if (!int.TryParse(kokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClId == kokyaku))
                    {
                        MessageBox.Show("顧客IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int juchu;
                    if (!int.TryParse(jyutyuID, out juchu) || !context.TOrders.Any(j => j.OrId == juchu))
                    {
                        MessageBox.Show("受注IDが存在しません。", "データエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newSale = new TSale
                    {
                        SoId = shop,
                        EmId = employeeId,
                        ClId = kokyaku,
                        OrId = juchu,
                        SaDate = salesDate,
                        SaHidden = delFlag ? "1" : "0"
                    };

                    context.TSales.Add(newSale);
                    context.SaveChanges();
                    MessageBox.Show("登録が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示
                    var sales = checkBox_2.Checked
                        ? context.TSales.ToList()  // チェックされていれば全ての注文を表示
                        : context.TSales.Where(o => o.SaHidden != "1").ToList();  // チェックされていなければ非表示フラグが "1" のものを除外

                    dataGridView1.DataSource = sales.Select(s => new
                    {
                        売上ID = s.SaId,
                        受注ID = s.OrId,
                        営業所ID = s.SoId,
                        社員ID = s.EmId,
                        顧客ID = s.ClId,
                        売上日 = s.SaDate,
                        売上フラグ = s.SaFlag,
                        非表示フラグ = s.SaHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchSales()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var jyutyuID = TBJyutyuID.Text.Trim();       // 受注ID 
                var shopID = TBShopID.Text.Trim();           // 営業所ID 
                var shainID = TBShainID.Text.Trim();         // 社員ID 
                var kokyakuID = TBKokyakuID.Text.Trim();     // 顧客ID 
                var salesID = TBSalesID.Text.Trim();     // 担当者 

                // 基本的なクエリ 
                var query = context.TSales.AsQueryable();

                // 受注IDを検索条件に追加 
                if (!string.IsNullOrEmpty(jyutyuID) && int.TryParse(jyutyuID, out int parsedJyutyuID))
                {
                    query = query.Where(s => s.OrId == parsedJyutyuID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                {
                    query = query.Where(s => s.SoId == parsedShopID);
                }

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(s => s.EmId == parsedShainID);
                }

                // 顧客IDを検索条件に追加 
                if (!string.IsNullOrEmpty(kokyakuID) && int.TryParse(kokyakuID, out int parsedKokyakuID))
                {
                    query = query.Where(s => s.ClId == parsedKokyakuID);
                }

                // 担当者名を検索条件に追加 
                if (!string.IsNullOrEmpty(salesID) && int.TryParse(shainID, out int parsedsalesID))
                {
                    query = query.Where(s => s.SaId == parsedsalesID);
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
                        受注ID = sale.OrId,
                        営業所ID = sale.SoId,
                        社員ID = sale.EmId,
                        顧客ID = sale.ClId,
                        売上ID = sale.SaId,
                        受注日 = sale.SaDate,
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



        private void UpdateSaleDetails()
        {
            string UriageSyosaiID = TBUriageSyosaiID.Text;
            string uriageID = TBUriageIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;
            string total = TBTotal.Text;

            using (var context = new SalesManagementContext())
            {
                var saleDetail = context.TSaleDetails.SingleOrDefault(sa => sa.SaDetailId.ToString() == UriageSyosaiID);
                if (saleDetail != null)
                {
                    saleDetail.SaDetailId = int.Parse(UriageSyosaiID);
                    saleDetail.PrId = int.Parse(syohinID);
                    saleDetail.SaId = int.Parse(uriageID);
                    saleDetail.SaQuantity = int.Parse(suryou);
                    saleDetail.SaPrTotalPrice = int.Parse(total);

                    context.SaveChanges();
                    MessageBox.Show("受注詳細の更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する受注詳細が見つかりません。");
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
                    if (!int.TryParse(uriageID, out int uriage) || !context.TSales.Any(s => s.SaId == uriage))
                    {
                        MessageBox.Show("売上IDが存在しません。", "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 商品IDの検証
                    if (!int.TryParse(syohinID, out int shouhin) || !context.MProducts.Any(s => s.PrId == shouhin))
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

                    var newSaleDetail = new TSaleDetail
                    {

                        SaId = uriage,
                        PrId = shouhin,
                        SaQuantity = quantity
                    };

                    // 合計金額が入力されていない場合は自動で計算
                    if (string.IsNullOrEmpty(total))
                    {
                        var product = context.MProducts.SingleOrDefault(p => p.PrId == newSaleDetail.PrId);
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

                    dataGridView3.DataSource = saleDetails.Select(sa => new
                    {
                        売上詳細ID = sa.SaDetailId,
                        商品ID = sa.PrId,
                        数量 = sa.SaQuantity,
                        売上ID = sa.SaId,
                        合計金額 = sa.SaPrTotalPrice

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
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
                    query = query.Where(sa => sa.SaDetailId.ToString() == uriagesyosaiID);
                }

                if (!string.IsNullOrEmpty(uriageID))
                {
                    // 受注IDを検索条件に追加
                    query = query.Where(sa => sa.SaId.ToString() == uriageID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(sa => sa.PrId.ToString() == syohinID);
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
                        売上詳細ID = sa.SaDetailId,
                        売上ID = sa.SaId,
                        商品ID = sa.PrId,
                        数量 = sa.SaQuantity,
                        合計金額 = sa.SaPrTotalPrice
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する受注詳細が見つかりません。");
                }
            }
        }




        private void ToggleSaleSelection()
        {
            isSaleSelected = !isSaleSelected;
            saleFlag = isSaleSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isSaleSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);
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

                    // 各テキストボックスにデータを入力
                    TBSalesID.Text = row.Cells["売上ID"].Value.ToString();
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["売上日時"].Value);
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

        private void b_FormSelector_Click_1(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleSaleSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
        }

        private void label_ename_Click(object sender, EventArgs e)
        {

        }

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
                    TBSalesID.Text = row.Cells["売上ID"].Value.ToString();
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["売上日時"].Value);
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
                    DataGridViewRow row = dataGridView2.Rows[rowIndex];

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
    }


}
