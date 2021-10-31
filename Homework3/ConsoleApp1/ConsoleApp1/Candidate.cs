using System;
using Bogus;

namespace ConsoleApp1
{
    public enum DismissalReasons
    {
        FamilyReasons,
        ProfessionalGrowthLack,
        LowSalary,
        BadTeamMicroclimate,
        LackManagementUnderstanding,
        Other
    }

    public class Candidate : User, IDisplayable
    {
        public DismissalReasons? DismissalReason;

        public void Display()
        {
            if (DismissalReason == null)
            {
                Console.WriteLine($"Hello, I am {FullName}.\nI want to be a { JobTitle} ({ JobDescription}) with a salary from \n{ JobSalary}.\nI haven't worked anywhere before.");
            }
            else
            {
                Console.WriteLine($"Hello, I am {FullName}. \nI want to be a { JobTitle} ({ JobDescription}) with a salary from \n{ JobSalary}. \nI quit my previous job for a reason of { DismissalReason}.");
            }
        }

        public static DismissalReasons? RndDismissalReason()
        {
            Random rndValue = new Random();

            int value = rndValue.Next(-1, 7);

            if (value == -1)
            {
                return null;
            }
            else
            {
                return (DismissalReasons)value;
            }
        }

        public Candidate CreateRndCand()
        {
            string[,] JobTitles = { { "Programmer", "Tester", "HR" }, { "Coding specialisation", "Testing specialisation", "Recruiting and training students " } };
            Random rnd = new Random();
            Candidate rndCandidate = new Candidate();
            int rndJobtitle;

            rndJobtitle = rnd.Next(0, 3);

            var generator = new Faker<Candidate>()
                    .StrictMode(true)
                    .RuleFor(x => x.Id, f => Guid.NewGuid())
                    .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                    .RuleFor(x => x.LastName, f => f.Name.LastName())
                    .RuleFor(x => x.JobDescription, f => JobTitles[1, rndJobtitle])
                    .RuleFor(x => x.JobTitle, f => JobTitles[0, rndJobtitle])
                    .RuleFor(x => x.JobSalary, f => f.Random.Int(100, 300))
                    .RuleFor(x => x.DismissalReason, f => RndDismissalReason());

            rndCandidate = generator.Generate();

            return rndCandidate;
        }

        public Candidate[] RandomCandCount()
        {
            Random rnd = new Random();
            int rndArrSize = rnd.Next(1, 11);

            Candidate[] rndCandidates = new Candidate[rndArrSize];

            for (int i = 0; i < rndArrSize; i++)
            {
                rndCandidates[i] = CreateRndCand();
            }

            return rndCandidates;
        }
    }
}
