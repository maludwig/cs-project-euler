using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class PolygonalSieveTest {
        [TestMethod]
        public void TriTest() {
            long lTri;
            List<long> llTri = new List<long>(2000);
            Assert.AreEqual(1, PolygonalSieve.GetTriangle(1));
            Assert.AreEqual(3, PolygonalSieve.GetTriangle(2));
            Assert.AreEqual(6, PolygonalSieve.GetTriangle(3));
            Assert.AreEqual(10, PolygonalSieve.GetTriangle(4));
            Assert.AreEqual(15, PolygonalSieve.GetTriangle(5));
            for (int i = 1; i < 2000; i++) {
                lTri = PolygonalSieve.GetTriangle(i);
                Assert.AreEqual(i, PolygonalSieve.GetTriangleIndex(lTri));
                llTri.Add(lTri);
            }
            for (int i = 1; i < 2000; i++) {
                Assert.AreEqual(llTri.Contains(i), PolygonalSieve.IsTriangle(i));
            }
        }
        [TestMethod]
        public void PentaTest() {
            long lPenta;
            List<long> llPentas = new List<long>(2000);
            Assert.AreEqual(1, PolygonalSieve.GetPentagonal(1));
            Assert.AreEqual(5, PolygonalSieve.GetPentagonal(2));
            Assert.AreEqual(12, PolygonalSieve.GetPentagonal(3));
            Assert.AreEqual(22, PolygonalSieve.GetPentagonal(4));
            Assert.AreEqual(35, PolygonalSieve.GetPentagonal(5));
            Assert.AreEqual(51, PolygonalSieve.GetPentagonal(6));
            Assert.AreEqual(70, PolygonalSieve.GetPentagonal(7));
            for (int i = 1; i < 2000; i++) {
                lPenta = PolygonalSieve.GetPentagonal(i);
                Assert.AreEqual(i, PolygonalSieve.GetPentagonalIndex(lPenta));
                llPentas.Add(lPenta);
            }
            for (int i = 1; i < 2000; i++) {
                Assert.AreEqual(llPentas.Contains(i), PolygonalSieve.IsPentagonal(i));
            }
        }
        [TestMethod]
        public void HexaTest() {
            long lHexa;
            List<long> llHexas = new List<long>(2000);
            Assert.AreEqual(1, PolygonalSieve.GetHexagonal(1));
            Assert.AreEqual(6, PolygonalSieve.GetHexagonal(2));
            Assert.AreEqual(15, PolygonalSieve.GetHexagonal(3));
            Assert.AreEqual(28, PolygonalSieve.GetHexagonal(4));
            Assert.AreEqual(45, PolygonalSieve.GetHexagonal(5));
            for (int i = 1; i < 2000; i++) {
                lHexa = PolygonalSieve.GetHexagonal(i);
                Assert.AreEqual(lHexa, PolygonalSieve.GetPoly(i, 6));
                Assert.AreEqual(i, PolygonalSieve.GetHexagonalIndex(lHexa));
                Assert.AreEqual(i, PolygonalSieve.GetPolyIndex(lHexa,6));
                llHexas.Add(lHexa);
            }
            for (int i = 1; i < 2000; i++) {
                Assert.AreEqual(llHexas.Contains(i), PolygonalSieve.IsHexagonal(i));
            }
        }
        [TestMethod]
        public void HeptaTest() {
            long lHepta;
            List<long> llHeptas = new List<long>(2000);
            Assert.AreEqual(1, PolygonalSieve.GetHeptagonal(1));
            Assert.AreEqual(7, PolygonalSieve.GetHeptagonal(2));
            Assert.AreEqual(18, PolygonalSieve.GetHeptagonal(3));
            Assert.AreEqual(34, PolygonalSieve.GetHeptagonal(4));
            Assert.AreEqual(55, PolygonalSieve.GetHeptagonal(5));
            for (int i = 1; i < 2000; i++) {
                lHepta = PolygonalSieve.GetHeptagonal(i);
                Assert.AreEqual(lHepta, PolygonalSieve.GetPoly(i, 7));
                Assert.AreEqual(i, PolygonalSieve.GetHeptagonalIndex(lHepta));
                Assert.AreEqual(i, PolygonalSieve.GetPolyIndex(lHepta, 7));
                llHeptas.Add(lHepta);
            }
            for (int i = 1; i < 2000; i++) {
                Assert.AreEqual(llHeptas.Contains(i), PolygonalSieve.IsHeptagonal(i));
                Assert.AreEqual(llHeptas.Contains(i), PolygonalSieve.IsPoly(i,7));
            }
        }
        [TestMethod]
        public void OctaTest() {
            long lOcta;
            List<long> llOctas = new List<long>(2000);
            Assert.AreEqual(1, PolygonalSieve.GetOctagonal(1));
            Assert.AreEqual(8, PolygonalSieve.GetOctagonal(2));
            Assert.AreEqual(21, PolygonalSieve.GetOctagonal(3));
            Assert.AreEqual(40, PolygonalSieve.GetOctagonal(4));
            Assert.AreEqual(65, PolygonalSieve.GetOctagonal(5));
            for (int i = 1; i < 2000; i++) {
                lOcta = PolygonalSieve.GetOctagonal(i);
                Assert.AreEqual(i, PolygonalSieve.GetOctagonalIndex(lOcta));
                llOctas.Add(lOcta);
            }
            for (int i = 1; i < 2000; i++) {
                Assert.AreEqual(llOctas.Contains(i), PolygonalSieve.IsOctagonal(i));
                Assert.AreEqual(llOctas.Contains(i), PolygonalSieve.IsPoly(i, 8));
            }
        }
        [TestMethod]
        public void GenerateEach4DigitPoly() {
            List<int> ll = PolygonalSieve.GeneratePolysBetween(1000, 10000, 3);
            Debug.WriteLine("Triangles: " + string.Join(",", ll));
            ll = PolygonalSieve.GeneratePolysBetween(1000, 10000, 4);
            Debug.WriteLine("Squares: " + string.Join(",", ll));
            ll = PolygonalSieve.GeneratePolysBetween(1000, 10000, 5);
            Debug.WriteLine("Pentas: " + string.Join(",", ll));
            ll = PolygonalSieve.GeneratePolysBetween(1000, 10000, 6);
            Debug.WriteLine("Hexas: " + string.Join(",", ll));
            ll = PolygonalSieve.GeneratePolysBetween(1000, 10000, 7);
            Debug.WriteLine("Heptas: " + string.Join(",", ll));
            ll = PolygonalSieve.GeneratePolysBetween(1000, 10000, 8);
            Debug.WriteLine("Octas: " + string.Join(",", ll));


        }

        [TestMethod]
        public void PentaSpeedTest() {
            //Used to determine fastest testing algorithm
            //Winner was HashSet, but only by 2x.
            //BinarySearch broke for larger Lists

            /* Sample Output:
             * 
             * Gen List: 00:00.00s
             * Gen Hash: 00:00.00s
             * Correctness: 00:00.45s
             * Static Numbers: 00:00.01s       //No memory needs, no pre-computed table needed
             * List Contains: 00:04.61s        //REALLY TERRIBLE
             * List BinarySearch: 00:00.01s    //Breaks on List.Count > 300000
             * Hash Contains: 00:00.00s        //Fastest runtime, large memory requirements
             * 
             * Gen List: 00:00.00s
             * Gen Hash: 00:00.00s
             * Correctness: 00:00.46s
             * Static Numbers: 00:18.11s
             * List BinarySearch: 00:36.13s
             * Hash Contains: 00:09.43s
             */
            HashSet<long> hl = new HashSet<long>();
            List<long> ll = new List<long>();
            long lPenta;
            bool b;
            long lTestTo = 300;
            Ticker t = new Ticker();

            for (int i = 1; i < 30000; i++) {
                lPenta = PolygonalSieve.GetPentagonal(i);
                ll.Add(lPenta);
            }
            t.Tick("Gen List");
            for (int i = 1; i < 30000; i++) {
                lPenta = PolygonalSieve.GetPentagonal(i);
                hl.Add(lPenta);
            } 
            t.Tick("Gen Hash");

            //Test Correctness
            for (long i = 1; i < 3000; i++) {
                b = PolygonalSieve.IsPentagonal(i);
                //Assert.AreEqual(b, ll.Contains(i));
                Assert.AreEqual(b, ll.BinarySearch(i) >= 0);
                Assert.AreEqual(b, hl.Contains(i));
            }
            t.Tick("Correctness");

            for (long i = 1; i < lTestTo; i++) {
                b = PolygonalSieve.IsPentagonal(i);
            }
            t.Tick("Static Numbers");

            //Clear loser, all other tests completely eclipse this one, commented out so that the test can give better numbers
            //for (int i = 1; i < iTestTo; i++) {
            //    b = ll.Contains(i);
            //}
            //t.Tick("List Contains");

            for (long i = 1; i < lTestTo; i++) {
                b = ll.BinarySearch(i) >= 0;
            }
            t.Tick("List BinarySearch");

            for (long i = 1; i < lTestTo; i++) {
                b = hl.Contains(i);
            }
            t.Tick("Hash Contains");
        }
    }
}
