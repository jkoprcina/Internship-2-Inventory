using System;
using System.Collections.Generic;
namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var Phones = new List<MobilePhone>();
            var Vehicles = new List<Vehicle>();
            var Computers = new List<Computer>();
            var choice = 0;

            PreliminaryInputVehicles();
            PreliminaryInputPhones();
            PreliminaryInputComputers();

            do
            {
                Console.Write("Choose a given option to see the information on something or write in a number higher than 5 to leave the menu:" +
                    "1) The specific item you'd like" +
                    "2) Computers whose warranty expires in a certain year" +
                    "3) How many pieces of technology have a battery" +
                    "4) Phones of a certain brand" +
                    "5) The names and phone numbers of employes whose warranty expires in a certain year" +
                    "6) Vehicles whose warranty expires in a month or less" +
                    "7) Price and price change of a certain piece of hardware ");
            } while (choice < 1 || choice > 7);
            Console.WriteLine("Have a nice day!");
        }
        
        static List<Vehicle> PreliminaryInputVehicles()
        {
            var listOfVehicles = new List<Vehicle>();

            var descriptionsOfVehicles = new string[4] { "Good", "A firetruck", "A lamborgini ( boss's car)", "Run down" };
            var dateOfAquiringOfVehicles = new DateTime[4];
            var warrantyOfVehicles = new int[4] { 24, 12, 36, 48 };
            var priceOfVehicles = new double[4] { 10000, 21000, 30000, 15000 };
            var sellerOfVehicles = new string[4] { "Honda", "Toyota", "WolksVagen", "Ford" };
            var warrantyExpirationDateOfVehicles = new DateTime[4];
            var mileageOfVehicles = new double[4] { 1000.5, 1535.3, 40000.53, 311.3 };

            for (int i = 0; i < 4; i++)
            {
                var dummyVehicle = new Vehicle(i.ToString(), descriptionsOfVehicles[i], dateOfAquiringOfVehicles[i], warrantyExpirationDateOfVehicles[i], priceOfVehicles[i], sellerOfVehicles[i], warrantyExpirationDateOfVehicles[i], mileageOfVehicles[i]);
                listOfVehicles.Add(dummyVehicle);
            }
            return listOfVehicles;
        }

        static List<MobilePhone> PreliminaryInputPhones()
        {
            var listOfPhones = new List<MobilePhone>();

            var descriptionsOfPhones = new string[4] { "Good", "A firetruck", "A lamborgini ( boss's car)", "Run down" };
            var dateOfAquiringOfPhones = new DateTime[4];
            var warrantyOfPhones = new int[4] { 0, 12, 24, 12 };
            var priceOfPhones = new double[4] { 1000, 400, 200, 800};
            var batteryOfPhones = new bool[4] { true, false, true, false };
            var phoneNumberOfPhones = new string[4] { "099434553", "091324532", "099856432", "097421234" };
            var ownerOfPhones = new string[4] { "BATMAN" , "J.Jonah Jameson", "Spiderman", "Nobody" };

            for (int i = 0; i < 4; i++)
            {
                var dummyPhone = new MobilePhone(i.ToString(), descriptionsOfPhones[i], dateOfAquiringOfPhones[i], warrantyExpirationDateOfPhones[i], priceOfPhones[i], PhoneCompanies.[i], batteryOfPhones[i], phoneNumberOfPhones[i], ownerOfPhones[i]);
                listOfPhones.Add(dummyPhone);
            }

            return listOfPhones;
        }

        static List<Computer> PreliminaryInputComputers()
        {
            var listOfComputers = new List<Computer>();

            var descriptionsOfComputers = new string[4] { "Good", "A firetruck", "A lamborgini ( boss's car)", "Run down" };
            var dateOfAquiringOfComputers = new DateTime[4];
            var warrantyOfComputers = new int[4] { 24, 24, 32, 12 };
            var priceOfComputers = new double[4] { 1000, 800, 200, 1000 };
            var sellerOfComputers = new string[4] { "Dell", "HP", "Acer", "Apple" };
            var batteryOfComputers = new bool[4] { true, false, true, false };
            var operatingSystemOfComputers = new string[4] { "Windows", "Windows", "Linux", "iOS" };
            var portableOfComputers = new bool[4] { true, true, false, false };

            for (int i = 0; i < 4; i++)
            {
                var dummyComputer = new Computer(i.ToString(), descriptionsOfComputers[i], dateOfAquiringOfComputers[i], warrantyExpirationDateOfVehicles[i], priceOfComputers[i], sellerOfComputers[i], batteryOfComputers[i], operatingSystemOfComputers[i], portableOfComputers[i]);
                listOfComputers.Add(dummyComputer);
            }

            return listOfComputers;
        }

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
