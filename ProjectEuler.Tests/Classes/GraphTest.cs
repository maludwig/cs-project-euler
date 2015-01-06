using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using ProjectEuler.Graph;
using System.Diagnostics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class GraphTest {
        [TestMethod]
        public void IntegerGraphTest() {
            IntegerGraph g = new IntegerGraph();
            BasicGraphTest(g);
        }
        public void BasicGraphTest(IGraph<int> g) {
            g.Connect(1, 2);
            Assert.IsTrue(g.AreConnected(1, 2));
            Assert.IsTrue(g.AreConnected(2, 1));
            Assert.AreEqual(2, g.Count());
            g.Connect(1, 3);
            Assert.IsTrue(g.AreConnected(1, 3));
            Assert.IsTrue(g.AreConnected(3, 1));
            Assert.AreEqual(3, g.Count());
            g.Disconnect(1, 3);
            Assert.IsFalse(g.AreConnected(1, 3));
            Assert.IsFalse(g.AreConnected(3, 1));
            Assert.AreEqual(3, g.Count());

            Assert.IsTrue(g.AreConnected(1, 2));
            Assert.IsTrue(g.AreConnected(2, 1));

            g.Remove(1);
            Assert.IsFalse(g.AreConnected(1, 2));
            Assert.IsFalse(g.AreConnected(2, 1));
            Assert.IsFalse(g.AreConnected(1, 3));
            Assert.IsFalse(g.AreConnected(3, 1));
            Assert.AreEqual(2, g.Count());
            g.Remove(2);
            Assert.AreEqual(1, g.Count());
            g.Remove(3);
            Assert.AreEqual(0, g.Count());
        }

        [TestMethod]
        public void GraphPruning() {
            IntegerGraph g = new IntegerGraph();
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
        [TestMethod]
        public void SubGraphConnectedToTest() {
            IntegerGraph g = new IntegerGraph();
            IntegerGraph gSub;
            g.Connect(1, 2);
            g.Connect(1, 3);
            g.Connect(1, 4);
            g.Connect(1, 5);
            g.Connect(2, 3);
            g.Connect(3, 5);
            g.Connect(5, 6);
            gSub = g.SubGraphConnectedTo(5);
            Debug.WriteLine(gSub);
            gSub = g.SubGraphConnectedTo(1);
            Debug.WriteLine(gSub);
        }
    }
}
