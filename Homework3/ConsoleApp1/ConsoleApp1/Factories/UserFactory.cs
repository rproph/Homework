namespace ConsoleApp1
{
    public abstract class UserFactory
    {
        abstract public User Create();
    }

    public class CandidateFactory : UserFactory
    {
        public Candidate[] CreateGroupOfCandidates(int count)
        {
            Candidate[] randomCandidates = new Candidate[count];

            for (int i = 0; i < count; i++)
            {
                randomCandidates[i] = new Candidate().CreateRandomCandidate();
            }

            return randomCandidates;
        }

        public override User Create()
        {
            return new Candidate().CreateRandomCandidate();
        }
    }

    public class EmployeeFactory : UserFactory
    {
        public Employee[] CreateGroupOfEmployees(int count)
        {

            Employee[] randomEmployee = new Employee[count];

            for (int i = 0; i < count; i++)
            {
                randomEmployee[i] = new Employee().CreateRandomEmployee();
            }

            return randomEmployee;
        }

        public override User Create()
        {
            return new Employee().CreateRandomEmployee();
        }
    }
}
