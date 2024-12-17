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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using SalesManagement_SysDev.Entity;

namespace SalesManagement_SysDev
{
    public partial class customer : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger;
        private ClassDateNamelabel dateNamelabel;
        private ClassAccessManager accessManager;
        private DateTime timestamp = DateTime.Now;
        public customer()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(customer_Load);
            this.dateNamelabel = new ClassDateNamelabel(label_id, label_ename);
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            
        }
        private void customer_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_emp,
                b_mer,
                b_sto,
            });
            DisplayCustomer();
            SetupNumericOnlyTextBoxes();
            CurrentStatus.RegistrationStatus(label2);
            TBKokyakuID.Enabled = false;
            TBKokyakuID.BackColor = Color.Gray;
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

        private void b_sto_Click(object sender, EventArgs e)
        {
            // formChanger.NavigateToStockForm();
            formChanger.NavigateToStockForm();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBKokyakuID.Text = "";
            TBShopID.Text = "";
            TBKokyakuName.Text = "";
            TBJyusyo.Text = "";
            TBYuubinNo.Text = "";
            TBTellNo.Text = "";
            TBFax.Text = "";
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            CurrentStatus.ResetStatus(label2);
            TBKokyakuID.BackColor = Color.White;
            colorReset();
            ResetYellowBackgrounds(this);
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBKokyakuID.Enabled = false;
            TBKokyakuID.BackColor = Color.Gray;
            TBKokyakuID.Text = "";
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBKokyakuID.Enabled = true;
            TBKokyakuID.BackColor = Color.White;
        }

        private void b_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBKokyakuID.Enabled = true;
            TBKokyakuID.BackColor = Color.White;
            DisplayCustomer();
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBKokyakuID.Enabled = true;
            TBKokyakuID.BackColor = Color.White;
        }

        private void b_kakutei_Click(object sender, EventArgs e)
        {

            colorReset();
            HandleCustomerOperation();
        }
        private void HandleCustomerOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateCustomer();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterCustomer();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayCustomer();
                    break;
                case CurrentStatus.Status.検索:
                    SearchCustomer();
                    break;
                default:
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        //
        private bool CheckTBValue(TextBox textBox, string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                textBox.BackColor = Color.Yellow;
                textBox.Focus();
                MessageBox.Show($":101\n必要な入力がありません。（{fieldName}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            textBox.BackColor = SystemColors.Window; // 問題ない場合、背景色をリセット
            return true;
        }

        private void NotFound(string itemName, string itemId)
        {
            MessageBox.Show($":204\n該当の{itemName}が見つかりません。（{itemName}ID: {itemId}）",
                            "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateCustomer()
        {
            string kokyakuID    = TBKokyakuID.Text;
            string shopID       = TBShopID.Text;
            string kokyakuname  = TBKokyakuName.Text;
            string juusho       = TBJyusyo.Text;
            string yuubinbangou = TBYuubinNo.Text;
            string tel          = TBTellNo.Text;
            string fax          = TBFax.Text;
            bool flag           = DelFlag.Checked;

            // 必須項目のチェック
            if (CheckTBValue(TBKokyakuID, kokyakuID, "顧客ID"))     return;
            if (CheckTBValue(TBShopID, shopID, "営業所ID"))         return;
            if (CheckTBValue(TBKokyakuName, kokyakuname, "顧客名")) return;
            if (CheckTBValue(TBYuubinNo, yuubinbangou, "郵便番号")) return;
            if (CheckTBValue(TBJyusyo, juusho, "住所"))             return;
            if (CheckTBValue(TBTellNo, tel, "電話番号"))            return;
            if (CheckTBValue(TBFax, fax, "FAX"))                    return;
            if (Kuraberu_kun.Kuraberu_chan("顧客", null, "更新", int.Parse(kokyakuID), timestamp) == false)
            { return; }

            using (var context = new SalesManagementContext())
            {
                var customer = context.MClients.SingleOrDefault(c => c.ClID.ToString() == kokyakuID);
                if (customer != null)
                {
                    customer.SoID      = int.Parse(shopID);
                    customer.ClPostal  = yuubinbangou;
                    customer.ClName    = kokyakuname;
                    customer.ClID      = int.Parse(kokyakuID);
                    customer.ClAddress = juusho;
                    customer.ClPhone   = tel;
                    customer.ClFax     = fax;
                    customer.ClFlag    = flag ? 1 : 0;
                    customer.ClHidden  = TBRiyuu.Text;

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    DisplayCustomer();
                    Log_Customer(customer.ClID);
                    ResetYellowBackgrounds(this);
                }
                else
                {
                    NotFound("顧客ID", kokyakuID);
                }
            }
        }

        private void RegisterCustomer()
        {
            string kokyakuID = TBKokyakuID.Text;
            string shopID = TBShopID.Text;
            string kokyakuname = TBKokyakuName.Text;
            string juusho = TBJyusyo.Text;
            string yuubinbangou = TBYuubinNo.Text;
            string tel = TBTellNo.Text;
            string fax = TBFax.Text;
            bool CusFlag = DelFlag.Checked;
            bool delFlag = DelFlag.Checked;

            // 必須項目のチェック
            if (CheckTBValue(TBShopID, shopID, "営業所ID"))         return;
            if (CheckTBValue(TBKokyakuName, kokyakuname, "顧客名")) return;
            if (CheckTBValue(TBYuubinNo, yuubinbangou, "郵便番号")) return;
            if (CheckTBValue(TBJyusyo, juusho, "住所"))             return;
            if (CheckTBValue(TBTellNo, tel, "電話番号"))            return;
            if (CheckTBValue(TBFax, fax, "FAX"))                    return;

            using (var context = new SalesManagementContext())
            {
                int shop;

                if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    TBShopID.BackColor = Color.Yellow;
                    TBShopID.Focus();
                    NotFound("店舗ID", shopID);
                    return;
                }

                var newcustomer = new MClient
                {
                    SoID = int.Parse(shopID),
                    ClPostal = yuubinbangou,
                    ClAddress = juusho,
                    ClName = kokyakuname,
                    ClPhone = tel,
                    ClFax = fax,
                };

                context.MClients.Add(newcustomer);
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("登録が成功しました。");
                    DisplayCustomer();
                    Log_Customer(newcustomer.ClID);
                    ResetYellowBackgrounds(this);
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show($"エラーの詳細: {ex.InnerException.Message}");
                    }
                    else
                    {
                        MessageBox.Show(":201\n登録操作が失敗しました。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DisplayCustomer()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、全ての顧客を表示
                    var customers = checkBox_2.Checked
                        ? context.MClients.ToList()
                        // チェックされていなければ、ClFlagが1のものを除外
                        : context.MClients.Where(c => c.ClFlag != 1).ToList();

                    dataGridView1.DataSource = customers.Select(c => new
                    {
                        顧客ID = c.ClID,
                        営業所ID = c.SoID,
                        顧客名 = c.ClName,
                        郵便番号 = c.ClPostal,
                        住所 = c.ClAddress,
                        電話番号 = c.ClPhone,
                        FAX = c.ClFax,
                        顧客管理フラグ = c.ClFlag,
                        非表示理由 = c.ClHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchCustomer()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var kokyakuID = TBKokyakuID.Text.Trim();       // 受注ID 
                var shopID = TBShopID.Text.Trim();           // 営業所ID 
                var kokyakuname = TBKokyakuName.Text.Trim();         // 社員ID 
                var juusho = TBJyusyo.Text.Trim();     // 顧客ID 
                var yuubinbangou = TBYuubinNo.Text.Trim();     // 担当者
                var tel = TBTellNo.Text.Trim();
                var fax = TBFax.Text.Trim();



                // 基本的なクエリ 
                var query = context.MClients.AsQueryable();

                // 受注IDを検索条件に追加 
                if (!string.IsNullOrEmpty(kokyakuID) && int.TryParse(kokyakuID, out int parsedkokyakuID))
                {
                    query = query.Where(c => c.ClID == parsedkokyakuID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                {
                    query = query.Where(sh => sh.SoID == parsedShopID);
                }

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(kokyakuname))
                {
                    query = query.Where(o => o.ClName.Contains(kokyakuname));
                }

                // 顧客IDを検索条件に追加 
                if (!string.IsNullOrEmpty(juusho))
                {
                    query = query.Where(o => o.ClAddress.Contains(juusho));
                }

                // 担当者名を検索条件に追加 
                if (!string.IsNullOrEmpty(yuubinbangou))
                {
                    query = query.Where(o => o.ClPostal.Contains(yuubinbangou));
                }

                // 受注日を検索条件に追加（チェックボックスがチェックされている場合） 
                if (!string.IsNullOrEmpty(tel))
                {
                    query = query.Where(o => o.ClPhone.Contains(tel));
                }
                if (!string.IsNullOrEmpty(fax))
                {
                    query = query.Where(o => o.ClFax.Contains(fax));
                }

                // 結果を取得 
                var customer = query.ToList();

                if (customer.Any())
                {
                    // dataGridView1 に結果を表示 
                    dataGridView1.DataSource = customer.Select(c => new
                    {
                        顧客ID = c.ClID,
                        営業所ID = c.SoID,
                        顧客名 = c.ClName,
                        郵便番号 = c.ClPostal,
                        住所 = c.ClAddress,
                        電話番号 = c.ClPhone,
                        FAX = c.ClFax,
                        顧客管理フラグ = c.ClFlag,
                        非表示理由 = c.ClHidden
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        TBKokyakuID.Text = "";
                    }
                    else
                    {
                        TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
                    }
                    // 各テキストボックスにデータを入力
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBKokyakuName.Text = row.Cells["顧客名"].Value.ToString();
                    TBJyusyo.Text = row.Cells["住所"].Value.ToString();
                    TBYuubinNo.Text = row.Cells["郵便番号"].Value.ToString();
                    TBTellNo.Text = row.Cells["電話番号"].Value.ToString();
                    TBFax.Text = row.Cells["FAX"].Value.ToString();
                    // 注文状態や非表示ボタン、非表示理由も必要に応じて設定
                    // 非表示ボタンや非表示理由もここで設定
                    // 例: hiddenButton.Text = row.Cells["非表示ボタン"].Value.ToString();
                    // 例: hiddenReason.Text = row.Cells["非表示理由"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void TBKokyakuID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBShopID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 2);
        }

        private void TBKokyakuName_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 50);
        }

        private void TBYuubinNo_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 7);
        }
        private void TBJyusyo_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 50);
        }

        private void TBTellNo_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 13);
        }

        private void TBFax_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 13);
        }
        private void colorReset()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    TBKokyakuID.BackColor = Color.Gray;
                    TBKokyakuID.Enabled = false;
                    TBShopID.BackColor = SystemColors.Window;
                    TBKokyakuName.BackColor = SystemColors.Window;
                    TBYuubinNo.BackColor = SystemColors.Window;
                    TBJyusyo.BackColor = SystemColors.Window;
                    TBTellNo.BackColor = SystemColors.Window;
                    TBFax.BackColor = SystemColors.Window;
                    break;
                default:
                    TBKokyakuID.BackColor = SystemColors.Window;
                    TBShopID.BackColor = SystemColors.Window;
                    TBKokyakuName.BackColor = SystemColors.Window;
                    TBYuubinNo.BackColor = SystemColors.Window;
                    TBJyusyo.BackColor = SystemColors.Window;
                    TBTellNo.BackColor = SystemColors.Window;
                    TBFax.BackColor = SystemColors.Window;
                    break;

            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBKokyakuID.KeyPress += NumericTextBox_KeyPress;
            TBShopID.KeyPress += NumericTextBox_KeyPress;
            TBYuubinNo.KeyPress += NumericTextBox_KeyPress;
            TBTellNo.KeyPress += Num_KeyPress;
            TBFax.KeyPress += Num_KeyPress;

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

        private void Num_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字とBackspace以外は入力を無効化
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Log_Customer(int id)
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
                            Display = "顧客",
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
                        MessageBox.Show("最新のログ履歴が見つかりませんでした。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Logへの登録に失敗しました:" + ex.Message);
            }
        }

        private void CusFlag_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DelFlag_CheckedChanged(object sender, EventArgs e)
        {

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