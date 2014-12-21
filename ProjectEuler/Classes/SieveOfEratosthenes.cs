using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class SieveOfEratosthenes : PrimeGenerator {
        public const int INSTANT = 100000;
        public const int FIVE = 1200000;
        public const int FORTY = 5000000;
        public SieveOfEratosthenes()
            : this(SieveOfEratosthenes.INSTANT) {
        }
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
            for (int i = 1; i < iCount; ) {
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
    }
}