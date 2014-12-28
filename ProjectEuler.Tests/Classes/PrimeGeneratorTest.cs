using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Diagnostics;
using System.Collections.Generic;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class PrimeGeneratorTest {
        [TestMethod]
        public void Atkin() {
            PrimeGenerator pg = new SieveOfAtkin();
            TestPrimes(pg);
        }
        [TestMethod]
        public void Eratosthenes() {
            PrimeGenerator pg = new SieveOfEratosthenes();
            TestPrimes(pg);
        }

        public void TestPrimes(PrimeGenerator pg) {
            Assert.AreEqual(2, pg.getPrime(0));
            Assert.AreEqual(3, pg.getPrime(1));
            Assert.AreEqual(5, pg.getPrime(2));
            Assert.AreEqual(7, pg.getPrime(3));
            Assert.AreEqual(11, pg.getPrime(4));
            Assert.AreEqual(997, pg.getPrime(167));
            try {
                pg.getPrime(pg.Count());
                Assert.Fail();
            } catch (IndexOutOfRangeException) {
            }
            //pg = new SieveOfEratosthenes(pg.FIVE);
            //pg = new SieveOfEratosthenes(pg.FORTY);
        }
        [TestMethod]
        public void Factor() {
            PrimeGenerator pg = new SieveOfAtkin();
            List<int> liFactors;
            liFactors = new List<int>(new int[] { 2, 5 });
            Assert.IsTrue(Extensions.EachItemEqual(liFactors, pg.factor(10)));
            liFactors = new List<int>(new int[] { 5 });
            Assert.IsTrue(Extensions.EachItemEqual(liFactors, pg.factor(5)));
            liFactors = new List<int>(new int[] { 71, 839, 1471, 6857 });
            Assert.IsTrue(Extensions.EachItemEqual(liFactors, pg.factor(600851475143)));
        }
        [TestMethod]
        public void Divisors() {
            PrimeGenerator pg = new SieveOfAtkin();
            List<int> liDivs;
            liDivs = new List<int>(new int[] { 1, 2, 4, 5, 10, 20 });
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.divisors(20)));
            liDivs = new List<int>(new int[] { 1, 2, 4, 5, 8, 10, 20, 40 });
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.divisors(40)));
            liDivs = new List<int>(new int[] { 1, 2, 4, 5, 8, 10, 16, 20, 40, 80 });
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.divisors(80)));
            liDivs = new List<int>(new int[] { 1, 3, 9, 27, 81 });
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.divisors(81)));
            liDivs = new List<int>(new int[] { 1, 3, 9, 27 });
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.properDivisors(81)));
            liDivs = new List<int>(new int[] { 1 });
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.divisors(1)));
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.properDivisors(6781)));
            liDivs = new List<int>(new int[] { 1, 6781 });
            Assert.IsTrue(Extensions.EachItemEqual(liDivs, pg.divisors(6781)));
        }
        [TestMethod]
        public void FindPrime() {
            PrimeGenerator pg = new SieveOfAtkin();
            Assert.AreEqual(2, pg.findPrime(5));
            Assert.AreEqual(-1, pg.findPrime(6));
            Assert.AreEqual(0, pg.findPrime(2));
            Assert.AreEqual(1, pg.findPrime(3));
            Assert.AreEqual(999, pg.findPrime(7919));
            pg = new SieveOfAtkin(20);
            Assert.AreEqual(1, pg.findClosestPrime(3));
            Assert.AreEqual(2, pg.findClosestPrime(4));
            Assert.AreEqual(3, pg.findClosestPrime(8));
            pg = new SieveOfAtkin();
            Assert.AreEqual(0, pg.findClosestPrime(0));
            Assert.AreEqual(999, pg.findClosestPrime(7919));
            Assert.AreEqual(999, pg.findClosestPrime(7920));
        }
        [TestMethod]
        public void CircularPrimes() {
            PrimeGenerator pg = new SieveOfAtkin();
            Assert.IsTrue(pg.IsCircularPrime(197));
            Assert.IsTrue(pg.IsCircularPrime(719));
            Assert.IsTrue(pg.IsCircularPrime(971));
            List<int> liCircs = new List<int>(new int[] { 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97 });
            for (int i = 1; i < 100; i++) {
                Assert.AreEqual(liCircs.Contains(i),pg.IsCircularPrime(i));
            }
        }
        [TestMethod]
        public void TruncatablePrimes() {
            PrimeGenerator pg = new SieveOfAtkin();
            Assert.IsTrue(pg.IsTruncatablePrime(3797));
            Assert.IsTrue(pg.IsTruncatablePrime(797));
            Assert.IsFalse(pg.IsTruncatablePrime(7));
            Assert.IsFalse(pg.IsTruncatablePrime(5));
        }
    }
}
