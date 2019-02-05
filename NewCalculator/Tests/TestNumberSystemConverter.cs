using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NewCalculator.Tests
{
    [TestFixture]
    class TestNumberSystemConverter
    {
        [Test]
        public void DecimalToHex()
        {
            double decimalValue = 29;
            string results = NumberSystemConverter.ConvertDecimalToHex(decimalValue);
            Assert.AreEqual("1D", results);
        }

        [Test]
        public void HexToDecimal()
        {
            string hexValue = "2FC";
            double results = NumberSystemConverter.ConvertHexToDecimal(hexValue);
            Assert.AreEqual(764, results);
        }

        [Test]
        public void DecimalToBinary()
        {
            double decimalValue = 112;
            string results = NumberSystemConverter.ConvertDecimalToBinary(decimalValue);
            Assert.AreEqual("1110000", results);
        }

        [Test]
        public void BinaryToDecimal()
        {
            string binaryValue = "1101101";
            double results = NumberSystemConverter.ConvertBinaryToDecimal(binaryValue);
            Assert.AreEqual(109, results);
        }
    }
}
