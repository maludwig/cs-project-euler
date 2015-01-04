using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class LongExtensionsTest {
        [TestMethod]
        public void BinaryStringTest() {
            Assert.AreEqual("1001", 9L.ToBinaryString());
            Assert.AreEqual("1011", 11L.ToBinaryString());
            Assert.AreEqual("1101", 13L.ToBinaryString());
            Assert.AreEqual("0", 0L.ToBinaryString());
            Assert.AreEqual("-10", (-2L).ToBinaryString());
            Assert.AreEqual("-11", (-3L).ToBinaryString());
        }
        [TestMethod]
        public void Pow() {
            Assert.AreEqual(3L, 3L.Pow(1L));
            Assert.AreEqual(9L, 3L.Pow(2L));
            Assert.AreEqual(27L, 3L.Pow(3L));
            Assert.AreEqual(81L, 3L.Pow(4L));
            Assert.AreEqual(243L, 3L.Pow(5L));
            Assert.AreEqual(729L, 3L.Pow(6L));
            Assert.AreEqual(2187L, 3L.Pow(7L));
            Assert.AreEqual(6561L, 3L.Pow(8L));
            Assert.AreEqual(19683L, 3L.Pow(9L));
            Assert.AreEqual(59049L, 3L.Pow(10L));
            Assert.AreEqual(177147L, 3L.Pow(11L));
            Assert.AreEqual(531441L, 3L.Pow(12L));
            Assert.AreEqual(1594323L, 3L.Pow(13L));
        }
        [TestMethod]
        public void GetDigit() {
            Assert.AreEqual(3L, 321L.GetDigit(3L));
            Assert.AreEqual(2L, 321L.GetDigit(2L));
            Assert.AreEqual(1L, 321L.GetDigit(1L));
            Assert.AreEqual(6L, 7654321L.GetDigit(6L));
            Assert.AreEqual(4567L, 1234567L.GetDigits(4L));
            Assert.AreEqual(456L, 1234567L.GetDigits(4L, 3L));
            Assert.AreEqual(45L, 1234567L.GetDigits(4L, 2L));
            Assert.AreEqual(4L, 1234567L.GetDigits(4L, 1L));
            Assert.AreEqual(5963L, 4875963L.GetDigits(4L));
            Assert.AreEqual(596L, 4875963L.GetDigits(4L, 3L));
            Assert.AreEqual(59L, 4875963L.GetDigits(4L, 2L));
            Assert.AreEqual(5L, 4875963L.GetDigits(4L, 1L));
        }
        [TestMethod]
        public void ContainsDigit() {
            Assert.IsTrue(200L.ContainsDigit(0L));
            Assert.IsTrue(0L.ContainsDigit(0L));
            Assert.IsTrue(1L.ContainsDigit(1L));
            Assert.IsTrue(2L.ContainsDigit(2L));
            Assert.IsTrue(30L.ContainsDigit(3L));
            Assert.IsFalse(0L.ContainsDigit(3L));
            Assert.IsFalse(1L.ContainsDigit(4L));
            Assert.IsFalse(20L.ContainsDigit(1L));
            Assert.IsFalse(300L.ContainsDigit(5L));
        }
        [TestMethod]
        public void TrailingZeros() {
            Assert.AreEqual(0L, 1L.CountBinaryTrailingZeros());
            Assert.AreEqual(0L, 7L.CountBinaryTrailingZeros());
            for (long i = 1L; i < 1000L; i += 2L) {
                Assert.AreEqual(0L, i.CountBinaryTrailingZeros());
            }
            for (long i = 0L; i < 64L; i++) {
                Assert.AreEqual(i, 2L.Pow(i).CountBinaryTrailingZeros());
            }
        }
    }
}
