using System;

namespace ConsoleApp2
{
    public class Overload
    {
        public void Display(int n)
        {
            Console.WriteLine($"Number is {n}");
        }

        public void Display(int n, int m)
        {
            Console.WriteLine($"Numbers are {n} and {m}");
        }

        public void Display(ref string line)
        {
            Console.WriteLine($"String is {line}");
        }

        public void Display(int n, params string[] lines)
        {
            Console.WriteLine($"Number is {n}");
            foreach (string line in lines)
            {
                Console.WriteLine($"Line {line} in lines");
            }
        }

    }
}
