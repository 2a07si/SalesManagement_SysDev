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

namespace SalesManagement_SysDev
{
    public partial class issue : Form
    {
        private bool isIssueSelected = true; // 初期状態を出庫(TSyukko)に設定
        private string issueFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス

        private int lastFocusedPanelId = 1;
        public issue()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.Load += new EventHandler(issue_Load);
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
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_acc,
                b_shi,
                b_sal,
                b_lss,
                b_arr
            });

            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayIssues();
            DisplayIssueDetails();

            if (Global.EmployeePermission == 1)
            {
                b_reg.Enabled = true;
            }
            else
            {
                b_reg.Enabled = false;
                b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            }

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
            TBSyukkoId.Text = "";
            TBShopId.Text = "";
            TBShainId.Text = "";
            TBKokyakuId.Text = "";
            TBJyutyuId.Text = "";
            SyukkoFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBSyukkoSyosaiId.Text = "";
            TBSyukkoIDS.Text = "";
            TBSuryou.Text = "";
            TBSyohinId.Text = "";
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
            DisplayIssues();
            DisplayIssueDetails();
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
                        HandleIssueOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
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
            string SyukkoId = TBSyukkoId.Text;
            string ShopId = TBShopId.Text;
            string ShainId = TBShainId.Text;
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool SyukkoFlg = SyukkoFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Syukkodate = date.Value;

            if (TBSyukkoId.Text == null)
            {
                MessageBox.Show("出庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShopId.Text == null)
            {
                MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShainId.Text == null)
            {
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBKokyakuId.Text == null)
            {
                MessageBox.Show("顧客IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBJyutyuId.Text == null)
            {
                MessageBox.Show("受注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {

                var issue = context.TSyukkos.SingleOrDefault(o => o.SyId.ToString() == SyukkoId);
                if (issue != null)
                {
                    issue.SoId = int.Parse(ShopId);                   // 店舗ID
                    issue.EmId = int.Parse(ShainId);                  // 社員ID
                    issue.ClId = int.Parse(KokyakuId);                // クライアントID
                    issue.OrId = int.Parse(JyutyuId);                 // 受注ID
                    issue.SyDate = Syukkodate;                        // 出庫日
                    issue.SyStateFlag = SyukkoFlg ? 2 : 0;            // 出庫状態フラグ
                    issue.SyFlag = DelFlg ? 1 : 0;                    // 削除フラグ
                    issue.SyHidden = Riyuu;                           // 理由

                    // SyukkoFlgがチェックされている場合、出庫詳細の確認を行う
                    if (SyukkoFlg)
                    {
                        // 出庫詳細が存在するか確認
                        var issueDetailsExist = context.TSyukkoDetails
                            .Any(sd => sd.SyId == issue.SyId); // SyId が一致する出庫詳細が存在するか確認

                        if (!issueDetailsExist)
                        {
                            // 出庫詳細が存在しない場合はエラーメッセージを表示
                            MessageBox.Show("出庫詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断
                        }

                        // 出庫詳細が存在する場合、出庫確認処理を実行
                        IssueConfirm(int.Parse(JyutyuId), issue.SyId);
                    }

                    // 更新を保存
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
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
        }

        private void RegisterIssue()
        {
            string SyukkoId = TBSyukkoId.Text;
            string ShopId = TBShopId.Text;
            string ShainId = TBShainId.Text;
            string KokyakuId = TBKokyakuId.Text;
            string JyutyuId = TBJyutyuId.Text;
            bool SyukkoFlg = SyukkoFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Syukkodate = date.Value;

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (!int.TryParse(ShopId, out shop) || !context.MSalesOffices.Any(s => s.SoId == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int employeeId;
                if (!int.TryParse(ShainId, out employeeId) || !context.MEmployees.Any(e => e.EmId == employeeId))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kokyaku;
                if (!int.TryParse(KokyakuId, out kokyaku) || !context.MClients.Any(k => k.ClId == kokyaku))
                {
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int juchu;
                if (!int.TryParse(JyutyuId, out juchu) || !context.TOrders.Any(j => j.OrId == juchu))
                {
                    MessageBox.Show("受注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBShopId.Text == null)
                {
                    MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBShainId.Text == null)
                {
                    MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBKokyakuId.Text == null)
                {
                    MessageBox.Show("顧客IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBJyutyuId.Text == null)
                {
                    MessageBox.Show("受注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 出庫が既に存在するか確認 
                var issue = context.TSyukkos.SingleOrDefault(o => o.OrId.ToString() == SyukkoId);
                if (issue == null)
                {
                    try
                    {
                        // 新しい出庫情報を作成 
                        var newIssue = new TSyukko
                        {
                            SoId = int.Parse(ShopId),           // 店舗ID 
                            EmId = int.Parse(ShainId),          // 社員ID 
                            ClId = int.Parse(KokyakuId),        // クライアントID 
                            OrId = int.Parse(JyutyuId),         // 受注ID 
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
                                .Any(sd => sd.SyId == newIssue.SyId); // SyId が一致する出庫詳細が存在するか確認

                            if (!syukkoDetailsExist)
                            {
                                // 出庫詳細が存在しない場合はエラーメッセージを表示
                                MessageBox.Show("出庫詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // 処理を中断 
                            }

                            // 出庫詳細が存在する場合、出庫確認処理を実行
                            IssueConfirm(issue.OrId, newIssue.SyId);
                        }

                        // 出庫登録成功メッセージ
                        MessageBox.Show("登録が成功しました。");
                        DisplayIssues();
                        DisplayIssueDetails();
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
                        出庫ID = o.SyId,            // 出庫ID
                        社員ID = o.EmId,
                        顧客ID = o.ClId,             // クライアントID
                        営業所ID = o.SoId,              // 店舗ID
                        受注ID = o.OrId,              // 受注ID
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
                string nyuukaId = TBSyukkoId.Text;
                string shopId = TBShopId.Text;
                string shainId = TBShainId.Text;
                string kokyakuId = TBKokyakuId.Text;
                string jyutyuId = TBJyutyuId.Text;
                DateTime? nyuukodate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TSyukkos.AsQueryable();

                // 出庫IDを検索条件に追加
                if (!string.IsNullOrEmpty(nyuukaId))
                {
                    int arId = int.Parse(nyuukaId);
                    query = query.Where(issue => issue.SyId == arId);
                }

                // 店舗IDを検索条件に追加
                if (!string.IsNullOrEmpty(shopId))
                {
                    int soId = int.Parse(shopId);
                    query = query.Where(issue => issue.SoId == soId);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainId))
                {
                    int emId = int.Parse(shainId);
                    query = query.Where(issue => issue.EmId == emId);
                }

                // 顧客IDを検索条件に追加
                if (!string.IsNullOrEmpty(kokyakuId))
                {
                    int clId = int.Parse(kokyakuId);
                    query = query.Where(issue => issue.ClId == clId);
                }

                // 受注IDを検索条件に追加
                if (!string.IsNullOrEmpty(jyutyuId))
                {
                    int orId = int.Parse(jyutyuId);
                    query = query.Where(issue => issue.OrId == orId);
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
                        出庫ID = issue.SyId,         // 出庫ID
                        営業所ID = issue.SoId,           // 店舗ID
                        社員ID = issue.EmId,        // 社員ID
                        顧客ID = issue.ClId,          // クライアントID
                        受注ID = issue.OrId,           // 受注ID
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
            string SyukkoSyosaiID = TBSyukkoSyosaiId.Text;
            string SyukkoID = TBSyukkoIDS.Text;
            string syohinID = TBSyohinId.Text;
            string suryou = TBSuryou.Text;

            if (TBSyukkoSyosaiId.Text == null)
            {
                MessageBox.Show("出庫詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSyukkoIDS.Text == null)
            {
                MessageBox.Show("出庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (TBSyohinId.Text == null)
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
                var issueDetail = context.TSyukkoDetails.SingleOrDefault(od => od.SyDetailId.ToString() == SyukkoSyosaiID);
                if (issueDetail != null)
                {
                    issueDetail.SyId = int.Parse(SyukkoID);
                    issueDetail.PrId = int.Parse(syohinID);
                    issueDetail.SyQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("出庫詳細の更新が成功しました。");
                    DisplayIssueDetails();
                }
                else
                {
                    MessageBox.Show("該当する出庫詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterIssueDetails()
        {
            string SyukkoSyosaiID = TBSyukkoSyosaiId.Text;
            string SyukkoID = TBSyukkoIDS.Text;
            string syohinID = TBSyohinId.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                int shukko;
                if (!int.TryParse(SyukkoID, out shukko) || !context.TSyukkos.Any(s => s.SyId == shukko))
                {
                    MessageBox.Show("出庫IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBSyukkoIDS.Text == null)
                {
                    MessageBox.Show("出庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (TBSyohinId.Text == null)
                {
                    MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBSuryou.Text == null)
                {
                    MessageBox.Show("数量を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrId == shouhin))
                {
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var newIssueDetail = new TSyukkoDetail
                {
                    SyId = int.Parse(SyukkoID),
                    PrId = int.Parse(syohinID),
                    SyQuantity = int.Parse(suryou),
                };

                context.TSyukkoDetails.Add(newIssueDetail);
                context.SaveChanges();
                MessageBox.Show("出庫詳細の登録が成功しました。");
                DisplayIssueDetails();
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
                            var Syukko = context.TSyukkos.FirstOrDefault(o => o.SyId == od.SyId);

                            return Syukko == null || (Syukko.SyFlag != 1 && Syukko.SyStateFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleSyukkoDetails.Select(od => new
                    {
                        出庫詳細ID = od.SyDetailId,
                        出庫ID = od.SyId,
                        商品ID = od.PrId,
                        数量 = od.SyQuantity,
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
                var SyukkoSyosaiID = TBSyukkoSyosaiId.Text;
                var SyukkoIdS = TBSyukkoIDS.Text;
                var syohinID = TBSyohinId.Text;
                var suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.TSyukkoDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(SyukkoSyosaiID))
                {
                    // 出庫詳細IDを検索条件に追加
                    query = query.Where(od => od.SyDetailId.ToString() == SyukkoSyosaiID);
                }

                if (!string.IsNullOrEmpty(SyukkoIdS))
                {
                    //出庫IDを検索条件に追加
                    query = query.Where(od => od.SyId.ToString() == SyukkoIdS);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrId.ToString() == syohinID);
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
                        出庫詳細ID = od.SyDetailId,
                        出庫ID = od.SyId,
                        商品ID = od.PrId,
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
                lastFocusedPanelId = 1;
            else if (issueFlag == "詳細→")
                lastFocusedPanelId = 2;
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

                    // 各テキストボックスにデータを入力 (null許可)
                    TBSyukkoId.Text = row.Cells["出庫ID"].Value?.ToString() ?? string.Empty;
                    TBShopId.Text = row.Cells["営業所ID"].Value?.ToString() ?? string.Empty;
                    TBShainId.Text = row.Cells["社員ID"].Value?.ToString() ?? string.Empty;
                    TBKokyakuId.Text = row.Cells["顧客ID"].Value?.ToString() ?? string.Empty;
                    TBJyutyuId.Text = row.Cells["受注ID"].Value?.ToString() ?? string.Empty;
                    date.Value = row.Cells["出庫年月日"].Value != null
                                 ? Convert.ToDateTime(row.Cells["出庫年月日"].Value)
                                 : DateTime.Now; // nullの場合は現在の日付を設定
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

                    // 各テキストボックスにデータを入力 (null許可)
                    TBSyukkoSyosaiId.Text = row.Cells["出庫詳細ID"].Value?.ToString() ?? string.Empty;
                    TBSyukkoIDS.Text = row.Cells["出庫ID"].Value?.ToString() ?? string.Empty;
                    TBSyohinId.Text = row.Cells["商品ID"].Value?.ToString() ?? string.Empty;
                    TBSuryou.Text = row.Cells["数量"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssueConfirm(int orderId, int SyId)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言 
                var syukko = context.TSyukkos.SingleOrDefault(o => o.SyId == SyId);

                if (syukko == null)
                {
                    throw new Exception("出庫IDが見つかりません。");
                }
                // 注文情報をTChumonに追加
                var newArrival = new TArrival
                {

                    EmId = null,  // 社員ID
                    SoId = syukko.SoId,  // 営業所ID    
                    ClId = syukko.ClId,  // 顧客ID    
                    OrId = syukko.OrId,  // 受注ID 
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
                var syukkoDetail = context.TSyukkoDetails.SingleOrDefault(o => o.SyId == syukko.SyId);
                var newArrivalDetail = new TArrivalDetail
                {
                    ArId = newArrival.ArId,
                    PrId = syukkoDetail.PrId,
                    ArQuantity = syukkoDetail.SyQuantity
                };
                try
                {
                    context.TArrivalDetails.Add(newArrivalDetail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("TArrivalDetailへの登録に失敗しました:" + ex.Message);
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
                ToggleIssueSelection();
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
        private void TBSyukkoId_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBShainId_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBKokyakuId_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBShopId_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 2);
        }

        private void TBJyutyuId_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }


        private void TBSyukkoSyosaiId_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyukkoIDS_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyohinId_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSuryou_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }
    }



}
