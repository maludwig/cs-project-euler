using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEuler.Primes;

namespace MikesEuler.Tests.NumberTests {
    [TestClass]
    public class PrimalityTestsTest {
        List<int> liPrimes = new List<int>(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });

        PrimeGenerator pg = new SieveOfAtkin();

        [TestMethod]
        public void TestPrimalityTests() {
            IPrimalityTest p = new BasicPrimes();
            List<int> liExtraPrimes = new List<int>();
            liPrimes.Add(23);
            liPrimes.AddRange(new int[] { 29, 31, 37 });
            liExtraPrimes.Add(41);
            liExtraPrimes.Add(43);
            liExtraPrimes.Add(47);
            liExtraPrimes.Add(53);
            liPrimes.AddRange(liExtraPrimes);

            TestAnInterface(p);

            p = new MillerRabin();
            TestAnInterface(p);
            BigInterfaceTest(p);
        }
        public void TestAnInterface(IPrimalityTest p) {
            for (int i = 0; i <= liPrimes[liPrimes.Count - 1]; i++) {
                Assert.AreEqual(liPrimes.Contains(i), p.IsPrime(i));
            }
        }
        public void BigInterfaceTest(IPrimalityTest p) {
            for (int i = 0; i <= pg.largestPrime(); i++) {
                Assert.AreEqual(pg.IsPrime(i), p.IsPrime(i));
            }
        }
    }
}
