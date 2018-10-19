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
                    Console.WriteLine($"There is a possibility of a machine failure with account number: ");
                    Char[] chars = number.accountNumber.ToCharArray();
                    for(int i =0; i<chars.Length;i++)
                    {
                        if (i == number.positionOfWrongNumber)
                        {
                            Console.ForegroundColor = System.ConsoleColor.Green;
                            Console.Write(chars[i]);
                        }
                        else
                        {
                            Console.ForegroundColor = System.ConsoleColor.White;
                            Console.Write(chars[i]);
                        }
                    }
                Console.WriteLine($"\nThe green {number.possibleRightNumber} could be a {number.possibleWrongNumber}\n");
                }
                else
                {
                    Console.ForegroundColor = System.ConsoleColor.White;
                    Console.WriteLine("account number: " + number.accountNumber);
                    Console.WriteLine("\n");
                }
            }
            Console.Read();
        }
    }
}
