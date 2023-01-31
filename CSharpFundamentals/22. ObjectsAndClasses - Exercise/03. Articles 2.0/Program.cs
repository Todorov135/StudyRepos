using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {


            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Console.WriteLine($"{input[0]} - {input[1]}: {input[2]}");
            }

        }
    }
}
//    class Article
//    {
//        public Article(string title, string content, string author)
//        {
//            Title = title;
//            Content = content;
//            Author = author;
//        }

//        public string Title { get; set; }
//        public string Content { get; set; }
//        public string Author { get; set; }

//        public override string ToString() => $"{Title} - {Content}: {Author}";

//    }
//}
