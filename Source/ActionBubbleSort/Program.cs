// See https://aka.ms/new-console-template for more information

namespace ActionBubbleSort;

/// <summary>
/// Represents the main class in the application, which demonstrates the
/// functionality of a Bubble Sort algorithm. Contains methods to perform
/// sorting as well as handling the program's entry point.
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Serves as the entry point for the application and demonstrates the usage
    /// of the Bubble Sort algorithm. Initializes an array of integers, sorts it,
    /// and outputs the steps and the final sorted array to the console.
    /// </summary>
    public static void Main()
    {
        int[] numbers = { 5, 3, 2, 4, 1 };

        Sort(
            numbers,
            (i, j) => Console.WriteLine($"→ Schritt: Index {i} ({numbers[i]}) und {j} ({numbers[j]})")
        );

        Console.WriteLine("Fertig sortiert: " + string.Join(", ", numbers));
        Console.WriteLine("Done!!!");
    }


    /// <summary>
    /// Sorts an array of integers using the Bubble Sort algorithm.
    /// Optionally invokes an action during comparison and swap operations.
    /// </summary>
    /// <param name="a">The array of integers to be sorted.</param>
    /// <param name="step">
    /// An optional action to invoke during each comparison or swap operation.
    /// The action receives the indices of the elements being compared or swapped.
    /// If null, no action is performed during sorting.
    /// </param>
    public static void Sort(int[] a, Action<int, int>? step = null)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                // Bei jedem Vergleichen Bescheid sagen
                step?.Invoke(j, j + 1);

                if (a[j] > a[j + 1])
                {
                    // Bei jedem Tausch Bescheid sagen
                    step?.Invoke(j, j + 1);

                    // a[j], a[j + 1]) = (a[j + 1], a[j]); // tuple swap
                    var temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
            }
        }
    }
}