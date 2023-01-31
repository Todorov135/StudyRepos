using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<decimal>() { grade });
                }
                else 
                {
                    grades[name].Add(grade);
                }
            }
            foreach (var student in grades)
            {
                List<decimal> studentGrades = student.Value;
                Console.WriteLine($"{student.Key} -> {string.Join(" ",studentGrades.Select(g => g.ToString("f2")))} (avg: {(studentGrades.Average()):f2})");
            }
        }
    }
}
