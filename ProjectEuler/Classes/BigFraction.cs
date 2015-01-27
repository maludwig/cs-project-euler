using ProjectEuler.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Classes {
    public struct BigFraction {
        public BigInteger Numerator { get; set; }
        public BigInteger Denominator { get; set; }
        public BigFraction(BigInteger iNumerator, BigInteger iDenominator, bool bReduce = false)
            : this() {
            Numerator = iNumerator;
            Denominator = iDenominator;
            if (bReduce) {
                Reduce();
            }
        }
        public BigFraction(Fraction f, bool bReduce = false)
            : this() {
            Numerator = f.Numerator;
            Denominator = f.Denominator;
            if (bReduce) {
                Reduce();
            }
        }
        public void Reduce() {
            BigInteger iGCD = Denominator.GCD(Numerator);
            Denominator /= iGCD;
            Numerator /= iGCD;
        }
        public static BigFraction operator -(BigFraction value) {
            value.Numerator *= -1;
            return value;
        }
        public static BigFraction operator ++(BigFraction value) {
            return value + 1;
        }
        public static BigFraction operator -(BigFraction left, BigInteger right) {
            return Add(left, -right);
        }
        public static BigFraction operator -(BigFraction left, BigFraction right) {
            return Add(left, -right);
        }
        public static BigFraction operator +(BigFraction left, BigInteger right) {
            return Add(left, right);
        }
        public static BigFraction operator +(BigInteger left, BigFraction right) {
            return Add(right, left);
        }
        public static BigFraction operator +(BigFraction left, BigFraction right) {
            return Add(left, right);
        }
        public static BigFraction operator /(BigInteger left, BigFraction right) {
            return new BigFraction(left * right.Denominator, right.Numerator);
        }
        public static BigFraction operator /(BigFraction left, BigInteger right) {
            return new BigFraction(left.Numerator, left.Denominator * right);
        }
        public static bool operator ==(BigFraction left, BigFraction right) {
            return left.Equals(right);
        }
        public static bool operator !=(BigFraction left, BigFraction right) {
            return !left.Equals(right);
        }
        private static BigFraction Add(BigFraction f, BigInteger i) {
            return new BigFraction(f.Numerator + (i * f.Denominator), f.Denominator);
        }
        private static BigFraction Add(BigFraction left, BigFraction right, bool bReduce = false) {
            if (left.Denominator == right.Denominator) return new BigFraction(left.Numerator + right.Numerator, left.Denominator);
            return new BigFraction(left.Numerator * right.Denominator + right.Numerator * left.Denominator, right.Denominator * left.Denominator);
        }
        private static BigFraction Reduce(BigFraction f) {
            f.Reduce();
            return f;
        }
        public static implicit operator BigFraction(Fraction f) {
            return new BigFraction(f);
        }

        public bool Equals(BigFraction other) {
            BigFraction f1, f2;
            if (Denominator == other.Denominator) return Numerator == other.Numerator;
            f1 = Reduce(this);
            f2 = Reduce(other);
            if (f1.Denominator == f2.Denominator) return f1.Numerator == f2.Numerator;
            return false;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            return obj is BigFraction && Equals((BigFraction)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Denominator.GetHashCode() * 397) ^ Numerator.GetHashCode();
            }
        }
        public override string ToString() {
            return Numerator + "/" + Denominator;
        }

        //Fancy methods

        public static BigFraction SqrtConvergent(int iNum, int iConvergent) {
            if (iNum.IsSquare() || iConvergent == 0) return new BigFraction(iNum.Sqrt(), 1);

            List<int> liContFrac= Numbers.SqrtContinuedFraction(iNum);
            int iPeriod = liContFrac.Count - 1;
            iConvergent--;
            BigFraction f = new BigFraction(liContFrac[(iConvergent % iPeriod) + 1], 1);
            for (int i = iConvergent - 1; i >= 0; i--) {
                f = liContFrac[(i % iPeriod) + 1] + (1 / f);
            }
            f = liContFrac[0] + (1 / f);
            return f;
        }
    }
}