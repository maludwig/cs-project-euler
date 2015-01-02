using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEuler.Primes;

namespace MikesEuler.Tests.NumberTests {
    [TestClass]
    public class PrimalityTestsTest {
        List<int> liPrimes = new List<int>(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });
        
        [TestMethod]
        public void TestPrimalityTests() {
            IPrimalityTest p = new BasicPrimes();
            TestAnInterface(p);
        }
        [TestMethod]
        public void TestBailliePSW() {
            IPrimalityTest p = new BailliePSW();
            TestAnInterface(p);
        }
        public void TestAnInterface(IPrimalityTest p) {
            for (int i = 0; i <= liPrimes[liPrimes.Count - 1]; i++) {
                Assert.AreEqual(liPrimes.Contains(i), p.IsPrime(i));
            }
        }
    }
}
