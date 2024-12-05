using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using static SalesManagement_SysDev.Classまとめ.GlobalBadge;
using SalesManagement_SysDev.Entity;
using System.Text.RegularExpressions;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class mainmenu3 : Form
    {
        private ClassChangeForms changeForm; // フォーム遷移を管理するクラスのインスタンス 
        private ClassAccessManager accessManager; // アクセス権限を管理するクラスのインスタンス 

        public mainmenu3()
        {
            InitializeComponent();
            this.Load += new EventHandler(mainmenu3_Load); // フォームの読み込みイベントにメソッドを追加 
            changeForm = new ClassChangeForms(this); // フォーム遷移用クラスのインスタンス作成 
            accessManager = new ClassAccessManager(Global.EmployeePermission); // グローバル変数から権限を設定 
        }

        // フォームの初期化処理
        private void mainmenu3_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベルを更新  
            LoadEmployeeName(); // 従業員名をデータベースから取得して表示 
            SetButtonPermissions(); // ボタンの権限を設定
            GlobalEmp.EmployeeName = label_ename.Text;
            LoadLogData();
            listViewLog.Scrollable = false;

           
            
            
        }
        // 従業員名をデータベースから取得して表示するメソッド
        private void LoadEmployeeName()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // Global.EmployeeIDに基づいて従業員情報を取得
                    var employee = context.MEmployees
                        .Include(e => e.Po) // 職位情報を含めて取得 
                        .SingleOrDefault(e => e.EmID == Global.EmployeeID); // EmployeeIDを直接比較 

                    // 従業員が見つかった場合
                    if (employee != null)
                    {
                        label_id.Text = employee.Po.PoName; // 職位名をラベルに表示   
                    }
                    else
                    {
                        label_id.Text = "未登録"; // 従業員が見つからなかった場合のフォールバック 
                    }
                }
            }
            catch (DbUpdateException dbEx)
            {
                // データベースエラーが発生した場合の処理
                MessageBox.Show($"データベースのエラーが発生しました: {dbEx.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // その他の予期しないエラーが発生した場合の処理
                MessageBox.Show($"予期しないエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ボタンの権限を設定するメソッド
        private void SetButtonPermissions()
        {
            // 操作可能なボタンのリスト
            List<Button> buttons = new List<Button>
            {
                b_hor, b_rec, b_cus, b_mer, b_sto, b_emp,
                b_add, b_ord, b_iss, b_arr, b_shi, b_sal,
                b_JU, b_HN, b_mas, Loginkanri
            };

            // グローバル変数から権限に応じてボタンを有効・無効に設定
            switch (Global.EmployeePermission)
            {
                case 1: // 管理者
                    foreach (var button in buttons)
                        button.Enabled = true; // 全ボタンを有効化 
                    break;

                case 2: // 営業
                    foreach (var button in buttons)
                        button.Enabled = new[] { b_cus, b_add, b_arr, b_ord, b_shi, b_sal, b_JU, b_mas, Loginkanri }.Contains(button);
                    break;

                case 3: // 物流
                    foreach (var button in buttons)
                        button.Enabled = new[] { b_mer, b_sto, b_rec, b_iss, b_hor, b_JU, b_HN, b_mas, Loginkanri }.Contains(button);
                    break;

                default:
                    foreach (var button in buttons)
                        button.Enabled = false; // 権限が不明な場合はすべてのボタンを無効化 
                    break;
            }

            // 無効なボタンの色を濃い灰色に変更
            foreach (var button in buttons)
            {
                if (!button.Enabled)
                {
                    button.BackColor = Color.DarkGray; // 入れないボタンの色を変更 
                }
            }
        }

        // エラーハンドリング用メソッド
        private void HandleNavigationError(Action action)
        {
            try
            {
                action(); // 引数で渡されたアクションを実行
            }
            catch (Exception ex)
            {
                // ナビゲーション中にエラーが発生した場合の処理
                MessageBox.Show($"ナビゲーション中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ログアウトボタンのクリックイベント
        private void b_logout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("ログアウトしてもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // グローバル変数のリセット
                Global.EmployeeID = 0; // または適切な初期値にリセット  
                Global.EmployeeName = string.Empty;
                Global.PositionName = string.Empty;
                Global.EmployeePermission = 0;
                this.Close(); // 現在のフォームを閉じる 
                Log_Out();
                F_login loginForm = new F_login(); // ログインフォームを作成 
                loginForm.Show(); // ログインフォームを表示 

            }
        }

        // 各ボタンのクリックイベント（ナビゲーション）
        private void b_add_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToAcceptingOrderForm()); // 受注登録フォームに遷移 
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToOrderForm()); // 発注フォームに遷移 
        }

        private void b_iss_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToIssueForm()); // 出荷フォームに遷移 
        }

        private void b_arr_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToArrivalForm()); // 入庫フォームに遷移 
        }

        private void b_shi_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToShippingForm()); // 配送フォームに遷移 
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToSalesForm()); // 売上フォームに遷移 
        }

        private void b_emp_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToEmployeeForm()); // 従業員フォームに遷移 
        }

        private void b_mer_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToMerchandiseForm()); // 商品フォームに遷移 
        }

        private void b_sto_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToStockForm()); // 在庫フォームに遷移 
        }

        private void b_cus_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToCustomerForm()); // 顧客フォームに遷移 
        }

        private void b_hor_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToHorderForm()); // 注文フォームに遷移 
        }
        private void b_rec_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToReceivingstockForm());
        }

        private void Loginkanri_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.NavigateToLogForm()); // ログ管理フォームに遷移 
        }

        private void b_JU_Click(object sender, EventArgs e)
        {
            // JUタブを表示する処理
            HN.Visible = false;
            mas.Visible = false;
            JU.Visible = true;
        }

        private void b_HN_Click(object sender, EventArgs e)
        {
            // HNタブを表示する処理
            JU.Visible = false;
            mas.Visible = false;
            HN.Visible = true;
        }

        private void b_mas_Click(object sender, EventArgs e)
        {
            // masタブを表示する処理
            HN.Visible = false;
            JU.Visible = false;
            mas.Visible = true;
        }

        private void JU_Paint(object sender, PaintEventArgs e)
        {
            // Paint処理（必要に応じて実装） 
        }

        private void b_JU_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TOrders.Count(order => order.OrStateFlag == 0 || order.OrStateFlag == null);
                count += context.TChumons.Count(order => order.ChStateFlag == 0 || order.ChStateFlag == null);
                count += context.TSyukkos.Count(order => order.SyStateFlag == 0 || order.SyStateFlag == null);
                count += context.TArrivals.Count(order => order.ArStateFlag == 0 || order.ArStateFlag == null);
                count += context.TShipments.Count(order => order.ShStateFlag == 0 || order.ShStateFlag == null);

                if (count > 0)
                {
                    Button button = sender as Button;
                    if (button != null && button.Enabled)
                    {
                        GlobalBadge badge = new GlobalBadge("!"); // 通知数を指定
                        badge.DrawBadge(e, button); // バッジを描画
                    }
                }
            }
        }

        private void b_HN_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TWarehousings.Count(order => order.WaShelfFlag == 0 || order.WaShelfFlag == null);
                count += context.THattyus.Count(order => order.WaWarehouseFlag == 0 || order.WaWarehouseFlag == null);

                if (count > 0)
                {
                    Button button = sender as Button;
                    if (button != null && button.Enabled)
                    {
                        GlobalBadge badge = new GlobalBadge("!"); // 通知数を指定
                        badge.DrawBadge(e, button); // バッジを描画
                    }
                }
            }
        }

        private void b_add_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TOrders.Count(order => order.OrStateFlag == 0 || order.OrStateFlag == null);
                GlobalBadge badge = new GlobalBadge(count); // 通知数を指定
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {

                    // バッジを描画
                    if (button != null)
                    {
                        badge.SecondBadge(e, button);
                    }
                }

            }
        }

        private void b_ord_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TChumons.Count(order => order.ChStateFlag == 0 || order.ChStateFlag == null);
                GlobalBadge badge = new GlobalBadge(count); // 通知数を指定

                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    // ボタンを取得

                    // バッジを描画
                    if (button != null)
                    {
                        badge.SecondBadge(e, button);
                    }
                }
            }
        }

        private void b_iss_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TSyukkos.Count(order => order.SyStateFlag == 0 || order.SyStateFlag == null);
                GlobalBadge badge = new GlobalBadge(count); // 通知数を指定

                // ボタンを取得
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {

                    // バッジを描画
                    if (button != null)
                    {
                        badge.SecondBadge(e, button);
                    }
                }
            }
        }

        private void b_arr_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TArrivals.Count(order => order.ArStateFlag == 0 || order.ArStateFlag == null);
                GlobalBadge badge = new GlobalBadge(count); // 通知数を指定
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    // バッジを描画
                    if (button != null)
                    {
                        badge.SecondBadge(e, button);
                    }
                }
            }
        }

        private void b_shi_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TShipments.Count(order => order.ShStateFlag == 0 || order.ShStateFlag == null);
                GlobalBadge badge = new GlobalBadge(count); // 通知数を指定
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    // バッジを描画
                    if (button != null)
                    {
                        badge.SecondBadge(e, button);
                    }
                }
            }
        }

        private void b_hor_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.THattyus.Count(order => order.WaWarehouseFlag == 0 || order.WaWarehouseFlag == null);
                GlobalBadge badge = new GlobalBadge(count); // 通知数を指定
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    return; // 描画処理を行わない
                }
                else if (count > 0)
                {
                    // バッジを描画
                    if (button != null)
                    {
                        badge.SecondBadge(e, button);
                    }
                }
            }
        }

        private void b_rec_Paint(object sender, PaintEventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                int count = context.TWarehousings.Count(order => order.WaShelfFlag == 0 || order.WaShelfFlag == null);
                GlobalBadge badge = new GlobalBadge(count); // 通知数を指定
                Button button = sender as Button;
                if (button.Enabled == false)
                {
                    b_mas.Refresh(); // 描画処理を行わない
                }
                else if (count > 0)
                {
                    // バッジを描画
                    if (button != null)
                    {
                        badge.SecondBadge(e, button);
                    }
                }
            }
        }
        private void Log_Out()
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
                            Display = "メインメニュー",
                            Mode = "-",
                            Process = "ログアウト",
                            LogID = 0,  //
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

        private void b_rank_Click(object sender, EventArgs e)
        {
            HandleNavigationError(() => changeForm.ranking()); // 従業員フォームに遷移
        }

        private void LoadLogData()
        {
            // ListViewの初期化
            listViewLog.Items.Clear();
            listViewLog.View = View.Details; // 詳細表示モード
            listViewLog.FullRowSelect = true;

            // 列の設定
            listViewLog.Columns.Clear();
            listViewLog.Columns.Add("ID", 50, HorizontalAlignment.Left); // 表示するIDをDetailIDに変更
            listViewLog.Columns.Add("ログ詳細", 500, HorizontalAlignment.Left);
            // ヘッダーを非表示にする
            listViewLog.HeaderStyle = ColumnHeaderStyle.None;

            try
            {
                using (var context = new SalesManagementContext())
                {
                    // Processが「自動発注」または「ログアウト」以外のものをフィルタリング
                    var logs = (from log in context.LoginHistoryLogs
                                join detail in context.LoginHistoryLogDetails
                                    on log.ID equals detail.ID
                                join employee in context.MEmployees
                                    on log.LoginID equals employee.EmID.ToString()
                                where !(detail.Process == "自動発注" || detail.Process == "ログアウト") // Processが「自動発注」または「ログアウト」ではない
                                orderby detail.AcceptDateTime descending
                                select new
                                {
                                    detail.DetailID,
                                    detail.AcceptDateTime,
                                    EmployeeName = employee.EmName,
                                    detail.Display,
                                    detail.Mode,
                                    detail.Process,
                                    log.LoginID
                                }).Take(3).ToList();

                    // 取得したログデータをListViewに登録
                    foreach (var log in logs)
                    {
                        string logDetail = $"{log.AcceptDateTime:yyyy/MM/dd HH:mm}｜{log.EmployeeName}が{log.Display}{log.Mode}を{log.Process}しました";

                        // ListViewの行を追加
                        var listViewItem = new ListViewItem(log.DetailID.ToString()); // DetailIDを表示
                        listViewItem.SubItems.Add(logDetail);
                        listViewLog.Items.Add(listViewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                // エラー表示
                MessageBox.Show("エラーが発生しました: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listViewLog_MouseClick(object sender, MouseEventArgs e)
        {
            // クリックした位置を取得
            var hitTestInfo = listViewLog.HitTest(e.Location);
            var clickedItem = hitTestInfo.Item;

            if (clickedItem != null)
            {
                // クリックされたサブアイテムを取得（log.Displayが格納されている部分）
                var clickedSubItem = clickedItem.SubItems[1];  // 例えば、log.Displayの部分

                // log.Displayの部分を取得
                string displayText = clickedSubItem.Text;

                // 検索するキーワードをリストとして定義
                List<string> keywords = new List<string>
                {
                    "受注", "注文", "出庫", "入荷", "出荷",
                    "売上", "発注", "入庫", "顧客", "社員",
                    "商品", "在庫"
                };
                // 抽出した文字を格納するリスト
                List<string> extractedStrings = new List<string>();

                // displayTextに含まれているキーワードを探してリストに追加
                foreach (var keyword in keywords)
                {
                    if (displayText.Contains(keyword))
                    {
                        extractedStrings.Add(keyword); // 見つかったキーワードをリストに追加
                    }
                }

                // リストの内容を確認
                foreach (var extracted in extractedStrings)
                {
                    MessageBox.Show("リストに追加された文字: " + extracted);
                }

                // 「受注」がリストに含まれている場合の処理
                if (extractedStrings.Contains("受注"))
                {
                    // 権限チェック
                    if (Global.PositionName != "物流")
                    {
                        HandleNavigationError(() => changeForm.NavigateToAcceptingOrderForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("注文"))
                {
                    // 権限チェック
                    if (Global.PositionName != "物流")
                    {
                        HandleNavigationError(() => changeForm.NavigateToOrderForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("出庫"))
                {
                    // 権限チェック
                    if (Global.PositionName != "営業")
                    {
                        HandleNavigationError(() => changeForm.NavigateToIssueForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("入荷"))
                {
                    // 権限チェック
                    if (Global.PositionName != "物流")
                    {
                        HandleNavigationError(() => changeForm.NavigateToArrivalForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("出荷"))
                {
                    // 権限チェック
                    if (Global.PositionName != "物流")
                    {
                        HandleNavigationError(() => changeForm.NavigateToShippingForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("売上"))
                {
                    // 権限チェック
                    if (Global.PositionName != "物流")
                    {
                        HandleNavigationError(() => changeForm.NavigateToSalesForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("発注"))
                {
                    // 権限チェック
                    if (Global.PositionName != "営業")
                    {
                        HandleNavigationError(() => changeForm.NavigateToHorderForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("入庫"))
                {
                    // 権限チェック
                    if (Global.PositionName != "営業")
                    {
                        HandleNavigationError(() => changeForm.NavigateToReceivingstockForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("顧客"))
                {
                    // 権限チェック
                    if (Global.PositionName != "物流")
                    {
                        HandleNavigationError(() => changeForm.NavigateToCustomerForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("商品"))
                {
                    // 権限チェック
                    if (Global.PositionName != "営業")
                    {
                        HandleNavigationError(() => changeForm.NavigateToMerchandiseForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("在庫"))
                {
                    // 権限チェック
                    if (Global.PositionName != "営業")
                    {
                        HandleNavigationError(() => changeForm.NavigateToStockForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }
                if (extractedStrings.Contains("社員"))
                {
                    // 権限チェック
                    if (Global.PositionName != "物流" && Global.PositionName != "営業")
                    {
                        HandleNavigationError(() => changeForm.NavigateToEmployeeForm()); // 受注登録フォームに遷移 

                    }
                    else
                    {
                        MessageBox.Show("権限がありません。");
                    }
                }


            }
        }


    }
}
