using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class Numbers {
        static int[] _iaColChainLengths = new int[100000]; //First 100 000 chain lengths memoizer (0.4MB in RAM)
        //Performs one step of the Collatz Problem
        public static long CollatzStep(long lNum) {
            if (lNum % 2 == 0) {
                return lNum / 2;
            } else {
                return (3 * lNum) + 1;
            }
        }
        //Returns the length of the Collatz Chain starting at lNum
        public static int CollatzChainLength(long lNum) {
            if (lNum == 1) return 1;
            else if (lNum < _iaColChainLengths.Length) {
                if (_iaColChainLengths[lNum] == 0) _iaColChainLengths[lNum] = CollatzChainLength(CollatzStep(lNum)) + 1;
                return _iaColChainLengths[lNum];
            } else {
                return CollatzChainLength(CollatzStep(lNum)) + 1;
            } 
        }
    }
}