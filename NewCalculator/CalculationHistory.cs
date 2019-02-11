using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalculator
{
    class CalculationHistory
    {
        public static List<Calculation> calculationHistoryList = new List<Calculation>();

        public string GetLastOperation()
        {
            return calculationHistoryList[calculationHistoryList.Count - 1].GetCalculation();
        }
    }
}
