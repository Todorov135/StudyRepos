
using System.IO;

namespace OddLines

{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                int linecounter = 0;
                string currLine = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (currLine != null)
                    {
                        if (linecounter % 2 == 1)
                        {
                            writer.WriteLine(currLine);
                        }
                        linecounter++;
                        currLine = reader.ReadLine();
                    }
                }

            }
        }
    }
}