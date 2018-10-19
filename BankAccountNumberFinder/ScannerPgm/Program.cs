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
            List<AccountNumber> accountNumbers = NumberFinder.ScanEntry(filePath);
            foreach(var number in accountNumbers)
            {
                if (number.errorPossible)
                {
                    Console.WriteLine($"There is a possibility of a machine failure\n" +
                        $"with account number: {number.accountNumber}\n" +
                        $" {number.possibleRightNumber} could be a {number.possibleWrongNumber}");
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine("account number: " + number.accountNumber);
                    Console.WriteLine("\n");

                }
            }

            Console.Read();
        }
    }
}
