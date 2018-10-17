using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BankAccountNumberFinder
{
    public class NumberFinder
    {
        private static readonly Dictionary<string, string> _digits = new Dictionary<string, string>
        {
            {"     |  |","1" },
            {"    |  | ","1" },
            {" _  _||_ ","2" },
            {" _  _| _|","3" },
            {"   |_|  |","4" },
            {" _ |_  _|","5" },
            {"   |_ |_|","6" },
            {" _   |  |","7" },
            {" _ |_||_|","8" },
            {" _ |_| _|","9" },
            {" _ | ||_|","0" }
        };
        
        public static string ScanEntry(string filePath)
        {
            List<string> allDigits = ReadFileAndGetDigits(filePath);
            string accountNumber = "";
            foreach (string digit in allDigits)
            {
                accountNumber = accountNumber + _digits[digit];
            }
            
            return accountNumber;
        }

        public static List<string> ReadFileAndGetDigits(string filePath)
        {
            string[] lines = File.ReadLines(filePath).Take(3).ToArray();
            string firstDigit = "", secondDigit = "", thirdDigit = "", fourthDigit = "", fifthDigit = "", sixthDigit = "", seventhDigit = "", eighthDigit = "", ninthDigit = "";
            StringBuilder sb0 = new StringBuilder();
            foreach (string line in lines)
            {
                firstDigit = firstDigit + line.Substring(0, 3);
                secondDigit = secondDigit + line.Substring(3, 3);
                thirdDigit = thirdDigit + line.Substring(6, 3);
                fourthDigit = fourthDigit + line.Substring(9, 3);
                fifthDigit = fifthDigit + line.Substring(12, 3);
                sixthDigit = sixthDigit + line.Substring(15, 3);
                seventhDigit = seventhDigit + line.Substring(18, 3);
                eighthDigit = eighthDigit + line.Substring(21, 3);
                ninthDigit = ninthDigit + line.Substring(24, 3);
            }

            List<string> listOfDigits = new List<string>
            {
                firstDigit,
                secondDigit,
                thirdDigit,
                fourthDigit,
                fifthDigit,
                sixthDigit,
                seventhDigit,
                eighthDigit,
                ninthDigit,
            };

            return listOfDigits;

        }
    }
}
