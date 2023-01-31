using System;

namespace ExperienceGaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double expericeNeeded = double.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= countOfBattles; i++)
            {
                double expPerBattle = double.Parse(Console.ReadLine());
                counter++;  
                expericeNeeded -= expPerBattle;
                if (i % 3 == 0)
                {
                    expericeNeeded -= expPerBattle * 0.15;

                }
                if (i % 5 == 0)
                {
                    expericeNeeded += expPerBattle * 0.1;
                }
                if (i % 15 == 0)
                {
                    expericeNeeded -= expPerBattle * 0.05;
                }
                if (expericeNeeded <= 0)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {counter} battles.");
                    return;
                }

            }
            Console.WriteLine($"Player was not able to collect the needed experience, {expericeNeeded:f2} more needed.");
        }
    }
}
