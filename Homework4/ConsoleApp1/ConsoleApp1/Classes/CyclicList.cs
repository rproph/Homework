using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public static class CyclicList
    {
        public static void DoSifting(List<int> list)
        {
            List<int> finalList = new List<int>();
            List<int> indexList = new List<int>();

            while (list.Count != 1)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    if(i % 2 == 0)
                    {
                        finalList.Add(list[i]);
                    }
                }

                list = new List<int>(finalList);

                finalList.Clear();

                foreach (int value in list)
                {
                    Console.Write($"{value} ");
                }

                Console.WriteLine("\n");

                if (list.Count == 1)
                {
                    break;
                }
            }
        }
    }
}
