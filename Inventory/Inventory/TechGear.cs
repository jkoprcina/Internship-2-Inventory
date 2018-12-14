using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class TechGear : Hardware
    {
        public bool Battery { get; set; }

        public TechGear(Guid serialNumber, string description, DateTime dateOfAquiring, int warranty, double price, string seller, bool battery)
            : base(serialNumber, description, dateOfAquiring, warranty, price, seller)
        {
            Battery = battery;
        }
    }
}
