using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool boolValue = true;
            byte byteVal = 100;
            sbyte sByteVal = -100;
            short shortVal = 32000;
            ushort ushortVal = 60000;
            int intVal = -80000;
            uint uintVal = 80000;
            long longVal = -100000;
            ulong ulongVal = 100000;
            float floatVal = 100.0f;
            double doubleVal = 200.0d;
            decimal decimalVal = 300.0m;
            char charVal = 'a';
            string stringVal = " some string";
            object objectVal = null;
            
            if ((boolValue != false) || (sByteVal <= byteVal))
            {
                objectVal = (int) ((shortVal + ushortVal) / intVal * uintVal % (longVal - (long) ulongVal) +
                                   (decimal) (floatVal + doubleVal) / decimalVal);
            }


            Console.WriteLine(objectVal + stringVal + charVal);
        }
    }
}