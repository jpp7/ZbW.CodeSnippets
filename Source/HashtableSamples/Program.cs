namespace HashtableSamples;

/// <summary>
/// Stellt die Hauptanwendung der Beispielimplementierung für Hash-Tabellen bereit.
/// </summary>
/// <remarks>
/// Die Klasse <c>Program</c> dient als Einstiegspunkt der Anwendung. Sie demonstriert die Verwendung
/// von drei verschiedenen Hash-Tabellen-Implementierungen: Verkettung, offenes Hashing und doppeltes Hashing.
/// Jede dieser Implementierungen wird verwendet, um Schlüssel-Wert-Paare einzufügen, Werte anhand der Schlüssel
/// abzurufen und die Ergebnisse an die Konsole auszugeben.
/// </remarks>
public sealed class Program
{
    /// <summary>
    /// Einstiegspunkt der Anwendung, welcher die Hauptlogik und Demonstration
    /// für die verschiedenen Hash-Tabellen-Implementierungen ausführt.
    /// </summary>
    /// <remarks>
    /// Dieser Einstiegspunkt erstellt drei Instanzen von Hash-Tabellen mit unterschiedlichen Implementierungen:
    /// Verkettung, offenes Hashing und doppeltes Hashing. Es fügt Schlüssel-Wert-Paare ein,
    /// ruft Werte basierend auf Schlüsseln ab und zeigt die Ergebnisse in der Konsole an.
    /// </remarks>
    public static void Main()
    {
        var ht1 = new HashTableChaining();
        var ht2 = new HashTableOpen();
        var ht3 = new HashTableDouble();

        ht1.Add(42, "Answer");
        ht2.Add(42, "Answer");
        ht3.Add(42, "Answer");

        Console.WriteLine(ht1.Get(42)); // → Answer
        Console.WriteLine(ht2.Get(42)); // → Answer
        Console.WriteLine(ht3.Get(42)); // → Answer

        Console.WriteLine("Done!!!");
    }
}