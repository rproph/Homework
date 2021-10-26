using System;

namespace ConsoleApp1
{
    public class Candidate : User, IDisplayable
    {
        public DisReasons? DismissalReason;

        public Candidate()
        {
        }

        public Candidate(string firstname, string lastname, string jobtitle, string jobdescription, double jobsalary, DisReasons? dismissalReason = null)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            JobTitle = jobtitle;
            JobDescription = jobdescription;
            JobSalary = jobsalary;
            DismissalReason = dismissalReason;
        }

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
    }
}
