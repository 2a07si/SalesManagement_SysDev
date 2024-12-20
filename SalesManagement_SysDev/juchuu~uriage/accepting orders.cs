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
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using static SalesManagement_SysDev.Classまとめ.GlobalBadge;
using SalesManagement_SysDev.Entity;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        static int empID = Global.EmployeeID;　//ログイン時の社員ＩＤが処理画面の社員ＩＤのテキストボックスに自動的に反映される
        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定
        private ClassDataGridViewClearer dgvClearer;
        private GlobalBadge globalBadge;
        private Kuraberu_kun kuraberukun;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス
        private int lastFocusedPanelID = 1;
        private DateTime timestamp = DateTime.Now;
        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            formChanger = new ClassChangeForms(this);
            accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

            // パネル1とパネル2のコントロールにイベントを設定
            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel2, 2);  // パネル2の場合
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;

        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            // CBアクセス制御を設定
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_shi,
                b_sal,
                b_iss
            });
            TBShainID.Text = Global.EmployeeID.ToString();
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayOrders();
            DisplayOrderDetails();
            TBGoukeiKingaku.Enabled = false;
            TBGoukeiKingaku.BackColor = Color.Gray;
            CurrentStatus.RegistrationStatus(label2);
            SetupNumericOnlyTextBoxes();
            RegisterStatus();
            tbfalse();
            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
            UpdateTextBoxState(checkBoxSyain.Checked);
            TyumonFlag.Enabled = false;
            DateTime timestamp = DateTime.Now;

        }


        // メインメニューに戻る
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }
        // 各ボタンでの画面遷移
        private void b_ord_Click(object sender, EventArgs e) => formChanger.NavigateToOrderForm();
        private void b_arr_Click(object sender, EventArgs e) => formChanger.NavigateToArrivalForm();
        private void b_shi_Click(object sender, EventArgs e) => formChanger.NavigateToShippingForm();
        private void b_sal_Click(object sender, EventArgs e) => formChanger.NavigateToSalesForm();
        private void b_iss_Click(object sender, EventArgs e) => formChanger.NavigateToIssueForm();
        private void clear_Click(object sender, EventArgs e) => ClearText();

        private void ClearText()
        {
            TBJyutyuID.Text = "";
            TBShopID.Text = "";
            if (checkBoxSyain.Checked == false)
            {
                TBShainID.Text = "";
            }
            TBKokyakuID.Text = "";
            TBTantoName.Text = "";
            TyumonFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBJyutyuSyosaiID.Text = "";
            TBJyutyuIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            TBGoukeiKingaku.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            tbtrue();
            checkBoxDateFilter.Checked = false;
            checkBox_2.Checked = false;
            colorReset();
            ResetYellowBackgrounds(this);
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            PerformSearch();
            tbtrue();
            TyumonFlag.Enabled = true;
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
            TyumonFlag.Enabled = true;
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
            TyumonFlag.Enabled = false;
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
            TyumonFlag.Enabled = true;
        }

        private void ListStatus()
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplayOrders();
            DisplayOrderDetails();
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }

        private void tbfalse()
        {
            TBJyutyuID.Enabled = false;
            TBJyutyuSyosaiID.Enabled = false;
            TBJyutyuID.Text = "";
            TBJyutyuSyosaiID.Text = "";
            TBGoukeiKingaku.Text = "";
            TBJyutyuID.BackColor = Color.Gray;
            TBJyutyuSyosaiID.BackColor = Color.Gray;
            TBGoukeiKingaku.BackColor = Color.Gray;
        }
        private void tbtrue()
        {
            TBJyutyuID.Enabled = true;
            TBJyutyuSyosaiID.Enabled = true;
            TBJyutyuID.BackColor = Color.White;
            TBJyutyuSyosaiID.BackColor = Color.White;
        }
        private void b_kakutei_Click(object sender, EventArgs e)
        {
            countFlag();
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
                        HandleOrderDetailOperation();

                        break;
                    default:
                        MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HandleOrderOperation()
        {
            try
            {
                switch (CurrentStatus.CurrentStatusValue)
                {
                    case CurrentStatus.Status.更新:
                        UpdateOrder();
                        break;
                    case CurrentStatus.Status.登録:
                        RegisterOrder();
                        break;
                    case CurrentStatus.Status.一覧:
                        DisplayOrders();
                        DisplayOrderDetails();
                        break;
                    case CurrentStatus.Status.検索:
                        SearchOrders();
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

        private void HandleOrderDetailOperation()
        {
            try
            {
                switch (CurrentStatus.CurrentStatusValue)
                {
                    case CurrentStatus.Status.更新:
                        UpdateOrderDetails();
                        break;
                    case CurrentStatus.Status.登録:
                        RegisterOrderDetails();
                        break;
                    case CurrentStatus.Status.一覧:
                        DisplayOrderDetails();
                        DisplayOrders();
                        break;
                    case CurrentStatus.Status.検索:
                        SearchOrderDetails();
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
            MessageBox.Show($":204\n該当の{itemName}が見つかりません。（{itemName}: {itemId}）",
                            "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateOrder()
        {
            try
            {
                string jyutyuID = TBJyutyuID.Text;
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string tantoName = TBTantoName.Text;
                DateTime jyutyuDate = date.Value;
                bool tyumonFlag = TyumonFlag.Checked;
                bool delFlag = DelFlag.Checked;
                string riyuu = TBRiyuu.Text;

                // 条件精査（CheckTBValueメソッドを使用）
                if(CheckTBValue(TBJyutyuID, jyutyuID, "受注ID"))    return;
                if (CheckTBValue(TBShopID, shopID, "営業所ID"))       return;
                if (CheckTBValue(TBShainID, shainID, "社員ID"))     return; 
                if (CheckTBValue(TBKokyakuID, kokyakuID, "顧客ID")) return;


                // 社員IDが一致しない場合の処理
                if (shainID != GlobalEmp.EmployeeID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }

                // 受注日が未来日付の場合の確認
                if (jyutyuDate > DateTime.Now)
                {
                    var result = MessageBox.Show(
                        "受注日が未来を指していますが、よろしいですか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return; // 処理を中断
                    }
                }
                if (Kuraberu_kun.Kuraberu_chan("受注", "通常", "更新", int.Parse(jyutyuID), timestamp) == false)
                {  }

                using (var context = new SalesManagementContext())
                {
                    var order = context.TOrders.SingleOrDefault(o => o.OrID.ToString() == jyutyuID);
                    if (!int.TryParse(jyutyuID, out int jyutyu) || !context.TOrders.Any(s => s.OrID == jyutyu))
                    {
                        NotFound(TBJyutyuID, "受注ID", jyutyuID);
                        return;
                    }

                    if (!int.TryParse(shopID, out int eigyou) || !context.TOrders.Any(s => s.SoID == eigyou))
                    {
                        NotFound(TBShopID,"営業所ID", shopID);
                        return;
                    }
                    if (!int.TryParse(shainID, out int shain) || !context.TOrders.Any(s => s.EmID == shain))
                    {
                        NotFound(TBShainID,"社員ID", shainID);
                        return;
                    }
                    if (!int.TryParse(kokyakuID, out int kokyaku) || !context.TOrders.Any(s => s.ClID == kokyaku))
                    {
                        NotFound(TBKokyakuID,"顧客ID", kokyakuID);
                        return;
                    }

                    if (order != null)
                    {
                        order.SoID = int.Parse(shopID);
                        order.EmID = int.Parse(shainID);
                        order.ClID = int.Parse(kokyakuID);
                        order.ClCharge = tantoName;
                        order.OrDate = jyutyuDate;
                        order.OrStateFlag = tyumonFlag ? 2 : 0; // 適宜初期化  
                        order.OrFlag = delFlag ? 1 : 0;
                        order.OrHidden = riyuu;

                        // OrFlagの元の値を保存
                        var originalOrFlag = order.OrFlag;

                        // checkBox_2がチェックされている場合にOrFlagを1に設定
                        if (checkBox_2.Checked)
                        {
                            var orderDetailsExist = context.TOrderDetails.Any(od => od.OrID == order.OrID);
                            if (!orderDetailsExist)
                            {
                                NotFound(TBJyutyuID,"受注詳細ID", order.OrID.ToString());
                                return;
                            }
                            order.OrFlag = 1;
                            order.OrHidden = "受注確定処理済";
                        }

                        try
                        {
                            // 受注IDの重複チェック
                            bool isDuplicate = context.TChumons.Any(c => c.OrID == order.OrID);
                            if (isDuplicate)
                            {
                                MessageBox.Show(":203\n既存データとの重複が発生しました", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // 更新処理を中止
                            }


                            context.SaveChanges();

                            if (TyumonFlag.Checked)
                            {
                                try
                                {
                                    // AcceptionConfirm 実行
                                    AcceptionConfirm(int.Parse(jyutyuID));
                                }
                                catch (Exception ex)
                                {
                                    // AcceptionConfirm でのエラー処理
                                    throw new Exception(":500\n不明なエラーが発生しました。\n" + ex.Message);
                                }
                            }

                            Log_Accept(order.OrID);
                            MessageBox.Show("更新が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisplayOrders();
                            DisplayOrderDetails();
                            ResetYellowBackgrounds(this);
                        }
                        catch (Exception ex)
                        {
                            // エラーが発生した場合、OrFlag を元の状態に戻す
                            order.OrFlag = originalOrFlag;
                            context.SaveChanges(); // 元の状態に戻す変更を保存

                            MessageBox.Show(":500\n不明なエラーが発生しました。\n" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        NotFound(TBJyutyuID,"受注ID", jyutyuID);
                        TBJyutyuID.BackColor = Color.Yellow;
                        TBJyutyuID.Focus();
                    }

                }
            }
            catch (FormatException)
            {
                MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("受注の更新中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            countFlag();
            FlagCount();
        }

        private void RegisterOrder()
        {
            try
            {
                string shopID = TBShopID.Text;
                string shainID = TBShainID.Text;
                string kokyakuID = TBKokyakuID.Text;
                string tantoName = TBTantoName.Text;
                DateTime jyutyuDate = date.Value;
                string riyuu = TBRiyuu.Text;
                bool tyumonFlag = TyumonFlag.Checked;
                bool delFlag = DelFlag.Checked;

                if (CheckTBValue(TBShopID, shopID, "営業所ID"))       return;
                if (CheckTBValue(TBShainID, shainID, "社員ID"))     return;
                if (CheckTBValue(TBKokyakuID, kokyakuID, "顧客ID")) return;

                // 社員IDが一致しない場合の処理
                if (shainID != GlobalEmp.EmployeeID)
                {
                    MessageBox.Show("ログイン時に使用した社員IDを入力して下さい。");
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    return;
                }

                // 受注日が未来日付の場合の確認
                if (jyutyuDate > DateTime.Now)
                {
                    var result = MessageBox.Show(
                        "受注日が未来を指していますが、よろしいですか？",
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
                    if (!int.TryParse(shopID, out int eigyou) || !context.TOrders.Any(s => s.SoID == eigyou))
                    {
                        NotFound(TBShopID,"営業所ID", shopID);
                        return;
                    }
                    if (!int.TryParse(shainID, out int shain) || !context.MEmployees.Any(e => e.EmID == shain))
                    {
                        NotFound(TBShainID,"社員ID", shainID);
                        return;
                    }

                    // 新しい受注の登録
                    var newOrder = new TOrder
                    {
                        SoID = int.Parse(shopID),
                        EmID = int.Parse(shainID),
                        ClID = int.Parse(kokyakuID),
                        ClCharge = tantoName,
                        OrDate = jyutyuDate,
                        OrStateFlag = tyumonFlag ? 2 : 0,
                        OrFlag = delFlag ? 1 : 0,
                        OrHidden = riyuu
                    };
                    context.TOrders.Add(newOrder);
                    context.SaveChanges();

                    // 受注詳細が未登録の場合のエラーチェック
                    if (TyumonFlag.Checked)
                    {
                        var orderDetailExists = context.TOrderDetails.Any(d => d.OrID == newOrder.OrID);
                        if (!orderDetailExists)
                        {
                            MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        AcceptionConfirm(newOrder.OrID);
                    }

                    // 受注成功メッセージ
                    Log_Accept(newOrder.OrID);
                    MessageBox.Show("登録が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisplayOrders();
                    DisplayOrderDetails();
                    ResetYellowBackgrounds(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orders = checkBox_2.Checked
              ? (checkBox1.Checked
        ? context.TOrders.OrderByDescending(o => o.OrID).ToList() // 降順 
        : context.TOrders.OrderBy(o => o.OrID).ToList())          // 昇順 
    : (checkBox1.Checked
        ? context.TOrders
            .Where(o => o.OrFlag != 1 && o.OrStateFlag != 2)
            .OrderByDescending(o => o.OrID) // 条件に合致するものを降順で取得 
            .ToList()
        : context.TOrders
            .Where(o => o.OrFlag != 1 && o.OrStateFlag != 2)
            .OrderBy(o => o.OrID)          // 条件に合致するものを昇順で取得 
            .ToList());

                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        受注ID = o.OrID,
                        営業所ID = o.SoID,
                        社員ID = o.EmID,
                        顧客ID = o.ClID,
                        担当社員名 = o.ClCharge,
                        受注日 = o.OrDate,
                        状態フラグ = o.OrStateFlag,
                        非表示フラグ = o.OrFlag,
                        備考 = o.OrHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 各テキストボックスの値を取得   
                    var jyutyuID = TBJyutyuID.Text.Trim();       // 受注ID   
                    var shopID = TBShopID.Text.Trim();           // 営業所ID   
                    var shainID = TBShainID.Text.Trim();         // 社員ID   
                    var kokyakuID = TBKokyakuID.Text.Trim();     // 顧客ID   
                    var tantoName = TBTantoName.Text.Trim();     // 担当者   
                    var riyuu = TBRiyuu.Text.Trim();            // 理由

                    // 基本的なクエリ   
                    var query = context.TOrders.AsQueryable();

                    // 受注IDを検索条件に追加   
                    if (!string.IsNullOrEmpty(jyutyuID) && int.TryParse(jyutyuID, out int parsedJyutyuID))
                    {
                        query = query.Where(o => o.OrID == parsedJyutyuID);
                    }

                    // 営業所IDを検索条件に追加   
                    if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                    {
                        query = query.Where(o => o.SoID == parsedShopID);
                    }

                    // 社員IDを検索条件に追加   
                    if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                    {
                        query = query.Where(o => o.EmID == parsedShainID);
                    }

                    // 顧客IDを検索条件に追加   
                    if (!string.IsNullOrEmpty(kokyakuID) && int.TryParse(kokyakuID, out int parsedKokyakuID))
                    {
                        query = query.Where(o => o.ClID == parsedKokyakuID);
                    }

                    // 担当者名を検索条件に追加   
                    if (!string.IsNullOrEmpty(tantoName))
                    {
                        query = query.Where(o => o.ClCharge.Contains(tantoName));
                    }

                    // 理由を検索条件に追加   
                    if (!string.IsNullOrEmpty(riyuu))
                    {
                        query = query.Where(o => o.OrHidden.Contains(riyuu)); // Reasonは仮のカラム名
                    }

                    // TyumonFlag(チェックボックス)がチェックされている場合の条件
                    if (TyumonFlag.Checked)
                    {
                        query = query.Where(o => o.OrStateFlag == 2);
                    }
                    else
                    {
                        query = query.Where(o => o.OrStateFlag == 0);
                    }

                    // DelFlag(チェックボックス)がチェックされている場合の条件
                    if (DelFlag.Checked)
                    {
                        query = query.Where(o => o.OrFlag == 1);
                    }
                    else
                    {
                        query = query.Where(o => o.OrFlag == 0);
                    }

                    // 受注日を検索条件に追加（チェックボックスがチェックされている場合）   
                    if (checkBoxDateFilter.Checked)
                    {
                        DateTime jyutyuDate = date.Value; // DateTimePickerからの値  
                        query = query.Where(o => o.OrDate.Date == jyutyuDate.Date);
                    }


                    // 結果を取得   
                    var orders = query.ToList();

                    if (orders.Any())
                    {
                        // dataGridView1 に結果を表示   
                        dataGridView1.DataSource = orders.Select(order => new
                        {
                            受注ID = order.OrID,
                            営業所ID = order.SoID,
                            社員ID = order.EmID,
                            顧客ID = order.ClID,
                            担当社員名 = order.ClCharge,
                            受注日 = order.OrDate,
                            注文フラグ = TyumonFlag.Checked ? 2 : 0,
                            削除フラグ = DelFlag.Checked ? 1 : 0
                        }).ToList();
                    }
                    else
                    {
                        MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n" + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateOrderDetails()
        {
            try
            {
                string jyutyuSyosaiID = TBJyutyuSyosaiID.Text;
                string jyutyuID = TBJyutyuIDS.Text;
                string syohinID = TBSyohinID.Text;
                string suryou = TBSuryou.Text;

                // 必須入力チェック
                if (CheckTBValue(TBJyutyuSyosaiID, jyutyuSyosaiID, "受注詳細ID")) return;
                if (CheckTBValue(TBJyutyuIDS, jyutyuID, "受注ID")) return;
                if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
                if (CheckTBValue(TBSuryou, suryou, "数量")) return;

                if (!Kuraberu_kun.Kuraberu_chan("受注", "詳細", "更新", int.Parse(jyutyuSyosaiID), timestamp))
                    return;

                using (var context = new SalesManagementContext())
                {
                    // データベース項目の存在確認
                    if (!int.TryParse(jyutyuSyosaiID, out int detailId) || !context.TOrderDetails.Any(s => s.OrDetailID == detailId))
                    {
                        NotFound(TBJyutyuSyosaiID, "受注詳細ID", jyutyuSyosaiID);
                        return;
                    }

                    if (!int.TryParse(jyutyuID, out int jyutyu) || !context.TOrders.Any(s => s.OrID == jyutyu))
                    {
                        NotFound(TBJyutyuIDS, "受注ID", jyutyuID);
                        return;
                    }

                    if (!int.TryParse(syohinID, out int syohin) || !context.MProducts.Any(s => s.PrID == syohin))
                    {
                        NotFound(TBSyohinID, "商品ID", syohinID);
                        return;
                    }

                    // 他のレコードに同一の受注IDと商品IDが存在するかチェック（現在のレコードを除く）
                    if (context.TOrderDetails.Any(od => od.OrID == jyutyu && od.PrID == syohin && od.OrDetailID != detailId))
                    {
                        MessageBox.Show(":203\n同一受注ID内に同じ商品IDがすでに登録されています。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TBSyohinID.BackColor = Color.Yellow;
                        TBSyohinID.Focus();
                        return;
                    }

                    // データ更新処理
                    var orderDetail = context.TOrderDetails.SingleOrDefault(od => od.OrDetailID == detailId);
                    if (orderDetail != null)
                    {
                        orderDetail.OrID = jyutyu;
                        orderDetail.PrID = syohin;
                        orderDetail.OrQuantity = int.Parse(suryou);

                        context.SaveChanges();
                        MessageBox.Show("受注詳細の更新が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisplayOrderDetails();
                        Log_Accept(orderDetail.OrDetailID);
                        ResetYellowBackgrounds(this);
                        MessageBox.Show("ログ登録完了");
                    }
                    else
                    {
                        MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RegisterOrderDetails()
        {
            try
            {
                string jyutyuID = TBJyutyuIDS.Text;
                string syohinID = TBSyohinID.Text;
                string suryou = TBSuryou.Text;
                string goukeiKingaku = TBGoukeiKingaku.Text;

                // 必須入力チェック
                if (CheckTBValue(TBJyutyuIDS, jyutyuID, "受注ID")) return;
                if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
                if (CheckTBValue(TBSuryou, suryou, "数量")) return;

                using (var context = new SalesManagementContext())
                {
                    // データベース項目の存在確認
                    if (!int.TryParse(jyutyuID, out int jyutyu) || !context.TOrders.Any(s => s.OrID == jyutyu))
                    {
                        NotFound(TBJyutyuIDS, "受注ID", jyutyuID);
                        return;
                    }

                    if (!int.TryParse(syohinID, out int syohin) || !context.MProducts.Any(s => s.PrID == syohin))
                    {
                        NotFound(TBSyohinID, "商品ID", syohinID);
                        return;
                    }

                    // 同一受注ID内に同じ商品IDが含まれるかチェック
                    if (context.TOrderDetails.Any(od => od.OrID == jyutyu && od.PrID == syohin))
                    {
                        MessageBox.Show(":203\n同一受注ID内に同じ商品IDがすでに登録されています。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TBSyohinID.BackColor = Color.Yellow;
                        TBSyohinID.Focus();
                        return;
                    }

                    var newOrderDetail = new TOrderDetail
                    {
                        OrID = jyutyu,
                        PrID = syohin,
                        OrQuantity = int.Parse(suryou)
                    };

                    // 合計金額の計算
                    if (string.IsNullOrWhiteSpace(goukeiKingaku))
                    {
                        var product = context.MProducts.SingleOrDefault(p => p.PrID == newOrderDetail.PrID);
                        if (product != null)
                        {
                            newOrderDetail.OrTotalPrice = product.Price * newOrderDetail.OrQuantity;
                        }
                        else
                        {
                            NotFound(TBSyohinID,"商品ID", syohinID);
                            return;
                        }
                    }
                    else
                    {
                        newOrderDetail.OrTotalPrice = decimal.Parse(goukeiKingaku);
                    }

                    // 新しい注文詳細の追加
                    context.TOrderDetails.Add(newOrderDetail);
                    context.SaveChanges();

                    // ログ登録と詳細表示
                    Log_Accept(newOrderDetail.OrDetailID);
                    DisplayOrderDetails();

                    // 確認メッセージ
                    DialogResult result = MessageBox.Show("受注詳細の登録が完了しました。\n受注処理を確定させますか？",
                                                          "登録完了", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    // Yes/Noの処理分岐
                    if (result == DialogResult.Yes)
                    {
                        UpdateOrderAccept(jyutyuID);
                    }

                    // 入力フィールドの背景色をリセット
                    ResetYellowBackgrounds(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(":102\n入力形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayOrderDetails()
        {
            try
            {

                using (var context = new SalesManagementContext())
                {
                    // 受注詳細のリストを取得（checkBox1の状態に応じて並べ替え）
                    var OrderDetails = checkBox1.Checked
                        ? context.TOrderDetails.OrderByDescending(od => od.OrID).ToList() // 降順
                        : context.TOrderDetails.OrderBy(od => od.OrID).ToList();          // 昇順

                    // 受注詳細の表示条件を設定（OrFlagが1またはOrStateFlagが2の受注IDを持つ受注詳細は非表示）
                    var visibleOrderDetails = checkBox_2.Checked
                        ? OrderDetails // チェックされていれば全て表示（並び替え済み）
                        : OrderDetails.Where(od =>
                        {
                            var Order = context.TOrders.FirstOrDefault(o => o.OrID == od.OrID);

                            return Order == null || (Order.OrFlag != 1 && Order.OrStateFlag != 2);
                        }).ToList();

                    // データグリッドに表示
                    dataGridView2.DataSource = visibleOrderDetails.Select(od => new
                    {
                        受注詳細ID = od.OrDetailID,
                        受注ID = od.OrID,
                        商品ID = od.PrID,
                        数量 = od.OrQuantity.ToString("N0"),
                        合計金額 = od.OrTotalPrice.ToString("N0")  // 3桁区切り 
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchOrderDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 各テキストボックスの値を取得 
                    var jyutyuSyosaiID = TBJyutyuSyosaiID.Text;
                    var jyutyuID = TBJyutyuIDS.Text;
                    var syohinID = TBSyohinID.Text;
                    var suryou = TBSuryou.Text;
                    var goukeiKingaku = TBGoukeiKingaku.Text;

                    // 基本的なクエリ 
                    var query = context.TOrderDetails.AsQueryable();

                    // 各条件を追加 
                    if (!string.IsNullOrEmpty(jyutyuSyosaiID))
                    {
                        // 受注詳細IDを検索条件に追加 
                        query = query.Where(od => od.OrDetailID.ToString() == jyutyuSyosaiID);
                    }

                    if (!string.IsNullOrEmpty(jyutyuID))
                    {
                        // 受注IDを検索条件に追加 
                        query = query.Where(od => od.OrID.ToString() == jyutyuID);
                    }

                    if (!string.IsNullOrEmpty(syohinID) && int.TryParse(syohinID, out int productID))
                    {
                        // 商品IDを検索条件に追加 
                        query = query.Where(od => od.PrID == productID);
                    }

                    if (!string.IsNullOrEmpty(suryou) && int.TryParse(suryou, out int quantity))
                    {
                        // 数量を検索条件に追加 
                        query = query.Where(od => od.OrQuantity == quantity);
                    }

                    if (!string.IsNullOrEmpty(goukeiKingaku) && decimal.TryParse(goukeiKingaku, out decimal totalPrice))
                    {
                        // 合計金額を検索条件に追加 
                        query = query.Where(od => od.OrTotalPrice == totalPrice);
                    }

                    // 結果を取得 
                    var orderDetails = query.ToList();

                    if (orderDetails.Any())
                    {
                        dataGridView2.DataSource = orderDetails.Select(od => new
                        {
                            受注詳細ID = od.OrDetailID,
                            受注ID = od.OrID,
                            商品ID = od.PrID,
                            数量 = od.OrQuantity,
                            合計金額 = od.OrTotalPrice
                        }).ToList();
                    }
                    else
                    {
                        MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            if (orderFlag == "詳細→")
                lastFocusedPanelID = 2;
        }

        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            try
            {
                // 状態を切り替える処理 
                ToggleOrderSelection();

                // b_FormSelectorのテキストを現在の状態に更新 
                UpdateFlagButtonText();


            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFlagButtonText()
        {
            try
            {
                // b_FlagSelectorのテキストを現在の状態に合わせる 
                b_FormSelector.Text = orderFlag;
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        TBJyutyuID.Text = "";
                    }
                    else
                    {
                        TBJyutyuID.Text = row.Cells["受注ID"].Value?.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力 (null許可)

                    TBShopID.Text = row.Cells["営業所ID"].Value?.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value?.ToString() ?? string.Empty;
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value?.ToString() ?? string.Empty;
                    TBTantoName.Text = row.Cells["担当社員名"].Value?.ToString() ?? string.Empty;
                    date.Value = row.Cells["受注日"].Value != null ?
                                 Convert.ToDateTime(row.Cells["受注日"].Value) :
                                 DateTime.Today;  // nullなら現在日付を設定 

                    // 状態フラグと非表示フラグを取得 (null許可)
                    int orderFlag = row.Cells["状態フラグ"].Value != null ?
                                    Convert.ToInt32(row.Cells["状態フラグ"].Value) :
                                    0; // nullなら0を設定
                    int delFlag = row.Cells["非表示フラグ"].Value != null ?
                                  Convert.ToInt32(row.Cells["非表示フラグ"].Value) :
                                  0; // nullなら0を設定
                    UpdateTextBoxState(checkBoxSyain.Checked);
                    // チェックボックスの状態を設定 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        TBJyutyuSyosaiID.Text = "";
                        TBGoukeiKingaku.Text = "";
                    }
                    else
                    {
                        TBJyutyuSyosaiID.Text = row.Cells["受注詳細ID"].Value?.ToString() ?? string.Empty;
                        TBGoukeiKingaku.Text = "";
                    }
                    // 各テキストボックスにデータを入力 (null許可)
                    TBJyutyuIDS.Text = row.Cells["受注ID"].Value?.ToString() ?? string.Empty;
                    TBSyohinID.Text = row.Cells["商品ID"].Value?.ToString() ?? string.Empty;
                    TBSuryou.Text = row.Cells["数量"].Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 注文に登録する部分
        private void AcceptionConfirm(int orderID)
        {
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言
                var order = context.TOrders.SingleOrDefault(o => o.OrID == orderID);

                if (order == null)
                {
                    throw new Exception(":204\n該当の項目が見つかりません。");
                }

                // TChumon テーブル内で OrID が既に存在するか確認
                bool isDuplicate = context.TChumons.Any(c => c.OrID == orderID);
                if (isDuplicate)
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました");
                    return;
                }

                // 注文情報を TChumon に追加
                var newChumon = new TChumon
                {
                    SoID = order.SoID,  // 営業所ID     
                    EmID = null,
                    ClID = order.ClID,  // 顧客ID     
                    OrID = order.OrID,  // 受注ID  
                    ChDate = null, // 注文日     
                    ChStateFlag = 0,
                    ChFlag = 0
                };

                try
                {
                    context.TChumons.Add(newChumon);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(":201\n登録操作が失敗しました: " + ex.Message);
                }

                // 受注詳細情報を TChumonDetail に追加 
                var orderDetails = context.TOrderDetails.Where(o => o.OrID == orderID).ToList();

                if (!orderDetails.Any())
                {
                    throw new Exception(":204\n該当の項目が見つかりません。");
                }

                foreach (var detail in orderDetails)
                {
                    var newChumonDetail = new TChumonDetail
                    {
                        ChID = newChumon.ChID,
                        PrID = detail.PrID,
                        ChQuantity = detail.OrQuantity
                    };

                    try
                    {
                        context.TChumonDetails.Add(newChumonDetail);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(":201\n登録操作が失敗しました: " + ex.Message);
                    }
                }

                // 一括保存
                try
                {
                    context.SaveChanges();
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
                ToggleOrderSelection();
                UpdateFlagButtonText();
                lastFocusedPanelID = panelID; // 現在のパネルIDを更新
            }
        }
        //↓以下北島匙投げゾーン


        private void LimitTextLength(System.Windows.Forms.TextBox textBox, int maxLength)
        {
            if (textBox.Text.Length > maxLength)
            {
                // 文字数制限を超えたら、超過部分を切り捨てる
                textBox.Text = textBox.Text.Substring(0, maxLength);
                textBox.SelectionStart = maxLength;  // カーソル位置を末尾に設定
            }
        }
        private void TBJyutyuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 6);
        }

        private void TBShopID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 2);
        }

        private void TBShainID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 6);  // textBox1の制限を50文字に設定

        }

        private void TBKokyakuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 6);  // textBox1の制限を50文字に設定

        }

        private void TBTantoName_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 50);  // textBox1の制限を50文字に設定

        }

        private void TBJyutyuSyosaiID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 6);
        }

        private void TBJyutyuIDS_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 6);
        }

        private void TBSyohinID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 6);
        }

        private void TBSuryou_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 4);
        }

        private void TBGoukeiKingaku_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as System.Windows.Forms.TextBox, 10);
        }

        private void colorReset()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    tbfalse();
                    break;
                default:
                    TBJyutyuID.BackColor = SystemColors.Window;
                    TBShopID.BackColor = SystemColors.Window;
                    TBShainID.BackColor = SystemColors.Window;
                    TBKokyakuID.BackColor = SystemColors.Window;
                    TBTantoName.BackColor = SystemColors.Window;
                    TBJyutyuSyosaiID.BackColor = SystemColors.Window;
                    TBJyutyuIDS.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBSuryou.BackColor = SystemColors.Window;
                    TBGoukeiKingaku.BackColor = Color.Gray;
                    break;

            }
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


        // 数値のみを許可するテキストボックスの初期設定
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBJyutyuID.KeyPress += NumericTextBox_KeyPress;
            TBKokyakuID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBShopID.KeyPress += NumericTextBox_KeyPress;
            TBJyutyuIDS.KeyPress += NumericTextBox_KeyPress;
            TBJyutyuSyosaiID.KeyPress += NumericTextBox_KeyPress;
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

        private void b_acc_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TOrders.Count(order => order.OrFlag == 0 || order.OrFlag == null);
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
                else
                {
                    GlobalBadge badge = new GlobalBadge(""); // 空のバッジを設定
                    badge.pinpoint(e, button);
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
                else
                {
                    GlobalBadge badge = new GlobalBadge(""); // 空のバッジを設定
                    badge.pinpoint(e, button);
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
                else
                {
                    GlobalBadge badge = new GlobalBadge("");
                    badge.pinpoint(e, button);
                }
            }
        }

        private void b_shi_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TShipments.Count(order => order.ShStateFlag == 0 || order.ShStateFlag == null); // 通知数を指定
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
                else
                {
                    GlobalBadge badge = new GlobalBadge("");
                    badge.pinpoint(e, button);
                }
            }
        }

        private void countFlag()
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TOrders.Count(order => order.OrStateFlag == 0 || order.OrStateFlag == null);
                if (count == 0)
                {
                    GlobalBadge badge = new GlobalBadge("");
                    b_acc.Refresh();
                }
            }
        }

        private void FlagCount()
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TChumons.Count(order => order.ChStateFlag == 0 || order.ChStateFlag == null);
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" ");
                    b_ord.Refresh();
                }
            }
        }
        private void Log_Accept(int id)
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
                            Display = "受注",
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
                throw new Exception(":201\n登録操作が失敗しました" + ex.Message);
            }
        }


        private void UpdateOrderAccept(string jyutyuID)
        {
            // 状態を切り替える処理 
            ToggleOrderSelection();

            // b_FormSelectorのテキストを現在の状態に更新 
            UpdateFlagButtonText();

            label2.Text = "更新";
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var order = context.TOrders.SingleOrDefault(o => o.OrID.ToString() == jyutyuID);
                    if (!int.TryParse(jyutyuID, out int jyutyu) || !context.TOrders.Any(s => s.OrID == jyutyu))
                    {
                        MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TBJyutyuID.BackColor = Color.Yellow;
                        TBJyutyuID.Focus();
                        return;
                    }

                    if (order != null)
                    {
                        order.OrStateFlag = 2;

                        // checkBox_2がチェックされている場合にOrFlagを1に設定
                        if (order.OrStateFlag == 2)
                        {
                            order.OrFlag = 1;
                            order.OrHidden = "受注確定処理済";
                        }

                        try
                        {
                            context.SaveChanges();

                            if (order.OrStateFlag == 2)
                            {
                                // AcceptionConfirm実行
                                AcceptionConfirm(int.Parse(jyutyuID));
                            }
                            Log_Accept(order.OrID);
                            MessageBox.Show("更新が成功しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisplayOrders();
                            DisplayOrderDetails();
                        }
                        catch (Exception ex)
                        {
                            context.SaveChanges(); // 元の状態に戻す変更を保存

                            MessageBox.Show($":202\n更新操作が失敗しました: {ex.Message}", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(":204\n該当の項目が存在しません", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("入力された値の形式が正しくありません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            countFlag();
            FlagCount();
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
                TBShainID.Text = GlobalEmp.EmployeeID;  // テキストを設定
                TBShainID.Enabled = false; // 無効化
            }
            else
            {
                TBShainID.Enabled = true; // 有効化
                TBShainID.Text = "";
            }

            // フラグをオフに戻す
            isProgrammaticChange = false;
        }

        private bool CheckNumeric(string text)
        {
            bool flg;

            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(text))
                flg = false;
            else
                flg = true;

            return flg;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBoxSyain_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
