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

namespace SalesManagement_SysDev
{
    public partial class customer : Form
    {


        private Form mainForm;
        private ClassChangeForms formChanger;
        private ClassDateNamelabel dateNamelabel;
        private ClassAccessManager accessManager;
        public customer()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(customer_Load);
            this.dateNamelabel = new ClassDateNamelabel(label_id, label_ename);
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

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

        private void b_iti_Click(object sender, EventArgs e)
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
                    MessageBox.Show("無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        //


        private void UpdateCustomer()
        {
            string kokyakuID = TBKokyakuID.Text;
            string shopID = TBShopID.Text;
            string kokyakuname = TBKokyakuName.Text;
            string juusho = TBJyusyo.Text;
            string yuubinbangou = TBYuubinNo.Text;
            string tel = TBTellNo.Text;
            string fax = TBFax.Text;


            if (!int.TryParse(shopID, out int parsedShopID))
            {
                MessageBox.Show("営業所IDは半角整数でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(kokyakuID, out int parsedKokyakuID))
            {
                MessageBox.Show("顧客IDは半角整数でなければなりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

            using (var context = new SalesManagementContext())
            {
                var customer = context.MClients.SingleOrDefault(c => c.ClId.ToString() == kokyakuID);
                if (customer != null)
                {
                    customer.SoId = int.Parse(shopID);
                    customer.ClPostal = yuubinbangou;
                    customer.ClName = kokyakuname;
                    customer.ClId = int.Parse(kokyakuID);
                    customer.ClAddress = juusho;
                    customer.ClPhone = tel;
                    customer.ClFax = fax;

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    DisplayCustomer();
                }
                else
                {
                    MessageBox.Show("該当する顧客情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            using (var context = new SalesManagementContext())
            {
                int shop;
                if (!int.TryParse(shopID, out shop) || !context.MSalesOffices.Any(s => s.SoId == shop))
                {
                    MessageBox.Show("営業所IDが存在しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var newcustomer = new MClient
                {
                    SoId = int.Parse(shopID),
                    ClPostal = yuubinbangou,
                    ClAddress = juusho,
                    ClName = kokyakuname,
                    ClPhone = tel,
                    ClFax = fax,

                };

                context.MClients.Add(newcustomer);
                try
                {
                    context.SaveChanges(); MessageBox.Show("登録が成功しました。");
                    DisplayCustomer();
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

        private void DisplayCustomer()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var customer = context.MClients.ToList();


                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示
                    var orders = checkBox_2.Checked
                        ? context.MClients.ToList()  // チェックされていれば全ての注文を表示
                        : context.MClients.Where(o => o.ClFlag != 1).ToList();  // チェックされていなければ非表示フラグが "1" のものを除外
                    dataGridView1.DataSource = customer.Select(c => new
                    {
                        顧客ID = c.ClId,
                        営業所ID = c.SoId,
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
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    query = query.Where(c => c.ClId == parsedkokyakuID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(shopID) && int.TryParse(shopID, out int parsedShopID))
                {
                    query = query.Where(sh => sh.SoId == parsedShopID);
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
                        顧客ID = c.ClId,
                        営業所ID = c.SoId,
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
                    MessageBox.Show("該当する顧客情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // 各テキストボックスにデータを入力
                    TBKokyakuID.Text = row.Cells["顧客ID"].Value.ToString();
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
                MessageBox.Show("セルのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }


}