using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Extensions;
using System.Diagnostics;

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

        public static bool ReadingBinaryTest(int lTest) {
            int iIndex = (int) Math.Log(lTest, 2);
            int lOutput = 0;
            while (iIndex >= 1) {
                if ((lTest & (1 << iIndex)) == (1 << iIndex)) {
                    lOutput += 1;
                }
                lOutput *= 2;
                iIndex--;
            }
            if ((lTest & 1) == 1) lOutput += 1;
            return (lTest - lOutput) == 0;
        }
        public static bool ReadingBinaryTest(long lTest) {
            int iIndex = (int)Math.Log(lTest, 2);
            //int iIndex = 100;
            long lOutput = 0;
            //long ONE = 1L;
            while (iIndex >= 1L) {
                if ((lTest & (1L << iIndex)) == (1L << iIndex)) {
                    lOutput += 1;
                }
                lOutput *= 2;
                iIndex--;
            }
            if ((lTest & 1) == 1) lOutput += 1;
            Debug.WriteLine(lTest - lOutput);
            return (lTest - lOutput) == 0;
        }
//        101001101110110011100100100000111011110101111010010101100010111001
        public static bool ReadingBinaryTest(BigInteger bTest) {
            int iIndex = (int)BigInteger.Log(bTest, 2);
            //int iIndex = 100;
            BigInteger lOutput = 0;
            BigInteger ONE = 1L;
            while (iIndex >= 1) {
                if ((bTest & (ONE << iIndex)) == (ONE << iIndex)) {
                    lOutput += 1;
                }
                lOutput *= 2;
                iIndex--;
            }
            if ((bTest & 1) == 1) lOutput += 1;
            //Debug.WriteLine(bTest - lOutput);
            return (bTest - lOutput) == 0;
        }

        public static bool LucasProbablePrimeTestPostSquaresTest(int iPossiblePrime) {
            if (iPossiblePrime % 2 == 0) return false ^ (iPossiblePrime == 2);
            int iD = 5;
            while (JacobiSymbol(iD, iPossiblePrime) != -1) {
                if (iD < 0) {
                    iD = -(iD - 2);
                }
                else {
                    iD = -(iD + 2);
                }
            }
            long lQ = (1 - iD) / 4;
            long lNewQ = 1;
            long lU = 0;
            long lV = 2;
            int iIndex = (int)Math.Log(iPossiblePrime + 1, 2);
            while (iIndex >= 1L) {
                if ((iPossiblePrime + 1L & (1L << iIndex)) == (1L << iIndex)) {
                    lNewQ *= lQ;
                    lU = (lU + lV) % iPossiblePrime;
                    lV = (iD * lU - (iD - 1) * lV) % iPossiblePrime;
                    if (lU % 2 == 0) {
                        lU /= 2;
                    }
                    else {
                        lU = (lU + iPossiblePrime) / 2;
                    }
                    if (lV % 2 == 0) {
                        lV /= 2;
                    }
                    else lV = (lV + iPossiblePrime) / 2;
                }
                lU = lU * lV % iPossiblePrime;
                lV = ((lV * lV) % iPossiblePrime) - 2 * lNewQ % iPossiblePrime;
                lNewQ = lNewQ.ModPow(2, iPossiblePrime);
                iIndex--;
            }
            return lU % (iPossiblePrime) == 0;
        }


        public static bool LucasProbablePrimeTestPostSquaresTest(long lPossiblePrime) {
            if (lPossiblePrime % 2 == 0) return false ^ (lPossiblePrime == 2);
            long lD = 5;
            while (JacobiSymbol(lD, lPossiblePrime) != -1) {
                if (lD < 0) {
                    lD = -(lD - 2);
                }
                else {
                    lD = -(lD + 2);
                }
            }
            long lQ = (1 - lD) / 4;
            long lNewQ = 1;
            BigInteger lU = 0;
            BigInteger lV = 2;
            int iIndex = (int) Math.Log(lPossiblePrime + 1, 2);
            while (iIndex >= 1L) {
                if ((lPossiblePrime + 1L & (1L << iIndex)) == (1L << iIndex)) {
                    lNewQ *= lQ;
                    lU = (lU + lV) % lPossiblePrime;
                    lV = (lD*lU - (lD - 1)*lV) % lPossiblePrime;
                    if (lU % 2 == 0){
                        lU /= 2;
                    }
                    else {
                         lU = (lU + lPossiblePrime)/2;
                    }
                    if (lV % 2 == 0) {
                        lV /= 2;
                    }
                    else lV = (lV + lPossiblePrime) / 2;
                }
                lU = lU * lV % lPossiblePrime;
                lV = ((lV * lV ) % lPossiblePrime) - 2 * lNewQ % lPossiblePrime;
                lNewQ = lNewQ.ModPow(2, lPossiblePrime);
                iIndex--;
            }
            return lU % (lPossiblePrime) == 0;
        }
        public static bool LucasProbablePrimeTestPostSquaresTest(BigInteger lPossiblePrime) {
            if (lPossiblePrime % 2 == 0) return false ^ (lPossiblePrime == 2);
            long lD = 5;
            while (JacobiSymbol(lD, lPossiblePrime) != -1) {
                if (lD < 0) {
                    lD = -(lD - 2);
                }
                else {
                    lD = -(lD + 2);
                }
            }
            long lQ = (1 - lD) / 4;
            BigInteger lNewQ = 1;
            BigInteger lU = 0;
            BigInteger lV = 2;
            BigInteger ONE = (BigInteger)1;
            int iIndex = (int)BigInteger.Log(lPossiblePrime + 1, 2); ;
            while (iIndex >= 1) {
                if ((lPossiblePrime + 1 & (ONE << iIndex)) == (ONE << iIndex)) {
                    lNewQ *= lQ;
                    lU = (lU + lV) % lPossiblePrime;
                    lV = (lD * lU - (lD - 1) * lV) % lPossiblePrime;
                    if (lU % 2 == 0) {
                        lU /= 2;
                    }
                    else {
                        lU = (lU + lPossiblePrime) / 2;
                    }
                    if (lV % 2 == 0) {
                        lV /= 2;
                    }
                    else lV = (lV + lPossiblePrime) / 2;
                }
                lU = (lU * lV) % lPossiblePrime;
                lV = (((lV * lV) % lPossiblePrime) - 2 * lNewQ) % lPossiblePrime;
                lNewQ = lNewQ.ModPow(2, lPossiblePrime);
                iIndex--;
            }
            return lU % (lPossiblePrime) == 0;
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