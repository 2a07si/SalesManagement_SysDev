using System;
using System.Linq;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ; // 各種クラスを使用する
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using SalesManagement_SysDev.juchuu_uriage;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private ClassDataGridViewClearer dgvClearer;
        private ClassChangeForms formChanger; // 画面遷移管理クラス
        private ClassAccessManager accessManager; // 権限管理クラス
        private string orderFlag = "注文"; // 初期状態を「注文」に設定

        public acceptingorders(Form mainForm)
        {
            InitializeComponent();
            formChanger = new ClassChangeForms(this);
            accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
        }

        private void acceptingorders_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            // ボタンアクセス制御を設定
            accessManager.SetButtonAccess(new Control[]
            {
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

        // 各ボタンでの画面遷移
        private void b_ord_Click(object sender, EventArgs e) => formChanger.NavigateToOrderForm();
        private void b_arr_Click_1(object sender, EventArgs e) => formChanger.NavigateToArrivalForm();
        private void b_shi_Click(object sender, EventArgs e) => formChanger.NavigateToShippingForm();
        private void b_sal_Click(object sender, EventArgs e) => formChanger.NavigateToSalesForm();
        private void b_lss_Click_1(object sender, EventArgs e) => formChanger.NavigateToIssueForm();

        private void clear_Click(object sender, EventArgs e) => ClearText();

        private void ClearText()
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
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }

        private void b_kakutei_Click_1(object sender, EventArgs e)
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
                    SearchOrders(TBJyutyuID.Text);
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
                    MessageBox.Show("受注詳細の一覧表示が完了しました。");
                    break;
                case CurrentStatus.Status.検索:
                    SearchOrderDetails(TBJyutyuID.Text);
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }

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

            using (var context = new SalesManagementContext())
            {
                var order = context.TOrders.SingleOrDefault(o => o.OrId.ToString() == jyutyuID);
                if (order != null)
                {
                    order.SoId = int.Parse(shopID);
                    order.EmId = int.Parse(shainID);
                    order.ClId = int.Parse(kokyakuID);
                    order.ClCharge = tantoName;
                    order.OrDate = jyutyuDate;
                    order.OrStateFlag = null; // 適宜初期化
                    order.OrFlag = tyumonFlag ? 1 : 0;
                    order.OrHidden = delFlag ? "1" : "0";

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する受注が見つかりません。");
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

            using (var context = new SalesManagementContext())
            {
                var newOrder = new TOrder
                {
                    SoId = int.Parse(shopID),
                    EmId = int.Parse(shainID),
                    ClId = int.Parse(kokyakuID),
                    ClCharge = tantoName,
                    OrDate = jyutyuDate,
                    OrStateFlag = null,
                    OrFlag = tyumonFlag ? 1 : 0,
                    OrHidden = delFlag ? "1" : "0"
                };

                context.TOrders.Add(newOrder);
                context.SaveChanges();
                MessageBox.Show("登録が成功しました。");
            }
        }

        private void DisplayOrders()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var orders = context.TOrders.ToList();

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
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchOrders(string orderID)
        {
            using (var context = new SalesManagementContext())
            {
                var order = context.TOrders.SingleOrDefault(o => o.OrId.ToString() == orderID);
                if (order != null)
                {
                    MessageBox.Show($"受注ID: {order.OrId}\n営業所ID: {order.SoId}\n社員ID: {order.EmId}\n顧客ID: {order.ClId}\n担当者: {order.ClCharge}\n受注日: {order.OrDate}");
                }
                else
                {
                    MessageBox.Show("該当する受注が見つかりません。");
                }
            }
        }

        private void UpdateOrderDetails()
        {
            // 詳細更新処理を追加
        }

        private void RegisterOrderDetails()
        {
            // 詳細登録処理を追加
        }

        private void DisplayOrderDetails()
        {
            // 詳細表示処理を追加
        }

        private void SearchOrderDetails(string orderID)
        {
            // 詳細検索処理を追加
        }

        private void b_FornSelector_Click(object sender, EventArgs e)
        {
            // 状態を切り替える処理
            ToggleOrderSelection();

            // 現在の状態をメッセージボックスで表示
            MessageBox.Show($"現在の状態: {orderFlag}");

            // b_FlagSelectorのテキストを現在の状態に更新
            UpdateFlagButtonText();
        }

        private void ToggleOrderSelection()
        {
            isOrderSelected = !isOrderSelected; // 状態をトグル
            orderFlag = isOrderSelected ? "注文" : "詳細"; // 表示するフラグを更新
            label2.Text = orderFlag; // 状態をラベルに表示
        }

        private void UpdateFlagButtonText()
        {
            // b_FlagSelectorのテキストを現在の状態に合わせる
            b_FormSelector.Text = orderFlag;
        }

    }
}
