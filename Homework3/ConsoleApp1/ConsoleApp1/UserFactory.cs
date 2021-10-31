using System;

namespace ConsoleApp1
{
    public abstract class UserFactory
    {
        abstract public User Create();
    }

    public class CandidateCreator : UserFactory
    {
        public override User Create()
        {
            return new Candidate().CreateRndCand();
        }
    }

    public class EmployeeCreator : UserFactory
    {
        public override User Create()
        {
            return new Employee().CreateRndEmp();
        }
    }

}
