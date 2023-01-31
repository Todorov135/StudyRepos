namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = "Ivan";
            Animal animal = new Animal(name);
            Mammal mammal = new Mammal(name);
            Bear bear = new Bear(name);
            Reptile reptile = new Reptile(name);
            Snake snake = new Snake(name);
            //System.Console.WriteLine($"Animal{animal.Name}");
            //System.Console.WriteLine($"mammal{mammal.Name}");
            //System.Console.WriteLine($"bear{bear.Name}");
            //System.Console.WriteLine($"reptile{reptile.Name}");
            //System.Console.WriteLine($"snake{snake.Name}");

        }
    }
}