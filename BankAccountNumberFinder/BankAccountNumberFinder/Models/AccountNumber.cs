using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountNumberFinder
{
    public class AccountNumber
    {
        public string accountNumber { get; set; }
        public bool isReadable { get; set; }
        public bool errorPossible { get; set; }
        public bool isValid { get; set; }
        public string possibleWrongNumber { get; set; }
        public string possibleRightNumber { get; set; }

        public AccountNumber(string _accountNumber, bool _isReadable)
        {
            accountNumber = _accountNumber;
            isReadable = _isReadable;
            errorPossible = false;
            isValid = true;
            possibleWrongNumber = "";
            possibleRightNumber = "";
        }

        public void AddInfo(AccountNumber account)
        {
            if (!account.isValid && account.isReadable)
            {
                account.accountNumber += " ERR";
            }
            else if (!account.isReadable)
            {
                account.accountNumber += " ILL";
            }
        }

        public void ChangeInfo(AccountNumber account)
        {
            if (account.errorPossible && account.accountNumber.Contains("ERR"))
            {
                account.accountNumber = account.accountNumber.Replace("ERR", "AMB");
            }
            else if (!account.errorPossible && account.accountNumber.Contains("ERR"))
            {
                account.accountNumber = account.accountNumber.Replace("ERR", "ILL");
            }
            else if (account.errorPossible && account.accountNumber.Contains("ILL"))
            {
                account.accountNumber = account.accountNumber.Replace("ILL", "AMB");
            }
        }
    }
}
