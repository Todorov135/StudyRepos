using System;
using System.Text;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            StringBuilder output = new StringBuilder();
            //string output = "";

            foreach (string word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    output.Append(word);
                    //output += word;
                }
            }
            Console.WriteLine(output);
        }
    }
}
