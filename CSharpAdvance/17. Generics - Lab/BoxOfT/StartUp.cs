using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> elements = new Box<int>();
            elements.Add(1);
            elements.Add(2);
            elements.Add(3);
            Console.WriteLine(elements.Remove());
            elements.Add(4);
            elements.Add(5);
            Console.WriteLine(elements.Remove());


        }
    }
}
