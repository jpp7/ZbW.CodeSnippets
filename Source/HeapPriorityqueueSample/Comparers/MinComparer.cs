namespace HeapPriorityqueueSample.Comparers;

/// <summary>
///     Stellt einen Vergleichsalgorithmus für Integer-Werte bereit, der speziell für Min-Heap-Operationen verwendet wird.
///     Die Klasse implementiert die <see cref="IComparer{T}" />-Schnittstelle, wobei Vergleiche umgekehrt werden,
///     sodass kleinere Werte als "grösser" behandelt werden, um eine Priorisierung im Sinne eines Min-Heap
///     sicherzustellen.
/// </summary>
public sealed class MinComparer : IComparer<int>
{
    #region IComparer<int> Members

    /// <summary>
    ///     Vergleicht zwei Integer-Werte und kehrt deren natürliche Sortierreihenfolge um.
    ///     Dieser umgekehrte Vergleich wird hauptsächlich in Min-Heap-Implementierungen verwendet,
    ///     um kleinere Werte mit höherer Priorität zu behandeln.
    /// </summary>
    /// <param name="x">Der erste zu vergleichende Wert.</param>
    /// <param name="y">Der zweite zu vergleichende Wert.</param>
    /// <returns>
    ///     Ein Wert, der anzeigt, wie die beiden Werte relativ zueinander sortiert werden sollen:
    ///     <list type="bullet">
    ///         <item>Ein negativer Wert, wenn x grösser als y ist.</item>
    ///         <item>Null, wenn x und y gleich sind.</item>
    ///         <item>Ein positiver Wert, wenn x kleiner als y ist.</item>
    ///     </list>
    /// </returns>
    public int Compare(int x, int y)
    {
        return y.CompareTo(x); // MinHeap-Logik
    }

    #endregion
}