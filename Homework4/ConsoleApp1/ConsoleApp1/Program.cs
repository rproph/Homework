using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
             //First task

             int[] arr1 = { 1, 2, 3, 4, 5, 3};
             int[] arr2 = { 1, 3, 5};
             int[] arr = Multitudes.CreateIntersectionOfMultitudes(arr1, arr2);

             foreach(int value in arr)
             {
                 Console.WriteLine(value);
             }
            
            //Second task

            Queue<int> queue = new Queue<int>(new int[]{ 1, 1, 1});

            QueueOperation qOperator = new QueueOperation();

            Console.WriteLine(qOperator.FindMinMaxGap(queue));
            
            //Third task

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7};

            CyclicList.DoSifting(list);

            // Fourth task

            List<int> fourthList = new List<int>() { 1, 2, 3, 6, 5, 4 };

            PancakeSorter<int> sorter = new PancakeSorter<int>();

            foreach (int value in sorter.SortIntValues(fourthList))
            {
                Console.WriteLine(value);
            }
        }
    }
}
