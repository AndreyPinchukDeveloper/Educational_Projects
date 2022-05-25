using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Party_Planner
{
    public partial class PartyPlanner : Form
    {

        int mumberOfPeople = 0;
        double cost = 0;

        public PartyPlanner()
        {
            InitializeComponent();
        }

        private void Button_Calculate_Click(object sender, EventArgs e)
        {

        }

        private double Calculate(int guests, bool fancyDecorations, bool healthyOptions)
        {
            double calculatedCost = 0;

            if (fancyDecorations && healthyOptions)
            {

            }
            return calculatedCost;
        }
    }
}
