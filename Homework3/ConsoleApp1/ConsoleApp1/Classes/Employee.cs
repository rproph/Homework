using System;
using Bogus;

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

        public Employee CreateRandomEmployee()
        {
            Employee randomEmployee = new Employee();

            var generator = new Faker<Employee>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.JobDescription, f => f.Name.JobDescriptor())
                .RuleFor(x => x.JobTitle, f => f.Name.JobTitle())
                .RuleFor(x => x.JobSalary, f => f.Random.Int(400, 1000))
                .RuleFor(x => x.Company, f => null);

            var companyGenerator = new Faker<Company>()
                .StrictMode(true)
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Country, f => f.Address.Country())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.Address, f => f.Address.StreetAddress());

            randomEmployee = generator.Generate();
            randomEmployee.Company = companyGenerator.Generate();

            return randomEmployee;
        }
    }
}
