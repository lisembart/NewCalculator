using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NewCalculator.Tests
{
    [TestFixture]
    class TestCalculator
    {
        Calculator calculator = new Calculator();

        #region BasicOperationsTests

        [Test]
        public void TestAddition()
        {
            calculator.TotalReset();
            double firstNumber = 5.3;
            double secondNumber = 9.3;
            calculator.SetOperation(firstNumber.ToString(),"+");
            calculator.SetSecondNumber(9.3);
            double score = calculator.Calculate();
            Assert.AreEqual(14.6, score, 0.2);
        }

        [Test]
        public void TestSubstraction()
        {
            calculator.TotalReset();
            double firstNumber = 34;
            double secondNumber = 12.3;
            calculator.SetOperation(firstNumber.ToString(),"-");
            calculator.SetSecondNumber(12.3);
            double score = calculator.Calculate();
            Assert.AreEqual(21.7, score);
        }

        [Test]
        public void TestMultiplication()
        {
            calculator.TotalReset();
            double firstNumber = 5.6;
            double secondNumber = 12;
            calculator.SetOperation(firstNumber.ToString(),"*");
            calculator.SetSecondNumber(12);
            double score = calculator.Calculate();
            Assert.AreEqual(67.2, score, 0.2);
        }

        [Test]
        public void TestDivision()
        {
            calculator.TotalReset();
            double firstNumber = 78;
            double secondNumber = 12;
            calculator.SetOperation(firstNumber.ToString(),"/");
            calculator.SetSecondNumber(12);
            double score = calculator.Calculate();
            Assert.AreEqual(6.5, score);
        }

        #endregion

        #region SpecialMathOperations

        [Test]
        public void TestPow()
        {
            calculator.TotalReset();
            double firstNumber = 25;
            double secondNumber = 2;
            calculator.SetOperation(firstNumber.ToString(), "^");
            calculator.SetSecondNumber(2);
            double score = calculator.Calculate();
            Assert.AreEqual(625, score, 0.2);
        }

        [Test]
        public void TestSqrt()
        {
            calculator.TotalReset();
            double number = 625;
            double score = calculator.SetSqrtOperation(number.ToString());
            Assert.AreEqual(25, score);
        }

        [Test]
        public void TestRound()
        {
            calculator.TotalReset();
            double number = 4.4;
            double score = calculator.SetRoundOperation(number.ToString());
            Assert.AreEqual(4, score);
        }
        #endregion

        #region ContinuingOperations
        
        [Test]
        public void ContinuingAddition()
        {
            calculator.TotalReset();
            double firstNumber = 35.6;
            double secondNumber = 12;
            calculator.SetOperation(firstNumber.ToString(), "*");
            calculator.SetSecondNumber(12);
            double temp = calculator.Calculate();
            double thirdNumber = 15;
            calculator.SetOperation(thirdNumber.ToString(), "+");
            double score = calculator.Calculate();
            Assert.AreEqual(6408, score);
        }

        #endregion

        #region OtherTests

        #endregion
    }
}
