using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            var newInput = new Article(input[0], input[1], input[2]); 
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                if (command[0] == "Rename")
                {
                    newInput.Rename(command[1]);
                }
                else if (command[0] == "Edit")
                {
                    newInput.Edit(command[1]);
                }
                else
                {
                    newInput.ChangeAuthor(command[1]);
                }
            }
            Console.WriteLine(newInput);
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public string Rename(string titel) => Title = titel;
        public string Edit(string content) => Content = content;
        public string ChangeAuthor(string author) => Author = author;

        public override string ToString() => $"{Title} - {Content}: {Author}";

    }
}
