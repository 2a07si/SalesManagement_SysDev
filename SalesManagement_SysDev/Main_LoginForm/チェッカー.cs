using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SalesManagement_SysDev.Main_LoginForm
{
    public partial class checkergamen : Form
    {
        public checkergamen()
        {
            InitializeComponent();
        }

        private void チェッカー_Load(object sender, EventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                var Checkers = context.NyuukoCheckers.ToList();
                dataGridView1.DataSource = Checkers;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                var Checkers = context.NyuukoCheckers.ToList();
                dataGridView1.DataSource = Checkers;
            }

        }
    }
}

