using CariHesap.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariHesap.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SigInBtn_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            var pass = textBox2.Text;

            var saveModel = UserHelper.SingIn(name, pass);

            if (saveModel.isSuccess)
            {
                Hide();

                var dashBoard = new Dashboard();
                dashBoard.Show();
            }
            else
            {
                MessageBox.Show(saveModel.message,"Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
