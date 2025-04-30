namespace SimpleQueue;

/// <summary>
///     Represents a person with a unique identifier and a name.
/// </summary>
public interface IPerson
{
    /// <summary>
    ///     Gets or sets the name of the person.
    /// </summary>
    /// <remarks>
    ///     The name is a string representing the individual's name. This property can be used
    ///     to retrieve or modify the name of a person.
    /// </remarks>
    string Name { get; set; }

    /// <summary>
    ///     Gets or sets the unique identifier of the person.
    /// </summary>
    /// <remarks>
    ///     The identifier is an integer representing the unique identity of a person.
    ///     This property can be used to retrieve or assign the person's unique ID.
    /// </remarks>
    int Id { get; set; }
}