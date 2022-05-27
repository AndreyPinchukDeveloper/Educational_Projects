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
        
        public PartyPlanner()
        {
            InitializeComponent();
            
        }
        
        private void Button_Calculate_Click(object sender, EventArgs e)
        {
            double people = (double)numericUpDown1.Value;
            Calculate(people, CheckBox__Healthy_Options.Checked, CheckBox__Fancy_Decorations.Checked);
        }

        private void Calculate(double guests, bool healthyOptions, bool fancyDecorations)
        {
            double calculatedCost = 0;

            if (fancyDecorations && healthyOptions)
            {
                calculatedCost = guests * 5 + guests * 15 + 50;
                calculatedCost *=  0.95;
            }
            else if (fancyDecorations && !healthyOptions)
            {
                calculatedCost = guests * 20 + guests * 15 + 50;
            }
            else if (!fancyDecorations && healthyOptions)
            {
                calculatedCost = guests * 5 + guests * 7.5 + 30;
                calculatedCost *= 0.95;
            }
            else if (!fancyDecorations && !healthyOptions)
            {
                calculatedCost = guests * 20 + guests * 7.5 + 30;
            }
            textBox1.Text = calculatedCost + " $";
        }

        /*public void UpdateFields()
        {
            textBox1.Text = 
        }*/
    }
}
