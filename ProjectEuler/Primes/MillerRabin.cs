using ProjectEuler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Primes {
    public class MillerRabin : IPrimalityTest {

        public bool IsPrime(int i) {
            if (i < 2) return false;
            if (i == 2) return true;
            if (i > 7) {
                if ((i % 2) == 0) return false;
                if ((i % 3) == 0) return false;
                if ((i % 5) == 0) return false;
                if ((i % 7) == 0) return false;
            }
            if (MillerRabinPass(2, i)) {
                if ((i <= 7 || MillerRabinPass(7, i))) {
                    if (i <= 61 || MillerRabinPass(61, i)) {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsPrime(long i) {
            long divisor = 2;
            if (i < 2) {
                return false;
            }
            while (divisor < i) {
                if (i % divisor == 0) {
                    return false;
                }
                divisor++;
            }
            return true;
        }
        public bool IsPrime(BigInteger b) {
            BigInteger divisor = 2;
            if (b < 2) {
                return false;
            }
            while (divisor < b) {
                if (b % divisor == 0) {
                    return false;
                }
                divisor++;
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
            for (int i = 0; i <= s - 1; i++) {
                if (iWitnessPowModN == iNum - 1) return true;
                iWitnessPowModN = iWitnessPowModN.ModPow(2, iNum);
            }
            if (iWitnessPowModN == iNum - 1) return true;
            return false;
        }

        public static bool GoodTest(int n) {
            if (n <= 1) return false;
            if (n == 2) return true;
            if ((n % 2) == 0) return false;
            if ((n % 3) == 0) return false;
            if ((n % 5) == 0) return false;
            if ((n % 7) == 0) return false;
            if ((n % 11) == 0) return false;
            if ((n % 13) == 0) return false;
            if ((n % 17) == 0) return false;
            if ((n % 19) == 0) return false;
            if ((n % 23) == 0) return false;
            if ((n % 29) == 0) return false;
            if ((n % 31) == 0) return false;
            if ((n % 37) == 0) return false;
            if ((n % 41) == 0) return false;
            if ((n % 43) == 0) return false;
            if ((n % 47) == 0) return false;
            if ((n % 53) == 0) return false;
            if ((n % 59) == 0) return false;
            if ((n % 61) == 0) return false;
            if (n > 61) {
                if (MillerRabinPass(2, n)) {
                    if (MillerRabinPass(7, n)) {
                        if (MillerRabinPass(61, n)) {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return true;
        }

    }

}