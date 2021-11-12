using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random randomValue = new Random();
            CandidateFactory candidateFactory = new CandidateFactory();
            CandidateReportGenerator candidateSorter = new CandidateReportGenerator();
            EmployeeFactory employeeFactory = new EmployeeFactory();
            EmployeeReportGenerator employeeSorter = new EmployeeReportGenerator();

            Candidate[] candidateGroup = candidateFactory.CreateGroupOfCandidates(randomValue.Next(1, 11));

            candidateSorter.CompareBySalary(candidateGroup);

            Console.WriteLine("\n");

            Employee[] employeeGroup = employeeFactory.CreateGroupOfEmployees(randomValue.Next(1, 11));

            employeeSorter.CompareBySalary(employeeGroup);
        }
    }
}