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
        public horder()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(horder_Load);
            this.formChanger = new ClassChangeForms(this);
            this.dateNameLabel = new ClassDateNamelabel(labeltime,labeldate,label_id,label_ename);
            this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
            GlobalUtility.UpdateLabels(label_id, label_ename);
            dateNameLabel.UpdateDateTime(); // 初回表示時に日付と時間を更新 
        }
    }
}
