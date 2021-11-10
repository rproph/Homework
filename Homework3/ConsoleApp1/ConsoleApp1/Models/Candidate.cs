using System;
using Bogus;

namespace ConsoleApp1
{

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

        public static DismissalReasons? RandomDismissalReason()
        {
            Random randomValue = new Random();

            int value = randomValue.Next(-1, 7);

            if (value == -1)
            {
                return null;
            }
            else
            {
                return (DismissalReasons)value;
            }
        }

        public Candidate CreateRandomCandidate()
        {
            return new Faker<Candidate>()
                    .StrictMode(true)
                    .RuleFor(x => x.Id, f => Guid.NewGuid())
                    .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                    .RuleFor(x => x.LastName, f => f.Name.LastName())
                    .RuleFor(x => x.JobDescription, f => f.Name.JobDescriptor())
                    .RuleFor(x => x.JobTitle, f => f.Name.JobTitle())
                    .RuleFor(x => x.JobSalary, f => f.Random.Int(100, 300))
                    .RuleFor(x => x.DismissalReason, f => RandomDismissalReason()).Generate();
        }
    }
}
