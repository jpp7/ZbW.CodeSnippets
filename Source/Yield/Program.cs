namespace Yield
{
    /// Defines the Program class, which contains the entry point and methods demonstrating
    /// lazy evaluation using the yield keyword to generate a sequence of numbers.
    public sealed class Program
    {
        /// Serves as the entry point of the program, responsible for executing the main logic of the application.
        /// Demonstrates the usage of a lazily evaluated sequence of numbers generated using the ZahlenBis method.
        public static void Main()
        {
            Console.WriteLine("Zahlen bis 5 (lazy mit yield):");

            foreach (int zahl in ZahlenBis(5))
            {
                Console.WriteLine(zahl);
            }
        }

        // Gibt Zahlen von 1 bis max zurück – aber lazy mit yield
        /// Returns a sequence of numbers from 1 to the specified maximum value using lazy evaluation with yield.
        /// <param name="max">The maximum value up to which numbers will be yielded.</param>
        /// <return>An enumerable sequence of integers starting from 1 up to the specified maximum value.</return>
        private static IEnumerable<int> ZahlenBis(int max)
        {
            for (int i = 1; i <= max; i++)
            {
                yield return i;
            }
        }
    }
}