using System;
using System.Collections.Generic;
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
        public static string Output
        {
            get => ScenarioContext.Current.Get<string>(nameof(Output));
            set => ScenarioContext.Current.Set(value, nameof(Output));
        }


        [When(@"I read a (.*)")]
        public void WhenIReadALine(string digit)
        {
            Output = NumberFinder.ScanEntry(digit);
        }

        [Then(@"I want to find its (.*)")]
        public void ThenIWantToFindItsValue(int value)
        {
            Assert.AreEqual(value, Output);
        }



    }
}
