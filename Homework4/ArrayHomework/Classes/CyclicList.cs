using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public static class CyclicList
    {
        public static void DoSifting(List<int> list)
        {
            List<int> finalList = new List<int>(list);
            int index = 1;

            for (int i = 0; i < finalList.Count; i++)
            {
                if (index % 2 == 0)
                {
                    finalList.RemoveAt(i);
                    i--;

                    foreach (int value in finalList)
                    {
                        Console.Write($"{value} ");
                    }

                    Console.WriteLine("\n");
                }

                index++;

                if (i == finalList.Count - 1)
                {
                    i = -1;

                }

                if (finalList.Count == 1)
                {
                    break;
                }
            }

            Console.WriteLine(finalList[0]);
        }
    }
}
