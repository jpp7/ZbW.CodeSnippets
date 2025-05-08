namespace BucketSortAlgorithmusSample;

/// <summary>
/// The Program class contains the entry point of the application demonstrating the usage of the Bucket Sort algorithm.
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Beispiel zur Verwendung des Bucket Sort Algorithmus
    /// </summary>
    public static void Main()
    {
        // Beispiel-Array erstellen
        List<int> numbers = new List<int> { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Unsortierte Liste:");
        Console.WriteLine(string.Join(", ", numbers));

        // Sortieren
        var sorter = new BucketSortAlgorithmus();
        sorter.Sort(numbers);

        Console.WriteLine("\nSortierte Liste:");
        Console.WriteLine(string.Join(", ", numbers));
    }
}