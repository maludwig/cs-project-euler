using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
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
            Permutations p = new Permutations(iNum.ToString());
            return p.IsPermutationOf(iOther.ToString());
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
        //Returns true of all of the decimal digits are different (ex. 1234=true, 11=false)
        public static bool AllDigitsDifferent(int i) {
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
    }
}