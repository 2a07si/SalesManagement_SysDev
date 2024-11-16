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
using SalesManagement_SysDev;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace SalesManagement_SysDev
{
    public partial class receivingstock : Form
    {

        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定
        private ClassDataGridViewClearer dgvClearer;

        private Form mainForm;
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassDateNamelabel dateNamelabel;
        private ClassAccessManager accessManager;

        private int lastFocusedPanelId = 1;

        public receivingstock()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット   

            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel3, 2);  // パネル2の場合
        }

        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        private void b_hor_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToHorderForm();
        }

        private void receivingstock_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_hor
            });

            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayReceivingStocks();
            DisplayReceivingStockDetails();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBNyukoID.Text = "";
            TBHattyuuID.Text = "";
            TBShainID.Text = "";
            NyuukoFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBNyuukoSyosaiID.Text = "";
            TBNyuukoIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            PerformSearch();
            TBNyukoID.Enabled = true;
            TBNyuukoSyosaiID.Enabled = true;
        }
        private void PerformSearch()
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            UpdateStatus();
            TBNyukoID.Enabled = true;
            TBNyuukoSyosaiID.Enabled = true;
        }
        private void UpdateStatus()
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            RegisterStatus();
            TBNyukoID.Enabled = false;
            TBNyuukoSyosaiID.Enabled = false;
            TBNyukoID.Text = "";
            TBNyuukoSyosaiID.Text = "";
        }

        private void RegisterStatus()
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplayReceivingStocks();
            DisplayReceivingStockDetails();
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            ListStatus();
            TBNyukoID.Enabled = true;
            TBNyuukoSyosaiID.Enabled = true;
        }
        private void ListStatus()
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplayReceivingStocks();
            DisplayReceivingStockDetails();
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }

        private void kakutei_Click(object sender, EventArgs e)
        {
            try
            {
                // モードに基づいて処理を分岐  
                switch (CurrentStatus.CurrentMode)
                {
                    case CurrentStatus.Mode.通常:
                        colorReset();
                        HandleReceivingStockOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        colorReset();
                        HandleReceivingStockDetailOperation();
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

        private void HandleReceivingStockOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateReceivingStock();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterReceivingStock();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayReceivingStocks();
                    break;
                case CurrentStatus.Status.検索:
                    SearchReceivingStocks();
                    break;
                default:
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void HandleReceivingStockDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateReceivingStockDetails();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterReceivingStockDetails();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayReceivingStockDetails();
                    break;
                case CurrentStatus.Status.検索:
                    SearchReceivingStockDetails();
                    break;
                default:
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void UpdateReceivingStock()
        {
            string nyuukoID = TBNyukoID.Text;
            string haID = TBHattyuuID.Text;
            string shainID = TBShainID.Text;
            DateTime nyuukoDate = date.Value;
            bool nyuukoFlag = NyuukoFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            if (TBHattyuuID.Text == null)
            {
                MessageBox.Show("発注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBNyukoID.Text == null)
            {
                MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShainID.Text == null)
            {
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {
                var receivingStock = context.TWarehousings.SingleOrDefault(ws => ws.WaId.ToString() == nyuukoID);
                if (receivingStock != null)
                {
                    receivingStock.HaId = int.Parse(haID);                 // 発注ID 
                    receivingStock.EmId = int.Parse(shainID);              // 社員ID 
                    receivingStock.WaDate = nyuukoDate;                    // 入庫日 
                    receivingStock.WaShelfFlag = nyuukoFlag ? 2 : 0;       // 入庫棚フラグ 
                    receivingStock.WaFlag = delFlag ? 1 : 0;               // 削除フラグ 
                    receivingStock.WaHidden = riyuu;                       // 理由 

                    // NyuukoFlagがチェックされている場合、入庫詳細の確認を行う 
                    if (nyuukoFlag)
                    {
                        // 入庫詳細が存在するか確認 
                        var receivingDetailsExist = context.TWarehousingDetails
                            .Any(wd => wd.WaId == receivingStock.WaId); // WaId が一致する入庫詳細が存在するか確認 

                        if (!receivingDetailsExist)
                        {
                            // 入庫詳細が存在しない場合はエラーメッセージを表示 
                            MessageBox.Show("入庫詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断 
                        }

                        MessageBox.Show("入庫確定処理");
                        // 入庫詳細が存在する場合、入庫確認処理を実行 
                        ReceiveConfirm(receivingStock.WaId);

                        // 在庫更新メッセージを保存
                        var receivingDetails = context.TWarehousingDetails
                            .Where(wd => wd.WaId == receivingStock.WaId);

                        foreach (var detail in receivingDetails)
                        {
                            Global.AddStockUpdateMessage(detail.PrId, detail.WaQuantity); // メッセージ追加
                        }
                    }

                    // 更新を保存 
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        DisplayReceivingStocks(); // 更新後に入庫情報を再表示 
                    }
                    catch (DbUpdateException ex)
                    {
                        // inner exception の詳細を表示 
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"エラーの詳細: {ex.InnerException.Message}");
                        }
                        else
                        {
                            MessageBox.Show("エンティティの変更を保存中にエラーが発生しました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("該当する入庫情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterReceivingStock()
        {
            string haID = TBHattyuuID.Text;
            string shainID = TBShainID.Text;
            DateTime nyuukoDate = date.Value;
            bool nyuukoFlag = NyuukoFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            using (var context = new SalesManagementContext())
            {
                // HaIDがTHattyuテーブルに存在するか確認
                int hattyuId;
                if (!int.TryParse(haID, out hattyuId) || !context.THattyus.Any(h => h.HaId == hattyuId))
                {
                    MessageBox.Show("発注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int employeeId;
                if (!int.TryParse(shainID, out employeeId) || !context.MEmployees.Any(e => e.EmId == employeeId))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBNyukoID.Text == null)
                {
                    MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBShainID.Text == null)
                {
                    MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newReceivingStock = new TWarehousing
                {
                    HaId = hattyuId, // 発注IDを適切に設定
                    EmId = employeeId, // 社員IDを適切に設定
                    WaDate = nyuukoDate,
                    WaShelfFlag = nyuukoFlag ? 2 : 0,
                    WaFlag = nyuukoFlag ? 1 : 0,
                    WaHidden = riyuu
                };

                context.TWarehousings.Add(newReceivingStock);
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("登録が成功しました。");
                    DisplayReceivingStocks();
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
                        MessageBox.Show("エンティティの変更を保存中にエラーが発生しました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // その他のエラーに対処する
                    MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DisplayReceivingStocks()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {

                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示
                    var receivingStocks = checkBox_2.Checked
                        ? context.TWarehousings.ToList()  // チェックされていれば全ての注文を表示
                        : context.TWarehousings.Where(o => o.WaFlag != 1 && o.WaShelfFlag != 2).ToList();  // チェックされていなければ非表示フラグが "1" のものを除外
                    dataGridView1.DataSource = receivingStocks.Select(ws => new
                    {
                        入庫ID = ws.WaId,
                        発注ID = ws.HaId,
                        社員ID = ws.EmId,
                        入庫年月日 = ws.WaDate,
                        入庫済フラグ = ws.WaShelfFlag,
                        非表示フラグ = ws.WaFlag,
                        非表示理由 = ws.WaHidden

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchReceivingStocks()
        {
            using (var context = new SalesManagementContext())
            {
                var nyuukoID = TBNyukoID.Text.Trim();
                var haID = TBHattyuuID.Text.Trim();
                var shainID = TBShainID.Text.Trim();

                var query = context.TWarehousings.AsQueryable();

                if (!string.IsNullOrEmpty(nyuukoID) && int.TryParse(nyuukoID, out int parsedNyuukoID))
                {
                    query = query.Where(ws => ws.WaId == parsedNyuukoID);
                }

                if (!string.IsNullOrEmpty(haID) && int.TryParse(haID, out int parsedHaID))
                {
                    query = query.Where(ws => ws.HaId == parsedHaID);
                }

                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(ws => ws.EmId == parsedShainID);
                }

                var receivingStocks = query.ToList();

                if (receivingStocks.Any())
                {
                    dataGridView1.DataSource = receivingStocks.Select(ws => new
                    {
                        入庫ID = ws.WaId,
                        発注ID = ws.HaId,
                        社員ID = ws.EmId,
                        入庫年月日 = ws.WaDate,
                        入庫済フラグ = ws.WaFlag,
                        非表示フラグ = ws.WaHidden
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する入庫情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null;
                }
            }
        }

        private void UpdateReceivingStockDetails()
        {
            string nyuukoDetailID = TBNyuukoSyosaiID.Text;
            string nyuukoID = TBNyuukoIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            if (TBNyuukoSyosaiID.Text == null)
            {
                MessageBox.Show("入庫詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBNyuukoIDS.Text == null)
            {
                MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (TBSyohinID.Text == null)
            {
                MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSuryou.Text == null)
            {
                MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {
                var receivingStockDetail = context.TWarehousingDetails.SingleOrDefault(ws => ws.WaDetailId.ToString() == nyuukoDetailID);
                if (receivingStockDetail != null)
                {
                    receivingStockDetail.WaId = int.Parse(nyuukoID);
                    receivingStockDetail.PrId = int.Parse(syohinID);
                    receivingStockDetail.WaQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("入庫詳細の更新が成功しました。");
                    DisplayReceivingStockDetails();
                }
                else
                {
                    MessageBox.Show("該当する入庫詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterReceivingStockDetails()
        {
            string nyuukoID = TBNyuukoIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                // WaIDがTWarehousingテーブルに存在するか確認
                int warehousingId;
                if (!int.TryParse(nyuukoID, out warehousingId) || !context.TWarehousings.Any(w => w.WaId == warehousingId))
                {
                    MessageBox.Show("入庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // PrIDがTProductテーブルに存在するか確認
                int productId;
                if (!int.TryParse(syohinID, out productId) || !context.MProducts.Any(p => p.PrId == productId))
                {
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int quantity;
                if (!int.TryParse(suryou, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("数量が無効です。正の整数を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBNyuukoIDS.Text == null)
                {
                    MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (TBSyohinID.Text == null)
                {
                    MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBSuryou.Text == null)
                {
                    MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newReceivingStockDetail = new TWarehousingDetail
                {
                    WaId = warehousingId, // 入庫IDを適切に設定
                    PrId = productId, // 商品IDを適切に設定
                    WaQuantity = quantity // 数量を適切に設定
                };

                context.TWarehousingDetails.Add(newReceivingStockDetail);

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("入庫詳細の登録が成功しました。");
                    DisplayReceivingStockDetails();
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
                        MessageBox.Show("エンティティの変更を保存中にエラーが発生しました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // その他のエラーに対処する
                    MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DisplayReceivingStockDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var WarehousingDetails = context.TWarehousingDetails.ToList();

                    var visibleWarehousingDetails = checkBox_2.Checked
                        ? WarehousingDetails
                        : WarehousingDetails.Where(od =>
                        {
                            var Warehousing = context.TWarehousings.FirstOrDefault(o => o.WaId == od.WaId);

                            return Warehousing == null || (Warehousing.WaFlag != 1 && Warehousing.WaShelfFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleWarehousingDetails.Select(ws => new
                    {
                        入庫詳細ID = ws.WaDetailId,
                        入庫ID = ws.WaId,
                        商品ID = ws.PrId,
                        数量 = ws.WaQuantity,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchReceivingStockDetails()
        {
            using (var context = new SalesManagementContext())
            {
                var nyuukoDetailID = TBNyuukoSyosaiID.Text.Trim();
                var nyuukoID = TBNyuukoIDS.Text.Trim();
                var syohinID = TBSyohinID.Text.Trim();

                var query = context.TWarehousingDetails.AsQueryable();

                if (!string.IsNullOrEmpty(nyuukoDetailID) && int.TryParse(nyuukoDetailID, out int parsedNyuukoDetailID))
                {
                    query = query.Where(ws => ws.WaDetailId == parsedNyuukoDetailID);
                }

                if (!string.IsNullOrEmpty(nyuukoID) && int.TryParse(nyuukoID, out int parsedNyuukoID))
                {
                    query = query.Where(ws => ws.WaId == parsedNyuukoID);
                }

                if (!string.IsNullOrEmpty(syohinID) && int.TryParse(syohinID, out int parsedSyohinID))
                {
                    query = query.Where(ws => ws.PrId == parsedSyohinID);
                }

                var receivingStockDetails = query.ToList();

                if (receivingStockDetails.Any())
                {
                    dataGridView2.DataSource = receivingStockDetails.Select(ws => new
                    {
                        入庫詳細ID = ws.WaDetailId,
                        入庫ID = ws.WaId,
                        商品ID = ws.PrId,
                        数量 = ws.WaQuantity,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する入庫詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView2.DataSource = null;
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
                lastFocusedPanelId = 1;
            else if (orderFlag == "詳細→")
                lastFocusedPanelId = 2;

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
                    TBNyukoID.Text = row.Cells["入庫ID"].Value.ToString() ?? string.Empty;
                    TBHattyuuID.Text = row.Cells["発注ID"].Value.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString() ?? string.Empty;
                    date.Value = Convert.ToDateTime(row.Cells["入庫日"].Value);
                    NyuukoFlag.Checked = Convert.ToBoolean(row.Cells["入庫フラグ"].Value);
                    DelFlag.Checked = Convert.ToBoolean(row.Cells["非表示フラグ"].Value);
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
                    TBNyuukoSyosaiID.Text = row.Cells["入庫詳細ID"].Value.ToString();
                    TBNyuukoIDS.Text = row.Cells["入庫ID"].Value.ToString();
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBSuryou.Text = row.Cells["数量"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ReceiveConfirm(int WaId)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                // 入庫情報を取得
                var receive = context.TWarehousingDetails.SingleOrDefault(o => o.WaId == WaId);
                if (receive == null)
                {
                    throw new Exception("入庫IDが見つかりません。");
                }
                // 在庫テーブルで商品IDが存在するか検索
                var existingStock = context.TStocks.FirstOrDefault(s => s.PrId == receive.PrId);
                if (existingStock == null)
                {
                    // 存在しない場合、新しい在庫行を追加
                    var newStock = new TStock
                    {

                        PrId = receive.PrId,
                        StQuantity = receive.WaQuantity,
                    };
                    try
                    {
                        context.TStocks.Add(newStock);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("TStockへの登録に失敗しました: " + ex.Message);
                    }
                }
                else
                {
                    // 存在する場合、数量を更新
                    existingStock.StQuantity += receive.WaQuantity;
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("在庫の数量更新に失敗しました: " + ex.Message);
                    }
                }
            }

        }

        // パネル内のすべてのコントロールにEnterイベントを追加
        private void AddControlEventHandlers(Control panel, int panelId)
        {
            foreach (Control control in panel.Controls)
            {
                // コントロールにEnterイベントを追加
                control.Enter += (sender, e) => Control_Enter(sender, e, panelId);
            }
        }

        // コントロールが選択（フォーカス）された時
        private void Control_Enter(object sender, EventArgs e, int panelId)
        {
            // 異なるパネルに移動したときのみイベントを発生させる
            if (panelId != lastFocusedPanelId)
            {
                ToggleOrderSelection();
                UpdateFlagButtonText();
                lastFocusedPanelId = panelId; // 現在のパネルIDを更新
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
        private void TBNyukoID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBHattyuuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBShainID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }
        //
        private void TBNyuukoSyosaiID_TextChanged(object sender, EventArgs e)
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
            TBNyukoID.BackColor = SystemColors.Window;
            TBHattyuuID.BackColor = SystemColors.Window;
            TBShainID.BackColor = SystemColors.Window;
            TBNyuukoSyosaiID.BackColor = SystemColors.Window;
            TBSyohinID.BackColor = SystemColors.Window;
            TBNyuukoSyosaiID.BackColor = SystemColors.Window;
            TBSuryou.BackColor = SystemColors.Window;
        }
    }
}