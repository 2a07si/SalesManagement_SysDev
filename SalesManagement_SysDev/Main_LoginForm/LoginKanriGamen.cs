using Microsoft.Data.SqlClient;
using SalesManagement_SysDev.Classまとめ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;// 各種クラスを使用する
using static SalesManagement_SysDev.Classまとめ.labelChange;
using static SalesManagement_SysDev.Classまとめ.CurrentStatus;
using static SalesManagement_SysDev.Classまとめ.LabelStatus;
using static SalesManagement_SysDev.Classまとめ.ClassChangeForms;
using SalesManagement_SysDev.juchuu_uriage;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class LoginKanriGamen : Form
    {

        private ClassChangeForms changeForm;
        public LoginKanriGamen()
        {
            InitializeComponent();
            changeForm = new ClassChangeForms(this); // インスタンスを作成  
        }

        private void close_Click(object sender, EventArgs e)
        {
            changeForm.NavigateToMainMenu();
        }

        private void b_PassChange_Click(object sender, EventArgs e)
        {
        }

        private void b_NewAccount_Click(object sender, EventArgs e)
        {
        }

        private void LoginKanriGamen_Load(object sender, EventArgs e)
        {
            // デフォルト選択
            ComboLog.SelectedIndex = 0;
            ComboGamen.SelectedIndex = 0;
            ComboMode.SelectedIndex = 0;
            ComboShori.SelectedIndex = 0;

            // イベントハンドラを設定
            ComboLog.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            dateTimePicker1.Visible = false;
        }

        private void clear_Click(object sender, EventArgs e)
        {
        }

        private void b_PCOK_Click(object sender, EventArgs e)
        {
            UpdatePassword();

        }
        private void UpdatePassword()
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void clear_Click_1(object sender, EventArgs e)
        {
            cleartext();
        }
        private void cleartext()
        {
            ComboLog.Text = string.Empty;
            ComboGamen.Text = string.Empty;
            ComboMode.Text = string.Empty;
            ComboShori.Text = string.Empty;

            TB_Log.Text = string.Empty;
            TB_ID.Text = string.Empty;

            ComboLog.SelectedIndex = -1;
            ComboGamen.SelectedIndex = -1;
            ComboMode.SelectedIndex = -1;
            ComboShori.SelectedIndex = -1;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 選択された項目に応じて動作を切り替える
            if (ComboLog.SelectedItem.ToString() == "ログイン日時")
            {
                TB_Log.Visible = false;
                dateTimePicker1.Visible = true; // DateTimePicker を表示
            }
            else
            {
                TB_Log.Visible = true; // テキストボックスを表示
                dateTimePicker1.Visible = false; // DateTimePicker を隠す
            }
        }
    }
}
