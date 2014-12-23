using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Classes
{
    public class PrimeGenerator
    {
        protected int[] _iaPrimes;
        public PrimeGenerator() {

        }
        public int Count() {
            return _iaPrimes.Length;
        }
        public int getPrime(int iIndex) {
            return _iaPrimes[iIndex];
        }
        public int[] getPrimes(int iFrom, int iTo) {
            return Extensions.Slice(_iaPrimes, iFrom, iTo);
        }
        public int findPrime(int iPrime) {
            return findPrime(iPrime, 0, _iaPrimes.Length - 1);
        }
        public int findPrime(int iPrime, int iStart, int iEnd) {
            int iMid = (iEnd - iStart) / 2 + iStart;
            if (iMid >= _iaPrimes.Length) {
                return 0;
            } else {
                if (_iaPrimes[iMid] == iPrime) return iMid;
                else if (iStart == iEnd) return 0;
                else if (_iaPrimes[iMid] < iPrime) return findPrime(iPrime, iMid + 1, iEnd);
                else return findPrime(iPrime, iStart, iMid);
            }
        }
        public int findClosestPrime(int iPrime) {
            return 0;
        }
        public List<int> factor(int iNum) {
            return factor((long) iNum);
        }
        public List<int> factor(long lNum) {
            List<int> liFactors = new List<int>();
            for (int i = 0; _iaPrimes[i] <= lNum; i++) {
                if (lNum % _iaPrimes[i] == 0) {
                    lNum /= _iaPrimes[i];
                    liFactors.Add(_iaPrimes[i]);
                    i--;
                }
            }
            return liFactors;
        }
        public List<int> divisors(int iNum) {
            return divisors((long)iNum);
        }
        public List<int> divisors(long lNum) {
            List<int> liFactors = factor(lNum);
            List<int> liLastDivs = new List<int>();
            List<int> liDivs = new List<int>();
            int iLastFactor = 0;
            liLastDivs.Add(1);
            liDivs.Add(1);
            foreach (int iFactor in liFactors) {
                if (iFactor != iLastFactor) {
                    liLastDivs = new List<int>(liDivs);
                    iLastFactor = iFactor;
                }
                for (int i = 0; i < liLastDivs.Count; i++) {
                    liLastDivs[i] *= iFactor;
                    liDivs.Add(liLastDivs[i]);
                }
            }
            liDivs.Sort();
            return liDivs;
        }
        public List<int> properDivisors(int iNum) {
            return properDivisors((long)iNum);
        }
        public List<int> properDivisors(long lNum) {
            List<int> li = divisors(lNum);
            li.RemoveAt(li.Count() - 1);
            return li;
        }
        public bool areCoprime(int iNum1, int iNum2) {
            return false;
        }
        public void genTotients(int iMax) {
            return;
        }
        public int totient(int iNum) {
            return 0;
        }
        public bool isPrime(int iNum) {
            return false;
        }
    }
}
