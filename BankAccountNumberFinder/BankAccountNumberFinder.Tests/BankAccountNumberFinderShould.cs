using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.IO;
using System.Linq;


namespace BankAccountNumberFinder.Tests
{
    public class BankAccountNumberFinderShould
    {
        public Dictionary<string, string> _digits = new Dictionary<string, string>
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


        private readonly string pathTest1 = Path.Combine(Environment.CurrentDirectory, "Test55.txt");
 
        [Theory]
        [InlineData("Example55.txt", "111111145")]
        public void GetListOfAccountsNumber(string fileName, string number)
        {
            string filePath = GetPath(fileName);
            List<String> allAccountNumbersReadable = NumberFinder.ScanEntry(filePath);

            Assert.Equal(number, allAccountNumbersReadable[0]);
        }

        [Theory]
        [InlineData("345882865",true)]
        [InlineData("245852865",false)]
        [InlineData("111111145",true)]
        public void CheckAccountNumber(string accountNumber, bool isValid)
        {
            bool testIfValid = NumberFinder.CheckIfAccountIsValid(accountNumber);

            Assert.Equal(isValid, testIfValid);
        }
        
        [Theory]
        [InlineData("Example55.txt", 5)]
        [InlineData("Example66.txt", 5)]
        public void GetListOfAccounts(string fileName, int count)
        {
            string filePath = GetPath(fileName);
            List<List<string>> listOfAccount = NumberFinder.ReadAllAccountNumbers(filePath);

            Assert.Equal(count, listOfAccount.Count);
        }

        [Theory]
        [InlineData("490067715 ERR", "490067715 AMB")]
        [InlineData("556703120 ERR", "556703120 AMB")]
        [InlineData("9?3456740 ILL", "9?3456740 AMB")]
        public void CheckIfThereIsAPossibleError(string accountNumber, string expected)
        {
            accountNumber = NumberFinder.CheckPossibleErrors(accountNumber);

            Assert.Equal(expected, accountNumber);
        }

        private string GetPath(string fileName)
        {
            string path = @".\";

            while (!File.Exists(path + fileName))
            {
                path += @"..\";
            }

            return path + fileName;
        }
    }
}
