using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party_Planner
{
    class DinnerParty
    {
        public double Calculate(double guests, bool healthyOptions, bool fancyDecorations)
        {
            double calculatedCost = 0;

            if (fancyDecorations && healthyOptions)
            {
                calculatedCost = guests * 5 + guests * 15 + 50;
                calculatedCost *= 0.95;
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
            return calculatedCost;
        }
    }
}
