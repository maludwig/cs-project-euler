using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class CombinationsTest {
        [TestMethod]
        public void NChooseRTest() {
            //BigInteger b;
            Assert.AreEqual(1144066, Combinations.CountCombinations(23, 10));
            Assert.AreEqual(10, Combinations.CountCombinations(5, 3));
            for (int i = 1; i < 100; i++) {
                Assert.AreEqual(i, Combinations.CountCombinations(i, 1));
                Assert.AreEqual(1, Combinations.CountCombinations(i, i));
            }
        }
    }
}
