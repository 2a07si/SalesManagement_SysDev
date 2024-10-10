using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class shipping : Form
    {
        private Form mainForm;

        // コンストラクターでmainFormを引数として受け取る
        public shipping(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            timer1.Start();
        }

        private void shipping_Load(object sender, EventArgs e)
        {

        }

        private void b_reg_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
        }

        private void b_ser_Click(object sender, EventArgs e)
        {
        }

        private void b_flg_Click(object sender, EventArgs e)
        {
        }

        private void close_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label_id_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label_ename_Click(object sender, EventArgs e)
        {
        }

        private void b_next_Click(object sender, EventArgs e)
        {
        }

        private void b_logout_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            label1.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            label2.Text = now.ToString("yyyy年MM月dd日");
        }

        private void close_Click_1(object sender, EventArgs e)
        {
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを非表示にする
            this.Hide(); // this.Close()から変更
        }
    }
}
