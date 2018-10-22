using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BankAccountNumberFinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BankAccountNumberFinder.BDD
{
    [Binding]
    public sealed class StepBankAccountNumberFinder
    {
        INumberFinder Bo;

        public StepBankAccountNumberFinder()
        {
            Bo = new NumberFinder();
        }
        public static List<AccountNumber> Output
        {
            get => ScenarioContext.Current.Get<List<AccountNumber>>(nameof(Output));
            set => ScenarioContext.Current.Set(value, nameof(Output));
        }

        public static string accountNumber
        {
            get => ScenarioContext.Current.Get<string>(nameof(accountNumber));
            set => ScenarioContext.Current.Set(value, nameof(accountNumber));
        }

        [When(@"I read a text (.*)")]
        public void WhenIReadAText(string fileName)
        {
            string filePath = GetPath(fileName);
            Output = Bo.ScanEntry(filePath);
        }

        [When(@"I target an account by its (.*)")]
        public void WhenITargetAnAccountByIts(int index)
        {
            accountNumber = Output[index].accountNumber;
        }

        [Then(@"I want to get a list with the correct count of account (.*)")]
        public void ThenIWantToGetTheAccount(int count)
        {
            Assert.AreEqual(count, Output.Count);
        }

        [Then(@"I want to get a normalized (.*)")]
        public void ThenIWantToGetANormalized(string account)
        {
            Assert.AreEqual(account, accountNumber);
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
