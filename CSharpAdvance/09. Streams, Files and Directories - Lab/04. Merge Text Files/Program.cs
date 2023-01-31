using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader readerFirstInput = new StreamReader(firstInputFilePath);
            StreamReader readerSecondInput = new StreamReader(secondInputFilePath);
            int firstInput = File.ReadAllLines(firstInputFilePath).Length;
            int secondInput = File.ReadAllLines(secondInputFilePath).Length;
            int index = 0;
            using (readerFirstInput)
            {
                var first = readerFirstInput.ReadLine();
                using (readerSecondInput)
                {
                    var second = readerSecondInput.ReadLine();
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        while (true)
                        {
                            index++;
                            if (index> firstInput || index > secondInput)
                            {
                                break;
                            }
                            writer.WriteLine(first);
                            writer.WriteLine(second);
                            first = readerFirstInput.ReadLine();
                            second = readerSecondInput.ReadLine();
                        }
                        if (firstInput < secondInput)
                        {
                            for (int i = index - 1; i < secondInput; i++)
                            {
                                writer.WriteLine(second);
                            }
                        }
                        else
                        {
                            for (int i = index - 1; i < firstInput; i++)
                            {
                                writer.WriteLine(first);
                            }
                        }


                    }
                }
            }
            
        }
    }
}
