using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class PermutationsTest {
        [TestMethod]
        public void Permutation() {
            Permutations pm = new Permutations("0123456789");
            Assert.AreEqual("2783915460", pm[1000000-1]);
            pm = new Permutations("012");
            Assert.AreEqual("012", pm[0]);
            Assert.AreEqual("021", pm[1]);
            Assert.AreEqual("120", pm[3]);
            Assert.AreEqual("210", pm[5]);
        }

        [TestMethod]
        public void Iterate() {
            Permutations pm = new Permutations("0");
            Assert.AreEqual("0", string.Join(",", pm));
            pm = new Permutations("01");
            Assert.AreEqual("01,10", string.Join(",", pm));
            pm = new Permutations("012");
            Assert.AreEqual("012,021,102,120,201,210", string.Join(",", pm));
        }
    }
}
