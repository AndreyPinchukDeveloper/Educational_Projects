using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooker.FactoryMethod.Factory
{
    internal class GymANdSwimmingFactory:MembershipFactory
    {
        private readonly decimal _price;
        private readonly string _description;

        public GymANdSwimmingFactory(decimal price, string description)
        {
            _price = price;
            _description = description;
        }

        public override IMembership GetMembership()
        {
            GymAndSwimming membership = new(_price)
            {
                Description = _description
            };
            return membership;
        }
    }
}
