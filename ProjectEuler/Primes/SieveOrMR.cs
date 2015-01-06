using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ProjectEuler.Primes {
    public class SieveOrTest : IPrimalityTest {
        PrimeSieve _pg;
        IPrimalityTest _pt;
        public SieveOrTest(PrimeSieve pg, IPrimalityTest pt) {
            _pg = pg;
            _pt = pt;
        }
        public bool IsPrime(int iNum) {
            if (iNum > _pg.largestPrime()) {
                return _pt.IsPrime(iNum);
            } else {
                return _pg.IsPrime(iNum);
            }
        }
        public bool IsPrime(long l) {
            if (l < int.MaxValue) return IsPrime((int)l);
            return _pt.IsPrime(l);
        }
        public bool IsPrime(BigInteger b) {
            if (b < int.MaxValue) return IsPrime((int)b);
            return _pt.IsPrime(b);
        }
        public bool IsComposite(int i) {
            return !IsPrime(i);
        }
        public bool IsComposite(long l) {
            return !IsPrime(l);
        }
        public bool IsComposite(BigInteger b) {
            return !IsPrime(b);
        }
    }
}