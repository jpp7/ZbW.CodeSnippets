namespace BasicHashTable;

/// <summary>
/// Die <c>MyHashtable</c>-Klasse implementiert eine einfache Hash-Tabelle, die Schlüssel-Wert-Paare speichert.
/// Sie bietet grundlegende Operationen zum Hinzufügen und Abrufen von Werten basierend auf einem Schlüssel.
/// Die Schlüssel sind vom Typ <c>string</c> und werden durch einen internen Hashing-Mechanismus
/// auf die verfügbaren Buckets abgebildet.
/// </summary>
public class MyHashtable
{
    private readonly LinkedList<Entry>[] _buckets;

    private readonly int _size = 17; // Grösse vom hash table

    /// <summary>
    /// Die <c>MyHashtable</c>-Klasse implementiert eine einfache Datenstruktur, die Schlüssel-Wert-Paare speichert.
    /// Sie basiert auf einem Hashing-Mechanismus, um die Daten effizient zu organisieren und abzurufen.
    /// Die Schlüssel sind vom Typ <c>string</c>, wobei eine interne Hash-Funktion verwendet wird, um die Position
    /// im zugrundeliegenden Bucket-Array zu bestimmen.
    /// </summary>
    public MyHashtable()
    {
        _buckets = new LinkedList<Entry>[_size];
    }

    /// <summary>
    /// Berechnet den Index des Buckets im zugrundeliegenden Array der Hashtable,
    /// in dem der angegebene Schlüssel gespeichert werden soll.
    /// Der Index wird basierend auf dem Hash-Wert des Schlüssels berechnet, der
    /// mit der Größe der Hashtable modulo gerechnet wird.
    /// </summary>
    /// <param name="key">Der Schlüssel vom Typ <c>string</c>, für den der Bucket-Index berechnet werden soll.</param>
    /// <returns>Ein ganzzahliger Index, der die Position des Buckets im Array angibt.</returns>
    private int GetBucketIndex(string key)
    {
        var hash = key.GetHashCode() & 0x7FFFFFFF; // entfernt das Vorzeichenbit
        return hash % _size;
    }

    /// <summary>
    /// Fügt ein Schlüssel-Wert-Paar in die <c>MyHashtable</c> ein oder aktualisiert den Wert eines vorhandenen Schlüssels.
    /// Wenn der Schlüssel bereits existiert, wird der zugehörige Wert aktualisiert; andernfalls wird ein neues Paar hinzugefügt.
    /// </summary>
    /// <param name="key">Der Schlüssel vom Typ <c>string</c>, der verwendet wird, um den Wert zu speichern oder zu aktualisieren.</param>
    /// <param name="value">Der Wert vom Typ <c>string</c>, der dem angegebenen Schlüssel zugeordnet werden soll.</param>
    public void Put(string key, string value)
    {
        var index = GetBucketIndex(key);

        if (_buckets[index] == null)
        {
            _buckets[index] = new LinkedList<Entry>();
        }

        foreach (var entry in _buckets[index])
        {
            if (entry.Key == key)
            {
                // Aktualisiere den Wert, wenn der Schlüssel bereits existiert
                entry.Value = value;
                return;
            }
        }

        // Fügt einen neuen Eintrag hinzu, wenn der Schlüssel nicht existiert
        _buckets[index].AddLast(new Entry(key, value));
    }

    /// <summary>
    /// Sucht in der <c>MyHashtable</c> den Wert, der dem angegebenen Schlüssel zugeordnet ist, und gibt diesen zurück.
    /// Wenn der Schlüssel nicht gefunden wird, gibt die Methode <c>null</c> zurück.
    /// </summary>
    /// <param name="key">Der Schlüssel vom Typ <c>string</c>, dessen zugehöriger Wert abgerufen werden soll.</param>
    /// <returns>Der Wert vom Typ <c>string</c>, der dem Schlüssel zugeordnet ist, oder <c>null</c>, wenn der Schlüssel nicht gefunden wird.</returns>
    public string Get(string key)
    {
        var index = GetBucketIndex(key);

        var bucket = _buckets[index];
        if (bucket != null)
        {
            foreach (var entry in bucket)
            {
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }
        }

        return null; // Wurde nicht gefunden
    }

    /// <summary>
    /// Die <c>Entry</c>-Klasse stellt ein einzelnes Schlüssel-Wert-Paar dar,
    /// das in der <c>MyHashtable</c>-Datenstruktur verwendet wird.
    /// Der Schlüssel ist eine Zeichenkette, die zur Identifikation der Einträge dient,
    /// während der Wert ebenfalls eine Zeichenkette ist, die die gespeicherten Informationen repräsentiert.
    /// </summary>
    private class Entry
    {
        public readonly string Key;
        public string Value;

        /// <summary>
        /// Die <c>Entry</c>-Klasse stellt ein einzelnes Schlüssel-Wert-Paar dar.
        /// Sie wird intern von der Klasse <c>MyHashtable</c> verwendet, um Daten effizient zu speichern und abzurufen.
        /// Der Schlüssel ist vom Typ <c>string</c> und identifiziert eindeutig den Eintrag,
        /// während der Wert ebenfalls eine Zeichenkette ist, die die gespeicherte Information repräsentiert.
        /// </summary>
        public Entry(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}