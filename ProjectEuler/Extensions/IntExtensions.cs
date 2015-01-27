using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Classes;
using System.Text;

namespace ProjectEuler.Extensions {
    public static class IntExtensions {

        /// <summary>
        /// Calculates the current int, raised to the specified power.
        /// Usage: 3.Pow(4) == 81
        /// </summary>
        public static int Pow(this int x, int pow) {
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
                    int ret = 1;
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
        public static int GetDigit(this int iNum, int iDigitIndex) {
            int TenPow = 10.Pow(iDigitIndex - 1);
            return (iNum % (TenPow * 10)) / TenPow;
        }
        /// <summary>
        /// Starting from the n'th decimal digit from the end of a number, returns all following digits
        /// </summary>
        public static int GetDigits(this int iNum, int iDigitIndex) {
            return iNum % 10.Pow(iDigitIndex);
        }
        /// <summary>
        /// Starting from the n'th decimal digit from the end of a number, returns the specified number of following digits
        /// </summary>
        public static int GetDigits(this int iNum, int iDigitIndex, int iLength) {
            int iCancelledTop = iNum % 10.Pow(iDigitIndex);
            return iCancelledTop / 10.Pow(iDigitIndex - iLength); ;
        }
        /// <summary>
        /// Returns true if iNum is a lexicographic permutation of iOther
        /// </summary>
        public static bool IsPermutationOf(this int iNum, int iOther) {
            int[] iaCounts = new int[10];
            int iDigit;
            if (iNum == iOther) return true;
            while (iNum > 0) {
                iDigit = iNum % 10;
                iaCounts[iDigit]++;
                iNum = iNum / 10;
            }
            while (iOther > 0) {
                iDigit = iOther % 10;
                iaCounts[iDigit]--;
                iOther = iOther / 10;
            }
            foreach (int iDigitCount in iaCounts) {
                if (iDigitCount != 0) return false;
            }
            return true;
            //Permutations p = new Permutations(iNum.ToString());
            //return p.IsPermutationOf(iOther.ToString());
        }
        /// <summary>
        /// Returns true if i contains the specified digit at least once
        /// </summary>
        public static bool ContainsDigit(this int i, int iDigit) {
            int x;
            int iNum = i;
            if (i == iDigit) return true;
            while (iNum > 0) {
                x = iNum % 10;
                if (x == iDigit) return true;
                iNum = iNum / 10;
            }
            return false;
        }
        /// <summary>
        /// Counts the number of occurrences of iDigit in i
        /// </summary>
        public static int CountDigits(this int i, int iDigit) {
            int x;
            int iNum = i;
            int iCount = 0;
            if (i == iDigit) return 1;
            while (iNum > 0) {
                x = iNum % 10;
                if (x == iDigit) iCount++;
                iNum = iNum / 10;
            }
            return iCount;
        }
        /// <summary>
        /// Counts the number of decimal digits in i
        /// </summary>
        public static int CountDigits(this int i) {
            int iCount = 0;
            while (i > 0) {
                iCount++;
                i = i / 10;
            }
            return iCount;
        }
        //Returns true of all of the decimal digits are different (ex. 1234=true, 11=false)
        public static bool AllDigitsDifferent(this int i) {
            bool[] b = new bool[10];
            int x;
            while (i > 0) {
                x = i % 10;
                if (b[x]) return false;
                b[x] = true;
                i = i / 10;
            }
            return true;
        }

        //Returns n!
        public static int Factorial(this int n) {
            int iResult = 1;
            for (int i = 2; i <= n; i++) iResult *= i;
            return iResult;
        }

        public static int GCD(this int iA, int iB) {
            if (iA == 0) return iB;
            if (iB == 0) return iA;
            if (iA > iB) return GCD(iB, iA % iB);
            return GCD(iA, iB % iA);
        }

        public static int CountBinaryTrailingZeros(this int iNum) {
            int i;
            for (i = 0; i < 32 && (iNum & 1) == 0; i++) {
                iNum >>= 1;
            }
            return i;
        }

        public static int ModPow(this int iBase, int iPower, int iModulus) {
            long lRet = 1;
            for (int i = 31; i >= 0; i--) {
                lRet = (lRet * lRet) % iModulus;
                if ((iPower & (1 << i)) != 0) {
                    lRet = (lRet * iBase) % iModulus;
                }
            }
            return (int)lRet;
        }

        public static string ToBinaryString(this int source) {
            StringBuilder sb = new StringBuilder();
            string sRet;
            int i = source;
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

        public static int Sqrt(this int iNum) {
            return (int)Math.Sqrt(iNum);
        }
        public static bool IsSquare(this int iNum) {
            int possibleRoot = (int)Math.Sqrt(iNum);
            return possibleRoot * possibleRoot == iNum;
        }

    }
}