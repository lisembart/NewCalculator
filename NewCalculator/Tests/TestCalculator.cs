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
            calculator.SetNumberSystem(NumSystem.Decimal);
            double firstNumber = 5.3;
            double secondNumber = 9.3;
            calculator.SetOperation(firstNumber.ToString(), "+");
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
            calculator.SetOperation(firstNumber.ToString(), "-");
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
            calculator.SetOperation(firstNumber.ToString(), "*");
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
            calculator.SetOperation(firstNumber.ToString(), "/");
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
            calculator.SetNumberSystem(NumSystem.Decimal);
            double firstNumber = 35.6;
            double secondNumber = 12;
            calculator.SetOperation(firstNumber.ToString(), "*");
            calculator.SetSecondNumber(12);
            double temp = calculator.Calculate();
            calculator.SetOperation("", "+");
            double thirdNumber = 15;
            calculator.SetSecondNumber(thirdNumber);
            double score = calculator.Calculate();
            Assert.AreEqual(442, score, 0.5);
        }

        #endregion



        #region BinaryOperations

        [Test]
        public void BinaryAddition()
        {
            calculator.TotalReset();
            calculator.SetNumberSystem(NumSystem.Binary);
            double firstNumber = 11010;
            double secondNumber = 110111;
            calculator.SetOperation(firstNumber.ToString(), "+");
            calculator.SetSecondNumber(secondNumber);
            double results = calculator.Calculate();
            Assert.AreEqual(1010001, results);
        }

        [Test]
        public void BinarySubstraction()
        {
            calculator.TotalReset();
            double firstNumber = 111010;
            double secondNumber = 110111;
            calculator.SetOperation(firstNumber.ToString(), "-");
            calculator.SetSecondNumber(secondNumber);
            double results = calculator.Calculate();
            Assert.AreEqual(11, results);
        }

        [Test]
        public void BinaryMultiplication()
        {
            calculator.TotalReset();
            double firstNumber = 1110;
            double secondNumber = 110111;
            calculator.SetOperation(firstNumber.ToString(), "*");
            calculator.SetSecondNumber(secondNumber);
            double results = calculator.Calculate();
            Assert.AreEqual(1100000010, results);
        }

        [Test]
        public void BinaryDivision()
        {
            calculator.TotalReset();
            double firstNumber = 11001010;
            double secondNumber = 1101;
            calculator.SetOperation(firstNumber.ToString(), "/");
            calculator.SetSecondNumber(secondNumber);
            double results = calculator.Calculate();
            Assert.AreEqual(1111, results);
        }

        [Test]
        public void BinaryPow()
        {
            calculator.TotalReset();
            double firstNumber = 10;
            double secondNumber = 101;
            calculator.SetOperation(firstNumber.ToString(), "^");
            calculator.SetSecondNumber(secondNumber);
            double results = calculator.Calculate();
            Assert.AreEqual(100000, results);
        }

        [Test]
        public void BinarySqrt()
        {
            calculator.TotalReset();
            double firstNumber = 10000000000;
            double results = calculator.SetSqrtOperation(firstNumber.ToString());
            Assert.AreEqual(100000, results);
        }

        #endregion

        #region HexOperations

        [Test]
        public void HexAddition()
        {
            calculator.TotalReset();
            calculator.SetNumberSystem(NumSystem.Hex);
            string firstNumber = "5CA";
            string secondNumber = "2FC";
            calculator.SetOperation(firstNumber, "+");
            calculator.SetSecondNumber(secondNumber);
            double score = calculator.Calculate();
            string results = NumberSystemConverter.ConvertDecimalToHex(score);
            Assert.AreEqual("8C6", results);
        }

        [Test]
        public void HexSubstraction()
        {
            calculator.TotalReset();
            calculator.SetNumberSystem(NumSystem.Hex);
            string firstNumber = "9BD";
            string secondNumber = "DF";
            calculator.SetOperation(firstNumber, "-");
            calculator.SetSecondNumber(secondNumber);
            double score = calculator.Calculate();
            string results = NumberSystemConverter.ConvertDecimalToHex(score);
            Assert.AreEqual("8DE", results);
        }

        [Test]
        public void HexMultiplication()
        {
            calculator.TotalReset();
            calculator.SetNumberSystem(NumSystem.Hex);
            string firstNumber = "8B";
            string secondNumber = "BDF";
            calculator.SetOperation(firstNumber, "*");
            calculator.SetSecondNumber(secondNumber);
            double score = calculator.Calculate();
            string results = NumberSystemConverter.ConvertDecimalToHex(score);
            Assert.AreEqual("67215", results);
        }

        [Test]
        public void HexDivision()
        {
            calculator.TotalReset();
            calculator.SetNumberSystem(NumSystem.Hex);
            string firstNumber = "9658BDA";
            string secondNumber = "DFA";
            calculator.SetOperation(firstNumber, "/");
            calculator.SetSecondNumber(secondNumber);
            double score = calculator.Calculate();
            string results = NumberSystemConverter.ConvertDecimalToHex(score);
            Assert.AreEqual("AC1C", results);
        }

        [Test]
        public void HexPow()
        {
            calculator.TotalReset();
            calculator.SetNumberSystem(NumSystem.Hex);
            string firstNumber = "2";
            string secondNumber = "D";
            calculator.SetOperation(firstNumber, "^");
            calculator.SetSecondNumber(secondNumber);
            double score = calculator.Calculate();
            string results = NumberSystemConverter.ConvertDecimalToHex(score);
            Assert.AreEqual("2000", results);
        }

        [Test]
        public void HexSqrt()
        {
            calculator.TotalReset();
            calculator.SetNumberSystem(NumSystem.Hex);
            string firstNumber = "10";
            string results = calculator.SetSqrtOperationHex(firstNumber);
            Assert.AreEqual("4", results);
        }

        #endregion
    }
}
