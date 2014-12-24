using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class SumsTest {
        [TestMethod]
        public void SumDigitsFromStringTest() {
            Assert.AreEqual(8, Sums.sumDigits("1232"));
            Assert.AreEqual(0, Sums.sumDigits("0"));
            Assert.AreEqual(0, Sums.sumDigits(""));
        }
    }
}
