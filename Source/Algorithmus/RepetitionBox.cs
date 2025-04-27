namespace Algorithmus;

/// <summary>
///     Sammlung typischer Repetitions-Aufgaben für den Unterricht.
///     Jeder Algorithmus ist als eigene Methode gekapselt,
///     sodass die Klasse in Unit-Tests oder Live-Coding-Sessions
///     bequem wiederverwendet werden kann.
/// </summary>
public static class RepetitionBox
{
    // --- Aufgabe A ------------------------------------------
    /// <summary>Bildet die Quersumme einer ganzen Zahl n ≥ 0.</summary>
    public static int Quersumme(int n)
    {
        var sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }

        return sum;
    }

    // --- Aufgabe B ------------------------------------------
    /// <summary>
    ///     Liest m Werte von der Konsole ein
    ///     und gibt Min, Max und Durchschnitt zurück.
    /// </summary>
    public static (int Min, int Max, double Avg) Statistik(int m)
    {
        var werte = new List<int>(m);
        for (var i = 0; i < m; i++)
        {
            Console.Write($"Wert {i + 1}: ");
            werte.Add(int.Parse(Console.ReadLine()!));
        }

        int min = int.MaxValue, max = int.MinValue, sum = 0;
        foreach (var w in werte)
        {
            if (w < min)
            {
                min = w;
            }

            if (w > max)
            {
                max = w;
            }

            sum += w;
        }

        var avg = (double)sum / werte.Count;
        return (min, max, avg);
    }

    // --- Aufgabe C ------------------------------------------
    /// <summary>Gibt die Primfaktoren einer Zahl n > 1 zurück.</summary>
    public static List<int> Primfaktoren(int n)
    {
        var faktoren = new List<int>();
        for (var i = 2; i * i <= n; i++)
        {
            while (n % i == 0)
            {
                faktoren.Add(i);
                n /= i;
            }
        }

        if (n > 1)
        {
            faktoren.Add(n);
        }

        return faktoren;
    }
}