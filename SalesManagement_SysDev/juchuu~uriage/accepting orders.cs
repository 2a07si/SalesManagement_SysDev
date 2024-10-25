using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using System.Linq; // LINQの使用を許可 
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using SalesManagement_SysDev.juchuu_uriage;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定

        private ClassDataGridViewClearer dgvClearer;
        private string searchKeyword = "";
        private ClassChangeForms formChanger; // 画面遷移管理クラス    
        private ClassAccessManager accessManager; // 権限管理クラス   
        private string FormSelector = "";
        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            // ボタンアクセス制御を設定   
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_arr,
                b_shi,
                b_sal,
                b_lss
            });
            labelStatus.labelstatus(label2, b_kakutei);
        }

        // メインメニューに戻る    
        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移    
        }

        // 注文管理画面に遷移    
        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移    
        }

        // 入荷管理画面に遷移    
        private void b_arr_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToArrivalForm(); // 入荷管理画面に遷移    
        }

        // 出荷管理画面に遷移    
        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm(); // 出荷管理画面に遷移    
        }

        // 売上管理画面に遷移    
        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移    
        }

        // 出庫管理画面に遷移   
        private void b_lss_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm(); // 出庫管理画面に遷移   
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBJyutyuID.Text = "";
            TBShopID.Text = "";
            TBShainID.Text = "";
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
        }

        private void b_ser_Click(object sender, EventArgs e)
        {

            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {

            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            //new UpdatorButton().AddUpdator(label14).OnUpdate();

        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        // 状態リセットメソッド（必要ならボタンにバインド）   
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }
        private void b_kakutei_Click_1(object sender, EventArgs e)
        {
            // モードに応じた処理を実行
            switch (FormSelector)
            {
                case "受注":
                    // 受注モードの処理
                    switch (CurrentStatus.CurrentStatusValue) // CurrentStatusを参照するように変更
                    {
                        case CurrentStatus.Status.更新:
                            UpdateOrder();
                            break;

                        case CurrentStatus.Status.登録:
                            RegisterOrder();
                            break;

                        case CurrentStatus.Status.一覧:
                            DisplayOrders();
                            MessageBox.Show("一覧表示が完了しました。");
                            break;

                        case CurrentStatus.Status.検索:
                            searchKeyword = TBJyutyuID.Text;
                            SearchOrders();
                            break;

                        default:
                            MessageBox.Show("無効な操作です。");
                            break;
                    }
                    break;

                case "受注詳細":
                    // 受注詳細モードの処理
                    switch (CurrentStatus.CurrentStatusValue) // CurrentStatusを参照するように変更
                    {
                        case CurrentStatus.Status.更新:
                            UpdateOrderDetails();
                            break;

                        case CurrentStatus.Status.登録:
                            RegisterOrderDetails(); // 新たに追加する登録処理
                            break;

                        case CurrentStatus.Status.一覧:
                            DisplayOrderDetails();
                            MessageBox.Show("受注詳細の一覧表示が完了しました。");
                            break;

                        case CurrentStatus.Status.検索:
                            searchKeyword = TBJyutyuID.Text; // 受注詳細の検索条件を取得
                            SearchOrderDetails(); // 受注詳細の検索処理
                            break;

                        default:
                            MessageBox.Show("無効な操作です。");
                            break;
                    }
                    break;

                default:
                    MessageBox.Show("現在のモードは無効です。");
                    break;
            }
        }
<<<<<<< HEAD
    
       
=======
>>>>>>> f99a50bcb4491c5122f3a59aa23920363a3a24c9

        private void UpdateOrder()
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

            using (var context = new SalesManagementContext())
            {
                // JyutyuID ではなく OrId で検索する必要があります 
                var order = context.TOrders.SingleOrDefault(o => o.OrId.ToString() == jyutyuID);
                if (order != null)
                {
                    order.SoId = int.Parse(shopID); // SoIdの設定 
                    order.EmId = int.Parse(shainID); // EmIdの設定 
                    order.ClId = int.Parse(kokyakuID); // ClIdの設定 
                    order.ClCharge = tantoName; // ClChargeの設定 
                    order.OrDate = jyutyuDate; // OrDateの設定 
                    order.OrStateFlag = null; // OrStateFlagは適宜初期化 
                    order.OrFlag = tyumonFlag ? 1 : 0; // OrFlagの設定 
                    order.OrHidden = delFlag ? "1" : "0"; // OrHiddenの設定 

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("指定された受注IDが見つかりませんでした。");
                }
            }
        }

        private void RegisterOrder()
        {
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string tantoName = TBTantoName.Text;
            DateTime jyutyuDate = date.Value;
            bool tyumonFlag = TyumonFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            try
            {
                using (var context = new SalesManagementContext())
                {
                    var order = new TOrder
                    {
                        SoId = int.Parse(shopID), // SoIdの設定 
                        EmId = int.Parse(shainID), // EmIdの設定 
                        ClId = int.Parse(kokyakuID), // ClIdの設定 
                        ClCharge = tantoName, // ClChargeの設定 
                        OrDate = jyutyuDate, // OrDateの設定 
                        OrStateFlag = null, // OrStateFlagは適宜初期化 
                        OrFlag = tyumonFlag ? 1 : 0, // OrFlagの設定 
                        OrHidden = delFlag ? "1" : "0", // OrHiddenの設定 
                    };

                    context.TOrders.Add(order);
                    context.SaveChanges();
                }
                MessageBox.Show("受注登録が成功しました。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("登録中にエラーが発生しました: " + ex.Message);
            }
        }

        // 一覧表示メソッド    
        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orders = context.TOrders.ToList(); // すべての受注を取得 

                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        受注ID = o.OrId,
                        営業所ID = o.SoId,
                        社員ID = o.EmId,
                        顧客ID = o.ClId,
                        顧客担当者 = o.ClCharge,
                        受注日 = o.OrDate,
                        受注フラグ = o.OrFlag,
                        非表示フラグ = o.OrHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("データの取得中にエラーが発生しました: " + ex.Message);
            }
        }
        private void SearchOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // 検索条件に基づいて受注をフィルタリング
                    var orders = context.TOrders
                        .Where(o => o.OrId.ToString().Contains(searchKeyword) ||
                                    o.SoId.ToString().Contains(searchKeyword) ||
                                    o.EmId.ToString().Contains(searchKeyword) ||
                                    o.ClId.ToString().Contains(searchKeyword) ||
                                    o.ClCharge.Contains(searchKeyword))
                        .ToList();
                    // DataGridViewに表示するために変換
                    dataGridView1.DataSource = orders.Select(o => new
                    {
                        受注ID = o.OrId,
                        営業所ID = o.SoId,
                        社員ID = o.EmId,
                        顧客ID = o.ClId,
                        顧客担当者 = o.ClCharge,
                        受注日 = o.OrDate,
                        受注フラグ = o.OrFlag,
                        非表示フラグ = o.OrHidden
                    }).ToList();

                    // 検索結果が0件の場合のメッセージ
                    if (orders.Count == 0)
                    {
                        MessageBox.Show("該当する受注が見つかりませんでした。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("検索中にエラーが発生しました: " + ex.Message);
            }
        }
<<<<<<< HEAD


        // 受注詳細の更新機能
        public void UpdateOrderDetails()
=======
        // DataGridViewのセルがクリックされたときのイベントハンドラ
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
>>>>>>> f99a50bcb4491c5122f3a59aa23920363a3a24c9
        {
            // 受注詳細の更新機能が動作しました
            MessageBox.Show("受注詳細の更新機能が動作しました");
        }

        // 受注詳細の追加機能
        public void RegisterOrderDetails()
        {
            // 受注詳細の追加機能が動作しました
            MessageBox.Show("受注詳細の追加機能が動作しました");
        }

        // 受注詳細の検索機能
        public void SearchOrderDetails()
        {
            // 受注詳細の検索機能が動作しました
            MessageBox.Show("受注詳細の検索機能が動作しました");
        }

        // 受注詳細の一覧機能
        public void DisplayOrderDetails()
        {
            // 受注詳細の一覧機能が動作しました
            MessageBox.Show("受注詳細の一覧機能が動作しました");
        }

        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            // 現在の選択状態を反転
            isOrderSelected = !isOrderSelected;

            // 表示名を切り替える
            if (isOrderSelected)
            {
<<<<<<< HEAD
                FormSelector = "受注";
                b_FormSelector.Text = "受注詳細操作"; // TOrder詳細側を選択
=======
                // クリックした行のデータを取得
                var row = dataGridView1.Rows[e.RowIndex];
                // 各テキストボックスにデータを設定
                TBJyutyuID.Text = row.Cells["受注ID"].Value.ToString();
                TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                TBShainID.Text = row.Cells["社員ID"].Value.ToString();
                TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                TBTantoName.Text = row.Cells["顧客担当者"].Value.ToString();
                date.Value = DateTime.Parse(row.Cells["受注日"].Value.ToString()); // 日付を設定
                TyumonFlag.Checked = Convert.ToBoolean(row.Cells["受注フラグ"].Value); // フラグの設定
                DelFlag.Checked = row.Cells["非表示フラグ"].Value.ToString() == "1"; // 非表示フラグの設定
>>>>>>> f99a50bcb4491c5122f3a59aa23920363a3a24c9
            }
            else
            {
                FormSelector = "受注詳細";
                b_FormSelector.Text = "受注操作"; // TOrder側を選択
            }

            // ここで選択状態に応じた処理を行うことも可能
            // 例えば、受注詳細フォームを表示する場合など
        }

    }
}
