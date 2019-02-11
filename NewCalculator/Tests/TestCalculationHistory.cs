using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NewCalculator.Tests
{
    [TestFixture]
    class TestCalculationHistory
    {
        Calculator calculator = new Calculator();
        CalculationHistory calculationHistory = new CalculationHistory();

        [Test]
        public void TestAdditionOperation()
        {
            calculator.TotalReset();
            double firstNumber = 15;
            double secondNumber = 23;
            calculator.SetOperation(firstNumber.ToString(), "+");
            calculator.SetSecondNumber(23);
            calculator.Calculate();
            string operation = calculationHistory.GetLastOperation();
            Assert.AreEqual("15 + 23 = 38", operation);
        }

        [Test]
        public void TestSubstractionOperation()
        {
            calculator.TotalReset();
            double firstNumber = 43;
            double secondNumber = 23;
            calculator.SetOperation(firstNumber.ToString(), "-");
            calculator.SetSecondNumber(23);
            calculator.Calculate();
            string operation = calculationHistory.GetLastOperation();
            Assert.AreEqual("43 - 23 = 20", operation);
        }

        [Test]
        public void TestMultiplicationOperation()
        {
            calculator.TotalReset();
            double firstNumber = 6;
            double secondNumber = 23;
            calculator.SetOperation(firstNumber.ToString(), "*");
            calculator.SetSecondNumber(23);
            calculator.Calculate();
            string operation = calculationHistory.GetLastOperation();
            Assert.AreEqual("6 * 23 = 138", operation);
        }


        [Test]
        public void TestDivisionOperation()
        {
            calculator.TotalReset();
            double firstNumber = 850;
            double secondNumber = 5;
            calculator.SetOperation(firstNumber.ToString(), "/");
            calculator.SetSecondNumber(5);
            calculator.Calculate();
            string operation = calculationHistory.GetLastOperation();
            Assert.AreEqual("850 / 5 = 170", operation);
        }

        [Test]
        public void TestPowOperation()
        {
            calculator.TotalReset();
            double firstNumber = 2;
            double secondNumber = 9;
            calculator.SetOperation(firstNumber.ToString(), "^");
            calculator.SetSecondNumber(9);
            calculator.Calculate();
            string operation = calculationHistory.GetLastOperation();
            Assert.AreEqual("2 ^ 9 = 512", operation);
        }

        [Test]
        public void TestSqrtOperation()
        {
            calculator.TotalReset();
            double firstNumber = 1024;
            double score = calculator.SetSqrtOperation(firstNumber.ToString());
            string operation = calculationHistory.GetLastOperation();
            Assert.AreEqual("√ 1024 = 32", operation);
        }

        [Test]
        public void TestRoundOperation()
        {
            calculator.TotalReset();
            double firstNumber = 1025.2;
            double score = calculator.SetRoundOperation(firstNumber.ToString());
            string operation = calculationHistory.GetLastOperation();
            Assert.AreEqual("1025,2 ~ = 1025",operation);
        }
    }
}
