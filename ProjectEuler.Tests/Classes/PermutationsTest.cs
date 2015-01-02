using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Diagnostics;
using System.Collections.Generic;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class PermutationsTest {
        [TestMethod]
        public void Permutation() {
            Permutations pm = new Permutations("0123456789");
            Assert.IsTrue(pm.IsPermutationOf("2783915460"));
            Assert.AreEqual("2783915460", pm[1000000-1]);
            pm = new Permutations("012");
            Assert.AreEqual("012", pm[0]);
            Assert.AreEqual("021", pm[1]);
            Assert.AreEqual("120", pm[3]);
            Assert.AreEqual("210", pm[5]);
            Assert.IsTrue(pm.IsPermutationOf("012"));
            Assert.IsTrue(pm.IsPermutationOf("021"));
            Assert.IsTrue(pm.IsPermutationOf("210"));
            Assert.IsFalse(pm.IsPermutationOf("0124"));
            Assert.IsFalse(pm.IsPermutationOf("01"));
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
        [TestMethod]
        public void ReplPermsTest() {
            List<string> ls = Permutations.ReplacementPermutations("56606", '6', 'x');
            string[] saCompare = new string[] { "5xx0x", "56x0x", "5x60x", "5660x", "5xx06", "56x06", "5x606", "56606" };
            Assert.IsTrue(saCompare.EachItemEqual(ls));
            ls = Permutations.ReplacementPermutations("56606", '7', 'x');
            saCompare = new string[] { "56606" };
            Assert.IsTrue(saCompare.EachItemEqual(ls));
        }
    }
}
