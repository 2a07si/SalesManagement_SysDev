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
            p_PC.Visible = true;
            p_NA.Visible = false;
        }

        private void b_NewAccount_Click(object sender, EventArgs e)
        {
            p_NA.Visible = true;
            p_PC.Visible = false;
        }

        private void LoginKanriGamen_Load(object sender, EventArgs e)
        {
            p_PC.Visible = true;
            p_NA.Visible = false;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            tb_NAJ.Text = "";
            tb_NAP.Text = "";
            tb_NAUI.Text = "";
            tb_PCNP.Text = "";
            tb_PCOP.Text = "";
            tb_PCUI.Text = "";
        }

        private void b_PCOK_Click(object sender, EventArgs e)
        {
            UpdatePassword();

        }
        private void UpdatePassword()
        {
            int userID = int.Parse(tb_PCUI.Text);
            string oldPassword = tb_PCOP.Text;
            string newPassword = tb_PCNP.Text;

            using (var context = new SalesManagementContext())
            {
                // userIDとoldPasswordでユーザーを検索
                var employee = context.MEmployees.SingleOrDefault(e => e.EmId == userID && e.EmPassword == oldPassword);

                if (employee != null)
                {
                    // パスワードを新しいものに変更
                    employee.EmPassword = newPassword;

                    context.SaveChanges();
                    MessageBox.Show("パスワードの更新が成功しました。");
                }
                else
                {
                    MessageBox.Show("ユーザーIDまたは旧パスワードが正しくありません。");
                }
            }
        }
    }
}
