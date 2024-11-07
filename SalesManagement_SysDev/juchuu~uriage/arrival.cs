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
    public partial class arrival : Form
    {
        private bool isArrivalSelected = true; // 初期状態を入荷(TArrival)に設定
        private string arrivalFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス

        public arrival(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.Load += new EventHandler(arrival_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

        }

        private void arrival_Load(object sender, EventArgs e)
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
            labelStatus.labelstatus(label2, b_kakutei);
        }

        // メインメニューに戻る 
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        // 各ボタンでの画面遷移
        private void b_ord_Click(object sender, EventArgs e) => formChanger.NavigateToOrderForm();
        private void b_acc_Click(object sender, EventArgs e) => formChanger.NavigateToAcceptingOrderForm();
        private void b_shi_Click(object sender, EventArgs e) => formChanger.NavigateToShippingForm();
        private void b_sal_Click(object sender, EventArgs e) => formChanger.NavigateToSalesForm();
        private void b_lss_Click(object sender, EventArgs e) => formChanger.NavigateToIssueForm();
        private void clear_Click(object sender, EventArgs e) => ClearText();

        private void ClearText()
        {
            TBNyuukaId.Text = "";
            TBShopId.Text = "";
            TBShainId.Text = "";
            TBKokyakuId.Text = "";
            TBJyutyuId.Text = "";
            NyuukaFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBNyukaSyosaiID.Text = "";
            TBNyuukaIDS.Text = "";
            TBSuryou.Text = "";
            TBSyohinID.Text = "";
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
                        HandleArrivalOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        HandleArrivalDetailOperation();
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
        private void HandleArrivalOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateArrival();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterArrival();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayArrivals();
                    break;
                case CurrentStatus.Status.検索:
                    SearchArrivals();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }

        private void HandleArrivalDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateArrivalDetails();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterArrivalDetails();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayArrivalDetails();
                    break;
                case CurrentStatus.Status.検索:
                    SearchArrivalDetails();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }


        private void UpdateArrival()
        {
            string NyuukaId = TBNyuukaId.Text;
            string ShopId = TBShopId.Text;
            string ShainId = TBShainId.Text;
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool NyuukaFlg = NyuukaFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Nyuukodate = date.Value;
            CurrentStatus.ResetStatus(label2);



            using (var context = new SalesManagementContext())
            {
                var arrival = context.TArrivals.SingleOrDefault(o => o.OrId.ToString() == JyutyuId);
                if (arrival != null)
                {
                    // 新しい入荷情報を作成
                    var Arrival = new TArrival
                    {
                        SoId = int.Parse(ShopId),                    // 店舗ID
                        EmId = int.Parse(ShainId),// 社員ID（null許容）
                        ClId = int.Parse(KokyakuId),                 // クライアントID
                        OrId = int.Parse(JyutyuId),                       // 受注ID
                        ArDate = Nyuukodate,                         // 入荷日
                        ArStateFlag = NyuukaFlg ? 1 : 0,             // 入荷状態フラグ
                        ArFlag = DelFlg ? 1 : 0,                     // 削除フラグ
                        ArHidden = Riyuu                              // 理由
                    };

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する入荷が見つかりません。");
                }
            }
        }



        private void RegisterArrival()
        {
            string NyuukaId = TBNyuukaId.Text;
            string ShopId = TBShopId.Text;
            string ShainId = TBShainId.Text;
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool NyuukaFlg = NyuukaFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Nyuukodate = date.Value;
            CurrentStatus.ResetStatus(label2);

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (!int.TryParse(ShopId, out shop) || !context.MSalesOffices.Any(s => s.SoId == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。");
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
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

                // EmIdがMEmployeeテーブルに存在するか確認
                int juchu;
                if (!int.TryParse(JyutyuId, out juchu) || !context.TOrders.Any(j => j.OrId == juchu))
                {
                    MessageBox.Show("受注IDが存在しません。");
                    return;
                }
                // 入荷が既に存在するか確認
                var arrival = context.TArrivals.SingleOrDefault(o => o.OrId.ToString() == NyuukaId);
                if (arrival == null)
                {
                    try
                    { // 新しい入荷情報を作成
                        var newArrival = new TArrival
                        {
                            SoId = int.Parse(ShopId),                           // 店舗ID
                            EmId = int.Parse(ShainId), // 社員ID（null許容）
                            ClId = int.Parse(KokyakuId),                        // クライアントID
                            OrId = int.Parse(JyutyuId),                         // 受注ID
                            ArDate = Nyuukodate,                                // 入荷日
                            ArStateFlag = NyuukaFlg ? 1 : 0,                    // 入荷状態フラグ
                            ArFlag = DelFlg ? 1 : 0,                            // 削除フラグ
                            ArHidden = Riyuu
                        };

                        // 入荷情報をコンテキストに追加
                        context.TArrivals.Add(newArrival);


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
                    MessageBox.Show("既に入荷が存在しています。");
                }
            }
        }




        private void DisplayArrivals()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var arrivals = context.TArrivals.ToList();

                    // データを選択してDataGridViewに表示
                    dataGridView1.DataSource = arrivals.Select(o => new
                    {
                        入荷ID = o.ArId,            // 入荷ID
                        営業所ID = o.SoId,              // 店舗ID
                        社員ID = o.EmId,           // 社員ID
                        顧客ID = o.ClId,             // クライアントID
                        受注ID = o.OrId,              // 受注ID
                        入荷日 = o.ArDate,        // 入荷日
                        状態フラグ = o.ArStateFlag,     // 入荷状態フラグ
                        非表示フラグ = o.ArFlag,         // 削除フラグ
                        非表示理由 = o.ArHidden            // 理由
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }


        private void SearchArrivals()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                string nyuukaId = TBNyuukaId.Text;
                string shopId = TBShopId.Text;
                string shainId = TBShainId.Text;
                string kokyakuId = TBKokyakuId.Text;
                string jyutyuId = TBJyutyuId.Text;
                DateTime? nyuukodate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TArrivals.AsQueryable();

                // 入荷IDを検索条件に追加
                if (!string.IsNullOrEmpty(nyuukaId))
                {
                    int arId = int.Parse(nyuukaId);
                    query = query.Where(arrival => arrival.ArId == arId);
                }

                // 店舗IDを検索条件に追加
                if (!string.IsNullOrEmpty(shopId))
                {
                    int soId = int.Parse(shopId);
                    query = query.Where(arrival => arrival.SoId == soId);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainId))
                {
                    int emId = int.Parse(shainId);
                    query = query.Where(arrival => arrival.EmId == emId);
                }

                // 顧客IDを検索条件に追加
                if (!string.IsNullOrEmpty(kokyakuId))
                {
                    int clId = int.Parse(kokyakuId);
                    query = query.Where(arrival => arrival.ClId == clId);
                }

                // 受注IDを検索条件に追加
                if (!string.IsNullOrEmpty(jyutyuId))
                {
                    int orId = int.Parse(jyutyuId);
                    query = query.Where(arrival => arrival.OrId == orId);
                }

                // 入荷日を検索条件に追加（チェックボックスがチェックされている場合）
                if (nyuukodate.HasValue)
                {
                    query = query.Where(arrival => arrival.ArDate == nyuukodate.Value);
                }

                // 結果を取得
                var arrivals = query.ToList();

                if (arrivals.Any())
                {
                    // データを選択してDataGridViewに表示
                    dataGridView1.DataSource = arrivals.Select(o => new
                    {
                        入荷ID = o.ArId,            // 入荷ID
                        営業所ID = o.SoId,              // 店舗ID
                        社員ID = o.EmId,           // 社員ID
                        顧客ID = o.ClId,             // クライアントID
                        受注ID = o.OrId,              // 受注ID
                        入荷日 = o.ArDate,        // 入荷日
                        状態フラグ = o.ArStateFlag,     // 入荷状態フラグ
                        非表示フラグ = o.ArFlag,         // 削除フラグ
                        非表示理由 = o.ArHidden            // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する入荷が見つかりません。");
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }




        private void UpdateArrivalDetails()
        {
            string jyutyuSyosaiID = TBNyukaSyosaiID.Text;
            string jyutyuID = TBNyuukaIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                var arrivalDetail = context.TArrivalDetails.SingleOrDefault(od => od.ArDetailId.ToString() == jyutyuSyosaiID);
                if (arrivalDetail != null)
                {
                    arrivalDetail.ArId = int.Parse(jyutyuID);
                    arrivalDetail.PrId = int.Parse(syohinID);
                    arrivalDetail.ArQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("入荷詳細の更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する入荷詳細が見つかりません。");
                }
            }
        }

        private void RegisterArrivalDetails()
        {
            string NyuukaSyosaiID = TBNyukaSyosaiID.Text;
            string NyuukaID = TBNyuukaIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                int nyuuka;
                if (!int.TryParse(NyuukaID, out nyuuka) || !context.TArrivals.Any(n => n.ArId == nyuuka))
                {
                    MessageBox.Show("発注IDが存在しません。");
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrId == shouhin))
                {
                    MessageBox.Show("社員IDが存在しません。");
                    return;
                }
                var newArrivalDetail = new TArrivalDetail
                {
                    ArId = int.Parse(NyuukaID),
                    PrId = int.Parse(syohinID),
                    ArQuantity = int.Parse(suryou),
                };

                context.TArrivalDetails.Add(newArrivalDetail);
                context.SaveChanges();
                MessageBox.Show("入荷詳細の登録が成功しました。");
            }
        }

        private void DisplayArrivalDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var arrivalDetails = context.TArrivalDetails.ToList();

                    dataGridView2.DataSource = arrivalDetails.Select(od => new
                    {
                        入荷詳細ID = od.ArDetailId,
                        入荷ID = od.ArId,
                        商品ID = od.PrId,
                        数量 = od.ArQuantity,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchArrivalDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var jyutyuSyosaiID = TBJyutyuSyosaiID.Text;
                var jyutyuID = TBNyuukaIDS.Text;
                var syohinID = TBSyohinID.Text;
                var suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.TArrivalDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(jyutyuSyosaiID))
                {
                    // 入荷詳細IDを検索条件に追加
                    query = query.Where(od => od.ArDetailId.ToString() == jyutyuSyosaiID);
                }

                if (!string.IsNullOrEmpty(jyutyuID))
                {
                    //入荷IDを検索条件に追加
                    query = query.Where(od => od.ArId.ToString() == jyutyuID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrId.ToString() == syohinID);
                }

                if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                {
                    // 数量を検索条件に追加
                    query = query.Where(od => od.ArQuantity == quantity);
                }



                // 結果を取得
                var arrivalDetails = query.ToList();

                if (arrivalDetails.Any())
                {
                    dataGridView2.DataSource = arrivalDetails.Select(od => new
                    {
                        入荷詳細ID = od.ArDetailId,
                        入荷ID = od.ArId,
                        商品ID = od.PrId,
                        数量 = od.ArQuantity,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する入荷詳細が見つかりません。");
                }
            }
        }




        private void ToggleArrivalSelection()
        {
            isArrivalSelected = !isArrivalSelected;
            arrivalFlag = isArrivalSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isArrivalSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);
        }


        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleArrivalSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
        }


        private void UpdateFlagButtonText()
        {
            // b_FlagSelectorのテキストを現在の状態に合わせる
            b_FormSelector.Text = arrivalFlag;
        }



        private void Nyuukaflag_CheckedChanged(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

=======
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
                    TBNyuukaId.Text = row.Cells["入荷ID"].Value.ToString();
                    TBShopId.Text = row.Cells["営業所ID"].Value.ToString();
                    TBShainId.Text = row.Cells["社員ID"].Value.ToString();
                    TBKokyakuId.Text = row.Cells["顧客ID"].Value.ToString();
                    TBJyutyuId.Text = row.Cells["受注ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["入荷日"].Value);
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
                    TBNyukaSyosaiID.Text = row.Cells["入荷詳細ID"].Value.ToString();
                    TBNyuukaIDS.Text = row.Cells["入荷ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
>>>>>>> 21d7d1727b52ed8302ee1ae6a674c365f8d1db52
        }
    }


}

