using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Primes;
using System.Diagnostics;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class MillerRabinExperiment {
        PrimeSieve pg = new SieveOfAtkin(1000);
        MillerRabin p = new MillerRabin();
        [TestMethod]
        public void StrongPseudoPrimes() {
            int iActualPrimeCount = 0;
            int iActualCompositeCount = 0;
            int iMRPrimeCount = 0;
            int iMRCompositeCount = 0;
            int iTotalCount = 0;
            for (int i = 1; i < pg.largestPrime(); i++) {
                iTotalCount++;
                if (pg.IsPrime(i)) {
                    iActualPrimeCount++;
                }
                if (MillerRabin.MillerRabinPass(2, i)) {
                    if (MillerRabin.MillerRabinPass(7, i)) {
                        iMRPrimeCount++;
                    }
                }
            }
            iActualCompositeCount = iTotalCount - iActualPrimeCount;
            iMRCompositeCount = iTotalCount - iMRPrimeCount;
            Debug.WriteLine("Total Count: " + iTotalCount);
            Debug.WriteLine("Actual - C: " + iActualCompositeCount + ", P: " + iActualPrimeCount);
            Debug.WriteLine("Miller Rabin - C: " + iMRCompositeCount + ", P: " + iMRPrimeCount);
        }
        [TestMethod]
        public void PassTest() {
            PrimeSieve pgAtkin = new SieveOfAtkin();
            Ticker t = new Ticker();
            foreach (int i in pgAtkin) {
                MillerRabin.MillerRabinPass(2, i);
            }
            t.Tick("2Pass");
            foreach (int i in pgAtkin) {
                MillerRabin.MillerRabinPass(3, i);
            }
            t.Tick("3Pass");
            foreach (int i in pgAtkin) {
                MillerRabin.MillerRabinPass(7, i);
            }
            t.Tick("7Pass");
            foreach (int i in pgAtkin) {
                MillerRabin.MillerRabinPass(61, i);
            }
            t.Tick("61Pass");
        }
    }
}
