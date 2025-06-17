namespace HeapPriorityqueueSample;

/// <summary>
///     Eine generische PriorityQueue-Klasse, die Elemente basierend auf ihrer Priorität verwaltet.
///     Elemente mit höherer Priorität werden zuerst aus der Warteschlange abgerufen. Die Implementierung basiert auf einer
///     Heap-Datenstruktur.
/// </summary>
/// <typeparam name="TElement">Der Typ der Elemente, die in der PriorityQueue gespeichert werden.</typeparam>
/// <typeparam name="TPriority">Der Typ der Prioritäten, die die Reihenfolge der Elemente bestimmen.</typeparam>
public sealed class PriorityQueue<TElement, TPriority>
{
    private readonly IComparer<TPriority> _comparer;
    private (TElement Element, TPriority Priority)[] _array;

    /// <summary>
    ///     Eine Datenstruktur, die Elemente basierend auf ihren Prioritäten in einer Heap-ähnlichen Struktur verwaltet.
    ///     Die PriorityQueue ermöglicht das effiziente Hinzufügen von Elementen und das Abrufen des Elements mit der höchsten
    ///     Priorität.
    /// </summary>
    /// <typeparam name="TElement">Der Typ der Elemente, die in der PriorityQueue gespeichert werden.</typeparam>
    /// <typeparam name="TPriority">Der Typ der Priorität, die zur Bestimmung der Reihenfolge der Elemente verwendet wird.</typeparam>
    public PriorityQueue(int capacity = 16, IComparer<TPriority>? customComparer = null)
    {
        _array = new (TElement, TPriority)[capacity];
        Count = 0;
        _comparer = customComparer ?? Comparer<TPriority>.Default;
    }

    /// <summary>
    ///     Ruft die Anzahl der Elemente in der PriorityQueue ab.
    /// </summary>
    /// <remarks>
    ///     Diese Eigenschaft repräsentiert die aktuelle Anzahl von Elementen,
    ///     die in der PriorityQueue gespeichert sind. Sie bietet eine schnelle Möglichkeit,
    ///     die Grösse der Warteschlange zu ermitteln, ohne direkt auf interne Strukturen zuzugreifen.
    /// </remarks>
    /// <value>
    ///     Die Anzahl der Elemente in der PriorityQueue.
    /// </value>
    public int Count { get; private set; }

    /// <summary>
    ///     Entfernt das Element mit der höchsten Priorität aus der PriorityQueue und gibt es zurück.
    ///     Diese Methode wird verwendet, um auf das oberste Element zuzugreifen und es gleichzeitig aus der Struktur zu
    ///     entfernen.
    ///     Wenn die PriorityQueue leer ist, wird eine Ausnahme ausgelöst.
    /// </summary>
    /// <returns>Das Element mit der höchsten Priorität, das aus der PriorityQueue entfernt wurde.</returns>
    public TElement Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("PriorityQueue is empty.");
        }

        var result = _array[0].Element;
        Count--;
        _array[0] = _array[Count];
        HeapifyDown(0);
        return result;
    }

    /// <summary>
    ///     Fügt ein neues Element mit einer definierten Priorität in die PriorityQueue ein.
    ///     Diese Methode wird verwendet, um Elemente mit einer entsprechenden Priorität zur Warteschlange hinzuzufügen,
    ///     wobei die Heap-Eigenschaft beibehalten wird.
    /// </summary>
    /// <param name="element">Das Element, das in die PriorityQueue eingefügt werden soll.</param>
    /// <param name="priority">Die Priorität des Elements, die bestimmt, wo es in der Warteschlange eingeordnet wird.</param>
    public void Enqueue(TElement element, TPriority priority)
    {
        if (Count == _array.Length)
        {
            Resize();
        }

        _array[Count] = (element, priority);
        HeapifyUp(Count);
        Count++;
    }

    /// <summary>
    ///     Gibt das oberste Element der PriorityQueue zurück, ohne es zu entfernen.
    ///     Diese Methode wird verwendet, um einen Blick auf das höchste Prioritätselement zu werfen,
    ///     ohne die zugrunde liegende Heap-Struktur zu verändern. Wenn die PriorityQueue leer ist,
    ///     wird eine Ausnahme ausgelöst.
    /// </summary>
    /// <returns>Das Element mit der höchsten Priorität in der PriorityQueue.</returns>
    public TElement Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("PriorityQueue is empty.");
        }

        return _array[0].Element;
    }

    /// <summary>
    ///     Stellt sicher, dass die Heap-Eigenschaft im darunterliegenden Array für die gegebene Indexposition beibehalten
    ///     wird.
    ///     Diese Methode wird verwendet, um ein Element im Heap nach unten zu verschieben, bis es an der korrekten Position
    ///     liegt.
    ///     Sie wird typischerweise nach dem Entfernen eines Elements aus dem Heap aufgerufen, um die Heap-Struktur
    ///     wiederherzustellen.
    /// </summary>
    /// <param name="index">Der Index des Elements, das innerhalb des Heaps nach unten bewegt werden soll.</param>
    private void HeapifyDown(int index)
    {
        while (true)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var largestIndex = index;

            // Prüfe, ob linkes höhere Priorität hat
            if (IsHigherPriority(leftChildIndex, largestIndex))
            {
                largestIndex = leftChildIndex;
            }

            // Prüfe, ob rechtes Kind höhere Priorität hat
            if (IsHigherPriority(rightChildIndex, largestIndex))
            {
                largestIndex = rightChildIndex;
            }

            // Wenn keine Änderung nötig ist, beenden
            if (largestIndex == index)
            {
                break;
            }

            // Tausche Elemente und gehe eine Ebene tiefer
            SwapElements(index, largestIndex);
            index = largestIndex;
        }
    }


    /// <summary>
    ///     Stellt sicher, dass die Heap-Eigenschaft im darunterliegenden Array für die gegebene Indexposition beibehalten
    ///     wird.
    ///     Diese Methode wird verwendet, um ein Element im Heap nach oben zu verschieben, bis es an der korrekten Position
    ///     liegt.
    ///     Sie wird typischerweise nach dem Hinzufügen eines neuen Elements zum Heap aufgerufen, um die Heap-Struktur
    ///     wiederherzustellen.
    /// </summary>
    /// <param name="index">Der Index des Elements, das innerhalb des Heaps nach oben bewegt werden soll.</param>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            // Position des Elternknotens berechnen
            var parentIndex = (index - 1) / 2;

            // Prüfen ob aktuelles Element grösser als Elternelement ist
            var shouldMoveUp = _comparer.Compare(_array[index].Priority, _array[parentIndex].Priority) < 0;
            if (!shouldMoveUp)
            {
                break;
            }

            // Elemente tauschen
            SwapElements(index, parentIndex);

            // Eine Ebene nach oben gehen
            index = parentIndex;
        }
    }

    /// <summary>
    ///     Prüft, ob das Element an einem bestimmten Index in der Warteschlange eine höhere Priorität
    ///     hat als das Element an einem anderen Index.
    /// </summary>
    /// <param name="childIndex">Der Index des potenziellen "Kind"-Elements in der Warteschlange.</param>
    /// <param name="compareIndex">Der Index des zu vergleichenden Elements in der Warteschlange.</param>
    /// <returns>Gibt true zurück, wenn das Element am angegebenen "childIndex" eine höhere Priorität hat; andernfalls false.</returns>
    private bool IsHigherPriority(int childIndex, int compareIndex)
    {
        return childIndex < Count && _comparer.Compare(_array[childIndex].Priority, _array[compareIndex].Priority) > 0;
    }

    /// <summary>
    ///     Passt die Grösse des internen Arrays an, wenn die Kapazität erreicht wurde.
    ///     Diese Methode verdoppelt die aktuelle Grösse des Arrays, um Platz für zusätzliche Elemente zu schaffen.
    ///     Sie wird automatisch aufgerufen, wenn neue Elemente hinzugefügt werden und das Array seine maximale Kapazität
    ///     erreicht.
    /// </summary>
    private void Resize()
    {
        Array.Resize(ref _array, _array.Length * 2);
    }

    /// <summary>
    ///     Tauscht die Positionen von zwei Elementen im internen Array des Heaps.
    ///     Diese Methode wird intern verwendet, um die Heap-Eigenschaft nach Operationen wie Einfügen oder Entfernen
    ///     wiederherzustellen.
    /// </summary>
    /// <param name="firstIndex">
    ///     Der Index des ersten Elements im Array, das getauscht werden soll.
    /// </param>
    /// <param name="secondIndex">
    ///     Der Index des zweiten Elements im Array, das getauscht werden soll.
    /// </param>
    private void SwapElements(int firstIndex, int secondIndex)
    {
        (_array[firstIndex], _array[secondIndex]) = (_array[secondIndex], _array[firstIndex]);
    }
}