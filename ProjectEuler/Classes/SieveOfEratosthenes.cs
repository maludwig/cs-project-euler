using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes
{
    public class SieveOfEratosthenes : PrimeGenerator
    {
        protected int[] _iaPrimes;
        public SieveOfEratosthenes() {}

        public SieveOfEratosthenes(int iCount) {
            _iaPrimes = generatePrimes(iCount);
        }
        private int[] generatePrimes(int iCount) {
            int lNum = 0, lRoot = 0, k = 0;
            int[] iaPrimes = new int[iCount];
            bool bIsComposite = false;
            string elapsedTime;
            TimeSpan ts;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
        
            lNum = 2;
            iaPrimes[0] = 2;
            lNum = 1;
            for (int i = 1; i < iCount;) {
                lNum += 2;
            
                lRoot = (int)(Math.Sqrt(lNum));
                k = 0;
                bIsComposite = false;
                while (iaPrimes[k] <= lRoot && bIsComposite == false && iaPrimes[k] != 0) {
                    if (lNum % iaPrimes[k] == 0) {
                        bIsComposite = true;
                    }
                    k++;
                }
                if (bIsComposite == false) {
                    iaPrimes[i] = lNum;
                    i++;
                }
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}h{1:00}m{2:00}.{3:00}s", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            System.Diagnostics.Debug.WriteLine("Eratosthenes: " + iCount + " primes up to " + iaPrimes[iCount - 1] + " generated in " + elapsedTime);
            return iaPrimes;
        }
        public int getPrime(int iIndex) {
            return _iaPrimes[iIndex];
        }
        public int[] getPrimes(int iFrom, int iTo) {
            return Extensions.Slice(_iaPrimes,iFrom,iTo);
        }
        public int findPrime(int iPrime) {
            return findPrime(iPrime,0,_iaPrimes.Length-1);
        }
        public int findPrime(int iPrime, int iStart, int iEnd) {
            int iMid = (iEnd - iStart) / 2 + iStart;
            if (iMid >= _iaPrimes.Length) {
                return 0;
            }
            else
            {
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
            List<int> liFactors = new List<int>();
            for (int i = 0; _iaPrimes[i] <= iNum; i++) {
                if (iNum % _iaPrimes[i] == 0) {
                    iNum /= _iaPrimes[i];
                    liFactors.Add(_iaPrimes[i]);
                    i--;
                }
            }
            return liFactors;
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