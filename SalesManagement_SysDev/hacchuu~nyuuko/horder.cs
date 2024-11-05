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
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager; // アクセスマネージャのインスタンス

        public horder()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(horder_Load);
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
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
        }


        private void b_ser_Click_1(object sender, EventArgs e) => PerformSearch();

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

        private void b_reg_Click_1(object sender, EventArgs e) => RegisterStatus();

        private void RegisterStatus()
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click_1(object sender, EventArgs e) => ListStatus();

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
                        HandleOrderOperation();
                        break;
                    case CurrentStatus.Mode.詳細:
                        HandleOrderDetailOperation();
                        break;
                    default:
                        MessageBox.Show("現在のモードは無効です。");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
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
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }

        private void HandleOrderDetailOperation()
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
                    break;
                case CurrentStatus.Status.検索:
                    SearchOrderDetails();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
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

            using (var context = new SalesManagementContext())
            {
                var hattyu = context.THattyus.SingleOrDefault(h => h.HaId.ToString() == hattyuuID);
                if (hattyu != null)
                {
                    hattyu.MaId = int.Parse(makerID);
                    hattyu.EmId = int.Parse(shainID);
                    hattyu.HaDate = hattyuuDate;
                    hattyu.WaWarehouseFlag = nyuukoFlag ? 1 : 0;
                    hattyu.HaHidden = delFlag ? "1" : "0";
                    hattyu.HaHidden = riyuu;

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する発注が見つかりません。");
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
                // EmIdがMEmployeeテーブルに存在するか確認
                int employeeId;
                if (!int.TryParse(shainID, out employeeId) || !context.MEmployees.Any(e => e.EmId == employeeId))
                {
                    MessageBox.Show("社員IDが存在しません。");
                    return;
                }

                var newHattyu = new THattyu
                {
                    MaId = int.Parse(makerID),
                    EmId = employeeId, // ここで存在を確認したEmIdを使用
                    HaDate = hattyuuDate,
                    WaWarehouseFlag = nyuukoFlag ? 1 : 0,
                    HaFlag = delFlag ? 1 : 0, // 非表示フラグをHaFlagで示す
                    HaHidden = riyuu // 非表示理由を設定
                };

                context.THattyus.Add(newHattyu);
                context.SaveChanges();
                MessageBox.Show("登録が成功しました。");
            }
        }




        private void DisplayHattyus()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var hattyus = context.THattyus.ToList();

                    dataGridView1.DataSource = hattyus.Select(h => new
                    {
                        発注ID = h.HaId,
                        メーカID = h.MaId,
                        社員ID = h.EmId,
                        発注日 = h.HaDate,
                        入庫フラグ = h.WaWarehouseFlag,
                        非表示フラグ = h.HaHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
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
                        発注日 = h.HaDate,
                        入庫状態 = NyuukoFlag.Checked ? "〇" : "×",
                        非表示フラグ = DelFlag.Checked ? "〇" : "×"
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する発注が見つかりません。");
                    dataGridView1.DataSource = null;
                }
            }
        }


        private void UpdateOrderDetails()
        {
            string hattyuuSyosaiID = TBHattyuuSyosaiID.Text;
            string hattyuuID = TBHattyuIDS.Text;
            string syohinID = TBSyohinID.Text;
            string suryou = TBSuryou.Text;

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
                }
                else
                {
                    MessageBox.Show("該当する発注詳細が見つかりません。");
                }
            }
        }

        private void RegisterOrderDetails()
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
                    MessageBox.Show("発注IDが存在しません。");
                    return;
                }

                // PrId（商品ID）がMProductテーブルに存在するか確認
                int productId;
                if (!int.TryParse(syohinID, out productId) || !context.MProducts.Any(p => p.PrId == productId))
                {
                    MessageBox.Show("商品IDが存在しません。");
                    return;
                }

                // 数量のパース
                int quantity;
                if (!int.TryParse(suryou, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("数量が無効です。");
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
            }
        }


        private void DisplayOrderDetails()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orderDetails = context.THattyuDetails.ToList();

                    dataGridView2.DataSource = orderDetails.Select(od => new
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
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchOrderDetails()
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
                    MessageBox.Show("該当する発注詳細が見つかりません。");
                }
            }
        }





        private void ToggleOrderSelection()
        {
            isOrderSelected = !isOrderSelected;
            orderFlag = isOrderSelected ? "←通常" : "詳細→";

            // CurrentStatusのモードを切り替える
            CurrentStatus.SetMode(isOrderSelected ? CurrentStatus.Mode.通常 : CurrentStatus.Mode.詳細);
        }


        private void b_FormSelector_Click_1(object sender, EventArgs e)
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

        // CellClickイベントハンドラ 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // クリックした行のインデックスを取得 
            int rowIndex = e.RowIndex;

            // 行インデックスが有効かどうかをチェック 
            if (rowIndex >= 0)
            {
                // 行データを取得 
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // 各テキストボックスにデータを入力 
                TBHattyuuID.Text = row.Cells["発注ID"].Value.ToString();
                TBMakerID.Text = row.Cells["メーカID"].Value.ToString();
                TBShainID.Text = row.Cells["社員ID"].Value.ToString();

                date.Value = Convert.ToDateTime(row.Cells["発注日"].Value);
                // 入庫状態や非表示フラグも必要に応じて設定 
                // 例: NyuukoFlag.Checked = (row.Cells["入庫状態"].Value.ToString() == "1"); 
                // 例: DelFlag.Checked = (row.Cells["非表示フラグ"].Value.ToString() == "1"); 
                // 例: TBRiyuu.Text = row.Cells["非表示理由"].Value.ToString(); 
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // クリックした行のインデックスを取得  
            int rowIndex = e.RowIndex;

            // 行インデックスが有効かどうかをチェック  
            if (rowIndex >= 0)
            {
                // 行データを取得  
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                // 各テキストボックスにデータを入力 
                TBHattyuuSyosaiID.Text = row.Cells["発注詳細ID"].Value.ToString();
                TBHattyuIDS.Text = row.Cells["発注ID"].Value.ToString();
                TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                TBSuryou.Text = row.Cells["数量"].Value.ToString();
                // 合計金額も設定 
                // 例: TBGoukeiKingaku.Text = row.Cells["合計金額"].Value.ToString(); 
            }
        }

        
    }

}
