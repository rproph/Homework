using System;

namespace ConsoleApp2
{
    class ClassA : ClassC
    {
        public override void DisplayC()
        {
            Console.WriteLine("This method was inherited from abstract class ClassC");
        }
        public int numberA = 10;
        public void Display()
        {
            Console.WriteLine("ClassA display");
        }
    }

    class ClassB : ClassA
    {
        public void Display()
        {
            base.Display();
        }
    }

    abstract class ClassC
    {
        public abstract void DisplayC();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var overload = new Overload();
            string line = "some line";
            overload.Display(ref line);

            ClassA a = new ClassB();
        }
    }
}
