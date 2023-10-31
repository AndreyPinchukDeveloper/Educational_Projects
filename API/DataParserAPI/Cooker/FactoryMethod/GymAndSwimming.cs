using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooker.FactoryMethod
{
    internal class GymAndSwimming:IMembership
    {
        private readonly string _name;
        private readonly decimal _price;

        public GymAndSwimming(decimal price)
        {
            _name = "Gym ANd swimming";
            _price = price;
        }

        public string Name => _name;
        public string Description { get; set; }

        public decimal GetPrice() => _price;
    }
}
