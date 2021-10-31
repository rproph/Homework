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

        public Employee CreateRndEmp()
        {
            string[,] JobTitles = { { "Programmer", "Tester", "HR" }, { "Coding specialisation", "Testing specialisation", "Recruiting and training students " } };
            Random rnd = new Random();
            Employee rndEmployee = new Employee();
            int rndJobtitle;

            rndJobtitle = rnd.Next(0, 3);

            var generator = new Faker<Employee>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.JobDescription, f => JobTitles[1, rndJobtitle])
                .RuleFor(x => x.JobTitle, f => JobTitles[0, rndJobtitle])
                .RuleFor(x => x.JobSalary, f => f.Random.Int(400, 1000))
                .RuleFor(x => x.Company, f => null);

            var companyGenerator = new Faker<Company>()
                .StrictMode(true)
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Country, f => f.Address.Country())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.Address, f => f.Address.StreetAddress());

            rndEmployee = generator.Generate();
            rndEmployee.Company = companyGenerator.Generate();

            return rndEmployee;
        }

        public Employee[] RandomEmpCount()
        {
            Random rnd = new Random();
            int rndArrSize = rnd.Next(1, 11);
            Employee[] rndEmployee = new Employee[rndArrSize];

            for (int i = 0; i < rndArrSize; i++)
            {
                rndEmployee[i] = CreateRndEmp();
            }

            return rndEmployee;
        }
    }
}
