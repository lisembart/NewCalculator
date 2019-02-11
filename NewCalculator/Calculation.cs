using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalculator
{
    class Calculation
    {
        private double firstNumber;
        private double secondNumber;
        private string operation;
        private double score;
        private bool special;

        public Calculation(double firstNumber, double secondNumber, string operation, double score, bool special = false)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
            this.operation = operation;
            this.score = score;
            this.special = special;
        }

        public Calculation(double firstNumber, string operation, double score, bool special = true)
        {
            this.firstNumber = firstNumber;
            this.operation = operation;
            this.score = score;
            this.special = special;
        }

        public string GetCalculation()
        {
            if (!special)
            {
                return string.Format(firstNumber + " " + operation + " " + secondNumber + " = " + score);
            } else
            {
                if(operation == "~")
                {
                    return string.Format(firstNumber + " " + operation + " = " + score);
                } else
                {
                    return string.Format("√ " + firstNumber + " = " + score);
                }
            }
        }
    }
}
