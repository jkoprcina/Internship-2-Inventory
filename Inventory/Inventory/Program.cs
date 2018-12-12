using System;
using System.Collections.Generic;
namespace Inventory
{
    class Program
    {
        public static class Globals
        {
            public static int id = 0;
        }
        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>();
            var phones = new List<MobilePhone>();
            var computers = new List<Computer>();
            var choice = 0;

            vehicles = PreliminaryInputVehicles();
            phones = PreliminaryInputPhones();
            computers = PreliminaryInputComputers();

            do
            {
                Console.Write("Choose a given option to see the information on something or write in a number higher than 5 to leave the menu:\n" +
                    "1) The specific item you'd like\n" +
                    "2) Computers whose warranty expires in a certain year\n" +
                    "3) How many pieces of technology have a battery\n" +
                    "4) Phones of a certain brand\n" +
                    "5) The names and phone numbers of employes whose warranty expires in a certain year\n" +
                    "6) Vehicles whose warranty expires in a month or less\n" +
                    "7) Price and price change of a certain piece of hardware\n" +
                    "8) All the computers with a certain operating system\n");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Please enter the serial number of the item you'd like to see");
                        try
                        {
                            var specificItem = int.Parse(Console.ReadLine());
                            Console.WriteLine(OutputForACertainItem(specificItem, vehicles, phones, computers));
                        }
                        catch
                        {
                            Console.WriteLine("The input was a bad format");
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Enter the year in which you want to see which computers warranties expire");
                        try
                        {
                            var year = int.Parse(Console.ReadLine());
                            List<Computer> locatedComputers = ComputersWithCertainWarranty(year, computers);
                            if (locatedComputers != null)
                            {
                                foreach (Computer c in locatedComputers)
                                    Console.WriteLine(c.SerialNumber + " " + c.Description + " " + c.DateOfAquiring);
                            }
                            else
                                Console.WriteLine("There are none that expire in the given year");
                        }
                        catch {
                            Console.WriteLine("The input was a bad format");
                        }
                        break;
                    case 3:
                        var numberOfBatteries = NumberOfTechGearWithBattery(phones, computers);
                        Console.WriteLine("The number of batteries in use is {0}", numberOfBatteries);
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Enter the brand of phones you'd like to see");
                            var whichBrand = Console.ReadLine();
                            var brandedPhones = PhonesOfACertainBrand(whichBrand, phones);
                            if (brandedPhones != null)
                            {
                                foreach(MobilePhone c in brandedPhones)
                                    Console.WriteLine(c.SerialNumber + " " + c.Description + " " + c.DateOfAquiring);
                            }
                         }
                        catch {
                            Console.WriteLine("Krivi tip unosa");
                            break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter the year in which you want to see which phones warranties expire");
                        try
                        {
                            var year = int.Parse(Console.ReadLine());
                            List<MobilePhone> locatedPhones = PhonesWithCertainWarranty(year, phones);
                            if (locatedPhones != null)
                            {
                                foreach (MobilePhone c in locatedPhones)
                                    Console.WriteLine(c.SerialNumber + " " + c.Owner + " " + c.PhoneNumber);
                            }
                            else
                                Console.WriteLine("There are none that expire in the given year");
                        }
                        catch
                        {
                            Console.WriteLine("The input was a bad format");
                        }
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        try
                        {
                            Console.WriteLine("Enter the OS and we'll display the computers that run them");
                            var whichOS = Console.ReadLine();
                            var systemComps = CompsOfACertainOS(whichOS, computers);
                            if (systemComps != null)
                            {
                                foreach (Computer c in systemComps)
                                    Console.WriteLine(c.SerialNumber + " " + c.Description + " " + c.OperatingSystem);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Krivi tip unosa");
                            break;
                        }
                        break;
                }
            } while (choice > 0 && choice < 9);
            Console.WriteLine("Have a nice day!");
            Console.ReadKey();
        }

        //Methods for the main menu

        //Method to show the user a certain item he requested through the input of it's serial number  11111
        static string OutputForACertainItem(int number, List<Vehicle> vehicles, List<MobilePhone> phones, List<Computer> computers)
        {
            foreach (Vehicle v in vehicles)
            {
                if (v.SerialNumber == number)
                    return (v.SerialNumber + " " + v.Description + " " + v.Seller);
            }
            foreach (MobilePhone p in phones)
            {
                if (p.SerialNumber == number)
                    return (p.SerialNumber + " " + p.Description + " " + p.Seller);
            }
            foreach (Computer c in computers)
            {
                if (c.SerialNumber == number)
                    return (c.SerialNumber + " " + c.Description + " " + c.Seller);
            }
            return "The id does not exist";
        }

        //Methos used to search for when a warranty will expire    2222222
        static List<Computer> ComputersWithCertainWarranty(int number, List<Computer> allComputers)
        {
            var computers = new List<Computer>();

            foreach (Computer c in allComputers)
            {
                var year = c.DateOfAquiring.Year;
                var months = c.DateOfAquiring.Month + c.Warranty;
                year += months / 12;
                if (year == number)
                    computers.Add(c);
            }

            return computers;
        }

        //Just returns the number of objects that have a battery     333333
        static int NumberOfTechGearWithBattery(List<MobilePhone> phones, List<Computer> computers)
        {
            var batteryCounter = 0;

            foreach (MobilePhone p in phones)
            {
                if (p.Battery)
                    batteryCounter++;
            }
            foreach (Computer c in computers)
            {
                if (c.Battery)
                    batteryCounter++;
            }

            return batteryCounter;
        }

        // lists all the phones that are the brand the user inputs       44444
        static List<MobilePhone> PhonesOfACertainBrand(string brand, List<MobilePhone> phones)
        {
            var thePhonesYouAreLoookingFor = new List<MobilePhone>();
            foreach (MobilePhone p in phones)
            {
                if (p.Seller.ToLower() == brand)
                    thePhonesYouAreLoookingFor.Add(p);
            }

            return thePhonesYouAreLoookingFor;
        }

        // prints out all the phones that have warranties which expire in the given year     55555
        static List<MobilePhone> PhonesWithCertainWarranty(int number, List<MobilePhone> allPhones)
        {
            var phones = new List<MobilePhone>();

            foreach (MobilePhone c in allPhones)
            {
                var year = c.DateOfAquiring.Year;
                var months = c.DateOfAquiring.Month + c.Warranty;
                year += months / 12;
                if (year == number)
                    phones.Add(c);
            }

            return phones;
        }

        // lists all the computers that use the required OS         88888
        static List<Computer> CompsOfACertainOS(string OS, List<Computer> computers)
        {
            var certainOS = new List<Computer>();
            foreach (Computer p in computers)
            {
                if (p.OperatingSystem.ToLower() == OS.ToLower())
                    certainOS.Add(p);
            }

            return certainOS;
        }
        //Creating dummy objects for easier testing of aplication
        static List<Vehicle> PreliminaryInputVehicles()
        {
            var listOfVehicles = new List<Vehicle>();

            var descriptionsOfVehicles = new string[4] { "Good", "A firetruck", "A lamborgini ( boss's car)", "Run down" };
            var dateOfAquiringOfVehicles = new DateTime[4]
            {
                new DateTime(2011, 11, 1),
                new DateTime(2010, 10, 2),
                new DateTime(2014, 5, 1),
                new DateTime(2000, 2, 2)
            };
            var warrantyOfVehicles = new int[4] { 24, 12, 36, 48 };
            var priceOfVehicles = new double[4] { 10000, 21000, 30000, 15000 };
            var sellerOfVehicles = new string[4] { "Honda", "Toyota", "WolksVagen", "Ford" };
            var warrantyExpirationDateOfVehicles = new DateTime[4]
            {
                new DateTime(2020, 11, 1),
                new DateTime(2021, 10, 2),
                new DateTime(2022, 5, 1),
                new DateTime(2020, 2, 2)
            };
            var mileageOfVehicles = new double[4] { 1000.5, 1535.3, 40000.53, 311.3 };

            for (int i = 0; i < 4; i++)
            {
                var dummyVehicle = new Vehicle(Globals.id, descriptionsOfVehicles[i], dateOfAquiringOfVehicles[i], warrantyOfVehicles[i], priceOfVehicles[i], sellerOfVehicles[i], warrantyExpirationDateOfVehicles[i], mileageOfVehicles[i]);
                Globals.id++;
                listOfVehicles.Add(dummyVehicle);
            }
            return listOfVehicles;
        }

        static List<MobilePhone> PreliminaryInputPhones()
        {
            var listOfPhones = new List<MobilePhone>();

            var descriptionsOfPhones = new string[4] { "Old", "Bad touchscreen", "A iphone X ( boss's phone)", "Barely working" };
            var dateOfAquiringOfPhones = new DateTime[4]
            {
                new DateTime(2011, 11, 1),
                new DateTime(2010, 10, 2),
                new DateTime(2014, 5, 1),
                new DateTime(2000, 2, 2)
            };
            var warrantyOfPhones = new int[4] { 0, 12, 24, 12 };
            var priceOfPhones = new double[4] { 1000, 400, 200, 800};
            var batteryOfPhones = new bool[4] { true, false, true, false };
            var phoneNumberOfPhones = new string[4] { "099434553", "091324532", "099856432", "097421234" };
            var ownerOfPhones = new string[4] { "BATMAN" , "J.Jonah Jameson", "Spiderman", "Nobody" };

            for (int i = 0; i < 4; i++)
            {
                var dummyPhone = new MobilePhone(Globals.id, descriptionsOfPhones[i], dateOfAquiringOfPhones[i], warrantyOfPhones[i], priceOfPhones[i], "apple", batteryOfPhones[i], phoneNumberOfPhones[i], ownerOfPhones[i]);
                Globals.id++;
                listOfPhones.Add(dummyPhone);
            }

            return listOfPhones;
        }

        static List<Computer> PreliminaryInputComputers()
        {
            var listOfComputers = new List<Computer>();

            var descriptionsOfComputers = new string[4] { "Gaming computer", "For writing code", "A mac ( boss's laptop)", "New" };
            var dateOfAquiringOfComputers = new DateTime[4]
                {
                new DateTime(2015, 11, 9),
                new DateTime(2016, 10, 8),
                new DateTime(2014, 4, 5),
                new DateTime(2017, 2, 5)
            };
            var warrantyOfComputers = new int[4] { 24, 24, 32, 12 };
            var priceOfComputers = new double[4] { 1000, 800, 200, 1000 };
            var sellerOfComputers = new string[4] { "Dell", "HP", "Acer", "Apple" };
            var batteryOfComputers = new bool[4] { true, false, true, false };
            var operatingSystemOfComputers = new string[4] { "Windows", "Windows", "Linux", "iOS" };
            var portableOfComputers = new bool[4] { true, true, false, false };

            for (int i = 0; i < 4; i++)
            {
                var dummyComputer = new Computer(Globals.id, descriptionsOfComputers[i], dateOfAquiringOfComputers[i], warrantyOfComputers[i], priceOfComputers[i], sellerOfComputers[i], batteryOfComputers[i], operatingSystemOfComputers[i], portableOfComputers[i]);
                Globals.id++;
                listOfComputers.Add(dummyComputer);
            }

            return listOfComputers;
        }


        //creating enums for sellers
        public enum ComputerCompanies
        {
            Dell = 1,
            HP = 2,
            Acer = 3,
            Apple = 4
        }

        public enum PhoneCompanies
        {
            Samsung = 1,
            Sony = 2,
            Xiaomi = 3,
            Apple = 4
        }

        public enum VehicleCompanies
        {
            Toyota = 1,
            Honda = 2,
            Ford = 3,
            WolksVagen = 4
        }

    }
}
