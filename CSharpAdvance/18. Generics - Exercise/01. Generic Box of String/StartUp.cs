using System;

namespace Boxes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int input = int.Parse(Console.ReadLine());
                var convertedInput = new Box<int>(input);
                Console.WriteLine(convertedInput);
            }
            
        }
    }
}
