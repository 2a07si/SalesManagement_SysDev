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
    public partial class shipping : Form
    {

        private bool isShippingSelected = true; // 初期状態を受注(TOrder)に設定
        private string shippingFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;

        // コンストラクターでmainFormを引数として受け取る 
        public shipping(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(shipping_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

        }

        private void shipping_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベルの初期化
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_acc,
                b_sal,
                b_lss
            });
            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
        }
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        private void b_acc_Click(object sender, EventArgs e)
        {
            // 受注管理画面に遷移
            formChanger.NavigateToAcceptingOrderForm(); // acceptingorders フォームに遷移
        }

        // 注文管理画面に遷移 
        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移 
        }

        private void b_lss_Click_2(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm();//出庫管理画面に遷移
        }

        private void b_acc_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToAcceptingOrderForm(); // acceptingorders フォームに遷移
        }

        private void b_sal_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移 
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            // 登録ボタンの処理を追加 
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            // 更新ボタンの処理を追加 
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            // 検索ボタンの処理を追加 
        }

        private void b_flg_Click(object sender, EventArgs e)
        {
            // フラグボタンの処理を追加 
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            // 次へボタンの処理を追加 
        }

        private void b_logout_Click(object sender, EventArgs e)
        {
            // ログアウト処理を追加 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void b_reg_Click_1(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click_1(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_ser_Click_1(object sender, EventArgs e)
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
            TBSyukkaID.Text = "";
            TBKokyakuID.Text = "";
            TBShainID.Text = "";
            TBShopID.Text = "";
            TBJyutyuID.Text = "";
            SyukkaFlag.Checked = false;
            KanriFlag.Checked = false;
            TBRiyuu.Text = "";
            TBSyukkaSyosaiID.Text = "";
            TBSyukkaIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
        }

        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移 
        }

        private void b_kakutei_Click(object sender, EventArgs e)
        {
            try
            {
                // モードに基づいて処理を分岐
                switch (CurrentStatus.CurrentMode)
                {
                    case CurrentStatus.Mode.通常:
                        HandleShippingOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        HandleShippingDetailOperation();
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
        private void HandleShippingOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateShipping();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterShipping();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayShipping();
                    break;
                case CurrentStatus.Status.検索:
                    SearchShipping();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }
        private void HandleShippingDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateShippingDetails();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterShippingDetails();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayShippingDetails();
                    break;
                case CurrentStatus.Status.検索:
                    SearchShippingDetails();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }


        private void UpdateShipping()
        {
            string jyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string shukkaID = TBSyukkaID.Text;
            DateTime shukkaDate = date.Value;
            bool delFlag = KanriFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                var shipping = context.TShipments.SingleOrDefault(sh => sh.ShId.ToString() == shukkaID);
                if (shipping != null)
                {
                    shipping.SoId = int.Parse(shopID);
                    shipping.EmId = int.Parse(shainID);
                    shipping.ClId = int.Parse(kokyakuID);
                    shipping.ShId = int.Parse(shukkaID);
                    shipping.OrId = int.Parse(jyutyuID);
                    shipping.ShFinishDate = shukkaDate;
                    shipping.ShHidden = delFlag ? "1" : "0";

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    DisplayShipping();
                }
                else
                {
                    MessageBox.Show("該当する出荷情報が見つかりません。");
                }
            }
        }

        private void RegisterShipping()
        {
            string jyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string syukkaID = TBSyukkaID.Text;
            DateTime shukkaDate = date.Value;
            string riyuu = TBRiyuu.Text;
            bool syukkaf = SyukkaFlag.Checked;
            bool kanriFlag = KanriFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoId == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。");
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int employeeId;
                if (!int.TryParse(shainID, out employeeId) || !context.MEmployees.Any(e => e.EmId == employeeId))
                {
                    MessageBox.Show("社員IDが存在しません。");
                    return;
                }
                int kokyaku;
                if (!int.TryParse(kokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClId == kokyaku))
                {
                    MessageBox.Show("顧客IDが存在しません。");
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int juchu;
                if (!int.TryParse(jyutyuID, out juchu) || !context.TOrders.Any(j => j.OrId == juchu))
                {
                    MessageBox.Show("受注IDが存在しません。");
                    return;
                }
                var newShipping = new TShipment
                {
                    SoId = int.Parse(shopID),
                    EmId = int.Parse(shainID),
                    ClId = int.Parse(kokyakuID),
                    OrId = int.Parse(jyutyuID),
                    ShFinishDate = shukkaDate,
                    ShStateFlag = syukkaf ? 1 : 0,
                    ShFlag = kanriFlag ? 1 : 0,
                };

                context.TShipments.Add(newShipping);
                try
                {
                    context.SaveChanges(); MessageBox.Show("登録が成功しました。");
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
        }

        private void DisplayShipping()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {

                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示
                    var shipping = checkBox_2.Checked
                        ? context.TShipments.ToList()  // チェックされていれば全ての注文を表示
                        : context.TShipments.Where(o => o.ShHidden != "1").ToList();  // チェックされていなければ非表示フラグが "1" のものを除外
                    dataGridView1.DataSource = shipping.Select(sh => new
                    {
                        出荷ID = sh.ShId,
                        営業所ID = sh.SoId,
                        社員ID = sh.EmId,
                        顧客ID = sh.ClId,
                        受注ID = sh.OrId,
                        出荷終了日 = sh.ShFinishDate,
                        出荷フラグ = sh.ShFlag,
                        非表示フラグ = sh.ShHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchShipping()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var jyutyuID = TBJyutyuID.Text.Trim();       // 受注ID 
                var shopID = TBShopID.Text.Trim();           // 営業所ID 
                var shainID = TBShainID.Text.Trim();         // 社員ID 
                var kokyakuID = TBKokyakuID.Text.Trim();     // 顧客ID 
                var shukkaID = TBSyukkaID.Text.Trim();     // 担当者


                // 基本的なクエリ 
                var query = context.TShipments.AsQueryable();

                // 受注IDを検索条件に追加 
                if (!string.IsNullOrEmpty(jyutyuID) && int.TryParse(jyutyuID, out int parsedJyutyuID))
                {
                    query = query.Where(sh => sh.OrId == parsedJyutyuID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                {
                    query = query.Where(sh => sh.SoId == parsedShopID);
                }

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(sh => sh.EmId == parsedShainID);
                }

                // 顧客IDを検索条件に追加 
                if (!string.IsNullOrEmpty(kokyakuID) && int.TryParse(kokyakuID, out int parsedKokyakuID))
                {
                    query = query.Where(sh => sh.ClId == parsedKokyakuID);
                }

                // 担当者名を検索条件に追加 
                if (!string.IsNullOrEmpty(shukkaID) && int.TryParse(shainID, out int parsedshukkaID))
                {
                    query = query.Where(sh => sh.ShId == parsedshukkaID);
                }

                // 受注日を検索条件に追加（チェックボックスがチェックされている場合） 
                if (checkBoxDateFilter.Checked)
                {
                    DateTime shukkaDate = date.Value; // DateTimePickerからの値
                    query = query.Where(sh => sh.ShFinishDate == shukkaDate.Date);
                }

                // 結果を取得 
                var shipping = query.ToList();

                if (shipping.Any())
                {
                    // dataGridView1 に結果を表示 
                    dataGridView1.DataSource = shipping.Select(sh => new
                    {
                        出荷ID = sh.ShId,
                        顧客ID = sh.ClId,
                        社員ID = sh.EmId,
                        営業所ID = sh.SoId,
                        受注ID = sh.OrId,
                        出荷終了日 = sh.ShFinishDate,
                        出荷フラグ = sh.ShFlag,
                        非表示フラグ = sh.ShHidden,
                        削除フラグ = KanriFlag.Checked ? "〇" : "×"
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する出荷情報が見つかりません。");
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア 
                }
            }
        }



        private void UpdateShippingDetails()
        {
            string shukkasyosaiID = TBSyukkaSyosaiID.Text;
            string shukkaID = TBSyukkaIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                var shippingDetail = context.TShipmentDetails.SingleOrDefault(sh => sh.ShDetailId.ToString() == shukkasyosaiID);
                if (shippingDetail != null)
                {
                    shippingDetail.PrId = int.Parse(syohinID);
                    shippingDetail.ShId = int.Parse(shukkaID);
                    shippingDetail.ShQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("出荷詳細の更新が成功しました。");
                    DisplayShippingDetails();
                }
                else
                {
                    MessageBox.Show("該当する出荷詳細が見つかりません。");
                }
            }
        }

        private void RegisterShippingDetails()
        {
            string shukkaID = TBSyukkaIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                int shukka;
                if (!int.TryParse(shukkaID, out shukka) || !context.TShipments.Any(s => s.ShId == shukka))
                {
                    MessageBox.Show("出荷IDが存在しません。");
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(e => e.PrId == shouhin))
                {
                    MessageBox.Show("商品IDが存在しません。");
                    return;
                }
                var newShippingDetail = new TShipmentDetail
                {
                    PrId = int.Parse(syohinID),
                    ShId = int.Parse(shukkaID),
                    ShQuantity = int.Parse(suryou)
                };

                context.TShipmentDetails.Add(newShippingDetail);
                context.SaveChanges();
                MessageBox.Show("出荷詳細の登録が成功しました。");
            }
        }

        private void DisplayShippingDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var shippingDetails = context.TShipmentDetails.ToList();

                    dataGridView2.DataSource = shippingDetails.Select(sh => new
                    {
                        出荷詳細ID = sh.ShDetailId,
                        商品ID = sh.PrId,
                        数量 = sh.ShQuantity,
                        出荷ID = sh.ShId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchShippingDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                string shukkasyosaiID = TBSyukkaSyosaiID.Text;
                string shukkaID = TBSyukkaIDS.Text;
                string syohinID = TBSyohinID.Text;
                string suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.TShipmentDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(shukkasyosaiID))
                {
                    // 受注詳細IDを検索条件に追加
                    query = query.Where(sh => sh.ShDetailId.ToString() == shukkasyosaiID);
                }

                if (!string.IsNullOrEmpty(shukkaID))
                {
                    // 受注IDを検索条件に追加
                    query = query.Where(sh => sh.ShId.ToString() == shukkaID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(sh => sh.PrId.ToString() == syohinID);
                }

                if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                {
                    // 数量を検索条件に追加
                    query = query.Where(sh => sh.ShQuantity == quantity);
                }
                // 結果を取得
                var shippingDetails = query.ToList();

                if (shippingDetails.Any())
                {
                    dataGridView2.DataSource = shippingDetails.Select(sh => new
                    {
                        出荷詳細ID = sh.ShDetailId,
                        商品ID = sh.PrId,
                        数量 = sh.ShQuantity,
                        出荷ID = sh.ShId
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する出荷詳細が見つかりません。");
                }
            }
        }




        private void ToggleShippingSelection()
        {
            isShippingSelected = !isShippingSelected;
            shippingFlag = isShippingSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isShippingSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);
        }


        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleShippingSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
        }


        private void UpdateFlagButtonText()
        {
            // b_FlagSelectorのテキストを現在の状態に合わせる
            b_FormSelector.Text = shippingFlag;
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
                    TBSyukkaID.Text = row.Cells["出荷ID"].Value.ToString();
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["出荷完了年月日"].Value);
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
                    TBSyukkaSyosaiID.Text = row.Cells["出荷詳細ID"].Value.ToString();
                    TBSyukkaIDS.Text = row.Cells["出荷ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
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
            ToggleShippingSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
        }

        private void b_FormSelector_Click_2(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleShippingSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
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
                    TBSyukkaID.Text = row.Cells["出荷ID"].Value.ToString();
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["出荷完了年月日"].Value);
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
                    TBSyukkaSyosaiID.Text = row.Cells["出荷詳細ID"].Value.ToString();
                    TBSyukkaIDS.Text = row.Cells["出荷ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}
