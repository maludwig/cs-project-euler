using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using ProjectEuler.Primes;
using System.Numerics;

namespace ProjectEuler.Tests.Performance {
    [TestClass]
    public class PrimalityPerfTest {

        /*
         * MAKE THIS VALUE TRUE TO RUN THE TEST
         */
        bool bTestPerf = false;
        
        [TestMethod]
        public void PrimalityPerformance() {
            IPrimalityTest[] paTesters = new IPrimalityTest[] { new BailliePSW(), new MillerRabin() };
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            stopWatch.Start();
            long lCount = 0;
            if (!bTestPerf) return;
            
            foreach (IPrimalityTest p in paTesters) {
                Debug.WriteLine("#######");
                Debug.WriteLine(p.GetType().Name);
                Debug.WriteLine("-------");
                Debug.Write("Testing Integers");
                ts = stopWatch.Elapsed;
                lCount = 0;
                while (ts.Seconds < 5) {
                    IntegerTest(p);
                    ts = stopWatch.Elapsed;
                    lCount++;
                }
                Debug.WriteLine(": Iterated " + lCount + " times in " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
                stopWatch.Restart();

                Debug.WriteLine("-------");
                Debug.Write("Testing Longs");
                ts = stopWatch.Elapsed;
                lCount = 0;
                while (ts.Seconds < 5) {
                    LongTest(p);
                    ts = stopWatch.Elapsed;
                    lCount++;
                }
                Debug.WriteLine(": Iterated " + lCount + " times in " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
                stopWatch.Restart();

                Debug.WriteLine("-------");
                Debug.Write("Testing BigIntegers");
                ts = stopWatch.Elapsed;
                lCount = 0;
                while (ts.Seconds < 5) {
                    BigIntegerTest(p);
                    ts = stopWatch.Elapsed;
                    lCount++;
                }
                Debug.WriteLine(": Iterated " + lCount + " times in " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
                stopWatch.Restart();
            }

            ts = stopWatch.Elapsed;
            Debug.Print(String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Restart();
        }

        private void IntegerTest(IPrimalityTest p) {
            bool b;
            for (int i = 0; i < 10000; i++) {
                b = p.IsPrime(i);
            }
        }

        private void LongTest(IPrimalityTest p) {
            bool b;
            long lStop = int.MaxValue;
            lStop += 10000;
            for (long l = lStop - 10000; l < lStop; l++) {
                b = p.IsPrime(l);
            }
        }
        private void BigIntegerTest(IPrimalityTest p) {
            bool bIsPrime;
            BigInteger bStop = bStop = BigInteger.Pow(10, 30);
            for (BigInteger b = bStop - 10000; b < bStop; b++) {
                bIsPrime = p.IsPrime(b);
            }
        }
    }
}
