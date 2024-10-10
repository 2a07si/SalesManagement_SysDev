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
    public partial class sales : Form
    {
        private Form mainForm;
<<<<<<< HEAD
        public sales()
        {
            InitializeComponent();
            this.mainForm = new Form();
=======

        public sales()
        {
            InitializeComponent();
            this.mainForm = mainForm;
>>>>>>> 81bafee186ab31ecd8ad5ff8d413353f50ddad8f
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            label1.Text = dateTime.ToLongTimeString();

            var now = System.DateTime.Now;
            label2.Text = now.ToString("yyyy年MM月dd日");
        }

<<<<<<< HEAD
        private void close_Click(object sender, EventArgs e)
        {
            // メインフォームを再表示
            mainForm.Opacity = 1.0;
            mainForm.TransparencyKey = Color.Empty; // 透明化を解除
            mainForm.Show();

            // 現在のフォームを閉じる
=======
        private void b_acc_Click(object sender, EventArgs e)
        {
            acceptingorders acceptingordersForm = new acceptingorders();
            acceptingordersForm.ShowDialog();
>>>>>>> 81bafee186ab31ecd8ad5ff8d413353f50ddad8f
            this.Close();
        }
    }
}
