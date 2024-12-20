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
using SalesManagement_SysDev.Entity;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace SalesManagement_SysDev
{
    public partial class merchandise : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger;
        private ClassDateNamelabel dateNamelabel;
        private ClassTimerManager timerManager;
        private ClassAccessManager accessManager;
        private DateTime timestamp = DateTime.Now;
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
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;


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
            SetupNumericOnlyTextBoxes();
            CurrentStatus.RegistrationStatus(label2);
            TBSyohinID.Enabled = false;
            TBSyohinID.BackColor = Color.Gray;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBSell.Text = "";
            TBSyohinID.Text = "";
            TBMakerID.Text = "";
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
            TBSyohinID.BackColor = Color.White;
            colorReset();
            ResetYellowBackgrounds(this);
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            CurrentStatus.RegistrationStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBSyohinID.Enabled = false;
            TBSyohinID.BackColor = Color.Gray;
            TBSyohinID.Text = "";
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            CurrentStatus.UpDateStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBSyohinID.Enabled = true;
            TBSyohinID.BackColor = Color.White;
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            CurrentStatus.ListStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBSyohinID.Enabled = true;
            TBSyohinID.BackColor = Color.White;
            Displaymerchandise();
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            CurrentStatus.SearchStatus(label2);
            labelStatus.labelstatus(label2, b_kakutei);
            TBSyohinID.Enabled = true;
            TBSyohinID.BackColor = Color.White;
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
                    MessageBox.Show(":100\n無効な操作です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private bool CheckTBValue(TextBox textBox, string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                textBox.BackColor = Color.Yellow;
                textBox.Focus();
                MessageBox.Show($":101\n必要な入力がありません。（{fieldName}）", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            textBox.BackColor = SystemColors.Window; // 問題ない場合、背景色をリセット
            return false;
        }
        private void NotFound(TextBox textBox, string itemName, string itemId)
        {
            textBox.BackColor = Color.Yellow;
            textBox.Focus();
            MessageBox.Show($":204\n該当の{itemName}が見つかりません。（{itemName}ID: {itemId}）",
                            "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Updatemerchandise()
        {
            string syohinID = TBSyohinID.Text;
            string makerID = TBMakerID.Text;
            string syohinName = TBSyohinName.Text;
            string sell = TBSell.Text;
            string safeNum = TBSafeNum.Text;
            string sclass = TBSyoubunrui.Text;
            string tModel = TBModel.Text;
            string tColor = TBColor.Text;
            bool delFlag = DelFlag.Checked;
            DateTime syohinDate = date.Value;

            // 入力チェックを共通メソッドで実施
            if (CheckTBValue(TBSyohinID, syohinID, "商品ID")) return;
            if (CheckTBValue(TBMakerID, makerID, "メーカーID")) return;
            if (CheckTBValue(TBSyohinName, syohinName, "商品名")) return;
            if (CheckTBValue(TBSell, sell, "販売価格")) return;
            if (CheckTBValue(TBSafeNum, safeNum, "安全在庫数")) return;
            if (CheckTBValue(TBSyoubunrui, sclass, "小分類")) return;
            if (CheckTBValue(TBModel, tModel, "モデル番号")) return;
            if (CheckTBValue(TBColor, tColor, "色")) return;
            if (Kuraberu_kun.Kuraberu_chan("商品", null, "更新", int.Parse(syohinID), timestamp) == false)
            { return; }

            using (var context = new SalesManagementContext())
            {
                try
                {
                    // メーカーIDの存在確認
                    if (!int.TryParse(makerID, out int parsedMakerID) ||
                        !context.MMakers.Any(m => m.MaID == parsedMakerID))
                    {
                        NotFound(TBMakerID, "メーカーID", makerID);
                        return;
                    }

                    // 小分類IDの存在確認
                    if (!int.TryParse(sclass, out int parsedSClassID) ||
                        !context.MSmallClassifications.Any(sc => sc.ScID == parsedSClassID))
                    {
                        NotFound(TBSyoubunrui, "小分類ID", sclass);
                        return;
                    }

                    // 商品IDの存在確認
                    var merchandise = context.MProducts.SingleOrDefault(p => p.PrID.ToString() == syohinID);
                    if (merchandise != null)
                    {
                        // 商品情報の更新
                        merchandise.MaID = parsedMakerID;
                        merchandise.PrName = syohinName;
                        merchandise.Price = int.Parse(sell);
                        merchandise.PrSafetyStock = int.Parse(safeNum);
                        merchandise.ScID = parsedSClassID;
                        merchandise.PrReleaseDate = syohinDate;
                        merchandise.PrModelNumber = tModel;
                        merchandise.PrColor = tColor;
                        merchandise.PrFlag = delFlag ? 1 : 0;

                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        Displaymerchandise();
                        Log_Merchandise(merchandise.PrID);
                        ResetYellowBackgrounds(this);
                    }
                    else
                    {
                        NotFound(TBSyohinID, "商品ID", syohinID);
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($":102\n入力形式が正しくありません。\n詳細: {ex.Message}",
                                    "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($":500\n予期しないエラーが発生しました。\n詳細: {ex.Message}",
                                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Registermerchandise()
        {
            string syohinID = TBSyohinID.Text;
            string makerID = TBMakerID.Text;
            string syohinName = TBSyohinName.Text;
            string sell = TBSell.Text;
            string safeNum = TBSafeNum.Text;
            string sclass = TBSyoubunrui.Text;
            string tModel = TBModel.Text;
            string tColor = TBColor.Text;
            DateTime syohinDate = date.Value;
            bool delFlag = DelFlag.Checked;
            string riyuu = TBRiyuu.Text;

            // 入力チェックを共通メソッドで実施
            if (CheckTBValue(TBMakerID, makerID, "メーカーID")) return;
            if (CheckTBValue(TBSyohinName, syohinName, "商品名")) return;
            if (CheckTBValue(TBSell, sell, "販売価格")) return;
            if (CheckTBValue(TBSafeNum, safeNum, "安全在庫数")) return;
            if (CheckTBValue(TBSyoubunrui, sclass, "小分類")) return;
            if (CheckTBValue(TBModel, tModel, "モデル番号")) return;
            if (CheckTBValue(TBColor, tColor, "色")) return;

            using (var context = new SalesManagementContext())
            {
                try
                {
                    // メーカーIDの存在確認
                    if (!int.TryParse(makerID, out int parsedMakerID) ||
                        !context.MMakers.Any(m => m.MaID == parsedMakerID))
                    {
                        NotFound(TBMakerID, "メーカーID", makerID);
                        return;
                    }

                    // 小分類IDの存在確認
                    if (!int.TryParse(sclass, out int parsedSClassID) ||
                        !context.MSmallClassifications.Any(sc => sc.ScID == parsedSClassID))
                    {
                        NotFound(TBSyoubunrui, "小分類ID", sclass);
                        return;
                    }

                    // 商品情報の登録
                    var newProduct = new MProduct
                    {
                        MaID = parsedMakerID,
                        PrName = syohinName,
                        Price = int.Parse(sell),
                        PrSafetyStock = int.Parse(safeNum),
                        ScID = parsedSClassID,
                        PrReleaseDate = syohinDate,
                        PrModelNumber = tModel,
                        PrColor = tColor,
                        PrFlag = delFlag ? 1 : 0,
                        PrHidden = riyuu
                    };

                    context.MProducts.Add(newProduct);
                    context.SaveChanges();

                    MessageBox.Show("登録が成功しました。");
                    Displaymerchandise();
                    Log_Merchandise(newProduct.PrID);
                    ResetYellowBackgrounds(this);

                    // 在庫0で在庫にも登録
                    var newStock = new TStock
                    {
                        PrID = newProduct.PrID, // 登録された商品のIDを取得
                        StQuantity = 0,         // 初期在庫数は0
                        StFlag = 0              // 必要に応じて初期値を設定
                    };

                    context.TStocks.Add(newStock);
                    context.SaveChanges(); // 在庫テーブルの登録を保存

                    MessageBox.Show("在庫テーブルへの登録が完了しました。");

                    DialogResult result = MessageBox.Show("自動発注処理を実行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // 「はい」が選択された場合
                    if (result == DialogResult.Yes)
                    {
                        // ついでに発注もすませてしまう
                        StockManager.CompareStock(newProduct.PrID, newStock.StQuantity);
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($":102\n入力形式が正しくありません。\n詳細: {ex.Message}",
                                    "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($":500\n予期しないエラーが発生しました。\n詳細: {ex.Message}",
                                    "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Displaymerchandise()//;/;//
        {
            try
            {
                using (var context = new SalesManagementContext())
                {

                    // checkBox_2 がチェックされている場合、全ての商品を表示
                    var merchandises = checkBox_2.Checked
                        ? (checkBox1.Checked
                            ? context.MProducts.OrderByDescending(m => m.PrID).ToList() // 降順
                            : context.MProducts.OrderBy(m => m.PrID).ToList())          // 昇順
                        : (checkBox1.Checked
                            ? context.MProducts
                                .Where(m => m.PrFlag != 1)
                                .OrderByDescending(m => m.PrID) // 条件に合致するものを降順で取得
                                .ToList()
                            : context.MProducts
                                .Where(m => m.PrFlag != 1)
                                .OrderBy(m => m.PrID)          // 条件に合致するものを昇順で取得
                                .ToList());

                    dataGridView1.DataSource = merchandises.Select(m => new
                    {
                        商品ID = m.PrID,
                        メーカーID = m.MaID,
                        商品名 = m.PrName,
                        値段 = m.Price.ToString("N0"),
                        安全在庫数 = m.PrSafetyStock.ToString("N0"),
                        小分類ID = m.ScID,
                        型番 = m.PrModelNumber,
                        色 = m.PrColor,
                        発売日 = m.PrReleaseDate,
                        非表示フラグ = m.PrFlag,
                        備考 = m.PrHidden
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Searchmerchandise()
        {

            using (var context = new SalesManagementContext())
            {
                // 各テキストボックスの値を取得 
                var SyohinID = TBSyohinID.Text.Trim();       // 商品
                var MakerID = TBMakerID.Text.Trim();           // めーかー 
                var SyohinName = TBSyohinName.Text.Trim();         //商品名
                var Sell = TBSell.Text.Trim();     // 値段
                var safe = TBSafeNum.Text.Trim();
                var shou = TBSyoubunrui.Text.Trim();
                var Model = TBModel.Text.Trim();     // かたばｊｎ 
                var color = TBColor.Text.Trim();
                DateTime? Date = dateCheckBox.Checked ? date.Value : (DateTime?)null; // チェックボックスで日付検索を制御


                // 基本的なクエリ 
                var query = context.MProducts.AsQueryable();

                // 社員IDを検索条件に追加 
                if (!string.IsNullOrEmpty(SyohinID) && int.TryParse(SyohinID, out int parsedSyohinID))
                {
                    query = query.Where(m => m.PrID == parsedSyohinID);
                }

                // 商品名を検索条件に追加 
                if (!string.IsNullOrEmpty(MakerID) && int.TryParse(MakerID, out int parsedMakerID))
                {
                    query = query.Where(m => m.MaID == parsedMakerID);
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
                    query = query.Where(m => m.ScID == parsedshou);
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
                // 注文日を検索条件に追加（チェックボックスがチェックされている場合）
                if (Date.HasValue)
                {
                    query = query.Where(order => order.PrReleaseDate == Date.Value);
                }




                // 結果を取得 
                var m = query.ToList();

                if (m.Any())
                {
                    // dataGridView1 に結果を表示 
                    dataGridView1.DataSource = m.Select(m => new
                    {
                        商品ID = m.PrID,
                        メーカーID = m.MaID,
                        商品名 = m.PrName,
                        値段 = m.Price,
                        安全在庫数 = m.PrSafetyStock,
                        小分類ID = m.ScID,
                        型番 = m.PrModelNumber,
                        色 = m.PrColor,
                        発売日 = m.PrReleaseDate,
                        非表示フラグ = m.PrFlag,
                        備考 = m.PrHidden,
                        削除フラグ = DelFlag.Checked ? 1 : 0
                    }).ToList();
                }
                else
                {
                    MessageBox.Show(":204\n該当の項目が見つかりません。", "DBエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (label2.Text == "登録")
                    {
                        TBSyohinID.Text = "";
                    }
                    else
                    {
                        TBSyohinID.Text = row.Cells["商品ID"].Value.ToString();
                    }
                    // 各テキストボックスにデータを入力
                    TBMakerID.Text = row.Cells["メーカーID"].Value.ToString();
                    TBSyohinName.Text = row.Cells["商品名"].Value.ToString();
                    TBSell.Text = row.Cells["値段"].Value.ToString().Replace(",", "").Trim();
                    date.Value = Convert.ToDateTime(row.Cells["発売日"].Value);
                    TBSafeNum.Text = row.Cells["安全在庫数"].Value.ToString();
                    TBSyoubunrui.Text = row.Cells["小分類ID"].Value.ToString();
                    TBModel.Text = row.Cells["型番"].Value.ToString();
                    TBColor.Text = row.Cells["色"].Value.ToString();
                    // 注文状態や非表示ボタン、備考も必要に応じて設定
                    // 非表示ボタンや備考もここで設定
                    // 例: hiddenButton.Text = row.Cells["非表示ボタン"].Value.ToString();
                    // 例: hiddenReason.Text = row.Cells["備考"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(":500\n不明なエラーが発生しました。\n: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void TBSyohinID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 6);
        }

        private void TBMakerID_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 4);
        }

        private void TBSyohinName_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 50);
        }

        private void TBSell_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 9);
        }

        private void TBSafeNum_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 4);
        }

        private void TBSyoubunrui_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 2);
        }

        private void TBModel_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 20);
        }

        private void TBColor_TextChanged(object sender, EventArgs e)
        {
            LimitTextLength(sender as TextBox, 20);
        }
        private void colorReset()
        {
            switch (CurrentStatus.CurrentStatusValue)
            {
                case CurrentStatus.Status.登録:
                    TBSyohinID.BackColor = Color.Gray;
                    TBSyohinID.Enabled = false;
                    TBMakerID.BackColor = SystemColors.Window;
                    TBSyohinName.BackColor = SystemColors.Window;
                    TBSell.BackColor = SystemColors.Window;
                    TBSafeNum.BackColor = SystemColors.Window;
                    TBSyoubunrui.BackColor = SystemColors.Window;
                    TBModel.BackColor = SystemColors.Window;
                    TBColor.BackColor = SystemColors.Window;
                    break;
                default:
                    TBSyohinID.BackColor = SystemColors.Window;
                    TBMakerID.BackColor = SystemColors.Window;
                    TBSyohinName.BackColor = SystemColors.Window;
                    TBSell.BackColor = SystemColors.Window;
                    TBSafeNum.BackColor = SystemColors.Window;
                    TBSyoubunrui.BackColor = SystemColors.Window;
                    TBModel.BackColor = SystemColors.Window;
                    TBColor.BackColor = SystemColors.Window;
                    break;
            }
        }
        private void SetupNumericOnlyTextBoxes()
        {
            // 対象のテキストボックスのみイベントを追加
            TBSyohinID.KeyPress += NumericTextBox_KeyPress;
            TBMakerID.KeyPress += NumericTextBox_KeyPress;
            TBSell.KeyPress += NumericTextBox_KeyPress;
            TBSafeNum.KeyPress += NumericTextBox_KeyPress;
            TBSyoubunrui.KeyPress += NumericTextBox_KeyPress;

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


        private void Log_Merchandise(int id)
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
                            Display = "商品",
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
