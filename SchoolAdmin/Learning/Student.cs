using System;
namespace SchoolAdmin.Learning
{
    public class Student
    {
        private readonly int _regNumber;
        private readonly string _fullName;
        private string _level;


        public Student(int regNumber, string fullName)
        {
            _regNumber = regNumber;
            _fullName = fullName;
        }


        public int RegNumber
        {
            get => _regNumber;
        }


        public string Name
        {
            get => _fullName;
        }


        public string Level
        {
            get
            {
                return _level;
            }

            set {
                _level = value;
            }
        }


        public void Learn()
        {
            // Additional instructions can go here
            Console.WriteLine("I am learning something interesting now.");
        }

    }
}
