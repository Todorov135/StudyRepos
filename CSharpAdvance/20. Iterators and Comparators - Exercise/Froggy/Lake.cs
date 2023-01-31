using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(params int[] stones)
        {
            this.Stones = new int[stones.Length];
            for (int i = 0; i < stones.Length; i++)
            {
                this.Stones[i] = stones[i];
            }
        }
        public int[] Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Stones.Length; i++)
            {
                if (i%2 ==0)
                {
                    yield return this.Stones[i];
                }
            }
            for (int i = this.Stones.Length-1; i >= 0; i--)
            {
                if (i%2 != 0)
                {
                    yield return this.Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
