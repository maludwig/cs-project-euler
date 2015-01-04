using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ProjectEuler.Primes {
    public class BailliePSW : IPrimalityTest {
        public bool IsPrime(int i) {
            return IsPrime((long)i);
        }
        public bool IsPrime(long i) {
            return true;
        }
        public bool IsPrime(BigInteger b) {
            return true;
        }
        public bool IsComposite(int i) {
            return !IsPrime(i);
        }
        public bool IsComposite(long i) {
            return !IsPrime(i);
        }
        public bool IsComposite(BigInteger b) {
            return !IsPrime(b);
        }
        public static long EuclideanAlgorithm(long first, long second) {
            if (first == 0 || second == 0) {
                return first + second;
            }
            return EuclideanAlgorithm(second, first % second);
        }
        public static long PowerMod(long lbase, long exponent, long modulus) {
            long temp = lbase;
            while (exponent > 1) {
                temp = (temp * lbase) % modulus;
                exponent--;
            }
            return temp;
        }
        public static bool IsSquare(long possiblePrime) {
            long possibleRoot = findRoots(possiblePrime);
            return possibleRoot * possibleRoot == possiblePrime;
        }
        public static long findRoots(long n) {
            long root = Math.Min(1, n - 10);
            long oldRoot = 0;

            do {
                //System.out.println(root);
                oldRoot = root;
                root = (root + (n / root)) / 2;
                if (root - oldRoot == 1 & oldRoot == (root + (n / root)) / 2) {
                    return root;
                }
            }
            while (root - oldRoot != 0);
            return root;
            //System.out.println(root);
        }
        public static short JacobiSymbol(long D, long modulus) {
            return JacobiSymbol(D, modulus, false);
        }
        public static short JacobiSymbol(long D, long modulus, bool isNegative) {
            if (modulus == 1) return 1;
            if (modulus % 2 == 0 || modulus < 0) throw new Exception();
            D = D % modulus;
            if (D < 0) D += modulus;
            if (Math.Abs(EuclideanAlgorithm(D, modulus)) != 1) return 0;
            if (D % 2 == 0) {
                if (modulus % 8 == 1 || modulus % 8 == 7) return JacobiSymbol(D / 2, modulus, isNegative);
                else if (modulus % 8 == 3 || modulus % 8 == 5) return JacobiSymbol(D / 2, modulus, isNegative ^ true);
                else throw new Exception();
            }
            if (D == 1) {
                if (isNegative) return -1;
                return 1;
            }
            if (modulus % 4 == 1 || D % 4 == 1) return JacobiSymbol(modulus, D, isNegative);
            else return JacobiSymbol(modulus, D, isNegative ^ true);
        }

    }
}