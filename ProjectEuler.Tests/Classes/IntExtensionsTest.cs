using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class IntExtensionsTest {
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
        [TestMethod]
        public void ContainsDigit() {
            Assert.IsTrue(200.ContainsDigit(0));
            Assert.IsTrue(0.ContainsDigit(0));
            Assert.IsTrue(1.ContainsDigit(1));
            Assert.IsTrue(2.ContainsDigit(2));
            Assert.IsTrue(30.ContainsDigit(3));
            Assert.IsFalse(0.ContainsDigit(3));
            Assert.IsFalse(1.ContainsDigit(4));
            Assert.IsFalse(20.ContainsDigit(1));
            Assert.IsFalse(300.ContainsDigit(5));
        }
        [TestMethod]
        public void TrailingZeros() {
            Assert.AreEqual(0, 1.CountBinaryTrailingZeros());
            Assert.AreEqual(0, 7.CountBinaryTrailingZeros());
            for (int i = 1; i < 1000; i += 2) {
                Assert.AreEqual(0, i.CountBinaryTrailingZeros());
            }
            for (int i = 0; i < 32; i++) {
                Assert.AreEqual(i, 2.Pow(i).CountBinaryTrailingZeros());
            }
        }
        [TestMethod]
        public void ModPow() {
            Assert.AreEqual(1, 2.ModPow(3, 7));
            Assert.AreEqual(2, 2.ModPow(4, 7));
            Assert.AreEqual(4, 2.ModPow(5, 7));
            Assert.AreEqual(1, 2.ModPow(6, 7));
            Assert.AreEqual(47, 174.ModPow(55, 221));
            Assert.AreEqual(220, 174.ModPow(110, 221));
            Assert.AreEqual(188, 137.ModPow(55, 221));
            Assert.AreEqual(205, 137.ModPow(110, 221));
            Assert.AreEqual(210, 2000000000.ModPow(55, 221));
            Assert.AreEqual(166, 2090000001.ModPow(106, 221));
            Assert.AreEqual(166, 2090000001.ModPow(106, 221));
            Assert.AreEqual(1248031580, 2090000009.ModPow(2090000007, 2090000001));
        }
        [TestMethod]
        public void GCDTest() {
            Assert.AreEqual(7, 7.GCD(0));
            Assert.AreEqual(7, 7.GCD(14));
            Assert.AreEqual(7, 7.GCD(21));
            Assert.AreEqual(4, 8.GCD(4));
            Assert.AreEqual(3, 300.GCD(9));
        }
        [TestMethod]
        public void PermTest() {
            Assert.IsTrue(73.IsPermutationOf(37));
            Assert.IsTrue(173.IsPermutationOf(317));
            Assert.IsTrue(9.IsPermutationOf(9));
            Assert.IsTrue(1.IsPermutationOf(1));
            Assert.IsTrue(1763.IsPermutationOf(3617));
            Assert.IsFalse(173.IsPermutationOf(3617));
            Assert.IsFalse(13.IsPermutationOf(3617));
            Assert.IsFalse(1.IsPermutationOf(3));
            Assert.IsFalse(67.IsPermutationOf(17));
            Assert.IsFalse(1.IsPermutationOf(3617));
        }
    }
}
