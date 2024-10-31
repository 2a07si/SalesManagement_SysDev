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
    public partial class mainmenu3 : Form
    {
        public mainmenu3()
        {
            InitializeComponent();
        }

        private void b_JU_Click(object sender, EventArgs e)
        {
            HN.Visible = false;
            mas.Visible = false;
            JU.Visible = true;
        }

        private void b_HN_Click(object sender, EventArgs e)
        {
            JU.Visible = false;
            mas.Visible = false;
            HN.Visible = true;
        }

        private void b_mas_Click(object sender, EventArgs e)
        {
            HN.Visible = false;
            JU.Visible = false;
            mas.Visible = true;
        }

        private void mainmenu3_Load(object sender, EventArgs e)
        {

        }
    }
}
