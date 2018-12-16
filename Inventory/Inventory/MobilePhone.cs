using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    class MobilePhone : TechGear
    {
        //Iako je broj pretpostavljamo da moze poceti sa nulom
        public string PhoneNumber { get; set; }
        public string Owner { get; set; }
        public PhoneCompanies Seller { get; set; }

        public MobilePhone(Guid serialNumber, string description, DateTime dateOfAcquiring, int warranty, double price, PhoneCompanies seller, bool battery, string phoneNumber, string owner)
            : base(serialNumber, description, dateOfAcquiring, warranty, price, battery)
        {
            PhoneNumber = phoneNumber;
            Owner = owner;
        }

        public enum PhoneCompanies
        {
            Samsung = 1,
            Sony = 2,
            Xiaomi = 3,
            Apple = 4
        }

        public MobilePhone AddMobilePhone()
        {
            var success = false;
            var description = "";
            var warranty = 0;
            var price = 0.0;
            var seller = PhoneCompanies.Apple;
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
                var input = Console.ReadLine();
                foreach (var v in values)
                {
                    if (input.ToLower() == v.ToString().ToLower())
                    {
                        success = true;
                        seller = (PhoneCompanies) v;
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

        public void RemovingPhone(string text, List<MobilePhone> phones)
        {
            phones.RemoveAll(s => s.Description == text);
        }

        public void OutputMobilePhones(List<MobilePhone> phones)
        {
            var counter = 1;
            foreach (var v in phones)
            {
                Console.WriteLine("{0}. phone:", counter);
                counter++;
                Console.WriteLine(v.SerialNumber + " " + v.Description + " " + v.DateOfAcquiring.ToString("d/M/yyyy") + " " + v.Warranty);
                Console.WriteLine(v.Seller + " " + v.Price + " " + v.Battery + " " + v.PhoneNumber + " " + v.Owner);
            }
        }

        public List<MobilePhone> PhonesOfACertainBrand(string brand, List<MobilePhone> phones)
        {
            var thePhonesYouAreLoookingFor = new List<MobilePhone>();
            foreach (var p in phones)
            {
                if (p.Seller.ToString().ToLower() == brand)
                    thePhonesYouAreLoookingFor.Add(p);
            }

            return thePhonesYouAreLoookingFor;
        }

        public List<MobilePhone> PhonesWithCertainWarranty(int number, List<MobilePhone> allPhones)
        {
            var phones = new List<MobilePhone>();

            foreach (var c in allPhones)
            {
                var year = c.DateOfAcquiring.Year;
                var months = c.DateOfAcquiring.Month + c.Warranty;
                year += months / 12;
                if (year == number)
                    phones.Add(c);
            }

            return phones;
        }
    }
}
