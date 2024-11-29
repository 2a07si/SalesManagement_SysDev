using SalesManagement_SysDev.Classまとめ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
        
        }
        private ClassChangeForms formChanger; // 画面遷移管理クラス 

        private void Ranking_Load(object sender, EventArgs e)
        {

        }

        private void b_kakutei_Click(object sender, EventArgs e)
        {
            DisplayCustomerRanking();
            DisplayRankingProduct();
        }

        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateTo3();
        }

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
                                  detail.PrID,
                                  detail.SaQuantity,
                                  detail.SaPrTotalPrice
                              })
                        .Join(context.MProducts,
                              detail => detail.PrID,
                              product => product.PrID,
                              (detail, product) => new
                              {
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
                            数量 = g.Sum(x => x.SaQuantity),          // 売上数量の合計
                            合計金額 = g.Sum(x => x.SaPrTotalPrice)  // 合計金額の合計
                        });

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DisplayCustomerRanking()
        {
            try
            {
                using (var context = new SalesManagementContext())
                {
                    // ComboBoxで選ばれた番号を取得
                    int condition = comboBox1.SelectedIndex + 1; // 0～2のインデックスを1～3に変換

                    // 顧客IDと売上IDに基づき、売上詳細（TSaleDetail）と売上（TSale）を結合
                    var query = context.TSales
                        .Join(context.TSaleDetails,
                              sale => sale.SaID,
                              detail => detail.SaID,
                              (sale, detail) => new
                              {
                                  sale.ClID,                     // 顧客ID
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
                                  sale.SaPrTotalPrice,
                                  sale.SaQuantity
                              })
                        .GroupBy(data => new { data.ClID, data.ClName }) // 顧客IDと顧客名でグループ化
                        .Select(g => new
                        {
                            顧客ID = g.Key.ClID,
                            顧客名 = g.Key.ClName,
                            取引回数 = g.Count(),                           // 取引回数（顧客IDの出現回数）
                            合計金額 = g.Sum(x => x.SaPrTotalPrice)        // 購入金額の合計
                        });

                    // ComboBoxの選択に応じた並び替え処理
                    switch (condition)
                    {
                        case 1: // 顧客ID順
                            query = query.OrderBy(x => x.顧客ID);
                            break;
                        case 2: // 取引回数順
                            query = query.OrderByDescending(x => x.取引回数);
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
                            取引回数 = string.Format("{0:N0}", x.取引回数),   // 3桁区切り
                            合計金額 = string.Format("{0:N0}", x.合計金額)     // 3桁区切り
                        })
                        .ToList();

                    // DataGridViewにデータを表示
                    dataGridView2.DataSource = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラー: " + ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
