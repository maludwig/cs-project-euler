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
            if (!MillerRabin.MillerRabinPass(2, i)) return false;
            return IsLucasPseudoprime(i);
        }
        public bool IsPrime(long l) {
            if (l < int.MaxValue) return IsPrime((int)l);
            if (l.IsSquare()) return false;
            if (!MillerRabin.MillerRabinPass(2, l)) return false;
            return IsLucasPseudoprime(l);
        }
        public bool IsPrime(BigInteger b) {
            if (b.IsSquare()) return false;
            if (b < long.MaxValue) return IsPrime((long)b);
            if (!MillerRabin.MillerRabinPass(2, b)) return false;
            return IsLucasPseudoprime(b);
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

        public static short JacobiSymbol(BigInteger bD, BigInteger bModulus) {
            return JacobiSymbol(bD, bModulus, false);
        }
        public static short JacobiSymbol(BigInteger bD, BigInteger bModulus, bool isNegative) {
            BigInteger bModulusMod8;
            if (bModulus == 1) return 1;
            if (bModulus % 2 == 0 || bModulus < 0) throw new Exception();
            bD %= bModulus;
            if (bD < 0) bD += bModulus;
            if (BigInteger.Abs(bD.GCD(bModulus)) != 1) return 0;
            if (bD % 2 == 0) {
                bModulusMod8 = bModulus % 8;
                if (bModulusMod8 == 1 || bModulusMod8 == 7) return JacobiSymbol(bD / 2, bModulus, isNegative);
                else if (bModulusMod8 == 3 || bModulusMod8 == 5) return JacobiSymbol(bD / 2, bModulus, !isNegative);
                else throw new Exception();
            } else if (bD == 1) {
                if (isNegative) return -1;
                return 1;
            }
            if (bModulus % 4 == 1 || bD % 4 == 1) return JacobiSymbol(bModulus, bD, isNegative);
            else return JacobiSymbol(bModulus, bD, !isNegative);
        }
        public static long FindLucasD(BigInteger bPossiblePrime) {
            long iD = 5;
            while (JacobiSymbol(iD, bPossiblePrime) != -1) {
                if (iD < 0) {
                    iD = -(iD - 2);
                } else {
                    iD = -(iD + 2);
                }
            }
            return iD;
        }
        public static bool IsLucasPseudoprime(int iPossiblePrime) {
            long lD = FindLucasD(iPossiblePrime);
            long lQ = (1 - lD) / 4;
            long lNewQ = 1;
            long lU = 0;
            long lV = 2;
            int iIndex = (int)Math.Log(iPossiblePrime + 1, 2);
            while (iIndex >= 1L) {
                if ((iPossiblePrime + 1L & (1L << iIndex)) == (1L << iIndex)) {
                    lNewQ *= lQ;
                    lU = (lU + lV) % iPossiblePrime;
                    lV = (lD * lU - (lD - 1) * lV) % iPossiblePrime;
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

        public static bool IsLucasPseudoprime(long lPossiblePrime) {
            long lD = FindLucasD(lPossiblePrime);
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
        public static bool IsLucasPseudoprime(BigInteger lPossiblePrime) {
            long lD = FindLucasD(lPossiblePrime);
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
    }
}