using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape;
            shape = new Circle(2);
            if (shape is Circle circle)
            {
                Console.WriteLine(circle.CalculateArea());
                Console.WriteLine(circle.CalculatePerimeter());
                Console.WriteLine(circle.Draw());
            }
            shape = new Rectangle(2, 2);
            if (shape is Rectangle rectangle)
            {
                Console.WriteLine(rectangle.CalculateArea());
                Console.WriteLine(rectangle.CalculatePerimeter());
                Console.WriteLine(rectangle.Draw());
            }
        }
    }
}
