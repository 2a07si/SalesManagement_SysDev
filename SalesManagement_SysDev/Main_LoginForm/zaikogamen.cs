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
    public partial class zaikogamen : Form
    {
        public zaikogamen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                var stock = context.TStocks.ToList();
                dataGridView1.DataSource = stock;
            }
        }

        private void zaikogamen_Load(object sender, EventArgs e)
        {
            using (var context = new SalesManagementContext())
            {
                var stock = context.TStocks.ToList();
                dataGridView1.DataSource = stock;
            }
        }
    }
}
