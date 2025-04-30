namespace SimpleQueue;

/// <summary>
///     Represents a simple first-in, first-out (FIFO) queue of elements of type T.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public sealed class SimpleQueue<T>
{
    /// <summary>
    ///     Represents the underlying storage of the queue elements, implemented as a linked list of type <see cref="T" />.
    /// </summary>
    /// <remarks>
    ///     This field is used internally to manage the elements of the queue in a first-in, first-out (FIFO) manner.
    /// </remarks>
    private readonly LinkedList<T> _list = new();

    /// <summary>
    ///     Gets the number of elements contained in the queue.
    /// </summary>
    /// <value>
    ///     The total number of elements currently stored in the queue.
    /// </value>
    /// <remarks>
    ///     This property provides the current count of elements in the queue. It reflects the number
    ///     of elements that were added via <c>Enqueue</c> and haven't yet been removed via <c>Dequeue</c>.
    /// </remarks>
    public int Count => _list.Count;

    /// <summary>
    ///     Adds an element to the end of the queue.
    /// </summary>
    /// <param name="item">The element of type <typeparamref name="T" /> to add to the queue.</param>
    public void Enqueue(T item)
    {
        _list.AddLast(item);
    }

    /// <summary>
    ///     Removes and returns the element at the front of the queue.
    /// </summary>
    /// <returns>The element of type <typeparamref name="T" /> at the front of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public T Dequeue()
    {
        if (_list.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var value = _list.First!.Value;
        _list.RemoveFirst();
        return value;
    }

    /// <summary>
    ///     Returns the element at the front of the queue without removing it.
    /// </summary>
    /// <returns>The element of type <typeparamref name="T" /> at the front of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty.</exception>
    public T Peek()
    {
        if (_list.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _list.First!.Value;
    }

    /// <summary>
    ///     Removes all elements from the queue.
    /// </summary>
    /// <remarks>
    ///     After calling this method, the queue will be empty, and its count will be zero.
    /// </remarks>
    public void Clear()
    {
        _list.Clear();
    }
}