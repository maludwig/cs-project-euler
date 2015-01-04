using ProjectEuler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Primes {
    public class MillerRabin : IPrimalityTest {
        static int[] iaTestValues = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

        public bool IsPrime(int i) {
            if (i < 2) return false;
           // int iRoot = (int)Math.Sqrt(i);
            //if (iRoot * iRoot == i) return false;
            if (i % 2 == 0) return false ^ (i == 2);
            if (i % 3 == 0) return false ^ (i == 3);
            if (i % 5 == 0) return false ^ (i == 5);
            if (i % 7 == 0) return false ^ (i == 7);
            if (i % 61 == 0) return false ^ (i == 61);
            //if (i.IsSquare()) return false;
            if (!MillerRabinPass(2, i)) return false;
            if (!MillerRabinPass(7, i)) return false;
            if (!MillerRabinPass(61, i)) return false;
            return true;
        }

        public bool IsPrime(long i) {
            if (i < int.MaxValue) return IsPrime((int)i);

            foreach (int iElement in iaTestValues) {
                if (!MillerRabinPass(iElement, i)) return false;
            }
            return true;
        }
        public bool IsPrime(BigInteger b) {
            if (b < long.MaxValue) return IsPrime((long)b);

            foreach (int iElement in iaTestValues) {
                if (!MillerRabinPass(iElement, b)) return false;
            }
            return true;
        }
        public bool IsComposite(int i) {
            return !IsPrime(i);
        }
        public bool IsComposite(long i) {
            return !IsPrime(i);
        }
        public bool IsComposite(BigInteger b) {
            return !IsPrime(b);
        }

        public static bool MillerRabinPass(int iWitness, int iNum) {
            int d = iNum - 1;
            int s = d.CountBinaryTrailingZeros();
            d >>= s;
            int iWitnessPowModN = iWitness.ModPow(d, iNum);
            if (iWitnessPowModN == 1) return true;
            for (int i = 0; i < s - 1; i++) {
                if (iWitnessPowModN == iNum - 1) return true;
                iWitnessPowModN = iWitnessPowModN.ModPow(2, iNum);
            }
            if (iWitnessPowModN == iNum - 1) return true;
            return false;
        }
        public static bool MillerRabinPass(long iWitness, long iNum) {
            long d = iNum - 1L;
            int s = d.CountBinaryTrailingZeros();
            d >>= s;
            long iWitnessPowModN = iWitness.ModPow(d, iNum);
            if (iWitnessPowModN == 1L) return true;
            for (int i = 0; i < s - 1; i++) {
                if (iWitnessPowModN == iNum - 1L) return true;
                iWitnessPowModN = iWitnessPowModN.ModPow(2L, iNum);
            }
            if (iWitnessPowModN == iNum - 1L) return true;
            return false;
        }
        public static bool MillerRabinPass(BigInteger iWitness, BigInteger iNum) {

            BigInteger d = iNum - 1;
            int s = d.CountBinaryTrailingZeros();
            d >>= s;
            BigInteger iWitnessPowModN = iWitness.ModPow(d, iNum);
            if (iWitnessPowModN == 1) return true;
            for (int i = 0; i < s - 1; i++) {
                if (iWitnessPowModN == iNum - 1) return true;
                iWitnessPowModN = iWitnessPowModN.ModPow(2, iNum);
            }
            if (iWitnessPowModN == iNum - 1) return true;
            return false;
        }
    }

}