// See https://aka.ms/new-console-template for more information

namespace BinaryTreeSample;

/// <summary>
/// Diese Klasse dient als Einstiegspunkt für die Konsolenanwendung.
/// Sie demonstriert die Verwendung eines Binären Suchbaums (Binary Search Tree),
/// einschließlich der Insertion, Traversierung und Löschung von Elementen.
/// </summary>
public sealed class Program
{
    /// <summary>
    ///     The entry point of the console application that demonstrates
    ///     stack versus heap memory allocation in .NET.
    /// </summary>
    /// <param name="args">An array of command-line arguments.</param>
    public static void Main(string[] args)
    {
        var bst = new BinarySearchTree<int>();
        bst.Insert(40);          
        bst.Insert(20);
        bst.Insert(10);
        bst.Insert(30);
        bst.Insert(60);
        bst.Insert(50);
        bst.Insert(70);
        
        // Nach den Insert-Operationen sieht der Baum so aus:
        //
        //           40
        //          /  \
        //        20    60
        //       /  \   / \
        //     10   30 50  70


        // Links => Node => Rechts (sortiert aufsteigend)
        Console.WriteLine("In-Order  : " + string.Join(", ", bst.InOrder())); // 10 20 30 40 50 60 70
        
        // => Links => RechtS =>  Node
        Console.WriteLine("Post-Order: " + string.Join(", ", bst.PostOrder())); // 10 30 20 50 70 60 40
        
        // Node => Links => Rechts
        Console.WriteLine("Pre-Order: " + string.Join(", ", bst.LevelOrder())); // 40 20 60 10 30 50 70

        bst.Delete(20); // Knoten mit zwei Kindern
        Console.WriteLine("Nach Delete(20): " + string.Join(", ", bst.InOrder())); // 10 30 40 50 60 70
    }
}