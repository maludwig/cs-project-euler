using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class NumbersTest {
        [TestMethod]
        public void AllDigitsDifferentTest() {
            Assert.IsTrue(Numbers.AllDigitsDifferent(1234567890));
            Assert.IsFalse(Numbers.AllDigitsDifferent(11));
            Assert.IsFalse(Numbers.AllDigitsDifferent(9911));
            Assert.IsFalse(Numbers.AllDigitsDifferent(2131));
            Assert.IsTrue(Numbers.AllDigitsDifferent(1234560));
            Assert.IsTrue(Numbers.AllDigitsDifferent(123));
            Assert.IsTrue(Numbers.AllDigitsDifferent(0));
            Assert.IsFalse(Numbers.AllDigitsDifferent(0, 0));
            Assert.IsTrue(Numbers.AllDigitsDifferent(678));
            Assert.IsTrue(Numbers.AllDigitsDifferent(678, 1234));
            Assert.IsTrue(Numbers.AllDigitsDifferent(678, 1234, 90));
            Assert.IsTrue(Numbers.AllDigitsDifferent(6, 1, 9));
            Assert.IsFalse(Numbers.AllDigitsDifferent(16, 1, 9));
            Assert.IsFalse(Numbers.AllDigitsDifferent(0, 0, 0));
            Assert.IsFalse(Numbers.AllDigitsDifferent(16, 10, 90));
            Assert.IsFalse(Numbers.AllDigitsDifferent(36, 10, 20));
        }
        [TestMethod]
        public void PandigitalTest() {
            Assert.IsTrue(Numbers.IsPandigital(123456789, 9));
            Assert.IsTrue(Numbers.IsPandigital(123789456, 9));
            Assert.IsTrue(Numbers.IsPandigital(1237894560, 9, true));
            Assert.IsFalse(Numbers.IsPandigital(123, 4));
            Assert.IsFalse(Numbers.IsPandigital(123, 4, true));
            Assert.IsFalse(Numbers.IsPandigital(1230, 4, true));
            Assert.IsTrue(Numbers.IsPandigital(1230, 3, true));
            Assert.IsFalse(Numbers.IsPandigital(1230, 3, false));
            Assert.IsTrue(Numbers.Pandigital1To9(39, 186, 7254));
            Assert.IsFalse(Numbers.Pandigital1To9(309, 186, 7254));
            Assert.IsTrue(Numbers.Pandigital1To9(319, 86, 7254));
            Assert.IsFalse(Numbers.Pandigital1To9(0, 39186, 7254));
        }
    }
}
