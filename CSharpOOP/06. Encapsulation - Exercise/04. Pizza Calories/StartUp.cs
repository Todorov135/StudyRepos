using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           
            try
            {
                string[] inputPizza = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] inputDough = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Dough dough = new Dough(inputDough[1], inputDough[2], double.Parse(inputDough[3]));
                Pizza pizza = new Pizza(inputPizza[1], dough);
                string input = "";
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputTopping = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(inputTopping[1], double.Parse(inputTopping[2]));
                    pizza.AddTopping(topping);
                    
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
               
            
            
        }
    }
}
