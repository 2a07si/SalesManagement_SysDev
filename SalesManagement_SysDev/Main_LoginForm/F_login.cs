using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using SalesManagement_SysDev.Class�܂Ƃ�;
using static SalesManagement_SysDev.Class�܂Ƃ�.labelChange;
using static SalesManagement_SysDev.Class�܂Ƃ�.ClassChangeForms;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using SalesManagement_SysDev.Main_LoginForm;
using static SalesManagement_SysDev.Class�܂Ƃ�.GlobalEmpNo;
using SalesManagement_SysDev.Entity;

namespace SalesManagement_SysDev
{
    public partial class F_login : Form
    {
        private ClassDateNamelabel dateNameLabel;
        private bool isPasswordVisible = true;  // �p�X���[�h�\����Ԃ��Ǘ�����t���O 
        private ClassTimerManager timerManager;
        private ClassChangeForms classChangeForms;
        public F_login()
        {
            InitializeComponent();

            // ������ԂŃp�X���[�h���B�� 
            tb_Pass.UseSystemPasswordChar = false;  // �p�X���[�h���\���ɂ��� 

            // �^�C�}�[�₻�̑��̏����ݒ� 
            this.dateNameLabel = new ClassDateNamelabel(labeltime, labeldate);
            this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate);
            this.classChangeForms = new ClassChangeForms(this);
            timer1.Start();
        }

        private void btn_CleateDabase_Click(object sender, EventArgs e)
        {
            //�f�[�^�x�[�X�̐������s���܂��D
            //�ēx���s����ꍇ�ɂ́C�K���f�[�^�x�[�X�̍폜�����Ă�����s���Ă��������D

            using SalesManagementContext context = new SalesManagementContext();

            context.Database.EnsureCreated();

            List<MPosition> po = new List<MPosition>();
            {
                po.Add(new MPosition()
                {
                    PoName = "�Ǘ���",
                    PoFlag = 0,
                });
                po.Add(new MPosition()
                {
                    PoName = "�c��",
                    PoFlag = 0,
                });
                po.Add(new MPosition()
                {
                    PoName = "����",
                    PoFlag = 0,
                });
                context.MPositions.AddRange(po);
                context.SaveChanges();
            }

            MessageBox.Show("�e�[�u���쐬����");
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
                    MaName = "A���[�J",
                    MaAddress = "���",
                    MaPhone = "000-0000-0000",
                    MaPostal = "0000000",
                    MaFax = "000-0000-0000",
                    MaFlag = 0,
                });
                ma.Add(new MMaker()
                {
                    MaName = "B���[�J",
                    MaAddress = "���s",
                    MaPhone = "000-0000-0000",
                    MaPostal = "0000000",
                    MaFax = "000-0000-0000",
                    MaFlag = 0,
                });
                ma.Add(new MMaker()
                {
                    MaName = "C���[�J",
                    MaAddress = "�a�̎R",
                    MaPhone = "000-0000-0000",
                    MaPostal = "0000000",
                    MaFax = "000-0000-0000",
                    MaFlag = 0,
                });
                ma.Add(new MMaker()
                {
                    MaName = "D���[�J",
                    MaAddress = "����",
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
                    SoName = "�k���c�Ə�",
                    SoAddress = "���{���c�s����3-4-40",
                    SoPhone = "06-7011-6123",
                    SoPostal = "5600046",
                    SoFax = "06-6562-2740",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "���ɉc�Ə�",
                    SoAddress = "���Ɍ��P�H�s���҈�2-5-20",
                    SoPhone = "079-669-4326",
                    SoPostal = "6700994",
                    SoFax = "079-669-4327",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "���c�Ə�",
                    SoAddress = "�ޗǌ�����S�O��������8-7-50",
                    SoPhone = "0745-99-0084",
                    SoPostal = "6360814",
                    SoFax = "0746-0-1160",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "���s�c�Ə�",
                    SoAddress = "���s�{���s�s�R�ȋ擌����m�㒬10-3-7",
                    SoPhone = "077-672-6006",
                    SoPostal = "6078143",
                    SoFax = "0771-85-2574",
                    SoFlag = 0,
                });
                so.Add(new MSalesOffice()
                {
                    SoName = "�a�̎R�c�Ə�",
                    SoAddress = "�a�̎R���a�̎R�s����4-19",
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
                    ClName = "�㑺�d�@",
                    ClAddress = "���s�{���s�s�����扖����3-9-95",
                    ClPhone = "077-672-6006",
                    ClPostal = "6128046",
                    ClFax = "077-581-0164",
                    ClFlag = 0,
                    So = so[3],
                });
                cl.Add(new MClient()
                {
                    ClName = "�ݓc���Z",
                    ClAddress = "���{���s����k�x�]1����22-3",
                    ClPhone = "06-8757-6267",
                    ClPostal = "5500014",
                    ClFax = "06-8757-6267",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "��c�d�@",
                    ClAddress = "���{���s������a��2-5-46",
                    ClPhone = "06-1423-1895",
                    ClPostal = "5720806",
                    ClFax = "06-1374-4358",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "INATUGI",
                    ClAddress = "���{��؎s���]2-5-60",
                    ClPhone = "072-02-5171",
                    ClPostal = "5670044",
                    ClFax = "072-018-0116",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "����d�@",
                    ClAddress = "���{�L���s���L��2-6-13",
                    ClPhone = "06-2096-0974",
                    ClPostal = "5600024",
                    ClFax = "06-2434-2434",
                    ClFlag = 0,
                    So = so[1],
                });
                cl.Add(new MClient()
                {
                    ClName = "�V���b�v�Ԑ�",
                    ClAddress = "���{���s�V�������{��",
                    ClPhone = "090-1111-1111",
                    ClPostal = "5430001",
                    ClFax = "06-1111-1111",
                    ClFlag = 0,
                    So = so[0],
                });
                cl.Add(new MClient()
                {
                    ClName = "���c",
                    ClAddress = "�ޗǌ��䏊�s�D�H2-8-87",
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
                        EmName = "������",
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
                        EmName = "���J�t�j",
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
                        EmName = "�������r�v",
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
                        EmName = "�ݖ{�萶",
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
                        EmName = "�����֕F",
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
                        EmName = "�a�J�H��",
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
                        EmName = "���c�����Y",
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
                    McName = "�e���r�E���R�[�_�[",
                    McFlag = 0,
                });
                mc.Add(new MMajorClassification()
                {
                    McName = "�G�A�R���E�①�ɁE����@",
                    McFlag = 0,
                });
                mc.Add(new MMajorClassification()
                {
                    McName = "�I�[�f�B�I�E�C���z���E�w�b�h�z��",
                    McFlag = 0,
                });
                mc.Add(new MMajorClassification()
                {
                    McName = "�g�ѓd�b�E�X�}�[�g�t�H��",
                    McFlag = 0,
                });
                context.MMajorClassifications.AddRange(mc);
                context.SaveChanges();
            }
            {
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[0],
                    ScName = "�e���r",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[0],
                    ScName = "���R�[�_�[",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[1],
                    ScName = "�G�A�R��",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[1],
                    ScName = "�①��",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[1],
                    ScName = "����@",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[2],
                    ScName = "�I�[�f�B�I",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[2],
                    ScName = "�C���z��",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[2],
                    ScName = "�w�b�h�z��",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[3],
                    ScName = "�g�ѓd�b",
                    ScFlag = 0,
                });
                sc.Add(new MSmallClassification()
                {
                    Mc = mc[3],
                    ScName = "�X�}�[�g�t�H��",
                    ScFlag = 0,
                });
                context.MSmallClassifications.AddRange(sc);
                context.SaveChanges();
            }
            {
                pr.Add(new MProduct()
                {
                    Ma = ma[0],
                    PrName = "�e���rA",
                    Price = 100000,
                    PrSafetyStock = 100,
                    Sc = sc[0],
                    PrModelNumber = "1",
                    PrColor = "��",
                    PrReleaseDate = new DateTime(2019, 5, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[0],
                    PrName = "�e���rB",
                    Price = 98000,
                    PrSafetyStock = 100,
                    Sc = sc[0],
                    PrModelNumber = "1",
                    PrColor = "��",
                    PrReleaseDate = new DateTime(2019, 5, 10),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[0],
                    PrName = "���R�[�_�[A",
                    Price = 5000,
                    PrSafetyStock = 50,
                    Sc = sc[1],
                    PrModelNumber = "1",
                    PrColor = "��",
                    PrReleaseDate = new DateTime(2019, 10, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[1],
                    PrName = "�G�A�R��A",
                    Price = 160000,
                    PrSafetyStock = 50,
                    Sc = sc[2],
                    PrModelNumber = "1",
                    PrColor = "��",
                    PrReleaseDate = new DateTime(2020, 10, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[1],
                    PrName = "�①��A",
                    Price = 200000,
                    PrSafetyStock = 50,
                    Sc = sc[3],
                    PrModelNumber = "1",
                    PrColor = "��",
                    PrReleaseDate = new DateTime(2020, 1, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[1],
                    PrName = "����@A",
                    Price = 150000,
                    PrSafetyStock = 50,
                    Sc = sc[4],
                    PrModelNumber = "1",
                    PrColor = "��",
                    PrReleaseDate = new DateTime(2019, 3, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[2],
                    PrName = "�I�[�f�B�IA",
                    Price = 6000,
                    PrSafetyStock = 10,
                    Sc = sc[5],
                    PrModelNumber = "1",
                    PrColor = "��",
                    PrReleaseDate = new DateTime(2020, 8, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[2],
                    PrName = "�C���z��A",
                    Price = 5000,
                    PrSafetyStock = 100,
                    Sc = sc[6],
                    PrModelNumber = "1",
                    PrColor = "��",
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
                    PrColor = "�S�[���h",
                    PrReleaseDate = new DateTime(2017, 9, 22),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[3],
                    PrName = "�X�}�[�g�t�H��A",
                    Price = 30000,
                    PrSafetyStock = 50,
                    Sc = sc[9],
                    PrModelNumber = "1",
                    PrColor = "�V���o�[",
                    PrReleaseDate = new DateTime(2019, 5, 1),
                    PrFlag = 0,
                });
                pr.Add(new MProduct()
                {
                    Ma = ma[3],
                    PrName = "�X�}�[�g�t�H��B",
                    Price = 40000,
                    PrSafetyStock = 50,
                    Sc = sc[9],
                    PrModelNumber = "1",
                    PrColor = "��",
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
                    ClCharge = "�ݓc�⎟�Y",
                    OrDate = new DateTime(2020, 12, 10),
                    OrStateFlag = 1,
                    OrFlag = 0,
                });
                or.Add(new TOrder
                {
                    So = so[1],
                    Em = em[116],
                    Cl = cl[4],
                    ClCharge = "���쏟��",
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

            MessageBox.Show("�T���v���f�[�^�o�^����");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateNameLabel.UpdateDateTime(); // ���t�Ǝ��Ԃ̃��x�����X�V
        }



        private void B_login_Click(object sender, EventArgs e)
        {
            try
            {
                // ���͌���
                if (!InputValidator.IsNotEmpty(tb_ID.Text) || !InputValidator.IsValidEmployeeID(tb_ID.Text, out int empID))
                {
                    MessageBox.Show("�Ј�ID�𐳂������͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }

                // �Ј�ID��3�`4���̐������ǂ������`�F�b�N 
                if (tb_ID.Text.Length < 3 || tb_ID.Text.Length > 4 || !Regex.IsMatch(tb_ID.Text, @"^\d+$"))
                {
                    MessageBox.Show("�Ј�ID��3�`4���̐����œ��͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }

                if (!InputValidator.IsNotEmpty(tb_Pass.Text))
                {
                    MessageBox.Show("�p�X���[�h����͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // �p�X���[�h �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }

                // �p�X���[�h��3�`4���̐������ǂ������`�F�b�N 
                if (tb_Pass.Text.Length < 3 || tb_Pass.Text.Length > 4 || !Regex.IsMatch(tb_Pass.Text, @"^\d+$"))
                {
                    MessageBox.Show("�p�X���[�h��3�`4���̐����œ��͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // �p�X���[�h �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }


                string pass = tb_Pass.Text;
                bool isLoginSuccessful = false; // ���������Đ�����Ԃ�ۑ�����ϐ�  

                using (var context = new SalesManagementContext())
                {
                    var employeeService = new EmployeeService(context);
                    if (employeeService.ValidateEmployee(empID, pass, out string employeeName, out string positionName, out int poID))
                    {
                        HandleSuccessfulLogin(empID, employeeName, positionName, poID);
                    }
                    else
                    {
                        MessageBox.Show("�Ј�ID�ƃp�X���[�h����v���Ă��܂���", "�F�؃G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_Pass.Focus(); // �p�X���[�h �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                        return;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2) // �^�C���A�E�g�G���[ 
            {
                MessageBox.Show("�f�[�^�x�[�X�ڑ����^�C���A�E�g���܂����B�l�b�g���[�N��Ԃ��m�F���A�Ď��s���Ă��������B", "�ڑ��^�C���A�E�g", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("�f�[�^�x�[�X�ɐڑ��ł��܂���B�l�b�g���[�N��Ԃ��m�F���Ă�������: " + ex.Message, "�ڑ��G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("�f�[�^�x�[�X���쒆�ɃG���[���������܂���: " + ex.Message, "�f�[�^�x�[�X�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�\�����Ȃ��G���[���������܂����B�V�X�e���Ǘ��҂ɂ��₢���킹���������B", "�V�X�e���G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleSuccessfulLogin(int empID, string employeeName, string positionName, int poID)
        {
            Global.EmployeeID = empID;
            Global.EmployeeName = employeeName;
            Global.PositionName = positionName;
            Global.EmployeePermission = GetPermissionByPoID(poID);

            GlobalEmp.EmployeeID = tb_ID.Text;



            // �������s�����Ă���ꍇ 
            if (Global.EmployeePermission == 0)
            {
                MessageBox.Show("�������ݒ肳��Ă��܂���B�ڂ����͊Ǘ��҂ɖ₢���킹�Ă��������B", "�����G���[", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ���O�C���������̏��� 
            classChangeForms.NavigateTo3();
            using (var context = new SalesManagementContext())
            {
            }
        }

        // PoID�Ɋ�Â��Č��������肷��֐�  
        private int GetPermissionByPoID(int poID)
        {
            // �E��ID�Ɋ�Â��Č������x����Ԃ��i��: 1, 2, 3�j  
            switch (poID)
            {
                case 1: return 1; // ����1  
                case 2: return 2; // ����2  
                case 3: return 3; // ����3  
                default: return 0; // ����`�̌���  
            }
            Global.EmployeePermission = poID;
        }


        private void b_pwHyouji_Click(object sender, EventArgs e)
        {
            // �p�X���[�h�\����Ԃ��g�O��
            isPasswordVisible = !isPasswordVisible;

            if (!isPasswordVisible)
            {
                tb_Pass.UseSystemPasswordChar = false; // �p�X���[�h���\�� 
                tb_Pass.PasswordChar = '\0';
                b_pwHyouji.Text = "�J";  // �{�^���̃e�L�X�g���u�\���v�ɕύX 
            }
            else
            {
                tb_Pass.UseSystemPasswordChar = true; // �p�X���[�h��\�� 

                b_pwHyouji.Text = "��";  // �{�^���̃e�L�X�g���u��\���v�ɕύX 
            }
        }


        private void F_login_Load(object sender, EventArgs e)
        {
            // �@btn_InsertSampleData.Visible = false;
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
                // ���͌���
                if (!InputValidator.IsNotEmpty(tb_ID.Text) || !InputValidator.IsValidEmployeeID(tb_ID.Text, out int empID))
                {
                    MessageBox.Show("�Ј�ID�𐳂������͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }

                // �Ј�ID��3�`4���̐������ǂ������`�F�b�N 
                if (tb_ID.Text.Length < 3 || tb_ID.Text.Length > 4 || !Regex.IsMatch(tb_ID.Text, @"^\d+$"))
                {
                    MessageBox.Show("�Ј�ID��3�`4���̐����œ��͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_ID.Focus(); // ID �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }

                if (!InputValidator.IsNotEmpty(tb_Pass.Text))
                {
                    MessageBox.Show("�p�X���[�h����͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // �p�X���[�h �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }

                // �p�X���[�h��3�`4���̐������ǂ������`�F�b�N 
                if (tb_Pass.Text.Length < 3 || tb_Pass.Text.Length > 4 || !Regex.IsMatch(tb_Pass.Text, @"^\d+$"))
                {
                    MessageBox.Show("�p�X���[�h��3�`4���̐����œ��͂��ĉ������B", "���̓G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_Pass.Focus(); // �p�X���[�h �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                    return;
                }

                string pass = tb_Pass.Text;
                bool isLoginSuccessful = false; // ���������Đ�����Ԃ�ۑ�����ϐ�  

                using (var context = new SalesManagementContext())
                {
                    var employeeService = new EmployeeService(context);
                    if (employeeService.ValidateEmployee(empID, pass, out string employeeName, out string positionName, out int poID))
                    {
                        MessageBox.Show("���O�C�������A�o�^�����J�n");
                        AddLoginLog();
                        HandleSuccessfulLogin(empID, employeeName, positionName, poID);
                    }
                    else
                    {
                        MessageBox.Show("�Ј�ID�ƃp�X���[�h����v���Ă��܂���", "�F�؃G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_Pass.Focus(); // �p�X���[�h �e�L�X�g�{�b�N�X�Ƀt�H�[�J�X 
                        return;
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == -2) // �^�C���A�E�g�G���[ 
            {
                MessageBox.Show("�f�[�^�x�[�X�ڑ����^�C���A�E�g���܂����B�l�b�g���[�N��Ԃ��m�F���A�Ď��s���Ă��������B", "�ڑ��^�C���A�E�g", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("�f�[�^�x�[�X�ɐڑ��ł��܂���B�l�b�g���[�N��Ԃ��m�F���Ă�������: " + ex.Message, "�ڑ��G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("�f�[�^�x�[�X���쒆�ɃG���[���������܂���: " + ex.Message, "�f�[�^�x�[�X�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�\�����Ȃ��G���[���������܂����B�V�X�e���Ǘ��҂ɂ��₢���킹���������B", "�V�X�e���G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("�o�^����");
                }
            }
            catch (Exception ex)
            {
                // ������O��\������
                MessageBox.Show($"�G���[: {ex.Message}\n������O: {ex.InnerException?.Message}");
            }

        }

        private void passwordchange_Click(object sender, EventArgs e)
        {
            classChangeForms.passwordchange();
        }

    }

}
