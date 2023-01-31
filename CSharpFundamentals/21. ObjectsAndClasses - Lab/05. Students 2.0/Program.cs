using System;
using System.Collections.Generic;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (command != "end")
            {
                string[] studentProp = command.Split();
                Student student = new Student
                {
                    FirstName = studentProp[0],
                    LastName = studentProp[1],
                    Age = studentProp[2],
                    HomeTown = studentProp[3],
                };
                if (student.FirstName == students[0].FirstName && student.LastName == students[1].LastName )
                {
                     student = new Student
                    {
                        FirstName = studentProp[0],
                        LastName = studentProp[1],
                        Age = studentProp[2],
                        HomeTown = studentProp[3],
                    };
                    students.Remove(student);

                }
                students.Add(student);


                command = Console.ReadLine();

            }
            string cityName = Console.ReadLine();

            foreach (Student person in students)
            {
                if (cityName == person.HomeTown)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} is {person.Age} years old.");
                }
            }
        }
    }
    class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string HomeTown { get; set; }
    }
}
