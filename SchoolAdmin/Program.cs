using SchoolAdmin.Learning;
using SchoolAdmin.Teaching;
using System;

namespace SchoolAdmin
{
    class Program
    {
        static void Main(string[] args)
        {

            // Declare a variable of type Teacher then assign it an instance of the Teacher class
            Teacher firstTeacher = new Teacher(101, "Tunde Badmus");

            // The above statement can also be written as below:
            // Teacher firstTeacher = new(101, "Tunde Badmus");

            // Set the Subject property to a suitable value.
            firstTeacher.Subject = "Mathematics";

            // Set the Learners property to an array of learner names.
            firstTeacher.Learners = new string[] { "John", "Tina", "Esther" };


            // Write the following to the console, for the teacher you created in task 3:
            // Their staff number and name
            Console.WriteLine($"The teacher's staff id is: {firstTeacher.StaffId}");
            Console.WriteLine($"The teacher's name is: {firstTeacher.Name}");

            // The subject they teach
            Console.WriteLine($"The teacher teaches: {firstTeacher.Subject}");

            // The number of learners they were assigned
            Console.WriteLine($"The teacher has {firstTeacher.Learners.Length} learners.");

            // The names of their assigned learners, one per line.
            Console.WriteLine($"The learners' names are: \n{string.Join('\n', firstTeacher.Learners)}");



            // Declare a variable of type Student then assign it an instance of the Student class
            Student firstStudent = new Student(1001, "Esther");

            // Set the Subject property to a suitable value.
            firstStudent.Level = "JSS 1";


            // Write the following to the console, for the student you created in task 4:
            // Their registration number and name
            Console.WriteLine($"The student's registration number is: {firstStudent.RegNumber}");
            Console.WriteLine($"The student's name is: {firstStudent.Name}");

            // Their current level
            Console.WriteLine($"The student's level is: {firstStudent.Level}");


            // Check if the student created in task 4 is one of those assigned to the teacher created in task 3. Display the result on the console.

            bool isAssignedStudent = false;

            foreach(string learner in firstTeacher.Learners)
            {
                if (learner.ToLower() == firstStudent.Name.ToLower())
                {
                    isAssignedStudent = true;
                    break;
                }
            }

            Console.WriteLine($"The search for {firstStudent.Name} returned {isAssignedStudent}");
        }
    }
}
