using System;
using System.Linq;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ; // 各種クラスを使用する
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using SalesManagement_SysDev.juchuu_uriage;
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using Microsoft.EntityFrameworkCore;
using SalesManagement_SysDev.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesManagement_SysDev
{
    public partial class issue : Form
    {
        string empID = GlobalEmp.EmployeeID;
        private bool isIssueSelected = true; // 初期状態を出庫(TSyukko)に設定
        private string issueFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス
        private DateTime timestamp = DateTime.Now;
        private int lastFocusedPanelID = 1;
        public issue()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //this. += new EventHandler(issue_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット


            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);


            // パネル1とパネル2のコントロールにイベントを設定
            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel3, 2);  // パネル2の場合
            StockCheck();
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;

        }

        private void issue_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_acc,
                b_shi,
                b_sal,
                b_iss,
                b_arr
            });

            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayIssues();
            DisplayIssueDetails();
            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
            UpdateTextBoxState(checkBoxSyain.Checked);
            b_reg.Enabled = false;
            b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定

            SetupNumericOnlyTextBoxes();

            // 在庫不足で非表示となった出庫情報に関するメッセージを取得

            // 在庫更新メッセージを取得
            string stockUpdateMessages2 = Global.GetStockUpdateMessages();

            // メッセージが存在する場合、MessageBoxで表示
            if (!string.IsNullOrEmpty(stockUpdateMessages2))
            {
                MessageBox.Show(stockUpdateMessages2, "在庫更新通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("特に在庫更新はありません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CurrentStatus.UpDateStatus(label2);
            StockCheck();
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
        private void b_arr_Click(object sender, EventArgs e) => formChanger.NavigateToArrivalForm();
        private void clear_Click(object sender, EventArgs e) => ClearText();

        private void ClearText()
        {
            TBSyukkoID.Text = "";
            TBShopID.Text = "";
            TBKokyakuID.Text = "";
            TBJyutyuID.Text = "";
            SyukkoFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBSyukkoSyosaiID.Text = "";
            TBSyukkoIDS.Text = "";
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
            DisplayIssues();
            DisplayIssueDetails();
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }

        private void tbfalse()
        {
            TBSyukkoID.Enabled = false;
            TBSyukkoSyosaiID.Enabled = false;
            TBSyukkoID.BackColor = Color.Gray;
            TBSyukkoSyosaiID.BackColor = Color.Gray;
            TBSyukkoID.Text = "";
            TBSyukkoSyosaiID.Text = "";
        }
        private void tbtrue()
        {
            TBSyukkoID.Enabled = true;
            TBSyukkoSyosaiID.Enabled = true;
            TBSyukkoID.BackColor = Color.White;
            TBSyukkoSyosaiID.BackColor = Color.White;
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
                        HandleIssueOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        colorReset();
                        HandleIssueDetailOperation();
                        break;
                    default:
                        MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HandleIssueOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateIssue();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterIssue();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayIssues();
                    StockCheck();
                    break;
                case CurrentStatus.Status.検索:
                    SearchIssues();
                    break;
                default:
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void HandleIssueDetailOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateIssueDetails();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterIssueDetails();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayIssueDetails();
                    break;
                case CurrentStatus.Status.検索:
                    SearchIssueDetails();
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

        private void UpdateIssue()
        {
            string SyukkoID = TBSyukkoID.Text;
            string ShopID = TBShopID.Text;
            string ShainID = TBShainID.Text;
            string KokyakuID = TBKokyakuID.Text;
            string JyutyuID = TBJyutyuID.Text;
            bool SyukkoFlg = SyukkoFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Syukkodate = date.Value;

            // 入力必須項目の確認
            if (CheckTBValue(TBSyukkoID, SyukkoID, "出庫ID")) return;
            if (CheckTBValue(TBShopID, ShopID, "営業所ID")) return;
            if (CheckTBValue(TBShainID, ShainID, "社員ID")) return;
            if (CheckTBValue(TBKokyakuID, KokyakuID, "顧客ID")) return;
            if (CheckTBValue(TBJyutyuID, JyutyuID, "受注ID")) return;

            // ログイン時の社員IDチェック
            if (ShainID != empID)
            {
                MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                return;
            }

            // 出庫日の確認
            if (date.Value > DateTime.Now)
            {
                var result = MessageBox.Show(
                    "出庫日が未来を指していますが、よろしいですか？",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.No) return;
            }

            // 業務ロジックチェック
            if (!Kuraberu_kun.Kuraberu_chan("出庫", "通常", "更新", int.Parse(SyukkoID), timestamp))
                return;

            using (var context = new SalesManagementContext())
            {
                // 出庫ID存在確認
                if (!int.TryParse(SyukkoID, out int syukkoID) || !context.TSyukkos.Any(s => s.SyID == syukkoID))
                {
                    NotFound(TBSyukkoID, "出庫ID", SyukkoID);
                    return;
                }

                // 営業所ID存在確認
                if (!int.TryParse(ShopID, out int shopID) || !context.MSalesOffices.Any(s => s.SoID == shopID))
                {
                    NotFound(TBShopID, "営業所ID", ShopID);
                    return;
                }

                // 社員ID存在確認
                if (!int.TryParse(ShainID, out int employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    NotFound(TBShainID, "社員ID", ShainID);
                    return;
                }

                // 顧客ID存在確認
                if (!int.TryParse(KokyakuID, out int kokyakuID) || !context.MClients.Any(k => k.ClID == kokyakuID))
                {
                    NotFound(TBKokyakuID, "顧客ID", KokyakuID);
                    return;
                }

                // 受注ID存在確認
                if (!int.TryParse(JyutyuID, out int juchuID) || !context.TOrders.Any(j => j.OrID == juchuID))
                {
                    NotFound(TBJyutyuID, "受注ID", JyutyuID);
                    return;
                }

                var issue = context.TSyukkos.SingleOrDefault(o => o.SyID == syukkoID);

                if (issue != null)
                {
                    // 出庫情報の更新
                    issue.SoID = shopID;                      // 営業所ID
                    issue.EmID = employeeID;                  // 社員ID
                    issue.ClID = kokyakuID;                   // 顧客ID
                    issue.OrID = juchuID;                     // 受注ID
                    issue.SyDate = Syukkodate;                // 出庫日
                    issue.SyStateFlag = SyukkoFlg ? 2 : 0;    // 出庫状態フラグ
                    issue.SyFlag = DelFlg ? 1 : 0;            // 削除フラグ
                    issue.SyHidden = Riyuu;                   // 理由

                    try
                    {
                        // 出庫確定処理
                        if (SyukkoFlg)
                        {
                            if (context.TArrivals.Any(c => c.OrID == juchuID))
                            {
                                MessageBox.Show($"この受注ID ({juchuID}) は既に登録されています。更新を中止します。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (!context.TSyukkoDetails.Any(sd => sd.SyID == syukkoID))
                            {
                                MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            issue.SyFlag = 1;
                            issue.SyHidden = "出庫確定処理済";
                            IssueConfirm(juchuID, syukkoID);
                        }

                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        Log_Issue(syukkoID);
                        DisplayIssues();
                        DisplayIssueDetails();
                        ResetYellowBackgrounds(this);
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show(ex.InnerException?.Message ?? ":201\n登録操作が失敗しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($":500\n不明なエラーが発生しました。\n{ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NotFound(TBSyukkoID, "出庫ID", SyukkoID);
                }
            }

            countFlag();
            FlagCount();
        }


        private void RegisterIssue()
        {
            string SyukkoID = TBSyukkoID.Text;
            string ShopID = TBShopID.Text;
            string ShainID = TBShainID.Text;
            string KokyakuID = TBKokyakuID.Text;
            string JyutyuID = TBJyutyuID.Text;
            bool SyukkoFlg = SyukkoFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Syukkodate = date.Value;

            using (var context = new SalesManagementContext())
            {
                // Check required fields using CheckTBValue
                if (CheckTBValue(TBShopID, ShopID, "営業所ID")) return;
                if (CheckTBValue(TBShainID, ShainID, "社員ID")) return;
                if (CheckTBValue(TBKokyakuID, KokyakuID, "顧客ID")) return;
                if (CheckTBValue(TBJyutyuID, JyutyuID, "受注ID")) return;

                // Validate IDs against the database
                if (!int.TryParse(ShopID, out int shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
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

                // Validate employee ID matches logged-in user
                if (TBShainID.Text != empID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力してください。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }

                // Validate date
                if (date.Value > DateTime.Now)
                {
                    if (MessageBox.Show("出庫日が未来を指していますが、よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }

                // Check if the issue already exists
                var existingIssue = context.TSyukkos.SingleOrDefault(o => o.OrID.ToString() == SyukkoID);
                if (existingIssue != null)
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Create a new issue
                    var newIssue = new TSyukko
                    {
                        SoID = shop,
                        EmID = employeeID,
                        ClID = kokyaku,
                        OrID = juchu,
                        SyDate = Syukkodate,
                        SyStateFlag = SyukkoFlg ? 2 : 0,
                        SyFlag = DelFlg ? 1 : 0,
                        SyHidden = Riyuu
                    };

                    context.TSyukkos.Add(newIssue);
                    context.SaveChanges();

                    // Confirm shipping details if necessary
                    if (SyukkoFlag.Checked && !context.TSyukkoDetails.Any(sd => sd.SyID == newIssue.SyID))
                    {
                        MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (SyukkoFlag.Checked)
                        IssueConfirm(newIssue.OrID, newIssue.SyID);

                    // Success
                    MessageBox.Show("登録が成功しました。");
                    DisplayIssues();
                    DisplayIssueDetails();
                    Log_Issue(newIssue.SyID);
                    ResetYellowBackgrounds(this);
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.InnerException != null
                        ? $":500\n不明なエラーが発生しました。\n{ex.Message}"
                        : ":201\n登録操作が失敗しました", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($":500\n不明なエラーが発生しました。\n{ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DisplayIssues()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての出庫を表示
                    var issues = checkBox_2.Checked
                        ? (checkBox1.Checked
                            ? context.TSyukkos.OrderByDescending(s => s.SyID).ToList() // 降順
                            : context.TSyukkos.OrderBy(s => s.SyID).ToList())          // 昇順
                        : (checkBox1.Checked
                            ? context.TSyukkos
                                .Where(s => s.SyFlag != 1 && s.SyStateFlag != 2)
                                .OrderByDescending(s => s.SyID) // 条件に合致するものを降順で取得
                                .ToList()
                            : context.TSyukkos
                                .Where(s => s.SyFlag != 1 && s.SyStateFlag != 2)
                                .OrderBy(s => s.SyID)          // 条件に合致するものを昇順で取得
                                .ToList());

                    dataGridView1.DataSource = issues.Select(o => new
                    {
                        出庫ID = o.SyID,            // 出庫ID
                        社員ID = o.EmID,
                        顧客ID = o.ClID,             // クライアントID
                        営業所ID = o.SoID,              // 営業所ID
                        受注ID = o.OrID,              // 受注ID
                        出庫日 = o.SyDate,        // 出庫日
                        状態フラグ = o.SyStateFlag,     // 出庫状態フラグ
                        非表示フラグ = o.SyFlag,         // 削除フラグ
                        備考 = o.SyHidden            // 理由
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchIssues()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                string syukkoID = TBSyukkoID.Text;
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string JyutyuID = TBJyutyuID.Text;
                DateTime? syukkoDate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TSyukkos.AsQueryable();

                // 出庫IDを検索条件に追加
                if (!string.IsNullOrEmpty(syukkoID))
                {
                    int syID = int.Parse(syukkoID);
                    query = query.Where(issue => issue.SyID == syID);
                }

                // 営業所IDを検索条件に追加
                if (!string.IsNullOrEmpty(shopID))
                {
                    int soID = int.Parse(shopID);
                    query = query.Where(issue => issue.SoID == soID);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainID))
                {
                    int emID = int.Parse(shainID);
                    query = query.Where(issue => issue.EmID == emID);
                }

                // 顧客IDを検索条件に追加
                if (!string.IsNullOrEmpty(kokyakuID))
                {
                    int clID = int.Parse(kokyakuID);
                    query = query.Where(issue => issue.ClID == clID);
                }

                // 受注IDを検索条件に追加
                if (!string.IsNullOrEmpty(JyutyuID))
                {
                    int orID = int.Parse(JyutyuID);
                    query = query.Where(issue => issue.OrID == orID);
                }

                // 出庫日を検索条件に追加（チェックボックスがチェックされている場合）
                if (syukkoDate.HasValue)
                {
                    query = query.Where(issue => issue.SyDate == syukkoDate.Value);
                }

                // 出庫フラグ(SyukkoFlag)の検索条件を追加
                if (SyukkoFlag.Checked)
                {
                    query = query.Where(issue => issue.SyStateFlag == 2);
                }
                else
                {
                    query = query.Where(issue => issue.SyStateFlag == 0);
                }

                // 削除フラグ(DelFlag)の検索条件を追加
                if (DelFlag.Checked)
                {
                    query = query.Where(issue => issue.SyFlag == 1);
                }
                else
                {
                    query = query.Where(issue => issue.SyFlag == 0);
                }

                // 結果を取得
                var issues = query.ToList();

                if (issues.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = issues.Select(issue => new
                    {
                        出庫ID = issue.SyID,         // 出庫ID
                        営業所ID = issue.SoID,       // 営業所ID
                        社員ID = issue.EmID,         // 社員ID
                        顧客ID = issue.ClID,         // クライアントID
                        受注ID = issue.OrID,         // 受注ID
                        出庫日 = issue.SyDate,   // 出庫日
                        状態フラグ = issue.SyStateFlag, // 出庫状態フラグ
                        非表示フラグ = issue.SyFlag,    // 削除フラグ
                        備考 = issue.SyHidden     // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }

        private void UpdateIssueDetails()
        {
            string SyukkoSyosaiID = TBSyukkoSyosaiID.Text;
            string SyukkoID = TBSyukkoIDS.Text;
            string SyohinID = TBSyohinID.Text;
            string Suryou = TBSuryou.Text;

            // 入力チェック（共通メソッドを活用）
            if (CheckTBValue(TBSyukkoSyosaiID, SyukkoSyosaiID, "出庫詳細ID")) return;
            if (CheckTBValue(TBSyukkoIDS, SyukkoID, "出庫ID")) return;
            if (CheckTBValue(TBSyohinID, SyohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, Suryou, "数量")) return;

            // 更新可能状態の確認
            if (!Kuraberu_kun.Kuraberu_chan("出庫", "詳細", "更新", int.Parse(SyukkoSyosaiID), timestamp)) return;

            using (var context = new SalesManagementContext())
            {
                // 各データ存在確認（共通メソッドを活用）
                if (!int.TryParse(SyukkoSyosaiID, out int shousai) || !context.TSyukkoDetails.Any(s => s.SyDetailID == shousai))
                {
                    NotFound(TBSyukkoSyosaiID, "出庫詳細", SyukkoSyosaiID);
                    return;
                }

                if (!int.TryParse(SyukkoID, out int shukko) || !context.TSyukkos.Any(s => s.SyID == shukko))
                {
                    NotFound(TBSyukkoIDS, "出庫", SyukkoID);
                    return;
                }

                if (!int.TryParse(SyohinID, out int shouhin) || !context.MProducts.Any(p => p.PrID == shouhin))
                {
                    NotFound(TBSyohinID, "商品", SyohinID);
                    return;
                }

                // データ更新処理
                var issueDetail = context.TSyukkoDetails.SingleOrDefault(od => od.SyDetailID == shousai);
                if (issueDetail != null)
                {
                    issueDetail.SyID = shukko;
                    issueDetail.PrID = shouhin;
                    issueDetail.SyQuantity = int.Parse(Suryou);

                    context.SaveChanges();
                    MessageBox.Show("出庫詳細の更新が成功しました。");
                    DisplayIssueDetails();
                    Log_Issue(issueDetail.SyDetailID);
                    ResetYellowBackgrounds(this);
                }
                else
                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void RegisterIssueDetails()
        {
            string SyukkoID = TBSyukkoIDS.Text;
            string SyohinID = TBSyohinID.Text;
            string Suryou = TBSuryou.Text;

            // 入力チェック（共通メソッドを使用）
            if (CheckTBValue(TBSyukkoIDS, SyukkoID, "出庫ID")) return;
            if (CheckTBValue(TBSyohinID, SyohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, Suryou, "数量")) return;

            using (var context = new SalesManagementContext())
            {
                // データ存在確認（共通メソッドを活用）
                if (!int.TryParse(SyukkoID, out int shukko) || !context.TSyukkos.Any(s => s.SyID == shukko))
                {
                    NotFound(TBSyukkoIDS, "出庫", SyukkoID);
                    return;
                }

                if (!int.TryParse(SyohinID, out int shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    NotFound(TBSyohinID, "商品", SyohinID);
                    return;
                }

                // 重複チェック
                var existingOrderDetail = context.TSyukkoDetails.FirstOrDefault(o => o.SyID == shukko);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 処理を終了
                }

                // 新しい出庫詳細の登録
                var newIssueDetail = new TSyukkoDetail
                {
                    SyID = shukko,
                    PrID = shouhin,
                    SyQuantity = int.Parse(Suryou),
                };

                context.TSyukkoDetails.Add(newIssueDetail);
                context.SaveChanges();
                MessageBox.Show("出庫詳細の登録が成功しました。");
                DisplayIssueDetails();
                Log_Issue(newIssueDetail.SyDetailID);
                ResetYellowBackgrounds(this);
            }
        }


        private void DisplayIssueDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 出庫詳細のリストを取得（checkBox1の状態に応じて並べ替え）
                    var SyukkoDetails = checkBox1.Checked
                        ? context.TSyukkoDetails.OrderByDescending(sd => sd.SyID).ToList() // 降順
                        : context.TSyukkoDetails.OrderBy(sd => sd.SyID).ToList();          // 昇順

                    // checkBox_2がチェックされている場合、フィルタリングを無視してすべての詳細を表示
                    var visibleSyukkoDetails = checkBox_2.Checked
                        ? SyukkoDetails // チェックされていれば全て表示（並び替え済み）
                        : SyukkoDetails.Where(sd =>
                        {
                            var Syukko = context.TSyukkos.FirstOrDefault(s => s.SyID == sd.SyID);

                            return Syukko == null || (Syukko.SyFlag != 1 && Syukko.SyStateFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleSyukkoDetails.Select(od => new
                    {
                        出庫詳細ID = od.SyDetailID,
                        出庫ID = od.SyID,
                        商品ID = od.PrID,
                        数量 = od.SyQuantity.ToString("N0"),
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchIssueDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var SyukkoSyosaiID = TBSyukkoSyosaiID.Text;
                var SyukkoIDS = TBSyukkoIDS.Text;
                var syohinID = TBSyohinID.Text;
                var suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.TSyukkoDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(SyukkoSyosaiID))
                {
                    // 出庫詳細IDを検索条件に追加
                    query = query.Where(od => od.SyDetailID.ToString() == SyukkoSyosaiID);
                }

                if (!string.IsNullOrEmpty(SyukkoIDS))
                {
                    //出庫IDを検索条件に追加
                    query = query.Where(od => od.SyID.ToString() == SyukkoIDS);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrID.ToString() == syohinID);
                }

                if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                {
                    // 数量を検索条件に追加
                    query = query.Where(od => od.SyQuantity == quantity);
                }



                // 結果を取得
                var issueDetails = query.ToList();

                if (issueDetails.Any())
                {
                    dataGridView2.DataSource = issueDetails.Select(od => new
                    {
                        出庫詳細ID = od.SyDetailID,
                        出庫ID = od.SyID,
                        商品ID = od.PrID,
                        数量 = od.SyQuantity,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToggleIssueSelection()
        {
            isIssueSelected = !isIssueSelected;
            issueFlag = isIssueSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isIssueSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);

            if (issueFlag == "←通常")
                lastFocusedPanelID = 1;
            else if (issueFlag == "詳細→")
                lastFocusedPanelID = 2;
        }

        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleIssueSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
        }


        private void UpdateFlagButtonText()
        {
            // b_FlagSelectorのテキストを現在の状態に合わせる
            b_FormSelector.Text = issueFlag;
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
                        TBSyukkoID.Text = "";
                    }
                    else
                    {
                        TBSyukkoID.Text = row.Cells["出庫ID"].Value?.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力 (null許可)
                    TBShopID.Text = row.Cells["営業所ID"].Value?.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value?.ToString() ?? string.Empty;
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value?.ToString() ?? string.Empty;
                    TBJyutyuID.Text = row.Cells["受注ID"].Value?.ToString() ?? string.Empty;
                    date.Value = row.Cells["出庫日"].Value != null
                                 ? Convert.ToDateTime(row.Cells["出庫日"].Value)
                                 : DateTime.Now; // nullの場合は現在の日付を設定
                    UpdateTextBoxState(checkBoxSyain.Checked);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CellClickイベントハンドラ  
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
                        TBSyukkoSyosaiID.Text = "";
                    }
                    else
                    {
                        TBSyukkoSyosaiID.Text = row.Cells["出庫詳細ID"].Value?.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力 (null許可)
                    TBSyukkoIDS.Text = row.Cells["出庫ID"].Value?.ToString() ?? string.Empty;
                    TBSyohinID.Text = row.Cells["商品ID"].Value?.ToString() ?? string.Empty;
                    TBSuryou.Text = row.Cells["数量"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssueConfirm(int orderID, int SyID)
        {
            using (var context = new SalesManagementContext())
            {
                using (var transaction = context.Database.BeginTransaction()) // トランザクションの開始
                {
                    try
                    {
                        // 引き継ぐ情報を宣言 
                        var syukko = context.TSyukkos.SingleOrDefault(o => o.SyID == SyID);

                        if (syukko == null)
                        {
                            throw new Exception("出庫IDが見つかりません。");
                        }

                        // 注文情報をTChumonに追加
                        var newArrival = new TArrival
                        {
                            EmID = null,  // 社員ID
                            SoID = syukko.SoID,  // 営業所ID    
                            ClID = syukko.ClID,  // 顧客ID    
                            OrID = syukko.OrID,  // 受注ID 
                            ArDate = null, // 注文日    
                            ArStateFlag = 0,
                            ArFlag = 0
                        };

                        try
                        {
                            context.TArrivals.Add(newArrival);
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("TArrivalへの登録に失敗しました: " + ex.Message);
                        }
                        // TSyukkoDetailsの取得  
                        var syukkoDetails = context.TSyukkoDetails.Where(o => o.SyID == syukko.SyID).ToList();
                        if (!syukkoDetails.Any())
                        {
                            MessageBox.Show(":204\\n該当の項目が存在しません。\r\n処理を中止します。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 複数の出庫詳細を全て引き継ぐ
                        foreach (var syukkoDetail in syukkoDetails)
                        {
                            var stock = context.TStocks.FirstOrDefault(s => s.PrID == syukkoDetail.PrID);
                            if (stockCompare(syukkoDetail.PrID, syukkoDetail.SyQuantity))
                            {
                                stock.StQuantity -= syukkoDetail.SyQuantity;

                                StockManager.CompareStock(syukkoDetail.PrID, stock.StQuantity);
                            }
                            else
                            {
                                throw new Exception("在庫が不足しています。"); // 処理を強制終了
                            }
                            // 新しい到着詳細の登録  
                            var newArrivalDetail = new TArrivalDetail
                            {
                                ArID = newArrival.ArID,
                                PrID = syukkoDetail.PrID,  // 出庫詳細から商品IDを取得
                                ArQuantity = syukkoDetail.SyQuantity  // 出庫数量を到着数量として登録
                            };

                            context.TArrivalDetails.Add(newArrivalDetail);
                        }

                        // すべての到着詳細をデータベースに保存
                        context.SaveChanges();
                        transaction.Commit(); // 正常終了ならトランザクションをコミット
                        MessageBox.Show("すべての到着詳細が登録されました。");
                        StockCheck();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // エラー時にロールバック
                        MessageBox.Show($"エラーが発生しました: {ex.Message}");
                        throw;
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
                ToggleIssueSelection();
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
        private void TBSyukkoID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBShainID_TextChanged(object sender, EventArgs e)
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

        private void TBJyutyuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }


        private void TBSyukkoSyosaiID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyukkoIDS_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyohinID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSuryou_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }
        private void colorReset()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    tbfalse();
                    break;
                default:
                    TBSyukkoID.BackColor = SystemColors.Window;
                    TBShainID.BackColor = SystemColors.Window;
                    TBKokyakuID.BackColor = SystemColors.Window;
                    TBShopID.BackColor = SystemColors.Window;
                    TBJyutyuID.BackColor = SystemColors.Window;

                    TBJyutyuID.BackColor = SystemColors.Window;
                    TBSyukkoIDS.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBSuryou.BackColor = SystemColors.Window;
                    break;
            }

        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBSyukkoID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBKokyakuID.KeyPress += NumericTextBox_KeyPress;
            TBShopID.KeyPress += NumericTextBox_KeyPress;
            TBJyutyuID.KeyPress += NumericTextBox_KeyPress;

            TBJyutyuID.KeyPress += NumericTextBox_KeyPress;
            TBSyukkoIDS.KeyPress += NumericTextBox_KeyPress;
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
                int count = context.TSyukkos.Count(order => order.SyStateFlag == 0 || order.SyStateFlag == null);
                if (count == 0)
                {
                    GlobalBadge badge = new GlobalBadge("");
                    b_iss.Refresh();
                }
            }
        }

        private void FlagCount()
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TArrivals.Count(order => order.ArStateFlag == 0 || order.ArStateFlag == null);
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" ");
                    b_arr.Refresh();
                }
            }
        }
        private void Log_Issue(int id)
        {
            string ModeFlag = "";
            if (issueFlag == "←通常")
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
                            Display = "出庫",
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


        private void DisplaySyukkoData(TSyukko matchingRecord)
        {
            // 出庫データを画面に表示するロジック（例：MessageBox または 別画面に表示）
            string syukkoInfo = $"出庫ID: {matchingRecord.SyID}\n" +
                                $"社員ID: {matchingRecord.EmID}\n" +
                                $"顧客ID: {matchingRecord.ClID}\n" +
                                $"営業所ID: {matchingRecord.SoID}\n" +
                                $"受注ID: {matchingRecord.OrID}\n" +
                                $"出庫日: {matchingRecord.SyDate?.ToString("yyyy-MM-dd") ?? "未設定"}\n" +
                                $"表示状態: {(matchingRecord.SyFlag == 0 ? "表示中" : "非表示")}";

            MessageBox.Show(syukkoInfo, "出庫情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool stockCompare(int PrID, int Quantity)
        {
            using (var context = new SalesManagementContext())
            {
                var stock = context.TStocks.FirstOrDefault(o => o.PrID == PrID);

                if (stock.StQuantity >= Quantity)
                {
                    //stock.StQuantity -= Quantity;
                    //context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                    //throw new Exception("在庫が不足しています。"); // 処理を強制終了
                }

            }

        }

        private void StockCheck()
        {
            using (var context = new SalesManagementContext())
            {
                // 出庫情報を取得 (SyStateFlagが2以外のものを対象、または在庫不足状態ではないものも含む)
                var syukkoList = context.TSyukkos
                    .Where(s => s.SyStateFlag != 2)
                    .ToList();

                foreach (var syukko in syukkoList)
                {
                    // 出庫詳細情報を取得 
                    var details = context.TSyukkoDetails
                        .Where(d => d.SyID == syukko.SyID)
                        .ToList();

                    bool isHidden = false; // 初期値: 非表示にしない 
                    string hiddenReason = null;

                    foreach (var detail in details)
                    {
                        // 在庫情報を取得 
                        var stock = context.TStocks
                            .FirstOrDefault(s => s.PrID == detail.PrID);

                        // 在庫が足りない場合 
                        if (stock == null || stock.StQuantity < detail.SyQuantity)
                        {
                            isHidden = true;
                            hiddenReason = "在庫不足のため非表示中";
                            break; // 一つでも不足していれば以降の判定をスキップ 
                        }
                    }

                    // 非表示状態の切り替え
                    // SyStateFlagが0であっても在庫不足の場合は非表示にする
                    if (isHidden)
                    {
                        syukko.SyFlag = 1; // 非表示 
                        syukko.SyHidden = hiddenReason;
                    }
                    else
                    {
                        syukko.SyFlag = 0; // 表示 
                        syukko.SyHidden = null;
                    }

                    // データベースを更新 
                    context.TSyukkos.Update(syukko);
                }

                // 変更を保存 
                context.SaveChanges();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }




}

