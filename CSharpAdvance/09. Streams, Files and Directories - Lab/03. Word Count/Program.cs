using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();
            StreamReader wordsReader = new StreamReader(wordsFilePath);
            using (wordsReader)
            {
                string[] currWord = wordsReader.ReadLine().ToLower().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                using (var text = new StreamReader(textFilePath))
                {
                    char[] charsToRemove = new char[] { '-', '-', '.', ',', '!', '?', '"' };
                    string[] currText = text.ReadLine().TrimStart(charsToRemove).TrimEnd(charsToRemove).ToLower().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                    while (!text.EndOfStream)
                    {
                        
                        for (int i = 0; i < currText.Length; i++)
                        {
                            for (int j = 0; j < currWord.Length; j++)
                            {
                                if (currText[i] == currWord[j])
                                {
                                    if (!counter.ContainsKey(currWord[j]))
                                    {
                                        counter.Add(currWord[j], 0);
                                    }
                                    counter[currWord[j]]++;
                                    
                                }
                            }
                        }
                        currText = text.ReadLine().TrimStart(charsToRemove).TrimEnd(charsToRemove).ToLower().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

                    }



                }
            }

            counter = counter.OrderByDescending(v => v.Value).ToDictionary(k => k.Key, v => v.Value);
            var output = new StreamWriter(outputFilePath);
            using (output)
            {
                foreach (var count in counter)
                {
                    output.WriteLine($"{count.Key} - {count.Value}");
                }
            }
        }
    }
}