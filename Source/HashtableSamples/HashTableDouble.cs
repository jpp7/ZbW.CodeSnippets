namespace HashtableSamples;

/// <summary>
/// Die Klasse <c>HashTableDouble</c> implementiert eine Hashtabelle,
/// die die Technik des doppelten Hashings zur Konfliktlösung verwendet.
/// </summary>
/// <remarks>
/// Das doppelte Hashing wird genutzt, um die Position einer einzufügenden
/// oder zu suchenden Schlüssel-Wert-Paarung zu definieren. Zwei voneinander
/// unabhängige Hashfunktionen bestimmen Haupt- und Schrittweite im Fall
/// eines Kollisionskonflikts. Die Kapazität der Hashtabelle wird dynamisch
/// angepasst, wenn ein festgelegter maximaler Ladefaktor überschritten wird.
/// </remarks>
/// <example>
/// Die Klasse unterstützt Grundoperationen wie das Speichern, Abrufen und
/// Entfernen von Schlüssel-Wert-Kombinationen, indem eine effiziente
/// Suche dank Hashing gewährleistet wird.
/// </example>
/// <param name="capacity">
/// Die anfängliche Kapazität der Hashtabelle, standardmässig 17.
/// Die Kapazität sollte prim sein, um den optimalen Einsatz des doppelten
/// Hashings zu gewährleisten.
/// </param>
/// <exception cref="ArgumentException">
/// Wird möglicherweise bei ungültigen Eingaben durch Methoden der Klasse ausgelöst.
/// </exception>
/// <threadsafety>
/// Diese Implementierung ist nicht threadsicher. Im multithreaded Kontext
/// müssen notwendige Synchronisationen extern implementiert werden.
/// </threadsafety>
public class HashTableDouble
{
    /// <summary>
    /// Repräsentiert die interne Tabelle, die in der Hash-Tabellen-Implementierung verwendet wird.
    /// Enthält Tupel bestehend aus einem Ganzzahlwert als Schlüssel,
    /// einem String als Wert und einem Bool, um anzuzeigen, ob der Eintrag belegt ist.
    /// </summary>
    private (int key, string value, bool occupied)[] _table;

    /// <summary>
    /// Gibt den maximal zulässigen Lastfaktor der Hash-Tabelle an, bevor eine
    /// Vergrösserung (Resize) der Tabelle durchgeführt wird.
    /// Der Lastfaktor wird als Verhältnis zwischen der Anzahl gespeicherter
    /// Elemente und der Gesamtkapazität der Tabelle berechnet.
    /// </summary>
    private const double LoadFactorMax = 0.7;

    /// <summary>
    /// Gibt die Anzahl der derzeit gespeicherten Elemente in der Hash-Tabelle an.
    /// Wird verwendet, um das Einfügen und Entfernen von Elementen zu verfolgen
    /// sowie Bedingungen wie das maximale Verhältnis der Auslastung zu überprüfen.
    /// </summary>
    private int _count;

    /// <summary>
    /// Repräsentiert eine Hash-Tabelle, die eine doppelte Hashing-Strategie verwendet,
    /// um den Speicherplatz effizient zu nutzen und Kollisionen zu minimieren.
    /// </summary>
    public HashTableDouble(int capacity = 17) => _table = new (int, string, bool)[capacity];

    /// <summary>
    /// Berechnet den primären Hash-Wert für einen gegebenen Schlüssel basierend auf dessen HashCode.
    /// Wird verwendet, um den Index der Hash-Tabelle zu bestimmen.
    /// </summary>
    /// <param name="key">Der Schlüssel, dessen primärer Hash-Wert berechnet werden soll.</param>
    /// <returns>Der berechnete primäre Hash-Wert innerhalb der Grenzen der Hash-Tabelle.</returns>
    private int Hash1(int key) => Math.Abs(key.GetHashCode()) % _table.Length; // Math.Abs entfernt das Vorzeichenbit

    /// <summary>
    /// Berechnet einen zweiten Hashwert basierend auf dem gegebenen Schlüssel, um den Sprungwert
    /// in der doppelten Hashing-Strategie zu bestimmen.
    /// </summary>
    /// <param name="key">Der Schlüssel, für den der zweite Hashwert berechnet werden soll.</param>
    /// <returns>Der zweite Hashwert, der für die Sprungberechnung in der Hash-Tabelle verwendet wird.</returns>
    private int Hash2(int key) => 1 + (Math.Abs(key.GetHashCode()) % (_table.Length - 2)); // garantiert ≠0

    /// <summary>
    /// Vergrössert die Kapazität der Hash-Tabelle durch Allokation eines neuen Speicherbereichs
    /// und Übertragen bestehender Einträge. Die neue Kapazität wird als nächste Primzahl
    /// des doppelten aktuellen Speichers festgelegt, um die Verteilung zu optimieren.
    /// </summary>
    private void Resize()
    {
        var old = _table;
        _table = new (int, string, bool)[PrimeNext(_table.Length * 2)];
        _count = 0;
        foreach (var (k, v, occ) in old)
        {
            if (occ)
            {
                Add(k, v);
            }
        }
    }

    /// <summary>
    /// Fügt einen neuen Schlüssel-Wert-Paar in die Hash-Tabelle ein.
    /// Wenn der Schlüssel bereits existiert, wird der Wert überschrieben.
    /// Die Methode verwendet doppeltes Hashing, um Kollisionen zu behandeln.
    /// Bei Überschreitung des maximalen Ladefaktors wird die Grösse der Tabelle automatisch angepasst.
    /// </summary>
    /// <param name="key">Der Schlüssel des einzufügenden Elements.</param>
    /// <param name="value">Der Wert, der mit dem angegebenen Schlüssel verknüpft werden soll.</param>
    public void Add(int key, string value)
    {
        if ((double)_count / _table.Length > LoadFactorMax)
        {
            Resize();
        }

        int idx = Hash1(key);
        int step = Hash2(key);

        while (_table[idx].occupied && _table[idx].key != key)
        {
            idx = (idx + step) % _table.Length; // zweiter Hash bestimmt den Sprung
        }

        if (!_table[idx].occupied)
        {
            _count++;
        }

        _table[idx] = (key, value, true);
    }

    /// <summary>
    /// Ruft den Wert ab, der mit dem angegebenen Schlüssel in der Hash-Tabelle verbunden ist.
    /// </summary>
    /// <param name="key">Der Schlüssel, dessen zugehöriger Wert abgerufen werden soll.</param>
    /// <returns>
    /// Den Wert, der dem angegebenen Schlüssel zugeordnet ist,
    /// oder <c>null</c>, wenn der Schlüssel in der Tabelle nicht gefunden wird.
    /// </returns>
    public string? Get(int key)
    {
        int idx = Hash1(key);
        int step = Hash2(key);

        while (_table[idx].occupied)
        {
            if (_table[idx].key == key)
            {
                return _table[idx].value;
            }

            idx = (idx + step) % _table.Length;
        }

        return null;
    }

    /// <summary>
    /// Entfernt ein Element mit dem angegebenen Schlüssel aus der Hash-Tabelle.
    /// </summary>
    /// <param name="key">Der Schlüssel des Elements, das entfernt werden soll.</param>
    /// <returns>
    /// Gibt <c>true</c> zurück, wenn das Element erfolgreich entfernt wurde, andernfalls <c>false</c>,
    /// falls der Schlüssel nicht in der Hash-Tabelle gefunden wurde.
    /// </returns>
    public bool Remove(int key)
    {
        int idx = Hash1(key);
        int step = Hash2(key);

        while (_table[idx].occupied)
        {
            if (_table[idx].key == key)
            {
                _table[idx].occupied = false;
                _count--;
                return true;
            }

            idx = (idx + step) % _table.Length;
        }

        return false;
    }

    /// <summary>
    /// Gibt die nächste Primzahl zurück, die grösser oder gleich der angegebenen Zahl ist.
    /// </summary>
    /// <param name="n">Die Zahl, von der die nächste Primzahl berechnet werden soll.</param>
    /// <returns>Die nächste Primzahl, die grösser oder gleich der angegebenen Zahl ist.</returns>
    private static int PrimeNext(int n)
    {
        while (!IsPrime(n))
        {
            n++;
        }

        return n;
    }

    /// <summary>
    /// Bestimmt, ob eine gegebene Zahl eine Primzahl ist.
    /// </summary>
    /// <param name="x">Die zu überprüfende Zahl.</param>
    /// <returns>True, wenn die Zahl eine Primzahl ist; andernfalls false.</returns>
    private static bool IsPrime(int x)
    {
        if (x < 2)
        {
            return false;
        }

        for (int i = 2; i * i <= x; i++)
        {
            if (x % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}