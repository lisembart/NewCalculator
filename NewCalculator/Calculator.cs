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

        string firstHexNumber = string.Empty;
        string secondHexNumber = string.Empty;

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
            
            if(currentNumSystem == NumSystem.Binary)
            {
                value = NumberSystemConverter.ConvertBinaryToDecimal(value).ToString();
            } else if(currentNumSystem == NumSystem.Hex)
            {
                value = NumberSystemConverter.ConvertHexToDecimal(value).ToString();
            }
            double score = Math.Sqrt(double.Parse(value));
            if(currentNumSystem == NumSystem.Binary)
            {
                score = double.Parse(NumberSystemConverter.ConvertDecimalToBinary(score));
            } 
            if(currentNumSystem != NumSystem.Hex)
            {
                AddToCalculationsHistory(value, score, "√");
            }
            return score;
        }

        public string SetSqrtOperationHex(string value)
        {
            double decimalScore = SetSqrtOperation(value);
            string score = NumberSystemConverter.ConvertDecimalToHex(decimalScore);
            AddToCalculationsHistory(score, true);
            return score;           
        }

        public double SetRoundOperation(string value)
        {
            double score = Math.Round(double.Parse(value),0);
            AddToCalculationsHistory(value, score, "~");
            return score;
        }

        public void SetOperation(string value, string operation)
        {
            if(value != "" && currentNumSystem != NumSystem.Hex)
            {
                firstNumber = double.Parse(value);
            } 
            if(currentNumSystem == NumSystem.Hex)
            {
                firstHexNumber = value;
            }
            currentOperation = operation;
        }

        public void SetSecondNumber(double value)
        {
            secondNumber = value;
        }

        public void SetSecondNumber(string value)
        {
            secondHexNumber = value;
        }

        public void AddToCalculationsHistory(double score)
        {
            Calculation calculation = new Calculation(firstNumber, secondNumber, currentOperation, score);
            CalculationHistory.calculationHistoryList.Add(calculation);
        }

        public void AddToCalculationsHistory(string value,double score, string operation)
        {
            double number = double.Parse(value);
            Calculation calculation = new Calculation(number, operation, score);
            CalculationHistory.calculationHistoryList.Add(calculation);
        }

        public void AddToCalculationsHistory(string score)
        {
            Calculation calculation = new Calculation(firstHexNumber, secondHexNumber, currentOperation, score);
            CalculationHistory.calculationHistoryList.Add(calculation);
        }

        public void AddToCalculationsHistory(string score, bool hexSpecial = true)
        {
            Calculation calculation = new Calculation(firstHexNumber, currentOperation, score);
            CalculationHistory.calculationHistoryList.Add(calculation);
        }

        public double Calculate()
        {
            if(currentNumSystem == NumSystem.Binary)
            {
                firstNumber = NumberSystemConverter.ConvertBinaryToDecimal(firstNumber);
                secondNumber = NumberSystemConverter.ConvertBinaryToDecimal(secondNumber);
            } else if(currentNumSystem == NumSystem.Hex)
            {
                firstNumber = NumberSystemConverter.ConvertHexToDecimal(firstHexNumber);
                secondNumber = NumberSystemConverter.ConvertHexToDecimal(secondHexNumber);
            }
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
            if(currentNumSystem == NumSystem.Binary)
            {
                firstNumber = double.Parse(NumberSystemConverter.ConvertDecimalToBinary(firstNumber));
                secondNumber = double.Parse(NumberSystemConverter.ConvertDecimalToBinary(secondNumber));
                score = double.Parse(NumberSystemConverter.ConvertDecimalToBinary(score));
            }
            if(currentNumSystem == NumSystem.Binary || currentNumSystem == NumSystem.Decimal)
            {
                AddToCalculationsHistory(score);
            } else 
            {
                AddToCalculationsHistory(NumberSystemConverter.ConvertDecimalToHex(score));
            }
            firstNumber = score;
            return score;
        }
    }
}
