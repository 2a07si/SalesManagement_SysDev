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
    public partial class merchandise : Form
    {
        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定

        private Form mainForm;
        private ClassChangeForms formChanger;
        private ClassDateNamelabel dateNamelabel;
        private ClassTimerManager timerManager;
        private ClassAccessManager accessManager;
        public merchandise()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(merchandise_Load);
            this.dateNamelabel = new ClassDateNamelabel(labeltime, labeldate, label_id, label_ename);
            this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate);
            timer1.Start();
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセッ
            this.formChanger = new ClassChangeForms(this);

        }

        private void button3_Click(object sender, EventArgs e)
        {

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
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを閉じる
            this.Close();
        }

        private void b_emp_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToEmployeeForm();
        }

        private void b_sto_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToStockForm();
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToCustomerForm();
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void merchandise_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_emp,
                b_cus,
                b_sto,
            });
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBSyohinID.Text = "";
            TBMakerId.Text = "";
            TBSyohinName.Text = "";
            TBSafeNum.Text = "";
            TBSyohinName.Text = "";
            TBModel.Text = "";
            TBColor.Text = "";
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
            try
            {
                // モードに基づいて処理を分岐
                switch (CurrentStatus.CurrentMode)
                {
                    case CurrentStatus.Mode.通常:
                        HandleOrderOperation();
                        break;
                    default:
                        MessageBox.Show("現在のモードは無効です。");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void HandleOrderOperation()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.更新:
                    Updatemerchandise();
                    break;
                case CurrentStatus.Status.登録:
                    Registermerchandise();
                    break;
                case CurrentStatus.Status.一覧:
                    Displaymerchandise();
                    break;
                case CurrentStatus.Status.検索:
                    Searchmerchandise();
                    break;
                default:
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }
        private void Updatesemerchandise()
        {
            string SyohinID = TBSyohinID.Text;
            string MakerID = TBMakerId.Text;
            string SyohinName = TBSyohinName.Text;
            string Sell = TBSell.Text;
            string SafeNum = TBSafeNum.Text;
            string Sclass = TBSyoubunrui.Text;
            string TModel = TBModel.Text;
            string TColor = TBColor.Text;
            DateTime SyohinDate = date.Value;
            bool delFlag = DelFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                var merchandise = context.MProducts.SingleOrDefault(e => e.PrId.ToString() == SyohinID);
                if (merchandise != null)
                {
                    merchandise.PrId = int.Parse(SyohinID);
                    merchandise.MaId = int.Parse(MakerID);
                    merchandise.PrName = SyohinName;
                    merchandise.Price = int.Parse(Sell);
                    merchandise.PrSafetyStock = int.Parse(SafeNum);
                    merchandise.ScId = int.Parse(Sclass);
                    merchandise.PrReleaseDate = SyohinDate;
                    merchandise.PrModelNumber = TModel;
                    merchandise.PrColor = TColor;
                    merchandise.PrReleaseDate = SyohinDate;
                    merchandise.PrHidden = delFlag ? "1" : "0";

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する受注が見つかりません。");
                }
            }

        }
        private void Registermerchandise()
        {
            string ShainID = TBSyainID.Text;
            string ShainName = TBSyainName.Text;
            string ShopID = TBShopId.Text;
            string JobID = TBJobID.Text;
            DateTime ShainDate = date.Value;
            string TelNo = TBTellNo.Text;
            bool delFlag = DelFlag.Checked;

            using (var context = new SalesManagementContext())
            {
                var newEmployee = new MEmployee
                {
                    EmId = int.Parse(ShainID),
                    EmName = ShainName,
                    SoId = int.Parse(ShopID),
                    PoId = int.Parse(JobID),
                    EmHiredate = ShainDate,
                    EmHidden = delFlag ? "1" : "0"
                };

                context.MEmployees.Add(newEmployee);
                context.SaveChanges();
                MessageBox.Show("登録が成功しました。");
            }
        }
        private void Displaymerchandise()
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
                        電話番号 = e.EmPhone,
                        非表示フラグ = e.EmHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
            }
        }

        private void Searchmerchandise()
        {
            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var ShainID = TBSyainID.Text.Trim();       // 社員ID 
                var ShaiName = TBSyainName.Text.Trim();           // 営業所ID 
                var ShopID = TBShopId.Text.Trim();         // 社員ID 
                var JobID = TBJobID.Text.Trim();     // 顧客ID 
                var TelNo = TBTellNo.Text.Trim();     // 担当者 

                // 基本的なクエリ 
                var query = context.MEmployees.AsQueryable();

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(ShainID) && int.TryParse(ShainID, out int parsedJyutyuID))
                {
                    query = query.Where(e => e.EmId == parsedJyutyuID);
                }

                // 社員名を検索条件に追加 
                if (!string.IsNullOrEmpty(ShaiName) && int.TryParse(ShaiName, out int parsedShopID))
                {
                    query = query.Where(o => o.SoId == parsedShopID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(ShopID) && int.TryParse(ShopID, out int parsedShainID))
                {
                    query = query.Where(o => o.EmId == parsedShainID);
                }

                // 顧客IDを検索条件に追加 
                if (!string.IsNullOrEmpty(JobID) && int.TryParse(JobID, out int parsedKokyakuID))
                {
                    query = query.Where(e => e.SoId == parsedKokyakuID);
                }

                // 担当者名を検索条件に追加 
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
                        営業所ID = employee.EmId,
                        役職ID = employee.PoId,
                        入社年月日 = employee.EmHiredate,
                        電話番号 = employee.EmPhone,
                        削除フラグ = DelFlag.Checked ? "〇" : "×"
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する受注が見つかりません。");
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア 
                }
            }
        }
    }
}
