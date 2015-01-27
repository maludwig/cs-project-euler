using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class FractionTest {
        [TestMethod]
        public void Fractions() {
            Fraction f1, f2, f3;
            f1 = new Fraction(2, 3);
            f2 = new Fraction(4, 6);
            f3 = new Fraction(6, 9);
            Assert.AreEqual(f1, f2);
            Assert.AreEqual(f2, f3);
            Assert.AreEqual(f1, f3);
            Assert.AreEqual(f1 + f3, f2 + f3);
            Assert.AreEqual(f1 + f1, f2 + f2);
        }
        [TestMethod]
        public void BigFractions() {
            BigFraction bf1, bf2, bf3;
            Fraction f = new Fraction(200, 300);
            bf1 = new BigFraction(2, 3);
            bf2 = new BigFraction(4, 6);
            bf3 = new BigFraction(6, 9);
            Assert.AreEqual(bf1, bf2);
            Assert.AreEqual(bf2, bf3);
            Assert.AreEqual(bf1, bf3);
            Assert.AreEqual(bf1 + bf3, bf2 + bf3);
            Assert.AreEqual(bf1 + bf1, bf2 + bf2);
            Assert.AreEqual(f, bf2);
            Assert.AreEqual(f, bf3);
            Assert.AreEqual(f, bf3);
            Assert.AreEqual(f + bf3, bf2 + bf3);
            Assert.AreEqual(f + bf1, bf2 + bf2);
        }
        [TestMethod]
        public void SqrtConvergentTest() {
            Assert.AreEqual(new BigFraction(1, 1), BigFraction.SqrtConvergent(2, 0));
            Assert.AreEqual(new BigFraction(3, 2), BigFraction.SqrtConvergent(2, 1));
            Assert.AreEqual(new BigFraction(7, 5), BigFraction.SqrtConvergent(2, 2));
            Assert.AreEqual(new BigFraction(17, 12), BigFraction.SqrtConvergent(2, 3));
            Assert.AreEqual(new BigFraction(41, 29), BigFraction.SqrtConvergent(2, 4));
            Assert.AreEqual(new BigFraction(1, 1), BigFraction.SqrtConvergent(3, 0));
            Assert.AreEqual(new BigFraction(2, 1), BigFraction.SqrtConvergent(3, 1));
            Assert.AreEqual(new BigFraction(5, 3), BigFraction.SqrtConvergent(3, 2));
            Assert.AreEqual(new BigFraction(7, 4), BigFraction.SqrtConvergent(3, 3));
        }
    }
}
