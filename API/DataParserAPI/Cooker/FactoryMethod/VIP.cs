using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooker.FactoryMethod
{
    internal class VIP:IMembership
    {
        private readonly string _name;
        private readonly decimal _price;

        public VIP(decimal price)
        {
            _name = "VIP";
            _price = price;
        }

        public string Name => _name;
        public string Description { get; set; }

        public decimal GetPrice() => _price;
    }
}
