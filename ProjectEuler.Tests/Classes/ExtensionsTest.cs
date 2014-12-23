using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class ExtensionsTest {
        [TestMethod]
        public void ListEquality() {
            List<int> l1 = new List<int>(new int[] { 1, 2, 3, 4 });
            List<int> l2 = new List<int>(new int[] { 1, 2, 3, 4 });
            Assert.IsTrue(Extensions.EachItemEqual(l1, l2));
            l2.Add(5);
            Assert.IsFalse(Extensions.EachItemEqual(l1, l2));
            l2 = new List<int>(new int[] { 8, 2, 1, 4 });
            Assert.IsFalse(Extensions.EachItemEqual(l1, l2));
            l2 = l1;
            Assert.IsTrue(Extensions.EachItemEqual(l1, l2));
            l1 = new List<int>();
            l2 = new List<int>();
            Assert.IsTrue(Extensions.EachItemEqual(l1, l2));
        }
    }
}
