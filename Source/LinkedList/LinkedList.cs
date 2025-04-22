using System.Collections;

namespace LinkedList;

/// <summary>
///     Represents a singly linked list data structure.
/// </summary>
public sealed class LinkedList : IEnumerable
{
    /// <summary>
    ///     Gets or sets the first node in the linked list.
    /// </summary>
    /// <remarks>
    ///     This property holds a reference to the first node in the linked list.
    ///     It can be used to traverse the list or manipulate its elements starting from the first node.
    /// </remarks>
    private Node FirstNode { get; set; }

    /// <summary>
    ///     Gets or sets the last node in the linked list.
    /// </summary>
    /// <remarks>
    ///     This property holds a reference to the last node in the linked list.
    ///     It can be used to append new elements or identify the end of the list.
    /// </remarks>
    private Node LastNode { get; set; }

    /// <summary>
    ///     Gets the number of elements contained in the linked list.
    /// </summary>
    /// <remarks>
    ///     This property represents the total count of nodes currently present in the linked list.
    ///     It is updated when elements are added or removed from the list.
    /// </remarks>
    public int Count { get; private set; }

    /// <summary>
    ///     Gets or sets the element at the specified index in the linked list.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <returns>The element at the specified index.</returns>
    /// <exception cref="IndexOutOfRangeException">
    ///     Thrown when the specified index is less than 0 or greater than or equal to the count of elements in the linked
    ///     list.
    /// </exception>
    public object this[int index]
    {
        get => FindByIndex(index).Item;
        set => FindByIndex(index).Item = value;
    }

    /// <summary>
    ///     Returns an enumerator that iterates through the linked list.
    /// </summary>
    /// <returns>
    ///     An enumerator that can be used to iterate through the linked list.
    /// </returns>
    // public IEnumerator GetEnumerator()
    // {
    //     return new LinkedListEnumerator(this);
    // }
    public IEnumerator GetEnumerator()
    {
        var node = FirstNode;

        while (node != null)
        {
            yield return node.Item;
            node = node.Next;
        }
    }

    /// <summary>
    ///     Removes all nodes from the linked list, resulting in an empty list.
    /// </summary>
    public void Clear()
    {
        FirstNode = null;
        LastNode = null;
        Count = 0;
    }

    /// <summary>
    ///     Adds an item to the end of the linked list.
    /// </summary>
    /// <param name="item">The object to add to the linked list.</param>
    public void Add(object item)
    {
        var newNode = new Node();
        newNode.Item = item;

        if (FirstNode == null)
        {
            FirstNode = newNode;
            LastNode = newNode;
        }
        else
        {
            LastNode.Next = newNode;
            LastNode = newNode;
        }

        Count++;
    }

    /// <summary>
    ///     Finds the first node in the linked list that contains the specified item.
    /// </summary>
    /// <param name="item">The item to search for within the linked list.</param>
    /// <returns>
    ///     The node that contains the specified item if found; otherwise, <c>null</c>.
    /// </returns>
    private Node Find(object item)
    {
        var currentNode = FirstNode;

        while (currentNode != null)
        {
            if (currentNode.Item.Equals(item))
            {
                return currentNode;
            }

            currentNode = currentNode.Next;
        }

        return null;
    }

    /// <summary>
    ///     Removes the first occurrence of the specified item from the linked list, if it exists.
    /// </summary>
    /// <param name="item">The object to remove from the linked list.</param>
    /// <returns>
    ///     <c>true</c> if the item was successfully removed from the linked list; otherwise, <c>false</c>.
    /// </returns>
    public bool Remove(object item)
    {
        var node = Find(item);

        if (node == null)
        {
            return false;
        }

        var previousNode = FindPrevious(item);

        // aus der Mitte entfernen
        if (previousNode != null)
        {
            previousNode.Next = node.Next;

            if (node == LastNode)
            {
                LastNode = previousNode;
            }
        }
        else
        {
            // aus dem Anfang entfernen
            FirstNode = node.Next;

            if (FirstNode == null)
            {
                LastNode = null;
            }
        }

        Count--;

        return true;
    }

    /// <summary>
    ///     Finds the node preceding the node containing the specified item in the linked list.
    /// </summary>
    /// <param name="item">The object to locate in the linked list.</param>
    /// <returns>
    ///     The node that precedes the node containing the specified item, or <c>null</c> if the item is not found or it is in
    ///     the first node.
    /// </returns>
    private Node FindPrevious(object item)
    {
        var currentNode = FirstNode;

        while (currentNode != null)
        {
            if (currentNode.Item.Equals(item))
            {
                return currentNode;
            }

            currentNode = currentNode.Next;
        }

        return null;
    }

    /// <summary>
    ///     Retrieves the node at the specified index in the linked list.
    /// </summary>
    /// <param name="index">The zero-based index of the node to locate.</param>
    /// <returns>
    ///     The node at the specified index in the linked list.
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">
    ///     Thrown if the specified index is less than 0 or greater than or equal to the count of elements in the linked list.
    /// </exception>
    private Node FindByIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        var currentNode = FirstNode;

        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
        }

        return currentNode;
    }

    /// <summary>
    ///     Represents a single node in a singly linked list.
    /// </summary>
    private sealed class Node
    {
        public object Item { get; set; }
        public Node Next { get; set; }
    }
}