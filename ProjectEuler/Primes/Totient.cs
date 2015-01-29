﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectEuler.Extensions;
using ProjectEuler.Classes;

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
            Ticker t = new Ticker();
            int iDiv1, iDiv2;
            _iaPreCalc = new int[Limit];
            _iaPreCalc[1] = 1;
            for (int i = 2; i < Limit; i++) {
                if (_p.IsPrime(i)) {
                    _iaPreCalc[i] = i - 1;
                } else {
                    iDiv1 = _p.LeastPrimePowerDivisor[i];
                    if (iDiv1 == i) {
                        iDiv2 = _p.LeastPrimeDivisor[i];
                        _iaPreCalc[i] = _iaPreCalc[i / iDiv2] * iDiv2;
                    } else {
                        iDiv2 = i / iDiv1;
                        _iaPreCalc[i] = _iaPreCalc[iDiv1] * _iaPreCalc[iDiv2];
                    }
                }
            }
            t.Tick("Precalculated totients");
        }
        private void PrecalculateBadly() {
            int lCurrPrime;
            int lCurrTot;
            long lPow;
            Ticker t = new Ticker();
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
            t.Tick("Seeding prime powers");
            for (int i = 0; _p[i] < Limit; i++) {
                Precalculate(1, 1, i);
            }
            t.Tick("Totient Precalculations - " + _iPreCalcCalls);
        }
        private static int _iPreCalcCalls = 0;
        private void Precalculate(long lNum, int iTot, int iPrimeIndex) {
            _iPreCalcCalls++;
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