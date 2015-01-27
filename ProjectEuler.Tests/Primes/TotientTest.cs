﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Primes;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Primes {
    [TestClass]
    public class TotientTest {
        /*
         * MAKE THIS VALUE TRUE TO RUN THE TEST
         */
        bool bRunExpensive = false;

        private int[] iaTots = new int[] { 0, 1, 1, 2, 2, 4, 2, 6, 4, 6, 4, 10, 4, 12, 6, 8, 8, 16, 6, 18, 8, 12, 10, 22, 8, 20, 12, 18, 12, 28, 8, 30, 16, 20, 16, 24, 12, 36, 18, 24, 16, 40, 12, 42, 20, 24, 22, 46, 16, 42, 20, 32, 24, 52, 18, 40, 24, 36, 28, 58, 16, 60, 30, 36, 32, 48, 20, 66, 32, 44, 24, 70, 24, 72, 36, 40, 36, 60, 24, 78, 32, 54, 40, 82, 24, 64, 42, 56, 40, 88, 24, 72, 44, 60, 46, 72, 32, 96, 42, 60, 40, 100, 32, 102, 48, 48, 52, 106, 36, 108, 40, 72, 48, 112, 36, 88, 56, 72, 58, 96, 32, 110, 60, 80, 60, 100, 36, 126, 64, 84, 48, 130, 40, 108, 66, 72, 64, 136, 44, 138, 48, 92, 70, 120, 48, 112, 72, 84, 72, 148, 40, 150, 72, 96, 60, 120, 48, 156, 78, 104, 64, 132, 54, 162, 80, 80, 82, 166, 48, 156, 64, 108, 84, 172, 56, 120, 80, 116, 88, 178, 48, 180, 72, 120, 88, 144, 60, 160, 92, 108, 72, 190, 64, 192, 96, 96, 84, 196, 60, 198, 80, 132, 100, 168, 64, 160, 102, 132, 96, 180, 48, 210, 104, 140, 106, 168, 72, 180, 108, 144, 80, 192, 72, 222, 96, 120, 112, 226, 72, 228, 88, 120, 112, 232, 72, 184, 116, 156, 96, 238, 64, 240, 110, 162, 120, 168, 80, 216, 120, 164, 100, 250, 72, 220, 126, 128, 128, 256, 84, 216, 96, 168, 130, 262, 80, 208, 108, 176, 132, 268, 72, 270, 128, 144, 136, 200, 88, 276, 138, 180, 96, 280, 92, 282, 140, 144, 120, 240, 96, 272, 112, 192, 144, 292, 84, 232, 144, 180, 148, 264, 80, 252, 150, 200, 144, 240, 96, 306, 120, 204, 120, 310, 96, 312, 156, 144, 156, 316, 104, 280, 128, 212, 132, 288, 108, 240, 162, 216, 160, 276, 80, 330, 164, 216, 166, 264, 96, 336, 156, 224, 128, 300, 108, 294, 168, 176, 172, 346, 112, 348, 120, 216, 160, 352, 116, 280, 176, 192, 178, 358, 96, 342, 180, 220, 144, 288, 120, 366, 176, 240, 144, 312, 120, 372, 160, 200, 184, 336, 108, 378, 144, 252, 190, 382, 128, 240, 192, 252, 192, 388, 96, 352, 168, 260, 196, 312, 120, 396, 198, 216, 160, 400, 132, 360, 200, 216, 168, 360, 128, 408, 160, 272, 204, 348, 132, 328, 192, 276, 180, 418, 96, 420, 210, 276, 208, 320, 140, 360, 212, 240, 168, 430, 144, 432, 180, 224, 216, 396, 144, 438, 160, 252, 192, 442, 144, 352, 222, 296, 192, 448, 120, 400, 224, 300, 226, 288, 144, 456, 228, 288, 176, 460, 120, 462, 224, 240, 232, 466, 144, 396, 184, 312, 232, 420, 156, 360, 192, 312, 238, 478, 128, 432, 240, 264, 220, 384, 162, 486, 240, 324, 168, 490, 160, 448, 216, 240, 240, 420, 164, 498, 200 };
        private PrimeSieve p = new SieveOfAtkin();
        
        [TestMethod]
        public void CrappyTest() {
            Totient t = new Totient(null);
            for (int i = 1; i < iaTots.Length; i++) {
                Assert.AreEqual(iaTots[i], t.Crappy(i));
            }
            if (bRunExpensive) {
                //Assert.AreEqual(3015360, t.Crappy(9799998));
                //Assert.AreEqual(2799792, t.Crappy(9799398));
                //Assert.AreEqual(3195896, t.Crappy(9796398));
                Assert.AreEqual(400000, t.Crappy(1000000));
            }
        }
        [TestMethod]
        public void OkTest() {
            Totient t = new Totient(p);
            for (int i = 1; i < iaTots.Length; i++) {
                Assert.AreEqual(iaTots[i], t.OK(i));
            }
            Assert.AreEqual(3015360, t.OK(9799998));
            Assert.AreEqual(2799792, t.OK(9799398));
            Assert.AreEqual(3195896, t.OK(9796398));
            Assert.AreEqual(400000, t.OK(1000000));
        }
        [TestMethod]
        public void PrecalcTest() {
            Totient t = new Totient(p, iaTots.Length);
            for (int i = 1; i < iaTots.Length; i++) {
                Assert.AreEqual(iaTots[i], t.Best(i));
            }
            if (bRunExpensive) {
                //t = new Totient(p, 9900000);
                Assert.AreEqual(3015360, t.Best(9799998));
                Assert.AreEqual(2799792, t.Best(9799398));
                Assert.AreEqual(3195896, t.Best(9796398));
                Assert.AreEqual(400000, t.Best(1000000));
            }
        }


        [TestMethod]
        public void TotientPerformance() {
            if (!bRunExpensive) return;
            Ticker tick = new Ticker();
            Totient tot = new Totient(p,9900000);
            tick.Tick("Generated first ~ten million");
            int iMax;
            iMax = 0;
            while (!tick.SecondsElapsed(5) && iMax < 1000000) {
                iMax++;
                tot.Crappy(iMax);
            }
            tick.Tick("Crappy Max Value = " + iMax);
            iMax = 0;
            while (!tick.SecondsElapsed(5) && iMax < 1000000) {
                iMax++;
                tot.OK(iMax);
            }
            tick.Tick("OK Max Value = " + iMax);
            iMax = 0;
            while (!tick.SecondsElapsed(5) && iMax < 1000000) {
                iMax++;
                tot.Best(iMax);
            }
            tick.Tick("Best Max Value = " + iMax);
        }
    }
}
