using BankAccountNumberFinder;
using System;

namespace ScannerPgm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le chemin de votre fichier");
            string filePath = Console.ReadLine();
            string accountNumber = NumberFinder.ScanEntry(filePath);
            Console.WriteLine("Le numero du compte est: " + accountNumber);

            Console.Read();
        }
    }
}
