// See https://aka.ms/new-console-template for more information

namespace ActionBubbleSort;

/// <summary>
/// Die Klasse Program enthält die Hauptanwendung und Implementierungen des Bubble-Sort-Algorithmus.
/// Sie bietet Methoden zum Sortieren von Arrays mit optionaler Rückmeldung
/// über die durchgeführten Schritte.
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Die Main-Methode ist der Einstiegspunkt der Anwendung.
    /// Sie demonstriert die Verwendung des Bubble-Sort-Algorithmus,
    /// indem ein Array von Ganzzahlen sortiert und optionale Rückmeldungen
    /// zu den Vergleichs- und Tauschoperationen ausgegeben werden.
    /// Zusätzlich wird das sortierte Ergebnis ausgegeben.
    /// </summary>
    public static void Main()
    {
        int[] numbers = { 5, 3, 2, 4, 1 };

        BubbleSortEarlyExit(
            numbers,
            (i, j) => Console.WriteLine($"→ Schritt: Index {i} ({numbers[i]}) und {j} ({numbers[j]})")
        );

        Console.WriteLine("Fertig sortiert: " + string.Join(", ", numbers));
        Console.WriteLine("Done!!!");
    }


    /// <summary>
    /// Führt den Bubble-Sort-Algorithmus auf einem gegebenen Array aus.
    /// Diese Methode sortiert das Array in aufsteigender Reihenfolge und
    /// bietet eine Option zur Übergabe einer Aktion, die bei jedem Vergleich
    /// oder Tausch von Elementen ausgeführt wird.
    /// </summary>
    /// <param name="a">Das zu sortierende Array.</param>
    /// <param name="step">
    /// Eine optionale Aktion, die bei jedem Vergleich oder Tausch der Elemente
    /// im Array ausgeführt wird. Sie gibt die Indizes der betroffenen Elemente
    /// zurück.
    /// </param>
    public static void Sort(int[] a, Action<int, int>? step = null)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = 0; j < a.Length - 1 - i; j++)
            {
                // Bei jedem Vergleichen Bescheid sagen
                //step?.Invoke(j, j + 1);

                if (a[j] > a[j + 1])
                {
                    // Bei jedem Tausch Bescheid sagen
                    //step?.Invoke(j, j + 1);

                    // a[j], a[j + 1]) = (a[j + 1], a[j]); // tuple swap
                    var temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
            }
        }
    }


    /// <summary>
    /// Führt den Bubble-Sort-Algorithmus mit vorzeitigem Abbruch durch.
    /// Diese Methode sortiert ein gegebenes Array in aufsteigender Reihenfolge
    /// und beendet den Algorithmus, sobald das Array sortiert ist.
    /// Optional kann eine Aktion übergeben werden, die bei jedem Vergleich
    /// und Tausch von Elementen ausgeführt wird.
    /// </summary>
    /// <param name="a">Das zu sortierende Array.</param>
    /// <param name="step">
    /// Eine optionale Aktion, die bei jedem Vergleich oder Tausch von Elementen
    /// ausgeführt wird. Die Indizes der beteiligten Elemente werden übergeben.
    /// </param>
    public static void BubbleSortEarlyExit(int[] a, Action<int,int>? step = null)
    {
        if (a == null || a.Length < 2) return;

        int n = a.Length;
        bool swapped;

        do
        {
            swapped = false;

            // nach jedem Durchgang ist das grösste Element am Ende,
            // daher können wir die Vergleichsgrenze (n) verkleinern
            for (int i = 1; i < n; i++)
            {
                step?.Invoke(i - 1, i);

                if (a[i - 1] > a[i])
                {
                    step?.Invoke(i - 1, i);
                    (a[i - 1], a[i]) = (a[i], a[i - 1]);   // tuple swap
                    swapped = true;
                }
            }

            n--;                 // letzte Position ist jetzt fest
        }
        while (swapped);        // kein Tausch ⇒ Array bereits sortiert
    }
}