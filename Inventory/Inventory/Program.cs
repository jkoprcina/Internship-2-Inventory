using System;
using System.Collections.Generic;
namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = PreliminaryInputVehicles();
            var phones = PreliminaryInputPhones();
            var computers = PreliminaryInputComputers();
            var singleVehicle = vehicles[0];
            var singlePhone = phones[0];
            var singleComputer = computers[0];
            var choice = "";
            var success = false;
            do
            {
                Console.Write("Choose a given option or write 'ok' if you want to leave:\n" +
                    "0) Add a Vehicle, Computer or MobilePhone\n" +
                    "1) The specific item you'd like\n" +
                    "2) Computers whose warranty expires in a certain year\n" +
                    "3) How many pieces of technology have a battery\n" +
                    "4) Phones of a certain brand\n" +
                    "5) The names and phone numbers of employes whose warranty expires in a certain year\n" +
                    "6) Vehicles whose warranty expires in a month or less\n" +
                    "7) Price and price change of all hardware\n" +
                    "8) All the computers with a certain operating system\n" +
                    "9) Delete a Vehicle, Computer or MobilePhone\n" +
                    "10) Show everything\n");
                choice = Console.ReadLine();
                var word = "";
                switch (choice)
                {
                    case "0":
                        do
                        {
                            Console.WriteLine("Would you like to add a vehicle, computer or phone");
                            word = Console.ReadLine();
                            if (word.ToLower() == "vehicle")
                            {
                                var veh = singleVehicle.AddVehicle();
                                vehicles.Add(veh);
                            }
                            else if (word.ToLower() == "computer")
                            {
                                var comp = singleComputer.AddComputer();
                                computers.Add(comp);
                            }
                            else if (word.ToLower() == "phone")
                            {
                                var pho = singlePhone.AddMobilePhone();
                                phones.Add(pho);
                            }
                        } while (word.ToLower() != "vehicle" && word.ToLower() != "computer" && word.ToLower() != "phone");
                        break;
                    case "1":
                        Console.WriteLine("Please enter the description of the item you'd like to see");
                        var specificItem = Console.ReadLine();
                        Console.WriteLine(OutputForACertainItem(specificItem, vehicles, phones, computers));
                        break;
                    case "2":
                        Console.WriteLine("Enter the year in which you want to see which computers warranties expire");
                        success = int.TryParse(Console.ReadLine(), out var info);
                        List<Computer> locatedComputers = singleComputer.ComputersWithCertainWarranty(info, computers);
                        if (!success)
                        {
                            Console.WriteLine("Wrong entry, try again");
                            break;
                        }
                        if (locatedComputers != null)
                        {
                            foreach (var c in locatedComputers)
                                Console.WriteLine(c.SerialNumber + " " + c.Description + " " + c.DateOfAcquiring);
                        }
                        else
                            Console.WriteLine("There are none that expire in the given year");
                        break;
                    case "3":
                        var numberOfBatteries = singlePhone.NumberOfTechGearWithBattery(phones, computers);
                        Console.WriteLine("The number of batteries in use is {0}", numberOfBatteries);
                        break;
                    case "4":
                        Console.WriteLine("Enter the brand of phones you'd like to see");
                        var whichBrand = Console.ReadLine();
                        var brandedPhones = singlePhone.PhonesOfACertainBrand(whichBrand, phones);
                        if (brandedPhones != null)
                        {
                            foreach(var c in brandedPhones)
                                Console.WriteLine(c.SerialNumber + " " + c.Description + " " + c.DateOfAcquiring);
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter the year in which you want to see which phones warranties expire");
                        success = int.TryParse(Console.ReadLine(), out var year);
                        List<MobilePhone> locatedPhones = singlePhone.PhonesWithCertainWarranty(year, phones);
                        if (locatedPhones != null)
                        {
                            foreach (var c in locatedPhones)
                                Console.WriteLine(c.SerialNumber + " " + c.Owner + " " + c.PhoneNumber);
                        }
                        else
                            Console.WriteLine("There are none that expire in the given year");
                        break;
                    case "6":
                        var locatedVehicles = singleVehicle.VehiclesWithCertainWarranty(vehicles);
                        foreach (var v in locatedVehicles)
                            Console.WriteLine(v.Description + " " + v.WarrantyExpirationDate + " " + v.Mileage);
                        if (locatedVehicles == null)
                            Console.WriteLine("There are none that expire next month");
                        break;
                    case "7":
                        Console.WriteLine("All the pricing information");
                        var vehiclePrices = singleVehicle.VehiclePrices(vehicles);
                        var techGear = singlePhone.TechGearPrices(phones, computers);
                        Console.WriteLine(vehiclePrices);
                        Console.WriteLine(techGear);
                        break;
                    case "8":
                        Console.WriteLine("Enter the OS and we'll display the computers that run them");
                        var whichOS = Console.ReadLine();
                        var systemComps = singleComputer.CompsOfACertainOS(whichOS, computers);
                        if (systemComps != null)
                        {
                            foreach (var c in systemComps)
                                Console.WriteLine(c.SerialNumber + " " + c.Description + " " + c.OperatingSystem);
                        }
                        break;
                    case "9":
                        do
                        {
                            var checking = false;
                            Console.WriteLine("Would you like to remove a vehicle, computer or phone");
                            word = Console.ReadLine();
                            var text = "";
                            if (word.ToLower() == "vehicle")
                            {
                                singleVehicle.OutputVehicles(vehicles);
                                Console.WriteLine("Enter the description of the item you wanna remove");
                                text = Console.ReadLine();
                                foreach (var v in vehicles)
                                {
                                    if (v.Description == text)
                                        checking = true;
                                }
                                if (checking == true)
                                {
                                    vehicles[0].RemovingVehicle(text, vehicles);
                                }
                                else
                                    Console.WriteLine("That vehicle doesn't exist");
                            }
                            else if (word.ToLower() == "computer")
                            {
                                singleComputer.OutputComputers(computers);
                                Console.WriteLine("Enter the description of the item you wanna remove");
                                text = Console.ReadLine();
                                foreach (var c in computers)
                                {
                                    if (c.Description == text)
                                        checking = true;
                                }
                                if (checking == true)
                                    {
                                    singleComputer.RemovingComputer(text, computers);
                                }
                                else
                                    Console.WriteLine("That computer doesn't exist");
                            }
                            else if (word.ToLower() == "phone")
                            {
                                singlePhone.OutputMobilePhones(phones);
                                Console.WriteLine("Enter the description of the item you wanna remove");
                                text = Console.ReadLine();
                                foreach (var m in phones)
                                {
                                    if (m.Description == text)
                                        checking = true;
                                }
                                if (checking == true)
                                {
                                    singlePhone.RemovingPhone(text, phones);
                                }
                                else
                                    Console.WriteLine("That phone doesn't exist");
                            }
                        } while (word.ToLower() != "vehicle" && word.ToLower() != "computer" && word.ToLower() != "phone");
                        break;
                    case "10":
                        singleVehicle.OutputVehicles(vehicles);
                        singleComputer.OutputComputers(computers);
                        singlePhone.OutputMobilePhones(phones);
                        break;
                }
                choice = choice.ToLower();
            } while (choice != "ok");
            Console.WriteLine("Have a nice day!");
            Console.ReadKey();
        }

        static string OutputForACertainItem(string text, List<Vehicle> vehicles, List<MobilePhone> phones, List<Computer> computers)
        {
            foreach (var v in vehicles)
            {
                if (v.Description == text)
                    return (v.SerialNumber + " " + v.Description + " " + v.Seller);
            }
            foreach (var p in phones)
            {
                if (p.Description == text)
                    return (p.SerialNumber + " " + p.Description + " " + p.Seller);
            }
            foreach (var c in computers)
            {
                if (c.Description == text)
                    return (c.SerialNumber + " " + c.Description + " " + c.Seller);
            }
            return "The id does not exist";
        }

        static List<Vehicle> PreliminaryInputVehicles()
        {
            var listOfVehicles = new List<Vehicle>();
            var tempVehicle = new Vehicle(Guid.NewGuid(), "Good", new DateTime(2011, 11, 1).Date, 24, 10000.0, Vehicle.VehicleCompanies.Toyota, new DateTime(2018, 12, 26).Date, 1000.0);
            listOfVehicles.Add(tempVehicle);
            tempVehicle = new Vehicle(Guid.NewGuid(), "A firetruck", new DateTime(2010, 10, 2).Date, 12, 21000, Vehicle.VehicleCompanies.Honda, new DateTime(2021, 10, 2).Date, 100000.5);
            listOfVehicles.Add(tempVehicle);
            tempVehicle = new Vehicle(Guid.NewGuid(), "A lamborgini ( boss's car)", new DateTime(2018, 12, 25).Date, 36, 30000, Vehicle.VehicleCompanies.Ford, new DateTime(2018, 12, 26).Date, 50535.3);
            listOfVehicles.Add(tempVehicle);
            tempVehicle = new Vehicle(Guid.NewGuid(), "Run down", new DateTime(2000, 2, 2).Date, 48, 15000, Vehicle.VehicleCompanies.Honda, new DateTime(2022, 5, 1).Date, 40000.53);
            listOfVehicles.Add(tempVehicle);
            return listOfVehicles;
        }

        static List<MobilePhone> PreliminaryInputPhones()
        {
            var listOfPhones = new List<MobilePhone>();
            var tempPhone = new MobilePhone(Guid.NewGuid(), "Old", new DateTime(2011, 11, 1).Date, 0, 1000, MobilePhone.PhoneCompanies.Apple, true, "099434553", "Someone");
            listOfPhones.Add(tempPhone);
            tempPhone = new MobilePhone(Guid.NewGuid(), "A iphone X ( boss's phone)", new DateTime(2010, 10, 2).Date, 0, 1000, MobilePhone.PhoneCompanies.Samsung, true, "091324532", "Spiderman");
            listOfPhones.Add(tempPhone);
            tempPhone = new MobilePhone(Guid.NewGuid(), "Barely working", new DateTime(2014, 5, 1).Date, 0, 800, MobilePhone.PhoneCompanies.Sony, false, "099856432", "Jameson");
            listOfPhones.Add(tempPhone);
            tempPhone = new MobilePhone(Guid.NewGuid(), "Bad touchscreen", new DateTime(2000, 2, 2).Date, 0, 400, MobilePhone.PhoneCompanies.Samsung, false, "097421234", "BATMAN");
            listOfPhones.Add(tempPhone);
            return listOfPhones;
        }

        static List<Computer> PreliminaryInputComputers()
        {
            var listOfComputers = new List<Computer>();
            var tempComputer = new Computer(Guid.NewGuid(), "Gaming computer", new DateTime(2015, 11, 9).Date, 24, 1000, Computer.ComputerCompanies.Apple, true, Computer.OS.Linux, false);
            listOfComputers.Add(tempComputer);
            tempComputer = new Computer(Guid.NewGuid(), "New", new DateTime(2016, 10, 8).Date, 24, 800, Computer.ComputerCompanies.Dell, false, Computer.OS.Windows, true);
            listOfComputers.Add(tempComputer);
            tempComputer = new Computer(Guid.NewGuid(), "For writing code", new DateTime(2014, 4, 5).Date, 32, 200, Computer.ComputerCompanies.Apple, true, Computer.OS.Windows, false);
            listOfComputers.Add(tempComputer);
            tempComputer = new Computer(Guid.NewGuid(), "A mac ( boss's laptop)", new DateTime(2017, 2, 5).Date, 12, 1000, Computer.ComputerCompanies.Acer, false, Computer.OS.iOS, true);
            listOfComputers.Add(tempComputer);
            return listOfComputers;
        }
    }
}
