using System;

namespace ConsoleApp1
{
    public class CandidateReportGenerator : IReportGenerator
    {
        public static void SortedDisplay(Candidate[] cands)
        {
            int maxStrLength = 0;
            int maxJobTitleLength = 0;
            String[] fullNames = new string[cands.Length];
            String[] jobTitles = new string[cands.Length];

            for (int i = 0; i < cands.Length; i++)
            {
                fullNames[i] = cands[i].FullName;
                jobTitles[i] = cands[i].JobTitle;

                if (cands[i].FullName.Length > maxStrLength)
                {
                    maxStrLength = cands[i].FullName.Length;
                }

                if (cands[i].JobTitle.Length > maxJobTitleLength)
                {
                    maxJobTitleLength = cands[i].JobTitle.Length;
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

            for (int i = 0; i < jobTitles.Length; i++)
            {
                while (true)
                {
                    if (jobTitles[i].Length < maxJobTitleLength)
                    {
                        jobTitles[i] += " ";
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine($"{cands[i].Id} | {jobTitles[i]} | {fullNames[i]} | {cands[i].JobSalary}.0$");
            }
        }

        public void CompareBySalary(Candidate[] cands)
        {
            double[] newCandArr = new double[cands.Length];
            double switcher;
            Candidate candSwitcher = new Candidate();

            for (int i = 0; i < newCandArr.Length; i++)
            {
                newCandArr[i] = cands[i].JobSalary;
            }

            for (int i = 0; i < newCandArr.Length - 1; i++)
            {
                for (int j = i + 1; j < newCandArr.Length; j++)
                {
                    if (newCandArr[i] >= newCandArr[j])
                    {
                        switcher = newCandArr[i];
                        candSwitcher = cands[i];
                        newCandArr[i] = newCandArr[j];
                        cands[i] = cands[j];
                        newCandArr[j] = switcher;
                        cands[j] = candSwitcher;
                    }
                }
            }

            SortedDisplay(cands);
        }

        public void CompareByJobTitle(Candidate[] cands)
        {
            string[] jobTitles = new string[cands.Length];
            Candidate switchCands = new Candidate();

            for (int i = 0; i < cands.Length; i++)
            {
                jobTitles[i] = cands[i].JobTitle;
            }
            Array.Sort(jobTitles);

            for (int i = 0; i < cands.Length; i++)
            {
                for (int j = 0; j < cands.Length; j++)
                {
                    if (cands[i].JobTitle.Equals(jobTitles[j]))
                    {
                        switchCands = cands[j];
                        cands[j] = cands[i];
                        cands[i] = switchCands;
                    }
                }
            }
            SortedDisplay(cands);
        }
    }
}
