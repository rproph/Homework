using System;


namespace ConsoleApp1
{
    abstract public class User
    {
        public Guid Id;
        public string FirstName;
        public string LastName;
        public string JobTitle;
        public string JobDescription;
        public double JobSalary;

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

    }

}


