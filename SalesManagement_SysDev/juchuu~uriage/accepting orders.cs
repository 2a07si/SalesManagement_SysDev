using System;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL関連クラスの使用を許可
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using Microsoft.Data.SqlClient;

namespace SalesManagement_SysDev
{
    public partial class acceptingorders : Form
    {
        // データベース接続文字列を定義
        string connectionString = "ここにパス入力";
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager; // 権限管理クラス

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
        }

        // メインメニューに戻る 
        private void close_Click_1(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移 
        }

        // 注文管理画面に遷移 
        private void b_ord_Click_2(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            currentStatus.SearchStatus(label2);
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 注文管理画面に遷移 
        }


        private void label2_Click(object sender, EventArgs e)
        {

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
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            currentStatus.ListStatus(label2);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            currentStatus.ListStatus(label2);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // 更新クエリの作成
                    string query = "UPDATE T_Order SET SoId = @SoId, EmId = @EmId, ClId = @ClId, ClCharge = @ClCharge, " +
                                   "OrDate = @OrDate, OrStateFlag = @OrStateFlag, OrHidden = @OrHidden " +
                                   "WHERE OrId = @OrId";

                    SqlCommand command = new SqlCommand(query, connection);

                    // テキストボックスやDateTimePickerから値を取得してパラメータに設定
                    command.Parameters.AddWithValue("@OrId", Convert.ToInt32(TBJyutyuID.Text));
                    command.Parameters.AddWithValue("@SoId", Convert.ToInt32(TBShopID.Text));
                    command.Parameters.AddWithValue("@EmId", Convert.ToInt32(TBShainID.Text));
                    command.Parameters.AddWithValue("@ClId", Convert.ToInt32(TBKokyakuID.Text));
                    command.Parameters.AddWithValue("@ClCharge", TBTantoName.Text);
                    command.Parameters.AddWithValue("@OrDate", date.Value);
                    command.Parameters.AddWithValue("@OrStateFlag", TyumonFlag.Checked ? 1 : 0);
                    command.Parameters.AddWithValue("@OrHidden", TBRiyuu.Text);

                    // データベース接続を開いて更新を実行
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    // 成功メッセージ
                    MessageBox.Show("受注情報を更新しました");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新に失敗しました: " + ex.Message);
                }
            }
        }
        private void b_reg_Click(object sender, EventArgs e)
        {
            currentStatus.ListStatus(label2);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQLコマンドを作成
                    string query = @"INSERT INTO T_Order (OrId, SoId, EmId, ClId, ClCharge, OrDate, OrStateFlag, OrFlag, OrHidden)
                                     VALUES (@OrId, @SoId, @EmId, @ClId, @ClCharge, @OrDate, @OrStateFlag, @OrFlag, @OrHidden)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 各パラメータをテキストボックスから取得して設定
                        command.Parameters.AddWithValue("@OrId", int.Parse(TBJyutyuID.Text));
                        command.Parameters.AddWithValue("@SoId", int.Parse(TBShopID.Text));
                        command.Parameters.AddWithValue("@EmId", int.Parse(TBShainID.Text));
                        command.Parameters.AddWithValue("@ClId", int.Parse(TBKokyakuID.Text));
                        command.Parameters.AddWithValue("@ClCharge", TBTantoName.Text);
                        command.Parameters.AddWithValue("@OrDate", date.Value);
                        command.Parameters.AddWithValue("@OrStateFlag", TyumonFlag.Checked ? 1 : 0);
                        command.Parameters.AddWithValue("@OrFlag", DelFlag.Checked ? 1 : 0);
                        command.Parameters.AddWithValue("@OrHidden", TBRiyuu.Text);

                        // データベースに接続してコマンドを実行
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        // 成功メッセージを表示
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("データが正常に登録されました。");
                        }
                        else
                        {
                            MessageBox.Show("データの登録に失敗しました。");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーメッセージを表示
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }
    }
}
