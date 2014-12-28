using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class Permutations : IEnumerable<string> {
        protected string _sSeed;
        public Permutations(string sSeed) {
            _sSeed = sSeed;
        }
        public string this[int iIndex] {
            get {
                string sRemainingDigits = _sSeed;
                int iFactorial;
                string sResult = "";
                while (sRemainingDigits.Length != 0) {
                    iFactorial = Numbers.factorial(sRemainingDigits.Length - 1);
                    sResult += sRemainingDigits.Substring(iIndex / iFactorial, 1);
                    sRemainingDigits = sRemainingDigits.Substring(0, iIndex / iFactorial) + sRemainingDigits.Substring((iIndex / iFactorial) + 1);
                    iIndex %= iFactorial;
                }
                return sResult;
            }
        }
        public IEnumerator<string> GetEnumerator() {
            int iMaxCombs = Numbers.factorial(_sSeed.Length);
            for (int i = 0; i < iMaxCombs; i++) {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
}