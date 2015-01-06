using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Classes {
    public class Permutations : IEnumerable<string> {
        protected string _sSeed;
        public Permutations(string sSeed) {
            _sSeed = sSeed;
        }
        public Permutations(int iSeed) {
            _sSeed = iSeed.ToString();
        }
        public Permutations(long lSeed) {
            _sSeed = lSeed.ToString();
        }
        public string this[int iIndex] {
            get {
                string sRemainingDigits = _sSeed;
                int iFactorial;
                string sResult = "";
                while (sRemainingDigits.Length != 0) {
                    iFactorial = (sRemainingDigits.Length - 1).Factorial();
                    sResult += sRemainingDigits.Substring(iIndex / iFactorial, 1);
                    sRemainingDigits = sRemainingDigits.Substring(0, iIndex / iFactorial) + sRemainingDigits.Substring((iIndex / iFactorial) + 1);
                    iIndex %= iFactorial;
                }
                return sResult;
            }
        }
        public bool IsPermutationOf(string sTest) {
            Dictionary<char, int> diiDigits = new Dictionary<char, int>();
            if (sTest.Length != _sSeed.Length) return false;
            char[] ca = _sSeed.ToCharArray();
            foreach (char c in ca) {
                if (diiDigits.ContainsKey(c)) {
                    diiDigits[c]++;
                } else {
                    diiDigits.Add(c, 1);
                }
            }
            ca = sTest.ToCharArray();
            foreach (char c in ca) {
                if (diiDigits.ContainsKey(c)) {
                    diiDigits[c]--;
                    if (diiDigits[c] == 0) diiDigits.Remove(c);
                } else {
                    return false;
                }
            }
            return true;
        }
        public IEnumerator<string> GetEnumerator() {
            int iMaxCombs = _sSeed.Length.Factorial();
            for (int i = 0; i < iMaxCombs; i++) {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
        public static List<string> ReplacementPermutations(string s, char cSwapFrom, char cSwapTo) {
            List<string> lsPerms = new List<string>();
            char[] ca = s.ToCharArray();
            List<int> liIndicies = new List<int>();
            int iCount;
            int iCharIndex;

            for (int i = 0; i < ca.Length; i++) {
                if (ca[i] == cSwapFrom) liIndicies.Add(i);
            }
            iCount = 2.Pow(liIndicies.Count);
            for (int i = 0; i < iCount; i++) {
                for (int iIndexIndex = 0; iIndexIndex < liIndicies.Count; iIndexIndex++) {
                    iCharIndex = liIndicies[iIndexIndex];
                    if (i % 2.Pow(iIndexIndex) == 0) {
                        if (ca[iCharIndex] == cSwapFrom) ca[iCharIndex] = cSwapTo;
                        else ca[iCharIndex] = cSwapFrom;
                    }
                }
                lsPerms.Add(new string(ca));
            }
            return lsPerms;
        }
    }
}