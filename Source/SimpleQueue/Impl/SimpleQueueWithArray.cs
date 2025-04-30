namespace SimpleQueue.Impl;

/// Represents a simple queue implementation using an array.
public sealed class SimpleQueueWithArray<T> : ISimpleQueue<T>
{
    private T[] _items;

    /// Represents a simple queue implemented using an array.
    /// This class provides basic queue functionalities such as enqueue, dequeue, peek, and clear.
    /// It manages the elements sequentially in an internally allocated fixed-size array.
    public SimpleQueueWithArray(int length = 10)
    {
        _items = new T[length];
    }

    /// <summary>
    ///     Gets the number of elements contained in the queue.
    /// </summary>
    /// <remarks>
    ///     Represents the total number of elements that have been added to the queue and are currently stored within it.
    /// </remarks>
    /// <value>
    ///     The number of elements the queue currently holds.
    /// </value>
    public int Count { get; private set; }


    /// Adds the specified item to the end of the queue.
    /// <param name="item">
    ///     The item to add to the queue.
    /// </param>
    public void Enqueue(T item)
    {
        if (Count == _items.Length)
        {
            var newItems = new T[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }

        _items[Count++] = item;
    }

    /// Removes and returns the element at the front of the queue.
    /// <returns>
    ///     The element that was at the front of the queue.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the queue is empty.
    /// </exception>
    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        var value = _items[0];
        Array.Copy(_items, 1, _items, 0, Count - 1);
        Count--;
        return value;
    }

    /// Returns the element at the front of the queue without removing it.
    /// <returns>
    ///     The element at the front of the queue.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the queue is empty.
    /// </exception>
    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return _items[0];
    }

    /// Removes all elements from the queue and resets its state.
    /// After calling this method, the queue will be empty, and its count will be reset to zero.
    public void Clear()
    {
        _items = new T[10];
        Count = 0;
    }
}