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
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace SalesManagement_SysDev
{
    public partial class merchandise : Form
    {
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



        private void merchandise_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_emp,
                b_cus,
                b_sto,
            });
            Displaymerchandise();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBSell.Text = "";
            TBSyohinID.Text = "";
            TBMakerId.Text = "";
            TBSyohinName.Text = "";
            TBSafeNum.Text = "";
            TBSyohinName.Text = "";
            TBModel.Text = "";
            TBColor.Text = "";
            TBSyoubunrui.Text = "";
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            date.Value = DateTime.Now;
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
        private void b_kakutei_Click_1(object sender, EventArgs e)
        {
            HandleOrderOperation();
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
        private void Updatemerchandise()
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
                    merchandise.PrFlag = int.Parse(delFlag ? "1" : "0");

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                    Displaymerchandise();
                }
                else
                {
                    MessageBox.Show("該当する商品情報が見つかりません。");
                }
            }

        }
        private void Registermerchandise()
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
            string riyuu = TBRiyuu.Text;

            using (var context = new SalesManagementContext())
            {
                int maker;
                if (!int.TryParse(MakerID, out maker) || !context.MMakers.Any(s => s.MaId == maker))
                {
                    MessageBox.Show("メーカーIDが存在しません。");
                    return;
                }

                // EmIdがMEmployeeテーブルに存在するか確認
                int shoubunrui;
                if (!int.TryParse(Sclass, out shoubunrui) || !context.MSmallClassifications.Any(e => e.ScId == shoubunrui))
                {
                    MessageBox.Show("小分類IDが存在しません。");
                    return;
                }
                var newProducts = new MProduct
                {
                    MaId = int.Parse(MakerID),
                    PrName = SyohinName,
                    Price = int.Parse(Sell),
                    PrSafetyStock = int.Parse(SafeNum),
                    ScId = int.Parse(Sclass),
                    PrReleaseDate = SyohinDate,
                    PrModelNumber = TModel,
                    PrColor = TColor,
                    PrFlag = int.Parse(delFlag ? "1" : "0"),
                    PrHidden = riyuu
                };

                context.MProducts.Add(newProducts);
                context.SaveChanges();

                MessageBox.Show("登録が成功しました。");
                Displaymerchandise();
            }
        }
        private void Displaymerchandise()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var merchandises = context.MProducts.ToList();

                    // checkBox_2 がチェックされている場合、非表示フラグに関係なくすべての受注を表示
                    var orders = checkBox_2.Checked
                        ? context.MProducts.ToList()  // チェックされていれば全ての注文を表示
                        : context.MProducts.Where(o => o.PrFlag != 1).ToList();  // チェックされていなければ非表示フラグが "1" のものを除外
                    dataGridView1.DataSource = merchandises.Select(m => new
                    {
                        商品ID = m.PrId,
                        メーカーID = m.MaId,
                        商品名 = m.PrName,
                        値段 = m.Price,
                        安全在庫数 = m.PrSafetyStock,
                        小分類ID = m.ScId,
                        型番 = m.PrModelNumber,
                        色 = m.PrColor,
                        発売日 = m.PrReleaseDate,
                        非表示フラグ = m.PrFlag,
                        非表示理由 = m.PrHidden
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
                var SyohinID = TBSyohinID.Text.Trim();       // 商品
                var MakerId = TBMakerId.Text.Trim();           // めーかー 
                var SyohinName = TBSyohinName.Text.Trim();         //商品名
                var Sell = TBSell.Text.Trim();     // 値段
                var safe = TBSafeNum.Text.Trim();
                var shou = TBSyoubunrui.Text.Trim();
                var Model = TBModel.Text.Trim();     // かたばｊｎ 
                var color = TBColor.Text.Trim();


                // 基本的なクエリ 
                var query = context.MProducts.AsQueryable();

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(SyohinID) && int.TryParse(SyohinID, out int parsedSyohinID))
                {
                    query = query.Where(m => m.PrId == parsedSyohinID);
                }

                // 商品名を検索条件に追加 
                if (!string.IsNullOrEmpty(MakerId) && int.TryParse(MakerId, out int parsedMakerID))
                {
                    query = query.Where(m => m.MaId == parsedMakerID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(SyohinName))
                {
                    query = query.Where(m => m.PrName == SyohinName);
                }

                // 顧客IDを検索条件に追加 
                if (!string.IsNullOrEmpty(Sell) && int.TryParse(Sell, out int parsedSell))
                {
                    query = query.Where(m => m.Price == parsedSell);
                }

                if (!string.IsNullOrEmpty(safe) && int.TryParse(safe, out int parsedsafe))
                {
                    query = query.Where(m => m.PrSafetyStock == parsedsafe);
                }

                if (!string.IsNullOrEmpty(shou) && int.TryParse(shou, out int parsedshou))
                {
                    query = query.Where(m => m.ScId == parsedshou);
                }

                // 担当者名を検索条件に追加 
                if (!string.IsNullOrEmpty(Model))
                {
                    query = query.Where(m => m.PrModelNumber.Contains(Model));
                }

                if (!string.IsNullOrEmpty(color))
                {
                    query = query.Where(m => m.PrColor.Contains(color));
                }




                // 結果を取得 
                var m = query.ToList();

                if (m.Any())
                {
                    // dataGridView1 に結果を表示 
                    dataGridView1.DataSource = m.Select(m => new
                    {
                        商品ID = m.PrId,
                        メーカーID = m.MaId,
                        商品名 = m.PrName,
                        値段 = m.Price,
                        安全在庫数 = m.PrSafetyStock,
                        小分類ID = m.ScId,
                        型番 = m.PrModelNumber,
                        色 = m.PrColor,
                        発売日 = m.PrReleaseDate,
                        非表示フラグ = m.PrFlag,
                        非表示理由 = m.PrHidden,
                        削除フラグ = DelFlag.Checked ? "〇" : "×"
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する商品情報が見つかりません。");
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

                    // 各テキストボックスにデータを入力
                    TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    TBMakerId.Text = row.Cells["メーカーID"].Value.ToString();
                    TBSyohinName.Text = row.Cells["商品名"].Value.ToString();
                    TBSell.Text = row.Cells["値段"].Value.ToString();
                    date.Value = Convert.ToDateTime(row.Cells["発売日"].Value);
                    TBSafeNum.Text = row.Cells["安全在庫数"].Value.ToString();
                    TBSyoubunrui.Text = row.Cells["小分類ID"].Value.ToString();
                    TBModel.Text = row.Cells["型番"].Value.ToString();
                    TBColor.Text = row.Cells["色"].Value.ToString();
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
