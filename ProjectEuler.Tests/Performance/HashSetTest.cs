using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProjectEuler.Tests.Performance {
    [TestClass]
    public class HashSetTest {
        [TestMethod]
        public void HashSetMemory() {
            HashSet<int> ha = new HashSet<int>();
            for (int i = 0; i < 20; i++) {
                ha.Add(i);
            }
            System.Diagnostics.Debug.WriteLine("ok");
        }
    }
}
