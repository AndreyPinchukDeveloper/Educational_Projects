using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTest
{
    class Elephant
    {
        public int EarSize{get; set;}

        public string Name { get; set; }


        public void WhoAmI(Elephant elephant)
        {
            MessageBox.Show("My ears are " + elephant.EarSize + " inches tall.");
        } 
    }
}
