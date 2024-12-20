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
    public partial class shipping : Form
    {
        string empID = GlobalEmp.EmployeeID;
        private bool isShippingSelected = true; // 初期状態を受注(TOrder)に設定
        private string shippingFlag = "←通常"; // 初期状態を「注文」に設定

        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager;

        private int lastFocusedPanelID = 1;
        private DateTime timestamp = DateTime.Now;
        // コンストラクターでmainFormを引数として受け取る 
        public shipping(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            //this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(shipping_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

            // パネル1とパネル2のコントロールにイベントを設定
            AddControlEventHandlers(panel1, 1);  // パネル1の場合
            AddControlEventHandlers(panel3, 2);  // パネル2の場合
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;


        }

        private void shipping_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベルの初期化
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_acc,
                b_sal,
                b_iss
            });
            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayShipping();
            DisplayShippingDetails();
            b_reg.Enabled = false;
            b_reg.BackColor = SystemColors.ControlDark; // 灰色に設定
            SetupNumericOnlyTextBoxes();
            CurrentStatus.UpDateStatus(label2);
            checkBoxSyain.CheckedChanged += checkBoxSyain_CheckedChanged;
            UpdateTextBoxState(checkBoxSyain.Checked);

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

        private void b_iss_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm();//出庫管理画面に遷移
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移 
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
            DisplayShipping();
            DisplayShippingDetails();
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            tbtrue();
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplayShipping();
            DisplayShippingDetails();
            tbtrue();

        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            tbtrue();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBSyukkaID.Text = "";
            TBKokyakuID.Text = "";
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

        private void tbfalse()
        {
            TBSyukkaID.Enabled = false;
            TBSyukkaSyosaiID.Enabled = false;
            TBSyukkaID.BackColor = Color.Gray;
            TBSyukkaSyosaiID.BackColor = Color.Gray;
            TBSyukkaID.Text = "";
            TBSyukkaSyosaiID.Text = "";
        }

        private void tbtrue()
        {
            TBSyukkaID.Enabled = true;
            TBSyukkaSyosaiID.Enabled = true;
            TBSyukkaID.BackColor = Color.White;
            TBSyukkaSyosaiID.BackColor = Color.White;
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
                        HandleShippingOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        colorReset();
                        HandleShippingDetailOperation();
                        break;
                    default:

                        MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void UpdateShipping()
        {
            string SyukkaID = TBSyukkaID.Text;
            string JyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string shukkaID = TBSyukkaID.Text;
            bool delFlag = KanriFlag.Checked;
            DateTime shukkaDate = date.Value;
            bool shipFlag = SyukkaFlag.Checked;
            string riyuu = TBRiyuu.Text;

            if (TBSyukkaID.Text == "")
            {
                TBSyukkaID.BackColor = Color.Yellow;
                TBSyukkaID.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShopID.Text == "")
            {
                TBShopID.BackColor = Color.Yellow;
                TBShopID.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShainID.Text == "")
            {
                TBShainID.BackColor = Color.Yellow;
                TBShainID.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBKokyakuID.Text == "")
            {
                TBKokyakuID.BackColor = Color.Yellow;
                TBKokyakuID.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBJyutyuID.Text == "")
            {
                TBJyutyuID.BackColor = Color.Yellow;
                TBJyutyuID.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Kuraberu_kun.Kuraberu_chan("出荷", "通常", "更新", int.Parse(SyukkaID), timestamp) == false)
            { return; }

            using (var context = new SalesManagementContext())
            {
                int ship;
                if (!int.TryParse(SyukkaID, out ship) || !context.TShipments.Any(s => s.ShID == ship))
                {
                    MessageBox.Show("出荷IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBSyukkaID.BackColor = Color.Yellow;
                    return;
                }

                int shop;
                if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBShopID.BackColor = Color.Yellow;
                    return;
                }

                // 社員IDが存在するか確認
                int employeeID;
                if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBShainID.BackColor = Color.Yellow;
                    return;
                }

                int kokyaku;
                if (!int.TryParse(kokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBKokyakuID.BackColor = Color.Yellow;
                    return;
                }

                // 受注IDが存在するか確認
                int juchu;
                if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    MessageBox.Show("受注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBJyutyuID.BackColor = Color.Yellow;
                    return;
                }

                var shipping = context.TShipments.SingleOrDefault(sh => sh.ShID.ToString() == shukkaID);

                if (shipping != null)
                {
                    shipping.SoID = int.Parse(shopID);
                    shipping.EmID = int.Parse(shainID);
                    shipping.ClID = int.Parse(kokyakuID);
                    shipping.OrID = int.Parse(JyutyuID);
                    shipping.ShFinishDate = shukkaDate;
                    shipping.ShFlag = delFlag ? 1 : 0;
                    shipping.ShStateFlag = shipFlag ? 2 : 0;
                    shipping.ShHidden = riyuu;

                    // 出荷フラグがチェックされている場合、出荷詳細の確認を行う
                    if (shipFlag)
                    {
                        // 受注IDの重複チェック
                        bool isDuplicate = context.TSales.Any(c => c.OrID == shipping.OrID);
                        if (isDuplicate)
                        {
                            MessageBox.Show($":203\n既存データとの重複が発生しました。更新を中止します。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // 更新処理を中止
                        }
                        // 出荷詳細が存在するか確認
                        var shippingDetailsExist = context.TShipmentDetails
                            .Any(sd => sd.ShID == shipping.ShID); // ShID が一致する出荷詳細が存在するか確認
                        if (!shippingDetailsExist)
                        {
                            // 出荷詳細が存在しない場合はエラーメッセージを表示
                            MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断
                        }

                        context.SaveChanges();
                        shipping.ShFlag = 1;
                        shipping.ShHidden = "出荷確定処理済";
                        // 出荷詳細が存在する場合、出荷確認処理を実行
                        ShippingConfirm(shipping.ShID);
                    }

                    // 更新を保存
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        DisplayShipping(); // 更新後に出荷情報を再表示
                        DisplayShippingDetails();
                        ResetYellowBackgrounds(this);
                        Log_Shipping(shipping.SoID);
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
                            MessageBox.Show(":201\n登録操作が失敗しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // その他のエラーに対処する
                        MessageBox.Show($":500\n不明なエラーが発生しました。\nが発生しました: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            countFlag();
        }

        private void RegisterShipping()
        {
            string JyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string shukkaID = TBSyukkaID.Text;
            bool delFlag = SyukkaFlag.Checked;
            DateTime shukkaDate = date.Value;
            bool shipFlag = KanriFlag.Checked;
            string riyuu = TBRiyuu.Text;

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (TBKokyakuID.Text == "")
                {
                    TBKokyakuID.BackColor = Color.Yellow;
                    TBKokyakuID.Focus();
                    MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBShainID.Text == "")
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBShopID.Text == "")
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBJyutyuID.Text == "")
                {
                    TBJyutyuID.BackColor = Color.Yellow;
                    TBJyutyuID.Focus();
                    MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBShopID.BackColor = Color.Yellow;
                    return;
                }

                // 社員IDが存在するか確認
                int employeeID;
                if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBShainID.BackColor = Color.Yellow;
                    return;
                }

                int kokyaku;
                if (!int.TryParse(kokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBKokyakuID.BackColor = Color.Yellow;
                    return;
                }

                // 受注IDが存在するか確認
                int juchu;
                if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
                    MessageBox.Show("受注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TBJyutyuID.BackColor = Color.Yellow;
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

                // 出荷情報が既に存在するか確認
                var shipping = context.TShipments.SingleOrDefault(o => o.ShID.ToString() == shukkaID);
                if (shipping == null)
                {
                    try
                    {
                        // 新しい出荷情報を作成
                        var newShipping = new TShipment
                        {
                            SoID = int.Parse(shopID),                  // 営業所ID
                            EmID = int.Parse(shainID),                 // 社員ID
                            ClID = int.Parse(kokyakuID),               // 顧客ID
                            OrID = int.Parse(JyutyuID),                // 受注ID
                            ShFinishDate = shukkaDate,                 // 出荷日
                            ShFlag = shipFlag ? 1 : 0,                 // 管理フラグ
                            ShStateFlag = shipFlag ? 2 : 0,            // 出荷状態フラグ
                            ShHidden = riyuu                          // 備考
                        };

                        // 出荷情報をコンテキストに追加
                        context.TShipments.Add(newShipping);

                        // 出荷詳細が存在するか確認
                        var shipmentDetails = context.TShipmentDetails
                                                     .Where(sd => sd.ShID == newShipping.ShID)
                                                     .ToList();

                        if (shipmentDetails.Count == 0)
                        {
                            MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 出荷詳細がない場合は処理を中止
                        }

                        // データを保存
                        context.SaveChanges();
                        MessageBox.Show("登録が成功しました。");
                        Log_Shipping(newShipping.ShID);
                        ResetYellowBackgrounds(this);

                        // 出荷情報が登録されたら、出荷確認を行う
                        if (shipFlag)
                        {
                            ShippingConfirm(int.Parse(shukkaID)); // 出荷確認処理
                        }

                        DisplayShipping(); // 出荷リストを更新
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
                            MessageBox.Show(":201\n登録操作が失敗しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // その他のエラーに対処する
                        MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DisplayShipping()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての出荷を表示
                    var shipping = checkBox_2.Checked
                        ? (checkBox1.Checked
                            ? context.TShipments.OrderByDescending(s => s.ShID).ToList() // 降順
                            : context.TShipments.OrderBy(s => s.ShID).ToList())          // 昇順
                        : (checkBox1.Checked
                            ? context.TShipments
                                .Where(s => s.ShFlag != 1 && s.ShStateFlag != 2)
                                .OrderByDescending(s => s.ShID) // 条件に合致するものを降順で取得
                                .ToList()
                            : context.TShipments
                                .Where(s => s.ShFlag != 1 && s.ShStateFlag != 2)
                                .OrderBy(s => s.ShID)          // 条件に合致するものを昇順で取得
                                .ToList());

                    dataGridView1.DataSource = shipping.Select(sh => new
                    {
                        出荷ID = sh.ShID,
                        顧客ID = sh.ClID,
                        社員ID = sh.EmID,
                        営業所ID = sh.SoID,
                        受注ID = sh.OrID,
                        出荷終了日 = sh.ShFinishDate,
                        出荷フラグ = sh.ShFlag,
                        非表示フラグ = sh.ShHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchShipping()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得   
                var JyutyuID = TBJyutyuID.Text.Trim();       // 受注ID   
                var shopID = TBShopID.Text.Trim();           // 営業所ID   
                var shainID = TBShainID.Text.Trim();         // 社員ID   
                var kokyakuID = TBKokyakuID.Text.Trim();     // 顧客ID   
                var shukkaID = TBSyukkaID.Text.Trim();       // 出荷ID  
                var riyuu = TBRiyuu.Text.Trim();             // 理由

                // 基本的なクエリ   
                var query = context.TShipments.AsQueryable();

                // 受注IDを検索条件に追加   
                if (!string.IsNullOrEmpty(JyutyuID) && int.TryParse(JyutyuID, out int parsedJyutyuID))
                {
                    query = query.Where(sh => sh.OrID == parsedJyutyuID);
                }

                // 営業所IDを検索条件に追加   
                if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                {
                    query = query.Where(sh => sh.SoID == parsedShopID);
                }

                // 社員IDを検索条件に追加   
                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(sh => sh.EmID == parsedShainID);
                }

                // 顧客IDを検索条件に追加   
                if (!string.IsNullOrEmpty(kokyakuID) && int.TryParse(kokyakuID, out int parsedKokyakuID))
                {
                    query = query.Where(sh => sh.ClID == parsedKokyakuID);
                }

                // 出荷IDを検索条件に追加   
                if (!string.IsNullOrEmpty(shukkaID) && int.TryParse(shukkaID, out int parsedShukkaID))
                {
                    query = query.Where(sh => sh.ShID == parsedShukkaID);
                }

                // 理由を検索条件に追加   
                if (!string.IsNullOrEmpty(riyuu))
                {
                    query = query.Where(sh => sh.ShHidden.Contains(riyuu));
                }

                // 出荷フラグ(SyukkoFlag)の検索条件を追加   
                if (SyukkaFlag.Checked)
                {
                    query = query.Where(sh => sh.ShStateFlag == 1); // 出荷済み
                }
                else
                {
                    query = query.Where(sh => sh.ShStateFlag == 0); // 出荷未完了
                }

                // 削除フラグ(DelFlag)の検索条件を追加   
                if (KanriFlag.Checked)
                {
                    query = query.Where(sh => sh.ShFlag == 1); // 削除済み
                }
                else
                {
                    query = query.Where(sh => sh.ShFlag == 0); // 有効
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
                        出荷ID = sh.ShID,
                        顧客ID = sh.ClID,
                        社員ID = sh.EmID,
                        営業所ID = sh.SoID,
                        受注ID = sh.OrID,
                        出荷終了日 = sh.ShFinishDate,
                        出荷フラグ = sh.ShStateFlag,  // 出荷フラグの表示 
                        削除フラグ = sh.ShFlag,       // 管理フラグ
                        理由 = sh.ShHidden           // 備考
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":104\n詳細が登録されていません", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (TBSyukkaSyosaiID.Text == "")
            {
                TBSyukkaSyosaiID.BackColor = Color.Yellow;
                TBSyukkaSyosaiID.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSyukkaIDS.Text == "")
            {
                TBSyukkaIDS.BackColor = Color.Yellow;
                TBSyukkaIDS.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (TBSyohinID.Text == "")
            {
                TBSyohinID.BackColor = Color.Yellow;
                TBSyohinID.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSuryou.Text == "")
            {
                TBSuryou.BackColor = Color.Yellow;
                TBSuryou.Focus();
                MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Kuraberu_kun.Kuraberu_chan("出荷", "詳細", "更新", int.Parse(shukkasyosaiID), timestamp) == false)
            { return; }

            using (var context = new SalesManagementContext())
            {
                int syousai;
                if (!int.TryParse(shukkasyosaiID, out syousai) || !context.TShipmentDetails.Any(s => s.ShDetailID == syousai))
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int shukka;
                if (!int.TryParse(shukkaID, out shukka) || !context.TShipments.Any(s => s.ShID == shukka))
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIDがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(e => e.PrID == shouhin))
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var shippingDetail = context.TShipmentDetails.SingleOrDefault(sh => sh.ShDetailID.ToString() == shukkasyosaiID);
                if (shippingDetail != null)
                {
                    shippingDetail.PrID = int.Parse(syohinID);
                    shippingDetail.ShID = int.Parse(shukkaID);
                    shippingDetail.ShQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("出荷詳細の更新が成功しました。");
                    DisplayShippingDetails();
                    Log_Shipping(shippingDetail.ShDetailID);
                    ResetYellowBackgrounds(this);
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (TBSyukkaIDS.Text == "")
                {
                    TBSyukkaIDS.BackColor = Color.Yellow;
                    TBSyukkaIDS.Focus();
                    MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (TBSyohinID.Text == "")
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBSuryou.Text == "")
                {
                    TBSuryou.BackColor = Color.Yellow;
                    TBSuryou.Focus();
                    MessageBox.Show("$:101\n必要な入力がありません。（ID: {}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(shukkaID, out shukka) || !context.TShipments.Any(s => s.ShID == shukka))
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIDがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(e => e.PrID == shouhin))
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var existingOrderDetail = context.TShipmentDetails.FirstOrDefault(o => o.ShID == shukka);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show(":203\n既存データとの重複が発生しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 処理を終了
                }
                var newShippingDetail = new TShipmentDetail
                {
                    PrID = int.Parse(syohinID),
                    ShID = int.Parse(shukkaID),
                    ShQuantity = int.Parse(suryou)
                };

                context.TShipmentDetails.Add(newShippingDetail);
                context.SaveChanges();
                MessageBox.Show("出荷詳細の登録が成功しました。");
                DisplayShippingDetails();
                Log_Shipping(newShippingDetail.ShDetailID);
                ResetYellowBackgrounds(this);
            }
        }

        private void DisplayShippingDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 出荷詳細のリストを取得（checkBox1の状態に応じて並べ替え）
                    var ShipmentDetails = checkBox1.Checked
                        ? context.TShipmentDetails.OrderByDescending(sd => sd.ShID).ToList() // 降順
                        : context.TShipmentDetails.OrderBy(sd => sd.ShID).ToList();          // 昇順

                    // checkBox_2がチェックされている場合、フィルタリングを無視してすべての詳細を表示
                    var visibleShipmentDetails = checkBox_2.Checked
                        ? ShipmentDetails // チェックされていれば全て表示（並び替え済み）
                        : ShipmentDetails.Where(sd =>
                        {
                            var Shipment = context.TShipments.FirstOrDefault(s => s.ShID == sd.ShID);

                            return Shipment == null || (Shipment.ShFlag != 1 && Shipment.ShStateFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleShipmentDetails.Select(sh => new
                    {
                        出荷詳細ID = sh.ShDetailID,
                        出荷ID = sh.ShID,
                        商品ID = sh.PrID,
                        数量 = sh.ShQuantity.ToString("N0")

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    query = query.Where(sh => sh.ShDetailID.ToString() == shukkasyosaiID);
                }

                if (!string.IsNullOrEmpty(shukkaID))
                {
                    // 受注IDを検索条件に追加
                    query = query.Where(sh => sh.ShID.ToString() == shukkaID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(sh => sh.PrID.ToString() == syohinID);
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
                        出荷詳細ID = sh.ShDetailID,
                        出荷ID = sh.ShID,
                        商品ID = sh.PrID,
                        数量 = sh.ShQuantity,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":104\n詳細が登録されていません", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ToggleShippingSelection()
        {
            isShippingSelected = !isShippingSelected;
            shippingFlag = isShippingSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isShippingSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);

            if (shippingFlag == "←通常")
                lastFocusedPanelID = 1;
            else if (shippingFlag == "詳細→")
                lastFocusedPanelID = 2;
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
                    if (label2.Text == "登録")
                    {
                        TBSyukkaID.Text = "";
                    }
                    else
                    {
                        TBSyukkaID.Text = row.Cells["出荷ID"].Value.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString() ?? string.Empty;
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString() ?? string.Empty;
                    TBShainID.Text = row.Cells["社員ID"].Value?.ToString() ?? string.Empty;
                    TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString() ?? string.Empty;
                    date.Value = row.Cells["出荷終了日"].Value != null
                                 ? Convert.ToDateTime(row.Cells["出荷終了日"].Value)
                                 : DateTime.Now; // nullの場合は現在の日付を設定
                    ;
                    // 注文状態や非表示ボタン、備考も必要に応じて設定
                    // 非表示ボタンや備考もここで設定
                    // 例: hiddenButton.Text = row.Cells["非表示ボタン"].Value.ToString();
                    // 例: hiddenReason.Text = row.Cells["備考"].Value.ToString();
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
                        TBSyukkaSyosaiID.Text = "";
                    }
                    else
                    {
                        TBSyukkaSyosaiID.Text = row.Cells["出荷詳細ID"].Value.ToString() ?? string.Empty;
                    }
                    // 各テキストボックスにデータを入力
                    TBSyukkaIDS.Text = row.Cells["出荷ID"].Value.ToString() ?? string.Empty;
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString() ?? string.Empty;
                    TBSuryou.Text = row.Cells["数量"].Value.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ShippingConfirm(int ShID)
        {
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言 
                var shipment = context.TShipments.SingleOrDefault(o => o.ShID == ShID);

                if (shipment == null)
                {
                    MessageBox.Show(":104\n詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    throw new Exception("出荷IDが見つかりません。");
                }

                // 情報追加
                var newSales = new TSale
                {
                    EmID = shipment.EmID ?? 0,
                    SoID = shipment.SoID,  // 営業所ID    
                    ClID = shipment.ClID,  // 顧客ID    
                    OrID = shipment.OrID,  // 受注ID
                    SaDate = shipment.ShFinishDate ?? DateTime.MinValue,
                    SaFlag = 0


                };

                try
                {
                    context.TSales.Add(newSales);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(":201\n登録操作が失敗しました\n: " + ex.Message + "\n\nスタックトレース:\n" + ex.InnerException);
                }

                // 複数の出荷詳細を取得
                var shipmentDetails = context.TShipmentDetails.Where(o => o.ShID == shipment.ShID).ToList();
                if (!shipmentDetails.Any())
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。処理を中止します。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 複数の出荷詳細を全て引き継ぐ
                foreach (var shipmentDetail in shipmentDetails)
                {
                    var product = context.MProducts.SingleOrDefault(o => o.PrID == shipmentDetail.PrID);
                    if (product == null)
                    {
                        MessageBox.Show(":204\n該当の項目が見つかりません。発注処理を中止します。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newSaleDetail = new TSaleDetail
                    {
                        SaID = newSales.SaID,
                        PrID = shipmentDetail.PrID,  // null の場合、0 を代入
                        SaQuantity = shipmentDetail.ShQuantity,  // null の場合、0 を代入
                        SaPrTotalPrice = shipmentDetail.ShQuantity * product.Price
                    };
                    try
                    {
                        context.TSaleDetails.Add(newSaleDetail);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(":201\n登録操作が失敗しました\n:" + ex.Message);
                    }
                }
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(":201\n登録操作が失敗しました\n: " + ex.Message);
                }

            }
        }

        // パネル内のすべてのコントロールにEnterイベントを追加
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
                ToggleShippingSelection();
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
        private void TBSyukkaID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBKokyakuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBShainID_TextChanged(object sender, EventArgs e)
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
        //
        private void TBSyukkaSyosaiID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyukkaIDS_TextChanged(object sender, EventArgs e)
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
                    TBSyukkaID.BackColor = SystemColors.Window;
                    TBKokyakuID.BackColor = SystemColors.Window;
                    TBShainID.BackColor = SystemColors.Window;
                    TBShopID.BackColor = SystemColors.Window;
                    TBJyutyuID.BackColor = SystemColors.Window;

                    TBSyukkaSyosaiID.BackColor = SystemColors.Window;
                    TBSyukkaIDS.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBSuryou.BackColor = SystemColors.Window;
                    break;
            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBSyukkaID.KeyPress += NumericTextBox_KeyPress;
            TBKokyakuID.KeyPress += NumericTextBox_KeyPress;
            TBShainID.KeyPress += NumericTextBox_KeyPress;
            TBShopID.KeyPress += NumericTextBox_KeyPress;
            TBJyutyuID.KeyPress += NumericTextBox_KeyPress;

            TBSyukkaSyosaiID.KeyPress += NumericTextBox_KeyPress;
            TBSyukkaIDS.KeyPress += NumericTextBox_KeyPress;
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
                int count = context.TShipments.Count(order => order.ShStateFlag == 0 || order.ShStateFlag == null);
                if (count == 0)
                {
                    GlobalBadge badge = new GlobalBadge("");
                    b_shi.Refresh();
                }
            }
        }


        private void Log_Shipping(int id)
        {
            string ModeFlag = "";
            if (shippingFlag == "←通常")
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
                            Display = "出荷",
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
    }


}
