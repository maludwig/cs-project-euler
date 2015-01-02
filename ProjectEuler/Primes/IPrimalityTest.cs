using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Primes {
    public interface IPrimalityTest {
        bool IsPrime(int i);
        bool IsPrime(long i);
        bool IsPrime(BigInteger b);
        bool IsComposite(int i);
        bool IsComposite(long i);
        bool IsComposite(BigInteger b);
    }
}
