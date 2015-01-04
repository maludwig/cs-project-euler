using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Primes;
using System.Diagnostics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class MillerRabinExperiment {
        PrimeGenerator pg = new SieveOfAtkin();
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
                    iMRPrimeCount++;
                }
            }
            iActualCompositeCount = iTotalCount - iActualPrimeCount;
            iMRCompositeCount = iTotalCount - iMRPrimeCount;
            Debug.WriteLine("Total Count: " + iTotalCount);
            Debug.WriteLine("Actual - C: " + iActualCompositeCount + ", P: " + iActualPrimeCount);
            Debug.WriteLine("Miller Rabin - C: " + iMRCompositeCount + ", P: " + iMRPrimeCount);
        }
    }
}
