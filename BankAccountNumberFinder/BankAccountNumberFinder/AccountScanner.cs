using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountNumberFinder
{
    public class AccountScanner
    {
        private readonly INumberFinder _bo;

        public AccountScanner(INumberFinder bo)
        {
            _bo = bo;
        }

        public List<AccountNumber> ScanEntry(string filePath)
        {
            return _bo.ScanEntry(filePath);
        }
    }
}
