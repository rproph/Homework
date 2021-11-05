using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3, 4, 5, 3};
            int[] arr2 = { 1, 3, 5};
            int[] arr = Multitudes.CreateIntersectionOfMultitudes(arr1, arr2);

            foreach(int value in arr)
            {
                Console.WriteLine(value);
            }
        }
    }
}
