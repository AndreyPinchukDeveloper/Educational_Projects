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
        DinnerParty dinnerParty = new DinnerParty();

        public PartyPlanner()
        {
            InitializeComponent();
            
        }
        
        private void Button_Calculate_Click(object sender, EventArgs e)
        {
            double people = (double)numericUpDown1.Value;
            textBox1.Text =dinnerParty.Calculate(people, CheckBox__Healthy_Options.Checked, CheckBox__Fancy_Decorations.Checked).ToString("c");

        }
    }
}
