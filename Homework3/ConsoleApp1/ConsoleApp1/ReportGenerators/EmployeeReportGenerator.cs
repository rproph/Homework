using System;

namespace ConsoleApp1
{
    public class EmployeeReportGenerator : IReportGenerator
    {
        private static void SortedDisplay(Employee[] emps)
        {
            int maxStrLength = 0;
            int maxComNameLength = 0;
            String[] fullNames = new string[emps.Length];
            String[] compNames = new string[emps.Length];

            for (int i = 0; i < emps.Length; i++)
            {
                fullNames[i] = emps[i].FullName;
                compNames[i] = emps[i].Company.Name;

                if (emps[i].FullName.Length > maxStrLength)
                {
                    maxStrLength = emps[i].FullName.Length;
                }

                if (emps[i].Company.Name.Length > maxComNameLength)
                {
                    maxComNameLength = emps[i].Company.Name.Length;
                }
            }

            for (int i = 0; i < fullNames.Length; i++)
            {
                while (true)
                {
                    if (fullNames[i].Length < maxStrLength)
                    {
                        fullNames[i] += " ";
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = 0; i < compNames.Length; i++)
            {
                while (true)
                {
                    if (compNames[i].Length < maxComNameLength)
                    {
                        compNames[i] += " ";
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine($"{emps[i].Id} | {compNames[i]} | {fullNames[i]} | {emps[i].JobSalary}.0$");
            }
        }

        public Employee[] CompareBySalary(Employee[] emps)
        {
            double[] newEmpArr = new double[emps.Length];
            double switcher;
            Employee empSwitcher = new Employee();

            for (int i = 0; i < newEmpArr.Length; i++)
            {
                newEmpArr[i] = emps[i].JobSalary;
            }

            for (int i = 0; i < newEmpArr.Length - 1; i++)
            {
                for (int j = i + 1; j < newEmpArr.Length; j++)
                {
                    if (newEmpArr[i] <= newEmpArr[j])
                    {
                        switcher = newEmpArr[i];
                        empSwitcher = emps[i];
                        newEmpArr[i] = newEmpArr[j];
                        emps[i] = emps[j];
                        newEmpArr[j] = switcher;
                        emps[j] = empSwitcher;
                    }
                }
            }

            return emps;
        }

        public Employee[] CompareByName(Employee[] emps)
        {
            string[] compNames = new string[emps.Length];
            Employee switchEmps = new Employee();

            for (int i = 0; i < emps.Length; i++)
            {
                compNames[i] = emps[i].Company.Name;
            }
            Array.Sort(compNames);

            for (int i = 0; i < emps.Length; i++)
            {
                for (int j = 0; j < emps.Length; j++)
                {
                    if (emps[i].Company.Name.Equals(compNames[j]))
                    {
                        switchEmps = emps[j];
                        emps[j] = emps[i];
                        emps[i] = switchEmps;
                    }
                }
            }

            return emps;
        }
    }
}
