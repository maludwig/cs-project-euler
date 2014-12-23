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
    }
}
