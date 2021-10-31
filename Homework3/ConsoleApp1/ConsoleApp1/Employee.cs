using System;

namespace ConsoleApp1
{
    public class Company
    {
        public string Name;
        public string Country;
        public string City;
        public string Address;
    }

    public class Employee : User, IDisplayable
    {
        public Company Company;

        public void Display()
        {
            Console.WriteLine($"Hello, I am {FullName}, {JobTitle} in {Company.Name}\n({ Company.Country}, { Company.City}, { Company.Address}) and my\nsalary { JobSalary}.");
        }
    }
}
