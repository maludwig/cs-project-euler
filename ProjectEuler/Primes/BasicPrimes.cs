using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ProjectEuler.Primes {
    public class BasicPrimes : IPrimalityTest {
        public bool IsPrime(int i) {
            return IsPrime((long)i);
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

    }
}