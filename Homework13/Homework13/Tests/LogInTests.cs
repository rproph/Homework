using NUnit.Framework;
using Homework13.BaseEntities;
using Homework13.Pages;
using Homework13.Steps;

namespace Homework13
{
    [Parallelizable(ParallelScope.All)]
    public class LogInTests : BaseTest
    {
        [Test]
        public void LogInTest()
        {
        }

        [Test]
        public void LogInTest1()
        {
            LogInSteps steps = new LogInSteps(Driver);
            steps.LogIn();
        }
    }
}
