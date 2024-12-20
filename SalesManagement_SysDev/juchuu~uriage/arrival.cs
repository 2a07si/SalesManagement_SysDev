﻿using System;
using System.Linq;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ; // 各種クラスを使用する
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using SalesManagement_SysDev.juchuu_uriage;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using SalesManagement_SysDev.Entity;

namespace SalesManagement_SysDev
{
    public partial class arrival : Form
    {
        string empID = GlobalEmp.EmployeeID;
        private bool isArrivalSelected = true; // 初期状態を入荷(TArrival)に設定
        private string arrivalFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス
        private DateTime timesamp = DateTime.Now;
        private int lastFocusedPanelID = 1;
        public arrival(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.Load += new EventHandler(arrival_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

            // パネル1とパネル2のコントロールにイベントを設定
            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel3, 2);  // パネル2の場合
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;

        }

        private void arrival_Load(object sender, EventArgs e)
        {
            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
            UpdateTextBoxState(checkBoxSyain.Checked);

            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_shi,
                b_sal,
                b_iss
            });
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayArrivals();
            DisplayArrivalDetails();
            b_reg.Enabled = false;
            b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            SetupNumericOnlyTextBoxes();
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
        private void b_iss_Click(object sender, EventArgs e) => formChanger.NavigateToIssueForm();
        private void clear_Click(object sender, EventArgs e)
        {
            colorReset();
            ClearText();
        }

        private void ClearText()
        {
            TBNyuukaID.Text = "";
            TBShopID.Text = "";
            TBKokyakuID.Text = "";
            TBJyutyuID.Text = "";
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
            tbtrue();
            colorReset();
            dateCheckBox.Checked = false;
            checkBox_2.Checked = false;
            if (checkBoxSyain.Checked == false)
            {
                TBShainID.Text = "";
            }
            ResetYellowBackgrounds(this);
            UpdateClose_kun(arrivalFlag);
            UpdateClose_Chan();

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
            DisplayArrivals();
            DisplayArrivalDetails();
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }

        private void tbfalse()
        {
            TBNyuukaID.Enabled = false;
            TBNyukaSyosaiID.Enabled = false;
            TBNyuukaID.BackColor = Color.Gray;
            TBNyukaSyosaiID.BackColor = Color.Gray;
            TBNyuukaID.Text = "";
            TBNyukaSyosaiID.Text = "";
        }
        private void tbtrue()
        {
            TBNyuukaID.Enabled = true;
            TBNyukaSyosaiID.Enabled = true;
            TBNyuukaID.BackColor = Color.White;
            TBNyukaSyosaiID.BackColor = Color.White;
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
                        HandleArrivalOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        colorReset();
                        HandleArrivalDetailOperation();
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
        private void HandleArrivalOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    colorReset();
                    UpdateArrival();
                    break;
                case CurrentStatus.Status.登録:
                    colorReset();
                    RegisterArrival();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayArrivals();
                    break;
                case CurrentStatus.Status.検索:
                    colorReset();
                    SearchArrivals();
                    break;
                default:
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void UpdateArrival()
        {
            string ArID = TBNyuukaID.Text;
            string ShopID = TBShopID.Text;
            string ShainID = TBShainID.Text;
            string KokyakuID = TBKokyakuID.Text;
            string JyutyuID = TBJyutyuID.Text;
            bool NyuukaFlg = NyuukaFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Nyuukadate = date.Value;
            colorReset();

            // 入力チェック
            if (CheckTBValue(TBNyuukaID, ArID, "入荷ID")) return;
            if (CheckTBValue(TBShopID, ShopID, "営業所ID")) return;
            if (CheckTBValue(TBShainID, ShainID, "社員ID")) return;
            if (CheckTBValue(TBKokyakuID, KokyakuID, "顧客ID")) return;
            if (CheckTBValue(TBJyutyuID, JyutyuID, "受注ID")) return;

            // 社員IDの整合性チェック
            if (ShainID != empID)
            {
                MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                return;
            }

            // 入荷日が未来の日付の場合の確認
            if (date.Value > DateTime.Now)
            {
                var result = MessageBox.Show(
                    "入荷日が未来を指していますが、よろしいですか？",
                    "確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No) return; // 処理を中断
            }

            // 入荷情報が存在するかチェック
            if (Kuraberu_kun.Kuraberu_chan("入荷", "通常", "更新", int.Parse(ArID), timesamp) == false)
            {
                return;
            }

            using (var context = new SalesManagementContext())
            {
                // 入荷IDの存在確認
                if (!int.TryParse(ArID, out int arID) || !context.TArrivals.Any(s => s.ArID == arID))
                {
                    NotFound(TBNyuukaID, "入荷ID", ArID);
                    return;
                }

                // 営業所IDの存在確認
                if (!int.TryParse(ShopID, out int shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    NotFound(TBShopID, "営業所ID", ShopID);
                    return;
                }

                // 社員IDの存在確認
                if (!int.TryParse(ShainID, out int employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    NotFound(TBShainID, "社員ID", ShainID);
                    return;
                }

                // 顧客IDの存在確認
                if (!int.TryParse(KokyakuID, out int kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    NotFound(TBKokyakuID, "顧客ID", KokyakuID);
                    return;
                }

                // 受注IDの存在確認
                if (!int.TryParse(JyutyuID, out int juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    NotFound(TBJyutyuID, "受注ID", JyutyuID);
                    return;
                }

                // 入荷情報の更新処理
                var arrival = context.TArrivals.SingleOrDefault(o => o.ArID.ToString() == ArID);
                if (arrival != null)
                {
                    arrival.SoID = shop;
                    arrival.EmID = employeeID;
                    arrival.ClID = kokyaku;
                    arrival.OrID = juchu;
                    arrival.ArDate = Nyuukadate;
                    arrival.ArStateFlag = NyuukaFlg ? 2 : 0;
                    arrival.ArFlag = DelFlg ? 1 : 0;
                    arrival.ArHidden = Riyuu;

                    // 入荷詳細のチェックと更新処理
                    if (NyuukaFlg)
                    {
                        // 受注IDの重複チェック
                        if (context.TShipments.Any(c => c.OrID == arrival.OrID))
                        {
                            MessageBox.Show($"この受注ID ({arrival.OrID}) は既に登録されています。更新を中止します。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // 更新処理を中止
                        }

                        // 入荷詳細の確認
                        if (!context.TArrivalDetails.Any(ad => ad.ArID == arrival.ArID))
                        {
                            NotFound(TBNyuukaID, "入荷詳細ID", arrival.ArID.ToString());
                            return;
                        }

                        arrival.ArFlag = 1;
                        arrival.ArHidden = "入荷確定処理済";

                        // 入荷確定処理の実行
                        ArrivalConfirm(arrival.ArID);
                    }

                    // データベースの更新処理
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        Log_Arrival(arrival.ArID);
                        DisplayArrivals();
                        DisplayArrivalDetails();
                        ResetYellowBackgrounds(this);
                    }
                    catch (DbUpdateException ex)
                    {
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"エラーの詳細: {ex.InnerException.Message}");
                        }
                        else
                        {
                            MessageBox.Show(":201\n登録操作が失敗しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    NotFound(TBNyuukaID, "入荷ID", ArID);
                }
            }

            countFlag();
            FlagCount();
        }

        private void RegisterArrival()
        {
            string NyuukaID = TBNyuukaID.Text;
            string ShopID = TBShopID.Text;
            string ShainID = TBShainID.Text;
            string KokyakuID = TBKokyakuID.Text;
            string JyutyuID = TBJyutyuID.Text;
            bool NyuukaFlg = NyuukaFlag.Checked;
            bool DelFlg = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;
            DateTime Nyuukodate = date.Value;
            colorReset();

            using (var context = new SalesManagementContext())
            {
                // 必須項目の入力チェック
                if (CheckTBValue(TBShopID, ShopID, "営業所ID")) return;
                if (CheckTBValue(TBShainID, ShainID, "社員ID")) return;
                if (CheckTBValue(TBKokyakuID, KokyakuID, "顧客ID")) return;
                if (CheckTBValue(TBJyutyuID, JyutyuID, "受注ID")) return;

                // 入力値の存在チェック
                if (!int.TryParse(ShopID, out int shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    NotFound(TBShopID, "営業所ID", ShopID);
                    return;
                }

                // 社員IDの存在確認
                if (!int.TryParse(ShainID, out int employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    NotFound(TBShainID, "社員ID", ShainID);
                    return;
                }

                // 顧客IDの存在確認
                if (!int.TryParse(KokyakuID, out int kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    NotFound(TBKokyakuID, "顧客ID", KokyakuID);
                    return;
                }

                // 受注IDの存在確認
                if (!int.TryParse(JyutyuID, out int juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    NotFound(TBJyutyuID, "受注ID", JyutyuID);
                    return;
                }

                if (TBShainID.Text != empID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }

                if (date.Value > DateTime.Now)
                {
                    var result = MessageBox.Show(
                        "入荷日が未来を指していますが、よろしいですか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No) return;
                }

                // 入荷が既に存在するか確認
                var arrival = context.TArrivals.SingleOrDefault(o => o.OrID.ToString() == NyuukaID);
                if (arrival != null)
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // 新しい入荷情報を作成
                    var newArrival = new TArrival
                    {
                        SoID = shop,
                        EmID = employeeID,
                        ClID = kokyaku,
                        OrID = juchu,
                        ArDate = Nyuukodate,
                        ArStateFlag = NyuukaFlg ? 2 : 0,
                        ArFlag = DelFlg ? 1 : 0,
                        ArHidden = Riyuu
                    };

                    context.TArrivals.Add(newArrival);

                    // NyuukaFlagがチェックされている場合の詳細確認
                    if (NyuukaFlg && !context.TArrivalDetails.Any(ad => ad.ArID == newArrival.ArID))
                    {
                        NotFound(TBNyuukaID, "入荷詳細ID", newArrival.ArID.ToString());
                        return;
                    }

                    context.SaveChanges();
                    MessageBox.Show("登録が成功しました。");
                    Log_Arrival(newArrival.ArID);
                    DisplayArrivals();
                    ResetYellowBackgrounds(this);
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"エラーの詳細: {ex.InnerException.Message}");
                    }
                    else
                    {
                        MessageBox.Show(":201\n登録操作が失敗しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($":500\n不明なエラーが発生しました。\n: {ex.Message}");
                }
            }
        }


        private void DisplayArrivals()
        {
            try
            {

                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての入庫を表示
                    var arrivals = checkBox_2.Checked
                        ? (checkBox1.Checked
                            ? context.TArrivals.OrderByDescending(a => a.ArID).ToList() // 降順
                            : context.TArrivals.OrderBy(a => a.ArID).ToList())          // 昇順
                        : (checkBox1.Checked
                            ? context.TArrivals
                                .Where(a => a.ArFlag != 1 && a.ArStateFlag != 2)
                                .OrderByDescending(a => a.ArID) // 条件に合致するものを降順で取得
                                .ToList()
                            : context.TArrivals
                                .Where(a => a.ArFlag != 1 && a.ArStateFlag != 2)
                                .OrderBy(a => a.ArID)          // 条件に合致するものを昇順で取得
                                .ToList());

                    // データを選択してDataGridViewに表示
                    dataGridView1.DataSource = arrivals.Select(o => new
                    {
                        入荷ID = o.ArID,            // 入荷ID
                        営業所ID = o.SoID,              // 営業所ID
                        社員ID = o.EmID,           // 社員ID
                        顧客ID = o.ClID,             // クライアントID
                        受注ID = o.OrID,              // 受注ID
                        入荷日 = o.ArDate,        // 入荷日
                        状態フラグ = o.ArStateFlag,     // 入荷状態フラグ
                        非表示フラグ = o.ArFlag,         // 削除フラグ
                        備考 = o.ArHidden            // 理由
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchArrivals()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                string nyuukaID = TBNyuukaID.Text;
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string JyutyuID = TBJyutyuID.Text;
                string riyuu = TBRiyuu.Text.Trim(); // 理由テキストボックスの値を取得
                DateTime? nyuukodate = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御

                // 基本的なクエリ
                var query = context.TArrivals.AsQueryable();

                // 入荷IDを検索条件に追加
                if (!string.IsNullOrEmpty(nyuukaID))
                {
                    int arID = int.Parse(nyuukaID);
                    query = query.Where(arrival => arrival.ArID == arID);
                }

                // 営業所IDを検索条件に追加
                if (!string.IsNullOrEmpty(shopID))
                {
                    int soID = int.Parse(shopID);
                    query = query.Where(arrival => arrival.SoID == soID);
                }

                // 社員IDを検索条件に追加
                if (!string.IsNullOrEmpty(shainID))
                {
                    int emID = int.Parse(shainID);
                    query = query.Where(arrival => arrival.EmID == emID);
                }

                // 顧客IDを検索条件に追加
                if (!string.IsNullOrEmpty(kokyakuID))
                {
                    int clID = int.Parse(kokyakuID);
                    query = query.Where(arrival => arrival.ClID == clID);
                }

                // 受注IDを検索条件に追加
                if (!string.IsNullOrEmpty(JyutyuID))
                {
                    int orID = int.Parse(JyutyuID);
                    query = query.Where(arrival => arrival.OrID == orID);
                }

                // 入荷日を検索条件に追加（チェックボックスがチェックされている場合）
                if (nyuukodate.HasValue)
                {
                    query = query.Where(arrival => arrival.ArDate == nyuukodate.Value);
                }

                // 入荷フラグ(NyuukaFlag)の検索条件を追加
                if (NyuukaFlag.Checked)
                {
                    query = query.Where(arrival => arrival.ArStateFlag == 2);
                }
                else
                {
                    query = query.Where(arrival => arrival.ArStateFlag == 0);
                }

                // 削除フラグ(DelFlag)の検索条件を追加
                if (DelFlag.Checked)
                {
                    query = query.Where(arrival => arrival.ArFlag == 1);
                }
                else
                {
                    query = query.Where(arrival => arrival.ArFlag == 0);
                }

                // 理由(TBRiyuu)の検索条件を追加
                if (!string.IsNullOrEmpty(riyuu))
                {
                    query = query.Where(arrival => arrival.ArHidden.Contains(riyuu));
                }

                // 結果を取得
                var arrivals = query.ToList();

                if (arrivals.Any())
                {
                    // データを選択してDataGridViewに表示
                    dataGridView1.DataSource = arrivals.Select(o => new
                    {
                        入荷ID = o.ArID,            // 入荷ID
                        営業所ID = o.SoID,          // 営業所ID
                        社員ID = o.EmID,           // 社員ID
                        顧客ID = o.ClID,           // クライアントID
                        受注ID = o.OrID,           // 受注ID
                        入荷日 = o.ArDate,         // 入荷日
                        状態フラグ = o.ArStateFlag, // 入荷状態フラグ
                        非表示フラグ = o.ArFlag,   // 削除フラグ
                        備考 = o.ArHidden    // 理由
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア
                }
            }
        }
        private void UpdateArrivalDetails()
        {
            string nyuukaSyosaiID = TBNyukaSyosaiID.Text;
            string nyuukaID = TBNyuukaIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            // 必須項目の入力チェック
            if (CheckTBValue(TBNyukaSyosaiID, nyuukaSyosaiID, "入荷詳細ID")) return;
            if (CheckTBValue(TBNyuukaIDS, nyuukaID, "入荷ID")) return;
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, suryou, "数量")) return;

            if (!Kuraberu_kun.Kuraberu_chan("入荷", "詳細", "更新", int.Parse(nyuukaSyosaiID), timesamp))
            {
                return;
            }

            using (var context = new SalesManagementContext())
            {
                // 入荷詳細IDの検証
                if (!int.TryParse(nyuukaSyosaiID, out int syousai) || !context.TArrivalDetails.Any(n => n.ArDetailID == syousai))
                {
                    NotFound(TBNyukaSyosaiID, "入荷詳細", nyuukaSyosaiID);
                    return;
                }

                // 入荷IDの検証
                if (!int.TryParse(nyuukaID, out int nyuuka) || !context.TArrivals.Any(n => n.ArID == nyuuka))
                {
                    NotFound(TBNyuukaIDS, "入荷", nyuukaID);
                    return;
                }

                // 商品IDの検証
                if (!int.TryParse(syohinID, out int shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    NotFound(TBSyohinID, "商品", syohinID);
                    return;
                }

                // データ更新処理
                var arrivalDetail = context.TArrivalDetails.SingleOrDefault(od => od.ArDetailID == syousai);
                if (arrivalDetail != null)
                {
                    arrivalDetail.ArID = nyuuka;
                    arrivalDetail.PrID = shouhin;
                    arrivalDetail.ArQuantity = int.Parse(suryou);

                    context.SaveChanges();

                    MessageBox.Show("入荷詳細の更新が成功しました。");
                    Log_Arrival(arrivalDetail.ArDetailID);
                    DisplayArrivalDetails();
                    countFlag();
                    ResetYellowBackgrounds(this); // 背景色のリセット
                }
                else
                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RegisterArrivalDetails()
        {
            string nyuukaSyosaiID = TBNyukaSyosaiID.Text;
            string nyuukaID = TBNyuukaIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            // 必須項目の入力チェック
            if (CheckTBValue(TBNyuukaIDS, nyuukaID, "入荷ID")) return;
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBSuryou, suryou, "数量")) return;

            using (var context = new SalesManagementContext())
            {
                // 入荷IDの検証
                if (!int.TryParse(nyuukaID, out int nyuuka) || !context.TArrivals.Any(n => n.ArID == nyuuka))
                {
                    NotFound(TBNyuukaIDS, "入荷", nyuukaID);
                    return;
                }

                // 商品IDの検証
                if (!int.TryParse(syohinID, out int shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    NotFound(TBSyohinID, "商品", syohinID);
                    return;
                }

                // 入荷詳細の重複確認
                if (context.TArrivalDetails.Any(o => o.ArID == nyuuka))
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 新しい入荷詳細の登録
                var newArrivalDetail = new TArrivalDetail
                {
                    ArID = nyuuka,
                    PrID = shouhin,
                    ArQuantity = int.Parse(suryou),
                };

                context.TArrivalDetails.Add(newArrivalDetail);
                context.SaveChanges();

                MessageBox.Show("入荷詳細の登録が成功しました。");
                Log_Arrival(newArrivalDetail.ArDetailID);
                DisplayArrivalDetails();
                ResetYellowBackgrounds(this); // 背景色のリセット
            }
        }

        private void DisplayArrivalDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {

                    // 入庫詳細のリストを取得（checkBox1の状態に応じて並べ替え）
                    var ArrivalDetails = checkBox1.Checked
                        ? context.TArrivalDetails.OrderByDescending(ad => ad.ArID).ToList() // 降順
                        : context.TArrivalDetails.OrderBy(ad => ad.ArID).ToList();          // 昇順

                    // checkBox_2がチェックされている場合、フィルタリングを無視してすべての詳細を表示
                    var visibleArrivalDetails = checkBox_2.Checked
                        ? ArrivalDetails // チェックされていれば全て表示（並び替え済み）
                        : ArrivalDetails.Where(ad =>
                        {
                            var Arrival = context.TArrivals.FirstOrDefault(a => a.ArID == ad.ArID);

                            return Arrival == null || (Arrival.ArFlag != 1 && Arrival.ArStateFlag != 2);
                        }).ToList();


                    dataGridView2.DataSource = visibleArrivalDetails.Select(od => new
                    {
                        入荷詳細ID = od.ArDetailID,
                        入荷ID = od.ArID,
                        商品ID = od.PrID,
                        数量 = od.ArQuantity.HasValue ? od.ArQuantity.Value.ToString("N0") : "0"
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchArrivalDetails()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得
                var nyuukaSyosaiID = TBNyukaSyosaiID.Text;
                var nyuukaID = TBNyuukaIDS.Text;
                var syohinID = TBSyohinID.Text;
                var suryou = TBSuryou.Text;

                // 基本的なクエリ
                var query = context.TArrivalDetails.AsQueryable();

                // 各条件を追加
                if (!string.IsNullOrEmpty(nyuukaSyosaiID))
                {
                    // 入荷詳細IDを検索条件に追加
                    query = query.Where(od => od.ArDetailID.ToString() == nyuukaSyosaiID);
                }

                if (!string.IsNullOrEmpty(nyuukaID))
                {
                    //入荷IDを検索条件に追加
                    query = query.Where(od => od.ArID.ToString() == nyuukaID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrID.ToString() == syohinID);
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
                        入荷詳細ID = od.ArDetailID,
                        入荷ID = od.ArID,
                        商品ID = od.PrID,
                        数量 = od.ArQuantity,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToggleArrivalSelection()
        {
            try
            {
                isArrivalSelected = !isArrivalSelected;
                arrivalFlag = isArrivalSelected ? "←通常" : "詳細→";

                // CurrentStatusのモードを切り替える
                CurrentStatus.SetMode(isArrivalSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);

            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (arrivalFlag == "←通常")
                lastFocusedPanelID = 1;
            else if (arrivalFlag == "詳細→")
                lastFocusedPanelID = 2;
        }

        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleArrivalSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
            UpdateClose_kun(arrivalFlag);
        }

        private void UpdateFlagButtonText()
        {
            // b_FlagSelectorのテキストを現在の状態に合わせる
            b_FormSelector.Text = arrivalFlag;
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
                        TBNyuukaID.Text = "";
                    }
                    else
                    {
                        TBNyuukaID.Text = row.Cells["入荷ID"].Value?.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力 (null許可)
                    TBShopID.Text = row.Cells["営業所ID"].Value?.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value?.ToString() ?? string.Empty;
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value?.ToString() ?? string.Empty;
                    TBJyutyuID.Text = row.Cells["受注ID"].Value?.ToString() ?? string.Empty;
                    date.Value = row.Cells["入荷日"].Value != null ?
                                 Convert.ToDateTime(row.Cells["入荷日"].Value) :
                                 DateTime.Today;  // nullなら現在日付を設定
                    int flagValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["状態フラグ"].Value);
                    if (flagValue == 2)
                        NyuukaFlag.Checked = true;
                    else
                        NyuukaFlag.Checked = false;
                    flagValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["非表示フラグ"].Value);
                    if (flagValue == 1)
                        DelFlag.Checked = true;
                    else
                        DelFlag.Checked = false;
                    TBRiyuu.Text = row.Cells["備考"].Value?.ToString() ?? string.Empty;

                    UpdateTextBoxState(checkBoxSyain.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        TBNyukaSyosaiID.Text = "";
                    }
                    else
                    {
                        TBNyukaSyosaiID.Text = row.Cells["入荷詳細ID"].Value.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力
                    TBNyuukaIDS.Text = row.Cells["入荷ID"].Value.ToString() ?? string.Empty;
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString() ?? string.Empty;
                    TBSuryou.Text = row.Cells["数量"].Value.ToString() ?? string.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArrivalConfirm(int ArID)
        {
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言 
                var arrival = context.TArrivals.SingleOrDefault(o => o.ArID == ArID);

                if (arrival == null)
                {
                    throw new Exception("入荷IDが見つかりません。");
                }

                // 情報追加
                var newShipment = new TShipment
                {

                    EmID = null,  // 社員ID
                    SoID = arrival.SoID,  // 営業所ID    
                    ClID = arrival.ClID,  // 顧客ID    
                    OrID = arrival.OrID,  // 受注ID 
                    ShFinishDate = null, // 注文日    
                    ShStateFlag = 0,
                    ShFlag = 0
                };

                try
                {
                    context.TShipments.Add(newShipment);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(":500\n不明なエラーが発生しました。\n " + ex.Message);
                }

                // TArrivalDetailsの取得  
                var arrivalDetails = context.TArrivalDetails.Where(o => o.ArID == arrival.ArID).ToList();
                if (!arrivalDetails.Any())
                {
                    MessageBox.Show("指定された到着情報が見つかりません。発注処理を中止します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 複数の到着詳細を全て引き継ぐ
                foreach (var arrivalDetail in arrivalDetails)
                {
                    // 新しい出荷詳細の登録  
                    var newShipmentDetail = new TShipmentDetail
                    {
                        ShID = newShipment.ShID,
                        PrID = arrivalDetail.PrID ?? 0,  // null の場合、0 を代入
                        ShQuantity = arrivalDetail.ArQuantity ?? 0  // null の場合、0 を代入
                    };

                    if (newShipmentDetail.PrID == 0 || newShipmentDetail.ShQuantity == 0)
                    {
                        MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        context.TShipmentDetails.Add(newShipmentDetail);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(":201\n登録操作が失敗しました: " + ex.Message);
                    }
                }

                // すべての出荷詳細をデータベースに保存
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("すべての出荷詳細が登録されました。");
                }
                catch (Exception ex)
                {
                    throw new Exception(":201\n登録操作が失敗しました: " + ex.Message);
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
                ToggleArrivalSelection();
                UpdateFlagButtonText();
                lastFocusedPanelID = panelID; // 現在のパネルIDを更新
                UpdateClose_kun(arrivalFlag);
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
        private void TBNyuukaID_TextChanged(object sender, EventArgs e)
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

        private void TBKokyakuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBJyutyuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBNyukaSyosaiID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBNyuukaIDS_TextChanged(object sender, EventArgs e)
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
            TBNyuukaID.BackColor = SystemColors.Window;
            TBShopID.BackColor = SystemColors.Window;
            TBShainID.BackColor = SystemColors.Window;
            TBKokyakuID.BackColor = SystemColors.Window;
            TBJyutyuID.BackColor = SystemColors.Window;
            TBNyukaSyosaiID.BackColor = SystemColors.Window;
            TBNyuukaIDS.BackColor = SystemColors.Window;
            TBSyohinID.BackColor = SystemColors.Window;
            TBSuryou.BackColor = SystemColors.Window;
            return;

        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBNyuukaID.KeyPress += NumericTextBox_KeyPress;
            TBShopID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBKokyakuID.KeyPress += NumericTextBox_KeyPress;
            TBJyutyuID.KeyPress += NumericTextBox_KeyPress;
            TBNyukaSyosaiID.KeyPress += NumericTextBox_KeyPress;
            TBNyuukaIDS.KeyPress += NumericTextBox_KeyPress;
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
                int count = context.TArrivals.Count(order => order.ArStateFlag == 0 || order.ArStateFlag == null);
                if (count == 0)
                {
                    GlobalBadge badge = new GlobalBadge("");
                    b_arr.Refresh();
                }
            }
        }

        private void FlagCount()
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TShipments.Count(order => order.ShStateFlag == 0 || order.ShStateFlag == null);
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定
                    b_shi.Refresh();
                }
            }
        }


        private void Log_Arrival(int id)
        {
            string ModeFlag = "";
            if (arrivalFlag == "←通常")
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
                            Display = "入荷",
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
                        MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void UpdateClose_kun(string orderFlag)
        {
            if (orderFlag == "詳細→")
            {
                b_upd.Enabled = false;
                b_upd.BackColor = SystemColors.ControlDark; // 灰色に設定
                b_kakutei.Enabled = false;
                b_kakutei.BackColor = SystemColors.ControlDark;
            }
            else
            {
                b_upd.Enabled = true;
                b_upd.BackColor = Color.FromArgb(255, 224, 192); // 色コード255, 224, 192に設定
                b_kakutei.Enabled = true;
                b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
            }
        }
        private void UpdateClose_Chan()
        {
            b_upd.Enabled = true;
            b_upd.BackColor = Color.FromArgb(255, 224, 192); // 色コード255, 224, 192に設定
            b_kakutei.Enabled = true;
            b_kakutei.BackColor = Color.FromArgb(255, 192, 192);
        }



    }
}

