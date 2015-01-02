using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEuler.Classes;
using System.Numerics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class ExtensionsTest {
        [TestMethod]
        public void ListEquality() {
            List<int> l1 = new List<int>(new int[] { 1, 2, 3, 4 });
            List<int> l2 = new List<int>(new int[] { 1, 2, 3, 4 });
            Assert.IsTrue(l1.EachItemEqual(l2));
            l2.Add(5);
            Assert.IsFalse(l1.EachItemEqual(l2));
            l2 = new List<int>(new int[] { 8, 2, 1, 4 });
            Assert.IsFalse(l1.EachItemEqual(l2));
            l2 = l1;
            Assert.IsTrue(l1.EachItemEqual(l2));
            l1 = new List<int>();
            l2 = new List<int>();
            Assert.IsTrue(l1.EachItemEqual(l2));
        }
        [TestMethod]
        public void IsPalindrome() {
            Assert.IsTrue("1001".IsPalindrome());
            Assert.IsTrue("1bb1".IsPalindrome());
            Assert.IsTrue("1b1".IsPalindrome());
            Assert.IsTrue("1".IsPalindrome());
            Assert.IsTrue("".IsPalindrome());
            Assert.IsFalse("12".IsPalindrome());
            Assert.IsFalse("122".IsPalindrome());
            Assert.IsFalse("123".IsPalindrome());
        }
    }
}
