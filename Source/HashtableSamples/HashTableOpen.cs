namespace HashtableSamples;

/// <summary>
/// Implementiert eine Hashtabelle mit offenem Adressieren zur Speicherung von Schlüssel-Wert-Paaren,
/// wobei Schlüssel als Integer und Werte als Strings gespeichert werden.
/// </summary>
/// <remarks>
/// Hauptmerkmale dieser Implementierung:
/// <list type="bullet">
/// <item><description>Verwendet lineare Sondierung zur Kollisionsauflösung</description></item>
/// <item><description>Implementiert eine Lazy-Deletion-Strategie für gelöschte Elemente</description></item>
/// <item><description>Führt automatische Größenanpassung durch, wenn der Auslastungsfaktor 0,7 übersteigt</description></item>
/// <item><description>Verwendet Primzahlen für die interne Array-Größe zur Minimierung von Clustering</description></item>
/// <item><description>Bietet eine standardmäßige Anfangskapazität von 17 Elementen</description></item>
/// <item><description>Erlaubt das Überschreiben existierender Schlüssel-Wert-Paare</description></item>
/// <item><description>Verwendet eine modulare Hashfunktion mit vorzeichenloser Transformation</description></item>
/// <item><description>Unterstützt grundlegende Operationen: Einfügen (Add), Abrufen (Get) und Löschen (Remove)</description></item>
/// </list>
/// </remarks>
public sealed class HashTableOpen
{
    /// <summary>
    /// Stellt das interne Array der Hash-Tabelle dar,
    /// welches die gespeicherten Schlüssel-Wert-Paare sowie ihren Belegungsstatus enthält.
    /// Das Array verwendet ein Tupel, das aus einem Schlüssel (int), einem Wert (string) und einem Belegungs-Flag (bool) besteht.
    /// </summary>
    private (int key, string value, bool occupied)[] _table;

    /// <summary>
    /// Gibt das maximale Verhältnis zwischen belegten Slots und der gesamten Kapazität
    /// des internen Arrays an, das vor einem Resize ausgelöst wird.
    /// Wird verwendet, um die Leistungsfähigkeit der Hash-Tabelle aufrechtzuerhalten,
    /// indem eine Überfüllung vermieden wird.
    /// </summary>
    private const double LoadFactorMax = 0.7;

    /// <summary>
    /// Stellt die aktuelle Anzahl der in der Hash-Tabelle gespeicherten Schlüssel-Wert-Paare dar.
    /// Diese Variable wird verwendet, um die Belegung der Hash-Tabelle zu verfolgen und
    /// gegebenenfalls eine Grössenskalierung (Resize) auszulösen, wenn die maximale Auslastung überschritten wird.
    /// </summary>
    private int _count;

    /// <summary>
    /// Stellt eine Implementierung einer Hash-Tabelle mit offenem Adressieren bereit,
    /// die für die Speicherung und Abfrage von Schlüssel-Wert-Paaren genutzt werden kann.
    /// </summary>
    public HashTableOpen(int capacity = 17) => _table = new (int, string, bool)[capacity];

    /// <summary>
    /// Berechnet den Hash-Wert für einen gegebenen Schlüssel, der zur Bestimmung des Speicherorts
    /// im internen Array der Hash-Tabelle verwendet wird.
    /// </summary>
    /// <param name="key">Der Schlüssel, für den der Hash-Wert berechnet werden soll.</param>
    /// <returns>Den berechneten Hash-Wert als Integer, der einem Index im internen Array entspricht.</returns>
    private int Hash(int key) => Math.Abs(key.GetHashCode()) % _table.Length; // Math.Abs entfernt das Vorzeichenbit

    /// <summary>
    /// Vergrössert die Kapazität der internen Datenstruktur der Hash-Tabelle und
    /// verteilt die bestehenden Schlüssel-Wert-Paare entsprechend der neuen Grösse, um
    /// die Effizienz und die Lastverteilung der Hash-Tabelle aufrechtzuerhalten.
    /// Diese Methode wird automatisch aufgerufen, wenn die maximale Auslastung
    /// überschritten wird.
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
    /// Fügt ein Schlüssel-Wert-Paar in die Hash-Tabelle ein.
    /// Wenn der Schlüssel bereits existiert, wird der zugehörige Wert aktualisiert.
    /// Beim Überschreiten des maximalen Auslastungsfaktors wird die Hash-Tabelle automatisch vergrössert.
    /// </summary>
    /// <param name="key">Der Schlüssel, unter dem der Wert gespeichert werden soll.</param>
    /// <param name="value">Der mit dem Schlüssel verknüpfte Wert, der gespeichert werden soll.</param>
    public void Add(int key, string value)
    {
        if ((double)_count / _table.Length > LoadFactorMax)
        {
            Resize();
        }

        int idx = Hash(key);
        while (_table[idx].occupied && _table[idx].key != key)
        {
            idx = (idx + 1) % _table.Length; // lineares Sondieren
        }

        if (!_table[idx].occupied)
        {
            _count++;
        }

        _table[idx] = (key, value, true);
    }

    /// <summary>
    /// Ruft den Wert ab, der mit dem angegebenen Schlüssel verknüpft ist, oder gibt null zurück,
    /// wenn der Schlüssel nicht in der Hash-Tabelle vorhanden ist.
    /// </summary>
    /// <param name="key">Der Schlüssel, dessen zugehöriger Wert abgerufen werden soll.</param>
    /// <returns>Der mit dem Schlüssel verknüpfte Wert, oder null, wenn der Schlüssel nicht gefunden wird.</returns>
    public string? Get(int key)
    {
        int idx = Hash(key);
        while (_table[idx].occupied)
        {
            if (_table[idx].key == key)
            {
                return _table[idx].value;
            }

            idx = (idx + 1) % _table.Length;
        }

        return null;
    }

    /// <summary>
    /// Entfernt das Element mit dem angegebenen Schlüssel aus der Hash-Tabelle, falls dieses existiert.
    /// </summary>
    /// <param name="key">Der Schlüssel des zu entfernenden Elements.</param>
    /// <returns>
    /// Gibt <c>true</c> zurück, wenn das Element erfolgreich entfernt wurde, andernfalls <c>false</c>,
    /// falls kein Element mit diesem Schlüssel in der Hash-Tabelle vorhanden ist.
    /// </returns>
    public bool Remove(int key)
    {
        int idx = Hash(key);
        while (_table[idx].occupied)
        {
            if (_table[idx].key == key)
            {
                _table[idx].occupied = false; // markiere Slot als gelöscht (lazy deletion)
                _count--;
                return true;
            }

            idx = (idx + 1) % _table.Length;
        }

        return false;
    }

    /// <summary>
    /// Berechnet die nächste Primzahl, die gleich oder grösser als die übergebene Zahl ist.
    /// </summary>
    /// <param name="n">Die Ausgangszahl, ab der die Suche nach der nächsten Primzahl beginnen soll.</param>
    /// <return>Die nächste Primzahl, die gleich oder grösser als die übergebene Zahl ist.</return>
    private static int PrimeNext(int n) // sehr simple Primzahlsuche
    {
        while (!IsPrime(n))
        {
            n++;
        }

        return n;
    }

    /// <summary>
    /// Überprüft, ob die angegebene Zahl eine Primzahl ist.
    /// </summary>
    /// <param name="x">Die Zahl, die überprüft werden soll.</param>
    /// <returns>True, wenn die Zahl eine Primzahl ist, andernfalls false.</returns>
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