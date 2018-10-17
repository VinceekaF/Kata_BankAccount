using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.IO;

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
        [InlineData(@"C:\Users\DUPINV\Desktop\Example.txt", "123456789")]
        [InlineData(@"C:\Users\DUPINV\Desktop\Example2.txt","729466750")]
        public void GetAListOfDigitsAndGetTheAccountNumber(string filePath, string number)
        {
            string accountNumber = NumberFinder.ScanEntry(filePath);

            Assert.Equal(number, accountNumber);
        }

        [Theory]
        [InlineData(" _ |_  _|", "5")]
        [InlineData(" _   |  |", "7")]
        [InlineData(" _ | ||_|", "0")]
        public void GetValueOfADigitSchema(string schema, string value)
        {
            string number = _digits[schema];

            Assert.Equal(value, number);
        }

       
    }
}
