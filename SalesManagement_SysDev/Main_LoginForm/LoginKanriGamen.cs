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
        }

        private void b_NewAccount_Click(object sender, EventArgs e)
        {
        }

        private void LoginKanriGamen_Load(object sender, EventArgs e)
        {
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
    }
}
