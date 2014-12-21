using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class SieveOfAtkin : SieveOfEratosthenes {

        public SieveOfAtkin(int iLimit) {
            _iaPrimes = generatePrimes(iLimit);
        }
        private int[] generatePrimes(int iLimit) {
            
		    // For tracking performance
		    // final long lTime = System.nanoTime();
		    BoolMap bmIsPrime = new BoolMap(iLimit+1);
		    int x;
		    int y;
		    int n;
		    int i;
		    int iCount = 0;
		    int xSquared;
		    int nSquared;
		    int nMod12;
		    int sqrtLimit = (int) Math.Sqrt(iLimit);
            int[] iaPrimes;
            string elapsedTime;
            TimeSpan ts;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
		
		    switch (iLimit) {
			    case 0:
			    case 1:
				    iaPrimes = null;
				    break;
			    case 2:
				    iaPrimes = new int[1];
				    iaPrimes[0] = 2;
				    break;
			    case 3:
				    iaPrimes = new int[2];
				    iaPrimes[0] = 2;
				    iaPrimes[1] = 3;
				    break;
			    case 4:
				    iaPrimes = new int[2];
				    iaPrimes[0] = 2;
				    iaPrimes[1] = 3;
				    break;
			    case 5:
				    iaPrimes = new int[3];
				    iaPrimes[0] = 2;
				    iaPrimes[1] = 3;
				    iaPrimes[2] = 5;
				    break;
			    default:
				    for (x = 1; x <= sqrtLimit; x++) {
					    xSquared = x * x;
					    if (4 * xSquared + 1 <= iLimit) {
						    for (y = 1; y <= sqrtLimit; y++) {
							    n = 4 * xSquared + y * y;
							    if (n <= iLimit) {
								    nMod12 = n % 12;
								    if (nMod12 == 1 || nMod12 == 5) {
									    bmIsPrime.Flip(n);
								    }
							    } else {
								    y = sqrtLimit + 1;
							    }
						    }
                        } else {
                            break;
                        }
				    }
				    for (x = 1; x <= sqrtLimit; x++) {
					    xSquared = x * x;
					    if (3 * xSquared + 1 <= iLimit) {
						    for (y = 1; y <= sqrtLimit; y++) {
							    n = 3 * xSquared + y * y;
							    if (n <= iLimit) {
                                    if (n % 12 == 7) {
                                        bmIsPrime.Flip(n);
								    }
							    } else {
								    y = sqrtLimit + 1;
							    }
						    }
                        } else {
                            break;
                        }
				    }
				    for (x = 1; x <= sqrtLimit; x++) {
					    xSquared = x * x;
					    if (2 * (xSquared - x) + 1 <= iLimit) {
						    for (y = x - 1; y > 0; y--) {
							    n = 3 * xSquared - y * y;
							    if (n <= iLimit) {
                                    if (n % 12 == 11) {
                                        bmIsPrime.Flip(n);
								    }
							    } else {
								    y = 0;
							    }
						    }
                        } else {
                            break;
                        }
				    }
				    for (n = 5; n < sqrtLimit; n += 2) {
					    if (bmIsPrime.Get(n)) {
						    nSquared = n * n;
						    for (i = nSquared; i < iLimit; i += nSquared) {
                                bmIsPrime.Disable(i);
						    }
					    }
				    }
				    iCount = 3;
				    for (n = 7; n < bmIsPrime.Length(); n += 2) {
                        if (bmIsPrime.Get(n)) {
						    iCount++;
					    }
				    }
				    iaPrimes = new int[iCount];
				    iaPrimes[0] = 2;
				    iaPrimes[1] = 3;
				    i = 2;
                    for (n = 5; n < bmIsPrime.Length(); n += 2) {
                        if (bmIsPrime.Get(n)) {
						    iaPrimes[i] = n;
						    i++;
					    }
				    }
                    break;
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}h{1:00}m{2:00}.{3:00}s", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            System.Diagnostics.Debug.WriteLine("Atkin: " + iaPrimes.Length + " primes up to " + iaPrimes[iaPrimes.Length - 1] + " generated in " + elapsedTime); 
            return iaPrimes;
        }
    }
}