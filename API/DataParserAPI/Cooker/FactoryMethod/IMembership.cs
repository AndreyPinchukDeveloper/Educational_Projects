using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooker.FactoryMethod
{
    internal interface IMembership
    {
        public string Name { get; }
        public string Description { get; set; }
        decimal GetPrice();
    }
}
