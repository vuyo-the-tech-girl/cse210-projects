using System;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6, 7);

        f1.SetTop(1);
        f1.SetBottom(1);
        f2.SetTop(6);
        f2.SetBottom(1);

        DisplayFraction(f1);
        DisplayFraction(f2);
        DisplayFraction(f3);

        Fraction f4 = new Fraction(5);
        Fraction f5 = new Fraction(3, 4);
        Fraction f6 = new Fraction(1, 3);

        DisplayFraction(f4);
        DisplayFraction(f5);
        DisplayFraction(f6);

    }

    static void DisplayFraction(Fraction f)
    {
        Console.WriteLine($"Fraction: {f.GetFractionString()}");
        Console.WriteLine($"Decimal: {f.GetDecimalValue(): 0.##}");
        Console.WriteLine();
    }
}