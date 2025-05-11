// See https://aka.ms/new-console-template for more information

/// <summary>
/// Eine versiegelte Klasse, die das Hauptprogramm und eine Methode zur Durchführung einer binären Suche definiert.
/// </summary>
public sealed class Program
{
    /// Der Einstiegspunkt der Anwendung. Führt das Hauptprogramm aus, das eine binäre Suche auf einem sortierten Array durchführt und die Ergebnisse ausgibt.
    public static void Main()
    {
        int[] numbers = { 11, 22, 33, 44, 55, 66, 77, 88, 98, 111 };

        var index = BinarySearch(numbers, 88);

        Console.WriteLine($"Gefunden an der Position: {index}");
        Console.WriteLine("Done!!!");
    }


    /// Führt eine binäre Suche auf einem sortierten Array von Ganzzahlen durch, um einen bestimmten Schlüssel zu finden.
    /// <param name="numbers">Das sortierte Array von Ganzzahlen, in dem gesucht werden soll.</param>
    /// <param name="key">Der Wert, der im Array gesucht wird.</param>
    /// <return>Der Index des gefundenen Schlüssels im Array oder -1, wenn der Schlüssel nicht gefunden wurde.</return>
    public static int BinarySearch(int[] numbers, int key)
    {
        int low = 0;    // Start-Index
            int high = numbers.Length - 1; // End-Index

        while (low <= high) // solange der Suchbereich gültig ist
        {
            int mid = low + ((high - low) >> 1); // gleiche wie /2, aber ohne Overflow-Risiko
            /*Was bedeutet >> 1 genau?
            Bitshift-Operator in C#
            x >> 1 ⇒ verschiebe alle Bits von x um eine Position nach rechts.
            Bei positiven Zahlen entspricht das ganzzahligen Teilen durch 2.
                        Beispiel: 6 (0b110) >> 1 → 3 (0b11).
                        Bei negativen Zahlen ist das Ergebnis nicht immer gleich.
            */
            if (numbers[mid] == key) // Schlüssel gefunden
                return mid;

            if (key < numbers[mid]) // Schlüssel ist kleiner als die Mitte
                high = mid - 1;
            else
                low = mid + 1;
        }

        return -1; // nicht gefunden
    }
}