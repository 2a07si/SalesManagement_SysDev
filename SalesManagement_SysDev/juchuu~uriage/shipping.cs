// shipping.cs
using System;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;
using static SalesManagement_SysDev.Classまとめ.labelChange;

namespace SalesManagement_SysDev
{
    public partial class shipping : Form
    {
        private ClassChangeForms formChanger; // 画面遷移管理クラス 
        private ClassTimerManager timerManager; // タイマー管理クラス 

        // コンストラクターでmainFormを引数として受け取る 
        public shipping(Form mainForm)
        {
            InitializeComponent();
            this.formChanger = new ClassChangeForms(this);
            this.timerManager = new ClassTimerManager(timer1, labeltime, labeldate); // タイマー管理クラスを初期化 
            this.Load += new EventHandler(shipping_Load);
        }

        private void shipping_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename); // ラベルの初期化 
        }

        private void b_reg_Click(object sender, EventArgs e)
        {
            // 登録ボタンの処理を追加 
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            // 更新ボタンの処理を追加 
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
            // 検索ボタンの処理を追加 
        }

        private void b_flg_Click(object sender, EventArgs e)
        {
            // フラグボタンの処理を追加 
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            // 次へボタンの処理を追加 
        }

        private void b_logout_Click(object sender, EventArgs e)
        {
            // ログアウト処理を追加 
        }

        private void close_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToMainMenu(); // メインメニューに遷移 
        }
    }
}
