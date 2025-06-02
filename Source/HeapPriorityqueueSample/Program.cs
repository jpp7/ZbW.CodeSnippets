#region

using HeapPriorityqueueSample.Comparers;

#endregion

namespace HeapPriorityqueueSample;

/// <summary>
///     Stellt die Hauptklasse des Programms dar, die den Einstiegspunkt der Anwendung definiert.
///     Diese Klasse demonstriert die Verwendung einer Heap-Prioritätswarteschlange mit Beispieldaten.
/// </summary>
public sealed class Program
{
    /// <summary>
    ///     Der Einstiegspunkt der Anwendung.
    ///     Diese Methode startet die Ausführung des Programms und demonstriert die Nutzung einer Heap-Prioritätswarteschlange.
    /// </summary>
    public static void Main()
    {
        // min. Heap-Beispiel
        var heap = new Heap<int>(comparer: new MinComparer());
        heap.Enqueue(5);
        heap.Enqueue(1);
        heap.Enqueue(9);
        heap.Enqueue(2);

        while (heap.Count > 0)
        {
            Console.WriteLine(heap.Dequeue()); // Ausgabe: 1, 2, 5, 9
        }

        // PriorityQueue Beispiel
        var pq = new PriorityQueue<string, int>();

        pq.Enqueue("Notfall", 1);
        pq.Enqueue("Routine", 5);
        pq.Enqueue("Dringend", 2);

        while (pq.Count > 0)
        {
            Console.WriteLine(pq.Dequeue()); // Ausgabe: Notfall, Dringend, Routine
        }

        Console.WriteLine("Done!!!");
    }
}