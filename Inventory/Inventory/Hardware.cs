using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class Hardware
    {
        public Guid SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateOfAcquiring { get; set; }
        public int Warranty { get; set; }
        public double Price { get; set; }

        public Hardware(Guid serialNumber, string description, DateTime dateOfAcquiring, int warranty, double price)
        {
            SerialNumber = serialNumber;
            Description = description;
            DateOfAcquiring = dateOfAcquiring;
            Warranty = warranty;
            Price = price;
        }
    }
}
