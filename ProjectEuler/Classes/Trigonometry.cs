using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public static class Trigonometry {
        public static bool IsPythagoreanTriplet(long a, long b, long c) {
            return a * a + b * b == c * c;
        }
    }
}