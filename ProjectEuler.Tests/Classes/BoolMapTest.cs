using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;

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
    }
}
