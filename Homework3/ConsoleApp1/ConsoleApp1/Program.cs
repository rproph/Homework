using System;
using Bogus;
using Bogus.DataSets;

namespace ConsoleApp1
{
    public enum DisReasons
    {
        FamilyReasons,
        ProfessionalGrowthLack,
        LowSalary,
        BadTeamMicroclimate,
        LackManagementUnderstanding,
        Other
    }

    public class Program
    {
        static string[,] JobTitles = { { "Programmer", "Tester", "HR" }, { "Coding specialisation", "Testing specialisation", "Recruiting and training students " } };

        static void Main(string[] args)
        {
            EmployeeReportGenerator erg = new EmployeeReportGenerator();

            Employee[] emps = RandomEmpCount();

            erg.CompareByName(emps);
        }

        static DisReasons? RndDisReason()
        {
            Random rndValue = new Random();

            int value = rndValue.Next(-1, 7);

            if (value == -1)
            {
                return null;
            }
            else
            {
                return (DisReasons)value;
            }
        }

        static Candidate[] RandomCandCount()
        {


            Random rnd = new Random();

            int rndJobtitle;
            int rndArrSize = rnd.Next(1, 11);

            Candidate[] rndCandidates = new Candidate[rndArrSize];

            for (int i = 0; i < rndArrSize; i++)
            {
                rndJobtitle = rnd.Next(0, 3);

                var generator = new Faker<Candidate>()
                    .StrictMode(true)
                    .RuleFor(x => x.Id, f => Guid.NewGuid())
                    .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                    .RuleFor(x => x.LastName, f => f.Name.LastName())
                    .RuleFor(x => x.JobDescription, f => JobTitles[1, rndJobtitle])
                    .RuleFor(x => x.JobTitle, f => JobTitles[0, rndJobtitle])
                    .RuleFor(x => x.JobSalary, f => f.Random.Int(100, 300))
                    .RuleFor(x => x.DismissalReason, f => RndDisReason());

                rndCandidates[i] = generator.Generate();
            }

            return rndCandidates;

        }

        static Employee[] RandomEmpCount()
        {
            Random rnd = new Random();

            int rndJobtitle;
            int rndArrSize = rnd.Next(1, 11);

            Employee[] rndEmployee = new Employee[rndArrSize];

            for (int i = 0; i < rndArrSize; i++)
            {
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

                rndEmployee[i] = generator.Generate();
                rndEmployee[i].Company = companyGenerator.Generate();
            }

            return rndEmployee; 
        }
    }
}
