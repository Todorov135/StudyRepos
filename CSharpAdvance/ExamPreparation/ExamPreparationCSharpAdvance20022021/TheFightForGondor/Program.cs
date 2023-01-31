using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> orcAttack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int waveCounter = 0;
            bool isOrcWin = false;
            for (int i = orcWaves; i >= 0; i--)
            {
                waveCounter++;
                if (waveCounter == 3)
                {
                    waveCounter = 0;
                    int newPlates = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlates);
                }


                while (orcAttack.Count != 0 && plates.Count != 0)
                {
                    int currPlate = plates.Peek();
                    int currOrc = orcAttack.Peek();
                    if (currPlate - currOrc > 0)
                    {
                        currPlate -= currOrc;
                        orcAttack.Pop();
                        plates.Dequeue();
                        plates.Enqueue(currPlate);
                        for (int l = 0; l < plates.Count - 1; l++)
                        {
                            int currRotetingPlate = plates.Dequeue();
                            plates.Enqueue(currRotetingPlate);

                        }
                    }
                    else if (currPlate - currOrc < 0)
                    {
                        currOrc -= currPlate;
                        plates.Dequeue();

                        orcAttack.Pop();
                        orcAttack.Push(currOrc);
                        if (plates.Count == 0)
                        {
                            isOrcWin = true;
                            break;
                        }

                    }
                    else if (currPlate == currOrc)
                    {
                        plates.Dequeue();
                        orcAttack.Pop();
                    }

                }
                if (isOrcWin)
                {
                    break;
                }
                if (i <= orcWaves)
                {
                    int[] nextOrcWave = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    for (int j = 0; j < nextOrcWave.Length; j++)
                    {
                        orcAttack.Push(nextOrcWave[j]);
                    }
                }
                   
                
                
            }
            
            string print = plates.Count > 0 ? $"The people successfully repulsed the orc's attack.{Environment.NewLine}Plates left: {string.Join(", ", plates)}"
                : $"The orcs successfully destroyed the Gondor's defense.{Environment.NewLine}Orcs left: {string.Join(", ", orcAttack)}";
            Console.WriteLine(print);
        }
    }
}
