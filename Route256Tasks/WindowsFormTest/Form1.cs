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
        Bank Bank = new Bank { name = "Bank", cash = 100 };

        public Form1()
        {
            InitializeComponent();
        }

        private void JoeGivesToBob_Click(object sender, EventArgs e)
        {
            if (Joe.cash>=10)
            {
                Joe.cash -= 10;
                Bob.cash += 10;
                UpdateForm();
            }
            else
            {
                MessageBox.Show("My pockets are empty !");
            }
        }

        private void BobGivesToJoe_Click(object sender, EventArgs e)
        {
            if (Bob.cash >= 5)
            {
                Bob.cash -= 5;
                Joe.cash += 5;
                UpdateForm();
            }
            else
            {
                MessageBox.Show("My pockets are empty !");
            }
        }

        private void BankGivesJoe_Click(object sender, EventArgs e)
        {
            if (Bank.cash>=10)
            {
                Bank.cash -= 10;
                Joe.cash += 10;
            }
            else
            {
                MessageBox.Show("Tha bank don't have any money yet !");
            }
            UpdateForm();
        }

        private void BankGivesToBob_Click(object sender, EventArgs e)
        {
            if (Bob.cash >= 5)
            {
                Bank.cash += 5;
                Bob.cash -= 5;
            }
            else
            {
                MessageBox.Show("Tha bank don't have any money yet !");
            }
            UpdateForm();
        }

        private void UpdateForm()
        {
            MoneyOfJoe.Text = "Joe has $ "+ Joe.cash.ToString();
            MoneyOfBob.Text = "Bob has $ " + Bob.cash.ToString();
            MoneyOfBank.Text = "The Bank has $ " + Bank.cash.ToString();
        }
    }
}
