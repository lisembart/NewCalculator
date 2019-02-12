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

        public string[] GetAllOperations()
        {
            string[] operations = new string[calculationHistoryList.Count];
            for(int i = 0; i < calculationHistoryList.Count; i++)
            {
                operations[i] = calculationHistoryList[i].GetCalculation();
            }
            return operations;
        }
    }
}
