namespace HashtableSamples;

/// <summary>
/// Eine Implementierung einer Hashtabelle mit Verkettung zur Verwaltung von Schlüssel-Wert-Paaren.
/// </summary>
/// <remarks>
/// Die Hashtabelle nutzt eine Verkettungsstrategie, bei der Werte, die zu demselben Hashcode gehören,
/// in einer Liste (Bucket) am jeweiligen Index gespeichert werden. Dies ermöglicht die Behandlung von
/// Kollisionen, indem mehrere Werte an einem Indexpunkt gespeichert werden.
/// Standardmässig wird eine primzahlgrosse Array-Grösse für die Buckets verwendet, um die Effizienz
/// der Hashtabelle zu maximieren.
/// </remarks>
public sealed class HashTableChaining
{
    /// <summary>
    /// Eine Sammlung von Buckets, die als interne Datenstruktur einer Hashtabelle mit Verkettung dient.
    /// </summary>
    /// <remarks>
    /// Jeder Bucket repräsentiert eine Liste, die Schlüssel-Wert-Paare speichert, deren Hash-Werte denselben Index ergeben.
    /// Dies wird verwendet, um Kollisionen in der Hashtabelle zu behandeln, indem mehrere Einträge an einem Index gespeichert werden.
    /// </remarks>
    private readonly List<(int key, string value)>[] buckets;

    /// <summary>
    /// Eine Implementierung einer Hashtabelle mit Verkettung zur Verwaltung von Schlüssel-Wert-Paaren.
    /// </summary>
    /// <remarks>
    /// Diese Klasse bietet grundlegende Operationen für eine Hashtabelle wie Einfügen, Abrufen und Löschen von Werten.
    /// Zur Kollisionserkennung und -behandlung wird das Prinzip der Verkettung verwendet, bei dem mehrere
    /// Schlüssel-Wert-Paare mit demselben Hash an einem Bucket-Index gespeichert werden.
    /// Die Tabelle nutzt eine intern definierte Anzahl von Buckets, die durch eine vorgegebene Grösse beim Erstellen
    /// der Hashtabelle festgelegt wird. Standardmässig wird eine Primgrösse verwendet, um die Wahrscheinlichkeit
    /// von Kollisionen zu reduzieren.
    /// </remarks>
    public HashTableChaining(int size = 17) // Primzahlgrösse
    {
        buckets = new List<(int, string)>[size];
        for (int i = 0; i < size; i++)
        {
            buckets[i] = new();
        }
    }

    /// <summary>
    /// Berechnet den Hash-Wert eines gegebenen Schlüssels und bestimmt den Index in den Buckets.
    /// </summary>
    /// <param name="key">Der Schlüssel, für den der Hash-Wert berechnet wird.</param>
    /// <returns>Den berechneten Index, der durch den Hashcode des Schlüssels und die Bucket-Grösse bestimmt wird.</returns>
    private int Hash(int key) => Math.Abs(key.GetHashCode()) % buckets.Length; // Math.Abs entfernt das Vorzeichenbit

    /// <summary>
    /// Fügt ein Schlüssel-Wert-Paar in die Hashtabelle ein. Falls der Schlüssel bereits existiert,
    /// wird der zugehörige Wert aktualisiert.
    /// </summary>
    /// <param name="key">Der Schlüssel, durch den das Element in der Hashtabelle eindeutig identifiziert wird.</param>
    /// <param name="value">Der Wert, der mit dem angegebenen Schlüssel in der Hashtabelle gespeichert wird.</param>
    /// <remarks>
    /// Bei einem Konflikt (wenn mehrere Schlüssel denselben Hashcode erzeugen) wird das neue Paar
    /// in der entsprechenden Buckets-Liste gespeichert, wobei ein bereits vorhandener Schlüssel
    /// überschrieben wird.
    /// </remarks>
    public void Add(int key, string value)
    {
        var bucket = buckets[Hash(key)];
        for (int i = 0; i < bucket.Count; i++)
        {
            if (bucket[i].key == key)
            {
                bucket[i] = (key, value);
                return;
            } // update
        }

        bucket.Add((key, value)); // new
    }

    /// <summary>
    /// Ruft den Wert ab, der mit dem angegebenen Schlüssel in der Hashtabelle verknüpft ist.
    /// </summary>
    /// <param name="key">Der Schlüssel, für den der zugehörige Wert abgerufen werden soll.</param>
    /// <returns>
    /// Der mit dem angegebenen Schlüssel verknüpfte Wert, falls dieser existiert. Andernfalls wird <c>null</c> zurückgegeben.
    /// </returns>
    public string? Get(int key)
    {
        foreach (var (k, v) in buckets[Hash(key)])
        {
            if (k == key)
            {
                return v;
            }
        }

        return null;
    }

    /// <summary>
    /// Entfernt ein Schlüssel-Wert-Paar aus der Hashtabelle, das dem angegebenen Schlüssel entspricht.
    /// </summary>
    /// <param name="key">Der Schlüssel des Schlüssel-Wert-Paares, das entfernt werden soll.</param>
    /// <returns>
    /// Gibt true zurück, wenn ein Eintrag mit dem angegebenen Schlüssel erfolgreich entfernt wurde; andernfalls false,
    /// wenn kein solcher Eintrag existiert.
    /// </returns>
    public bool Remove(int key) => buckets[Hash(key)].RemoveAll(p => p.key == key) > 0;
}