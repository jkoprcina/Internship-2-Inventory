using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class Computer : TechGear
    {
        public string OperatingSystem { get; set; }
        public bool Portable { get; set; }

        public Computer(Guid serialNumber, string description, DateTime dateOfAquiring, int warranty, double price, string seller, bool battery, string operatingSystem, bool portable)
            : base(serialNumber, description, dateOfAquiring, warranty, price, seller,battery)
        {
            OperatingSystem = operatingSystem;
            Portable = portable;
        }
    }
}
