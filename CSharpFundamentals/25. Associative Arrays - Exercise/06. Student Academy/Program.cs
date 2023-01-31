using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentsOverview = new Dictionary<string, List<double>>();

            for (int i = 0; i < lines; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsOverview.ContainsKey(studentName))
                {
                    studentsOverview[studentName] = new List<double>();

                }

                studentsOverview[studentName].Add(grade);

            }
            foreach (var student in studentsOverview)
            {
                if (student.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
                }
            }
        }
    }
}
