namespace BucketSortAlgorithmusSample;

/// <summary>
/// Die <c>BucketSortAlgorithmus</c>-Klasse implementiert den Bucket Sort Algorithmus zur Sortierung von Listen.
/// Diese Klasse ist spezialisiert auf das Sortieren von Ganzzahlen.
/// </summary>
/// <remarks>
/// Der Bucket Sort Algorithmus verwendet mehrere "Buckets", um die Werte nach ihren Bereichen aufzuteilen,
/// sortiert diese Buckets einzeln und kombiniert sie anschließend zu einem Gesamtergebnis.
/// Dieser Ansatz ist vor allem für gleichmäßig verteilte Daten effizient.
/// </remarks>
public sealed class BucketSortAlgorithmus
{
    /// <summary>
    /// Sortiert eine Liste von Ganzzahlen mit dem Bucket Sort Algorithmus.
    /// </summary>
    /// <param name="arrayToSort">Die zu sortierende Liste von Ganzzahlen.</param>
    public void Sort(IList<int> arrayToSort)
    {
        // Prüfen ob Array leer ist
        if (arrayToSort.Count == 0)
        {
            return;
        }

        // Minimum und Maximum finden
        int min = arrayToSort.Min();
        int max = arrayToSort.Max();

        // Anzahl der Buckets berechnen (Wurzel der Array-Länge)
        var bucketCount = (int)Math.Sqrt(arrayToSort.Count);

        // Grösse der einzelnen Buckets berechnen
        var bucketSize = (max - min) / bucketCount + 1;

        // Array von Buckets erstellen und initialisieren
        var buckets = new List<int>[bucketCount];
        for (var i = 0; i < bucketCount; i++)
        {
            buckets[i] = new List<int>();
        }

        // Werte in Buckets verteilen
        foreach (var value in arrayToSort)
        {
            int bucketIndex = (value - min) / bucketSize;
            buckets[bucketIndex].Add(value);
        }

        // Buckets sortieren und zurück ins Array schreiben
        int arrayIndex = 0;
        foreach (var bucket in buckets)
        {
            bucket.Sort(); // Jeden Bucket einzeln sortieren
            foreach (var value in bucket)
            {
                arrayToSort[arrayIndex] = value;
                arrayIndex++;
            }
        }
    }
}