using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Collections.Generic;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class BoolMapTest {
        [TestMethod]
        public void Mini() {
            BoolMap bm = new BoolMap(16);
            for (int i = 0; i < 16; i++) {
                Assert.IsFalse(bm.Get(i));
            }
            for (int i = 0; i < 16; i++) {
                bm.Enable(i);
                Assert.IsTrue(bm.Get(i));
                bm.Disable(i);
                for (int k = 0; k < 16; k++) {
                    Assert.IsFalse(bm.Get(k));
                }
            }
        }
        [TestMethod]
        public void Major() {
            BoolMap bm = new BoolMap(1000);
            for (int i = 0; i < 1000; i++) {
                Assert.IsFalse(bm.Get(i));
            }
            for (int i = 0; i < 1000; i++) {
                bm.Enable(i);
                Assert.IsTrue(bm.Get(i));
                bm.Disable(i);
                for (int k = 0; k < 1000; k++) {
                    Assert.IsFalse(bm.Get(k));
                }
            }
        }
        [TestMethod]
        public void MajorWithIndex() {
            BoolMap bm = new BoolMap(1000);
            for (int i = 0; i < 1000; i++) {
                Assert.IsFalse(bm[i]);
            }
            for (int i = 0; i < 1000; i++) {
                bm[i] = true;
                Assert.IsTrue(bm[i]);
                bm[i] = false;
                for (int k = 0; k < 1000; k++) {
                    Assert.IsFalse(bm[k]);
                }
            }
        }
        [TestMethod]
        public void MajorBool() {
            bool[] ba = new bool[1000];
            for (int i = 0; i < 1000; i++) {
                Assert.IsFalse(ba[i]);
            }
            for (int i = 0; i < 1000; i++) {
                ba[i] = true;
                Assert.IsTrue(ba[i]);
                ba[i] = false;
                for (int k = 0; k < 1000; k++) {
                    Assert.IsFalse(ba[i]);
                }
            }
        }
        [TestMethod]
        public void TwoDArray() {
            Stack<int> siX = new Stack<int>();
            Stack<int> siY = new Stack<int>();
            int iX, iY;
            Random r = new Random();
            BoolMap b = new BoolMap(100, 100);
            for (int i = 0; i < 1000; i++) {
                iX = r.Next(0, 100);
                iY = r.Next(0, 100);
                b[iX, iY] = true;
                Assert.IsTrue(b[iX, iY]);
                siX.Push(iX);
                siY.Push(iY);
            }
            while (siX.Count > 0) {
                iX = siX.Pop();
                iY = siY.Pop();
                //Assert.IsTrue(b[iX, iY]);
                b[iX, iY] = false;
                Assert.IsFalse(b[iX, iY]);
            }
            for (iX = 0; iX < 100; iX++) {
                for (iY = 0; iY < 100; iY++) {
                    Assert.IsFalse(b[iX, iY]);
                }
            }
        }
    }
}
