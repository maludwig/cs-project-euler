using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Diagnostics;

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
    }
}
