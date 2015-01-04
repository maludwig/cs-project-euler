using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Primes {
    public class BailliePSW : IPrimalityTest {
        public bool IsPrime(int i) {
            if (i.IsSquare()) return false;
            if (i % 2 == 0) return false ^ (i == 2);
            if (i % 3 == 0) return false ^ (i == 3);
            if (i % 5 == 0) return false ^ (i == 5);
            if (i % 7 == 0) return false ^ (i == 7);
            if (i % 61 == 0) return false ^ (i == 61);

            return BailliePSWTest(i);
        }
        public bool IsPrime(long l) {
            if (l < int.MaxValue) return IsPrime((int)l);
            return BailliePSWTest(l);
        }
        public bool IsPrime(BigInteger b) {
            if (b < long.MaxValue) return IsPrime((long)b);
            return BailliePSWTest(b);
        }
        public bool IsComposite(int i) {
            return !IsPrime(i);
        }
        public bool IsComposite(long l) {
            return !IsPrime(l);
        }
        public bool IsComposite(BigInteger b) {
            return !IsPrime(b);
        }

        //-------------------------------

        public static bool BailliePSWTest(int iPossiblePrime) {
            if (iPossiblePrime.IsSquare()) return false;
            if (!strongProbablePrimeTest(iPossiblePrime)) return false;
            return LucasProbablePrimeTestPostSquaresTest(iPossiblePrime);
        }
        public static bool BailliePSWTest(long lPossiblePrime) {
            if (lPossiblePrime.IsSquare()) return false;
            if (!strongProbablePrimeTest(lPossiblePrime)) return false;
            return LucasProbablePrimeTestPostSquaresTest(lPossiblePrime);
        }
        public static bool BailliePSWTest(BigInteger bPossiblePrime) {
            if (bPossiblePrime.IsSquare()) return false;
            if (!strongProbablePrimeTest(bPossiblePrime)) return false;
            return LucasProbablePrimeTestPostSquaresTest(bPossiblePrime);
        }

        public static short JacobiSymbol(BigInteger bD, BigInteger bModulus) {
            return JacobiSymbol(bD, bModulus, false);
        }
        public static short JacobiSymbol(BigInteger bD, BigInteger bModulus, bool isNegative) {
            if (bModulus == 1) return 1;
            if (bModulus % 2 == 0 || bModulus < 0) throw new Exception();
            bD = bD % bModulus;
            if (bD < 0) bD += bModulus;
            if (BigInteger.Abs(bD.GCD(bModulus)) != 1) return 0;
            if (bD % 2 == 0) {
                if (bModulus % 8 == 1 || bModulus % 8 == 7) return JacobiSymbol(bD / 2, bModulus, isNegative);
                else if (bModulus % 8 == 3 || bModulus % 8 == 5) return JacobiSymbol(bD / 2, bModulus, isNegative ^ true);
                else throw new Exception();
            }
            if (bD == 1) {
                if (isNegative) return -1;
                return 1;
            }
            if (bModulus % 4 == 1 || bD % 4 == 1) return JacobiSymbol(bModulus, bD, isNegative);
            else return JacobiSymbol(bModulus, bD, isNegative ^ true);
        }

        public static bool strongProbablePrimeTest(int possiblePrime) {
            return ProjectEuler.Primes.MillerRabin.MillerRabinPass(2, possiblePrime);
        }
        public static bool strongProbablePrimeTest(long possiblePrime) {
            return ProjectEuler.Primes.MillerRabin.MillerRabinPass(2, possiblePrime);
        }
        public static bool strongProbablePrimeTest(BigInteger possiblePrime) {
            return ProjectEuler.Primes.MillerRabin.MillerRabinPass(2, possiblePrime);
        }

        public static bool LucasProbablePrimeTestPostSquaresTest(long possiblePrime) {
            if (possiblePrime % 2 == 0) return false ^ (possiblePrime == 2);
            long D = 5;
            while (JacobiSymbol(D, possiblePrime) != -1) {
                if (D < 0) {
                    D = -(D - 2);
                }
                else {
                    D = -(D + 2);
                }
            }
            long Q = (1 - D) / 4;
            long Ufirst = 0L;
            long Usecond = 1L;
            long index = 1L;
            while (index < possiblePrime + 1) {
                Usecond = (Usecond - Q * Ufirst) % possiblePrime;
                if (Usecond < 0) Usecond += possiblePrime;
                Ufirst = (Usecond + Q * Ufirst) % possiblePrime;
                if (Ufirst < 0) Ufirst += possiblePrime;
                index++;
            }
            return Usecond % (possiblePrime) == 0;
        }
        public static bool LucasProbablePrimeTestPostSquaresTest(BigInteger bPossiblePrime) {
            if (bPossiblePrime % 2 == 0) return false ^ (bPossiblePrime == 2);
            BigInteger D = 5;
            while (JacobiSymbol(D, bPossiblePrime) != -1) {
                if (D < 0) {
                    D = -(D - 2);
                }
                else {
                    D = -(D + 2);
                }
            }
            BigInteger Q = (1 - D) / 4;
            BigInteger Ufirst = 0L;
            BigInteger Usecond = 1L;
            BigInteger index = 1L;
            while (index < bPossiblePrime + 1) {
                Usecond = (Usecond - Q * Ufirst) % bPossiblePrime;
                if (Usecond < 0) Usecond += bPossiblePrime;
                Ufirst = (Usecond + Q * Ufirst) % bPossiblePrime;
                if (Ufirst < 0) Ufirst += bPossiblePrime;
                index++;
            }
            return Usecond % (bPossiblePrime) == 0;
        }


        public static bool LucasProbablePrimeTest(long possiblePrime) {
            if (possiblePrime % 2 == 0) return false ^ (possiblePrime == 2);
            if (possiblePrime.IsSquare()) return false;
            long D = 5;
            while (JacobiSymbol(D, possiblePrime) != -1) {
                if (D < 0) {
                    D = -(D - 2);
                }
                else {
                    D = -(D + 2);
                }
            }
            long Q = (1 - D) / 4;
            long Ufirst = 0L;
            long Usecond = 1L;
            long index = 1L;
            while (index < possiblePrime + 1) {
                Usecond = (Usecond - Q * Ufirst) % possiblePrime;
                if (Usecond < 0) Usecond += possiblePrime;
                Ufirst = (Usecond + Q * Ufirst) % possiblePrime;
                if (Ufirst < 0) Ufirst += possiblePrime;
                index++;
            }
            return Usecond % (possiblePrime) == 0;
        }


    }
}