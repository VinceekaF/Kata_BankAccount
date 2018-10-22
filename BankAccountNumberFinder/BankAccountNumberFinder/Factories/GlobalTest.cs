using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountNumberFinder.Factories
{
    public interface IGlobalTest
    {
        void Test(AccountNumber account, int index, string numberToTest);
    }
    public class GlobalTest : IGlobalTest
    {
        INumberFinder _bo = new NumberFinder();

        public void Test(AccountNumber account, int index, string numberToTest)
        {
            string falseAccountNumber = account.accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, numberToTest);
            account.errorPossible = _bo.CheckIfAccountIsValid(falseAccountNumber);
            if (account.errorPossible)
            {
                account.possibleRightNumber = account.accountNumber[index].ToString();
                account.possibleWrongNumber = numberToTest.ToString();
                account.positionOfWrongNumber = index;
            }
        }

    }
}
