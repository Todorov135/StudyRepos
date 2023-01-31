using System;

namespace _01._Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputedSentence = Console.ReadLine().Split();

            Random rnd = new Random();

            for (int i = 0; i < inputedSentence.Length; i++)
            {
               int randomIndex = rnd.Next(0, inputedSentence.Length);

                string currWord = inputedSentence[i];

                inputedSentence[i] = inputedSentence[randomIndex];
                inputedSentence[randomIndex] = currWord;

            }

            foreach (var item in inputedSentence)
            {
                Console.WriteLine(item);
            }
        }
    }
}
