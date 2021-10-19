using System;

namespace ConsoleApp2
{
    public class ClassA : ClassC
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

    public class ClassB : ClassA
    {

        public void Display()
        {
            base.Display();
        }

    }

    public abstract class ClassC
    {

        public abstract void DisplayC();

    }

    public class Program
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
