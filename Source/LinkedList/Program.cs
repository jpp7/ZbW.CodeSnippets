namespace LinkedList
{
    public sealed class Program
    {
        public static void Main()
        {
            Console.WriteLine("Start LinkedList");
            
            // Create a new LinkedList instance and add various types of elements to it
            var list = new LinkedList();
            list.Add("Hallo");
            list.Add("Welt");
            list.Add(42);   
            list.Add(3.14); 
            list.Add(new DateTime(2023, 10, 1));
            
            // Print the elements of the LinkedList using different methods
            Console.WriteLine("Printen der LinkedList ausgeben mit for Schleife:");
            
            for( int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            
            Console.WriteLine();
            
            Console.WriteLine("Printen der LinkedList ausgeben mit while Schleife (MoveNext):");
            
            var iterator = list.GetEnumerator();
            
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
            
            // iterator.Reset();
            
            Console.WriteLine();
            
            Console.WriteLine("Printen der LinkedList ausgeben mit foreach Schleife:");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();
            

            Console.WriteLine("Ende LinkedList");
        }
    }
}