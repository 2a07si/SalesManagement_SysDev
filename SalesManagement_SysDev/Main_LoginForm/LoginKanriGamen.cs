using SalesManagement_SysDev.Classまとめ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
