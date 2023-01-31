using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+[A-Z][a-zA-Z\d]{4,}[A-Z]@#+";

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string barcode = Console.ReadLine();

                bool isMatch = Regex.IsMatch(barcode, pattern);

                if (isMatch)
                {
                    string digitPattern = @"\d";
                    MatchCollection productGroupe = Regex.Matches(barcode, digitPattern);
                    string intProductGroupe = "00";
                    if (productGroupe.Count >0)
                    {
                        intProductGroupe = string.Join("",productGroupe);
                    }
                    Console.WriteLine($"Product group: {intProductGroupe}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
