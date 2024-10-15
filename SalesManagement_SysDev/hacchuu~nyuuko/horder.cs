using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SalesManagement_SysDev.labelChange;

namespace SalesManagement_SysDev
{
    public partial class horder : Form
    {
        private Form mainForm;
        public horder()
        {
            InitializeComponent();
            this.mainForm = new Form();
            this.Load += new EventHandler(horder_Load);
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

        private void b_rec_Click(object sender, EventArgs e)
        {
            receivingstock receivingstock = new receivingstock();
            receivingstock.Show();
            this.Close();
        }

        private void horder_Load(object sender, EventArgs e)
        {
            GlobalUtility.UpdateLabels(label_id, label_ename);
        }
    }
}
