using System;
using System.Collections.Generic;

namespace _05._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            Dictionary<string, List<string>> coursesPopulation = new Dictionary<string, List<string>>();

            while (cmd != "end")
            {
                string[] tokens = cmd.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string courseName = tokens[0];
                string studentName = tokens[1];

                if (!coursesPopulation.ContainsKey(courseName))
                {
                    coursesPopulation[courseName] = new List<string>();
                }
                
                    coursesPopulation[courseName].Add(studentName);
                
                cmd = Console.ReadLine();
            }
            foreach (var course in coursesPopulation)
            {
               
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
