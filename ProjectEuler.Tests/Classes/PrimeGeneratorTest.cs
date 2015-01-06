using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Diagnostics;
using System.Collections.Generic;
using ProjectEuler.Primes;
using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class PrimeGeneratorTest {
        PrimeSieve Atkin = new SieveOfAtkin();
        PrimeSieve Eratosthenes = new SieveOfEratosthenes();
        [TestMethod]
        public void AtkinTest() {
            TestPrimes(Atkin);
        }
        [TestMethod]
        public void EratosthenesTest() {
            TestPrimes(Eratosthenes);
        }

        public void TestPrimes(PrimeSieve pg) {
            Assert.AreEqual(2, pg.getPrime(0));
            Assert.AreEqual(3, pg.getPrime(1));
            Assert.AreEqual(5, pg.getPrime(2));
            Assert.AreEqual(7, pg.getPrime(3));
            Assert.AreEqual(11, pg.getPrime(4));
            Assert.AreEqual(997, pg.getPrime(167));
            Assert.IsTrue(pg.IsPrime(2));
            Assert.IsTrue(pg.IsPrime(3));
            Assert.IsTrue(pg.IsPrime(5));
            Assert.IsTrue(pg.IsPrime(7));
            Assert.IsTrue(pg.IsPrime(2));
            Assert.IsFalse(pg.IsPrime(998));
            Assert.IsFalse(pg.IsPrime(30));
            Assert.IsFalse(pg.IsPrime(9));
            Assert.IsFalse(pg.IsPrime(8));
            Assert.IsFalse(pg.IsPrime(6));
            Assert.IsFalse(pg.IsPrime(4));
            Assert.IsTrue(pg.IsPrime(pg.getPrime(pg.Count() - 1)));
            Assert.IsTrue(pg.IsPrime(pg.getPrime(pg.Count() - 2)));
            Assert.IsTrue(pg.IsPrime(pg.getPrime(pg.Count() - 90)));
            Assert.IsFalse(pg.IsPrime(pg.getPrime(pg.Count() - 1) - 1));
            Assert.IsFalse(pg.IsPrime(pg.getPrime(pg.Count() - 2) - 1));
            Assert.IsFalse(pg.IsPrime(pg.getPrime(pg.Count() - 90) - 1));
            try {
                pg.getPrime(pg.Count());
                Assert.Fail();
            } catch (IndexOutOfRangeException) {
            }
        }
        [TestMethod]
        public void Factor() {
            List<int> liFactors;
            liFactors = new List<int>(new int[] { 2, 5 });
            Assert.IsTrue(liFactors.EachItemEqual(Atkin.Factors(10)));
            liFactors = new List<int>(new int[] { 5 });
            Assert.IsTrue(liFactors.EachItemEqual(Atkin.Factors(5)));
            liFactors = new List<int>(new int[] { 71, 839, 1471, 6857 });
            Assert.IsTrue(liFactors.EachItemEqual(Atkin.Factors(600851475143)));

        }
        [TestMethod]
        public void Divisors() {
            List<int> liDivs;
            liDivs = new List<int>(new int[] { 1, 2, 4, 5, 10, 20 });
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.divisors(20)));
            liDivs = new List<int>(new int[] { 1, 2, 4, 5, 8, 10, 20, 40 });
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.divisors(40)));
            liDivs = new List<int>(new int[] { 1, 2, 4, 5, 8, 10, 16, 20, 40, 80 });
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.divisors(80)));
            liDivs = new List<int>(new int[] { 1, 3, 9, 27, 81 });
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.divisors(81)));
            liDivs = new List<int>(new int[] { 1, 3, 9, 27 });
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.properDivisors(81)));
            liDivs = new List<int>(new int[] { 1 });
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.divisors(1)));
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.properDivisors(6781)));
            liDivs = new List<int>(new int[] { 1, 6781 });
            Assert.IsTrue(liDivs.EachItemEqual(Atkin.divisors(6781)));
        }
        [TestMethod]
        public void FindPrime() {
            Assert.AreEqual(2, Atkin.findPrime(5));
            Assert.AreEqual(-1, Atkin.findPrime(6));
            Assert.AreEqual(0, Atkin.findPrime(2));
            Assert.AreEqual(1, Atkin.findPrime(3));
            Assert.AreEqual(999, Atkin.findPrime(7919));
            Atkin = new SieveOfAtkin(20);
            Assert.AreEqual(1, Atkin.findClosestPrime(3));
            Assert.AreEqual(2, Atkin.findClosestPrime(4));
            Assert.AreEqual(3, Atkin.findClosestPrime(8));
            Atkin = new SieveOfAtkin();
            Assert.AreEqual(0, Atkin.findClosestPrime(0));
            Assert.AreEqual(999, Atkin.findClosestPrime(7919));
            Assert.AreEqual(999, Atkin.findClosestPrime(7920));
        }
        [TestMethod]
        public void CircularPrimes() {
            Assert.IsTrue(Atkin.IsCircularPrime(197));
            Assert.IsTrue(Atkin.IsCircularPrime(719));
            Assert.IsTrue(Atkin.IsCircularPrime(971));
            List<int> liCircs = new List<int>(new int[] { 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97 });
            for (int i = 1; i < 100; i++) {
                Assert.AreEqual(liCircs.Contains(i), Atkin.IsCircularPrime(i));
            }
        }
        [TestMethod]
        public void TruncatablePrimes() {
            Assert.IsTrue(Atkin.IsTruncatablePrime(3797));
            Assert.IsTrue(Atkin.IsTruncatablePrime(797));
            Assert.IsFalse(Atkin.IsTruncatablePrime(7));
            Assert.IsFalse(Atkin.IsTruncatablePrime(5));
        }
    }
}
