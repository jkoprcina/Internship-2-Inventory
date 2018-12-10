using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class Hardware
    {
        //s pretpostavkom da serijski broj moze poceti s nulom
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateOfAquiring { get; set; }
        public int Warranty { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }

        public Hardware(string serialNumber, string description, DateTime dateOfAquiring, int warranty, double price, string seller)
        {
            SerialNumber = serialNumber;
            Description = description;
            DateOfAquiring = dateOfAquiring;
            Warranty = warranty;
            Price = price;
            Seller = seller;
        }
    }
}
