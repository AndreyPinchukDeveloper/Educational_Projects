using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormTest
{
    public class Guy
    {
        public string name { get; set; }
        public int cash { get; set; }
        public void GiveCash(int firstValue, int secondValue)
        {
            if (secondValue>=10)
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
