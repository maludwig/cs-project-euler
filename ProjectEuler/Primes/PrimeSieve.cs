using ProjectEuler.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Extensions;

namespace ProjectEuler.Primes {
    public enum PerfectionLevel { DEFICIENT = -1, PERFECT, ABUNDANT };
    public class PrimeSieve : IEnumerable<int> {
        protected int[] _iaPrimes;
        public int[] LeastPrimeDivisor { get; protected set; }      //For a number n = p[a]^x * p[b]^y * ..., holds p[a],   where p[a] is the smallest prime that divides n.
        public int[] LeastPrimePowerDivisor { get; protected set; } //For a number n = p[a]^x * p[b]^y * ..., holds p[a]^x, where p[a] is the smallest prime that divides n.
        protected BoolMap _bmIsPrime;
        protected int _iLimit;
        public PrimeSieve() {
        }
        protected void CalculateFirstDivisors() {
            Ticker t = new Ticker();
            SieveFirstDivisors();
            t.Tick("Precalculated lowest prime divisors");
        }
        public void SieveFirstDivisors() {
            int iNum, iPrime, i6Prime, iLPD;
            LeastPrimeDivisor = new int[_iLimit];
            LeastPrimePowerDivisor = new int[_iLimit];
            LeastPrimeDivisor[1] = 1;
            //Start at the largest primes, then work down. This way, we never need to check if the
            // lowest prime multiple is already found, we just overwrite it
            //Also, skip any multiples of 2 or 3, because setting those is a waste of time
            for (int iPrimeIndex = _iaPrimes.Length - 1; iPrimeIndex >= 1; iPrimeIndex--) {
                iPrime = _iaPrimes[iPrimeIndex];
                i6Prime = iPrime * 6;
                for (iNum = iPrime; iNum < _iLimit; iNum += i6Prime) {
                    LeastPrimeDivisor[iNum] = iPrime;
                }
                for (iNum = iPrime * 5; iNum < _iLimit; iNum += i6Prime) {
                    LeastPrimeDivisor[iNum] = iPrime;
                }
            }
            //Then record all multiples of 2 or 3
            for (iNum = 3; iNum < _iLimit; iNum += 6) {
                LeastPrimeDivisor[iNum] = 3;
            }
            for (iNum = 2; iNum < _iLimit; iNum += 2) {
                LeastPrimeDivisor[iNum] = 2;
            }
            for (int i = 2; i < _iLimit; i++) {
                iNum = i;
                iLPD = LeastPrimeDivisor[i];
                while (iNum % iLPD == 0) iNum /= iLPD;
                LeastPrimePowerDivisor[i] = i / iNum;
            }
        }
        public int this[int iIndex] {
            get {
                return _iaPrimes[iIndex];
            }
        }
        public IEnumerator<int> GetEnumerator() {
            for (int i = 0; i < _iaPrimes.Length; i++) {
                yield return _iaPrimes[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
        public int Count() {
            return _iaPrimes.Length;
        }
        public int largestPrime() {
            return _iaPrimes[_iaPrimes.Length-1];
        }
        public int getPrime(int iIndex) {
            return _iaPrimes[iIndex];
        }
        public int[] getPrimes(int iFrom, int iTo) {
            return OtherExtensions.Slice(_iaPrimes, iFrom, iTo);
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

        //Only call this if you know that iNum < _iLimit
        public List<int> QuickFactors(int iNum) {
            List<int> liFactors = new List<int>();
            while (iNum != 1) {
                liFactors.Add(LeastPrimeDivisor[iNum]);
                iNum /= LeastPrimeDivisor[iNum];
            }
            return liFactors;
        }
        public List<int> Factors(int iNum) {
            if (iNum < _iLimit) return QuickFactors(iNum);
            return Factors((long)iNum);
        }
        public List<int> Factors(long lNum) {
            List<int> liFactors;
            if (lNum < _iLimit) return QuickFactors((int)lNum);
            liFactors = new List<int>();
            for (int i = 0; _iaPrimes[i] <= lNum; i++) {
                if (lNum % _iaPrimes[i] == 0) {
                    lNum /= _iaPrimes[i];
                    liFactors.Add(_iaPrimes[i]);
                    if (lNum < _iLimit) {
                        liFactors.AddRange(QuickFactors((int)lNum));
                        lNum = 0;
                    }
                    i--;
                }
            }
            return liFactors;
        }
        public List<int> DistinctFactors(int iNum) {
            return (List<int>)(Factors(iNum).Distinct());
        }
        public List<int> DistinctFactors(long lNum) {
            return (List<int>)(Factors(lNum).Distinct());
        }
        public int DistinctFactorCount(int iNum) {
            return DistinctFactors(iNum).Count;
        }
        public int DistinctFactorCount(long lNum) {
            return DistinctFactors(lNum).Count;
        }
        public List<int> divisors(int iNum) {
            return divisors((long)iNum);
        }
        public List<int> divisors(long lNum) {
            List<int> liFactors = Factors(lNum);
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
        public List<int> ProperDivisors(int iNum) {
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
            int iLPD1 = LeastPrimeDivisor[iNum1];
            if (iLPD1 == 1) return true;
            if (iNum2 % iLPD1 == 0) {
                return false;
            } else {
                return areCoprime(iNum1 / iLPD1, iNum2);
            }
        }
        public bool IsPrime(int iNum) {
            return _bmIsPrime[iNum];
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
