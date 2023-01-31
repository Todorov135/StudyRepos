using System;

namespace Person
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            try
            {
                string namePerson = Console.ReadLine();
                int agePerson = int.Parse(Console.ReadLine());

                string nameChild = Console.ReadLine();
                int ageChild = int.Parse(Console.ReadLine());

                Person person = new Person(namePerson, agePerson);
                Child child = new Child(nameChild, ageChild);

                Console.WriteLine(person);
                Console.WriteLine(child);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            

        }
    }
}
