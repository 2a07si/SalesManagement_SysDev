using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class passwordchange : Form
    {
        public passwordchange()
        {
            InitializeComponent();
        }

        private void kakutei_Click(object sender, EventArgs e)
        {
            passwordkakutei();
        }
        private void passwordkakutei()
        {
            string ShainID = TBID.Text;
            string oldPass = TBold.Text;
            string newPass = TBnew.Text;
            if (TBID.Text == "")
            {
                TBID.Focus();
                MessageBox.Show("社員IDを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBold.Text == "")
            {
                TBold.Focus();
                MessageBox.Show("変更前パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TBnew.Text == "")
            {
                TBnew.Focus();
                MessageBox.Show("変更後パスワードを入力して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new SalesManagementContext())
            {
                // ShainIDで該当社員を検索
                var employee = context.MEmployees.SingleOrDefault(e => e.EmID.ToString() == ShainID);

                if (employee != null)
                {
                    // oldPassの一致確認
                    if (employee.EmPassword == oldPass)
                    {
                        employee.EmPassword = newPass;

                        context.SaveChanges();
                        MessageBox.Show("更新が成功しました。");
                        this.Close(); // 現在のフォームを閉じる 
                        F_login loginForm = new F_login(); // ログインフォームを作成 
                        loginForm.Show(); // ログインフォームを表示 
                    }
                    else
                    {
                        MessageBox.Show("現在のパスワードが一致しません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("該当する社員情報が見つかりません。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void B_return_Click(object sender, EventArgs e)
        {
            this.Close(); // 現在のフォームを閉じる 
            F_login loginForm = new F_login(); // ログインフォームを作成 
            loginForm.Show(); // ログインフォームを表示 
        }
    }
}

