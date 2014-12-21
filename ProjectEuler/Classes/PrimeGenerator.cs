using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Classes
{
    interface PrimeGenerator
    {
        int getPrime(int iIndex);
        int[] getPrimes(int iFrom, int iTo);
        int findPrime(int iPrime);
        int findClosestPrime(int iPrime);
        List<int> factor(int iNum);
        List<int> factor(long iNum);
        bool areCoprime(int iNum1, int iNum2);
        void genTotients(int iMax);
        int totient(int iNum);
        bool isPrime(int iNum);
    }
}
