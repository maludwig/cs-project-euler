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

    }
}