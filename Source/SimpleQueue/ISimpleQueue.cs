namespace SimpleQueue;

/// <summary>
///     Represents a simple queue that operates on a first-in, first-out (FIFO)
///     basis, providing basic methods to add, remove, and inspect items.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public interface ISimpleQueue<T>
{
    /// <summary>
    ///     Gets the number of elements contained in the queue.
    /// </summary>
    /// <remarks>
    ///     This property provides the current count of elements stored within the queue.
    ///     The count is updated dynamically as items are added to or removed from the queue.
    /// </remarks>
    int Count { get; }

    /// <summary>
    ///     Adds an item to the end of the queue.
    /// </summary>
    /// <param name="item">The item to add.</param>
    void Enqueue(T item);

    /// <summary>
    ///     Removes and returns the item at the front of the queue.
    /// </summary>
    /// <returns>The item at the front of the queue.</returns>
    T Dequeue();

    /// <summary>
    ///     Returns the item at the front of the queue without removing it.
    /// </summary>
    /// <returns>The item at the front of the queue.</returns>
    T Peek();

    /// <summary>
    ///     Clears all items from the queue.
    /// </summary>
    void Clear();
}