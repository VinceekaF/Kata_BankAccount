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

                if (!isValid && isReadable)
                {
                    accountNumber += " ERR";
                }
                else if (!isReadable)
                {
                    accountNumber += " ILL";
                }

                if (accountNumber.Length > 9 && accountNumber.Where(x=>x.ToString()=="?").Count() < 2)
                {
                    accountNumber = CheckPossibleErrors(accountNumber);
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
                    firstDigit += line.Substring(0, 3);
                    secondDigit += line.Substring(3, 3);
                    thirdDigit += line.Substring(6, 3);
                    fourthDigit += line.Substring(9, 3);
                    fifthDigit += line.Substring(12, 3);
                    sixthDigit += line.Substring(15, 3);
                    seventhDigit += line.Substring(18, 3);
                    eighthDigit += line.Substring(21, 3);
                    ninthDigit += line.Substring(24, 3);
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

        public static string CheckPossibleErrors(string accountNumber)
        {
            bool isPossible = false;
            if (accountNumber.Contains("ERR"))
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!isPossible)
                    {
                        switch (accountNumber[i].ToString())
                        {
                            case "0":
                            case "6":
                                isPossible = TestsOfError.TestTo8(accountNumber, i);
                                break;
                            case "1":
                                isPossible = TestsOfError.TestTo7(accountNumber, i);
                                break;
                            case "3":
                                isPossible = TestsOfError.TestTo9(accountNumber, i);
                                break;
                            case "5":
                                isPossible = TestsOfError.TestTheTwoCasesOf5(accountNumber, i);
                                break;
                            case "7":
                                isPossible = TestsOfError.TestTo1(accountNumber, i);
                                break;
                            case "8":
                                isPossible = TestsOfError.TestTheTwoCasesOf8(accountNumber, i);
                                break;
                            case "9":
                                isPossible = TestsOfError.TestTheTwoCasesOf9(accountNumber, i);
                                break;
                            default:
                                isPossible = false;
                                break;
                        }
                    }
                }

            }
            else if (accountNumber.Contains("ILL"))
            {
                for (int i = 0; i < 9; i++)
                {
                    if (accountNumber[i].ToString() == "?")
                    {
                        isPossible = TestsOfError.TestAllNumbers(accountNumber, i);
                    }
                }
            }

            if (isPossible && accountNumber.Contains("ERR"))
            {
                accountNumber = accountNumber.Replace("ERR", "AMB");
            }
            else if (!isPossible && accountNumber.Contains("ERR"))
            {
                accountNumber = accountNumber.Replace("ERR", "ILL");
            }
            else if (isPossible && accountNumber.Contains("ILL"))
            {
                accountNumber = accountNumber.Replace("ILL", "AMB");
            }

            return accountNumber;
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
