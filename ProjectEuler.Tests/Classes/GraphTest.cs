using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class GraphTest {
        [TestMethod]
        public void GraphConnections() {
            Graph g = new Graph();
            g.Connect(1, 2);
            Assert.IsTrue(g.AreConnected(1, 2));
            Assert.IsTrue(g.AreConnected(2, 1));
            g.Connect(1, 3);
            Assert.IsTrue(g.AreConnected(1, 3));
            Assert.IsTrue(g.AreConnected(3, 1));
            g.Disconnect(1, 3);
            Assert.IsFalse(g.AreConnected(1, 3));
            Assert.IsFalse(g.AreConnected(3, 1));

            Assert.IsTrue(g.AreConnected(1, 2));
            Assert.IsTrue(g.AreConnected(2, 1));
        }
        [TestMethod]
        public void GraphPruning() {
            Graph g = new Graph();
            g.Connect(1, 2);
            g.Connect(1, 3);
            g.Connect(2, 3);
            g.Connect(4, 3);
            Assert.IsTrue(g.AreConnected(1, 2));
            Assert.IsTrue(g.AreConnected(2, 1));
            Assert.IsTrue(g.AreConnected(1, 3));
            Assert.IsTrue(g.AreConnected(3, 1));
            Assert.IsTrue(g.AreConnected(2, 3));
            Assert.IsTrue(g.AreConnected(3, 2));
            Assert.IsTrue(g.AreConnected(4, 3));
            Assert.IsTrue(g.AreConnected(3, 4));
            g.PruneWeak(2);
            Assert.IsTrue(g.AreConnected(1, 2));
            Assert.IsTrue(g.AreConnected(2, 1));
            Assert.IsTrue(g.AreConnected(1, 3));
            Assert.IsTrue(g.AreConnected(3, 1));
            Assert.IsTrue(g.AreConnected(2, 3));
            Assert.IsTrue(g.AreConnected(3, 2));
            Assert.IsFalse(g.AreConnected(4, 3));
            Assert.IsFalse(g.AreConnected(3, 4));
        }
    }
}
