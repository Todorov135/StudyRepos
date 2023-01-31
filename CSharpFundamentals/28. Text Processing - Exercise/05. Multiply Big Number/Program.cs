using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigInt = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            if (num == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int multiplaing = 0;
            int reminder = 0;

            for (int i = bigInt.Length-1; i >= 0; i--)
            {
                
                int lastNumber = int.Parse(bigInt[i].ToString());
                multiplaing = lastNumber * num + reminder;

                sb.Append(multiplaing % 10);
                reminder = multiplaing / 10;
            }
            if (reminder != 0)
            {
                sb.Append(reminder);
            }

            StringBuilder reversedStringBuilder = new StringBuilder();
            for (int i = sb.Length-1; i >= 0; i--)
            {
                reversedStringBuilder.Append(sb[i]);

            }
            Console.WriteLine(reversedStringBuilder);
        }
    }
}
