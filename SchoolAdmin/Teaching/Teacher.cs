using System;
namespace SchoolAdmin.Teaching
{
    public class Teacher
    {

        private readonly int _staffId;
        private readonly string _fullName;
        private string _subject;
        private string[] _learners;


        public Teacher(int staffId, string fullName)
        {
            _staffId = staffId;
            _fullName = fullName;
        }


        public int StaffId
        {
            get => _staffId;   
        }


        public string Name
        {
            get => _fullName;
        }


        public string Subject
        {
            // This get accessor uses the explicit syntax, rather than the short form

            get {
                return _subject;
            }


            set {
                _subject = value;
            } 
        }


        public string[] Learners
        {
            get
            {
                return _learners;
            }

            set {
                _learners = value;
            }
        }


        public void Teach()
        {
            // Additional instructions can go here
            Console.WriteLine("I am teaching a class now.");
        }
    }
}
