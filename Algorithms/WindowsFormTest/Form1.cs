using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTest
{
    public partial class Form1 : Form
    {
        Elephant lloyd = new Elephant() { EarSize = 40, Name = "Lloyd" };
        Elephant lucinda = new Elephant() { EarSize = 33, Name = "Lucinda" };
        Elephant iAmThird = new Elephant() { EarSize = 0, Name = "NoName" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Lloyd_Click(object sender, EventArgs e)
        {
            lloyd.WhoAmI(lloyd);
        }

        private void Lucinda_Click(object sender, EventArgs e)
        {
            lucinda.WhoAmI(lucinda);
        }

        private void Swap_Click(object sender, EventArgs e)
        {
            switch (lloyd.EarSize)
            {
                case 40:
                    iAmThird = lloyd;
                    lloyd = lucinda;
                    lucinda = iAmThird;
                    MessageBox.Show("References has been chenged");
                    break;
                case 33:
                    iAmThird = lloyd;
                    lloyd = lucinda;
                    lucinda = iAmThird;
                    MessageBox.Show("References has been chenged");
                    break;
                default:
                    break;
            }
            
        }

    }
}
