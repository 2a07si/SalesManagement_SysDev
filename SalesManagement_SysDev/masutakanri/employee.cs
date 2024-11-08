
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
        }

        private void clear_Click(object sender, EventArgs e)
        {

        }

        private void cleartext()
        {
            TBSyainID.Text = "";
            TBSyainName.Text = "";
            TBShopId.Text = "";
            TBJobID.Text = "";
            TBPass.Text = "";
            TBTellNo.Text = "";
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
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
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
        }

        private void b_kakutei_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }
        private void UpdateEmployee()
        {
            string ShainID = TBSyainID.Text;
            string ShainName = TBSyainName.Text;
            string ShopID = TBShopId.Text;
            string JobID = TBJobID.Text;
            DateTime ShainDate = date.Value;
            string Pass = TBPass.Text;
            string TelNo = TBTellNo.Text;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;


            using (var context = new SalesManagementContext())
            {
                var employee = context.MEmployees.SingleOrDefault(e => e.EmId.ToString() == ShainID);
                if (employee != null)
                {
                    employee.EmName = ShainName;
                    employee.SoId = int.Parse(ShopID);
                    employee.PoId = int.Parse(JobID);
                    employee.EmHiredate = ShainDate;
                    employee.EmPhone = TelNo;
                    employee.EmPassword = Pass;
                    employee.EmHidden = delFlag ? "1" : "0";
                    employee.EmHidden = riyuu;

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    DisplayEmployee();
                }
                else
                {
                    MessageBox.Show("該当する社員情報が見つかりません。");
                }
            }

        }
        private void RegisterEmployee()
        {
            string ShainID = TBSyainID.Text;
            string ShainName = TBSyainName.Text;
            string ShopID = TBShopId.Text;
            string JobID = TBJobID.Text;
            DateTime ShainDate = date.Value;
            string Pass = TBPass.Text;
            string TelNo = TBTellNo.Text;
            bool delFlag = DelFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (!int.TryParse(ShopID, out shop) || !context.MSalesOffices.Any(s => s.SoId == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。");
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int job;
                if (!int.TryParse(JobID, out job) || !context.MPositions.Any(e => e.PoId == job))
                {
                    MessageBox.Show("社員IDが存在しません。");
                    return;
                }
                var newEmployee = new MEmployee
                {
                    EmId = int.Parse(ShainID),
                    EmName = ShainName,
                    SoId = int.Parse(ShopID),
                    PoId = int.Parse(JobID),
                    EmHiredate = ShainDate,
                    EmPassword = Pass,
                    EmPhone = TelNo,
                    EmHidden = delFlag ? "1" : "0"
                };

                context.MEmployees.Add(newEmployee);
                context.SaveChanges();
                MessageBox.Show("登録が成功しました。");
            }
        }
        private void DisplayEmployee()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var employees = context.MEmployees.ToList();

                    dataGridView1.DataSource = employees.Select(e => new
                    {
                        社員ID = e.EmId,
                        社員名 = e.EmName,
                        営業所ID = e.EmId,
                        役職ID = e.PoId,
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
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void SearchEmployee()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var ShainID = TBSyainID.Text.Trim();       // 社員ID 
                var ShainName = TBSyainName.Text.Trim();           // 
                var ShopID = TBShopId.Text.Trim();         // 店あいデー
                var JobID = TBJobID.Text.Trim();     // 役職
                var TelNo = TBTellNo.Text.Trim();     // でんわ 

                // 基本的なクエリ 
                var query = context.MEmployees.AsQueryable();

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(ShainID) && int.TryParse(ShainID, out int parsedShainID))
                {
                    query = query.Where(e => e.EmId == parsedShainID);
                }

                // 社員名を検索条件に追加 
                if (!string.IsNullOrEmpty(ShainName))
                {
                    query = query.Where(o => o.EmName.Contains(ShainName));
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(ShopID) && int.TryParse(ShopID, out int parsedShopID))
                {
                    query = query.Where(o => o.SoId == parsedShopID);
                }

                // 役職 
                if (!string.IsNullOrEmpty(JobID) && int.TryParse(JobID, out int parsedJobID))
                {
                    query = query.Where(e => e.SoId == parsedJobID);
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
                        社員ID = employee.EmId,
                        社員名 = employee.EmName,
                        営業所ID = employee.SoId,
                        役職ID = employee.PoId,
                        入社年月日 = employee.EmHiredate,
                        パスワード = employee.EmPassword,
                        電話番号 = employee.EmPhone,
                        非表示理由 = employee.EmHidden,
                        削除フラグ = DelFlag.Checked ? "〇" : "×"
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する社員情報が見つかりません。");
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア 
                }
            }
        }


        private void TBTellNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

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

                    // 各テキストボックスにデータを入力
                    TBSyainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBSyainName.Text = row.Cells["社員名"].Value.ToString();
                    TBShopId.Text = row.Cells["営業所ID"].Value.ToString();
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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

                    // 各テキストボックスにデータを入力
                    TBSyainID.Text = row.Cells["社員ID"].Value.ToString();
                    TBSyainName.Text = row.Cells["社員名"].Value.ToString();
                    TBShopId.Text = row.Cells["営業所ID"].Value.ToString();
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
    }
}

