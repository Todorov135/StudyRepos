using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfAllStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < countOfAllStudents; i++)
            {
                string[] currStudent = Console.ReadLine().Split();
                string firstName = currStudent[0];
                string lastName = currStudent[1];
                double grade = double.Parse(currStudent[2]);
                var curStudentInfo = new Student(firstName, lastName, grade);
                students.Add(curStudentInfo);
            }
            students = students.OrderByDescending(currStudent => currStudent.Grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

        }
    }
    public class Student 
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString() => $"{FirstName} {LastName}: {Grade:f2}";
        
    }
}
