using System.Text.Json;
using System.Text.Json.Serialization;

namespace BinaryTreeSample;

/// <summary>
///     Repräsentiert einen Knoten in einem binären Baum.
/// </summary>
/// <typeparam name="T">Der Typ der Daten, die im Knoten gespeichert werden.</typeparam>
public sealed class BinaryTreeNode<T>
{
    // -----------------------  JSON-Ausgabe  ---------------------------

    /// <summary>
    ///     Repräsentiert die JSON-Serialisierungsoptionen, die für die Serialisierung
    ///     eines Knotens mit seinen Kindknoten verwendet werden.
    ///     Definiert Eigenschaften wie Einrückung, Feldberücksichtigung und Zykluserkennung.
    /// </summary>
    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        WriteIndented = true,
        IncludeFields = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };

    /// <summary>
    ///     Verweist auf den linken Kindknoten im binären Baum.
    ///     Kann null sein, wenn kein linker Kindknoten existiert.
    /// </summary>
    public BinaryTreeNode<T>? Left;

    /// <summary>
    ///     Verweist auf den rechten Kindknoten im binären Baum.
    ///     Kann null sein, wenn kein rechter Kindknoten existiert.
    /// </summary>
    public BinaryTreeNode<T>? Right;

    /// <summary>
    ///     Speichert den Wert des aktuellen Knotens im binären Baum.
    ///     Repräsentiert die Nutzdaten, die mit diesem Knoten verknüpft sind.
    /// </summary>
    public T Value;

    /// <summary>
    ///     Repräsentiert einen einzelnen Knoten in einem binären Baum.
    /// </summary>
    /// <typeparam name="T">Der Datentyp des Wertes, der im Knoten gespeichert ist.</typeparam>
    public BinaryTreeNode(T value)
    {
        Value = value;
    }

    /// <summary>
    ///     Serialisiert den Knoten (inkl. Unterbäumen) als JSON-String.
    ///     Achtung: Je nach Baumgröße kann der String sehr groß werden.
    /// </summary>
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, JsonOpts);
    }
}