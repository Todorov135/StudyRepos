using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private List<string> customList;
        public RandomList()
        {
            this.CustomList = new List<string>();
        }

        public List<string> CustomList { get; set; }
       
        

       public string RandomString()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, this.CustomList.Count+1);
            string output = this.CustomList[randomNumber];
            this.CustomList.RemoveAt(randomNumber);
            return output;
        }

    }
}
