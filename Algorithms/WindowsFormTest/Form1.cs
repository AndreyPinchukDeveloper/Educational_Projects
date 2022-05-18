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
        private decimal price = 39;
        private decimal miles = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void calculate_Button_Click(object sender, EventArgs e)
        {
            decimal count = (MileageOnEnd.Value - MileageOnStart.Value)*price;
            money.Text = count.ToString()+" $";
        }

        private void display_miles_Click(object sender, EventArgs e)
        {
            miles = MileageOnEnd.Value - MileageOnStart.Value;
            MessageBox.Show(miles.ToString());
        }
    }
}
