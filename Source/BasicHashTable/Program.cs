namespace BasicHashTable;

/// <summary>
/// Die Program-Klasse stellt den Einstiegspunkt der Anwendung dar.
/// Diese Klasse enthält die Hauptlogik, die beim Start der Anwendung ausgeführt wird.
/// </summary>
internal class Program
{
    /// <summary>
    /// Der Einstiegspunkt der Anwendung.
    /// Diese Methode wird beim Start des Programms aufgerufen und führt die Kernlogik aus.
    /// </summary>
    private static void Main()
    {
        var table = new MyHashtable();
        table.Put("name", "Alice");
        table.Put("age", "30");
        table.Put("city", "Zurich");

        Console.WriteLine("Name: " + table.Get("name"));
        Console.WriteLine("Age: " + table.Get("age"));
        Console.WriteLine("City: " + table.Get("city"));
    }
}