﻿using SalesManagement_SysDev.Classまとめ;
using SalesManagement_SysDev.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);

        }
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private bool isOrderSelected = true; // 初期状態を受注(TOrder)に設定
        private bool isRankSelected = true;
        private string orderFlag = "←商品"; // 初期状態を「注文」に設定
        private string buttonFlag = "ランキング";
        private int lastFocusedPanelID = 1;

        private void Ranking_Load(object sender, EventArgs e)
        {
            AddControlEventHandlers(RankingProduct, 1);  // パネル1の場合
            AddControlEventHandlers(RankingCustomer, 2);  // パネル2の場合
            AddControlEventHandlers(SaleProduct, 3);
            AddControlEventHandlers(SaleCustomer, 4);


            GlobalUtility.UpdateLabels(label_id, label_ename);
            ListBoxInitialize1();
            ListBoxInitialize2();
            ListBoxInitialize3();
            ListBoxInitialize4();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            b_FormSelector.Text = "←商品";
            RankChange.Text = "ランキング";
            DisplayRankingProduct();
            DisplayCustomerRanking();
            CurrentStatus.RankingMode(ItemType.商品);
            CurrentStatus.RankingSale(RankSale.ランキング);
            RankingCustomer.Visible = true;
            RankingProduct.Visible = true;
            SaleCustomer.Visible = false;
            SaleProduct.Visible = false;
        }

        private void b_kakutei_Click(object sender, EventArgs e)
        {
            try
            {
                // モードに基づいて処理を分岐
                switch (CurrentRanking)
                {
                    case CurrentStatus.ItemType.商品:
                        DisplayRankingProduct();
                        break;
                    case CurrentStatus.ItemType.顧客:
                        DisplayCustomerRanking();
                        break;
                    default:
                        MessageBox.Show("現在のモードは無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }
        //商品のランキング
        private void DisplayRankingProduct()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // ComboBoxで選ばれた番号を取得 
                    int condition = comboBox1.SelectedIndex + 1; // 0～2のインデックスを1～3に変換 

                    // 3つのテーブルを結合して、商品ID、商品名、数量、合計金額を取得 
                    var query = context.TSales
                        .Join(context.TSaleDetails,
                              sale => sale.SaID,
                              detail => detail.SaID,
                              (sale, detail) => new
                              {
                                  sale.SaDate,             // 売上日
                                  detail.PrID,
                                  detail.SaQuantity,
                                  detail.SaPrTotalPrice
                              })
                        .Join(context.MProducts,
                              detail => detail.PrID,
                              product => product.PrID,
                              (detail, product) => new
                              {
                                  detail.SaDate,         // 売上日
                                  product.PrID,
                                  product.PrName,
                                  detail.SaQuantity,
                                  detail.SaPrTotalPrice
                              })
                        .GroupBy(data => new { data.PrID, data.PrName }) // 商品IDと商品名でグループ化
                        .Select(g => new
                        {
                            商品ID = g.Key.PrID,
                            商品名 = g.Key.PrName,
                            数量 = g.Sum(x => x.SaQuantity),         // 売上数量の合計
                            合計金額 = g.Sum(x => x.SaPrTotalPrice), // 合計金額の合計
                            売上日 = g.Select(x => x.SaDate).FirstOrDefault() // 最初の売上日の取得
                        });

                    // checkBoxDateFilterがチェックされている場合、日付でフィルタリング
                    if (checkBoxDateFilter.Checked)
                    {
                        DateTime startDate = date.Value.Date;   // 開始日
                        DateTime endDate = date2.Value.Date;     // 終了日

                        // 日付範囲が逆転している場合のチェック 
                        if (startDate > endDate)
                        {
                            MessageBox.Show("開始日が終了日より後になっています。日付を正しく指定してください。",
                                            "入力エラー",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return; // 処理を中断 
                        }
                        // フィルタリング条件を追加
                        query = query.Where(x => x.売上日 >= startDate && x.売上日 <= endDate);
                    }

                    // checkBox1がチェックされている場合、checkedListBox1で選ばれた商品IDに絞り込む
                    if (checkBox1.Checked)
                    {
                        // checkedListBox1でチェックされた項目を抽出
                        var selectedProductIds = checkedListBox1.CheckedItems
                            .Cast<string>()
                            .Select(item => int.Parse(item.Split(':')[0])) // 商品IDを抽出
                            .ToList();

                        // 商品IDが選ばれたものだけをフィルタリング
                        query = query.Where(x => selectedProductIds.Contains(x.商品ID));
                    }
                    // checkBoxKingakuがチェックされている場合、合計金額の範囲を指定
                    if (checkBoxKingaku.Checked)
                    {
                        if (decimal.TryParse(TBKagenKin.Text, out decimal minPrice) && decimal.TryParse(TBJyogenKin.Text, out decimal maxPrice))
                        {
                            query = query.Where(x => x.合計金額 >= minPrice && x.合計金額 <= maxPrice);
                        }
                        else
                        {
                            MessageBox.Show("合計金額の下限または上限値が無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // checkBoxSuryoがチェックされている場合、数量の範囲を指定
                    if (checkBoxSuryo.Checked)
                    {
                        if (int.TryParse(TBKagen.Text, out int minQuantity) && int.TryParse(TBJyogen.Text, out int maxQuantity))
                        {
                            query = query.Where(x => x.数量 >= minQuantity && x.数量 <= maxQuantity);
                        }
                        else
                        {
                            MessageBox.Show("数量の下限または上限値が無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // ComboBoxの選択に応じた並び替え処理
                    switch (condition)
                    {
                        case 1: // 商品ID順
                            query = query.OrderBy(x => x.商品ID);
                            break;
                        case 2: // 売上数量順
                            query = query.OrderByDescending(x => x.数量);
                            break;
                        case 3: // 合計金額順
                            query = query.OrderByDescending(x => x.合計金額);
                            break;
                        default:
                            MessageBox.Show("無効な条件です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    // データ取得と書式設定
                    var result = query
                        .Select(x => new
                        {
                            x.商品ID,
                            x.商品名,
                            数量 = string.Format("{0:N0}", x.数量),       // 3桁区切り
                            合計金額 = string.Format("{0:N0}", x.合計金額) // 3桁区切り
                        })
                        .ToList();

                    // DataGridViewにデータを表示
                    dataGridView1.DataSource = result;

                    // 商品ID順以外の場合に上位5行を強調表示
                    if (condition != 1) // 商品ID順以外の場合
                    {
                        HighlightTopRows(5);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //顧客のランキング
        private void DisplayCustomerRanking()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // ComboBoxで選ばれた番号を取得
                    int condition = comboBox2.SelectedIndex + 1; // 0～2のインデックスを1～3に変換

                    // 顧客IDと売上IDに基づき、売上詳細（TSaleDetail）と売上（TSale）を結合
                    var query = context.TSales
                        .Join(context.TSaleDetails,
                              sale => sale.SaID,
                              detail => detail.SaID,
                              (sale, detail) => new
                              {
                                  sale.ClID,                     // 顧客ID
                                  sale.SaDate,                   // 売上日
                                  detail.SaPrTotalPrice,         // 合計金額
                                  detail.SaQuantity              // 売上数量
                              })
                        .Join(context.MClients,
                              sale => sale.ClID,
                              client => client.ClID,
                              (sale, client) => new
                              {
                                  sale.ClID,
                                  client.ClName,
                                  sale.SaDate,
                                  sale.SaPrTotalPrice,
                                  sale.SaQuantity
                              })
                        .GroupBy(data => new { data.ClID, data.ClName }) // 顧客IDと顧客名でグループ化
                        .Select(g => new
                        {
                            顧客ID = g.Key.ClID,
                            顧客名 = g.Key.ClName,
                            購入回数 = g.Count(),                           // 取引回数（顧客IDの出現回数）
                            合計金額 = g.Sum(x => x.SaPrTotalPrice),        // 購入金額の合計
                            売上日 = g.Select(x => x.SaDate).FirstOrDefault() // 最初の売上日の取得
                        });

                    // checkBoxDateFilterがチェックされている場合、日付でフィルタリング
                    if (checkBoxDateFilter.Checked)
                    {
                        DateTime startDate = date3.Value.Date;   // 開始日
                        DateTime endDate = date4.Value.Date;     // 終了日
                        DateTime startDate1 = date3.Value.Date;   // 開始日 
                        DateTime endDate1 = date4.Value.Date;   // 終了日 

                        // 日付範囲が逆転している場合のチェック 
                        if (startDate1 > endDate1)
                        {
                            MessageBox.Show("開始日が終了日より後になっています。日付を正しく指定してください。",
                                            "入力エラー",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return; // 処理を中断 
                        }

                        // フィルタリング条件を追加
                        query = query.Where(x => x.売上日 >= startDate && x.売上日 <= endDate);
                    }
                    // checkBox1がチェックされている場合、checkedListBox1で選ばれた商品IDに絞り込む
                    if (checkBox1.Checked)
                    {
                        // checkedListBox1でチェックされた項目を抽出
                        var selectedCustomerIds = checkedListBox2.CheckedItems
                            .Cast<string>()
                            .Select(item => int.Parse(item.Split(':')[0])) // 商品IDを抽出
                            .ToList();

                        // 商品IDが選ばれたものだけをフィルタリング
                        query = query.Where(x => selectedCustomerIds.Contains(x.顧客ID));
                    }

                    // checkBoxKingakuがチェックされている場合、合計金額の範囲を指定
                    if (checkBoxKingaku.Checked)
                    {
                        if (decimal.TryParse(TBKagenKin1.Text, out decimal minPrice) && decimal.TryParse(TBJyogenKin1.Text, out decimal maxPrice))
                        {
                            query = query.Where(x => x.合計金額 >= minPrice && x.合計金額 <= maxPrice);
                        }
                        else
                        {
                            MessageBox.Show("合計金額の下限または上限値が無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // checkBoxSuryoがチェックされている場合、数量の範囲を指定
                    if (checkBoxSuryo.Checked)
                    {
                        if (int.TryParse(TBKagen1.Text, out int minQuantity) && int.TryParse(TBJyogen1.Text, out int maxQuantity))
                        {
                            query = query.Where(x => x.購入回数 >= minQuantity && x.購入回数 <= maxQuantity);
                        }
                        else
                        {
                            MessageBox.Show("数量の下限または上限値が無効です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // ComboBoxの選択に応じた並び替え処理
                    switch (condition)
                    {
                        case 1: // 顧客ID順
                            query = query.OrderBy(x => x.顧客ID);
                            break;
                        case 2: // 取引回数順
                            query = query.OrderByDescending(x => x.購入回数);
                            break;
                        case 3: // 購入金額順
                            query = query.OrderByDescending(x => x.合計金額);
                            break;
                        default:
                            MessageBox.Show("無効な条件です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    // データ取得と書式設定
                    var result = query
                        .Select(x => new
                        {
                            x.顧客ID,
                            x.顧客名,
                            購入回数 = string.Format("{0:N0}", x.購入回数),   // 3桁区切り
                            合計金額 = string.Format("{0:N0}", x.合計金額)     // 3桁区切り
                        })
                        .ToList();

                    // DataGridViewにデータを表示
                    dataGridView2.DataSource = result;

                    // 商品ID順以外の場合に上位5行を強調表示
                    if (condition != 1) // 商品ID順以外の場合
                    {
                        HighlightTopRows2(5);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxDateFilter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBoxInitialize1()
        {
            try
            {
                // データベースのコンテキストを使用
                using (var context = new SalesManagementContext())
                {
                    // MProductsテーブルから商品ID（PrID）と商品名（PrName）を取得
                    var products = context.MProducts
                        .Select(p => new { p.PrID, p.PrName }) // 商品IDと商品名を取得
                        .ToList();

                    // CheckedListBoxをクリア
                    checkedListBox1.Items.Clear();

                    // 取得した商品をCheckedListBoxに追加
                    foreach (var product in products)
                    {
                        // 商品ID: 商品名 の形式で表示
                        checkedListBox1.Items.Add($"{product.PrID}: {product.PrName}");
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーハンドリング
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListBoxInitialize2()
        {
            try
            {
                // データベースのコンテキストを使用
                using (var context = new SalesManagementContext())
                {
                    // MClientsテーブルから顧客ID（ClID）と顧客名（ClName）を取得
                    var clients = context.MClients
                        .Select(c => new { c.ClID, c.ClName }) // 顧客IDと顧客名を取得
                        .ToList();

                    // CheckedListBoxをクリア
                    checkedListBox2.Items.Clear();

                    // 取得した顧客をCheckedListBoxに追加
                    foreach (var client in clients)
                    {
                        // 顧客ID: 顧客名 の形式で表示
                        checkedListBox2.Items.Add($"{client.ClID}: {client.ClName}");
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーハンドリング
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListBoxInitialize3()
        {
            try
            {
                // データベースのコンテキストを使用
                using (var context = new SalesManagementContext())
                {
                    // MProductsテーブルから商品ID（PrID）と商品名（PrName）を取得
                    var products = context.MProducts
                        .Select(p => new { p.PrID, p.PrName }) // 商品IDと商品名を取得
                        .ToList();

                    // CheckedListBoxをクリア
                    checkedListBox3.Items.Clear();

                    // 取得した商品をCheckedListBoxに追加
                    foreach (var product in products)
                    {
                        // 商品ID: 商品名 の形式で表示
                        checkedListBox3.Items.Add($"{product.PrID}: {product.PrName}");
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーハンドリング
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListBoxInitialize4()
        {
            try
            {
                // データベースのコンテキストを使用
                using (var context = new SalesManagementContext())
                {
                    // MProductsテーブルから商品ID（PrID）と商品名（PrName）を取得
                    var clients = context.MClients
                         .Select(c => new { c.ClID, c.ClName }) // 顧客IDと顧客名を取得
                         .ToList();

                    // CheckedListBoxをクリア
                    checkedListBox5.Items.Clear();

                    // 取得した商品をCheckedListBoxに追加
                    foreach (var client in clients)
                    {
                        // 商品ID: 商品名 の形式で表示
                        checkedListBox5.Items.Add($"{client.ClID}: {client.ClName}");
                    }
                }
            }
            catch (Exception ex)
            {
                // エラーハンドリング
                MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 上位行を強調表示するメソッド
        private void HighlightTopRows(int rowCount)
        {
            // 表示されているデータが少ない場合はその行数まで
            int rowsToHighlight = Math.Min(rowCount, dataGridView1.Rows.Count);

            for (int i = 0; i < rowsToHighlight; i++)
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                {
                    cell.Style.BackColor = Color.Yellow;  // 背景色を黄色に設定
                    //cell.Style.ForeColor = Color.Red;     // テキスト色を赤に設定
                }
            }

        }
        // 上位行を強調表示するメソッド
        private void HighlightTopRows2(int rowCount)
        {
            // 表示されているデータが少ない場合はその行数まで
            int rowsToHighlight = Math.Min(rowCount, dataGridView2.Rows.Count);

            for (int i = 0; i < rowsToHighlight; i++)
            {
                foreach (DataGridViewCell cell in dataGridView2.Rows[i].Cells)
                {
                    cell.Style.BackColor = Color.Yellow;  // 背景色を黄色に設定
                    //cell.Style.ForeColor = Color.Red;     // テキスト色を赤に設定
                }
            }
        }


        private void ToggleOrderSelection()
        {
            isOrderSelected = !isOrderSelected;
            orderFlag = isOrderSelected ? "←商品" : "顧客→";

            // CurrentStatusのモードを切り替える 
            CurrentStatus.RankingMode(isOrderSelected ? ItemType.商品 : ItemType.顧客);

            if (orderFlag == "←商品")
                lastFocusedPanelID = 1;
            else
            if (orderFlag == "顧客→")
                lastFocusedPanelID = 2;
        }

        private void RankSelection()
        {
            isRankSelected = !isRankSelected;
            buttonFlag = isRankSelected ? "ランキング" : "セール";

            // CurrentStatusのモードを切り替える 
            CurrentStatus.RankingSale(isRankSelected ? RankSale.ランキング : RankSale.セール);

            if (buttonFlag == "ランキング")
            {
                RankingCustomer.Visible = true;
                RankingProduct.Visible = true;
                SaleCustomer.Visible = false;
                SaleProduct.Visible = false;
            }
            else if (buttonFlag == "セール")
            {
                RankingCustomer.Visible = false;
                RankingProduct.Visible = false;
                SaleCustomer.Visible = true;
                SaleProduct.Visible = true;
            }
        }

        private void b_FormSelector_Click(object sender, EventArgs e)
        {
            try
            {
                // 状態を切り替える処理 
                ToggleOrderSelection();

                // b_FormSelectorのテキストを現在の状態に更新 
                UpdateFlagButtonText();


            }
            catch (Exception ex)
            {
                MessageBox.Show("ボタンのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFlagButtonText()
        {
            try
            {
                // b_FlagSelectorのテキストを現在の状態に合わせる 
                b_FormSelector.Text = orderFlag;
            }
            catch (Exception ex)
            {
                MessageBox.Show("フラグボタンのテキスト更新中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange()
        {
            try
            {
                // b_FlagSelectorのテキストを現在の状態に合わせる 
                RankChange.Text = buttonFlag;
            }
            catch (Exception ex)
            {
                MessageBox.Show("フラグボタンのテキスト更新中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBoxDateFilter.Checked = false;
            checkBoxKingaku.Checked = false;
            checkBoxSuryo.Checked = false;
            foreach (int index in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemChecked(index, false);
            }
            foreach (int index in checkedListBox2.CheckedIndices)
            {
                checkedListBox2.SetItemChecked(index, false);
            }
            TBJyogen.Text = null;
            TBKagen.Text = null;
            TBJyogen1.Text = null;
            TBKagen1.Text = null;
            TBJyogenKin.Text = null;
            TBKagenKin.Text = null;
            TBJyogenKin1.Text = null;
            TBKagenKin1.Text = null;
            date.Value = DateTime.Now;
            date2.Value = DateTime.Now;
            date3.Value = DateTime.Now;
            date4.Value = DateTime.Now;
            DisplayCustomerRanking();
            DisplayRankingProduct();
        }
        // パネル内のすべてのコントロールにEnterイベントを追加
        private void AddControlEventHandlers(Control panel, int panelID)
        {
            foreach (Control control in panel.Controls)
            {
                // コントロールにEnterイベントを追加
                control.Enter += (sender, e) => Control_Enter(sender, e, panelID);
            }
        }

        // コントロールが選択（フォーカス）された時
        private void Control_Enter(object sender, EventArgs e, int panelID)
        {
            // 異なるパネルに移動したときのみイベントを発生させる
            if (panelID != lastFocusedPanelID)
            {
                ToggleOrderSelection();
                UpdateFlagButtonText();
                lastFocusedPanelID = panelID; // 現在のパネルIDを更新
            }
        }

        private void ProductPrice(RankTable ProductRank)
        {
            // 割引率（10%）
            decimal discountRate = 0.10m;

            // 新しい注文がランキングに追加されたタイミングでの処理
            if (ProductRank.Quantity >= 2000)
            {
                using (var context = new SalesManagementContext())
                {
                    // すでに2000以上だった場合は割引を適用しない
                    var existingOrder = context.TSaleDetails.SingleOrDefault(o => o.PrID == ProductRank.ProductID);

                    // 新しい注文または数量が2000を超えた場合のみ割引を適用
                    if (existingOrder == null || existingOrder.SaQuantity < 2000)
                    {
                        var ptable = context.MProducts.ToList();
                        foreach (var product in ptable)
                        {
                            // Price（元の単価）に対して10%割引を適用して UniPrice（割引後単価）を更新
                            product.Price = product.Price * (1 - discountRate);

                            // ここでログなども表示可能
                            MessageBox.Show($"商品ID: {ProductRank.ProductID}の値段が10％オフの {product.Price}円になりました。");
                        }

                    }
                    context.SaveChanges();
                }

            }
        }
        private void UpdatePrice(RankTable productRank)
        {
            using (var context = new SalesManagementContext())
            {
                // RankTable の ProductID を使って MProduct から PrID を取得
                var matchingProduct = context.MProducts.SingleOrDefault(p => p.PrID == productRank.ProductID);

                // 一致する MProduct が見つかった場合、単価を更新
                if (matchingProduct != null)
                {
                    // MProduct の Price を RankTable の UnitPrice に設定
                    //productRank.Price = matchingProduct.Price;

                    // ログに表示（任意）
                    //MessageBox.Show($"Updated ProductID: {productRank.ProductID}, New UnitPrice: {productRank.UnitPrice}");

                    // データベースに変更を保存
                    context.SaveChanges();
                }
                else
                {
                    // 一致する商品が見つからない場合の処理
                    Console.WriteLine($"ProductID: {productRank.ProductID} was not found in MProducts.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                CurrentStatus.RankingMode(ItemType.商品);
                b_FormSelector.Text = "←商品";
                // 状態を切り替える処理 
                RankSelection();

                // b_FormSelectorのテキストを現在の状態に更新 
                buttonChange();

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("ボタンのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RankingCustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RankChange_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentStatus.RankingMode(ItemType.商品);
                b_FormSelector.Text = "←商品";
                // 状態を切り替える処理 
                RankSelection();

                // b_FormSelectorのテキストを現在の状態に更新 
                buttonChange();


            }
            catch (Exception ex)
            {
                MessageBox.Show("ボタンのクリック中にエラーが発生しました: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}