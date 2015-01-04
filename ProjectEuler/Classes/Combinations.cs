using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ProjectEuler.Classes {
    public class Combinations {
        private string _sSeed;
        private int _iChoosing;
        public Combinations(string sSeed, int iChoosing) {
            _sSeed = sSeed;
            _iChoosing = iChoosing;
        }
        public static BigInteger CountCombinations(int iN, int iR) {
            BigInteger b;
            BigInteger bRet;
            b = iN - iR;
            bRet = b.Factorial();
            b = iR;
            bRet *= b.Factorial();
            b = iN;
            bRet = b.Factorial() / bRet;
            return bRet;
        }
    }
}