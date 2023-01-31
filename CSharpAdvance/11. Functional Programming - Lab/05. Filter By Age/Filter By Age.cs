using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] inputedNameAndAge = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputedNameAndAge[0];
                int age = int.Parse(inputedNameAndAge[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = PersonFilter(condition, ageThreshold);
            List<Person> filteredPersons = persons.Where(p => filter(p)).ToList();


            string printFormat = Console.ReadLine();
            Action<Person> printPerson = CreatePersonPrinter(printFormat);

            Print(filteredPersons, printPerson);
        }

        

        static Func<Person, bool> PersonFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                return p => p.Age < ageThreshold;
            }
            else if (condition == "older")
            {
                return p => p.Age >= ageThreshold;
            }
            return null;
        }
        static Action<Person> CreatePersonPrinter(string printFormat)
        {
            if (printFormat == "name")
            {
                return p => Console.WriteLine($"{p.Name}");
            }
            if (printFormat == "age")
            {
                return p => Console.WriteLine($"{p.Age}");
            }
            if (printFormat == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            return null;

        }
        static void Print(List<Person> filteredPersons, Action<Person> printPerson)
        {
            foreach (Person person in filteredPersons)
            {
                printPerson(person);
            }
        }


    }
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}

