using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectEuler.Classes {
    public static class Extensions {
        /// <summary>
        /// Get the array slice between the two indexes.
        /// ... Inclusive for start index, exclusive for end index.
        /// </summary>
        public static T[] Slice<T>(this T[] source, int start, int end) {
            // Handles negative ends.
            if (end < 0) {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++) {
                res[i] = source[i + start];
            }
            return res;
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
            sRet = sb.ToString().StrReverse();
            if (source < 0) {
                sRet = "-" + sRet;
            }
            return sRet;
        }

        public static string StrReverse(this string source) {
            char[] ca = source.ToCharArray();
            Array.Reverse(ca);
            return new string(ca);
        }

        public static bool IsPalindrome(this string source) {
            char[] ca = source.ToCharArray();
            for (int i = 0; i < source.Length / 2; i++) {
                if (ca[i] != ca[source.Length - 1 - i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Compare two enumerable objects to see if each item is equal
        /// </summary>
        public static bool EachItemEqual<T>(this IEnumerable<T> list1, IEnumerable<T> list2) {
            if (list1.Count() != list2.Count()) return false;
            IEnumerator<T> enum1 = list1.GetEnumerator();
            IEnumerator<T> enum2 = list2.GetEnumerator();
            while (enum1.MoveNext()) {
                enum2.MoveNext();
                if (!enum1.Current.Equals(enum2.Current)) return false;
            }
            return true;
        }

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
    }
}