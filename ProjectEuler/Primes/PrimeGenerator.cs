using ProjectEuler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Primes {
    public enum PerfectionLevel { DEFICIENT = -1, PERFECT, ABUNDANT };
    public class PrimeGenerator {
        protected int[] _iaPrimes;
        protected BoolMap _bmIsPrime;
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
        public List<int> getPrimesTo(int iCap) {
            List<int> liPrimes = new List<int>();
            for (int i = 0; _iaPrimes[i] < iCap; i++) {
                liPrimes.Add(_iaPrimes[i]);
            }
            return liPrimes;
        }
        public int findPrime(int iPrime) {
            return findPrime(iPrime, 0, _iaPrimes.Length);
        }
        //iEnd should be one after the last element to consider
        public int findPrime(int iPrime, int iStart, int iEnd) {
            if (iEnd <= iStart) return -1;
            int iMid = (iEnd - iStart) / 2 + iStart;
            if (_iaPrimes[iMid] == iPrime) return iMid;
            else if (_iaPrimes[iMid] < iPrime) return findPrime(iPrime, iMid + 1, iEnd);
            else return findPrime(iPrime, iStart, iMid);
        }
        public int findClosestPrime(int iPrime) {
            return findClosestPrime(iPrime, 0, _iaPrimes.Length);
        }
        public int findClosestPrime(int iNum, int iStart, int iEnd) {
            if (iEnd == iStart) {
                if (iStart == 0) return 0;
                if (iNum - _iaPrimes[iStart-1] < _iaPrimes[iStart] - iNum) {
                    return iStart-1;
                } else {
                    return iStart;
                }
            } else {
                int iMid = (iEnd - iStart) / 2 + iStart;
                if (_iaPrimes[iMid] == iNum) return iMid;
                else if (_iaPrimes[iMid] < iNum) return findClosestPrime(iNum, iMid + 1, iEnd);
                else return findClosestPrime(iNum, iStart, iMid);
            }
        }
        public List<int> factor(int iNum) {
            return factor((long)iNum);
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
        public PerfectionLevel perfection(int iNum) {
            return perfection((long)iNum);
        }
        public PerfectionLevel perfection(long lNum) {
            long lPerfect = properDivisors(lNum).Sum() - lNum;
            if (lPerfect < 0) return PerfectionLevel.DEFICIENT;
            if (lPerfect == 0) return PerfectionLevel.PERFECT;
            return PerfectionLevel.ABUNDANT;
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
        public bool IsPrime(int iNum) {
            bool b = _bmIsPrime[iNum];
            return b;
        }
        public bool IsCircularPrime(int iNum) {
            string s = iNum.ToString();
            for (int i = 0; i < s.Length; i++) {
                if (!IsPrime(int.Parse(s))) return false;
                s = s.Substring(1) + s.Substring(0, 1);
            }
            return true;
        }
        public bool IsTruncatablePrime(int i) {
            if (!IsPrime(i)) return false;
            string sNum = i.ToString();
            if (sNum.Length == 1) return false;
            sNum = sNum.Substring(1);
            while (sNum.Length > 0) {
                if (!IsPrime(int.Parse(sNum))) return false;
                sNum = sNum.Substring(1);
            }
            sNum = i.ToString();
            sNum = sNum.Substring(0, sNum.Length - 1);
            while (sNum.Length > 0) {
                if (!IsPrime(int.Parse(sNum))) return false;
                sNum = sNum.Substring(0, sNum.Length - 1);
            }
            return true;
        }
    }
}
