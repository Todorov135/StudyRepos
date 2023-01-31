using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList das = new RandomList();
            das.Add("asd");
            das.Add("dfg4");
            das.Add("dfgd");
            das.Add("a123d");
            das.Add("a3d");
            das.Add("23");
            Console.WriteLine(das.RandomString());
            Console.WriteLine(das.RandomString());
            Console.WriteLine(das.RandomString());
            Console.WriteLine(das.RandomString());
            Console.WriteLine(das.RandomString());
          
     
         
        }
    }
}
