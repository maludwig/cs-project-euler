using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ProjectEuler.Extensions {
    public static class BigIntegerExtensions {
        public static BigInteger Factorial(this BigInteger b) {
            BigInteger bRet = 1;
            for (BigInteger bDec = b; bDec > 1; bDec--) {
                bRet *= bDec;
            }
            return bRet;
        }
        public static BigInteger ModPow(this BigInteger bBase, BigInteger bPower, BigInteger bModulus) {
            return BigInteger.ModPow(bBase, bPower, bModulus);
        }
        public static BigInteger GCD(this BigInteger iA, BigInteger iB) {
            if (iA == 0) return iB;
            if (iB == 0) return iA;
            if (iA > iB) return GCD(iB, iA % iB);
            return GCD(iA, iB % iA);
        }
        public static int CountBinaryTrailingZeros(this BigInteger bNum) {
            int i;
            for (i = 0; i < 64 && (bNum & 1) == 0; i++) {
                bNum >>= 1;
            }
            return i;
        }

    }
}