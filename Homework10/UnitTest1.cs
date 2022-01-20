using NUnit.Framework;
using System;

namespace Homework10
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass("Test passed");
        }

        [Test]
        public void Test2()
        {
            Assert.Fail("Test failed");
        }

        [Test]
        public void Test3()
        {
            MathOperations mathOp = new MathOperations();

            int number = mathOp.DoSolve();

            Assert.AreEqual(4, number);
        }

        [Test]
        public void Test4()
        {
            MathOperations math1 = new MathOperations();
            MathOperations math2 = new MathOperations();

            Assert.AreSame(math1, math1);
        }

        [Test]
        public void Test5()
        {
            MathOperations math1 = new MathOperations();
            MathOperations math2 = new MathOperations();

            Assert.AreNotSame(math1, math2);
        }

        [TearDown]
        public void RunMe() 
        {
            Console.WriteLine("TearDown");
        }

        [Test]
        public void Test6()
        {
            MathOperations math1 = new MathOperations();

            Assert.IsTrue(math1.FindTruth());
        }

        [Test]
        [Ignore("Testing ignore attribute")]
        public void Test7()
        {
            MathOperations math1 = new MathOperations();

            Assert.GreaterOrEqual(math1.a, math1.b);
        }
    }
}
