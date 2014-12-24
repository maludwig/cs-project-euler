using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class BigNumbersTest {
        [TestMethod]
        public void BigIntegerTest() {
            BigInteger b = 1;
            Assert.IsTrue(b < 2000);
            Assert.IsTrue(b < 2);
            Assert.IsTrue(b > 0);
            Assert.IsTrue(b > -2000);
            Assert.IsTrue(b == 1);
            Assert.IsTrue(b != 2);
            Assert.IsFalse(b == 2);
            Assert.IsFalse(b == 200);

            b = 200;
            b /= 2;
            Assert.IsTrue(b == 100);
            b /= 2;
            Assert.IsTrue(b == 50);
            b /= 2;
            Assert.IsTrue(b == 25);
            b /= 2;
            Assert.IsTrue(b == 12);
            b /= 2;
            Assert.IsTrue(b == 6);
            b /= 2;
            Assert.IsTrue(b == 3);
            b /= 2;
            Assert.IsTrue(b == 1);
            b /= 2;
            Assert.IsTrue(b == 0);
        }
        [TestMethod]
        public void BigDecimalTest() {
            BigDecimal bd1 = 1;
            BigDecimal bd2 = 4;
            Assert.AreEqual("0.25", (bd1 / bd2).ToString());
            bd2 = bd2 * 8;
            Assert.AreEqual("0.03125", (bd1 / bd2).ToString());
            bd2 = bd2 * 8;
            Assert.AreEqual("0.00390625", (bd1 / bd2).ToString());
            bd2 = bd2 * 8;
            Assert.AreEqual("0.00048828125", (bd1 / bd2).ToString());
            bd2 = bd2 * 8;
            Assert.AreEqual("0.00006103515625", (bd1 / bd2).ToString());

            bd2 = new BigDecimal(123, -5);
            Assert.AreEqual("0.00123", bd2.ToString());
            bd2 = new BigDecimal(123, -4);
            Assert.AreEqual("0.0123", bd2.ToString());
            bd2 = new BigDecimal(123, -3);
            Assert.AreEqual("0.123", bd2.ToString());
            bd2 = new BigDecimal(123, -2);
            Assert.AreEqual("1.23", bd2.ToString());
            bd2 = new BigDecimal(123, -1);
            Assert.AreEqual("12.3", bd2.ToString());
            bd2 = new BigDecimal(123, 0);
            Assert.AreEqual("123", bd2.ToString());
            bd2 = new BigDecimal(123, 1);
            Assert.AreEqual("1230", bd2.ToString());
            bd2 = new BigDecimal(123, 2);
            Assert.AreEqual("12300", bd2.ToString());

            bd2 = new BigDecimal(321, 5);
            Assert.AreEqual("32100000", bd2.ToString());
            bd2 = new BigDecimal(321, 9);
            Assert.AreEqual("321000000000", bd2.ToString());
            bd2 = new BigDecimal(321, 10);
            Assert.AreEqual("321E10", bd2.ToString());
            bd2 = new BigDecimal(321, 11);
            Assert.AreEqual("321E11", bd2.ToString());
            bd2 = new BigDecimal(321, 12);
            Assert.AreEqual("321E12", bd2.ToString());
        }
    }
}
