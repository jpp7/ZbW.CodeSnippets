using RingBufferQueueSample.Impl;

namespace RingBufferQueueSample;

/// <summary>
/// The Program class serves as the entry point for the application. It demonstrates
/// the usage of a fixed-size circular queue implementation (ICircularQueue16) by
/// enqueueing and iterating elements.
/// </summary>
public sealed class Program
{
    /// <summary>
    /// The entry point of the application. This method demonstrates the usage of a circular queue
    /// with a fixed size of 16 elements by enqueueing a series of integers and iterating over the
    /// stored elements. It also displays the final state of the queue and terminates with a confirmation message.
    /// </summary>
    public static void Main()
    {
        ICircularQueue16<int> queue16 = new CircularQueue16<int>();

        // 20 Zahlen einfügen
        for (var i = 1; i <= 20; i++)
        {
            queue16.Enqueue(i);
        }

        Console.WriteLine("Inhalt nach 20 Enqueues (soll 5‑20 sein):");
        foreach (var x in queue16)
        {
            Console.Write($"{x} ");
        }
        
        // Ausgabe: 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20

        Console.WriteLine();
        Console.WriteLine("Done!!!");
    }
}