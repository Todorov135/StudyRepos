using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = "";


            ListyIterator<string> listyireterator = null;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split();
                if (command[0] == "Create")
                {
                    var newOne = new ListyIterator<string>(command.Skip(1).ToArray());
                    listyireterator = newOne;
                }
                else if (command[0] == "Move")
                {
                    Console.WriteLine(listyireterator.Move());
                }
                else if (command[0] == "HasNext")
                {
                    Console.WriteLine(listyireterator.HasNext());
                }
                else if (command[0] == "Print")
                {
                    listyireterator.Print();
                }
                else if (command[0] == "PrintAll")
                {
                    listyireterator.PrintAll();
                }


            }
        }
    }
}
