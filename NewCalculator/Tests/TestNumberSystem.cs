using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NewCalculator.Tests
{
    [TestFixture]
    class TestNumberSystem
    {
        [Test]
        public void DecimalToHex()
        {
            double decimalValue = 29;
            string results = NumberSystem.ConvertDecimalToHex(decimalValue);
            Assert.AreEqual("1D", results);
        }

        [Test]
        public void HexToDecimal()
        {
            string hexValue = "2FC";
            double results = NumberSystem.ConvertHexToDecimal(hexValue);
            Assert.AreEqual(764, results);
        }

        [Test]
        public void DecimalToBinary()
        {
            double decimalValue = 112;
            string results = NumberSystem.ConvertDecimalToBinary(decimalValue);
            Assert.AreEqual("1110000", results);
        }

        [Test]
        public void BinaryToDecimal()
        {
            string binaryValue = "1101101";
            double results = NumberSystem.ConvertBinaryToDecimal(binaryValue);
            Assert.AreEqual(109, results);
        }
    }
}
