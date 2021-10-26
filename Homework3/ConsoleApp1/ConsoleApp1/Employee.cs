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

        public Employee()
        {

        }

        public Employee(string firstname, string lastname, string jobtitle, string jobdescription, double jobsalary, string companyName, string companyCountry, string companyCity, string companyAddress)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            JobTitle = jobtitle;
            JobDescription = jobdescription;
            JobSalary = jobsalary;
            this.Company.Name = companyName;
            this.Company.Country = companyCountry;
            this.Company.City = companyCity;
            this.Company.Address = companyAddress;
        }

        public void Display()
        {
            Console.WriteLine($"Hello, I am {FullName}, {JobTitle} in {Company.Name}\n({ Company.Country}, { Company.City}, { Company.Address}) and my\nsalary { JobSalary}.");
        }
    }
}
