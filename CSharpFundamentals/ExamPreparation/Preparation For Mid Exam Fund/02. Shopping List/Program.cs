using System;
using System.Linq;

namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitnigPeople = int.Parse(Console.ReadLine());
            int[] liftCurrStatement = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < liftCurrStatement.Length; i++)
            {
                for (int j = liftCurrStatement[i]; j < 4; j++)
                {
                    if (i < 4)
                    {
                        liftCurrStatement[i]++;
                        waitnigPeople--;

                        if (waitnigPeople <= 0)
                        {
                            Console.WriteLine($"There isn't enough space! {waitnigPeople} people in a queue!");
                            Console.WriteLine(string.Join(" ", liftCurrStatement));

                            return;
                        }
                    }

                }

            }
            Console.WriteLine("The lift has empty spots!");
            Console.WriteLine(string.Join(" ", liftCurrStatement));
            
            

        }
    }
}
