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

namespace SalesManagement_SysDev
{
    public partial class stock : Form
    {
        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private string orderFlag = "←通常"; // 初期状態を「注文」に設定

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

        private void button14_Click(object sender, EventArgs e)
        {


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
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを閉じる
            this.Close();
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
        }

        private void b_sto_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
        private void b_kakutei_Click_1(object sender, EventArgs e)
        {
            try
            {
                // モードに基づいて処理を分岐
                switch (CurrentStatus.CurrentMode)
                {
                    case CurrentStatus.Mode.通常:
                        HandleStockOperation();
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
                    MessageBox.Show("無効な操作です。");
                    break;
            }
        }


        private void UpdateStock()
        {
            string zaikoID = TBZaikoID.Text;
            string syohinID = TBSyohinID.Text;
            string zaiko = TBZaiko.Text;
            bool stflag = StFlag.Checked;
            bool delflag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            using (var context = new SalesManagementContext())
            {
                var stock = context.TStocks.SingleOrDefault(s => s.StId.ToString() == zaikoID);
                if (stock != null)
                {
                    stock.StId = int.Parse(zaikoID);
                    stock.PrId = int.Parse(syohinID);
                    stock.StQuantity = int.Parse(zaiko);
                    stock.StFlag = stflag ? 1 : 0;
                    

                    context.SaveChanges();
                    MessageBox.Show("更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("該当する出荷情報が見つかりません。");
                }
            }
        }

        private void RegisterStock()
        {
            string zaikoID = TBZaikoID.Text;
            string syohinID = TBSyohinID.Text;
            string zaiko = TBZaiko.Text;
            bool stflag = StFlag.Checked;
            bool delflag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            using (var context = new SalesManagementContext())
            {
                var newstock = new TStock
                {
                    StId = int.Parse(zaikoID),
                    PrId = int.Parse(syohinID),
                    StQuantity = int.Parse(zaiko),
                    StFlag = stflag ? 1:0,
                };

                context.TStocks.Add(newstock);
                try
                {
                    context.SaveChanges(); MessageBox.Show("登録が成功しました。");
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
                        MessageBox.Show("エンティティの変更を保存中にエラーが発生しました。");
                    }
                }
                catch (Exception ex)
                {
                    // その他のエラーに対処する
                    MessageBox.Show($"エラーが発生しました: {ex.Message}");
                }
            }
        }

        private void DisplayStock()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var stock = context.TStocks.ToList();

                    dataGridView1.DataSource = stock.Select(s => new
                    {
                        在庫ID = s.StId,
                        商品ID = s.PrId,
                        在庫数 = s.StQuantity,
                        在庫管理フラグ = s.StFlag,
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message);
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
                    query = query.Where(s => s.StId == parsedzaikoID);
                }

                // 営業所IDを検索条件に追加 
                if (!string.IsNullOrEmpty(syohinID) && int.TryParse(syohinID, out int parsedsyohinID))
                {
                    query = query.Where(s => s.PrId == parsedsyohinID);
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
                        在庫ID = s.StId,
                        商品ID = s.PrId,
                        在庫数 = s.StQuantity,
                        在庫管理フラグ = s.StFlag,
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("該当する受注が見つかりません。");
                    dataGridView1.DataSource = null; // 結果がない場合はデータソースをクリア 
                }
            }
        }

        // CellClickイベントハンドラ
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // クリックした行のインデックスを取得
            int rowIndex = e.RowIndex;

            // 行インデックスが有効かどうかをチェック
            if (rowIndex >= 0)
            {
                // 行データを取得
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                // 各テキストボックスにデータを入力
                TBZaikoID.Text = row.Cells["在庫ID"].Value.ToString();
                TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                TBZaiko.Text = row.Cells["在庫数"].Value.ToString();
                TBRiyuu.Text = row.Cells["非表示理由"].Value.ToString();
                // 注文状態や非表示ボタン、非表示理由も必要に応じて設定
                // 非表示ボタンや非表示理由もここで設定
                // 例: hiddenButton.Text = row.Cells["非表示ボタン"].Value.ToString();
                // 例: hiddenReason.Text = row.Cells["非表示理由"].Value.ToString();
            }
        }
    }
}
