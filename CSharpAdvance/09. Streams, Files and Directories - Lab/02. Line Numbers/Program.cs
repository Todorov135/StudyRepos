using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                int lineNum = 0;
                string currLine = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (currLine != null)
                    {
                        writer.WriteLine($"{++lineNum}. {currLine}");
                        currLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}