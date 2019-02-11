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
            double score = Math.Sqrt(double.Parse(value));
            AddToCalculationsHistory(score, "√");
            return score;
        }

        public double SetRoundOperation(string value)
        {
            double score = Math.Round(double.Parse(value),0);
            AddToCalculationsHistory(score, "~");
            return score;
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

        public void AddToCalculationsHistory(double score)
        {
            Calculation calculation = new Calculation(firstNumber, secondNumber, currentOperation, score);
            CalculationHistory.calculationHistoryList.Add(calculation);
        }

        public void AddToCalculationsHistory(double score, string operation)
        {
            Calculation calculation = new Calculation(firstNumber, operation, score);
            CalculationHistory.calculationHistoryList.Add(calculation);
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
            AddToCalculationsHistory(score);
            firstNumber = score;
            return score;
        }
    }
}
