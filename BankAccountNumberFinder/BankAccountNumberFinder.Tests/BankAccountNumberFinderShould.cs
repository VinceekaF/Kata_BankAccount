﻿using System;
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


        //string pathTest1 = Path.Combine(Environment.CurrentDirectory, "Test1.txt");

        [Theory]
        [InlineData(@"C:\Users\DUPINV\Desktop\Example55.txt", "111111145")]
        public void GetListOfAccountsNumber(string filePath, string number)
        {
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
        [InlineData(@"C:\Users\DUPINV\Desktop\Example55.txt", 5)]
        public void GetListOfAccounts(string filePath, int count)
        {
            List<List<string>> listOfAccount = NumberFinder.ReadAllAccountNumbers(filePath);

            Assert.Equal(count, listOfAccount.Count);
        }
    }
}
