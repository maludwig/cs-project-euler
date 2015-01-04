using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Classes;
using System.Text;

namespace ProjectEuler.Extensions {
    public static class LongExtensions {

        /// <summary>
        /// Calculates the current long, raised to the specified power.
        /// Usage: 3.Pow(4) == 81
        /// </summary>
        public static long Pow(this long x, long pow) {
            switch (pow) {
                case 0: return 1;
                case 1: return x;
                case 2: return x * x;
                case 3: return x * x * x;
                case 4: return x * x * x * x;
                case 5: return x * x * x * x * x;
                case 6: return x * x * x * x * x * x;
                case 7: return x * x * x * x * x * x * x;
                case 8: return x * x * x * x * x * x * x * x;
                case 9: return x * x * x * x * x * x * x * x * x;
                case 10: return x * x * x * x * x * x * x * x * x * x;
                case 11: return x * x * x * x * x * x * x * x * x * x * x;
                // up to 32 can be added 
                default: // Vilx's solution is used for default
                    long ret = 1;
                    while (pow != 0) {
                        if ((pow & 1) == 1)
                            ret *= x;
                        x *= x;
                        pow >>= 1;
                    }
                    return ret;
            }
        }
        /// <summary>
        /// Gets the n'th decimal digit from the end of a number
        /// </summary>
        public static long GetDigit(this long iNum, long iDigitIndex) {
            long TenPow = 10L.Pow(iDigitIndex - 1);
            return (iNum % (TenPow * 10)) / TenPow;
        }
        /// <summary>
        /// Starting from the n'th decimal digit from the end of a number, returns all following digits
        /// </summary>
        public static long GetDigits(this long iNum, long iDigitIndex) {
            return iNum % 10L.Pow(iDigitIndex);
        }
        /// <summary>
        /// Starting from the n'th decimal digit from the end of a number, returns the specified number of following digits
        /// </summary>
        public static long GetDigits(this long iNum, long iDigitIndex, long iLength) {
            long iCancelledTop = iNum % 10L.Pow(iDigitIndex);
            return iCancelledTop / 10L.Pow(iDigitIndex - iLength); ;
        }
        /// <summary>
        /// Returns true if iNum is a lexicographic permutation of iOther
        /// </summary>
        public static bool IsPermutationOf(this long iNum, long iOther) {
            Permutations p = new Permutations(iNum.ToString());
            return p.IsPermutationOf(iOther.ToString());
        }
        /// <summary>
        /// Returns true if i contains the specified digit at least once
        /// </summary>
        public static bool ContainsDigit(this long i, long iDigit) {
            long x;
            if (i == iDigit) return true;
            while (i > 0) {
                x = i % 10;
                if (x == iDigit) return true;
                i = i / 10;
            }
            return false;
        }
        /// <summary>
        /// Counts the number of occurrences of iDigit in i
        /// </summary>
        public static long CountDigits(this long i, int iDigit) {
            int x;
            long iCount = 0;
            if (i == iDigit) return 1;
            while (i > 0) {
                x = (int)(i % 10);
                if (x == iDigit) iCount++;
                i = i / 10;
            }
            return iCount;
        }
        //Returns true of all of the decimal digits are different (ex. 1234=true, 11=false)
        public static bool AllDigitsDifferent(this long i) {
            bool[] b = new bool[10];
            int x;
            while (i > 0) {
                x = (int)(i % 10);
                if (b[x]) return false;
                b[x] = true;
                i = i / 10;
            }
            return true;
        }

        //Returns n!
        public static long factorial(this long n) {
            long iResult = 1;
            for (long i = 2; i <= n; i++) iResult *= i;
            return iResult;
        }

        public static long GCD(this long iA, long iB) {
            if (iA == 0) return iB;
            if (iB == 0) return iA;
            if (iA > iB) return GCD(iB, iA % iB);
            return GCD(iA, iB % iA);
        }

        public static int CountBinaryTrailingZeros(this long iNum) {
            int i;
            for (i = 0; i < 64 && (iNum & 1) == 0; i++) {
                iNum >>= 1;
            }
            return i;
        }

        public static long ModPow(this long iBase, long iPower, long iModulus) {
            BigInteger bRet = BigInteger.ModPow(iBase, iPower, iModulus);
            return (long)bRet;
        }

        public static string ToBinaryString(this long source) {
            StringBuilder sb = new StringBuilder();
            string sRet;
            long i = source;
            if (i == 0) return "0";
            if (i < 0) i *= -1;
            while (i > 0) {
                sb.Append((i & 1) == 0 ? "0" : "1");
                i >>= 1;
            }
            if (source < 0) sb.Append("-");
            sRet = sb.ToString().StrReverse();
            return sRet;
        }
        public static bool IsSquare(this long possiblePrime) {
            long possibleRoot = (long) Math.Sqrt(possiblePrime);
            return possibleRoot * possibleRoot == possiblePrime;
        }
        /*
         * This method will work for really large long values.
         */
        public static long findRoot(this long n) {
            long root = 1;
            long oldRoot = 0;
            if (n == 0) return 0;
            n--;
            if (n == 0) return 1;
            do {
                oldRoot = root;
                root = (root + (n / root)) / 2;
                if (root - oldRoot == 1 & oldRoot == (root + (n / root)) / 2) {
                    return root;
                }
            }
            while (root - oldRoot != 0);
            return root;
        }
        public static long TruncateBinaryTrailingZeros(this long n) {
            return n >> n.CountBinaryTrailingZeros();
        }
    }
}