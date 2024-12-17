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
using SalesManagement_SysDev.Entity;
using System.Text.RegularExpressions;
using System.Diagnostics.Metrics;

namespace SalesManagement_SysDev
{
    public partial class horder : Form
    {

        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定
        private ClassDataGridViewClearer dgvClearer;


        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private Form mainForm;
        private ClassDateNamelabel dateNameLabel; // 日付と時間ラベル管理用クラス
        private ClassAccessManager accessManager; // アクセスマネージャのインスタンス

        private int lastFocusedPanelID = 1;


        public horder()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(horder_Load);
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

            // パネル1とパネル2のコントロールにイベントを設定
            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel3, 2);  // パネル2の場合
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;

        }



        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        private void b_rec_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToReceivingstockForm();
        }

        private void horder_Load(object sender, EventArgs e)
        {
            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
            UpdateTextBoxState(checkBoxSyain.Checked);

            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベル更新

            // アクセスマネージャを使ってボタンのアクセス制御を適用
            Control[] buttons = { b_rec, /* 他のボタンを追加 */ };
            accessManager.SetButtonAccess(buttons); // ボタンのアクセス設定を適用
            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayHattyus();
            DisplayHattyuDetails();
            SetupNumericOnlyTextBoxes();
            CurrentStatus.UpDateStatus(label2);
            UpdateStatus();
            b_reg.Enabled = false;
            b_reg.BackColor = Color.Gray;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBHattyuuID.Text = "";
            TBMakerID.Text = "";
            HattyuFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBHattyuuSyosaiID.Text = "";
            TBHattyuIDS.Text = "";
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
            if (checkBoxSyain.Checked == false)
            {
                TBShainID.Text = "";
            }
            ResetYellowBackgrounds(this);
        }


        private void b_ser_Click(object sender, EventArgs e)
        {
            PerformSearch();
            tbtrue();
            HattyuFlag.Enabled = true;
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
            HattyuFlag.Enabled = true;
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
            HattyuFlag.Enabled = false;
        }

        private void RegisterStatus()
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            DisplayHattyus();
            DisplayHattyuDetails();

            ListStatus();
            tbtrue();
            HattyuFlag.Enabled = true;
        }
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

        private void tbfalse()
        {
            TBHattyuuID.Enabled = false;
            TBHattyuuSyosaiID.Enabled = false;
            TBHattyuuID.BackColor = Color.Gray;
            TBHattyuuSyosaiID.BackColor = Color.Gray;
            TBHattyuuID.Text = "";
            TBHattyuuSyosaiID.Text = "";
        }
        private void tbtrue()
        {
            TBHattyuuID.Enabled = true;
            TBHattyuuSyosaiID.Enabled = true;
            TBHattyuuID.BackColor = Color.White;
            TBHattyuuSyosaiID.BackColor = Color.White;
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
                        HandleHattyuDetailOperation();
                        break;
                    default:
                        MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleOrderOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateHattyu();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterHattyu();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayHattyus();
                    break;
                case CurrentStatus.Status.検索:
                    SearchHattyus();
                    break;
                default:
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void HandleHattyuDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateHattyuDetails();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterHattyuDetails();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayHattyuDetails();
                    break;
                case CurrentStatus.Status.検索:
                    SearchHattyuDetails();
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

        private void NotFound(string itemName, string itemId)
        {
            MessageBox.Show($":204\n該当の{itemName}が見つかりません。（{itemName}ID: {itemId}）",
                            "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateHattyu()
        {
            string hattyuuID = TBHattyuuID.Text;
            string makerID = TBMakerID.Text;
            string shainID = TBShainID.Text;
            DateTime hattyuuDate = date.Value;
            bool hattyuFlag = HattyuFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            // 必須項目のチェック
            if (CheckTBValue(TBHattyuuID, hattyuuID, "発注ID")) return;
            if (CheckTBValue(TBMakerID, makerID, "メーカーID")) return;
            if (CheckTBValue(TBShainID, shainID, "社員ID"))     return;

            // 売上日が未来の場合の確認
            if (hattyuuDate > DateTime.Now)
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
                // 発注IDの確認
                int hor;
                if (!int.TryParse(hattyuuID, out hor) || !context.THattyus.Any(m => m.HaID == hor))
                {
                    MessageBox.Show(":204\n発注IDが存在しません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBHattyuuID.BackColor = Color.Yellow;
                    return;
                }

                // メーカーIDの確認
                int maker;
                if (!int.TryParse(makerID, out maker) || !context.MMakers.Any(m => m.MaID == maker))
                {
                    NotFound("メーカーID", makerID);
                    return;
                }

                // 社員IDの確認
                int employeeID;
                if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    NotFound("社員ID", shainID);
                    return;
                }

                var hattyu = context.THattyus.FirstOrDefault(h => h.HaID.ToString() == hattyuuID);
                if (hattyu != null)
                {
                    // 更新処理
                    hattyu.MaID = int.Parse(makerID);
                    hattyu.EmID = int.Parse(shainID);
                    hattyu.HaDate = hattyuuDate;
                    hattyu.WaWarehouseFlag = hattyuFlag ? 2 : 0; // 入庫フラグ
                    hattyu.HaFlag = delFlag ? 1 : 0;              // 削除フラグ
                    hattyu.HaHidden = riyuu;

                    // 入庫フラグがチェックされている場合、発注詳細の確認
                    if (hattyuFlag)
                    {
                        // 発注詳細が存在するか確認
                        var hattyuDetailsExist = context.THattyuDetails
                            .Any(hd => hd.HaID == hattyu.HaID);

                        if (!hattyuDetailsExist)
                        {
                            MessageBox.Show(":104\n発注詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断
                        }

                        // 発注詳細が存在する場合、発注確認処理を実行
                        hattyu.HaFlag = 1;
                        hattyu.HaHidden = "発注確定処理済";

                        bool isDuplicate = context.TWarehousings.Any(c => c.HaID == hattyu.HaID);
                        if (isDuplicate)
                        {
                            MessageBox.Show(":203\n既存データとの重複が発生しました", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // 更新処理を中止
                        }
                        HorderConfirm(hattyu.HaID);
                    }

                    // 更新を保存
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        DisplayHattyus(); // 更新後に発注情報を再表示
                        DisplayHattyuDetails();
                        ResetYellowBackgrounds(this);
                        Log_Horder(hattyu.HaID);
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show($"エラーの詳細: {ex.InnerException?.Message ?? ex.Message}", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(":500\n不明なエラーが発生しました。\n" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            countFlag();
            FlagCount();
        }


        private void RegisterHattyu()
        {
            string makerID = TBMakerID.Text;
            string shainID = TBShainID.Text;
            DateTime hattyuuDate = date.Value;
            bool nyuukoFlag = HattyuFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            using (var context = new SalesManagementContext())
            {
                if (CheckTBValue(TBMakerID, makerID, "メーカーID")) return;
                if (CheckTBValue(TBShainID, shainID, "社員ID"))     return;

                // メーカーIDが存在するか確認
                int maker;
                if (!int.TryParse(makerID, out maker) || !context.MMakers.Any(m => m.MaID == maker))
                {
                    NotFound("メーカーID", makerID); // メーカーが見つからない場合
                    return;
                }

                // 社員IDが存在するか確認
                int employeeID;
                if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    NotFound("社員ID", shainID); // 社員が見つからない場合
                    return;
                }

                // 日付が未来の日付でないか確認
                if (hattyuuDate > DateTime.Now)
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

                // 新しい発注情報を作成
                var newHattyu = new THattyu
                {
                    MaID = maker,
                    EmID = employeeID,
                    HaDate = hattyuuDate,
                    WaWarehouseFlag = nyuukoFlag ? 2 : 0,
                    HaFlag = delFlag ? 1 : 0,
                    HaHidden = riyuu
                };

                context.THattyus.Add(newHattyu);
                context.SaveChanges();

                Log_Horder(newHattyu.HaID);

                // 登録成功メッセージ
                MessageBox.Show("登録が成功しました。");
                DisplayHattyus(); // 新規登録後の発注情報を再表示
                ResetYellowBackgrounds(this);

                // 入庫フラグがチェックされている場合、発注詳細の確認を行う
                if (nyuukoFlag)
                {
                    // 発注詳細が存在するか確認
                    var hattyuDetailsExist = context.THattyuDetails
                        .Any(hd => hd.HaID == newHattyu.HaID); // HaID が一致する発注詳細が存在するか確認

                    if (!hattyuDetailsExist)
                    {
                        // 発注詳細が存在しない場合はエラーメッセージを表示
                        MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // 処理を中断
                    }

                    // 発注詳細が存在する場合、発注確認処理を実行
                    HorderConfirm(newHattyu.HaID);
                }
            }
        }



        private void DisplayHattyus()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {

                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示
                    var hattyus = checkBox_2.Checked
                        ? context.THattyus.ToList()  // チェックされていれば全ての注文を表示
                        : context.THattyus.Where(o => o.HaFlag != 1 && o.WaWarehouseFlag != 2).ToList();  // チェックされていなければ非表示フラグが "1" のものを除外
                    dataGridView1.DataSource = hattyus.Select(h => new
                    {
                        発注ID = h.HaID,
                        メーカID = h.MaID,
                        社員ID = h.EmID,
                        発注年月日 = h.HaDate,
                        状態フラグ = h.WaWarehouseFlag,
                        非表示フラグ = h.HaFlag,
                        非表示理由 = h.HaHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchHattyus()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var hattyuuID = TBHattyuuID.Text.Trim();    // 発注ID
                var makerID = TBMakerID.Text.Trim();        // メーカID
                var shainID = TBShainID.Text.Trim();        // 社員ID
                var riyuu = TBRiyuu.Text.Trim();            // 理由

                // 基本的なクエリ
                var query = context.THattyus.AsQueryable();

                // 発注IDを検索条件に追加
                if (!string.IsNullOrEmpty(hattyuuID) && int.TryParse(hattyuuID, out int parsedHattyuuID))
                {
                    query = query.Where(h => h.HaID == parsedHattyuuID);
                }

                // メーカIDを検索条件に追加
                if (!string.IsNullOrEmpty(makerID) && int.TryParse(makerID, out int parsedMakerID))
                {
                    query = query.Where(h => h.MaID == parsedMakerID);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(h => h.EmID == parsedShainID);
                }

                // 理由を検索条件に追加
                if (!string.IsNullOrEmpty(riyuu))
                {
                    query = query.Where(h => h.HaHidden.Contains(riyuu));
                }

                // 発注状態フラグ(HattyuFlag)を検索条件に追加
                if (HattyuFlag.Checked)
                {
                    query = query.Where(h => h.WaWarehouseFlag == 2); // 完了状態
                }
                else
                {
                    query = query.Where(h => h.WaWarehouseFlag == 0); // 未完了状態
                }

                // 削除フラグ(DelFlag)を検索条件に追加
                if (DelFlag.Checked)
                {
                    query = query.Where(h => h.HaFlag == 1); // 削除済み
                }
                else
                {
                    query = query.Where(h => h.HaFlag == 0); // 有効
                }

                // 発注日を検索条件に追加（チェックボックスがチェックされている場合）
                if (checkBoxDateFilter.Checked)
                {
                    DateTime hattyuuDate = date.Value; // DateTimePickerからの値
                    query = query.Where(h => h.HaDate.Date == hattyuuDate.Date);
                }

                // 結果を取得
                var hattyus = query.ToList();

                if (hattyus.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = hattyus.Select(h => new
                    {
                        発注ID = h.HaID,
                        メーカID = h.MaID,
                        社員ID = h.EmID,
                        発注年月日 = h.HaDate,
                        発注状態 = h.WaWarehouseFlag,        // 発注フラグの表示
                        削除フラグ = h.HaFlag,           // 管理フラグ
                        理由 = h.HaHidden               // 非表示理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }

        private void UpdateHattyuDetails()
        {
            string hattyuuSyosaiID = TBHattyuuSyosaiID.Text;
            string hattyuuID = TBHattyuIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            // 各TextBoxの入力値をチェック
            if (CheckTBValue(TBHattyuuSyosaiID, hattyuuSyosaiID, "発注詳細ID")) return;
            if (CheckTBValue(TBHattyuIDS, hattyuuID, "発注ID")) return;
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, suryou, "数量")) return;

            using (var context = new SalesManagementContext())
            {
                // 発注詳細IDが存在するか確認
                int syousai;
                if (!int.TryParse(hattyuuID, out syousai) || !context.THattyuDetails.Any(h => h.HaDetailID == syousai))
                {
                    NotFound("発注詳細ID", hattyuuID); 
                    return;
                }

                // 発注IDが存在するか確認
                int hattyuID;
                if (!int.TryParse(hattyuuID, out hattyuID) || !context.THattyus.Any(h => h.HaID == hattyuID))
                {
                    NotFound("発注ID", hattyuuID); 
                    return;
                }

                // 商品IDがMProductテーブルに存在するか確認
                int productID;
                if (!int.TryParse(syohinID, out productID) || !context.MProducts.Any(p => p.PrID == productID))
                {
                    NotFound("商品ID", syohinID); 
                    return;
                }

                var orderDetail = context.THattyuDetails.SingleOrDefault(od => od.HaDetailID.ToString() == hattyuuSyosaiID);
                if (orderDetail != null)
                {
                    orderDetail.HaID = int.Parse(hattyuuID);
                    orderDetail.PrID = int.Parse(syohinID);
                    orderDetail.HaQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("発注詳細の更新が成功しました。");
                    DisplayHattyuDetails();
                    Log_Horder(orderDetail.HaDetailID);
                    ResetYellowBackgrounds(this);
                }
                else
                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void RegisterHattyuDetails()
        {
            string hattyuuID = TBHattyuIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            // 各TextBoxの入力値をチェック
            if (CheckTBValue(TBHattyuIDS, hattyuuID, "発注ID")) return;
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, suryou, "数量")) return;

            using (var context = new SalesManagementContext())
            {
                // HaID（発注ID）がTHattyuテーブルに存在するか確認
                int hattyuIDInt;
                if (!int.TryParse(hattyuuID, out hattyuIDInt) || !context.THattyus.Any(h => h.HaID == hattyuIDInt))
                {
                    NotFound("発注ID", hattyuuID); 
                    return;
                }

                // PrID（商品ID）がMProductテーブルに存在するか確認
                int productID;
                if (!int.TryParse(syohinID, out productID) || !context.MProducts.Any(p => p.PrID == productID))
                {
                    NotFound("商品ID", syohinID); 
                    return;
                }

                // 数量のパースと検証
                int quantity;
                if (!int.TryParse(suryou, out quantity) || quantity <= 0)
                {
                    MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 発注詳細の重複確認
                var existingOrderDetail = context.THattyuDetails.FirstOrDefault(o => o.HaID == hattyuIDInt);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 処理を終了
                }

                // 新規発注詳細の登録
                var newOrderDetail = new THattyuDetail
                {
                    HaID = hattyuIDInt,
                    PrID = productID,
                    HaQuantity = quantity
                };

                context.THattyuDetails.Add(newOrderDetail);
                context.SaveChanges();

                DisplayHattyuDetails();
                Log_Horder(newOrderDetail.HaDetailID);
                ResetYellowBackgrounds(this);

                // 登録完了後の確認メッセージ
                DialogResult result = MessageBox.Show("発注詳細の登録が完了しました。\n発注処理を確定させますか？",
                                                     "登録完了", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Yes/Noでの分岐処理
                if (result == DialogResult.Yes)
                {
                    // Yesが選ばれた場合の処理（受注処理確定）
                    UpdateHattyuAccept(hattyuIDInt.ToString());
                }
                else
                {
                    // Noが選ばれた場合の処理（受注処理を中止）
                    MessageBox.Show("発注処理は中止されました。", "中止", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void DisplayHattyuDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var HattyuDetails = context.THattyuDetails.ToList();

                    var visibleHattyuDetails = checkBox_2.Checked
                        ? HattyuDetails
                        : HattyuDetails.Where(od =>
                        {
                            var Hattyu = context.THattyus.FirstOrDefault(o => o.HaID == od.HaID);

                            return Hattyu == null || (Hattyu.HaFlag != 1 && Hattyu.WaWarehouseFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleHattyuDetails.Select(od => new
                    {
                        発注詳細ID = od.HaDetailID,
                        発注ID = od.HaID,
                        商品ID = od.PrID,
                        数量 = od.HaQuantity
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchHattyuDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var hattyuuSyosaiID = TBHattyuuSyosaiID.Text;
                var hattyuuID = TBHattyuIDS.Text;
                var syohinID = TBSyohinID.Text;
                var suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.THattyuDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(hattyuuSyosaiID))
                {
                    // 発注詳細IDを検索条件に追加
                    query = query.Where(od => od.HaDetailID.ToString() == hattyuuSyosaiID);
                }

                if (!string.IsNullOrEmpty(hattyuuID))
                {
                    // 発注IDを検索条件に追加
                    query = query.Where(od => od.HaID.ToString() == hattyuuID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrID.ToString() == syohinID);
                }

                if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                {
                    // 数量を検索条件に追加
                    query = query.Where(od => od.HaQuantity == quantity);
                }

                // 結果を取得
                var orderDetails = query.ToList();

                if (orderDetails.Any())
                {
                    dataGridView2.DataSource = orderDetails.Select(od => new
                    {
                        発注詳細ID = od.HaDetailID,
                        発注ID = od.HaID,
                        商品ID = od.PrID,
                        数量 = od.HaQuantity
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToggleHattyuSelection()
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
            ToggleHattyuSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();

            if (orderFlag == "←通常")
                lastFocusedPanelID = 1;
            else if (orderFlag == "詳細→")
                lastFocusedPanelID = 2;
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
                        TBHattyuuID.Text = "";
                    }
                    else
                    {
                        TBHattyuuID.Text = row.Cells["発注ID"].Value.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力 
                    TBMakerID.Text = row.Cells["メーカID"].Value.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value.ToString() ?? string.Empty;

                    date.Value = Convert.ToDateTime(row.Cells["発注年月日"].Value);
                    // 入庫状態や非表示フラグも必要に応じて設定 
                    // 例: NyuukoFlag.Checked = (row.Cells["入庫状態"].Value.ToString() == "1"); 
                    // 例: DelFlag.Checked = (row.Cells["非表示フラグ"].Value.ToString() == "1"); 
                    // 例: TBRiyuu.Text = row.Cells["非表示理由"].Value.ToString(); 
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
                        TBHattyuuSyosaiID.Text = "";
                    }
                    else
                    {
                        TBHattyuuSyosaiID.Text = row.Cells["発注詳細ID"].Value.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力 
                    TBHattyuIDS.Text = row.Cells["発注ID"].Value.ToString() ?? string.Empty;
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString() ?? string.Empty;
                    TBSuryou.Text = row.Cells["数量"].Value.ToString() ?? string.Empty;
                    // 合計金額も設定 
                    // 例: TBGoukeiKingaku.Text = row.Cells["合計金額"].Value.ToString(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HorderConfirm(int HaID)
        {
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言 
                var horder = context.THattyus.SingleOrDefault(o => o.HaID == HaID);

                if (horder == null)
                {
                    throw new Exception("入荷IDが見つかりません。");
                }

                // 情報追加
                var newWarehousing = new TWarehousing
                {
                    HaID = HaID,
                    WaDate = horder.HaDate,
                    EmID = horder.EmID,
                    WaShelfFlag = 0,
                    WaFlag = 0
                };

                try
                {
                    context.TWarehousings.Add(newWarehousing);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("THattyuへの登録に失敗しました: " + ex.Message + "\n" + ex.InnerException?.Message);
                    throw;
                }


                var hattyuDetail = context.THattyuDetails.SingleOrDefault(o => o.HaID == HaID);
                var newWarehousingDetail = new TWarehousingDetail
                {
                    WaID = newWarehousing.WaID,
                    PrID = hattyuDetail.PrID,
                    WaQuantity = hattyuDetail.HaQuantity

                };

                try
                {
                    context.TWarehousingDetails.Add(newWarehousingDetail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("TShipmentDetailへの登録に失敗しました:" + ex.Message);
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
                ToggleHattyuSelection();
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
        private void TBHattyuuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBMakerID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 4);
        }

        private void TBShainID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBHattyuuSyosaiID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBHattyuIDS_TextChanged(object sender, EventArgs e)
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
                    TBHattyuuID.BackColor = SystemColors.Window;
                    TBMakerID.BackColor = SystemColors.Window;
                    TBShainID.BackColor = SystemColors.Window;
                    TBHattyuuSyosaiID.BackColor = SystemColors.Window;
                    TBHattyuIDS.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBSuryou.BackColor = SystemColors.Window;
                    break;
            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBHattyuuID.KeyPress += NumericTextBox_KeyPress;
            TBMakerID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBHattyuIDS.KeyPress += NumericTextBox_KeyPress;
            TBHattyuuSyosaiID.KeyPress += NumericTextBox_KeyPress;
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
                int count = context.THattyus.Count(order => order.WaWarehouseFlag == 0 || order.WaWarehouseFlag == null);
                if (count == 0)
                {
                    GlobalBadge badge = new GlobalBadge("");
                    b_hor.Refresh();
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
        private void Log_Horder(int id)
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
                            Display = "発注",
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
                        MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void UpdateHattyuAccept(string hattyuID)
        {
            // 状態を切り替える処理 
            ToggleHattyuSelection();

            // b_FormSelectorのテキストを現在の状態に更新 
            UpdateFlagButtonText();

            label2.Text = "更新";
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var hattyu = context.THattyus.SingleOrDefault(o => o.HaID.ToString() == hattyuID);
                    if (!int.TryParse(hattyuID, out int hattyus) || !context.THattyus.Any(s => s.HaID == hattyus))
                    {
                        MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TBHattyuuID.BackColor = Color.Yellow;
                        TBHattyuuID.Focus();
                        return;
                    }

                    if (hattyu != null)
                    {
                        hattyu.WaWarehouseFlag = 2;

                        // checkBox_2がチェックされている場合にOrFlagを1に設定
                        if (hattyu.WaWarehouseFlag == 2)
                        {
                            hattyu.HaFlag = 1;
                            hattyu.HaHidden = "発注確定処理済";
                        }

                        try
                        {
                            context.SaveChanges();

                            if (hattyu.WaWarehouseFlag == 2)
                            {
                                // AcceptionConfirm実行
                                HorderConfirm(int.Parse(hattyuID));
                            }
                            Log_Horder(hattyu.HaID);
                            MessageBox.Show("更新が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisplayHattyus();
                            DisplayHattyuDetails();
                        }
                        catch (Exception ex)
                        {
                            context.SaveChanges(); // 元の状態に戻す変更を保存

                            MessageBox.Show($":202\n更新操作が失敗しました。\n "+ex.Message,"DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            countFlag();
            FlagCount();
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
