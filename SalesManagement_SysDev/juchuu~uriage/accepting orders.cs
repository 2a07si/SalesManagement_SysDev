﻿using System;
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
        private CurrentStatus currentStatus;


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
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }
        // ボタンクリックイベント
        private void b_kakutei_Click(object sender, EventArgs e)
        {
        }

        // 状態リセットメソッド（必要ならボタンにバインド）
        private void ResetStatus()
        {
            CurrentStatus.ResetStatus(label2);
        }

        private void b_kakutei_Click_1(object sender, EventArgs e)
        {            // 現在の状態を確認
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateOrder();
                    break;

                case CurrentStatus.Status.登録:
                    RegisterOrder();
                    break;

                case CurrentStatus.Status.一覧:
                    MessageBox.Show("一覧状態で動作してます。");
                    DisplayOrders();
                    MessageBox.Show("DisplayOrdersが終了しました。");
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
            string riyuu = TBRiyuu.Text;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kento\\source\\repos\\SalesManagement_SysDev_git\\SalesManagement_SysDev\\DataBase_1.mdf;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE T_Order SET ShopID=@shopID, ShainID=@shainID, KokyakuID=@kokyakuID, TantoName=@tantoName, JyutyuDate=@jyutyuDate, TyumonFlag=@tyumonFlag, DelFlag=@delFlag, Riyuu=@riyuu WHERE JyutyuID=@jyutyuID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
            string shopID = TBShopID.Text;
            string shainID = TBShainID.Text;
            string kokyakuID = TBKokyakuID.Text;
            string tantoName = TBTantoName.Text;
            DateTime jyutyuDate = date.Value;
            bool tyumonFlag = TyumonFlag.Checked;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kento\\source\\repos\\SalesManagement_SysDev_git\\SalesManagement_SysDev\\DataBase_1.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // クエリを正しい列名に修正
                    string query = "INSERT INTO T_Order (SoID, EmID, ClID, ClCharge, OrDate, OrStateFlag, OrFlag, OrHidden) " +
                                   "VALUES (@soID, @emID, @clID, @clCharge, @orDate, @orStateFlag, @orFlag, @orHidden)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // パラメータの追加 
                        cmd.Parameters.AddWithValue("@soID", shopID);
                        cmd.Parameters.AddWithValue("@emID", shainID);
                        cmd.Parameters.AddWithValue("@clID", kokyakuID);
                        cmd.Parameters.AddWithValue("@clCharge", tantoName);
                        cmd.Parameters.AddWithValue("@orDate", jyutyuDate);
                        cmd.Parameters.AddWithValue("@orStateFlag", tyumonFlag);
                        cmd.Parameters.AddWithValue("@orFlag", delFlag);
                        cmd.Parameters.AddWithValue("@orHidden", riyuu);

                        // SQLクエリの実行 
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "登録が成功しました。" : "登録に失敗しました。");
                    }
                }
            }
            catch (SqlException ex)
            {
                // SQLエラー時のエラーメッセージ表示 
                MessageBox.Show($"データベースエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // その他のエラー時のエラーメッセージ表示 
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 一覧表示メソッド
        private void DisplayOrders()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kento\\source\\repos\\SalesManagement_SysDev_git\\SalesManagement_SysDev\\DataBase_1.mdf;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM T_Order";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count >= 0)
                    {
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        MessageBox.Show("データが見つかりませんでした。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました: " + ex.Message);
            }
        }


        private void b_reg_Click_1(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_reg_Click_2(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }
    }
}

