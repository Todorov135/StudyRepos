using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string messige = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < messige.Length; i++)
            {
                char currChar = messige[i];
                char scriptedChar = (char)(currChar + 3);
                sb.Append(scriptedChar);
            }
            Console.WriteLine(sb);
        }
    }
}
