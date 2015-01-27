using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectEuler.Extensions;

namespace ProjectEuler.Primes {
    public class Totient {
        private PrimeSieve _p;
        public int Limit { get; protected set; }
        private int[] _iaPreCalc;
        public Totient() {
            _p = null;
            Limit = 0;
        }
        public Totient(PrimeSieve p) {
            _p = p;
            Limit = 0;
        }
        public Totient(PrimeSieve p, int iLimit) {
            _p = p;
            Limit = iLimit;
            if (_p.largestPrime() < iLimit) throw new Exception("Not enough primes generated to calculate to limit");
            Precalculate();
        }
        private void Precalculate() {
            int lCurrPrime;
            int lCurrTot;
            long lPow;
            _iaPreCalc = new int[Limit];
            _iaPreCalc[1] = 1;
            for (int i = 0; _p[i] < Limit; i++) {
                lCurrPrime = _p[i];
                lCurrTot = lCurrPrime - 1;
                lPow = lCurrPrime;
                lPow *= lCurrPrime;
                _iaPreCalc[lCurrPrime] = lCurrTot;
                while (lPow < Limit) {
                    lCurrTot *= lCurrPrime;
                    _iaPreCalc[lPow] = lCurrTot;
                    lPow *= lCurrPrime;
                }
            }
            for (int i = 0; _p[i] < Limit; i++) {
                Precalculate(1, 1, i);
            }
            System.Diagnostics.Debug.WriteLine("woo");

        }
        private void Precalculate(long lNum, int iTot, int iPrimeIndex) {
            int lCurrPrime = _p[iPrimeIndex];
            int lCurrTot = iTot * _iaPreCalc[lCurrPrime];
            long lNext = lNum;
            lNext *= lCurrPrime;
            while (lNext < Limit) {
                _iaPreCalc[lNext] = lCurrTot;
                for (int i = iPrimeIndex + 1; lNext * _p[i] < Limit; i++) {
                    Precalculate(lNext, lCurrTot, i);
                }
                lNext *= lCurrPrime;
                lCurrTot *= lCurrPrime;
            }
        }
        public int Best(int iNum) {
            if (iNum < Limit) return _iaPreCalc[iNum];
            return OK(iNum);
        }
        public int Crappy(int iNum) {
            int iSum = 0;
            for(int i = 2; i < iNum; i++){
                if(i.GCD(iNum) == 1) iSum++;
            }
            return iSum + 1;
        }

        public int OK(int iNum) {
            List<int> liFactors = _p.Factors(iNum);
            int iLast = 0;
            int iProd = 1;
            foreach (int i in liFactors) {
                if (iLast != i) {
                    iProd *= (i - 1);
                } else {
                    iProd *= i;
                }
                iLast = i;
            }
            return iProd;
        }
    }
}