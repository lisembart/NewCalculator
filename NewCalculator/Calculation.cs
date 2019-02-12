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

        private string firstNumberHex;
        private string secondNumberHex;
        private string scoreHex;
        private bool hexSystem;

        public Calculation(double firstNumber, double secondNumber, string operation, double score, bool special = false, bool hex = false)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
            this.operation = operation;
            this.score = score;
            this.special = special;
            this.hexSystem = hex;
        }

        public Calculation(double firstNumber, string operation, double score, bool special = true, bool hex = false)
        {
            this.firstNumber = firstNumber;
            this.operation = operation;
            this.score = score;
            this.special = special;
            this.hexSystem = hex;
        }

        public Calculation(string firstNumber, string secondNumber, string operation, string score, bool special = false, bool hex = true)
        {
            firstNumberHex = firstNumber;
            secondNumberHex = secondNumber;
            this.operation = operation;
            scoreHex = score;
            this.special = special;
            this.hexSystem = hex;
        }

        public Calculation(string firstNumber, string operation, string score, bool special = true, bool hex = true)
        {
            firstNumberHex = firstNumber;
            this.operation = operation;
            scoreHex = score;
            this.special = special;
            this.hexSystem = hex;
        }

        public string GetCalculation()
        {
            if (!hexSystem)
            {
                if (!special)
                {
                    return string.Format(firstNumber + " " + operation + " " + secondNumber + " = " + score);
                }
                else
                {
                    if (operation == "~")
                    {
                        return string.Format(firstNumber + " " + operation + " = " + score);
                    }
                    else
                    {
                        return string.Format("√ " + firstNumber + " = " + score);
                    }
                }
            } else
            {
                if (!special)
                {
                    return string.Format(firstNumberHex + " " + operation + " " + secondNumberHex + " = " + scoreHex);
                }
                else
                {
                    return string.Format("√ " + firstNumberHex + " = " + scoreHex);
                }
            }
        }
    }
}
