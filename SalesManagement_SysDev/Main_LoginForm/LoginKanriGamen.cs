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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.VisualBasic.Logging;

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
            DisplayRogDetail();


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

            DisplayLoginLog();
            DisplayRogDetail();
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
            // ヘッダー行または無効なセルのクリックを無視
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            try
            {
                // クリックした行の指定列からデータを取得
                var clickedData = dataGridView1.Rows[e.RowIndex].Cells[0].Value; // 列番号0を確認してください

                if (clickedData != null)
                {
                    // 詳細画面を更新
                    DisplayDataIn2Grid(clickedData);
                }
            }
            catch (Exception ex)
            {
                // エラー処理
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }

        private void DisplayDataIn2Grid(object clickedData)
        {
            try
            {
                // フィルタリングしたデータを取得
                var filteredData = GetDataFor2Grid(clickedData);

                // データが存在しない場合の処理
                if (filteredData == null || filteredData.Count == 0)
                {
                    MessageBox.Show("該当するデータがありません。");
                    return;
                }

                // 右側のグリッドにデータを設定
                dataGridView2.DataSource = null; // 再バインド前にデータをクリア
                dataGridView2.DataSource = filteredData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }

        private List<LoginHistoryLogDetail> GetDataFor2Grid(object clickedData)
        {
            try
            {
                // クリックされたデータに基づいてフィルタリング処理を実行
                // 例: データベースクエリやリスト操作を行う
                using (var context = new SalesManagementContext())
                {
                    // クリックされたデータに基づいてデータを取得
                    int clickedId = Convert.ToInt32(clickedData);
                    var result = context.LoginHistoryLogDetails
                        .Where(log => log.ID == clickedId) // フィルタ条件
                        .ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"データ取得中にエラーが発生しました: {ex.Message}");
                return new List<LoginHistoryLogDetail>();
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

                ComboGamen.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
                ComboMode.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
                ComboShori.Text = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString();
                TB_ID.Text = row.Cells["LogID"].Value?.ToString() ?? string.Empty;
            }
        }

        public void DisplayLoginLog()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var loginData = context.LoginHistoryLogs
                         .Join<LoginHistoryLog, MEmployee, string, dynamic>(
                            context.MEmployees,               // 結合するテーブル
                            log => log.LoginID,               // 主テーブルの結合キー (LoginHistoryLogs の LoginID)
                            emp => emp.EmID.ToString(),                  // 結合先テーブルの結合キー (MEmployees の EmID)
                              (log, emp) => new                 // 結合後の結果
                              {
                                  log.ID,                       // LoginHistoryLogs の ID
                                  log.LoginID,                  // LoginHistoryLogs の LoginID
                                  EmployeeName = emp.EmName,    // MEmployees の社員名 (EmName)
                                  log.LoginDateTime             // LoginHistoryLogs の LoginDateTime
                              }
                     )
                     .ToList();


                    // データグリッドにバインド
                    dataGridView1.DataSource = loginData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー: {ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayRogDetail()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var logData = context.LoginHistoryLogDetails
                        .Select(o => new
                        {
                            o.DetailID,
                            o.ID,
                            o.Display,
                            o.Mode,
                            o.Process,
                            o.LogID,
                            o.AcceptDateTime
                        })
                        .ToList();

                    // DataGridView にデータをバインド
                    dataGridView2.DataSource = logData;
                }
            }
            catch (Exception ex)
            {
                // 例外発生時にエラーメッセージを表示
                MessageBox.Show($"エラー: {ex.Message}", "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShousaiKensaku_Click(object sender, EventArgs e)
        {
            string comboBox1Value = ComboGamen.SelectedItem?.ToString(); // ComboBox1 の選択された値
            string comboBox2Value = ComboMode.SelectedItem?.ToString(); // ComboBox2 の選択された値
            string comboBox3Value = ComboShori.SelectedItem?.ToString(); // ComboBox3 の選択された値
            string textBoxValue = TB_ID.Text; // TextBox1 のテキスト

            using (var context = new SalesManagementContext())
            {
                // 基本的なクエリを作成
                var query = context.LoginHistoryLogDetails.AsQueryable();

                // それぞれの条件に基づいてフィルタリングを追加
                if (ComboGamen.SelectedIndex > 0 && !string.IsNullOrEmpty(comboBox1Value))
                {
                    query = query.Where(x => x.Display.Contains(comboBox1Value)); // Display プロパティを使う
                }

                // ComboBox2の選択されたインデックスが 0 より大きい場合のみ、その条件を追加
                if (ComboMode.SelectedIndex > 0 && !string.IsNullOrEmpty(comboBox2Value))
                {
                    query = query.Where(x => x.Mode.Contains(comboBox2Value)); // Mode プロパティを使う
                }

                // ComboBox3の選択されたインデックスが 0 より大きい場合のみ、その条件を追加
                if (ComboShori.SelectedIndex > 0 && !string.IsNullOrEmpty(comboBox3Value))
                {
                    query = query.Where(x => x.Process.Contains(comboBox3Value)); // Process プロパティを使う
                }
                if (!string.IsNullOrEmpty(textBoxValue))
                {
                    query = query.Where(x => x.LogID.ToString() == (textBoxValue));
                }

                // 結果を取得し、DataGridView に表示
                var result = query.ToList();
                dataGridView2.DataSource = result;
            }
        }

        private void LoginKensaku_Click(object sender, EventArgs e)
        {
            string comboBox2Value = ComboLog.SelectedItem?.ToString();
            string textBoxValue = TB_Log.Text?.Trim();
            DateTime? logDate = dateTimePicker1.Checked ? (DateTime?)dateTimePicker1.Value.Date : null;
            string ename = "";

            if (ComboLog.SelectedIndex == 0 ||
                (string.IsNullOrEmpty(textBoxValue) && logDate == null))
            {
                MessageBox.Show("検索条件を入力してください。");
                return;
            }

            try
            {
                using (var context = new SalesManagementContext())
                {
                    var query = context.LoginHistoryLogs.AsQueryable();

                    // 社員IDでの検索
                    if (comboBox2Value == "社員ID" && !string.IsNullOrEmpty(textBoxValue))
                    {
                        query = query.Where(x => x.LoginID == textBoxValue);
                    }

                    // 社員名での検索
                    if (comboBox2Value == "社員名" && !string.IsNullOrEmpty(textBoxValue))
                    {
                        query = context.LoginHistoryLogs;
                        query.Join<LoginHistoryLog, MEmployee, string, dynamic>(
                           context.MEmployees,               // 結合するテーブル
                           log => log.LoginID,               // 主テーブルの結合キー (LoginHistoryLogs の LoginID)
                           emp => emp.EmID.ToString(),                  // 結合先テーブルの結合キー (MEmployees の EmID)
                             (log, emp) => new                 // 結合後の結果
                             {
                                 log.ID,                       // LoginHistoryLogs の ID
                                 log.LoginID,                  // LoginHistoryLogs の LoginID
                                 ename = emp.EmName,    // MEmployees の社員名 (EmName)
                                 log.LoginDateTime             // LoginHistoryLogs の LoginDateTime
                             }
                       )
                       .ToList();
                        ename = TB_Log.Text;
                    }

                    // ログイン日での検索
                    if (comboBox2Value == "ログイン日" && logDate.HasValue)
                    {
                        query = query.Where(o => o.LoginDateTime.Date == logDate.Value);
                    }

                    var result = query.Select(x => new
                    {
                        x.ID,
                        x.LoginID,
                        ename,       // 社員名のみ表示
                        LoginDate = x.LoginDateTime.ToString("yyyy-MM-dd HH:mm:ss") // ログイン日時をフォーマットして表示
                    })
                    .ToList();

                    dataGridView1.DataSource = result;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }


        }
    }
}
