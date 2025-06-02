namespace HeapPriorityqueueSample;

/// <summary>
///     Die Klasse <c>Heap</c> implementiert eine generische Heap-Datenstruktur.
///     Ein Heap ist eine spezielle Baumstruktur, die typischerweise in Prioritätswarteschlangen verwendet wird.
///     Er unterstützt effiziente Einsätze wie das Hinzufügen (Enqueue) und Entfernen (Dequeue) von Elementen.
///     Die Elemente werden gemäss der definierten Vergleichslogik <see cref="IComparer{T}" /> sortiert.
/// </summary>
/// <typeparam name="T">
///     Der Typ der im Heap gespeicherten Elemente. Der Typ T muss mit dem bereitgestellten <see cref="IComparer{T}" />
///     vergleichbar sein,
///     oder, wenn kein benutzerdefinierter Comparer angegeben ist, mit dem Standardcomparierer für T.
/// </typeparam>
public sealed class Heap<T>
{
    private readonly IComparer<T> _comparer;
    private T[] _array;

    /// <summary>
    ///     Repräsentiert einen generischen Heap, der für die Prioritätswarteschlange verwendet werden kann.
    ///     Bietet Funktionen wie das Hinzufügen, Entfernen und Abrufen von Elementen in einer Heap-Datenstruktur.
    /// </summary>
    /// <typeparam name="T">
    ///     Der Typ der Elemente, die im Heap gespeichert werden.
    /// </typeparam>
    public Heap(int capacity = 16, IComparer<T>? comparer = null)
    {
        _array = new T[capacity];
        _comparer = comparer ?? Comparer<T>.Default;
        Count = 0;
    }

    /// <summary>
    ///     Gibt die aktuelle Anzahl der im Heap enthaltenen Elemente zurück.
    /// </summary>
    /// <remarks>
    ///     Der Wert dieser Eigenschaft entspricht der Anzahl der Elemente, die aktuell im Heap gespeichert sind.
    ///     Diese Zahl wird bei Hinzufügung oder Entfernung von Elementen dynamisch angepasst.
    /// </remarks>
    public int Count { get; private set; }

    /// <summary>
    ///     Entfernt das oberste Element im Heap und gibt es zurück.
    /// </summary>
    /// <returns>
    ///     Das entfernte oberste Element im Heap.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Wird ausgelöst, wenn der Heap leer ist.
    /// </exception>
    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        var result = _array[0];
        Count--;
        _array[0] = _array[Count];
        _array[Count] = default!;
        HeapifyDown(0);
        return result;
    }

    /// <summary>
    ///     Fügt ein neues Element in den Heap ein und stellt sicher, dass die Heap-Eigenschaft erhalten bleibt.
    /// </summary>
    /// <param name="item">
    ///     Das hinzuzufügende Element.
    /// </param>
    public void Enqueue(T item)
    {
        if (Count == _array.Length)
        {
            Resize();
        }

        _array[Count] = item;
        HeapifyUp(Count);
        Count++;
    }

    /// <summary>
    ///     Gibt das oberste Element im Heap zurück, ohne es zu entfernen.
    /// </summary>
    /// <returns>
    ///     Das oberste Element im Heap.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Wird ausgelöst, wenn der Heap leer ist.
    /// </exception>
    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        return _array[0];
    }

    /// <summary>
    ///     Ordnet Elemente im Heap um, um die Heap-Eigenschaft basierend auf einem gegebenen Index wiederherzustellen.
    /// </summary>
    /// <param name="index">
    ///     Der Startindex, bei dem der Anpassungsprozess im Heap beginnt.
    /// </param>
    /// <remarks>
    ///     Diese Methode bewegt ein Element vom gegebenen Index iterativ nach unten im Baum,
    ///     bis die Heap-Eigenschaft für alle untergeordneten Knoten erfüllt ist.
    ///     Es wird die passende Position basierend auf den Vergleichswerten bestimmt,
    ///     abhängig von der verwendeten Vergleichslogik (_comparer).
    /// </remarks>
    private void HeapifyDown(int index)
    {
        while (true)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var largestIndex = index;

            // Prüfe ob linkes Kind grösser ist
            if (IsValidIndexAndGreater(leftChildIndex, largestIndex))
            {
                largestIndex = leftChildIndex;
            }

            // Prüfe ob rechtes Kind grösser ist
            if (IsValidIndexAndGreater(rightChildIndex, largestIndex))
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
    ///     Ordnet Elemente im Heap um, um die Heap-Eigenschaft basierend auf einem gegebenen Index wiederherzustellen.
    /// </summary>
    /// <param name="index">
    ///     Der Startindex, bei dem der Anpassungsprozess im Heap beginnt.
    /// </param>
    /// <remarks>
    ///     Diese Methode bewegt ein Element vom gegebenen Index iterativ nach oben im Baum,
    ///     bis die Heap-Eigenschaft wieder erfüllt ist.
    ///     Es wird die passende Position basierend auf den Vergleichswerten bestimmt,
    ///     abhängig von der verwendeten Vergleichslogik (_comparer).
    /// </remarks>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            // Position des Elternknotens berechnen
            var parentIndex = (index - 1) / 2;

            // Prüfen ob aktuelles Element grösser als Elternelement ist
            var shouldMoveUp = _comparer.Compare(_array[index], _array[parentIndex]) > 0;
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
    ///     Überprüft, ob ein bestimmter Index innerhalb der Grenzen des Heaps liegt
    ///     und ob das Element an diesem Index grösser ist als ein anderes Element.
    /// </summary>
    /// <param name="childIndex">
    ///     Der Index des zu überprüfenden Elements im Heap.
    /// </param>
    /// <param name="compareIndex">
    ///     Der Index des Elements, mit dem verglichen werden soll.
    /// </param>
    /// <returns>
    ///     <c>true</c>, wenn der übergebene childIndex gültig ist und das Element grösser ist
    ///     als das Element am compareIndex; andernfalls <c>false</c>.
    /// </returns>
    private bool IsValidIndexAndGreater(int childIndex, int compareIndex)
    {
        return childIndex < Count && _comparer.Compare(_array[childIndex], _array[compareIndex]) > 0;
    }


    /// <summary>
    ///     Vergrössert die interne Kapazität des Heaps, um zusätzlichen Speicherplatz für weitere Elemente bereitzustellen.
    /// </summary>
    /// <remarks>
    ///     Diese Methode verdoppelt die aktuelle Grösse des internen Arrays, welches zur Speicherung der Elemente genutzt wird.
    ///     Sie wird aufgerufen, wenn die Anzahl der Elemente (_size) die aktuelle Kapazität des Arrays (_array.Length)
    ///     erreicht.
    /// </remarks>
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