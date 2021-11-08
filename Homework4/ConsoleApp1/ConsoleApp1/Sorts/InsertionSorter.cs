using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class InsertionSorter<T> : ISorter<T>
    {
        public int[] SortIntValues(List<int> list)
        {
            int switcher = 0;
            int[] result = list.ToArray();

            for (int i = 1; i < result.Length; i++)
            {
                while (i > 0 && result[i] > result[i - 1])
                {
                    switcher = result[i];
                    result[i] = result[i - 1];
                    result[i - 1] = switcher;
                    i--;
                }
            }

            return result;
        }

        public string[] SortStringValues(List<String> list)
        {
            String switcher;
            String[] result = list.ToArray();

            for (int i = 1; i < result.Length; i++)
            {
                while (i > 0 && result[i].Length > result[i - 1].Length)
                {
                    switcher = result[i];
                    result[i] = result[i - 1];
                    result[i - 1] = switcher;
                    i--;
                }
            }

            return result;
        }
    }
}
