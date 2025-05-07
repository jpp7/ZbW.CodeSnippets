namespace LinkedList;

/// <summary>
///     The Program class serves as the entry point of the application.
///     It demonstrates the functionality of a custom linked list implementation by performing operations
///     such as adding elements, iterating through them, and printing their values in various ways.
/// </summary>
public sealed class Program
{
    /// <summary>
    ///     Entry point of the application. Initializes and demonstrates the usage of a custom linked list
    ///     implementation by adding, iterating, and printing various types of elements.
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("Start LinkedList");

        // Create a new LinkedList instance and add various types of elements to it
        var list = new LinkedList();
        list.Add("Hallo");
        list.Add("Welt");
        list.Add(42);
        list.Add(3.14);
        list.Add(new DateTime(2023, 10, 1));

        // Print the elements of the LinkedList using different methods
        Console.WriteLine("Printen der LinkedList ausgeben mit for Schleife:");

        for (var i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        Console.WriteLine();

        Console.WriteLine("Printen der LinkedList ausgeben mit while Schleife (MoveNext):");

        var iterator = list.GetEnumerator();

        while (iterator.MoveNext())
        {
            Console.WriteLine(iterator.Current);
        }

        // iterator.Reset();

        Console.WriteLine();

        Console.WriteLine("Printen der LinkedList ausgeben mit foreach Schleife:");

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();


        Console.WriteLine("Ende LinkedList");
    }
}