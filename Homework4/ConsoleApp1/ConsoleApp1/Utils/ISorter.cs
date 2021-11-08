using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    public interface ISorter<T>
    {
        public int[] SortIntValues(List<int> list);

        public String[] SortStringValues(List<String> list);
    }
}
