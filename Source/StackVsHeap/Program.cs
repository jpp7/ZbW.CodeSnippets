namespace StackVsHeap;

/// <summary>
///     Represents the entry point of the application demonstrating
///     the concepts of stack versus heap memory usage in .NET.
/// </summary>
/// <remarks>
///     This class is sealed to prevent inheritance.
/// </remarks>
public sealed class Program
{
    /// <summary>
    ///     The entry point of the console application that demonstrates
    ///     stack versus heap memory allocation in .NET.
    /// </summary>
    /// <param name="args">An array of command-line arguments.</param>
    public static void Main(string[] args)
    {
        // Werttyp – Stack
        var alter = 30;

        // Referenztyp – p liegt im Stack, zeigt aber auf Heap-Objekt
        var p = new Person();
        p.Name = "Anna";

        // Struct – Werttyp, liegt komplett im Stack
        var punkt = new Point();
        punkt.X = 10;
        punkt.Y = 20;

        Console.WriteLine("Alter (Stack): " + alter);
        Console.WriteLine("Person.Name (Heap): " + p.Name);
        Console.WriteLine("Punkt.X (Stack): " + punkt.X);
        Console.WriteLine("Punkt.Y (Stack): " + punkt.Y);

        Console.WriteLine("Drücke eine Taste, um zu beenden...");
        Console.ReadLine(); // damit du Zeit hast, im Debugger zu schauen :)
    }

    /// <summary>
    ///     Represents a person with a name.
    /// </summary>
    /// <remarks>
    ///     This is a reference type, meaning objects of this class are stored in the heap.
    /// </remarks>
    public class Person
    {
        public string? Name;
    }

    /// <summary>
    ///     Represents a 2D point with X and Y coordinates.
    /// </summary>
    /// <remarks>
    ///     This is a value type, meaning instances of this struct are typically stored
    ///     on the stack when used locally. It is designed to provide simple data storage
    ///     for representing planar coordinates without requiring heap allocation.
    /// </remarks>
    public struct Point
    {
        public int X;
        public int Y;
    }
}