using System.Collections.Generic;

namespace ConsoleApp1
{
    public class QueueOperation
    {
        public int FindMinMaxGap(Queue<int> queue)
        {
            int[] arr = new int[queue.Count];
            int maxValue = queue.Peek();
            int maxIndex = 0;
            int minValue = queue.Peek();
            int minIndex = 0;
            int summ = 0;

            queue.CopyTo(arr, 0);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxIndex = i;
                    maxValue = arr[i];
                }
                else if (arr[i] < minValue)
                {
                    minIndex = i;
                    minValue = arr[i];
                }
            }

            if (maxValue == minValue)
            {
                return maxValue;
            }
            else
            {
                if (maxIndex > minIndex)
                {
                    for (int i = minIndex; i <= maxIndex; i++)
                    {
                        summ += arr[i];
                    }
                }
                else if (minIndex > maxIndex)
                {
                    for (int i = maxIndex; i <= minIndex; i++)
                    {
                        summ += arr[i];
                    }
                }

                return summ;
            }
        }
    }
}
