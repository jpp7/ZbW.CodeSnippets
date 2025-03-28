namespace FibonacciExamples
{
    /// <summary>
    /// The Program class serves as the entry point of the application and encapsulates the logic
    /// for managing and executing functionality related to the FibonacciExamples namespace.
    /// </summary>
    /// <remarks>
    /// This class is sealed, meaning it cannot be inherited, preventing further extension
    /// or modification of its behavior through inheritance.
    /// </remarks>
    public sealed class Program
    {
        /// <summary>
        /// The entry point of the application, responsible for executing the main logic of the program.
        /// </summary>
        /// <remarks>
        /// This method is executed as the starting point of the application. It computes and displays
        /// Fibonacci numbers using both iterative and recursive approaches.
        /// The method is static and does not return a value.
        /// </remarks>
        public static void Main()
        {
            int n = 40;

            Console.WriteLine($"Fibonacci ({n}) – iterativ: {FibonacciIterativ(n)}");
            Console.WriteLine($"Fibonacci ({n}) – rekursiv: {FibonacciRekursiv(n)}");
        }
        
        /// <summary>
        /// Calculates the nth Fibonacci number using an iterative approach.
        /// </summary>
        /// <param name="n">The position of the Fibonacci sequence to compute. Must be a non-negative integer.</param>
        /// <returns>The nth Fibonacci number.</returns>
        private static int FibonacciIterativ(int n)
        {
            if (n <= 1) return n;

            int a = 0, b = 1, sum = 0;

            for (int i = 2; i <= n; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
            }

            return b;
        }

        /// <summary>
        /// Calculates the nth Fibonacci number using a recursive approach.
        /// </summary>
        /// <param name="n">The position of the Fibonacci sequence to compute. Must be a non-negative integer.</param>
        /// <returns>The nth Fibonacci number.</returns>
        private static int FibonacciRekursiv(int n)
        {
            if (n <= 1)
                return n;

            return FibonacciRekursiv(n - 1) + FibonacciRekursiv(n - 2);
        }
    }
}