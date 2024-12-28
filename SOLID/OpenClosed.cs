using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.SOLID
{
/*
Open for extension: You should be able to add new functionality to a class without modifying 
its existing code.
Closed for modification: Once a class is written and tested, it shouldn't need to be changed.
This principle promotes the use of abstraction and polymorphism to allow the behavior of a system 
to be extended without altering its core functionality.
*/
    public class OpenClosed
    {
        // Step 1: Define a common interface
        public interface IShape
        {
            double CalculateArea();
        }

        // Step 2: Implement the interface for each shape
        public class Circle : IShape
        {
            public double Radius { get; set; }
            public double CalculateArea() => Math.PI * Radius * Radius;
        }

        public class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public double CalculateArea() => Width * Height;
        }

        // Step 3: Use polymorphism in the calculator
        public class AreaCalculator
        {
            public double TotalArea(IEnumerable<IShape> shapes)
            {
                return shapes.Sum(shape => shape.CalculateArea());
            }
        }

        public class Triangle : IShape
        {
            public double Base { get; set; }
            public double Height { get; set; }
            public double CalculateArea() => 0.5 * Base * Height;
        }

        static void Main(string[] args)
        {
            // Step 1: Create instances of shapes
            var circle = new Circle { Radius = 5 };
            var rectangle = new Rectangle { Width = 10, Height = 20 };
            var triangle = new Triangle { Base = 15, Height = 10 };

            // Step 2: Add shapes to a collection
            var shapes = new List<IShape> { circle, rectangle, triangle };

            // Step 3: Use AreaCalculator to calculate total area
            var calculator = new AreaCalculator();
            double totalArea = calculator.TotalArea(shapes);

            // Step 4: Display the total area
            Console.WriteLine($"Total Area of Shapes: {totalArea}");
        }
    }
}
