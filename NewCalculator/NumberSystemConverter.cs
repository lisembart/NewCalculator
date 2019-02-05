using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalculator
{
    static class NumberSystemConverter
    {
        public static string ConvertDecimalToHex(double value)
        {
            string result = Convert.ToString((int)value, 16);
            return result.ToUpper();
        }

        public static double ConvertHexToDecimal(string value)
        {
            return Convert.ToInt32(value, 16);
        }

        public static string ConvertDecimalToBinary(double value)
        {
            return Convert.ToString((int)value, 2);
        }

        public static double ConvertBinaryToDecimal(string value)
        {
            return Convert.ToInt32(value, 2);
        }
    }
}
