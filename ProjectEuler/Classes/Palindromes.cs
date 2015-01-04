using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ProjectEuler.Classes {
    public static class Palindromes {
        static int[] _iaLychrels = new int[10000];
        public static int LychrelValue(int i) {
            int iSum;
            if (i < _iaLychrels.Length) {
                if (_iaLychrels[i] != 0) return _iaLychrels[i];
                iSum = i + Reverse(i);
                if (IsPalindrome(iSum)) {
                    _iaLychrels[i] = 1;
                } else {
                    _iaLychrels[i] = LychrelValue(iSum) + 1;
                    if (_iaLychrels[i] == 0) _iaLychrels[i] = -1;
                }
                return _iaLychrels[i];
            } else {
                return CalculateLychrel(i);
            }
        }
        public static int CalculateLychrel(BigInteger b, int iMaxIterations = 60) {
            BigInteger bCurr;
            BigInteger bRev = Reverse(b);
            BigInteger bNext = b + bRev;
            int i;
            for (i = 1; i < iMaxIterations && !IsPalindrome(bNext); i++) {
                bCurr = bNext;
                bRev = Reverse(bCurr);
                bNext = bCurr + bRev;
            }
            if (i == iMaxIterations) return -1;
            return i;
        }

	    static public bool IsPalindrome(int i) {
		    return IsPalindrome(i.ToString());
	    }
	
	    static public bool IsPalindrome(String s) {
		    return IsPalindrome(s.ToCharArray());
	    }

        public static bool IsPalindrome(BigInteger b) {
            return IsPalindrome(b.ToString());
        }
	
	    static public bool IsPalindrome(char[] c) {
		    for (int i = 0; i < c.Length / 2; i++) {
			    if (c[i] != c[c.Length - i - 1]) {
				    return false;
			    }
		    }
		    return true;
	    }
	
	    static public int Reverse(int iRev) {
		    return int.Parse(Reverse(iRev.ToString()));
	    }

        public static BigInteger Reverse(BigInteger b) {
            return BigInteger.Parse(Reverse(b.ToString()));
        }
	
	    static public String Reverse(String s) {
		    return new String(Reverse(s.ToCharArray()));
            
	    }

        static public char[] Reverse(char[] cSrc) {
            char[] cRet = new char[cSrc.Length];
            for (int i = 0; i < cSrc.Length; i++) {
                cRet[i] = cSrc[cSrc.Length - i - 1];
            }
            return cRet;
        }
    }
}