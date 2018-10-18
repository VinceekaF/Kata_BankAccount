using BankAccountNumberFinder;
using System;
using System.Collections.Generic;

namespace ScannerPgm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le chemin de votre fichier");
            string filePath = Console.ReadLine();
            List<string> accountNumbers = NumberFinder.ScanEntry(filePath);
            foreach(var number in accountNumbers)
            {
                Console.WriteLine(number);
            }

            Console.Read();
        }
    }
}
