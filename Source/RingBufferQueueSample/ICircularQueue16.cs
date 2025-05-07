namespace RingBufferQueueSample.Impl;

/// <summary>
///     Represents a circular queue with a fixed size of 16 elements. The queue
///     automatically overwrites the oldest elements when the maximum capacity is reached.
/// </summary>
/// <typeparam name="T">The type of elements stored in the circular queue.</typeparam>
public interface ICircularQueue16<T> : IEnumerable<T>
{
    /// <summary>Anzahl aktuell gespeicherter Elemente (max 16).</summary>
    int Count { get; }

    /// <summary>Fügt ein Element hinzu; bei Überlauf wird das älteste überschrieben.</summary>
    void Enqueue(T item);

    /// <summary>Entfernt und liefert das älteste Element. Throws, wenn leer.</summary>
    T Dequeue();
}