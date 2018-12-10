using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class MobilePhone : TechGear
    {
        //opet iako je broj pretpostavljamo da moze poceti sa nulom
        public string PhoneNumber { get; set; }
        public string Owner { get; set; }

        public MobilePhone(string serialNumber, string description, DateTime dateOfAquiring, int warranty, double price, string seller, bool battery, string phoneNumber, string owner)
            : base(serialNumber, description, dateOfAquiring, warranty, price, seller, battery)
        {
            PhoneNumber = phoneNumber;
            Owner = owner;
        }
    }
}
