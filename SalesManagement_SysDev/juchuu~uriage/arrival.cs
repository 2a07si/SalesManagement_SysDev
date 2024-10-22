using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;

namespace SalesManagement_SysDev
{
    public partial class arrival : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassAccessManager accessManager;

        public arrival(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.Load += new EventHandler(arrival_Load);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット

        }

        private void arrival_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
            accessManager.SetButtonAccess(new Control[] {
                b_ord,
                b_acc,
                b_shi,
                b_sal,
                b_lss
            });
        }

        // メインメニューに戻る 
        private void button3_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移 
        }

        private void b_acc_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToAcceptingOrderForm(); // 受注管理画面に遷移 
        }

        private void b_shi_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToShippingForm(); // 出荷管理画面に遷移 
        }

        private void b_sal_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToSalesForm(); // 売上管理画面に遷移 
        }

        private void b_lss_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToIssueForm(); // 発注書発行画面に遷移 
        }

        private void b_ord_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToOrderForm(); // 受注管理画面に遷移 
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            currentStatus.RegistrationStatus(label2);
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            currentStatus.UpDateStatus(label2);
        }

        private void B_iti_Click(object sender, EventArgs e)
        {
            currentStatus.ListStatus(label2);
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            currentStatus.SearchStatus(label2);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBNyuuka.Text = "";
            TBShopId.Text = "";
            TBShainId.Text = "";
            TBKokyaku.Text = "";
            TBJyutyu.Text = "";
            Nyuukaflag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBNyukaSyosaiID.Text = "";
            TBNyuukaIDS.Text = "";
            TBSuryou.Text = "";
            TBSyohinID.Text = "";
            date.Value = DateTime.Now;
        }
    }
}
