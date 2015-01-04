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

        public static BigInteger GCD(this BigInteger iA, BigInteger iB) {
            if (iA == 0) return iB;
            if (iB == 0) return iA;
            if (iA > iB) return GCD(iB, iA % iB);
            return GCD(iA, iB % iA);
        }
    }
}