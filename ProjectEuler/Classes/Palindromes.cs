using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public static class Palindromes {
        
	    static public bool IsPalindrome(int i) {
		    return IsPalindrome(i.ToString());
	    }
	
	    static public bool IsPalindrome(String s) {
		    return IsPalindrome(s.ToCharArray());
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