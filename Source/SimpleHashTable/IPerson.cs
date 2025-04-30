namespace SimpleHashTable;

/// <summary>
///     Represents an individual with a unique identifier and a name.
/// </summary>
public interface IPerson
{
    /// <summary>
    ///     Gets or sets the name of the person. The name typically represents a descriptive identifier
    ///     for the individual, such as a first name, full name, or alias.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    ///     Gets or sets the unique identifier of the individual.
    ///     This identifier is typically used to distinguish one person from another.
    /// </summary>
    int Id { get; set; }
}