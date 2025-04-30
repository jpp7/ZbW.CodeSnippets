namespace SimpleHashTable;

/// <summary>
///     Represents a simple hash table implementation that maps keys to values.
/// </summary>
/// <typeparam name="TKey">The type of the keys in the hash table.</typeparam>
/// <typeparam name="TValue">The type of the values in the hash table.</typeparam>
public sealed class SimpleHashTable<TKey, TValue>
{
    private const int InitialSize = 11; // Primzahl für bessere Verteilung
    private readonly LinkedList<KeyValuePair<TKey, TValue>>[] _buckets;

    /// <summary>
    ///     Represents a simple hash table implementation that maps keys of a specific type to values of a specific type.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the hash table.</typeparam>
    /// <typeparam name="TValue">The type of the values in the hash table.</typeparam>
    public SimpleHashTable()
    {
        _buckets = new LinkedList<KeyValuePair<TKey, TValue>>[InitialSize];
    }

    /// <summary>
    ///     Gets the total number of key-value pairs currently stored in the hash table.
    /// </summary>
    /// <remarks>
    ///     The value is determined by iterating through all the buckets and summing up
    ///     the counts of each bucket's elements.
    /// </remarks>
    /// <value>
    ///     The total number of entries in the hash table.
    /// </value>
    public int Count
    {
        get
        {
            var count = 0;
            foreach (var bucket in _buckets)
            {
                if (bucket != null)
                {
                    count += bucket.Count;
                }
            }

            return count;
        }
    }

    /// <summary>
    ///     Calculates the index of the bucket where the specified key should be stored in the hash table.
    /// </summary>
    /// <param name="key">The key for which to calculate the bucket index.</param>
    /// <returns>The index of the bucket that corresponds to the specified key.</returns>
    private int GetBucketIndex(TKey key)
    {
        return Math.Abs(key!.GetHashCode()) % _buckets.Length;
    }

    /// <summary>
    ///     Adds the specified key and value to the hash table. If the key already exists, an exception is thrown.
    /// </summary>
    /// <param name="key">The key associated with the value to add.</param>
    /// <param name="value">The value to add to the hash table.</param>
    /// <exception cref="ArgumentException">Thrown if the specified key already exists in the hash table.</exception>
    public void Add(TKey key, TValue value)
    {
        var index = GetBucketIndex(key);
        _buckets[index] ??= new LinkedList<KeyValuePair<TKey, TValue>>();

        // Prüfen, ob Schlüssel schon existiert
        foreach (var kv in _buckets[index])
        {
            if (EqualityComparer<TKey>.Default.Equals(kv.Key, key))
            {
                throw new ArgumentException("Key already exists");
            }
        }

        _buckets[index]!.AddLast(new KeyValuePair<TKey, TValue>(key, value));
    }

    /// <summary>
    ///     Attempts to retrieve the value associated with the specified key in the hash table.
    /// </summary>
    /// <param name="key">The key of the value to retrieve.</param>
    /// <param name="value">
    ///     When this method returns, contains the value associated with the specified key,
    ///     if the key is found; otherwise, the default value for the type of the value parameter.
    /// </param>
    /// <returns>True if the hash table contains an element with the specified key; otherwise, false.</returns>
    public bool TryGetValue(TKey key, out TValue? value)
    {
        var index = GetBucketIndex(key);
        if (_buckets[index] != null)
        {
            foreach (var kv in _buckets[index])
            {
                if (EqualityComparer<TKey>.Default.Equals(kv.Key, key))
                {
                    value = kv.Value;
                    return true;
                }
            }
        }

        value = default;
        return false;
    }
}