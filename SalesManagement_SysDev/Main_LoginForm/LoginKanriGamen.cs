using Microsoft.Data.SqlClient;
using SalesManagement_SysDev.Classまとめ;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;// 各種クラスを使用する
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using SalesManagement_SysDev.juchuu_uriage;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using SalesManagement_SysDev.Entity;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class LoginKanriGamen : Form
    {

        private ClassChangeForms changeForm;
        public LoginKanriGamen()
        {
            InitializeComponent();
            changeForm = new ClassChangeForms(this); // インスタンスを作成  
        }

        private void close_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToMainMenu();
        }

        private void b_PassChange_Click(object sender, EventArgs e)
        {
        }

        private void b_NewAccount_Click(object sender, EventArgs e)
        {
        }

        private void LoginKanriGamen_Load(object sender, EventArgs e)
        {
            // デフォルト選択
            ComboLog.SelectedIndex = 0;
            ComboGamen.SelectedIndex = 0;
            ComboMode.SelectedIndex = 0;
            ComboShori.SelectedIndex = 0;

            // イベントハンドラを設定
            ComboLog.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            TB_ID.KeyDown += TB_ID_KeyDown_1;
            dateTimePicker1.Visible = false;
            SetupNumericOnlyTextBoxes();

            DisplayLoginLog();
        }

        private void clear_Click(object sender, EventArgs e)
        {
        }

        private void b_PCOK_Click(object sender, EventArgs e)
        {
            UpdatePassword();

        }
        private void UpdatePassword()
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void clear_Click_1(object sender, EventArgs e)
        {
            cleartext();
        }
        private void cleartext()
        {
            TB_Log.Text = string.Empty;
            TB_ID.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;

            ComboLog.SelectedIndex = 0;
            ComboGamen.SelectedIndex = 0;
            ComboMode.SelectedIndex = 0;
            ComboShori.SelectedIndex = 0;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 選択された項目に応じて動作を切り替える
            if (ComboLog.SelectedItem.ToString() == "ログイン日")
            {
                TB_Log.Visible = false;
                dateTimePicker1.Visible = true; // DateTimePicker を表示
            }
            else
            {
                TB_Log.Visible = true; // テキストボックスを表示
                dateTimePicker1.Visible = false; // DateTimePicker を隠す
            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TB_ID.KeyPress += NumericTextBox_KeyPress;

        }

        // 半角数字のみを許可するKeyPressイベントハンドラ
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 全角文字を半角文字に変換する
        /// </summary>
        /// <param name="input">変換対象の文字列</param>
        /// <returns>半角文字列</returns>
        private string ConvertToHalfWidth(string input)
        {
            return input.Normalize(NormalizationForm.FormKC); // 全角→半角変換
        }

        private void TB_ID_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter キーが押された場合
            {
                TextBoxBase textBox = sender as TextBoxBase;
                // テキストを全角から半角に変換
                textBox.Text = ConvertToHalfWidth(textBox.Text);

                // カーソルを末尾に移動
                textBox.SelectionStart = textBox.Text.Length;

                // Enter キーの既定動作を抑制
                e.SuppressKeyPress = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int selectedID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                // 詳細情報の取得
                //List<Detail> details = GetDetailsByID(selectedID);

                //↑のコードは詳細情報の取得に使えるけどまだテーブルが無くてエラーが出るから
                //コード書くときにコメント解除してください

                // 右側のDataGridViewをクリア
                dataGridView2.Rows.Clear();

                // 詳細情報を右側のDataGridViewに追加
                /*foreach (var detail in details)
                {
                    dataGridView2.Rows.Add(detail.DetailID, detail.DetailName);
                }これも！！！！！！！！！！！！！！！！！！*/
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            // 行インデックスが有効かどうかをチェック   
            if (rowIndex >= 0)
            {
                // 行データを取得   
                DataGridViewRow row = dataGridView2.Rows[rowIndex];

                ComboGamen.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                ComboMode.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                ComboShori.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
                TB_ID.Text = row.Cells["受注ID"].Value?.ToString() ?? string.Empty;
            }
        }

        public void DisplayLoginLog()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // LoginHistoryLog テーブルのデータを取得
                    var logData = context.LoginHistoryLogs
                        .Select(o => new
                        {
                            o.ID,                  // 表示するカラム (例: ID)
                            o.LoginID,             // 表示するカラム (例: LoginID)
                            o.LoginDateTime,       // 表示するカラム (例: ログイン日時)
                        })
                        .ToList();

                    // DataGridView にデータをバインド
                    dataGridView1.DataSource = logData;
                }
            }
            catch (Exception ex)
            {
                // 例外発生時にエラーメッセージを表示
                MessageBox.Show($"エラー: {ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /*public class LogHistory_EMP
        {

            public int logID { get; set; }
            public string empID { get; set; }
            public string empName { get; set; }
            public DateTime LoginDateTime { get; set; }
        }

        public class ApplicationDbContext : DbContext
        {
            public DbSet<LogHistory_EMP> LogHistory_EMPs { get; set; }

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Fluent APIを使用してempIDを主キーとして設定
                modelBuilder.Entity<LogHistory_EMP>()
                    .HasKey(e => e.logID);
            }
        }

        class Program
        {
            // グローバル変数として社員情報を定義
            static string globalEmpID = GlobalEmp.EmployeeID;
            static string globalEmpName = GlobalEmp.EmployeeName;
            static DateTime globalLoginDateTime = GlobalEmp.dateNow;

            static void database(string[] args)
            {
                try
                {
                    // DbContextのインスタンス作成
                    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

                    // データベース接続文字列を設定（接続文字列をセキュリティ的に管理する方法）
                    string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=SalesManagement;Integrated Security=True";
                    optionsBuilder.UseSqlServer(connectionString);

                    // データベースに接続
                    using (var context = new ApplicationDbContext(optionsBuilder.Options))
                    {
                        // グローバル変数のデータをLogHistory_EMPテーブルに追加
                        var logHistory = new LogHistory_EMP
                        {
                            empID = globalEmpID,
                            empName = globalEmpName,
                            LoginDateTime = globalLoginDateTime
                        };

                        // LogHistory_EMPテーブルにデータを追加
                        context.LogHistory_EMPs.Add(logHistory);

                        // 変更をデータベースに保存
                        context.SaveChanges();
                    }

                    Console.WriteLine("ログイン情報がデータベースに追加されました。");
                }
                catch (Exception ex)
                {
                    // エラーハンドリング
                    Console.WriteLine($"エラーが発生しました: {ex.Message}");
                }
            }
        }*/

    }
}
