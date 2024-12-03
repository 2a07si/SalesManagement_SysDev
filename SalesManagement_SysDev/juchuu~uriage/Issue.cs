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
        }

        private void issue_Load(object sender, EventArgs e)
        {
            UpdateNyuukoFlags();
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


            if (Global.EmployeePermission == 1)
            {
                b_reg.Enabled = true;
            }
            else
            {
                b_reg.Enabled = false;
                b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            }

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
            TBShainID.Text = "";
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
                        MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    break;
                case CurrentStatus.Status.検索:
                    SearchIssues();
                    break;
                default:
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
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

            if (TBSyukkoID.Text == "")
            {
                TBSyukkoID.BackColor = Color.Yellow;
                TBSyukkoID.Focus();
                MessageBox.Show("出庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TBShainID.Focus();
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

            if (date.Value > DateTime.Today)
            {
                var result = MessageBox.Show(
                    "出庫日が未来を指していますが、よろしいですか？",
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
                int shukko;
                if (!int.TryParse(ShopID, out shukko) || !context.TSyukkos.Any(s => s.SyID == shukko))
                {
                    TBSyukkoID.BackColor = Color.Yellow;
                    TBSyukkoID.Focus();
                    MessageBox.Show("出庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int shop;
                if (!int.TryParse(ShopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int employeeID;
                if (!int.TryParse(ShainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kokyaku;
                if (!int.TryParse(KokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    TBKokyakuID.BackColor = Color.Yellow;
                    TBKokyakuID.Focus();
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int juchu;
                if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    TBJyutyuID.BackColor = Color.Yellow;
                    TBJyutyuID.Focus();
                    MessageBox.Show("受注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var issue = context.TSyukkos.SingleOrDefault(o => o.SyID.ToString() == SyukkoID);

                if (issue != null)
                {
                    issue.SoID = int.Parse(ShopID);                   // 店舗ID
                    issue.EmID = int.Parse(ShainID);                  // 社員ID
                    issue.ClID = int.Parse(KokyakuID);                // クライアントID
                    issue.OrID = int.Parse(JyutyuID);                 // 受注ID
                    issue.SyDate = Syukkodate;                        // 出庫日
                    issue.SyStateFlag = SyukkoFlg ? 2 : 0;            // 出庫状態フラグ
                    issue.SyFlag = DelFlg ? 1 : 0;                    // 削除フラグ
                    issue.SyHidden = Riyuu;                           // 理由

                    // SyukkoFlgがチェックされている場合、出庫詳細の確認を行う
                    if (SyukkoFlg)
                    {
                        // 受注IDの重複チェック
                        bool isDuplicate = context.TArrivals.Any(c => c.OrID == issue.OrID);
                        if (isDuplicate)
                        {
                            MessageBox.Show($"この受注ID ({issue.OrID}) は既に登録されています。更新を中止します。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // 更新処理を中止
                        }
                        // 出庫詳細が存在するか確認
                        var issueDetailsExist = context.TSyukkoDetails
                            .Any(sd => sd.SyID == issue.SyID); // SyID が一致する出庫詳細が存在するか確認

                        if (!issueDetailsExist)
                        {
                            // 出庫詳細が存在しない場合はエラーメッセージを表示
                            MessageBox.Show("出庫詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断
                        }


                        issue.SyFlag = 1;
                        issue.SyHidden = "出庫確定処理済";
                        // 出庫詳細が存在する場合、出庫確認処理を実行
                        IssueConfirm(int.Parse(JyutyuID), issue.SyID);
                    }

                    // 更新を保存
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        Log_Issue(issue.SyID);
                        DisplayIssues(); // 更新後に出庫情報を再表示

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
                        MessageBox.Show("エラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("該当する出庫情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int shop;
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
                    TBShainID.Focus();
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
                if (!int.TryParse(ShopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int employeeID;
                if (!int.TryParse(ShainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kokyaku;
                if (!int.TryParse(KokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    TBKokyakuID.BackColor = Color.Yellow;
                    TBKokyakuID.Focus();
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int juchu;
                if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    TBJyutyuID.BackColor = Color.Yellow;
                    TBJyutyuID.Focus();
                    MessageBox.Show("受注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (TBShainID.Text != empID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }
                if (date.Value > DateTime.Today)
                {
                    var result = MessageBox.Show(
                        "出庫日が未来を指していますが、よろしいですか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return; // 処理を中断
                    }
                }
                // 出庫が既に存在するか確認 
                var issue = context.TSyukkos.SingleOrDefault(o => o.OrID.ToString() == SyukkoID);
                if (issue == null)
                {
                    try
                    {
                        // 新しい出庫情報を作成 
                        var newIssue = new TSyukko
                        {
                            SoID = int.Parse(ShopID),           // 店舗ID 
                            EmID = int.Parse(ShainID),          // 社員ID 
                            ClID = int.Parse(KokyakuID),        // クライアントID 
                            OrID = int.Parse(JyutyuID),         // 受注ID 
                            SyDate = Syukkodate,                // 出庫日 
                            SyStateFlag = SyukkoFlg ? 2 : 0,    // 出庫状態フラグ 
                            SyFlag = DelFlg ? 1 : 0,            // 削除フラグ 
                            SyHidden = Riyuu                   // 出庫理由 
                        };

                        // 出庫情報をコンテキストに追加 
                        context.TSyukkos.Add(newIssue);
                        context.SaveChanges(); // 保存して新しい出庫IDが自動で生成される 

                        // SyukkoFlagがチェックされている場合、出庫詳細の確認を行う 
                        if (SyukkoFlag.Checked)
                        {
                            var syukkoDetailsExist = context.TSyukkoDetails
                                .Any(sd => sd.SyID == newIssue.SyID); // SyID が一致する出庫詳細が存在するか確認

                            if (!syukkoDetailsExist)
                            {
                                // 出庫詳細が存在しない場合はエラーメッセージを表示
                                MessageBox.Show("出庫詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // 処理を中断 
                            }

                            // 出庫詳細が存在する場合、出庫確認処理を実行
                            IssueConfirm(issue.OrID, newIssue.SyID);
                        }

                        // 出庫登録成功メッセージ
                        MessageBox.Show("登録が成功しました。");
                        DisplayIssues();
                        DisplayIssueDetails();
                        Log_Issue(newIssue.SyID);
                    }
                    catch (DbUpdateException ex)
                    {
                        // inner exception の詳細を表示する 
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show("エラーの詳細: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("エンティティの変更を保存中にエラーが発生しました。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // その他のエラーに対処する 
                        MessageBox.Show("エラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("既に出庫情報が存在しています。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayIssues()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示

                    var issues = checkBox_2.Checked
                      ? context.TSyukkos.ToList()  // チェックされていれば全ての注文を表示
                      : context.TSyukkos
                         .Where(o => o.SyFlag != 1 && o.SyStateFlag != 2)
                         .ToList();       // データを選択してDataGridViewに表示
                    dataGridView1.DataSource = issues.Select(o => new
                    {
                        出庫ID = o.SyID,            // 出庫ID
                        社員ID = o.EmID,
                        顧客ID = o.ClID,             // クライアントID
                        営業所ID = o.SoID,              // 店舗ID
                        受注ID = o.OrID,              // 受注ID
                        出庫年月日 = o.SyDate,        // 出庫日
                        状態フラグ = o.SyStateFlag,     // 出庫状態フラグ
                        非表示フラグ = o.SyFlag,         // 削除フラグ
                        非表示理由 = o.SyHidden            // 理由
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchIssues()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                string nyuukaID = TBSyukkoID.Text;
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string JyutyuID = TBJyutyuID.Text;
                DateTime? nyuukodate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TSyukkos.AsQueryable();

                // 出庫IDを検索条件に追加
                if (!string.IsNullOrEmpty(nyuukaID))
                {
                    int arID = int.Parse(nyuukaID);
                    query = query.Where(issue => issue.SyID == arID);
                }

                // 店舗IDを検索条件に追加
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
                if (nyuukodate.HasValue)
                {
                    query = query.Where(issue => issue.SyDate == nyuukodate.Value);
                }

                // 結果を取得
                var issues = query.ToList();

                if (issues.Any())
                {
                    // dataGridView1 に結果を表示
                    dataGridView1.DataSource = issues.Select(issue => new
                    {
                        出庫ID = issue.SyID,         // 出庫ID
                        営業所ID = issue.SoID,           // 店舗ID
                        社員ID = issue.EmID,        // 社員ID
                        顧客ID = issue.ClID,          // クライアントID
                        受注ID = issue.OrID,           // 受注ID
                        出庫年月日 = issue.SyDate,     // 出庫日
                        状態フラグ = issue.SyStateFlag,  // 出庫状態フラグ
                        非表示フラグ = issue.SyFlag,      // 削除フラグ
                        非表示理由 = issue.SyHidden         // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する出庫情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }




        private void UpdateIssueDetails()
        {
            string SyukkoSyosaiID = TBSyukkoSyosaiID.Text;
            string SyukkoID = TBSyukkoIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            if (TBSyukkoSyosaiID.Text == "")
            {
                TBSyukkoSyosaiID.BackColor = Color.Yellow;
                TBSyukkoSyosaiID.Focus();
                MessageBox.Show("出庫詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSyukkoIDS.Text == "")
            {
                TBSyukkoIDS.BackColor = Color.Yellow;
                TBSyukkoIDS.Focus();
                MessageBox.Show("出庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int shousai;
                if (!int.TryParse(SyukkoSyosaiID, out shousai) || !context.TSyukkoDetails.Any(s => s.SyDetailID == shousai))
                {
                    TBSyukkoSyosaiID.BackColor = Color.Yellow;
                    TBSyukkoSyosaiID.Focus();
                    MessageBox.Show("出庫詳細IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int shukko;
                if (!int.TryParse(SyukkoID, out shukko) || !context.TSyukkos.Any(s => s.SyID == shukko))
                {
                    TBSyukkoIDS.BackColor = Color.Yellow;
                    TBSyukkoIDS.Focus();
                    MessageBox.Show("出庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // EmIDがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var issueDetail = context.TSyukkoDetails.SingleOrDefault(od => od.SyDetailID.ToString() == SyukkoSyosaiID);
                if (issueDetail != null)
                {
                    issueDetail.SyID = int.Parse(SyukkoID);
                    issueDetail.PrID = int.Parse(syohinID);
                    issueDetail.SyQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("出庫詳細の更新が成功しました。");
                    DisplayIssueDetails();
                    Log_Issue(issueDetail.SyDetailID);
                }
                else
                {
                    MessageBox.Show("該当する出庫詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterIssueDetails()
        {
            string SyukkoSyosaiID = TBSyukkoSyosaiID.Text;
            string SyukkoID = TBSyukkoIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                int shukko;
                if (TBSyukkoIDS.Text == "")
                {
                    TBSyukkoIDS.BackColor = Color.Yellow;
                    TBSyukkoIDS.Focus();
                    MessageBox.Show("出庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!int.TryParse(SyukkoID, out shukko) || !context.TSyukkos.Any(s => s.SyID == shukko))
                {
                    TBSyukkoIDS.BackColor = Color.Yellow;
                    TBSyukkoIDS.Focus();
                    MessageBox.Show("出庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // EmIDがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var existingOrderDetail = context.TSyukkoDetails.FirstOrDefault(o => o.SyID == shukko);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show("この出庫IDにはすでに出庫詳細が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 処理を終了
                }
                var newIssueDetail = new TSyukkoDetail
                {
                    SyID = int.Parse(SyukkoID),
                    PrID = int.Parse(syohinID),
                    SyQuantity = int.Parse(suryou),
                };

                context.TSyukkoDetails.Add(newIssueDetail);
                context.SaveChanges();
                MessageBox.Show("出庫詳細の登録が成功しました。");
                DisplayIssueDetails();
                Log_Issue(newIssueDetail.SyDetailID);
            }
        }

        private void DisplayIssueDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var SyukkoDetails = context.TSyukkoDetails.ToList();

                    var visibleSyukkoDetails = checkBox_2.Checked
                        ? SyukkoDetails
                        : SyukkoDetails.Where(od =>
                        {
                            var Syukko = context.TSyukkos.FirstOrDefault(o => o.SyID == od.SyID);

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
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("該当する出庫詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    date.Value = row.Cells["出庫年月日"].Value != null
                                 ? Convert.ToDateTime(row.Cells["出庫年月日"].Value)
                                 : DateTime.Now; // nullの場合は現在の日付を設定
                    UpdateTextBoxState(checkBoxSyain.Checked);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssueConfirm(int orderID, int SyID)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
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
                    MessageBox.Show("指定された出庫情報が見つかりません。処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 複数の出庫詳細を全て引き継ぐ
                foreach (var syukkoDetail in syukkoDetails)
                {
                    // 新しい到着詳細の登録  
                    var newArrivalDetail = new TArrivalDetail
                    {
                        ArID = newArrival.ArID,
                        PrID = syukkoDetail.PrID,  // 出庫詳細から商品IDを取得
                        ArQuantity = syukkoDetail.SyQuantity  // 出庫数量を到着数量として登録
                    };

                    try
                    {
                        context.TArrivalDetails.Add(newArrivalDetail);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("TArrivalDetailへの登録に失敗しました: " + ex.Message);
                    }
                }

                // すべての到着詳細をデータベースに保存
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("すべての到着詳細が登録されました。");
                }
                catch (Exception ex)
                {
                    throw new Exception("データベースへの保存に失敗しました: " + ex.Message);
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
                        MessageBox.Show("最新のログ履歴が見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Logへの登録に失敗しました:" + ex.Message);
            }
        }

        private void UpdateNyuukoFlags()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // Flag = 1 の NyuukoChecker を取得
                    var checkerList = context.NyuukoCheckers
                        .Where(c => c.Flag == true)
                        .ToList();

                    // SyukkoID のリストを取得
                    var syukkoIDs = checkerList.Select(c => c.SyukkoID).ToList();

                    if (syukkoIDs.Any())
                    {
                        // 対応する SyukkoID を持つ TSyukko レコードを取得
                        var syukkoRecords = context.TSyukkos
                            .Where(s => syukkoIDs.Contains(s.SyID.ToString()))
                            .ToList();

                        // TSyukko の更新
                        foreach (var record in syukkoRecords)
                        {
                            record.SyFlag = 0; // 必要に応じて設定値を変更
                            record.SyHidden = null; // 必要に応じて設定値を変更
                        }

                        // NyuukoChecker の更新
                        foreach (var checker in checkerList)
                        {
                            checker.DelFlag = true; // DelFlag を true に設定
                            checker.Flag = false;  // Flag を false に設定
                        }

                        // データベースへ保存
                        context.SaveChanges();
                        // デバッグ用メッセージを表示
                        var debugMessage = new System.Text.StringBuilder();

                        debugMessage.AppendLine("更新されたレコード:");
                        debugMessage.AppendLine("\n--- TSyukko ---");
                        foreach (var record in syukkoRecords)
                        {
                            debugMessage.AppendLine($"SyukkoID: {record.SyID}, SyFlag: {record.SyFlag}, SyHidden: {record.SyHidden}");
                        }

                        debugMessage.AppendLine("\n--- NyuukoChecker ---");
                        foreach (var checker in checkerList)
                        {
                            debugMessage.AppendLine($"SyukkoID: {checker.SyukkoID}, DelFlag: {checker.DelFlag}, Flag: {checker.Flag}");
                        }

                        // MessageBox で表示
                        MessageBox.Show(debugMessage.ToString(), "デバッグ情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("エラー: " + ex.Message);
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


    }




}

