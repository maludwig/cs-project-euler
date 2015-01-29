using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using ProjectEuler.Primes;
using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Performance {
    [TestClass]
    public class CoprimeTest {
        PrimeSieve p = new SieveOfAtkin();
        [TestMethod]
        public void CoprimeCorrectness() {
            for (int i = 2; i < 1000; i++) {
                for (int x = 2; x < 1000; x++) {
                    Assert.AreEqual(i.GCD(x) == 1, p.areCoprime(i, x));
                }
            }
        }
        [TestMethod]
        public void CoprimePerf() {
            Ticker t = new Ticker();
            int iCount = 0;
            while (!t.SecondsElapsed(5)) {
                iCount++;
                TestGCD();
            }
            t.Tick("GCD (" + iCount + ")");
            iCount = 0;
            while (!t.SecondsElapsed(5)) {
                iCount++;
                TestCoprime();
            }
            t.Tick("Coprime (" + iCount + ")");
        }

        private void TestGCD() {
            bool b = true;
            for (int i = 2; i < 1000; i++) {
                for (int x = 2; x < 1000; x++) {
                    b = i.GCD(x) == 1;
                }
            }
        }
        private void TestCoprime() {
            bool b = true;
            for (int i = 2; i < 1000; i++) {
                for (int x = 2; x < 1000; x++) {
                    b = p.areCoprime(i, x);
                }
            }
        }
    }
}
