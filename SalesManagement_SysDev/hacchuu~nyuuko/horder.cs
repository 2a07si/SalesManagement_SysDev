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

        private int lastFocusedPanelId = 1;


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

            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベル更新

            // アクセスマネージャを使ってボタンのアクセス制御を適用
            Control[] buttons = { b_rec, /* 他のボタンを追加 */ };
            accessManager.SetButtonAccess(buttons); // ボタンのアクセス設定を適用
            labelStatus.labelstatus(label2, b_kakutei);
            b_FormSelector.Text = "←通常";
            CurrentStatus.SetMode(Mode.通常);
            DisplayHattyus();
            DisplayHattyuDetails();


        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBHattyuuID.Text = "";
            TBMakerID.Text = "";
            TBShainID.Text = "";
            NyuukoFlag.Checked = false;
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
            TBHattyuuID.BackColor = Color.White;
            TBHattyuuSyosaiID.BackColor = Color.White;
        }


        private void b_ser_Click(object sender, EventArgs e)
        {
            PerformSearch();
            TBHattyuuID.Enabled = true;
            TBHattyuuSyosaiID.Enabled = true;
            TBHattyuuID.BackColor = Color.White;
            TBHattyuuSyosaiID.BackColor = Color.White;

        }
        private void PerformSearch()
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            UpdateStatus();
            TBHattyuuID.Enabled = true;
            TBHattyuuSyosaiID.Enabled = true;
            TBHattyuuID.BackColor = Color.White;
            TBHattyuuSyosaiID.BackColor = Color.White;
        }
        private void UpdateStatus()
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            RegisterStatus();
            TBHattyuuID.Enabled = false;
            TBHattyuuSyosaiID.Enabled = false;
            TBHattyuuID.BackColor = Color.Gray;
            TBHattyuuSyosaiID.BackColor = Color.Gray;
            TBHattyuuID.Text = "";
            TBHattyuuSyosaiID.Text = "";
        }

        private void RegisterStatus()
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            DisplayHattyus();
            DisplayHattyuDetails();
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            ListStatus();
            TBHattyuuID.Enabled = true;
            TBHattyuuSyosaiID.Enabled = true;
            TBHattyuuID.BackColor = Color.White;
            TBHattyuuSyosaiID.BackColor = Color.White;
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
                        MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void UpdateHattyu()
        {
            string hattyuuID = TBHattyuuID.Text;
            string makerID = TBMakerID.Text;
            string shainID = TBShainID.Text;
            DateTime hattyuuDate = date.Value;
            bool nyuukoFlag = NyuukoFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            if (TBHattyuuID.Text == null)
            {
                MessageBox.Show("発注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBMakerID.Text == null)
            {
                MessageBox.Show("メーカーIDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBShainID.Text == null)
            {
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {
                var hattyu = context.THattyus.SingleOrDefault(h => h.HaId.ToString() == hattyuuID);
                if (hattyu != null)
                {
                    hattyu.MaId = int.Parse(makerID);
                    hattyu.EmId = int.Parse(shainID);
                    hattyu.HaDate = hattyuuDate;
                    hattyu.WaWarehouseFlag = nyuukoFlag ? 2 : 0; // 入庫フラグ
                    hattyu.HaFlag = delFlag ? 1 : 0;              // 削除フラグ
                    hattyu.HaHidden = riyuu;

                    // 入庫フラグがチェックされている場合、発注詳細の確認を行う
                    if (nyuukoFlag)
                    {
                        // 発注詳細が存在するか確認
                        var hattyuDetailsExist = context.THattyuDetails
                            .Any(hd => hd.HaId == hattyu.HaId); // HaId が一致する発注詳細が存在するか確認

                        if (!hattyuDetailsExist)
                        {
                            // 発注詳細が存在しない場合はエラーメッセージを表示

                            MessageBox.Show("発注詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // 処理を中断
                        }

                        // 発注詳細が存在する場合、発注確認処理を実行

                        HorderConfirm(hattyu.HaId);
                    }

                    // 更新を保存
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        DisplayHattyus(); // 更新後に発注情報を再表示
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
                        MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("該当する発注情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void RegisterHattyu()
        {
            string makerID = TBMakerID.Text;
            string shainID = TBShainID.Text;
            DateTime hattyuuDate = date.Value;
            bool nyuukoFlag = NyuukoFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            using (var context = new SalesManagementContext())
            {
                // メーカーIDがMMakerテーブルに存在するか確認
                int maker;
                if (!int.TryParse(makerID, out maker) || !context.MMakers.Any(m => m.MaId == maker))
                {
                    MessageBox.Show("メーカーIDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int employeeId;
                if (!int.TryParse(shainID, out employeeId) || !context.MEmployees.Any(e => e.EmId == employeeId))
                {
                    MessageBox.Show("社員IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBMakerID.Text == null)
                {
                    MessageBox.Show("メーカーIDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBShainID.Text == null)
                {
                    MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 新しい発注情報を作成
                var newHattyu = new THattyu
                {
                    MaId = int.Parse(makerID),
                    EmId = employeeId,               // 確認済みの社員ID
                    HaDate = hattyuuDate,            // 発注日
                    WaWarehouseFlag = nyuukoFlag ? 2 : 0, // 入庫状態フラグ
                    HaFlag = delFlag ? 1 : 0,        // 削除フラグ
                    HaHidden = riyuu                 // 非表示理由
                };

                // 発注情報をコンテキストに追加
                context.THattyus.Add(newHattyu);
                context.SaveChanges();

                // 登録成功メッセージ
                MessageBox.Show("登録が成功しました。");
                DisplayHattyus(); // 新規登録後の発注情報を再表示

                // 入庫フラグがチェックされている場合、発注詳細の確認を行う
                if (nyuukoFlag)
                {
                    // 発注詳細が存在するか確認
                    var hattyuDetailsExist = context.THattyuDetails
                        .Any(hd => hd.HaId == newHattyu.HaId); // HaId が一致する発注詳細が存在するか確認

                    if (!hattyuDetailsExist)
                    {
                        // 発注詳細が存在しない場合はエラーメッセージを表示
                        MessageBox.Show("発注詳細が登録されていません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // 処理を中断
                    }

                    // 発注詳細が存在する場合、発注確認処理を実行
                    HorderConfirm(newHattyu.HaId);
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
                        発注ID = h.HaId,
                        メーカID = h.MaId,
                        社員ID = h.EmId,
                        発注年月日 = h.HaDate,
                        状態フラグ = h.WaWarehouseFlag,
                        非表示フラグ = h.HaFlag,
                        非表示理由 = h.HaHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchHattyus()
        {
            using (var context = new SalesManagementContext())
            {
                var hattyuuID = TBHattyuuID.Text.Trim();       // 発注ID  
                var makerID = TBMakerID.Text.Trim();           // メーカID  
                var shainID = TBShainID.Text.Trim();           // 社員ID  

                var query = context.THattyus.AsQueryable();

                if (!string.IsNullOrEmpty(hattyuuID) && int.TryParse(hattyuuID, out int parsedHattyuuID))
                {
                    query = query.Where(h => h.HaId == parsedHattyuuID);
                }

                if (!string.IsNullOrEmpty(makerID) && int.TryParse(makerID, out int parsedMakerID))
                {
                    query = query.Where(h => h.MaId == parsedMakerID);
                }

                if (!string.IsNullOrEmpty(shainID) && int.TryParse(shainID, out int parsedShainID))
                {
                    query = query.Where(h => h.EmId == parsedShainID);
                }

                if (checkBoxDateFilter.Checked)
                {
                    DateTime hattyuuDate = date.Value;
                    query = query.Where(h => h.HaDate.Date == hattyuuDate.Date);
                }

                var hattyus = query.ToList();

                if (hattyus.Any())
                {
                    dataGridView1.DataSource = hattyus.Select(h => new
                    {
                        発注ID = h.HaId,
                        メーカID = h.MaId,
                        社員ID = h.EmId,
                        発注年月日 = h.HaDate,
                        発注状態 = NyuukoFlag.Checked ? 2 : 1,
                        非表示フラグ = DelFlag.Checked ? 1 : 0
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する発注情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null;
                }
            }
        }

        private void UpdateHattyuDetails()
        {
            string hattyuuSyosaiID = TBHattyuuSyosaiID.Text;
            string hattyuuID = TBHattyuIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            if (TBHattyuuSyosaiID.Text == null)
            {
                MessageBox.Show("発注詳細IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TBHattyuIDS.Text == null)
            {
                MessageBox.Show("発注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var orderDetail = context.THattyuDetails.SingleOrDefault(od => od.HaDetailId.ToString() == hattyuuSyosaiID);
                if (orderDetail != null)
                {
                    orderDetail.HaId = int.Parse(hattyuuID);
                    orderDetail.PrId = int.Parse(syohinID);
                    orderDetail.HaQuantity = int.Parse(suryou);

                    context.SaveChanges();
                    MessageBox.Show("発注詳細の更新が成功しました。");
                    DisplayHattyuDetails();
                }
                else
                {
                    MessageBox.Show("該当する発注詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterHattyuDetails()
        {
            string hattyuuID = TBHattyuIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

            using (var context = new SalesManagementContext())
            {
                // HaId（発注ID）がTHattyuテーブルに存在するか確認
                int hattyuId;
                if (!int.TryParse(hattyuuID, out hattyuId) || !context.THattyus.Any(h => h.HaId == hattyuId))
                {
                    MessageBox.Show("発注IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // PrId（商品ID）がMProductテーブルに存在するか確認
                int productId;
                if (!int.TryParse(syohinID, out productId) || !context.MProducts.Any(p => p.PrId == productId))
                {
                    MessageBox.Show("商品IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 数量のパース
                int quantity;
                if (!int.TryParse(suryou, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("数量が無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TBHattyuIDS.Text == null)
                {
                    MessageBox.Show("発注IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var newOrderDetail = new THattyuDetail
                {
                    HaId = hattyuId,
                    PrId = productId,
                    HaQuantity = quantity
                };

                context.THattyuDetails.Add(newOrderDetail);
                context.SaveChanges();
                MessageBox.Show("発注詳細の登録が成功しました。");
                DisplayHattyuDetails();
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
                            var Hattyu = context.THattyus.FirstOrDefault(o => o.HaId == od.HaId);

                            return Hattyu == null || (Hattyu.HaFlag != 1 && Hattyu.WaWarehouseFlag != 2);
                        }).ToList();

                    dataGridView2.DataSource = visibleHattyuDetails.Select(od => new
                    {
                        発注詳細ID = od.HaDetailId,
                        発注ID = od.HaId,
                        商品ID = od.PrId,
                        数量 = od.HaQuantity
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    query = query.Where(od => od.HaDetailId.ToString() == hattyuuSyosaiID);
                }

                if (!string.IsNullOrEmpty(hattyuuID))
                {
                    // 発注IDを検索条件に追加
                    query = query.Where(od => od.HaId.ToString() == hattyuuID);
                }

                if (!string.IsNullOrEmpty(syohinID))
                {
                    // 商品IDを検索条件に追加
                    query = query.Where(od => od.PrId.ToString() == syohinID);
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
                        発注詳細ID = od.HaDetailId,
                        発注ID = od.HaId,
                        商品ID = od.PrId,
                        数量 = od.HaQuantity
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する発注詳細が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lastFocusedPanelId = 1;
            else if (orderFlag == "詳細→")
                lastFocusedPanelId = 2;
        }


        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleHattyuSelection();

            // b_FormSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();

            if (orderFlag == "←通常")
                lastFocusedPanelId = 1;
            else if (orderFlag == "詳細→")
                lastFocusedPanelId = 2;
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
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HorderConfirm(int HaId)
        {
            MessageBox.Show("登録開始します");
            using (var context = new SalesManagementContext())
            {
                // 引き継ぐ情報を宣言 
                var horder = context.THattyus.SingleOrDefault(o => o.HaId == HaId);

                if (horder == null)
                {
                    throw new Exception("入荷IDが見つかりません。");
                }

                // 情報追加
                var newWarehousing = new TWarehousing
                {
                    HaId = HaId,
                    EmId = null,
                    //datetime
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


                var hattyuDetail = context.THattyuDetails.SingleOrDefault(o => o.HaId == HaId);
                var newWarehousingDetail = new TWarehousingDetail
                {
                    WaId = newWarehousing.WaId,
                    PrId = hattyuDetail.PrId,
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
                ToggleHattyuSelection();
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
            TBHattyuuID.BackColor = SystemColors.Window;
            TBMakerID.BackColor = SystemColors.Window;
            TBShainID.BackColor = SystemColors.Window;
            TBHattyuuSyosaiID.BackColor = SystemColors.Window;
            TBHattyuIDS.BackColor = SystemColors.Window;
            TBSyohinID.BackColor = SystemColors.Window;
            TBSuryou.BackColor = SystemColors.Window;
        }
    }

}
