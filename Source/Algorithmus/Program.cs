namespace Algorithmus
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        ///     The main method, which serves as the entry point for the program.
        /// </summary>
        public static void Main()
        {
            Console.Write("Zahl für Quersumme: ");
            int n = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"Quersumme = {RepetitionBox.Quersumme(n)}");

            Console.Write("Wie viele Werte für Statistik? ");
            int m = int.Parse(Console.ReadLine()!);
            var (min, max, avg) = RepetitionBox.Statistik(m);
            Console.WriteLine($"Min = {min}, Max = {max}, Ø = {avg:F2}");

            Console.Write("Zahl für Primfaktoren: ");
            int p = int.Parse(Console.ReadLine()!);
            Console.WriteLine($"Primfaktoren: {string.Join(" × ", RepetitionBox.Primfaktoren(p))}");
        }
    }
}

