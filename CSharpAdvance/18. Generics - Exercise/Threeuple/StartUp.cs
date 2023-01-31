using System;

namespace Threeuple
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];
            string city = personInfo[3];

            string[] nameAndLittersBeer = Console.ReadLine().Split();
            string name = nameAndLittersBeer[0];
            int littersBeer = int.Parse(nameAndLittersBeer[1]);
            bool isDrunk = nameAndLittersBeer[2] == "drunk" ? true : false;

            string[] bankInfo = Console.ReadLine().Split();
            string nameOfCliet = bankInfo[0];
            double balance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            Threeuple<string, string, string> first = new Threeuple<string, string,string>(fullName, address,city);
            Threeuple<string, int, bool> second = new Threeuple<string, int, bool>(name, littersBeer, isDrunk);
            Threeuple<string, double, string> third = new Threeuple<string, double, string>(nameOfCliet, balance, bankName);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }
    }
}
