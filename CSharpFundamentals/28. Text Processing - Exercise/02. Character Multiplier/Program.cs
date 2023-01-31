using System;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int result = CharMultiplication(input[0], input[1]);
            Console.WriteLine(result);
        }
        public static int CharMultiplication(string str1, string str2)
        {
            int sum = 0;
            string longest = "";
            string shortest = "";

            if (str1.Length > str2.Length)
            {
                longest = str1;
                shortest = str2;
            }
            else
            {
                longest = str2;
                shortest = str1;
            }
            for (int i = 0; i < shortest.Length; i++)
            {
                sum += shortest[i] * longest[i];
            }
            for (int i = shortest.Length; i < longest.Length; i++)
            {
                sum += longest[i];
            }


            return sum;
        }
    }
}
