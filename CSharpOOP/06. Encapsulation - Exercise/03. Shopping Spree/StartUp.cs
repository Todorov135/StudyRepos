using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            try
            {
                Dictionary<string, Person> persons = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();

                string[] personsInput = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string[] productsInput = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < personsInput.Length; i += 2)
                {
                    string name = personsInput[i];
                    decimal money = decimal.Parse(personsInput[i + 1]);
                    Person person = new Person(name, money);
                    persons.Add(name, person);
                }
                for (int i = 0; i < productsInput.Length; i += 2)
                {
                    string name = productsInput[i];
                    decimal cost = decimal.Parse(productsInput[i + 1]);
                    Product product = new Product(name, cost);
                    products.Add(name, product);
                }
                string cmd = "";
                while ((cmd = Console.ReadLine()) != "END")
                {
                    string name = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                    string product = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

                    if (persons[name].Money >= products[product].Cost)
                    {
                        Console.WriteLine($"{name} bought {product}");
                        persons[name].Products.Add(products[product]);
                        persons[name].Money -= products[product].Cost;
                    }
                    else
                    {
                        Console.WriteLine($"{name} can't afford {product}");
                    }
                }
                foreach (var (name, productsToPrint) in persons)
                {
                    if (productsToPrint.Products.Count < 1)
                    {
                        Console.WriteLine($"{name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{name} - {string.Join(", ", productsToPrint.Products.Select(x=>x.Name))}");
                    }
                }
            }
            catch (Exception ae)
            {

                Console.WriteLine(ae.Message);
            }
            

        }
    }
}
