namespace HeapPriorityqueueSample.Comparers;

/// <summary>
///     Diese Klasse implementiert einen Comparer für Ganzzahlen (int),
///     der verwendet wird, um zwei Werte zu vergleichen. Sie ordnet die
///     Werte in einer aufsteigenden Reihenfolge durch den Aufruf von
///     <see cref="int.CompareTo(int)" />.
/// </summary>
/// <remarks>
///     Die <see cref="MaxComparer" />-Klasse wird häufig in Datenstrukturen
///     wie Heaps oder Priority Queues verwendet, wenn spezifisches
///     Verhalten beim Vergleich von Elementen notwendig ist.
/// </remarks>
public sealed class MaxComparer : IComparer<int>
{
    #region IComparer<int> Members

    /// <summary>
    ///     Vergleicht zwei Ganzzahlen und gibt einen Wert zurück, der anzeigt, ob die
    ///     erste kleiner, gleich oder grösser als die zweite ist.
    /// </summary>
    /// <param name="x">Die erste Ganzzahl, die verglichen werden soll.</param>
    /// <param name="y">Die zweite Ganzzahl, die verglichen werden soll.</param>
    /// <returns>
    ///     Ein negativer Wert, wenn <paramref name="x" /> kleiner als <paramref name="y" /> ist;
    ///     0, wenn beide gleich sind;
    ///     ein positiver Wert, wenn <paramref name="x" /> grösser als <paramref name="y" /> ist.
    /// </returns>
    public int Compare(int x, int y)
    {
        return x.CompareTo(y); // MaxHeap-Logik
    }

    #endregion
}