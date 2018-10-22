using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountNumberFinder
{
    public interface INumberFinder
    {
        List<AccountNumber> ScanEntry(string filePath);
        AccountNumber CheckPossibleErrors(AccountNumber account);
        bool CheckIfAccountIsValid(string accountNumber);
        List<List<string>> ReadAllAccountNumbers(string filePath);
        void AddInfo(AccountNumber account);
    }
}
