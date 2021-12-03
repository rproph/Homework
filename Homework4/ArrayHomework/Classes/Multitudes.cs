using System.Collections.Generic;

namespace ConsoleApp1
{
    public static class Multitudes
    {
        public static int[] CreateIntersectionOfMultitudes(int[] arr1, int[] arr2)
        {
            List<int> finalResult = new List<int>();

            foreach(int value1 in arr1)
            {
                foreach(int value2 in arr2)
                {
                    if(value1 == value2)
                    {
                        finalResult.Add(value1);
                    }
                }
            }

            finalResult.Sort();

            for(int i = 0; i < finalResult.Count - 1; i++)
            {
                if(finalResult[i] == finalResult[i + 1])
                {
                    finalResult.RemoveAt(i + 1);
                }
            }

            return finalResult.ToArray();
        }
    }
}
