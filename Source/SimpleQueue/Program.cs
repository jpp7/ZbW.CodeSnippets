namespace SimpleQueue
{
    /// <summary>
    /// The Program class contains the entry point of the application demonstrating the functionality
    /// of the SimpleQueue class. It includes operations such as enqueue, dequeue, peek, clear, and
    /// displays the output to the console during execution.
    /// </summary>
    /// <remarks>
    /// This class should be used as the starting point of the application, showcasing the usage and
    /// behavior of the SimpleQueue with example data.
    /// </remarks>
    public sealed class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <remarks>
        /// This method initializes and demonstrates the functionality of the `SimpleQueue` class,
        /// including adding elements, removing elements, peeking at elements, clearing the queue,
        /// and displaying output to the console.
        /// </remarks>
        public static void Main()
        {
            SimpleQueue<Person> queue = new SimpleQueue<Person>();
            queue.Enqueue(new Person { Name = "Hans", Id = 1 });
            queue.Enqueue(new Person { Name = "Peter", Id = 2 });
            queue.Enqueue(new Person { Name = "Anna", Id = 3 });
            queue.Enqueue(new Person { Name = "Maria", Id = 4 });
            
            Console.WriteLine($"Queue: {queue.Count} Personen");
            var p = queue.Dequeue();
            Console.WriteLine($"Entfernt: {p.Name} mit ID {p.Id}");
            Console.WriteLine($"Queue: {queue.Count} Personen");

            p = queue.Peek();
            Console.WriteLine($"Peek: {p.Name} mit ID {p.Id}");
            Console.WriteLine($"Queue: {queue.Count} Personen");
            
            queue.Clear();
            Console.WriteLine("Clear");
            Console.WriteLine($"Queue: {queue.Count} Personen");
            
            Console.WriteLine("Done!!!");
        }
    }
}