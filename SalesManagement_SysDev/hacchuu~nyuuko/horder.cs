using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class horder : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private Form mainForm;
        private ClassDateNamelabel dateNameLabel; // 日付と時間ラベル管理用クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 
        private ClassAccessManager accessManager; // アクセスマネージャのインスタンス

        public horder()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(horder_Load);
            this.formChanger = new ClassChangeForms(this);
            this.accessManager = new ClassAccessManager(Global.EmployeePermission); // 権限をセット
        }



        private void close_Click(object sender, EventArgs e)
        {
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを閉じる
            this.Close();
        }

        private void b_rec_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToReceivingstockForm();
        }

        private void horder_Load(object sender, EventArgs e)
        {

            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベル更新

            // アクセスマネージャを使ってボタンのアクセス制御を適用
            Control[] buttons = { b_rec, /* 他のボタンを追加 */ };
            accessManager.SetButtonAccess(buttons); // ボタンのアクセス設定を適用
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void cleartext()
        {
            TBHattyuuID.Text = "";
            TBMakerID.Text = "";
            TBShainID.Text = "";
            NyuukoFlag.Checked = false;
            DelFlag.Checked = false;
            TBRiyuu.Text = "";
            TBHattyuuSyosaiID.Text = "";
            TBHattyuIDS.Text = "";
            TBSyohinID.Text = "";
            TBSuryou.Text = "";
            date.Value = DateTime.Now;
            CurrentStatus.ResetStatus(label2);
        }
    }
}
