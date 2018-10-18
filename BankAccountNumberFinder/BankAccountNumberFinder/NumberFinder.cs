﻿using System;
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
            {"   |  |  ","1" },
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
        
        public static List<string> ScanEntry(string filePath)
        {
            List<List<string>> allAccountNumbers = ReadAllAccountNumbers(filePath);

            List<String> allAccountNumbersReadable = new List<string>();


            foreach (var listOfDigits in allAccountNumbers)
            {
                string accountNumber = "";
                bool isReadable = true;
                bool isValid;
                foreach (var number in listOfDigits)
                {
                    if (_digits.ContainsKey(number))
                    {
                        accountNumber += _digits[number];
                    }
                    else
                    {
                        accountNumber += "?";
                        isReadable = false;
                    }
                }

                isValid = CheckIfAccountIsValid(accountNumber);

                if (!isValid)
                {
                    accountNumber += " ERR";
                }
                else if (!isReadable)
                {
                    accountNumber += " ILL";
                }

                allAccountNumbersReadable.Add(accountNumber);
            }

            return allAccountNumbersReadable;
        }

        public static List<List<string>> ReadAllAccountNumbers(string filePath)
        {

            string[] lines = File.ReadAllLines(filePath);
            int numberOfAccount = (lines.Length + 1) / 4;
            List<string> listOfDigits = new List<string>();
            List<List<string>> listOfAccount = new List<List<string>>();

            for (int j = 0; j < lines.Length; j++)
            {
                string firstDigit = "", secondDigit = "", thirdDigit = "", fourthDigit = "",
                    fifthDigit = "", sixthDigit = "", seventhDigit = "", eighthDigit = "", ninthDigit = "";

                string[] temporaryLines = new string[3];
                temporaryLines[0] = lines[j];
                temporaryLines[1] = lines[j + 1];
                temporaryLines[2] = lines[j + 2];

                foreach (string line in temporaryLines)
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

                listOfDigits = new List<string>
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

                listOfAccount.Add(listOfDigits);

                j += 3;
            }


            return listOfAccount;

        }

        public static bool CheckIfAccountIsValid(string accountNumber)
        {
            int sum = 0;
            int count = 9;
            bool isValid = true;
            for (int i = 0; i < accountNumber.Length; i++)
            {
                sum += (accountNumber[i] - '0') * count;
                count--;
            }

            if (sum % 11 != 0)
                return isValid = false;

            return isValid;

        }
    }
}
