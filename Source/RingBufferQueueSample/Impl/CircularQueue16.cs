using System.Collections;

namespace RingBufferQueueSample.Impl;

/// <summary>
///     Represents a circular buffer queue with a fixed capacity of 16 elements.
///     When the queue is full, the oldest element is overwritten by the newest element.
/// </summary>
/// <typeparam name="T">The type of elements stored in the queue.</typeparam>
public sealed class CircularQueue16<T> : ICircularQueue16<T>
{
    private const int Capacity = 16; // feste Größe
    private readonly T[] _buffer = new T[Capacity];
    private int _head; // Index des ältesten Elements

    /// <summary>Fügt ein Element hinzu; bei Überlauf wird das älteste überschrieben.</summary>
    public void Enqueue(T item)
    {
        var tail = (_head + Count) & 0xF; // % 16 via Bitmaske
        _buffer[tail] = item;

        if (Count == Capacity) // Puffer voll → Head eins weiter
        {
            _head = (_head + 1) &
                    0xF; // % 16 via Bitmaske - So wird aus 16 wieder, aus 17 wieder 1 usw. – genau wie bei aber ohne die (relativ teure) Division‑Mod‑Operation.
            // Voraussetzung: Die Kapazität ist eine Zweierpotenz (hier16). Für 32 würde man &0x1F, für 8 &0x7 usw.
        }
        else
        {
            Count++;
        }
    }

    /// <summary>Entfernt und liefert das älteste Element. Throws, wenn leer.</summary>
    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue empty");
        }

        var item = _buffer[_head];
        _head = (_head + 1) &
                0xF; // % 16 via Bitmaske - So wird aus 16 wieder, aus 17 wieder 1 usw. – genau wie bei aber ohne die (relativ teure) Division‑Mod‑Operation.
        // Voraussetzung: Die Kapazität ist eine Zweierpotenz (hier16). Für 32 würde man &0x1F, für 8 &0x7 usw.
        Count--;
        return item;
    }

    /// <summary>Anzahl aktuell gespeicherter Elemente (max 16).</summary>
    public int Count { get; private set; }

    /// <summary>
    ///     Returns an enumerator that iterates through the elements in the queue in order from oldest to newest.
    /// </summary>
    /// <returns>An enumerator for iterating through the queue.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return _buffer[(_head + i) & 0xF];
        }
    }

    /// <summary>
    ///     Returns an enumerator that iterates through the elements in the queue in order from oldest to newest.
    /// </summary>
    /// <returns>An enumerator for iterating through the queue.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}