using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class Vehicle : Hardware
    {
        public DateTime WarrantyExpirationDate { get; set; }
        public double Mileage { get; set; }
        public VehicleCompanies Seller { get; set; }

        public Vehicle(Guid serialNumber, string description, DateTime dateOfAcquiring, int warranty, double price, VehicleCompanies seller, DateTime warrantyExpirationDate, double mileage)
            :base(serialNumber, description, dateOfAcquiring, warranty, price)
        {
            WarrantyExpirationDate = warrantyExpirationDate;
            Mileage = mileage;
        }

        public enum VehicleCompanies
        {
            Toyota = 1,
            Honda = 2,
            Ford = 3,
            WolksVagen = 4
        }

        public Vehicle AddVehicle()
        {
            var description = "";
            var warranty = 0;
            var price = 0.0;
            var seller = VehicleCompanies.Toyota;
            var mileage = 0.0;
            var success = false;

            Console.WriteLine("Enter a description");
            description = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter the warranty in number of months");
                var number = Console.ReadLine();
                success = int.TryParse(number, out warranty);
                if (!success)
                {
                    Console.WriteLine("Wrong entry, try again");
                }
            } while (!success);

            do
            {
                Console.WriteLine("Enter a price");
                var number = Console.ReadLine();
                success = double.TryParse(number, out price);
                if (!success)
                {
                    Console.WriteLine("Wrong entry, try again");
                }
            } while (!success);
            do
            {
                success = false;
                Console.WriteLine("Enter a seller out of the listed");
                var values = Enum.GetValues(typeof(VehicleCompanies));
                foreach (var v in values)
                {
                    Console.WriteLine(v);
                }
                var input = Console.ReadLine();
                foreach (var v in values)
                {
                    if (input.ToLower() == v.ToString().ToLower())
                    {
                        success = true;
                        seller = (VehicleCompanies)v;
                    }
                }
            } while (!success);

            var year = 0;
            var month = 0;
            var day = 0;
            do
            {
                Console.WriteLine("Enter the year it was bought in number");
                var number = Console.ReadLine();
                success = int.TryParse(number, out year);
                if (!success)
                {
                    Console.WriteLine("Wrong entry, try again");
                }
            } while (!success);
            do
            {
                Console.WriteLine("Enter the month it was bought in number");
                var number = Console.ReadLine();
                success = int.TryParse(number, out month);
                if (!success)
                {
                    Console.WriteLine("Wrong entry, try again");
                }
            } while (!success || month < 1 || month > 12);
            do
            {
                Console.WriteLine("Enter the day it was bought in number");
                var number = Console.ReadLine();
                success = int.TryParse(number, out day);
                if (!success)
                {
                    Console.WriteLine("Wrong entry, try again");
                }
            } while (!success || day > 30 || day < 1);

            var time = new DateTime(year, month, day).Date;
            var temp = month + Warranty;
            var tempYear = year + temp / 12;
            var tempMonth = temp % 12;
            if (tempMonth == 0)
                tempMonth = 12;
            var timeExp = new DateTime(tempYear, tempMonth, day).Date;

            do
            {
                Console.WriteLine("Enter the mileage");
                var number = Console.ReadLine();
                success = double.TryParse(number, out mileage);
                if (!success)
                {
                    Console.WriteLine("Wrong entry, try again");
                }
            } while (!success);

            var veh = new Vehicle(Guid.NewGuid(), description, time, warranty, price, seller, timeExp, mileage);
            return veh;
        }

        public void RemovingVehicle(string text, List<Vehicle> vehicles)
        {
            vehicles.RemoveAll(s => s.Description == text);
        }

        public void OutputVehicles(List<Vehicle> vehicles)
        {
            var counter = 1;
            foreach (var v in vehicles)
            {
                Console.WriteLine("{0}. vehicle:", counter);
                counter++;
                Console.WriteLine(v.SerialNumber + " " + v.Description + " " + v.DateOfAcquiring.ToString("d/M/yyyy") + " " + v.Warranty);
                Console.WriteLine(v.Seller + " " + v.Price + " " + v.WarrantyExpirationDate.ToString("d/M/yyyy") + " " + v.Mileage);
            }
        }

        public List<Vehicle> VehiclesWithCertainWarranty(List<Vehicle> allVehicles)
        {
            var vehicles = new List<Vehicle>();

            foreach (var c in allVehicles)
            {
                var monthCarWarrantyExpires = c.WarrantyExpirationDate.Month;
                var dayCarWarrantyExpires = c.WarrantyExpirationDate.Day;
                var currentMonth = DateTime.Now.Month;
                var currentDay = DateTime.Now.Day;
                if ((monthCarWarrantyExpires == (currentMonth + 1) && dayCarWarrantyExpires < currentDay) || (monthCarWarrantyExpires == currentMonth && dayCarWarrantyExpires > currentDay))
                {
                    vehicles.Add(c);
                }
            }

            return vehicles;
        }

        public string VehiclePrices(List<Vehicle> vehicles)
        {
            var prices = "";
            foreach (var v in vehicles)
            {
                prices += v.Description + "\t" + v.Price + "\t";
                var calc = v.Mileage / 20000;
                int number = (int)(v.Mileage / 20000);
                var newPrice = 0.0;
                if (v.Price * (calc / 10) > (v.Price * 0.2))
                {
                    newPrice = v.Price - (v.Price * (calc / 10));
                    prices += newPrice + "\t" + (v.Price - newPrice) + "\n";
                }
                else
                {
                    newPrice = v.Price * 0.2;
                    prices += newPrice + "\t" + (v.Price - newPrice) + "\n";
                }
            }
            return prices;
        }
    }
}
