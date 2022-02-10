using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Homework10
{
    public class MathOperations
    {
        public int a = 2;
        public int b = 3;

        public int DoSolve()
        {
            return a + b;
        }

        public bool FindTruth()
        {
            return a == b;
        }
    }

    [TestFixture]
    public class Tests
    {
        MathOperations math;
        MathOperations math1;

        IList<MathOperations> list;

        [SetUp]
        public void Setup()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            math = new MathOperations();
            math1 = new MathOperations();
            list = new List<MathOperations>(){math, math1};
        }

        [Test]
        public void Test1()
        {
            Assert.Pass("Test passed");
        }

        [Test, Order(1)]
        public void Test2()
        {
            Assert.Fail("Test failed");
        }

        [Test, Order(3)]
        public void Test3()
        {
            int number = math.DoSolve();

            Assert.AreEqual(4, number);
        }

        [Test, Order(2)]
        public void Test4()
        {
            Assert.AreSame(math, math1);
        }

        [Test]
        [Category("Some test")]
        public void Test5()
        {
            Assert.AreNotSame(math, math1);
        }

        [TearDown]
        public void TearDownTesting()
        {
            Console.WriteLine("TearDown");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            math = null;
            math1 = null;
        }

        [Test]
        [Ignore("Testing ignore attribute")]
        [Category("Ignored tests")]
        public void Test6()
        {
            Assert.GreaterOrEqual(math.a, math.b);
        }

        [Test]
        public void Test7()
        {
            Assert.IsTrue(math.FindTruth());
        }

        [Test]
        [Category("Ignored tests")]
        public void Test8()
        {
            Assert.Ignore();
        }

        [Test]
        [Category("Inconclusive tests")]
        public void Test9()
        {
            Assert.Inconclusive(); ;
        }

        [Test]
        public void Test10()
        {
            Assert.Contains(math, (System.Collections.ICollection)list);
        }
    }
}
