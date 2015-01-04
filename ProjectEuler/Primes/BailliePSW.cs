using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Primes {
    public class BailliePSW : IPrimalityTest {
        public bool IsPrime(int i) {
            return IsPrime((long)i);
        }
        public bool IsPrime(long i) {
            return true;
        }
        public bool IsPrime(BigInteger b) {
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

        //-------------------------------



        public static short JacobiSymbol(long D, long modulus) {
            return JacobiSymbol(D, modulus, false);
        }
        public static short JacobiSymbol(long D, long modulus, bool isNegative) {
            if (modulus == 1) return 1;
            if (modulus % 2 == 0 || modulus < 0) throw new Exception();
            D = D % modulus;
            if (D < 0) D += modulus;
            if (Math.Abs(D.GCD(modulus)) != 1) return 0;
            if (D % 2 == 0) {
                if (modulus % 8 == 1 || modulus % 8 == 7) return JacobiSymbol(D / 2, modulus, isNegative);
                else if (modulus % 8 == 3 || modulus % 8 == 5) return JacobiSymbol(D / 2, modulus, isNegative ^ true);
                else throw new Exception();
            }
            if (D == 1) {
                if (isNegative) return -1;
                return 1;
            }
            if (modulus % 4 == 1 || D % 4 == 1) return JacobiSymbol(modulus, D, isNegative);
            else return JacobiSymbol(modulus, D, isNegative ^ true);
        }

        public bool strongProbablePrimeTest(long possiblePrime) {
            return ProjectEuler.Primes.MillerRabin.MillerRabinPass(2, possiblePrime);
            /*
            long d = possiblePrime - 1;
            long s = d.CountBinaryTrailingZeros();
            d >>= (int) s;
            long s = 1L;
            long evenFactor = 2L;
            while ((possiblePrime - 1L / evenFactor) % 2L == 0L) {
                evenFactor *= 2L;
            }
            long d = possiblePrime - 1L / evenFactor;
            long testElement = 2L.ModPow(d, possiblePrime);
            if (testElement == 1L | testElement == possiblePrime - 1L) {
                return true;
            }
            long counter = 1L;
            long newTestElement = testElement;
            while (counter < s) {
                newTestElement = (newTestElement * testElement) % possiblePrime;
                if ((newTestElement) == possiblePrime - 1L) {
                    return true;
                }
                counter++;
            }
            return false;
             */
        }

    }
}