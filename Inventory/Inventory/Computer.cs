using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class Computer : TechGear
    {
        public OS OperatingSystem { get; set; }
        public bool Portable { get; set; }
        public ComputerCompanies Seller { get; set; }

        public Computer(Guid serialNumber, string description, DateTime dateOfAcquiring, int warranty, double price, ComputerCompanies seller, bool battery, OS operatingSystem, bool portable)
            : base(serialNumber, description, dateOfAcquiring, warranty, price, battery)
        {
            OperatingSystem = operatingSystem;
            Portable = portable;
        }

        public enum ComputerCompanies
        {
            Dell = 1,
            HP = 2,
            Acer = 3,
            Apple = 4
        }

        public enum OS
        {
            Android = 1,
            Windows = 2,
            iOS = 3,
            Linux = 4
        }

        public Computer AddComputer()
        {
            var success = false;
            var description = "";
            var warranty = 0;
            var price = 0.0;
            var seller = ComputerCompanies.Acer;
            var portable = false;
            var battery = false;
            var operatingSystem = OS.Android;

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
                var values = Enum.GetValues(typeof(ComputerCompanies));
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
                        seller = (ComputerCompanies)v;
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

            do
            {
                Console.WriteLine("Write 'true' if you computer is portable or 'false' if it's not");
                var text = Console.ReadLine();
                success = bool.TryParse(text, out portable);
            } while (!success);

            do
            {
                Console.WriteLine("Write 'true' if you computer has a battery or 'false' if it doesn't");
                var text = Console.ReadLine();
                success = bool.TryParse(text, out battery);
            } while (!success);

            do
            {
                success = false;
                Console.WriteLine("Enter a Operating System out of the listed");
                var values = Enum.GetValues(typeof(OS));
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
                        operatingSystem = (OS) v;
                    }
                }
            } while (!success);

            var comp = new Computer(Guid.NewGuid(), description, time, warranty, price, seller, battery, operatingSystem, portable);
            return comp;
        }

        public void RemovingComputer(string text, List<Computer> computers)
        {
            computers.RemoveAll(s => s.Description == text);
        }

        public void OutputComputers(List<Computer> computers)
        {
            var counter = 1;
            foreach (var v in computers)
            {
                Console.WriteLine("{0}. computer:", counter);
                counter++;
                Console.WriteLine(v.SerialNumber + " " + v.Description + " " + v.DateOfAcquiring.ToString("d/M/yyyy") + " " + v.Warranty);
                Console.WriteLine(v.Seller + " " + v.Price + " " + v.Battery + " " + v.OperatingSystem + " " + v.Portable);
            }
        }

        public List<Computer> ComputersWithCertainWarranty(int number, List<Computer> allComputers)
        {
            var computers = new List<Computer>();

            foreach (var c in allComputers)
            {
                var year = c.DateOfAcquiring.Year;
                var months = c.DateOfAcquiring.Month + c.Warranty;
                year += months / 12;
                if (year == number)
                    computers.Add(c);
            }

            return computers;
        }

        public List<Computer> CompsOfACertainOS(string OS, List<Computer> computers)
        {
            var certainOS = new List<Computer>();
            foreach (var p in computers)
            {
                if (p.OperatingSystem.ToString().ToLower() == OS.ToLower())
                    certainOS.Add(p);
            }

            return certainOS;
        }
    }
}
