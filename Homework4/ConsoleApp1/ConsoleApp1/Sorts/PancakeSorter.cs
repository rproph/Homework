using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class PancakeSorter<T> : ISorter<T>
    {
        private static void Flip<T>(T[] array, int end)
        {
            for (var start = 0; start < end; start++, end--)
            {
                var temp = array[start];
                array[start] = array[end];
                array[end] = temp;
            }
        }

        public int[] SortIntValues(List<int> list)
        {
            int[] result = list.ToArray();

            for (var i = result.Length - 1; i >= 0; i--)
            {
                int min = 0;
                for (int j = 1; j <= i; ++j)
                {
                    if (result[j] > result[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Flip(result, min);
                    Flip(result, i);
                }
            }

            return result;
        }

        public String[] SortStringValues(List<String> list)
        {
            string[] result = list.ToArray();

            for (var i = result.Length - 1; i >= 0; i--)
            {
                int min = 0;
                for (int j = 1; j <= i; ++j)
                {
                    if (result[j].Length < result[min].Length)
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Flip(result, min);
                    Flip(result, i);
                }
            }

            return result;
        }

    }
}
