using System;
using System.Linq;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessiges = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfMessiges; i++)
            {
                string messige = Console.ReadLine();
                int count = messige.ToLower().Count(x => x == 's' || x == 't' || x == 'a' || x == 'r') ;
                string realMessige = "";

                foreach (var item in messige)
                {
                    realMessige += (char)(item - count);
                }
                Console.WriteLine(realMessige);
            }

        }
    }
}
