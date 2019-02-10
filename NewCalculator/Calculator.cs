using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalculator
{
    class Calculator
    {
        double firstNumber = 0;
        double secondNumber = 0;
        double currentNumber = 0;

        string currentOperation;

        NumSystem currentNumSystem;

        public void TotalReset()
        {
            firstNumber = 0;
            secondNumber = 0;
            currentNumber = 0;
        }

        public void SetNumberSystem(NumSystem numberSystem)
        {
            currentNumSystem = numberSystem;
        }

        public double SetSqrtOperation(string value)
        {
            return Math.Sqrt(double.Parse(value));
        }

        public double SetRoundOperation(string value)
        {
            return Math.Round(double.Parse(value),0);
        }

        public void SetOperation(string value, string operation)
        {
            if(value != "")
            {
                firstNumber = double.Parse(value);
            }
            currentOperation = operation;
        }

        public void SetSecondNumber(double value)
        {
            secondNumber = value;
        }

        public double Calculate()
        {
            double score = 0;
            switch (currentOperation)
            {
                case "+":
                    score = firstNumber + secondNumber;
                    break;
                case "-":
                    score = firstNumber - secondNumber;
                    break;
                case "*":
                    score = firstNumber * secondNumber;
                    break;
                case "/":
                    score = firstNumber / secondNumber;
                    break;
                case "^":
                    score = Math.Pow(firstNumber, secondNumber);
                    break;
            }
            firstNumber = score;
            return score;
        }
    }
}
