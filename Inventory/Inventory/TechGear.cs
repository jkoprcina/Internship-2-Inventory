using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class TechGear : Hardware
    {
        public bool Battery { get; set; }

        public TechGear(Guid serialNumber, string description, DateTime dateOfAcquiring, int warranty, double price, bool battery)
            : base(serialNumber, description, dateOfAcquiring, warranty, price)
        {
            Battery = battery;
        }

        public int NumberOfTechGearWithBattery(List<MobilePhone> phones, List<Computer> computers)
        {
            var batteryCounter = 0;

            foreach (var p in phones)
            {
                if (p.Battery)
                    batteryCounter++;
            }
            foreach (var c in computers)
            {
                if (c.Battery)
                    batteryCounter++;
            }

            return batteryCounter;
        }

        public string TechGearPrices(List<MobilePhone> phones, List<Computer> computers)
        {
            var prices = "";

            foreach (var v in phones)
            {
                prices += v.Description + "\t" + v.Price + "\t";
                var current = new DateTime();
                var currentYear = current.Year;
                var currentMonth = current.Month;
                var currentDay = current.Day;

                var yearDifference = currentYear - v.DateOfAcquiring.Year;
                var monthDifference = currentMonth - v.DateOfAcquiring.Month;
                monthDifference += yearDifference * 12;
                var percentage = (monthDifference * 0.5);

                if ((v.Price * (monthDifference * 0.5)) > (0.3 * v.Price))
                {
                    var newPrice = (v.Price * (monthDifference * 0.5));
                    prices += newPrice + "\t" + (v.Price - newPrice) + "\n";
                }
                else
                {
                    var newPrice = 0.3 * v.Price;
                    prices += newPrice + "\t" + (v.Price - newPrice) + "\n";
                }
            }

            foreach (var v in computers)
            {
                prices += v.Description + "\t" + v.Price + "\t";
                var current = new DateTime();
                var currentYear = current.Year;
                var currentMonth = current.Month;
                var currentDay = current.Day;

                var yearDifference = currentYear - v.DateOfAcquiring.Year;
                var monthDifference = currentMonth - v.DateOfAcquiring.Month;
                monthDifference += yearDifference * 12;
                var percentage = (monthDifference * 5) / 100;

                if ((v.Price * (monthDifference * 5) / 100) > (0.3 * v.Price))
                    prices += v.Price * (monthDifference * 5) / 100 + "\t" + (v.Price * (monthDifference * 5) / 100) + "\n";
                else
                    prices += (0.3 * v.Price) + "\t" + (v.Price - 0.3 * v.Price) + "\n";

            }
            return prices;
        }
    }
}
