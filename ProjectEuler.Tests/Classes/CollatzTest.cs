using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class CollatzTest {
        [TestMethod]
        public void CollatzStep() {
            Assert.AreEqual(4, Numbers.CollatzStep(8));
            Assert.AreEqual(10, Numbers.CollatzStep(3));
            Assert.AreEqual(15, Numbers.CollatzStep(30));
        }
        [TestMethod]
        public void CollatzChains() {
            Assert.AreEqual(10, Numbers.CollatzChainLength(13));
            Assert.AreEqual(5, Numbers.CollatzChainLength(16));
            Assert.AreEqual(19, Numbers.CollatzChainLength(30));
            Assert.AreEqual(1, Numbers.CollatzChainLength(1));
        }
    }
}
