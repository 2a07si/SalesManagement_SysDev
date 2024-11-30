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
            CurrentStatus.UpDateStatus(label2);
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
            TBShainID.Text = "";
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

                        MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void UpdateShipping()
        {
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
                MessageBox.Show("出荷IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



            using (var context = new SalesManagementContext())
            {
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
                        // 出荷詳細が存在するか確認
                        var shippingDetailsExist = context.TShipmentDetails
                            .Any(sd => sd.ShID == shipping.ShID); // ShID が一致する出荷詳細が存在するか確認
                        if (!shippingDetailsExist)
                        {
                            // 出荷詳細が存在しない場合はエラーメッセージを表示
                            MessageBox.Show("出荷詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断
                        }
                        // 受注IDの重複チェック
                        bool isDuplicate = context.TChumons.Any(c => c.OrID == shipping.OrID);
                        if (isDuplicate)
                        {
                            MessageBox.Show($"この受注ID ({shipping.OrID}) は既に登録されています。更新を中止します。", "重複エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // 更新処理を中止
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
                    MessageBox.Show("該当する出荷情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("顧客IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBShainID.Text == "")
                {
                    TBShainID.BackColor = Color.Yellow;
                    TBShainID.Focus();
                    MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBShopID.Text == "")
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBJyutyuID.Text == "")
                {
                    TBJyutyuID.BackColor = Color.Yellow;
                    TBJyutyuID.Focus();
                    MessageBox.Show("受注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 社員IDが存在するか確認
                int employeeID;
                if (!int.TryParse(shainID, out employeeID) || !context.MEmployees.Any(e => e.EmID == employeeID))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kokyaku;
                if (!int.TryParse(kokyakuID, out kokyaku) || !context.MClients.Any(k => k.ClID == kokyaku))
                {
                    MessageBox.Show("顧客IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 受注IDが存在するか確認
                int juchu;
                if (!int.TryParse(JyutyuID, out juchu) || !context.TOrders.Any(j => j.OrID == juchu))
                {
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

                // 出荷情報が既に存在するか確認
                var shipping = context.TShipments.SingleOrDefault(o => o.ShID.ToString() == shukkaID);
                if (shipping == null)
                {
                    try
                    {
                        // 新しい出荷情報を作成
                        var newShipping = new TShipment
                        {
                            SoID = int.Parse(shopID),                  // 店舗ID
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
                            MessageBox.Show("出荷詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 出荷詳細がない場合は処理を中止
                        }

                        // データを保存
                        context.SaveChanges();
                        MessageBox.Show("登録が成功しました。");
                        Log_Shipping(newShipping.ShID);

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
                    MessageBox.Show("既に出荷情報が存在しています。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DisplayShipping()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {

                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示
                    var shipping = checkBox_2.Checked
                        ? context.TShipments.ToList()  // チェックされていれば全ての注文を表示
                        : context.TShipments.Where(o => o.ShFlag != 1 && o.ShStateFlag != 2).ToList();  // チェックされていなければ非表示フラグが "1" のものを除外
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
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var riyuu = TBRiyuu;

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
                        状態フラグ = sh.ShStateFlag,  // 出荷フラグの表示
                        管理フラグ = sh.ShFlag,
                        非表示理由 = sh.ShHidden

                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する出荷情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("出荷詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBSyukkaIDS.Text == "")
            {
                TBSyukkaIDS.BackColor = Color.Yellow;
                TBSyukkaIDS.Focus();
                MessageBox.Show("出荷IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                }
                else
                {
                    MessageBox.Show("該当する出荷詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("出荷IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (!int.TryParse(shukkaID, out shukka) || !context.TShipments.Any(s => s.ShID == shukka))
                {
                    MessageBox.Show("出荷IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIDがMEmployeeテーブルに存在するか確認
                int shouhin;
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(e => e.PrID == shouhin))
                {
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var existingOrderDetail = context.TShipmentDetails.FirstOrDefault(o => o.ShID == shukka);
                if (existingOrderDetail != null)
                {
                    MessageBox.Show("この出荷IDにはすでに出荷詳細が存在します。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }

        private void DisplayShippingDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var ShipmentDetails = context.TShipmentDetails.ToList();

                    var visibleShipmentDetails = checkBox_2.Checked
                        ? ShipmentDetails
                        : ShipmentDetails.Where(od =>
                        {
                            var Shipment = context.TShipments.FirstOrDefault(o => o.ShID == od.ShID);

                            return Shipment == null || (Shipment.ShFlag != 1 && Shipment.ShStateFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleShipmentDetails.Select(sh => new
                    {
                        出荷詳細ID = sh.ShDetailID,
                        商品ID = sh.PrID,
                        数量 = sh.ShQuantity.ToString("N0"),
                        出荷ID = sh.ShID
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("該当する出荷詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ShippingConfirm(int ShID)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言 
                var shipment = context.TShipments.SingleOrDefault(o => o.ShID == ShID);

                if (shipment == null)
                {
                    MessageBox.Show("出荷詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    throw new Exception("TSalesへの登録に失敗しました: " + ex.Message + "\n\nスタックトレース:\n" + ex.InnerException);
                }

                var shipmentDetail = context.TShipmentDetails.SingleOrDefault(o => o.ShID == shipment.ShID);
                var product = context.MProducts.SingleOrDefault(o => o.PrID == shipmentDetail.PrID);
                var newSaleDetail = new TSaleDetail
                {
                    // `PrID` が nullable 型のため、`Value` プロパティを使って値を取得
                    // `PrID` が null の場合、0 を代入
                    SaID = newSales.SaID,
                    PrID = shipmentDetail.PrID,  // null の場合、0 を代入
                    SaQuantity = shipmentDetail.ShQuantity,  // null の場合、0 を代入
                    SaPrTotalPrice = shipmentDetail.ShQuantity + product.Price


                };
                if (newSaleDetail.PrID == 0 || newSaleDetail.SaQuantity == 0)
                {
                    MessageBox.Show("PrIDかShquantityが0で入力されています");
                }

                try
                {
                    context.TSaleDetails.Add(newSaleDetail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("TSaleDetailへの登録に失敗しました:" + ex.Message);
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
                        MessageBox.Show("最新のログ履歴が見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Logへの登録に失敗しました:" + ex.Message);
            }
        }

    }


}
