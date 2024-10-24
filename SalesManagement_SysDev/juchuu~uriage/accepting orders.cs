using System;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL関連クラスの使用を許可
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using Microsoft.Data.SqlClient;
using System.Data;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;

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

            labelStatus.labelstatus(label2, b_kakutei);
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
            labelStatus.labelstatus(label2, b_kakutei);
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
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            currentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
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
            currentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // SQLコマンドを作成
                    string query = @"INSERT INTO T_Order (OrId, SoId, EmId, ClId, ClCharge, OrDate, OrStateFlag, OrFlag, OrHidden)
                                     VALUES (@OrId, @SoId, @EmId, @ClId, @ClCharge, @OrDate, @OrStateFlag, @OrFlag, @OrHidden)";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登録に失敗しました: " + ex.Message);
            }
        }
        private void B_iti_Click_1(object sender, EventArgs e)
        {
            currentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }
        private void b_kakutei_Click(object sender, EventArgs e)
        {
            // label2の内容を確認  
            string status = label2.Text;

            // ステータスに応じて処理を実行  
            switch (status)
            {
                case "更新":
                    UpdateOrder();
                    break;
                case "登録":
                    RegisterOrder();
                    break;
                case "一覧":
                    DisplayOrders();
                    break;
                default:
                    MessageBox.Show("無効な操作です。"); // 無効な操作の場合  
                    break;
            }
        }

        // 更新メソッド 
        private void UpdateOrder()
        {
            // 更新処理の具体的なコードをここに記述 
            // 入力された受注情報を取得
            string jyutyuID = TBJyutyuID.Text;
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string tantoName = TBTantoName.Text;
            DateTime jyutyuDate = date.Value;
            bool tyumonFlag = TyumonFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            // データベース接続コードをここに記述 
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kento\\source\\repos\\SalesManagement_SysDev_git\\SalesManagement_SysDev\\DataBase_1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE T_Order SET ShopID=@shopID, ShainID=@shainID, KokyakuID=@kokyakuID, TantoName=@tantoName, JyutyuDate=@jyutyuDate, TyumonFlag=@tyumonFlag, DelFlag=@delFlag, Riyuu=@riyuu WHERE JyutyuID=@jyutyuID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // パラメータの設定
                    cmd.Parameters.AddWithValue("@shopID", shopID);
                    cmd.Parameters.AddWithValue("@shainID", shainID);
                    cmd.Parameters.AddWithValue("@kokyakuID", kokyakuID);
                    cmd.Parameters.AddWithValue("@tantoName", tantoName);
                    cmd.Parameters.AddWithValue("@jyutyuDate", jyutyuDate);
                    cmd.Parameters.AddWithValue("@tyumonFlag", tyumonFlag);
                    cmd.Parameters.AddWithValue("@delFlag", delFlag);
                    cmd.Parameters.AddWithValue("@riyuu", riyuu);
                    cmd.Parameters.AddWithValue("@jyutyuID", jyutyuID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "更新が成功しました。" : "更新に失敗しました。");
                }
            }
        }

        // 登録メソッド 
        private void RegisterOrder()
        {
            // 登録処理の具体的なコードをここに記述 
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string tantoName = TBTantoName.Text;
            DateTime jyutyuDate = date.Value;
            bool tyumonFlag = TyumonFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            // データベース接続コードをここに記述 
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kento\\source\\repos\\SalesManagement_SysDev_git\\SalesManagement_SysDev\\DataBase_1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO T_Order (ShopID, ShainID, KokyakuID, TantoName, JyutyuDate, TyumonFlag, DelFlag, Riyuu) VALUES (@shopID, @shainID, @kokyakuID, @tantoName, @jyutyuDate, @tyumonFlag, @delFlag, @riyuu)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // パラメータの設定
                    cmd.Parameters.AddWithValue("@shopID", shopID);
                    cmd.Parameters.AddWithValue("@shainID", shainID);
                    cmd.Parameters.AddWithValue("@kokyakuID", kokyakuID);
                    cmd.Parameters.AddWithValue("@tantoName", tantoName);
                    cmd.Parameters.AddWithValue("@jyutyuDate", jyutyuDate);
                    cmd.Parameters.AddWithValue("@tyumonFlag", tyumonFlag);
                    cmd.Parameters.AddWithValue("@delFlag", delFlag);
                    cmd.Parameters.AddWithValue("@riyuu", riyuu);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected > 0 ? "登録が成功しました。" : "登録に失敗しました。");
                }
            }
        }

        // 一覧表示メソッド 
        private void DisplayOrders()
        {
            // 一覧表示処理の具体的なコードをここに記述 
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kento\\source\\repos\\SalesManagement_SysDev_git\\SalesManagement_SysDev\\DataBase_1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM T_Order"; // 必要に応じて条件を追加 
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        // DataGridViewにデータを表示 
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void b_reg_Click_1(object sender, EventArgs e)
        {
            currentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }
    }
}
