namespace BinaryTreeSample;

/// <summary>
///     Implementiert einen Binären Suchbaum (Binary Search Tree).
/// </summary>
/// <typeparam name="T">Der Typ der Elemente, die im Baum gespeichert werden. Der Typ muss IComparable implementieren.</typeparam>
public class BinarySearchTree<T> where T : IComparable<T>
{
    /// <summary>
    ///     Repräsentiert die Wurzel des binären Suchbaums.
    ///     Dieses private Feld dient als Einstiegspunkt für alle Operationen,
    ///     die den Baum durchsuchen, modifizieren oder traversieren.
    ///     Es verweist auf den obersten Knoten im Baum, welcher
    ///     die Hierarchie der untergeordneten Knoten definiert.
    ///     Wenn der Baum leer ist, ist dieses Feld null.
    /// </summary>
    private BinaryTreeNode<T>? _root;

    /// <summary>
    ///     Fügt einen neuen Wert in den Binären Suchbaum ein.
    ///     Wenn der Wert bereits existiert, wird keine Änderung am Baum vorgenommen.
    /// </summary>
    /// <param name="value">Der einzufügende Wert. Muss mit bereits vorhandenen Werten im Baum vergleichbar sein.</param>
    public void Insert(T value)
    {
        _root = Insert(_root, value);
    }

    /// <summary>
    ///     Fügt einen neuen Wert in den binären Suchbaum ein. Falls der Wert bereits
    ///     vorhanden ist, wird der Baum nicht geändert.
    /// </summary>
    /// <param name="value">Der einzufügende Wert. Der Wert muss mit den anderen Werten im Baum vergleichbar sein.</param>
    private static BinaryTreeNode<T> Insert(BinaryTreeNode<T>? node, T value)
    {
        if (node == null)
        {
            return new BinaryTreeNode<T>(value);
        }

        var cmp = value.CompareTo(node.Value);
        if (cmp < 0)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (cmp > 0)
        {
            node.Right = Insert(node.Right, value);
        }

        // cmp == 0 -> Wert schon vorhanden: ignorieren oder Policy ändern
        return node;
    }

    // ---------- Suchen ----------
    /// <summary>
    ///     Überprüft, ob ein bestimmter Wert im Binären Suchbaum vorhanden ist.
    /// </summary>
    /// <param name="value">Der zu suchende Wert. Muss mit den im Baum gespeicherten Werten vergleichbar sein.</param>
    /// <returns>Gibt true zurück, wenn der angegebene Wert im Baum gefunden wurde, andernfalls false.</returns>
    public bool Contains(T value)
    {
        return Find(_root, value) != null;
    }

    /// <summary>
    ///     Sucht nach einem bestimmten Wert im Binären Suchbaum und gibt den entsprechenden Knoten zurück, falls er vorhanden
    ///     ist.
    /// </summary>
    /// <param name="value">
    ///     Der Wert, nach dem im Baum gesucht werden soll. Muss mit den bereits im Baum gespeicherten Werten
    ///     vergleichbar sein.
    /// </param>
    /// <returns>Der Knoten, der den gesuchten Wert enthält, oder null, falls der Wert nicht im Baum gefunden wurde.</returns>
    public BinaryTreeNode<T>? Find(T value)
    {
        return Find(_root, value);
    }

    /// <summary>
    ///     Sucht nach einem Knoten im Binären Suchbaum, der den angegebenen Wert enthält.
    ///     Wenn der Wert im Baum gefunden wird, wird der entsprechende Knoten zurückgegeben, andernfalls null.
    /// </summary>
    /// <param name="node">Der aktuelle Knoten, bei dem die Suche beginnt.</param>
    /// <param name="value">Der zu suchende Wert. Muss mit den Werten im Baum vergleichbar sein.</param>
    /// <return>Der gefundene Knoten, der den angegebenen Wert enthält, oder null, wenn der Wert nicht gefunden wurde.</return>
    private static BinaryTreeNode<T>? Find(BinaryTreeNode<T>? node, T value)
    {
        while (node != null)
        {
            var cmp = value.CompareTo(node.Value);
            if (cmp == 0)
            {
                return node;
            }

            node = cmp < 0 ? node.Left : node.Right;
        }

        return null;
    }

    /// <summary>
    ///     Entfernt einen Wert aus dem binären Suchbaum, falls dieser existiert.
    ///     Wenn der Wert nicht im Baum enthalten ist, bleibt der Baum unverändert.
    /// </summary>
    /// <param name="value">Der zu löschende Wert. Muss mit den bereits im Baum gespeicherten Werten vergleichbar sein.</param>
    public void Delete(T value)
    {
        _root = Delete(_root, value);
    }

    /// <summary>
    ///     Entfernt einen Wert aus dem binären Suchbaum, falls dieser existiert.
    ///     Wenn der Wert nicht gefunden wird, bleibt der Baum unverändert.
    /// </summary>
    /// <param name="value">Der zu entfernende Wert. Muss mit den im Baum gespeicherten Werten vergleichbar sein.</param>
    private static BinaryTreeNode<T>? Delete(BinaryTreeNode<T>? node, T value)
    {
        if (node == null)
        {
            return null;
        }

        var cmp = value.CompareTo(node.Value);
        if (cmp < 0)
        {
            node.Left = Delete(node.Left, value);
        }
        else if (cmp > 0)
        {
            node.Right = Delete(node.Right, value);
        }
        else // Treffer
        {
            // Fall 1: kein Kind
            if (node.Left == null && node.Right == null)
            {
                return null;
            }

            // Fall 2: ein Kind
            if (node.Left == null)
            {
                return node.Right;
            }

            if (node.Right == null)
            {
                return node.Left;
            }

            // Fall 3: zwei Kinder – Nachfolger einsetzen
            var succ = Min(node.Right)!;
            node.Value = succ.Value;
            node.Right = Delete(node.Right, succ.Value);
/*
  1. `var succ = Min(node.Right)!;`
    - Sucht den kleinsten Wert im rechten Teilbaum des zu löschenden Knotens
    - Dieser Wert ist der "Nachfolger" (Successor) des zu löschenden Wertes
    - Das `!` am Ende sagt dem Compiler, dass wir sicher sind, dass das Ergebnis nicht null sein wird

2. `node.Value = succ.Value;`
    - Kopiert den Wert des Nachfolgers in den aktuellen Knoten
    - Dadurch wird der zu löschende Wert effektiv ersetzt

3. `node.Right = Delete(node.Right, succ.Value);`
    - Löscht den Nachfolgerknoten aus dem rechten Teilbaum
    - Der neue rechte Teilbaum wird dann wieder mit dem aktuellen Knoten verbunden

 */
        }

        return node;
    }

    /// <summary>
    ///     Gibt den Knoten mit dem kleinsten Wert in einem Teilbaum zurück.
    ///     Der Knoten mit dem kleinsten Wert befindet sich ganz links im Baum.
    /// </summary>
    /// <param name="node">Der Wurzelknoten des Teilbaums, in dem gesucht werden soll. Kann null sein.</param>
    /// <returns>Der Knoten mit dem kleinsten Wert oder null, wenn der Teilbaum leer ist.</returns>
    private static BinaryTreeNode<T>? Min(BinaryTreeNode<T>? node)
    {
        while (node?.Left != null)
        {
            node = node.Left;
        }

        return node;
    }

    // ---------- Traversierungs-Wrapper ----------
    /// <summary>
    ///     Führt eine Pre-Order-Traversierung des Binären Suchbaums durch.
    ///     Die Reihenfolge der Traversierung ist Wurzel → Links → Rechts.
    /// </summary>
    /// <returns>
    ///     Eine Auflistung der Werte des Baums in Pre-Order-Reihenfolge.
    /// </returns>
    public IEnumerable<T> PreOrder()
    {
        return BinaryTreeTraversal.PreOrder(_root);
    }

    /// <summary>
    ///     Führt eine In-Order-Traversierung des Binären Suchbaums durch.
    ///     Die Traverse-Reihenfolge ist Links → Wurzel → Rechts.
    /// </summary>
    /// <returns>Eine Auflistung der Werte des Baums in In-Order-Reihenfolge.</returns>
    public IEnumerable<T> InOrder()
    {
        return BinaryTreeTraversal.InOrder(_root);
    }

    /// <summary>
    ///     Führt eine Post-Order-Traversierung des Binären Suchbaums durch.
    ///     Die Reihenfolge der Traversierung ist: Links → Rechts → Wurzel.
    /// </summary>
    /// <returns>Eine Auflistung der Werte im Baum in Post-Order-Reihenfolge.</returns>
    public IEnumerable<T> PostOrder()
    {
        return BinaryTreeTraversal.PostOrder(_root);
    }

    /// <summary>
    ///     Führt eine Level-Order-Traversierung des Binären Suchbaums durch.
    ///     Die Methode gibt die Elemente des Baums in der Reihenfolge zurück, in der sie Ebene für Ebene,
    ///     von oben nach unten und von links nach rechts, besucht werden.
    /// </summary>
    /// <returns>Eine Auflistung der Werte des Baums in Level-Order-Reihenfolge.</returns>
    public IEnumerable<T> LevelOrder()
    {
        return BinaryTreeTraversal.LevelOrder(_root);
    }
}