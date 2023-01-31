using System;

namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string workSequence = Console.ReadLine();

            workSequence = SequenceManipulation(wordToRemove, workSequence);
            Console.WriteLine(workSequence);
        }

        private static string SequenceManipulation(string wordToRemove, string workSequence)
        {
            while (workSequence.Contains(wordToRemove))
            {
                int startIndex = workSequence.IndexOf(wordToRemove);
                workSequence = workSequence.Remove(startIndex, wordToRemove.Length);


            }

            return workSequence;
        }
    }
}
