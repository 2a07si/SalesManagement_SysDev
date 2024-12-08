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
using SalesManagement_SysDev;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using SalesManagement_SysDev.Entity;
using System.Text.RegularExpressions;

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

        private int lastFocusedPanelID = 1;

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
            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
            UpdateTextBoxState(checkBoxSyain.Checked);

            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_hor
            });

            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayReceivingStocks();
            DisplayReceivingStockDetails();
            SetupNumericOnlyTextBoxes();
            CurrentStatus.UpDateStatus(label2);
            b_reg.Enabled = false;
            b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定

        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBNyukoID.Text = "";
            TBHattyuuID.Text = "";
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
            tbtrue();
            checkBoxDateFilter.Checked = false;
            checkBox_2.Checked = false;
            colorReset();
            UpdateTextBoxState(checkBoxSyain.Checked);
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            PerformSearch();
            tbtrue();
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
            tbtrue();
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

        private void tbfalse()
        {
            TBNyukoID.Enabled = false;
            TBNyuukoSyosaiID.Enabled = false;
            TBNyukoID.BackColor = Color.Gray;
            TBNyuukoSyosaiID.BackColor = Color.Gray;
            TBNyukoID.Text = "";
            TBNyuukoSyosaiID.Text = "";
        }
        private void tbtrue()
        {
            TBNyukoID.Enabled = true;
            TBNyuukoSyosaiID.Enabled = true;
            TBNyukoID.BackColor = Color.White;
            TBNyuukoSyosaiID.BackColor = Color.White;
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

            if (TBHattyuuID.Text == "")
            {
                TBHattyuuID.BackColor = Color.Yellow;
                TBHattyuuID.Focus();
                MessageBox.Show("発注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBNyukoID.Text == "")
            {
                TBNyukoID.BackColor = Color.Yellow;
                TBNyukoID.Focus();
                MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShainID.Text == "")
            {
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (date.Value > DateTime.Now)
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
            using (var context = new SalesManagementContext())
            {
                int nyuuko;
                if (!int.TryParse(nyuukoID, out nyuuko) || !context.TWarehousings.Any(h => h.WaID == nyuuko))
                {
                    MessageBox.Show("入庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int hattyuID;
                if (!int.TryParse(haID, out hattyuID) || !context.THattyus.Any(h => h.HaID == hattyuID))
                {
                    MessageBox.Show("発注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIDがMEmployeeテーブルに存在するか確認
                int employeeID;
                if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var receivingStock = context.TWarehousings.SingleOrDefault(ws => ws.WaID.ToString() == nyuukoID);
                if (receivingStock != null)
                {
                    receivingStock.HaID = int.Parse(haID);                 // 発注ID 
                    receivingStock.EmID = int.Parse(shainID);              // 社員ID 
                    receivingStock.WaDate = nyuukoDate;                    // 入庫日 
                    receivingStock.WaShelfFlag = nyuukoFlag ? 2 : 0;       // 入庫棚フラグ 
                    receivingStock.WaFlag = delFlag ? 1 : 0;               // 削除フラグ 
                    receivingStock.WaHidden = riyuu;                       // 理由 

                    // NyuukoFlagがチェックされている場合、入庫詳細の確認を行う 
                    if (nyuukoFlag)
                    {
                        // 入庫詳細が存在するか確認 
                        var receivingDetailsExist = context.TWarehousingDetails
                            .Any(wd => wd.WaID == receivingStock.WaID); // WaID が一致する入庫詳細が存在するか確認 

                        if (!receivingDetailsExist)
                        {
                            // 入庫詳細が存在しない場合はエラーメッセージを表示 
                            MessageBox.Show("入庫詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断 
                        }

                        MessageBox.Show("入庫確定処理");
                        // 入庫詳細が存在する場合、入庫確認処理を実行 
                        ReceiveConfirm(receivingStock.WaID);

                        // 在庫更新メッセージを保存
                        var receivingDetails = context.TWarehousingDetails
                            .Where(wd => wd.WaID == receivingStock.WaID);

                        foreach (var detail in receivingDetails)
                        {
                            Global.AddStockUpdateMessage(detail.PrID, detail.WaQuantity); // メッセージ追加
                        }
                        receivingStock.WaFlag = 1;
                        receivingStock.WaHidden = "入庫確定処理済";

                    }

                    // 更新を保存 
                    // 更新を保存 
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        DisplayReceivingStocks(); // 更新後に入庫情報を再表示
                        DisplayReceivingStockDetails();
                        Log_Receive(receivingStock.WaID);
                        ResetYellowBackgrounds(this);


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
            countFlag();
            FlagCount();
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
                int hattyuID;
                if (TBNyukoID.Text == "")
                {
                    TBNyukoID.Focus();
                    MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBShainID.Text == "")
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(haID, out hattyuID) || !context.THattyus.Any(h => h.HaID == hattyuID))
                {
                    MessageBox.Show("発注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIDがMEmployeeテーブルに存在するか確認
                int employeeID;
                if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (date.Value > DateTime.Now)
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
                var newReceivingStock = new TWarehousing
                {
                    HaID = hattyuID, // 発注IDを適切に設定
                    EmID = employeeID, // 社員IDを適切に設定
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
                    DisplayReceivingStockDetails();
                    Log_Receive(newReceivingStock.WaID);
                    ResetYellowBackgrounds(this);
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
                        入庫ID = ws.WaID,
                        発注ID = ws.HaID,
                        社員ID = ws.EmID,
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
                // 各テキストボックスの値を取得
                var nyuukoID = TBNyukoID.Text.Trim();    // 入庫ID
                var haID = TBHattyuuID.Text.Trim();     // 発注ID
                var shainID = TBShainID.Text.Trim();    // 社員ID
                var riyuu = TBRiyuu.Text.Trim();        // 理由

                // 基本的なクエリ
                var query = context.TWarehousings.AsQueryable();

                // 入庫IDを検索条件に追加
                if (!string.IsNullOrEmpty(nyuukoID) && int.TryParse(nyuukoID, out int parsedNyuukoID))
                {
                    query = query.Where(ws => ws.WaID == parsedNyuukoID);
                }

                // 発注IDを検索条件に追加
                if (!string.IsNullOrEmpty(haID) && int.TryParse(haID, out int parsedHaID))
                {
                    query = query.Where(ws => ws.HaID == parsedHaID);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(ws => ws.EmID == parsedShainID);
                }

                // 理由を検索条件に追加
                if (!string.IsNullOrEmpty(riyuu))
                {
                    query = query.Where(ws => ws.WaHidden.Contains(riyuu));
                }

                // 入庫済フラグ(NyuukoFlag)を検索条件に追加
                if (NyuukoFlag.Checked)
                {
                    query = query.Where(ws => ws.WaFlag == 1); // 入庫済み
                }
                else
                {
                    query = query.Where(ws => ws.WaFlag == 0); // 未入庫
                }

                // 削除フラグ(DelFlag)を検索条件に追加
                if (DelFlag.Checked)
                {
                    query = query.Where(ws => ws.WaShelfFlag == 1); // 削除済み
                }
                else
                {
                    query = query.Where(ws => ws.WaShelfFlag == 0); // 有効
                }

                // 結果を取得
                var receivingStocks = query.ToList();

                if (receivingStocks.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = receivingStocks.Select(ws => new
                    {
                        入庫ID = ws.WaID,
                        発注ID = ws.HaID,
                        社員ID = ws.EmID,
                        入庫年月日 = ws.WaDate,
                        入庫済フラグ = ws.WaFlag,
                        削除フラグ = ws.WaShelfFlag,
                        理由 = ws.WaHidden
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する入庫情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }

        private void UpdateReceivingStockDetails()
        {
            string nyuukoDetailID = TBNyuukoSyosaiID.Text;
            string nyuukoID = TBNyuukoIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            if (TBNyuukoSyosaiID.Text == "")
            {
                TBNyuukoSyosaiID.BackColor = Color.Yellow;
                TBNyuukoSyosaiID.Focus();
                MessageBox.Show("入庫詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBNyuukoIDS.Text == "")
            {
                TBNyuukoIDS.BackColor = Color.Yellow;
                TBNyuukoIDS.Focus();
                MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (TBSyohinID.Text == "")
            {
                TBSyohinID.BackColor = Color.Yellow;
                TBSyohinID.Focus();
                MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSuryou.Text == "")
            {
                TBSuryou.BackColor = Color.Yellow;
                TBSuryou.Focus();
                MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (var context = new SalesManagementContext())
            {
                int syousai;
                if (!int.TryParse(nyuukoID, out syousai) || !context.TWarehousingDetails.Any(w => w.WaDetailID == syousai))
                {
                    MessageBox.Show("入庫詳細IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int warehousingID;
                if (!int.TryParse(nyuukoID, out warehousingID) || !context.TWarehousings.Any(w => w.WaID == warehousingID))
                {
                    MessageBox.Show("入庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // PrIDがTProductテーブルに存在するか確認
                int productID;
                if (!int.TryParse(syohinID, out productID) || !context.MProducts.Any(p => p.PrID == productID))
                {
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var receivingStockDetail = context.TWarehousingDetails.SingleOrDefault(ws => ws.WaDetailID.ToString() == nyuukoDetailID);
                if (receivingStockDetail != null)
                {
                    receivingStockDetail.WaID = int.Parse(nyuukoID);
                    receivingStockDetail.PrID = int.Parse(syohinID);
                    receivingStockDetail.WaQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("入庫詳細の更新が成功しました。");
                    DisplayReceivingStockDetails();
                    Log_Receive(receivingStockDetail.WaDetailID);
                    ResetYellowBackgrounds(this);
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
                int warehousingID;
                if (TBNyuukoIDS.Text == "")
                {
                    TBNyuukoIDS.BackColor = Color.Yellow;
                    TBNyuukoIDS.Focus();
                    MessageBox.Show("入庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (TBSyohinID.Text == "")
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBSuryou.Text == "")
                {
                    TBSuryou.BackColor = Color.Yellow;
                    TBSuryou.Focus();
                    MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(nyuukoID, out warehousingID) || !context.TWarehousings.Any(w => w.WaID == warehousingID))
                {
                    MessageBox.Show("入庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // PrIDがTProductテーブルに存在するか確認
                int productID;
                if (!int.TryParse(syohinID, out productID) || !context.MProducts.Any(p => p.PrID == productID))
                {
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int quantity;
                if (!int.TryParse(suryou, out quantity) || quantity <= 0)
                {
                    TBSuryou.BackColor = Color.Yellow;
                    TBSuryou.Focus();
                    MessageBox.Show("数量が無効です。正の整数を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingOrderDetail = context.TWarehousingDetails.FirstOrDefault(o => o.WaID == warehousingID);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show("この入庫IDにはすでに入庫詳細が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 処理を終了
                }
                var newReceivingStockDetail = new TWarehousingDetail
                {
                    WaID = warehousingID, // 入庫IDを適切に設定
                    PrID = productID, // 商品IDを適切に設定
                    WaQuantity = quantity // 数量を適切に設定
                };

                context.TWarehousingDetails.Add(newReceivingStockDetail);

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("入庫詳細の登録が成功しました。");
                    DisplayReceivingStockDetails();
                    Log_Receive(newReceivingStockDetail.WaDetailID);
                    ResetYellowBackgrounds(this);
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
                            var Warehousing = context.TWarehousings.FirstOrDefault(o => o.WaID == od.WaID);

                            return Warehousing == null || (Warehousing.WaFlag != 1 && Warehousing.WaShelfFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleWarehousingDetails.Select(ws => new
                    {
                        入庫詳細ID = ws.WaDetailID,
                        入庫ID = ws.WaID,
                        商品ID = ws.PrID,
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
                    query = query.Where(ws => ws.WaDetailID == parsedNyuukoDetailID);
                }

                if (!string.IsNullOrEmpty(nyuukoID) && int.TryParse(nyuukoID, out int parsedNyuukoID))
                {
                    query = query.Where(ws => ws.WaID == parsedNyuukoID);
                }

                if (!string.IsNullOrEmpty(syohinID) && int.TryParse(syohinID, out int parsedSyohinID))
                {
                    query = query.Where(ws => ws.PrID == parsedSyohinID);
                }

                var receivingStockDetails = query.ToList();

                if (receivingStockDetails.Any())
                {
                    dataGridView2.DataSource = receivingStockDetails.Select(ws => new
                    {
                        入庫詳細ID = ws.WaDetailID,
                        入庫ID = ws.WaID,
                        商品ID = ws.PrID,
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
                        TBNyukoID.Text = "";
                    }
                    else
                    {
                        TBNyukoID.Text = row.Cells["入庫ID"].Value.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力  
                    TBHattyuuID.Text = row.Cells["発注ID"].Value.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString() ?? string.Empty;
                    date.Value = Convert.ToDateTime(row.Cells["入庫年月日"].Value);
                    NyuukoFlag.Checked = Convert.ToBoolean(row.Cells["入庫済フラグ"].Value);
                    DelFlag.Checked = Convert.ToBoolean(row.Cells["非表示フラグ"].Value);
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
                        TBNyuukoSyosaiID.Text = "";
                    }
                    else
                    {
                        TBNyuukoSyosaiID.Text = row.Cells["入庫詳細ID"].Value.ToString();
                    }
                    // 各テキストボックスにデータを入力  
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


        private void ReceiveConfirm(int WaID)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                // 入庫情報を取得
                var receive = context.TWarehousingDetails.SingleOrDefault(o => o.WaID == WaID);
                if (receive == null)
                {
                    throw new Exception("入庫IDが見つかりません。");
                }
                // 在庫テーブルで商品IDが存在するか検索
                var existingStock = context.TStocks.FirstOrDefault(s => s.PrID == receive.PrID);
                if (existingStock == null)
                {
                    // 存在しない場合、新しい在庫行を追加
                    var newStock = new TStock
                    {

                        PrID = receive.PrID,
                        StQuantity = receive.WaQuantity,
                    };
                    try
                    {
                        context.TStocks.Add(newStock);
                        context.SaveChanges();
                        UpdateNyuukoCheckerFlag(receive.PrID, receive.WaQuantity);
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
                        UpdateNyuukoCheckerFlag(receive.PrID, receive.WaQuantity);
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
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    tbfalse();
                    break;
                default:
                    TBNyukoID.BackColor = SystemColors.Window;
                    TBHattyuuID.BackColor = SystemColors.Window;
                    TBShainID.BackColor = SystemColors.Window;
                    TBNyuukoSyosaiID.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBNyuukoSyosaiID.BackColor = SystemColors.Window;
                    TBSuryou.BackColor = SystemColors.Window;
                    break;
            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBNyukoID.KeyPress += NumericTextBox_KeyPress;
            TBHattyuuID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBNyuukoIDS.KeyPress += NumericTextBox_KeyPress;
            TBNyuukoSyosaiID.KeyPress += NumericTextBox_KeyPress;
            TBSuryou.KeyPress += NumericTextBox_KeyPress;
            TBSyohinID.KeyPress += NumericTextBox_KeyPress;

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

        private void b_hor_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.THattyus.Count(order => order.WaWarehouseFlag == 0 || order.WaWarehouseFlag == null);
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

        private void b_rec_Paint(object sender, PaintEventArgs e)
        {

            using (var context = new SalesManagementContext())
            {
                int count = context.TWarehousings.Count(order => order.WaShelfFlag == 0 || order.WaShelfFlag == null);
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
                int count = context.TWarehousings.Count(order => order.WaShelfFlag == 0 || order.WaShelfFlag == null);
                if (count == 0)
                {
                    GlobalBadge badge = new GlobalBadge("");
                    b_rec.Refresh();
                }
            }
        }

        private void FlagCount()
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TWarehousings.Count(order => order.WaShelfFlag == 0 || order.WaShelfFlag == null);
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" ");
                    b_rec.Refresh();
                }
            }
        }
        private void Log_Receive(int id)
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
                            Display = "入庫",
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
        private void UpdateNyuukoCheckerFlag(int PrID, int Quantity)
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 商品IDと数量でレコードを絞り込み
                    var itemsToUpdate = context.NyuukoCheckers
                        .Where(n => n.PrID == PrID.ToString() && n.Quantity <= Quantity && n.Flag == false)
                        .ToList();

                    if (itemsToUpdate.Any())
                    {
                        // デバッグ用メッセージを準備
                        var debugMessage = "更新されたレコード:\n";

                        // 条件に一致するレコードのフラグを更新
                        itemsToUpdate.ForEach(item =>
                        {
                            item.Flag = true;

                            // デバッグ用にレコード内容を収集
                            debugMessage += $"ID: {item.ID},SyukkoID: {item.SyukkoID}, JyutyuID: {item.JyutyuID}, PrID: {item.PrID},  Quantity: {item.Quantity}, Flag: {item.Flag}\n";
                        });

                        // 変更をデータベースに保存
                        context.SaveChanges();

                        // 更新内容を表示
                        MessageBox.Show(debugMessage, "デバッグ情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("該当する商品IDと数量に一致するレコードが見つかりませんでした。");
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーハンドリング
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TBShainID.Text = Global.EmployeeID.ToString();  // テキストを設定
                TBShainID.Enabled = false; // 無効化
            }
            else
            {
                TBShainID.Enabled = true; // 有効化
            }

            // フラグをオフに戻す
            isProgrammaticChange = false;
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