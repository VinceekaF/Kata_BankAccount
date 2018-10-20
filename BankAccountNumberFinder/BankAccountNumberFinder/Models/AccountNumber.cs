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
        public int? positionOfWrongNumber { get; set; }

        public AccountNumber()
        {
            accountNumber = "";
            isReadable = true;
            errorPossible = false;
            isValid = true;
            possibleWrongNumber = "";
            possibleRightNumber = "";
        }
    }
}
