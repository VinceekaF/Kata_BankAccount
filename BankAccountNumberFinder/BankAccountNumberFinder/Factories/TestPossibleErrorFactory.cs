using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountNumberFinder.Factories
{
    public interface ITestNumberFactory
    {
        bool TestAPossibleNumber(string accountNumber, int index);

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
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            return false;
        }
    }

    public class TestAllNumbers : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            bool isPossible = false;
            string falseAccountNumber = accountNumber.Remove(9);
            for (int j = 0; j < 10; j++)
            {
                isPossible = GlobalTest.Test(accountNumber, index, j.ToString());
                if (isPossible)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Test0Number : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            return GlobalTest.Test(accountNumber, index, "8");
        }
    }

    public class Test1Number : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            return GlobalTest.Test(accountNumber, index, "7");
        }
    }

    public class Test3Number : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            return GlobalTest.Test(accountNumber, index, "9");
        }
    }

    public class Test5Number : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            bool isPossible = GlobalTest.Test(accountNumber, index, "6");

            if (!isPossible)
            {
                isPossible = GlobalTest.Test(accountNumber, index, "9");
            }

            return isPossible;
        }
    }

    public class Test6Number : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, "8").Remove(9);

            return NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
        }
    }

    public class Test7Number : ITestNumberFactory
    {
         public bool TestAPossibleNumber(string accountNumber, int index)
            {
                return GlobalTest.Test(accountNumber, index, "1");
            }
    }

    public class Test8Number : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            bool isPossible = GlobalTest.Test(accountNumber, index, "0");

            if (!isPossible)
            {
                isPossible = GlobalTest.Test(accountNumber, index, "5");
            }

            return isPossible;
        }
    }

    public class Test9Number : ITestNumberFactory
    {
        public bool TestAPossibleNumber(string accountNumber, int index)
        {
            bool isPossible = GlobalTest.Test(accountNumber, index, "8");

            if (!isPossible)
            {
                isPossible = GlobalTest.Test(accountNumber, index, "5");
            }

            return isPossible;
        }
    }

    public class GlobalTest
    {
        public static bool Test(string accountNumber, int index, string numberToTest)
        {
            string falseAccountNumber = accountNumber;
            falseAccountNumber = falseAccountNumber.Remove(index, 1).Insert(index, numberToTest).Remove(9);
            return NumberFinder.CheckIfAccountIsValid(falseAccountNumber);
        }
    }
}
