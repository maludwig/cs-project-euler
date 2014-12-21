using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class SumsTest {
        [TestMethod]
        public void SumDigitsFromStringTest() {
            Assert.AreEqual(8, Sums.sumDigitsFromString("1232"));
            Assert.AreEqual(0, Sums.sumDigitsFromString("0"));
            Assert.AreEqual(0, Sums.sumDigitsFromString(""));
        }
    }
}
