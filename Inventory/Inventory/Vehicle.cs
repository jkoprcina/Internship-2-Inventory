using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class Vehicle : Hardware
    {
        public DateTime WarrantyExpirationDate { get; set; }
        public double Mileage { get; set; }

        public Vehicle(Guid serialNumber, string description, DateTime dateOfAquiring, int warranty, double price, string seller, DateTime warrantyExpirationDate, double mileage)
            :base(serialNumber, description, dateOfAquiring, warranty, price, seller)
        {
            WarrantyExpirationDate = warrantyExpirationDate;
            Mileage = mileage;
        }
    }
}
