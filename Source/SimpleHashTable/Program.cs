using SimpleHashTable.Impl;

namespace SimpleHashTable;

/// <summary>
///     Represents the main program class containing the entry point for the application.
/// </summary>
/// <remarks>
///     The Program class is designed to demonstrate the functionality of a hash table
///     implementation. It initializes a hash table of Person objects, allows adding new
///     entries to the hash table, and demonstrates retrieving and displaying stored data.
/// </remarks>
public sealed class Program
{
    /// <summary>
    ///     The main entry point for the application.
    ///     Initializes and operates on a hash table of Person objects, allowing the addition,
    ///     retrieval, and display of information stored within the hash table.
    /// </summary>
    public static void Main()
    {
        var hashTable = new SimpleHashTable<int, IPerson>();

        var p1 = new Person { Name = "Hans", Id = 1 };
        var p2 = new Person { Name = "Peter", Id = 2 };
        var p3 = new Person { Name = "Anna", Id = 3 };
        var p4 = new Person { Name = "Maria", Id = 4 };

        hashTable.Add(p1.Id, p1);
        hashTable.Add(p2.Id, p2);
        hashTable.Add(p3.Id, p3);
        hashTable.Add(p4.Id, p4);

        Console.WriteLine($"HashTable: {hashTable.Count} Personen");

        var success = hashTable.TryGetValue(2, out var outPerson);

        if (success)
        {
            Console.WriteLine($"Success: {outPerson.Name}");
        }
        else
        {
            Console.WriteLine("Failed to find person with ID 2");
        }

        Console.WriteLine("Done!!!");
    }
}