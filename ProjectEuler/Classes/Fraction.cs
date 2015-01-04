using ProjectEuler.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Classes {
    public struct Fraction {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Fraction(int iNumerator, int iDenominator, bool bReduce = false)
            : this() {
            Numerator = iNumerator;
            Denominator = iDenominator;
            if (bReduce) {
                Reduce();
            }
        }
        public void Reduce() {
            int iGCD = Denominator.GCD(Numerator);
            Denominator /= iGCD;
            Numerator /= iGCD;
        }
        public static Fraction operator -(Fraction value) {
            value.Numerator *= -1;
            return value;
        }
        public static Fraction operator ++(Fraction value) {
            return value + 1;
        }
        public static Fraction operator -(Fraction left, int right) {
            return Add(left, -right);
        }
        public static Fraction operator -(Fraction left, Fraction right) {
            return Add(left, -right);
        }
        public static Fraction operator +(Fraction left, int right) {
            return Add(left, right);
        }
        public static Fraction operator +(int left, Fraction right) {
            return Add(right, left);
        }
        public static Fraction operator +(Fraction left, Fraction right) {
            return Add(left, right);
        }
        public static Fraction operator /(int left, Fraction right) {
            return new Fraction(left * right.Denominator,right.Numerator);
        }
        public static bool operator ==(Fraction left, Fraction right) {
            return left.Equals(right);
        }
        public static bool operator !=(Fraction left, Fraction right) {
            return !left.Equals(right);
        }
        private static Fraction Add(Fraction f, int i) {
            return new Fraction(f.Numerator + (i * f.Denominator), f.Denominator);
        }
        private static Fraction Add(Fraction left, Fraction right, bool bReduce = false) {
            if (left.Denominator == right.Denominator) return new Fraction(left.Numerator + right.Numerator, left.Denominator);
            return new Fraction(left.Numerator * right.Denominator + right.Numerator * left.Denominator, right.Denominator * left.Denominator);
        }
        private static Fraction Reduce(Fraction f) {
            f.Reduce();
            return f;
        }

        public bool Equals(Fraction other) {
            Fraction f1, f2;
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
            return obj is Fraction && Equals((Fraction)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (Denominator.GetHashCode() * 397) ^ Numerator;
            }
        }
        public override string ToString() {
            return Numerator + "/" + Denominator;
        }
    }
}