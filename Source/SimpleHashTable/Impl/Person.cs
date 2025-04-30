namespace SimpleHashTable.Impl;

/// <summary>
///     Represents an individual with an identifier and a name.
/// </summary>
public sealed class Person : IPerson
{
    /// <summary>
    ///     Gets or sets the name of the person.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the unique identifier for the person.
    /// </summary>
    public int Id { get; set; }
}