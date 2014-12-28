using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEuler.Classes;

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
        public void BinaryStringTest() {
            Assert.AreEqual("1001", 9.ToBinaryString());
            Assert.AreEqual("1011", 11.ToBinaryString());
            Assert.AreEqual("1101", 13.ToBinaryString());
            Assert.AreEqual("0", 0.ToBinaryString());
            Assert.AreEqual("-10", (-2).ToBinaryString());
            Assert.AreEqual("-11", (-3).ToBinaryString());
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
        [TestMethod]
        public void Pow() {
            Assert.AreEqual(3, 3.Pow(1));
            Assert.AreEqual(9, 3.Pow(2));
            Assert.AreEqual(27, 3.Pow(3));
            Assert.AreEqual(81, 3.Pow(4));
            Assert.AreEqual(243, 3.Pow(5));
            Assert.AreEqual(729, 3.Pow(6));
            Assert.AreEqual(2187, 3.Pow(7));
            Assert.AreEqual(6561, 3.Pow(8));
            Assert.AreEqual(19683, 3.Pow(9));
            Assert.AreEqual(59049, 3.Pow(10));
            Assert.AreEqual(177147, 3.Pow(11));
            Assert.AreEqual(531441, 3.Pow(12));
            Assert.AreEqual(1594323, 3.Pow(13));
        }
        [TestMethod]
        public void GetDigit() {
            Assert.AreEqual(3, 321.GetDigit(3));
            Assert.AreEqual(2, 321.GetDigit(2));
            Assert.AreEqual(1, 321.GetDigit(1));
            Assert.AreEqual(6, 7654321.GetDigit(6));
            Assert.AreEqual(4567, 1234567.GetDigits(4));
            Assert.AreEqual(456, 1234567.GetDigits(4, 3));
            Assert.AreEqual(45, 1234567.GetDigits(4, 2));
            Assert.AreEqual(4, 1234567.GetDigits(4, 1));
            Assert.AreEqual(5963, 4875963.GetDigits(4));
            Assert.AreEqual(596, 4875963.GetDigits(4, 3));
            Assert.AreEqual(59, 4875963.GetDigits(4, 2));
            Assert.AreEqual(5, 4875963.GetDigits(4, 1));
        }
    }
}
