
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
    public partial class employee : Form
    {

        private Form mainForm;
        private ClassChangeForms formChanger;
        ///private ClassDateNamelabel dateNamelabel;
        private ClassTimerManager timerManager;
        private ClassAccessManager accessManager;
        public employee()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(employee_Load);
            //this.dateNamelabel = new ClassDateNamelabel(labeltime,labeldate,label_id,label_ename);
            //this.timerManager = new ClassTimerManager(timer1,labeltime,labeldate);
            timer1.Start();
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
            this.formChanger = new ClassChangeForms(this);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* DateTime dateTime = DateTime.Now;
             labeltime.Text = dateTime.ToLongTimeString();

             var now = System.DateTime.Now;
             labeldate.Text = now.ToString("yyyy年MM月dd日");*/
        }

        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

        private void b_mer_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMerchandiseForm();
        }

        private void b_sto_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToStockForm();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToCustomerForm();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_cus,
                b_mer,
                b_sto,
            });
            DisplayEmployee();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBSyainID.Text = "";
            TBSyainName.Text = "";
            TBShopID.Text = "";
            TBJobID.Text = "";
            TBPass.Text = "";
            TBTellNo.Text = "";
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
            TBSyainID.BackColor = Color.White;
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBSyainID.Enabled = true;
            TBSyainID.BackColor = Color.White;
            DisplayEmployee();
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_kakutei_Click(object sender, EventArgs e)
        {
            colorReset();
            HandleOrderOperation();
        }

        private void HandleOrderOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    UpdateEmployee();
                    break;
                case CurrentStatus.Status.登録:
                    RegisterEmployee();
                    break;
                case CurrentStatus.Status.一覧:
                    DisplayEmployee();
                    break;
                case CurrentStatus.Status.検索:
                    SearchEmployee();
                    break;
                default:
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        /*private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // パスワードを表示する列のインデックスを指定 (例: 0列目)
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                // パスワードの文字数分、●を表示
                e.Value = new string('●', e.Value.ToString().Length);
                e.FormattingApplied = true; // 既定の書式適用を防止
            }
        }*/
        private void UpdateEmployee()
        {
            string ShainID = TBSyainID.Text;
            string ShainName = TBSyainName.Text;
            string ShopID = TBShopID.Text;
            string JobID = TBJobID.Text;
            DateTime ShainDate = date.Value;
            string Pass = TBPass.Text;
            string TelNo = TBTellNo.Text;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            if (TBSyainID.Text == "")
            {
                TBSyainID.BackColor = Color.Yellow;
                TBSyainID.Focus();
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBSyainName.Text == "")
            {
                TBSyainName.BackColor = Color.Yellow;
                TBSyainName.Focus();
                MessageBox.Show("社員名を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBShopID.Text == "")
            {
                TBShopID.BackColor = Color.Yellow;
                TBShopID.Focus();
                MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBJobID.Text == "")
            {
                TBJobID.BackColor = Color.Yellow;
                TBJobID.Focus();
                MessageBox.Show("役職IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBPass.Text == "")
            {
                TBPass.BackColor = Color.Yellow;
                TBPass.Focus();
                MessageBox.Show("パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBTellNo.Text == "")
            {
                TBTellNo.BackColor = Color.Yellow;
                TBTellNo.Focus();
                MessageBox.Show("電話番号を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new SalesManagementContext())
            {
                var employee = context.MEmployees.SingleOrDefault(e => e.EmID.ToString() == ShainID);
                if (employee != null)
                {
                    employee.EmName = ShainName;
                    employee.SoID = int.Parse(ShopID);
                    employee.PoID = int.Parse(JobID);
                    employee.EmHiredate = ShainDate;
                    employee.EmPhone = TelNo;
                    employee.EmPassword = Pass;
                    employee.EmFlag = delFlag ? 1 : 0;
                    employee.EmHidden = riyuu;
                    
                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    DisplayEmployee();
                }
                else
                {
                    MessageBox.Show("該当する社員情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void RegisterEmployee()
        {
            string ShainID = TBSyainID.Text;
            string ShainName = TBSyainName.Text;
            string ShopID = TBShopID.Text;
            string JobID = TBJobID.Text;
            DateTime ShainDate = date.Value;
            string Pass = TBPass.Text;
            string TelNo = TBTellNo.Text;
            bool delFlag = DelFlag.Checked;
            string Riyuu = TBRiyuu.Text;

            if (TBSyainID.Text == "")
            {
                TBSyainID.BackColor = Color.Yellow;
                TBSyainID.Focus();
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBSyainName.Text == "")
            {
                TBSyainName.BackColor = Color.Yellow;
                TBSyainName.Focus();
                MessageBox.Show("社員名を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBShopID.Text == "")
            {
                TBShopID.BackColor = Color.Yellow;
                TBShopID.Focus();
                MessageBox.Show("営業所IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBJobID.Text == "")
            {
                TBJobID.BackColor = Color.Yellow;
                TBJobID.Focus();
                MessageBox.Show("役職IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBPass.Text == "")
            {
                TBPass.BackColor = Color.Yellow;
                TBPass.Focus();
                MessageBox.Show("パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBTellNo.Text == "")
            {
                TBTellNo.BackColor = Color.Yellow;
                TBTellNo.Focus();
                MessageBox.Show("電話番号を入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new SalesManagementContext())
            {
                int shop;
                if (!int.TryParse(ShopID, out shop) || !context.MSalesOffices.Any(s => s.SoID == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // EmIDがMEmployeeテーブルに存在するか確認
                int job;
                if (!int.TryParse(JobID, out job) || !context.MPositions.Any(e => e.PoID == job))
                {
                    MessageBox.Show("役職IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                var newEmployee = new MEmployee
                {
                    EmID = int.Parse(ShainID),
                    EmName = ShainName,
                    SoID = int.Parse(ShopID),
                    PoID = int.Parse(JobID),
                    EmHiredate = ShainDate,
                    EmPassword = Pass,
                    EmPhone = TelNo,
                    EmFlag = delFlag ? 1 : 0,
                    EmHidden = Riyuu
                };

                context.MEmployees.Add(newEmployee);
                context.SaveChanges();
                MessageBox.Show("登録が成功しました。");
                DisplayEmployee();
            }
        }

        // DataGridViewのCellFormattingイベントを使用


        private void DisplayEmployee()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // checkBox_2 がチェックされている場合、全員の社員情報を表示
                    var employees = checkBox_2.Checked
                        ? context.MEmployees.ToList()
                        // チェックされていなければ非表示フラグが "1" のものを除外
                        : context.MEmployees.Where(e => e.EmFlag != 1).ToList();

                    dataGridView1.DataSource = employees.Select(e => new
                    {
                        社員ID = e.EmID,
                        社員名 = e.EmName,
                        営業所ID = e.SoID,
                        役職ID = e.PoID,
                        入社年月日 = e.EmHiredate,
                        パスワード = e.EmPassword,
                        電話番号 = e.EmPhone,
                        非表示フラグ = e.EmFlag,
                        非表示理由 = e.EmHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchEmployee()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var ShainID = TBSyainID.Text.Trim();       // 社員ID 
                var ShainName = TBSyainName.Text.Trim();           // 
                var ShopID = TBShopID.Text.Trim();         // 店あいデー
                var JobID = TBJobID.Text.Trim();     // 役職
                var TelNo = TBTellNo.Text.Trim();     // でんわ 

                // 基本的なクエリ 
                var query = context.MEmployees.AsQueryable();

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(ShainID) && int.TryParse(ShainID, out int parsedShainID))
                {
                    query = query.Where(e => e.EmID == parsedShainID);
                }

                // 社員名を検索条件に追加 
                if (!string.IsNullOrEmpty(ShainName))
                {
                    query = query.Where(o => o.EmName.Contains(ShainName));
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(ShopID) && int.TryParse(ShopID, out int parsedShopID))
                {
                    query = query.Where(o => o.SoID == parsedShopID);
                }

                // 役職 
                if (!string.IsNullOrEmpty(JobID) && int.TryParse(JobID, out int parsedJobID))
                {
                    query = query.Where(e => e.PoID == parsedJobID);
                }

                // でんわ 
                if (!string.IsNullOrEmpty(TelNo))
                {
                    query = query.Where(e => e.EmPhone.Contains(TelNo));
                }




                // 結果を取得 
                var employees = query.ToList();

                if (employees.Any())
                {
                    // dataGridView1 に結果を表示 
                    dataGridView1.DataSource = employees.Select(employee => new
                    {
                        社員ID = employee.EmID,
                        社員名 = employee.EmName,
                        営業所ID = employee.SoID,
                        役職ID = employee.PoID,
                        入社年月日 = employee.EmHiredate,
                        パスワード = employee.EmPassword,
                        電話番号 = employee.EmPhone,
                        非表示理由 = employee.EmHidden,
                        削除フラグ = DelFlag.Checked ? 1 : 0
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する社員情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア 
                }
            }
        }



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

                    TBSyainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBSyainName.Text = row.Cells["社員名"].Value.ToString();
                    TBShopID.Text = row.Cells["営業所ID"].Value.ToString();
                    TBJobID.Text = row.Cells["役職ID"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["入社年月日"].Value);
                    TBPass.Text = row.Cells["パスワード"].Value.ToString();
                    TBTellNo.Text = row.Cells["電話番号"].Value.ToString();
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

        private void TBSyainID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBSyainName_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 50);
        }

        private void TBShopID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 2);
        }

        private void TBJobID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 2);
        }

        private void TBPass_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }
        private void TBTellNo_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 13);
        }
        private void colorReset()
        {
            TBSyainID.BackColor = SystemColors.Window;
            TBSyainName.BackColor = SystemColors.Window;
            TBJobID.BackColor = SystemColors.Window;
            TBJobID.BackColor = SystemColors.Window;
            TBPass.BackColor = SystemColors.Window;
            TBTellNo.BackColor = SystemColors.Window;

        }


    }
}

