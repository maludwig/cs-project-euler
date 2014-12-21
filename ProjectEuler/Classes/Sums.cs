using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class Sums {
        public static int sumNaturalsTo(int iMax) {
            return (iMax * (iMax + 1)) / 2;
        }
        public static long sumDigitsFromString(string s) {
            int iSum = 0;
            for (int i = 0; i < s.Length; i++) {
                iSum += int.Parse(s.Substring(i, 1));
            }
            return iSum;
        }
    }
}