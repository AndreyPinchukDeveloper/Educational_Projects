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
        Guy Joe = new Guy() { name = "Joe", cash = 50 };
        Guy Bob = new Guy() { name = "Bob", cash = 100 };
        public int sum = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void GiveButton_Click(object sender, EventArgs e)
        {
            GiveCash(sum, Bob.cash);
             
        }

        private void RecieveButton_Click(object sender, EventArgs e)
        {
            RecieveCash(Joe.cash, Bob.cash);
        }

        public void GiveCash(int firstValue, int secondValue)
        {
            if (secondValue >= 10)
            {
                firstValue += 10;
                secondValue -= 10;

            }
            else
            {
                MessageBox.Show("Im sorry ! But Bob has only " + secondValue + " $ !");
            }
        }

        public void RecieveCash(int firstValue, int secondValue)
        {
            if (secondValue >= 5)
            {
                secondValue -= 5;
                firstValue += 5;
            }
            else
            {
                MessageBox.Show("Im sorry ! But Joe has only " + firstValue + " $ !");
            }
        }
    }
}
