namespace BinaryTreeSample;

/// <summary>
///     Die Klasse BinaryTreeTraversal bietet statische Methoden zur Traversierung eines binären Baums.
///     Unterstützte Traversierungsarten umfassen Pre-Order, In-Order, Post-Order und Level-Order.
/// </summary>
public static class BinaryTreeTraversal
{
    /// <summary>
    ///     Pre-Order Traversierung eines binären Baums. Die Reihenfolge ist Wurzel → Links → Rechts.
    /// </summary>
    /// <typeparam name="T">Der Typ der Daten, die in den Knoten des Binärbaums gespeichert sind.</typeparam>
    /// <param name="node">Der Wurzelknoten des binären Baums oder Teilbaums.</param>
    /// <returns>Eine Auflistung der Werte, die in Pre-Order-Reihenfolge traversiert wurden.</returns>
    public static IEnumerable<T> PreOrder<T>(BinaryTreeNode<T>? node)
    {
        if (node == null) // ✱ Abbruchbedingung
        {
            yield break;
        }

        yield return node.Value; // 1) Wurzel besuchen
        foreach (var v in PreOrder(node.Left))
        {
            yield return v; // 2) linker Teil-Baum
        }

        foreach (var v in PreOrder(node.Right))
        {
            yield return v; // 3) rechter Teil-Baum
        }
    }

    /// <summary>
    ///     In-Order Traversierung eines binären Baums. Die Reihenfolge ist Links → Wurzel → Rechts.
    /// </summary>
    /// <typeparam name="T">Der Typ der Daten, die in den Knoten des Binärbaums gespeichert sind.</typeparam>
    /// <param name="node">Der Wurzelknoten des binären Baums oder Teilbaums.</param>
    /// <returns>Eine Auflistung der Werte, die in In-Order-Reihenfolge traversiert wurden.</returns>
    public static IEnumerable<T> InOrder<T>(BinaryTreeNode<T>? node)
    {
        if (node == null)
        {
            yield break;
        }

        foreach (var v in InOrder(node.Left))
        {
            yield return v; // 1) links
        }

        yield return node.Value; // 2) Wurzel
        foreach (var v in InOrder(node.Right))
        {
            yield return v; // 3) rechts
        }
    }


    /// <summary>
    ///     Post-Order Traversierung eines binären Baums. Die Reihenfolge ist Links → Rechts → Wurzel.
    /// </summary>
    /// <typeparam name="T">Der Typ der Daten, die in den Knoten des Binärbaums gespeichert sind.</typeparam>
    /// <param name="node">Der Wurzelknoten des binären Baums oder Teilbaums.</param>
    /// <returns>Eine Auflistung der Werte, die in Post-Order-Reihenfolge traversiert wurden.</returns>
    public static IEnumerable<T> PostOrder<T>(BinaryTreeNode<T>? node)
    {
        if (node == null)
        {
            yield break;
        }

        foreach (var v in PostOrder(node.Left))
        {
            yield return v; // 1) links
        }

        foreach (var v in PostOrder(node.Right))
        {
            yield return v; // 2) rechts
        }

        yield return node.Value; // 3) Wurzel
    }

    /// <summary>
    ///     Level-Order Traversierung eines binären Baums. Die Reihenfolge erfolgt Ebene für Ebene von oben nach unten und von
    ///     links nach rechts.
    /// </summary>
    /// <typeparam name="T">Der Typ der Daten, die in den Knoten des Binärbaums gespeichert sind.</typeparam>
    /// <param name="root">Der Wurzelknoten des binären Baums.</param>
    /// <returns>Eine Auflistung der Werte, die in Level-Order-Reihenfolge traversiert wurden.</returns>
    public static IEnumerable<T> LevelOrder<T>(BinaryTreeNode<T>? root)
    {
        if (root == null)
        {
            yield break;
        }

        var queue = new Queue<BinaryTreeNode<T>>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            yield return node.Value; // Aktuellen Knoten ausgeben

            if (node.Left != null)
            {
                queue.Enqueue(node.Left); // Kinder anstellen
            }

            if (node.Right != null)
            {
                queue.Enqueue(node.Right);
            }
        }
    }
}