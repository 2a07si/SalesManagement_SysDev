﻿using System;
using System.Linq;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ; // 各種クラスを使用する
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using SalesManagement_SysDev.juchuu_uriage;
using Microsoft.EntityFrameworkCore;
using SalesManagement_SysDev.Entity;

namespace SalesManagement_SysDev
{
    public partial class stock : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger;
        private ClassTimerManager timerManager;
        private ClassAccessManager accessManager;
        public stock()
        {
            InitializeComponent();
            this.mainForm = new Form();
            timer1.Start();
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
            this.formChanger = new ClassChangeForms(this);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*DateTime dateTime = DateTime.Now;
            labeltime.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            labeldate.Text = now.ToString("yyyy年MM月dd日");*/
        }

        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        private void b_emp_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToEmployeeForm();
        }

        private void b_mer_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMerchandiseForm();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToCustomerForm();
        }

        private void stock_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_emp,
                b_mer,
                b_cus,
            });
            DisplayStock();
            SetupNumericOnlyTextBoxes();
            CurrentStatus.RegistrationStatus(label2);
            TBZaikoID.Enabled = false;
            TBZaikoID.BackColor = Color.Gray;
            TBZaikoID.Text = "";
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBZaikoID.Text = "";
            TBSyohinID.Text = "";
            TBZaiko.Text = "";
            StFlag.Checked = false;
            CurrentStatus.ResetStatus(label2);
            TBZaikoID.BackColor = Color.White;
            colorReset();
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBZaikoID.Enabled = false;
            TBZaikoID.BackColor = Color.Gray;
            TBZaikoID.Text = "";
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBZaikoID.Enabled = true;
            TBZaikoID.BackColor = Color.White;
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBZaikoID.Enabled = true;
            TBZaikoID.BackColor = Color.White;
            DisplayStock();
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBZaikoID.Enabled = true;
            TBZaikoID.BackColor = Color.White;
        }


        private void b_kakutei_Click(object sender, EventArgs e)
        {
            colorReset();
            HandleStockOperation();
        }
        private void HandleStockOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateStock();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterStock();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayStock();
                    break;
                case CurrentStatus.Status.検索:
                    SearchStock();
                    break;
                default:
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


        private void UpdateStock()
        {
            string zaikoID = TBZaikoID.Text;
            string syohinID = TBSyohinID.Text;
            string zaiko = TBZaiko.Text;
            bool stflag = StFlag.Checked;


            if (TBZaikoID.Text == "")
            {
                TBZaikoID.BackColor = Color.Yellow;
                TBZaikoID.Focus();
                MessageBox.Show("在庫IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBSyohinID.Text == "")
            {
                TBSyohinID.BackColor = Color.Yellow;
                TBSyohinID.Focus();
                MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBZaiko.Text == "")
            {
                TBZaiko.BackColor = Color.Yellow;
                TBZaiko.Focus();
                MessageBox.Show("在庫数を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {
                var product = context.MProducts.FirstOrDefault(p => p.PrID == int.Parse(syohinID));
                if (product == null)
                {
                    MessageBox.Show("商品IDが見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var stock = context.TStocks.SingleOrDefault(s => s.StID.ToString() == zaikoID);
                if (stock != null)
                {
                    stock.StID = int.Parse(zaikoID);
                    stock.PrID = int.Parse(syohinID);
                    stock.StQuantity = int.Parse(zaiko);
                    stock.StFlag = stflag ? 1 : 0;


                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    DisplayStock();
                    Log_Stock(stock.StID);
                    ResetYellowBackgrounds(this);
                }
                else
                {
                    MessageBox.Show("該当する在庫情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterStock()
        {
            string zaikoID = TBZaikoID.Text;
            string syohinID = TBSyohinID.Text;
            string zaiko = TBZaiko.Text;
            bool stflag = StFlag.Checked;


            using (var context = new SalesManagementContext())
            {
                int shouhin;

                if (TBSyohinID.Text == "")
                {
                    TBSyohinID.BackColor = Color.Yellow;
                    TBSyohinID.Focus();
                    MessageBox.Show("商品IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TBZaiko.Text == "")
                {
                    TBZaiko.BackColor = Color.Yellow;
                    TBZaiko.Focus();
                    MessageBox.Show("在庫数を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(syohinID, out shouhin) || !context.MProducts.Any(s => s.PrID == shouhin))
                {
                    MessageBox.Show("商品IDが見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var product = context.MProducts.FirstOrDefault(p => p.PrID == shouhin);
                if (product == null)
                {
                    MessageBox.Show("商品IDが見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // 安全在庫数チェック
                int inputZaiko = int.Parse(zaiko); // 半角数字として入力される前提で直接変換

                if (inputZaiko < product.PrSafetyStock)
                {
                    var result = MessageBox.Show(
                        "安全在庫数を下回る在庫数ですが、よろしいですか？",
                        "確認",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return; // 処理中断
                    }
                }
                var newstock = new TStock
                {
                    PrID = int.Parse(syohinID),
                    StQuantity = int.Parse(zaiko),
                    StFlag = stflag ? 1 : 0,
                };

                context.TStocks.Add(newstock);
                try
                {
                    context.SaveChanges(); MessageBox.Show("登録が成功しました。");
                    DisplayStock();
                    Log_Stock(newstock.StID);
                    ResetYellowBackgrounds(this);
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
        }

        private void DisplayStock()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、全ての在庫情報を取得して並べ替え
                    var stock = checkBox_2.Checked
                        ? context.TStocks.OrderBy(s => s.PrID).ToList()
                        // チェックされていなければ、StFlagが1のものを除外して並べ替え
                        : context.TStocks.Where(s => s.StFlag != 1).OrderBy(s => s.PrID).ToList();

                    // DataGridView にデータをバインド
                    dataGridView1.DataSource = stock.Select(s => new
                    {
                        在庫ID = s.StID,
                        商品ID = s.PrID,
                        在庫数 = s.StQuantity,
                        管理フラグ = s.StFlag
                    }).ToList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchStock()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var zaikoID = TBZaikoID.Text.Trim();       // 受注ID 
                var syohinID = TBSyohinID.Text.Trim();           // 営業所ID 
                var zaiko = TBZaiko.Text.Trim();



                // 基本的なクエリ 
                var query = context.TStocks.AsQueryable();

                // 受注IDを検索条件に追加 
                if (!string.IsNullOrEmpty(zaikoID) && int.TryParse(zaikoID, out int parsedzaikoID))
                {
                    query = query.Where(s => s.StID == parsedzaikoID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(syohinID) && int.TryParse(syohinID, out int parsedsyohinID))
                {
                    query = query.Where(s => s.PrID == parsedsyohinID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(zaiko) && int.TryParse(zaiko, out int parsedzaiko))
                {
                    query = query.Where(s => s.StQuantity == parsedzaiko);
                }

                // 結果を取得 
                var stock = query.ToList();

                if (stock.Any())
                {
                    // dataGridView1 に結果を表示 
                    dataGridView1.DataSource = stock.Select(s => new
                    {
                        在庫ID = s.StID,
                        商品ID = s.PrID,
                        在庫数 = s.StQuantity,
                        在庫管理フラグ = s.StFlag,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する在庫情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア 
                }
            }
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
                        TBZaikoID.Text = "";
                    }
                    else
                    {
                        TBZaikoID.Text = row.Cells["在庫ID"].Value.ToString();
                    }
                    // 各テキストボックスにデータを入力
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBZaiko.Text = row.Cells["在庫数"].Value.ToString();
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

        private void LimitTextLength(TextBox textBox, int maxLength)
        {
            if (textBox.Text.Length > maxLength)
            {
                // 文字数制限を超えたら、超過部分を切り捨てる
                textBox.Text = textBox.Text.Substring(0, maxLength);
                textBox.SelectionStart = maxLength;  // カーソル位置を末尾に設定
            }
        }

        private void TBZaikoID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyohinID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBZaiko_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 4);
        }
        private void colorReset()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    TBZaikoID.BackColor = Color.Gray;
                    break;
                default:
                    TBZaikoID.BackColor = SystemColors.Window;
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBZaiko.BackColor = SystemColors.Window;
                    break;
            }

        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBZaikoID.KeyPress += NumericTextBox_KeyPress;
            TBZaiko.KeyPress += NumericTextBox_KeyPress;
            TBSyohinID.KeyPress += NumericTextBox_KeyPress;

        }

        // 半角数字のみを許可するKeyPressイベントハンドラ
        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字とBackspace以外は入力を無効化
            if ((e.KeyChar < '0' || e.KeyChar > '9') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void b_emp_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TWarehousings.Count(order => order.WaShelfFlag == 0 || order.WaShelfFlag == null);
                if (count > 0)
                {
                    GlobalBadge badge = new GlobalBadge(" "); // 通知数を指定

                    // ボタンを取得
                    Button button = sender as Button;

                    // バッジを描画
                    if (button != null)
                    {
                        badge.pinpoint(e, button);
                    }
                }
            }
        }


        private void Log_Stock(int id)
        {
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
                            Display = "在庫",
                            Mode = "",
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
        private void ResetYellowBackgrounds(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // テキストボックスかつ背景色が黄色かを判定
                if (control is TextBox textBox && textBox.BackColor == Color.Yellow)
                {
                    textBox.BackColor = SystemColors.Window; // 元の背景色に戻す
                }

                // 再帰的に子コントロールをチェック
                if (control.HasChildren)
                {
                    ResetYellowBackgrounds(control);
                }
            }
        }
    }
}
