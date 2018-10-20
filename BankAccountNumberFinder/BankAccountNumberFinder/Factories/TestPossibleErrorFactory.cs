using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountNumberFinder.Factories
{
    public interface ITestNumberFactory
    {
        void TestAPossibleNumber(AccountNumber account, int index);

    }
    public static class TestPossibleErrorFactory
    {
        public static ITestNumberFactory TestAll() => new TestAllNumbers();
        public static ITestNumberFactory Test0() => new Test0Number();
        public static ITestNumberFactory Test1() => new Test1Number();
        public static ITestNumberFactory Test3() => new Test3Number();
        public static ITestNumberFactory Test5() => new Test5Number();
        public static ITestNumberFactory Test6() => new Test6Number();
        public static ITestNumberFactory Test7() => new Test7Number();
        public static ITestNumberFactory Test8() => new Test8Number();
        public static ITestNumberFactory Test9() => new Test9Number();
        public static ITestNumberFactory TestNone() => new TestNone();
    }

    public class TestNone : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
        }
    }

    public class TestAllNumbers : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            account.isReadable = false;
            for (int j = 0; j < 10; j++)
            {
                GlobalTest.Test(account, index, j.ToString());
            }
        }
    }
    public class Test0Number : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            GlobalTest.Test(account, index, "8");
        }
    }

    public class Test1Number : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            GlobalTest.Test(account, index, "7");
        }
    }

    public class Test3Number : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            GlobalTest.Test(account, index, "9");
        }
    }

    public class Test5Number : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            GlobalTest.Test(account, index, "6");

            if (!account.errorPossible)
                GlobalTest.Test(account, index, "9");
        }
    }

    public class Test6Number : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            GlobalTest.Test(account, index, "8");
        }
    }

    public class Test7Number : ITestNumberFactory
    {
         public void TestAPossibleNumber(AccountNumber account, int index)
            {
                GlobalTest.Test(account, index, "1");
            }
    }

    public class Test8Number : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            GlobalTest.Test(account, index, "0");

            if (!account.errorPossible)
                GlobalTest.Test(account, index, "5");
        }
    }

    public class Test9Number : ITestNumberFactory
    {
        public void TestAPossibleNumber(AccountNumber account, int index)
        {
            GlobalTest.Test(account, index, "8");

            if (!account.errorPossible)
                GlobalTest.Test(account, index, "5");
            
        }
    }

    public class GlobalTest
    {
        public static void Test(AccountNumber account, int index, string numberToTest)
        {
            string falseAccountNumber = account.accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, numberToTest);
            account.errorPossible = NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
            if (account.errorPossible)
            {
                account.possibleRightNumber = account.accountNumber[index].ToString();
                account.possibleWrongNumber = numberToTest.ToString();
                account.positionOfWrongNumber = index;
            }
        }
    }
}
