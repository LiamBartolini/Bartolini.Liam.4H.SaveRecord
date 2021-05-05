using System;
using Bartolini.Liam._4H.SaveRecord.Models;

namespace Bartolini.Liam._4H.SaveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMERO_VERIFICA = 5;
            Console.WriteLine("SaveRecord - 2021 - liambartolini@gmail.com");
            
            // 1)
            // Leggere un file CSV con i comuni etrasformarlo in una list<Comune>
            Comuni c = new Comuni( "Comuni.csv" );
            Console.WriteLine($"Ho letto {c.Count} righe...");

            Console.WriteLine($"Ecco la riga {NUMERO_VERIFICA}: {c[NUMERO_VERIFICA]}");

            // 2)
            // Scrivere la List<Comune> in un file binario
            c.Save();
            
            // 3)
            // Rileggere il file binario i una List<Comune>
            c.Load();
            Console.WriteLine($"Ho letto {c.Count} righe dal file binario...");
        
            Console.WriteLine($"Ecco la riga {NUMERO_VERIFICA}: {c[NUMERO_VERIFICA]}");
        }
    }
}