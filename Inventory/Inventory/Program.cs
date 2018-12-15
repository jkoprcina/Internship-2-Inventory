using System;
using System.Collections.Generic;
namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>();
            var phones = new List<MobilePhone>();
            var computers = new List<Computer>();
            var choice = "";

            vehicles = PreliminaryInputVehicles();
            phones = PreliminaryInputPhones();
            computers = PreliminaryInputComputers();
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
                                var veh = AddingAVehicle();
                                vehicles.Add(veh);
                            }
                            else if (word.ToLower() == "computer")
                            {
                                var comp = AddingAComputer();
                                computers.Add(comp);
                            }
                            else if (word.ToLower() == "phone")
                            {
                                var pho = AddingAPhone();
                                phones.Add(pho);
                            }
                        } while (word.ToLower() != "vehicle" && word.ToLower() != "computer" && word.ToLower() != "phone");
                        break;
                    case "1":
                        Console.WriteLine("Please enter the description of the item you'd like to see");
                        try
                        {
                            var specificItem = Console.ReadLine();
                            Console.WriteLine(OutputForACertainItem(specificItem, vehicles, phones, computers));
                        }
                        catch
                        {
                            Console.WriteLine("The input was a bad format");
                        }
                        
                        break;
                    case "2":
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
                    case "3":
                        var numberOfBatteries = NumberOfTechGearWithBattery(phones, computers);
                        Console.WriteLine("The number of batteries in use is {0}", numberOfBatteries);
                        break;
                    case "4":
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
                            Console.WriteLine("Wrong input, try again");
                            break;
                        }
                        break;
                    case "5":
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
                    case "6":
                        var locatedVehicles = VehiclesWithCertainWarranty(vehicles);
                        foreach (Vehicle v in locatedVehicles)
                            Console.WriteLine(v.Description + " " + v.WarrantyExpirationDate + " " + v.Mileage);
                        if (locatedVehicles == null)
                            Console.WriteLine("There are none that expire next month");
                        break;
                    case "7":
                        Console.WriteLine("All the pricing information");
                        var vehiclePrices = VehiclePrices(vehicles);
                        var techGear = TechGearPrices(phones, computers);
                        Console.WriteLine(vehiclePrices);
                        Console.WriteLine(techGear);
                        break;
                    case "8":
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
                            Console.WriteLine("Wrong input, try again");
                            break;
                        }
                        break;
                    case "9":
                        do
                        {
                            var checking = false;
                            Console.WriteLine("Would you like to remove a vehicle, computer or phone");
                            word = Console.ReadLine();
                            var text = "";
                            text = Console.ReadLine();
                            if (word.ToLower() == "vehicle")
                            {
                                OutputVehicles(vehicles);
                                Console.WriteLine("Enter the description of the item you wanna remove");
                                text = Console.ReadLine();
                                foreach (Vehicle v in vehicles)
                                {
                                    if (v.Description == text)
                                        checking = true;
                                }
                                if (checking == true)
                                {
                                    RemovingAVehicle(text, vehicles);
                                }
                                else
                                    Console.WriteLine("That vehicle doesn't exist");
                            }
                            else if (word.ToLower() == "computer")
                            {
                                OutputComputers(computers);
                                Console.WriteLine("Enter the description of the item you wanna remove");
                                text = Console.ReadLine();
                                foreach (Computer c in computers)
                                {
                                    if (c.Description == text)
                                        checking = true;
                                }
                                if (checking == true)
                                    {
                                    RemovingAComputer(text, computers);
                                }
                                else
                                    Console.WriteLine("That computer doesn't exist");
                            }
                            else if (word.ToLower() == "phone")
                            {
                                OutputMobilePhones(phones);
                                Console.WriteLine("Enter the description of the item you wanna remove");
                                text = Console.ReadLine();
                                foreach (MobilePhone m in phones)
                                {
                                    if (m.Description == text)
                                        checking = true;
                                }
                                if (checking == true)
                                {
                                    RemovingAPhone(text, phones);
                                }
                                else
                                    Console.WriteLine("That phone doesn't exist");
                            }
                        } while (word.ToLower() != "vehicle" && word.ToLower() != "computer" && word.ToLower() != "phone");
                        break;
                    case "10":
                        OutputVehicles(vehicles);
                        OutputComputers(computers);
                        OutputMobilePhones(phones);
                        break;
                }
                choice = choice.ToLower();
            } while (choice != "ok");
            Console.WriteLine("Have a nice day!");
            Console.ReadKey();
        }

        //Methods for the main menu

        //Adding Methods 00000
        //Adding a new vehicle 
        static Vehicle AddingAVehicle()
        {
            var success = false;
            var description = "";
            var warranty = 0;
            var price = 0.0;
            var seller = "";
            var mileage = 0.0;

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
            do {
                success = false;
                Console.WriteLine("Enter a seller out of the listed");
                var values = Enum.GetValues(typeof(VehicleCompanies));
                foreach (var v in values)
                {
                    Console.WriteLine(v);
                }
                seller = Console.ReadLine();
                foreach (var v in values)
                {
                    if (seller.ToLower() == v.ToString().ToLower())
                        success = true;
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
            var time = new DateTime(year, month, day);

            var temp = month + warranty;
            var tempYear = temp / 12;
            var tempMonth = temp % 12;

            var timeExp = new DateTime(tempYear, tempMonth, day);

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
        //Adding a new computer
        static Computer AddingAComputer()
        {
            var success = false;
            var description = "";
            var warranty = 0;
            var price = 0.0;
            var seller = "";
            var portable = false;
            var battery = false;
            var operatingSystem = "";

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
                seller = Console.ReadLine();
                foreach (var v in values)
                {
                    if (seller.ToLower() == v.ToString().ToLower())
                        success = true;
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
            var time = new DateTime(year, month, day);

            do {
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
                operatingSystem = Console.ReadLine();
                foreach (var v in values)
                {
                    if (operatingSystem.ToLower() == v.ToString().ToLower())
                        success = true;
                }
            } while (!success);

            var comp = new Computer(Guid.NewGuid(), description, time, warranty, price, seller, battery, operatingSystem, portable);
            return comp;
        }
        //Adding a new phone
        static MobilePhone AddingAPhone()
        {
            var success = false;
            var description = "";
            var warranty = 0;
            var price = 0.0;
            var seller = "";
            var phoneNumber = "";
            var owner = "";

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
                var values = Enum.GetValues(typeof(PhoneCompanies));
                foreach (var v in values)
                {
                    Console.WriteLine(v);
                }
                seller = Console.ReadLine();
                foreach (var v in values)
                {
                    if (seller.ToLower() == v.ToString().ToLower())
                        success = true;
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
            } while (!success || month < 1  || month > 12);
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
            var time = new DateTime(year, month, day);

            bool battery;
            do
            {
                Console.WriteLine("Write 'true' if you computer has a battery or 'false' if it doesn't");
                var text = Console.ReadLine();
                success = bool.TryParse(text, out battery);
            } while (!success);

            Console.WriteLine("Enter your phone number");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Write the owners first and last name at once");
            owner = Console.ReadLine();

            var phon = new MobilePhone(Guid.NewGuid(), description, time, warranty, price, seller, battery, phoneNumber, owner);
            return phon;
        }
        //Method to show the user a certain item he requested through the input of it's serial number  11111
        static string OutputForACertainItem(string text, List<Vehicle> vehicles, List<MobilePhone> phones, List<Computer> computers)
        {
            foreach (Vehicle v in vehicles)
            {
                if (v.Description == text)
                    return (v.SerialNumber + " " + v.Description + " " + v.Seller);
            }
            foreach (MobilePhone p in phones)
            {
                if (p.Description == text)
                    return (p.SerialNumber + " " + p.Description + " " + p.Seller);
            }
            foreach (Computer c in computers)
            {
                if (c.Description == text)
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

        // prints out all the vehicles that have warranties which expire in a month or less     66666
        static List<Vehicle> VehiclesWithCertainWarranty(List<Vehicle> allVehicles)
        {
            var vehicles = new List<Vehicle>();

            foreach (Vehicle c in allVehicles)
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

        //calculates all types of prices for vehicles 77777A
        static string VehiclePrices(List<Vehicle> vehicles)
        {
            var prices = "";
            foreach (Vehicle v in vehicles)
            { 
                prices += v.Description + "\t" + v.Price + "\t";
                var calc = v.Mileage / 20000;
                int number = (int)calc;
                var newPrice = 0.0;
                if (v.Price * (calc / 10) > (v.Price * 0.2))
                {
                    newPrice = v.Price - (v.Price * (calc / 10));
                    prices += newPrice + "\t" + (v.Price - newPrice) +"\n";
                }
                else
                {
                    newPrice = v.Price * 0.2;
                    prices += newPrice + "\t" + (v.Price - newPrice) + "\n";
                }
            }
            return prices;
        }

        //calculates all types of prices for techgear      77777B
        static string TechGearPrices(List<MobilePhone> phones, List<Computer> computers)
        {
            var prices = "";

            foreach (MobilePhone v in phones)
            {
                prices += v.Description + "\t" + v.Price + "\t";
                var current = new DateTime();
                var currentYear = current.Year;
                var currentMonth = current.Month;
                var currentDay = current.Day;

                var yearDifference = currentYear - v.DateOfAquiring.Year;
                var monthDifference = currentMonth - v.DateOfAquiring.Month;
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

            foreach (Computer v in computers)
            {
                prices += v.Description + "\t" + v.Price + "\t";
                var current = new DateTime();
                var currentYear = current.Year;
                var currentMonth = current.Month;
                var currentDay = current.Day;

                var yearDifference = currentYear - v.DateOfAquiring.Year;
                var monthDifference = currentMonth - v.DateOfAquiring.Month;
                monthDifference += yearDifference * 12;
                var percentage = (monthDifference * 5) / 100;

                if ((v.Price * (monthDifference * 5) / 100) > (0.3 * v.Price))
                    prices += v.Price * (monthDifference * 5) / 100 + "\t" + (v.Price * (monthDifference * 5) / 100) + "\n";
                else
                    prices += (0.3 * v.Price) + "\t" + (v.Price - 0.3 * v.Price) + "\n";

            }
            return prices;
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

        //Method for removing objects 
        //removing a vehicle
        static List<Vehicle> RemovingAVehicle(string text, List<Vehicle> vehicles)
        {
            vehicles.RemoveAll(s => s.Description == text);
            return vehicles;
        }
        //removing a computer
        static List<Computer> RemovingAComputer(string text, List<Computer> computers)
        {
            computers.RemoveAll(s => s.Description == text);
            return computers;
        }
        //removing a phone
        static List<MobilePhone> RemovingAPhone(string text, List<MobilePhone> phones)
        {
            phones.RemoveAll(s => s.Description == text);
            return phones;
        }

        static void OutputVehicles(List<Vehicle> vehicles)
        {
            var counter = 1;
            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine("{0}. vehicle:",counter);
                counter++;
                Console.WriteLine(v.SerialNumber + " " + v.Description + " " + v.DateOfAquiring + " " + v.Warranty);
                Console.WriteLine(v.Seller + " " + v.Price + " " + v.WarrantyExpirationDate + " " + v.Mileage);
            }
        }

        static void OutputComputers(List<Computer> computers)
        {
            var counter = 1;
            foreach(Computer v in computers)
            {
                Console.WriteLine("{0}. computer:", counter);
                counter++;
                Console.WriteLine(v.SerialNumber + " " + v.Description + " " + v.DateOfAquiring + " " + v.Warranty);
                Console.WriteLine(v.Seller + " " + v.Price + " " + v.Battery + " " + v.OperatingSystem + " " + v.Portable);
            }
        }

        static void OutputMobilePhones(List<MobilePhone> phones)
        {
            var counter = 1;
            foreach (MobilePhone v in phones)
            {
                Console.WriteLine("{0}. phone:", counter);
                counter++;
                Console.WriteLine(v.SerialNumber + " " + v.Description + " " + v.DateOfAquiring + " " + v.Warranty);
                Console.WriteLine(v.Seller + " " + v.Price + " " + v.Battery + " " + v.PhoneNumber + " " + v.Owner);
            }
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
                new DateTime(2018, 12, 25),
                new DateTime(2000, 2, 2)
            };
            var warrantyOfVehicles = new int[4] { 24, 12, 36, 48 };
            var priceOfVehicles = new double[4] { 10000, 21000, 30000, 15000 };
            var sellerOfVehicles = new string[4] { "Honda", "Toyota", "WolksVagen", "Ford" };
            var warrantyExpirationDateOfVehicles = new DateTime[4]
            {
                new DateTime(2018, 12, 26),
                new DateTime(2021, 10, 2),
                new DateTime(2022, 5, 1),
                new DateTime(2020, 2, 2)
            };
            var mileageOfVehicles = new double[4] { 100000.5, 50535.3, 40000.53, 311.3 };

            for (int i = 0; i < 4; i++)
            {
                var dummyVehicle = new Vehicle(Guid.NewGuid(), descriptionsOfVehicles[i], dateOfAquiringOfVehicles[i], warrantyOfVehicles[i], priceOfVehicles[i], sellerOfVehicles[i], warrantyExpirationDateOfVehicles[i], mileageOfVehicles[i]);
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
                var dummyPhone = new MobilePhone(Guid.NewGuid(), descriptionsOfPhones[i], dateOfAquiringOfPhones[i], warrantyOfPhones[i], priceOfPhones[i], "apple", batteryOfPhones[i], phoneNumberOfPhones[i], ownerOfPhones[i]);
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
                var dummyComputer = new Computer(Guid.NewGuid(), descriptionsOfComputers[i], dateOfAquiringOfComputers[i], warrantyOfComputers[i], priceOfComputers[i], sellerOfComputers[i], batteryOfComputers[i], operatingSystemOfComputers[i], portableOfComputers[i]);
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

        public enum OS
        {
            Android = 1,
            Windows = 2,
            iOS = 3,
            Linux = 4
        }
    }
}
