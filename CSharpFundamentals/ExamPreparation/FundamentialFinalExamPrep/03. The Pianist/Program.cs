using System;
using System.Collections.Generic;

namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            
            var music = new Dictionary<string, KeyValuePair<string, string>>();
            var orther = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split("|");

                if (!music.ContainsKey(input[0]))
                {
                    music.Add(input[0], new KeyValuePair<string, string>(input[1], input[2]));
                    orther.Add(input[0]);
                }
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] tokens = command.Split("|");
                string action = tokens[0];
                string piece = tokens[1];

                switch (action)
                {
                    case "Add":
                        {
                            string composer = tokens[2];
                            string key = tokens[3];

                            if (!music.ContainsKey(piece))
                            {
                                music.Add(piece, new KeyValuePair<string, string>(composer, key));
                                orther.Add(piece);
                                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                            }
                            else
                            {
                                Console.WriteLine($"{piece} is already in the collection!");
                            }
                        }
                        break;
                    case "Remove":
                        {
                            if (music.ContainsKey(piece))
                            {
                                music.Remove(piece);
                                Console.WriteLine($"Successfully removed {piece}!");
                                orther.Remove(piece);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                            }
                        }
                        break;
                    case "ChangeKey":
                        {
                            string newKey = tokens[2];
                            if (music.ContainsKey(piece))
                            {
                                var pieceData = music[piece];
                                var composerData = pieceData.Key;
                                music[piece] = new KeyValuePair<string, string>(composerData, newKey);
                                Console.WriteLine($"Changed the key of {piece} to {newKey}!");

                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                            }
                        }
                        break;


                }



                command = Console.ReadLine();
            }
            foreach (var piece in orther)
            {
                Console.WriteLine($"{piece} -> Composer: {music[piece].Key}, Key: {music[piece].Value}");
            }

        }
    }
}
