using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square s1 = new Square("Red", 5);
        Console.WriteLine($"Square - Color: {s1.GetColor()}, Area: {s1.GetArea()}");
        
        List<Shape> shapes = new List<Shape>();
        
        shapes.Add(new Square("Blue", 4));
        shapes.Add(new Rectangle("Green", 3, 6));
        shapes.Add(new Circle("Yellow", 2.5));
        
        Console.WriteLine("\nLooping through shapes:");
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea():F2}");
        }
    }
}