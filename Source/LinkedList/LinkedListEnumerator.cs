using System.Collections;

namespace LinkedList;

/// <summary>
///     Provides an enumerator for iterating through a <see cref="LinkedList" />.
/// </summary>
public class LinkedListEnumerator : IEnumerator
{
    private int _index;

    /// <summary>
    ///     Provides an enumerator to iterate over the elements of a <see cref="LinkedList" />.
    /// </summary>
    public LinkedListEnumerator(LinkedList list)
    {
        List = list;
        _index = -1;
    }

    /// <summary>
    ///     Represents a collection of elements as a list structure in the implementation.
    /// </summary>
    /// <remarks>
    ///     This property provides access to a list of elements used internally.
    ///     Typically, it allows enumeration or manipulation of the underlying elements.
    /// </remarks>
    private LinkedList List { get; }

    /// <summary>
    ///     Advances the enumerator to the next element of the <see cref="LinkedList" />.
    /// </summary>
    /// <returns>
    ///     <c>true</c> if the enumerator was successfully advanced to the next element;
    ///     <c>false</c> if the enumerator has passed the end of the collection.
    /// </returns>
    public bool MoveNext()
    {
        ++_index;
        if (_index >= List.Count)
        {
            return false;
        }

        Current = List[_index];

        return true;
    }

    /// <summary>
    ///     Resets the enumerator to its initial position, which is before the first element in the <see cref="LinkedList" />.
    /// </summary>
    public void Reset()
    {
        _index = -1;
    }

    /// <summary>
    ///     Gets the current element in the <see cref="LinkedList" /> during iteration.
    /// </summary>
    /// <remarks>
    ///     This property retrieves the element at the current position of the enumerator.
    ///     It is updated each time <c>MoveNext</c> is successfully called. If the enumerator
    ///     is positioned before the first element or after the last element, accessing this
    ///     property will result in an undefined value.
    /// </remarks>
    public object Current { get; private set; }
}