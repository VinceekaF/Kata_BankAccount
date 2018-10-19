using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountNumberFinder
{
    public class TestsOfError
    {

        public static bool TestAllNumbers(string accountNumber, int index)
        {
            bool isPossible = false;
            string falseAccountNumber = accountNumber.Remove(9);
            for (int j = 0; j < 10; j++)
            {
                falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, j.ToString());
                isPossible = NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
                if (isPossible)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool TestTo1(string accountNumber, int index)
        {
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "1").Remove(9);

            return NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
        }

        public static bool TestTo8(string accountNumber, int index)
        {
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "8");
            if(accountNumber.Length > 9)
            {
                accountNumber = accountNumber.Remove(9);
            }
                

            return NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
        }

        public static bool TestTo7(string accountNumber, int index)
        {
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "7").Remove(9);

            return NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
        }

        public static bool TestTo9(string accountNumber, int index)
        {
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "9");
            if (falseAccountNumber.Length > 9)
            {
                falseAccountNumber = falseAccountNumber.Remove(9);
            }

            return NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
        }
        public static bool TestTheTwoCasesOf5(string accountNumber, int index)
        {
            bool isPossible5 = false;
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "6").Remove(9);

            isPossible5 = NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
            if (!isPossible5)
            {
                isPossible5 = TestTo9(falseAccountNumber, index);
            }
            return isPossible5;
        }

        public static bool TestTheTwoCasesOf9(string accountNumber, int index)
        {
            bool isPossible9 = false;
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "5").Remove(9);

            isPossible9 = NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
            if (!isPossible9)
            {
                isPossible9 = TestTo8(falseAccountNumber, index);
            }
            return isPossible9;
        }

        public static bool TestTheTwoCasesOf8(string accountNumber, int index)
        {
            bool isPossible8 = false;
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "0").Remove(9);

            isPossible8 = NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
            if (!isPossible8)
            {
                isPossible8 = TestTo9(falseAccountNumber, index);
            }
            return isPossible8;
        }
    }
}
