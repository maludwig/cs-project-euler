using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEuler.Primes;
using System.Diagnostics;

namespace MikesEuler.Tests.NumberTests {
    [TestClass]
    public class PrimalityTestsTest {
        List<int> liPrimes = new List<int>(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });

        [TestMethod]
        public void TestPrimalityTests() {
            IPrimalityTest p = new BasicPrimes();
            TestAnInterface(p);
        }
        [TestMethod]
        public void TestBailliePSW() {
            IPrimalityTest p = new BailliePSW();
            TestAnInterface(p);
        }
        public void TestAnInterface(IPrimalityTest p) {
            for (int i = 0; i <= liPrimes[liPrimes.Count - 1]; i++) {
                Assert.AreEqual(liPrimes.Contains(i), p.IsPrime(i));
            }
        }
        [TestMethod]
        public void QuickJacobiTest() {
            Assert.AreEqual(1, BailliePSW.JacobiSymbol(-1, 1));
            Assert.AreEqual(1, BailliePSW.JacobiSymbol(1, 3));
            Assert.AreEqual(-1, BailliePSW.JacobiSymbol(-1, 7));
            Assert.AreEqual(-1, BailliePSW.JacobiSymbol(8, 11));
        }
        [TestMethod]
        public void TestJacobiSymbol() {
            List<long> liModuli = new List<long>(new long[] { 1, 3, 5, 7, 9, 11 });
            for (long D = -1; D < 10; D++) {
                foreach (long lModulus in liModuli) {
                    Assert.AreEqual(BailliePSW.JacobiSymbol(D, lModulus), JacobiQuick(D, lModulus));
                }
            }
        }
        public short JacobiQuick(long lD, long lModulus) {
            short[][] laaJacobi = {
                                     new short[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},//Modulus = 1, Jacobi Symbol always = 1
                                     new short[] {-1, 0, 1, -1, 0, 1, -1, 0, 1, -1, 0, 1},//Modulus = 3, D varies
                                     new short[] {1, 0, 1, -1, -1, 1, 0, 1, -1, -1, 1, 0},//Modulus = 5, D varies
                                     new short[] {-1, 0, 1, 1, -1, 1, -1, -1, 0, 1, 1, -1},//Modulus = 7, D varies
                                     new short[] {1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1}, //Modulus = 9
                                     new short[] {-1, 0, 1, -1, 1, 1, 1, -1, -1, -1, 1, -1}, //Modulus = 11
                                 };
            return laaJacobi[(lModulus - 1) / 2][lD + 1];
        }
        [TestMethod]
        public void TestPowMod() {
            Assert.AreEqual(2, BailliePSW.PowerMod(2, 1, 1000));
            Assert.AreEqual(8, BailliePSW.PowerMod(2, 3, 1000));
            Assert.AreEqual(2, BailliePSW.PowerMod(2, 3, 6));
            Assert.AreEqual(1, BailliePSW.PowerMod(9, 2, 80));
        }
    }
}
