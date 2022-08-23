using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {   
            double radius = double.Parse(Console.ReadLine());
            Shape circle = new Circle(radius);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            Shape rectangle = new Rectangle(width, height);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
