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

        public Form1()
        {
            InitializeComponent();
        }

        private void Lloyd_Click(object sender, EventArgs e)
        {
            WhoAmI(lloyd);
        }

        private void Lucinda_Click(object sender, EventArgs e)
        {
            WhoAmI(lucinda);
        }

        private void Swap_Click(object sender, EventArgs e)
        {

        }

        public void WhoAmI(Elephant elephant)
        {
            
        }
    }
}
