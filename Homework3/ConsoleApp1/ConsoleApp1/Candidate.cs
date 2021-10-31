using System;

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
    }
}
