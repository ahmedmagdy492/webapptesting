using System;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestMath
    {
        [TestMethod]
        public void Sum_ValuesToSum_SumResult()
        {
            // arrangement
            int num1 = 12;
            int num2 = 34;
            int expected = 46;

            // act
            MyMath math = new MyMath();
            math.Sum(num1, num2);
            int actual = math.result;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Div_ValuesToDivideBy_ZeroExecptionChecking()
        {
            // arrange
            int num1 = 12;
            int num2 = 0;

            // act
            MyMath math = new MyMath();
            math.Div(num1, num2);
        }

        [TestMethod]
        public void Div_ValuesToDivideBy_DivisionResult()
        {
            // arrangement
            int num1 = 12;
            int num2 = 4;
            int expected = 3;

            // action
            MyMath math = new MyMath();
            math.Div(num1, num2);
            int actual = math.result;

            // assert
            Assert.AreEqual(expected, actual);
        }

        public void tst()
        {            
        }
    }
}
