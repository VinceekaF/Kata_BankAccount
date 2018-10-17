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
        [InlineData(@"C:\Users\DUPINV\Desktop\Example2.txt", "729466750 is not a valid account")]
        [InlineData(@"C:\Users\DUPINV\Desktop\Example3.txt", "526902124")]
        [InlineData(@"C:\Users\DUPINV\Desktop\Example4.txt", "245852865 is not a valid account")]
        public void GetAListOfDigitsAndGetTheAccountNumber(string filePath, string number)
        {
            string accountNumber = NumberFinder.ScanEntry(filePath);

            Assert.Equal(number, accountNumber);
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
       

       
    }
}
