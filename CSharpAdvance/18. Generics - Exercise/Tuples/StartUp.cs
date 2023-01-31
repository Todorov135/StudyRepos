using System;

namespace Tuples
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string city = personInfo[2];

            string[] nameAndLittersBeer = Console.ReadLine().Split();
            string name = nameAndLittersBeer[0];
            int littersBeer = int.Parse(nameAndLittersBeer[1]);

            string[] intAndDouble = Console.ReadLine().Split();
            int integer = int.Parse(intAndDouble[0]);
            double doubleNum = double.Parse(intAndDouble[1]);

            Tuple<string, string> first = new Tuple<string, string>(fullName, city);
            Tuple<string, int> second = new Tuple<string, int>(name, littersBeer);
            Tuple<int, double> third = new Tuple<int, double>(integer, doubleNum);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
