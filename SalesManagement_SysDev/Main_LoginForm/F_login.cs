using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using SalesManagement_SysDev.Main_LoginForm;
using static SalesManagement_SysDev.Classまとめ.GlobalEmpNo;
using SalesManagement_SysDev.Entity;

namespace SalesManagement_SysDev
{
    public partial class F_login : Form
    {
        private ClassDateNamelabel dateNameLabel;
        private bool isPasswordVisible = true;  // パスワード表示状態を管理するフラグ 
        private ClassTimerManager timerManager;
        private ClassChangeForms classChangeForms;
        public F_login()
        {
            InitializeComponent();

            // 初期状態でパスワードを隠す 
            tb_Pass.UseSystemPasswordChar = false;  // パスワードを非表示にする 

            // タイマーやその他の初期設定 
            this.dateNameLabel = new ClassDateNamelabel(labeltime, labeldate);
            this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate);
            this.classChangeForms = new ClassChangeForms(this);
            timer1.Start();
        }

        private void btn_CleateDabase_Click(object sender, EventArgs e)
        {
            //データベースの生成を行います．
            //再度実行する場合には，必ずデータベースの削除をしてから実行してください．

            using SalesManagementContext context = new SalesManagementContext();

            context.Database.EnsureCreated();

            List<MPosition> po = new List<MPosition>();
            {
                po.Add(new MPosition()
                {
                    PoName = "管理者",
                    PoFlag = 0,
                });
                po.Add(new MPosition()
                {
                    PoName = "営業",
                    PoFlag = 0,
                });
                po.Add(new MPosition()
                {
                    PoName = "物流",
                    PoFlag = 0,
                });
                context.MPositions.AddRange(po);
                context.SaveChanges();
            }

            MessageBox.Show("テーブル作成完了");
        }

        private void btn_InsertSampleData_Click(object sender, EventArgs e)
        {
            using SalesManagementContext context = new SalesManagementContext();

            List<MPosition> po = context.MPositions.OrderBy(x => x.PoID).ToList();
            List<MMaker> ma = new List<MMaker>();
            List<MSalesOffice> so = new List<MSalesOffice>();
            List<MClient> cl = new List<MClient>();
            Dictionary<int, MEmployee> em = new Dictionary<int, MEmployee>();
            List<MMajorClassification> mc = new List<MMajorClassification>();
            List<MSmallClassification> sc = new List<MSmallClassification>();
            List<MProduct> pr = new List<MProduct>();

            {
                ma.Add(new MMaker()
                {
                    MaName = "Aメーカ",
                    MaAddress = "大阪",
                    MaPhone = "000-0000-0000",
                    MaPostal = "0000000",
                    MaFax = "000-0000-0000",
                    MaFlag = 0,
                });
                ma.Add(new MMaker()
                {
                    MaName = "Bメーカ",
                    MaAddress = "京都",
                    MaPhone = "000-0000-0000",
                    MaPostal = "0000000",
                    MaFax = "000-0000-0000",
                    MaFlag = 0,
                });
                ma.Add(new MMaker()
                {
                    MaName = "Cメーカ",
                    MaAddress = "和歌山",
                    MaPhone = "000-0000-0000",
                    MaPostal = "0000000",
                    MaFax = "000-0000-0000",
                    MaFlag = 0,
                });
                ma.Add(new MMaker()
                {
                    MaName = "Dメーカ",
                    MaAddress = "滋賀",
                    MaPhone = "000-0000-0000",
                    MaPostal = "0000000",
                    MaFax = "000-0000-0000",
                    MaFlag = 0,
                });
                context.MMakers.AddRange(ma);
                context.SaveChanges();
            }
            {
                so.Add(new MSalesOffice()
                {
                    SoName = "北大阪営業所",
                    SoAddress = "大阪府吹田市寿町3-4-40",
                    SoPhone = "06-7011-6123",
                    SoPostal = "5600046",
                    SoFax = "06-6562-2740",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "兵庫営業所",
                    SoAddress = "兵庫県姫路市東辻井2-5-20",
                    SoPhone = "079-669-4326",
                    SoPostal = "6700994",
                    SoFax = "079-669-4327",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "鹿営業所",
                    SoAddress = "奈良県生駒郡三郷町勢野8-7-50",
                    SoPhone = "0745-99-0084",
                    SoPostal = "6360814",
                    SoFax = "0746-0-1160",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "京都営業所",
                    SoAddress = "京都府京都市山科区東野南井ノ上町10-3-7",
                    SoPhone = "077-672-6006",
                    SoPostal = "6078143",
                    SoFax = "0771-85-2574",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "和歌山営業所",
                    SoAddress = "和歌山県和歌山市柳丁4-19",
                    SoPhone = "073-887-1927",
                    SoPostal = "6408336",
                    SoFax = "0735-78-4874",
                    SoFlag = 0,
                });
                context.MSalesOffices.AddRange(so);
                context.SaveChanges();
            }
            {
                cl.Add(new MClient()
                {
                    ClName = "上村電機",
                    ClAddress = "京都府京都市伏見区塩屋町3-9-95",
                    ClPhone = "077-672-6006",
                    ClPostal = "6128046",
                    ClFax = "077-581-0164",
                    ClFlag = 0,
                    So = so[3],
                });
                cl.Add(new MClient()
                {
                    ClName = "萬田金融",
                    ClAddress = "大阪府大阪市西区北堀江1丁目22-3",
                    ClPhone = "06-8757-6267",
                    ClPostal = "5500014",
                    ClFax = "06-8757-6267",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "宝田電機",
                    ClAddress = "大阪府大阪市中央区和泉町2-5-46",
                    ClPhone = "06-1423-1895",
                    ClPostal = "5720806",
                    ClFax = "06-1374-4358",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "INATUGI",
                    ClAddress = "大阪府茨木市横江2-5-60",
                    ClPhone = "072-02-5171",
                    ClPostal = "5670044",
                    ClFax = "072-018-0116",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "水野電機",
                    ClAddress = "大阪府豊中市末広町2-6-13",
                    ClPhone = "06-2096-0974",
                    ClPostal = "5600024",
                    ClFax = "06-2434-2434",
                    ClFlag = 0,
                    So = so[1],
                });
                cl.Add(new MClient()
                {
                    ClName = "ショップ赤川",
                    ClAddress = "大阪府大阪市天王寺区上本町",
                    ClPhone = "090-1111-1111",
                    ClPostal = "5430001",
                    ClFax = "06-1111-1111",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "成田",
                    ClAddress = "奈良県御所市船路2-8-87",
                    ClPhone = "0746-0-1160",
                    ClPostal = "6392268",
                    ClFax = "0746-0-1160",
                    ClFlag = 0,
                    So = so[2],
                });
                context.MClients.AddRange(cl);
                context.SaveChanges();
            }
            {
                if (context.MEmployees.Where(x => x.EmID == 116).Count() == 0)
                {
                    em.Add(116, new MEmployee()
                    {
                        EmID = 116,
                        EmName = "坂口郁美",
                        EmHiredate = new DateTime(1980, 6, 17),
                        EmPassword = "0116",
                        EmPhone = "06-6813-5485",
                        So = so[1],
                        Po = po[2],
                    });
                }
                if (context.MEmployees.Where(x => x.EmID == 310).Count() == 0)
                {
                    em.Add(310, new MEmployee()
                    {
                        EmID = 310,
                        EmName = "高谷春男",
                        EmHiredate = new DateTime(1973, 3, 21),
                        EmPassword = "0310",
                        EmPhone = "06-6356-8742",
                        So = so[0],
                        Po = po[1],
                    });
                }
                if (context.MEmployees.Where(x => x.EmID == 1002).Count() == 0)
                {
                    em.Add(1002, new MEmployee()
                    {
                        EmID = 1002,
                        EmName = "日下部俊夫",
                        EmHiredate = new DateTime(1990, 9, 4),
                        EmPassword = "1002",
                        EmPhone = "06-6579-0622",
                        So = so[0],
                        Po = po[1],
                    });
                }
                if (context.MEmployees.Where(x => x.EmID == 1007).Count() == 0)
                {
                    em.Add(1007, new MEmployee()
                    {
                        EmID = 1007,
                        EmName = "岸本芽生",
                        EmHiredate = new DateTime(1997, 2, 4),
                        EmPassword = "1007",
                        EmPhone = "075-425-3371",
                        So = so[2],
                        Po = po[1],
                    });
                }
                if (context.MEmployees.Where(x => x.EmID == 1111).Count() == 0)
                {
                    em.Add(1111, new MEmployee()
                    {
                        EmID = 1111,
                        EmName = "奥村敦彦",
                        EmHiredate = new DateTime(1985, 3, 17),
                        EmPassword = "999",
                        EmPhone = "079-145-6121",
                        So = so[3],
                        Po = po[2],
                    });
                }
                if (context.MEmployees.Where(x => x.EmID == 1208).Count() == 0)
                {
                    em.Add(1208, new MEmployee()
                    {
                        EmID = 1208,
                        EmName = "渋谷秋昴",
                        EmHiredate = new DateTime(1994, 1, 31),
                        EmPassword = "1208",
                        EmPhone = "0790-68-8043",
                        So = so[4],
                        Po = po[1],
                    });
                }
                if (context.MEmployees.Where(x => x.EmID == 1227).Count() == 0)
                {
                    em.Add(1227, new MEmployee()
                    {
                        EmID = 1227,
                        EmName = "生田徳次郎",
                        EmHiredate = new DateTime(1964, 3, 20),
                        EmPassword = "1227",
                        EmPhone = "06-3021-1630",
                        So = so[0],
                        Po = po[0],
                    });
                }
                context.MEmployees.AddRange(em.Values);
                context.SaveChanges();
                foreach (var emp in context.MEmployees)
                {
                    em[emp.EmID] = emp;
                }
            }
            {
                mc.Add(new MMajorClassification()
                {
                    McName = "テレビ・レコーダー",
                    McFlag = 0,
                });
                mc.Add(new MMajorClassification()
                {
                    McName = "エアコン・冷蔵庫・洗濯機",
                    McFlag = 0,
                });
                mc.Add(new MMajorClassification()
                {
                    McName = "オーディオ・イヤホン・ヘッドホン",
                    McFlag = 0,
                });
                mc.Add(new MMajorClassification()
                {
                    McName = "携帯電話・スマートフォン",
                    McFlag = 0,
                });
                context.MMajorClassifications.AddRange(mc);
                context.SaveChanges();
            }
            {
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[0],
                    ScName = "テレビ",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[0],
                    ScName = "レコーダー",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[1],
                    ScName = "エアコン",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[1],
                    ScName = "冷蔵庫",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[1],
                    ScName = "洗濯機",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[2],
                    ScName = "オーディオ",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[2],
                    ScName = "イヤホン",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[2],
                    ScName = "ヘッドホン",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[3],
                    ScName = "携帯電話",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[3],
                    ScName = "スマートフォン",
                    ScFlag = 0,
                });
                context.MSmallClassifications.AddRange(sc);
                context.SaveChanges();
            }
            {
                pr.Add(new MProduct()
                {
                    Ma = ma[0],
                    PrName = "テレビA",
                    Price = 100000,
                    PrSafetyStock = 100,
                    Sc = sc[0],
                    PrModelNumber = "1",
                    PrColor = "黒",
                    PrReleaseDate = new DateTime(2019, 5, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[0],
                    PrName = "テレビB",
                    Price = 98000,
                    PrSafetyStock = 100,
                    Sc = sc[0],
                    PrModelNumber = "1",
                    PrColor = "黒",
                    PrReleaseDate = new DateTime(2019, 5, 10),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[0],
                    PrName = "レコーダーA",
                    Price = 5000,
                    PrSafetyStock = 50,
                    Sc = sc[1],
                    PrModelNumber = "1",
                    PrColor = "黒",
                    PrReleaseDate = new DateTime(2019, 10, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[1],
                    PrName = "エアコンA",
                    Price = 160000,
                    PrSafetyStock = 50,
                    Sc = sc[2],
                    PrModelNumber = "1",
                    PrColor = "白",
                    PrReleaseDate = new DateTime(2020, 10, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[1],
                    PrName = "冷蔵庫A",
                    Price = 200000,
                    PrSafetyStock = 50,
                    Sc = sc[3],
                    PrModelNumber = "1",
                    PrColor = "白",
                    PrReleaseDate = new DateTime(2020, 1, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[1],
                    PrName = "洗濯機A",
                    Price = 150000,
                    PrSafetyStock = 50,
                    Sc = sc[4],
                    PrModelNumber = "1",
                    PrColor = "白",
                    PrReleaseDate = new DateTime(2019, 3, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[2],
                    PrName = "オーディオA",
                    Price = 6000,
                    PrSafetyStock = 10,
                    Sc = sc[5],
                    PrModelNumber = "1",
                    PrColor = "黒",
                    PrReleaseDate = new DateTime(2020, 8, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[2],
                    PrName = "イヤホンA",
                    Price = 5000,
                    PrSafetyStock = 100,
                    Sc = sc[6],
                    PrModelNumber = "1",
                    PrColor = "赤",
                    PrReleaseDate = new DateTime(2019, 5, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[3],
                    PrName = "iphone8",
                    Price = 78800,
                    PrSafetyStock = 50,
                    Sc = sc[8],
                    PrModelNumber = "1",
                    PrColor = "ゴールド",
                    PrReleaseDate = new DateTime(2017, 9, 22),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[3],
                    PrName = "スマートフォンA",
                    Price = 30000,
                    PrSafetyStock = 50,
                    Sc = sc[9],
                    PrModelNumber = "1",
                    PrColor = "シルバー",
                    PrReleaseDate = new DateTime(2019, 5, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[3],
                    PrName = "スマートフォンB",
                    Price = 40000,
                    PrSafetyStock = 50,
                    Sc = sc[9],
                    PrModelNumber = "1",
                    PrColor = "黒",
                    PrReleaseDate = new DateTime(2020, 11, 1),
                    PrFlag = 0,
                });
                context.MProducts.AddRange(pr);
                context.SaveChanges();
            }
            List<TStock> st = new List<TStock>();
            {
                st.Add(new TStock()
                {
                    Pr = pr[0],
                    StQuantity = 100,
                    StFlag = 0,
                });
                st.Add(new TStock()
                {
                    Pr = pr[1],
                    StQuantity = 120,
                    StFlag = 0,
                });
                st.Add(new TStock()
                {
                    Pr = pr[2],
                    StQuantity = 199,
                    StFlag = 0,
                });
                st.Add(new TStock()
                {
                    Pr = pr[3],
                    StQuantity = 50,
                    StFlag = 0,
                });
                st.Add(new TStock()
                {
                    Pr = pr[4],
                    StQuantity = 60,
                    StFlag = 0,
                });
                st.Add(new TStock()
                {
                    Pr = pr[5],
                    StQuantity = 32,
                    StFlag = 0,
                });
                st.Add(new TStock()
                {
                    Pr = pr[9],
                    StQuantity = 240,
                    StFlag = 0,
                });
                context.TStocks.AddRange(st);
                context.SaveChanges();
            }
            List<TOrder> or = new List<TOrder>();
            {
                or.Add(new TOrder
                {
                    So = so[0],
                    Em = em[310],
                    Cl = cl[1],
                    ClCharge = "萬田銀次郎",
                    OrDate = new DateTime(2020, 12, 10),
                    OrStateFlag = 1,
                    OrFlag = 0,
                });
                or.Add(new TOrder
                {
                    So = so[1],
                    Em = em[116],
                    Cl = cl[4],
                    ClCharge = "水野勝成",
                    OrDate = new DateTime(2021, 1, 5),
                    OrStateFlag = 0,
                    OrFlag = 0,
                });
                context.TOrders.AddRange(or);
                context.SaveChanges();
            }
            List<TOrderDetail> ord = new List<TOrderDetail>();
            {
                ord.Add(new TOrderDetail()
                {
                    Or = or[0],
                    Pr = pr[2],
                    OrQuantity = 40,
                    OrTotalPrice = 200000,
                });
                ord.Add(new TOrderDetail()
                {
                    Or = or[0],
                    Pr = pr[9],
                    OrQuantity = 30,
                    OrTotalPrice = 900000,
                });
                ord.Add(new TOrderDetail()
                {
                    Or = or[1],
                    Pr = pr[3],
                    OrQuantity = 20,
                    OrTotalPrice = 3200000,
                });
                ord.Add(new TOrderDetail()
                {
                    Or = or[1],
                    Pr = pr[4],
                    OrQuantity = 15,
                    OrTotalPrice = 3000000,
                });
                ord.Add(new TOrderDetail()
                {
                    Or = or[1],
                    Pr = pr[5],
                    OrQuantity = 15,
                    OrTotalPrice = 2250000,
                });
                context.TOrderDetails.AddRange(ord);
                context.SaveChanges();
            }
            List<TChumon> ch = new List<TChumon>();
            {
                ch.Add(new TChumon()
                {
                    So = so[0],
                    Em = em[1002],
                    Cl = cl[1],
                    Or = or[0],
                    ChDate = new DateTime(2020, 12, 11),
                    ChStateFlag = 1,
                    ChFlag = 0,
                });
                context.TChumons.AddRange(ch);
                context.SaveChanges();
            }
            List<TChumonDetail> chd = new List<TChumonDetail>();
            {
                chd.Add(new TChumonDetail()
                {
                    Ch = ch[0],
                    Pr = pr[2],
                    ChQuantity = 40,
                });
                chd.Add(new TChumonDetail()
                {
                    Ch = ch[0],
                    Pr = pr[9],
                    ChQuantity = 30,
                });
                context.TChumonDetails.AddRange(chd);
                context.SaveChanges();
            }
            List<TSyukko> sy = new List<TSyukko>();
            {
                sy.Add(new TSyukko()
                {
                    Cl = cl[1],
                    So = so[0],
                    Or = or[0],
                    SyStateFlag = 0,
                    SyFlag = 0,
                });
                context.TSyukkos.AddRange(sy);
                context.SaveChanges();
            }
            List<TSyukkoDetail> syd = new List<TSyukkoDetail>();
            {
                syd.Add(new TSyukkoDetail()
                {
                    Sy = sy[0],
                    Pr = pr[2],
                    SyQuantity = 40,
                });
                syd.Add(new TSyukkoDetail()
                {
                    Sy = sy[0],
                    Pr = pr[9],
                    SyQuantity = 30,
                });
                context.TSyukkoDetails.AddRange(syd);
                context.SaveChanges();
            }

            MessageBox.Show("サンプルデータ登録完了");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateNameLabel.UpdateDateTime(); // 日付と時間のラベルを更新
        }



        private void B_login_Click(object sender, EventArgs e)
        {
            try
            {
                // 入力検証
                if (!InputValidator.IsNotEmpty(tb_ID.Text) || !InputValidator.IsValidEmployeeID(tb_ID.Text, out int empID))
                {
                    MessageBox.Show("社員IDを正しく入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID テキストボックスにフォーカス 
                    return;
                }

                // 社員IDが3～4桁の数字かどうかをチェック 
                if (tb_ID.Text.Length < 3 || tb_ID.Text.Length > 4 || !Regex.IsMatch(tb_ID.Text, @"^\d+$"))
                {
                    MessageBox.Show("社員IDは3～4桁の数字で入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID テキストボックスにフォーカス 
                    return;
                }

                if (!InputValidator.IsNotEmpty(tb_Pass.Text))
                {
                    MessageBox.Show("パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // パスワード テキストボックスにフォーカス 
                    return;
                }

                // パスワードが3～4桁の数字かどうかをチェック 
                if (tb_Pass.Text.Length < 3 || tb_Pass.Text.Length > 4 || !Regex.IsMatch(tb_Pass.Text, @"^\d+$"))
                {
                    MessageBox.Show("パスワードは3～4桁の数字で入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // パスワード テキストボックスにフォーカス 
                    return;
                }


                string pass = tb_Pass.Text;
                bool isLoginSuccessful = false; // 初期化して成功状態を保存する変数  

                using (var context = new SalesManagementContext())
                {
                    var employeeService = new EmployeeService(context);
                    if (employeeService.ValidateEmployee(empID, pass, out string employeeName, out string positionName, out int poID))
                    {
                        HandleSuccessfulLogin(empID, employeeName, positionName, poID);
                    }
                    else
                    {
                        MessageBox.Show("社員IDとパスワードが一致していません", "認証エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_Pass.Focus(); // パスワード テキストボックスにフォーカス 
                        return;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2) // タイムアウトエラー 
            {
                MessageBox.Show("データベース接続がタイムアウトしました。ネットワーク状態を確認し、再試行してください。", "接続タイムアウト", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("データベースに接続できません。ネットワーク状態を確認してください: " + ex.Message, "接続エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("データベース操作中にエラーが発生しました: " + ex.Message, "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期しないエラーが発生しました。システム管理者にお問い合わせください。", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSuccessfulLogin(int empID, string employeeName, string positionName, int poID)
        {
            Global.EmployeeID = empID;
            Global.EmployeeName = employeeName;
            Global.PositionName = positionName;
            Global.EmployeePermission = GetPermissionByPoID(poID);

            GlobalEmp.EmployeeID = tb_ID.Text;



            // 権限が不足している場合 
            if (Global.EmployeePermission == 0)
            {
                MessageBox.Show("権限が設定されていません。詳しくは管理者に問い合わせてください。", "権限エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ログイン成功時の処理 
            classChangeForms.NavigateTo3();
            using (var context = new SalesManagementContext())
            {
            }
        }

        // PoIDに基づいて権限を決定する関数  
        private int GetPermissionByPoID(int poID)
        {
            // 職位IDに基づいて権限レベルを返す（例: 1, 2, 3）  
            switch (poID)
            {
                case 1: return 1; // 権限1  
                case 2: return 2; // 権限2  
                case 3: return 3; // 権限3  
                default: return 0; // 未定義の権限  
            }
            Global.EmployeePermission = poID;
        }


        private void b_pwHyouji_Click(object sender, EventArgs e)
        {
            // パスワード表示状態をトグル
            isPasswordVisible = !isPasswordVisible;

            if (!isPasswordVisible)
            {
                tb_Pass.UseSystemPasswordChar = false; // パスワードを非表示 
                tb_Pass.PasswordChar = '\0';
                b_pwHyouji.Text = "開";  // ボタンのテキストを「表示」に変更 
            }
            else
            {
                tb_Pass.UseSystemPasswordChar = true; // パスワードを表示 

                b_pwHyouji.Text = "閉";  // ボタンのテキストを「非表示」に変更 
            }
        }


        private void F_login_Load(object sender, EventArgs e)
        {
            // 　btn_InsertSampleData.Visible = false;
            //  btn_CleateDabase.Visible = false;
            dateNameLabel.UpdateDateTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_ID.Text = "1111";
            tb_Pass.Text = "999";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            tb_ID.Text = "1007";
            tb_Pass.Text = "1007";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_ID.Text = "1227";
            tb_Pass.Text = "1227";

            try
            {
                // 入力検証
                if (!InputValidator.IsNotEmpty(tb_ID.Text) || !InputValidator.IsValidEmployeeID(tb_ID.Text, out int empID))
                {
                    MessageBox.Show("社員IDを正しく入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID テキストボックスにフォーカス 
                    return;
                }

                // 社員IDが3～4桁の数字かどうかをチェック 
                if (tb_ID.Text.Length < 3 || tb_ID.Text.Length > 4 || !Regex.IsMatch(tb_ID.Text, @"^\d+$"))
                {
                    MessageBox.Show("社員IDは3～4桁の数字で入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID テキストボックスにフォーカス 
                    return;
                }

                if (!InputValidator.IsNotEmpty(tb_Pass.Text))
                {
                    MessageBox.Show("パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // パスワード テキストボックスにフォーカス 
                    return;
                }

                // パスワードが3～4桁の数字かどうかをチェック 
                if (tb_Pass.Text.Length < 3 || tb_Pass.Text.Length > 4 || !Regex.IsMatch(tb_Pass.Text, @"^\d+$"))
                {
                    MessageBox.Show("パスワードは3～4桁の数字で入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // パスワード テキストボックスにフォーカス 
                    return;
                }

                string pass = tb_Pass.Text;
                bool isLoginSuccessful = false; // 初期化して成功状態を保存する変数  

                using (var context = new SalesManagementContext())
                {
                    var employeeService = new EmployeeService(context);
                    if (employeeService.ValidateEmployee(empID, pass, out string employeeName, out string positionName, out int poID))
                    {
                        MessageBox.Show("ログイン成功、登録処理開始");
                        AddLoginLog();
                        HandleSuccessfulLogin(empID, employeeName, positionName, poID);
                    }
                    else
                    {
                        MessageBox.Show("社員IDとパスワードが一致していません", "認証エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_Pass.Focus(); // パスワード テキストボックスにフォーカス 
                        return;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2) // タイムアウトエラー 
            {
                MessageBox.Show("データベース接続がタイムアウトしました。ネットワーク状態を確認し、再試行してください。", "接続タイムアウト", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("データベースに接続できません。ネットワーク状態を確認してください: " + ex.Message, "接続エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("データベース操作中にエラーが発生しました: " + ex.Message, "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("予期しないエラーが発生しました。システム管理者にお問い合わせください。", "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddLoginLog()
        {
            using (var context = new SalesManagementContext())
            {
                var log = context.LoginHistoryLogs.FirstOrDefault();
                {

                }
                var Log = new LoginHistoryLog
                {

                };
            }
            try
            {
                using (var context = new SalesManagementContext())
                {
                    var logEntry = new LoginHistoryLog
                    {
                        LoginID = tb_ID.Text,
                        LoginDateTime = DateTime.Now,
                        IsSuccessful = true
                    };
                    context.LoginHistoryLogs.Add(logEntry);
                    context.SaveChanges();
                    MessageBox.Show("登録成功");
                }
            }
            catch (Exception ex)
            {
                // 内部例外を表示する
                MessageBox.Show($"エラー: {ex.Message}\n内部例外: {ex.InnerException?.Message}");
            }

        }

        private void passwordchange_Click(object sender, EventArgs e)
        {
            classChangeForms.passwordchange();
        }

    }

}
