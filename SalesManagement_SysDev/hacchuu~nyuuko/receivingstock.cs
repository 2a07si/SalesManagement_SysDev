using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagement_SysDev.Classまとめ;

namespace SalesManagement_SysDev
{
    public partial class receivingstock : Form
    {
        private Form mainForm;
        private ClassChangeForms formChanger; // 画面遷移管理クラス 

        public receivingstock()
        {
            InitializeComponent();
            this.mainForm = new Form();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            labeltime.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            labeldate.Text = now.ToString("yyyy年MM月dd日");
        }

        private void close_Click(object sender, EventArgs e)
        {
            mainmenu1 mainmenu1 = new mainmenu1();
            mainmenu1.Show();

            // 現在のフォームを閉じる
            this.Close();
        }

        private void b_hor_Click(object sender, EventArgs e)
        {
            formChanger.NavigateToHorderForm();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void kakutei_Click(object sender, EventArgs e)
        {

        }
    }
}
