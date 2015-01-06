using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class NumbersTest {
        [TestMethod]
        public void AllDigitsDifferentTest() {
            Assert.IsTrue(Numbers.AllDigitsDifferent(1234567890));
            Assert.IsFalse(Numbers.AllDigitsDifferent(11));
            Assert.IsFalse(Numbers.AllDigitsDifferent(9911));
            Assert.IsFalse(Numbers.AllDigitsDifferent(2131));
            Assert.IsTrue(Numbers.AllDigitsDifferent(1234560));
            Assert.IsTrue(Numbers.AllDigitsDifferent(123));
            Assert.IsTrue(Numbers.AllDigitsDifferent(0));
            Assert.IsFalse(Numbers.AllDigitsDifferent(0, 0));
            Assert.IsTrue(Numbers.AllDigitsDifferent(678));
            Assert.IsTrue(Numbers.AllDigitsDifferent(678, 1234));
            Assert.IsTrue(Numbers.AllDigitsDifferent(678, 1234, 90));
            Assert.IsTrue(Numbers.AllDigitsDifferent(6, 1, 9));
            Assert.IsFalse(Numbers.AllDigitsDifferent(16, 1, 9));
            Assert.IsFalse(Numbers.AllDigitsDifferent(0, 0, 0));
            Assert.IsFalse(Numbers.AllDigitsDifferent(16, 10, 90));
            Assert.IsFalse(Numbers.AllDigitsDifferent(36, 10, 20));
        }
        [TestMethod]
        public void PandigitalTest() {
            Assert.IsTrue(Numbers.IsPandigital(123456789, 9));
            Assert.IsTrue(Numbers.IsPandigital(123789456, 9));
            Assert.IsTrue(Numbers.IsPandigital(1237894560, 9, true));
            Assert.IsFalse(Numbers.IsPandigital(123, 4));
            Assert.IsFalse(Numbers.IsPandigital(123, 4, true));
            Assert.IsFalse(Numbers.IsPandigital(1230, 4, true));
            Assert.IsTrue(Numbers.IsPandigital(1230, 3, true));
            Assert.IsFalse(Numbers.IsPandigital(1230, 3, false));
            Assert.IsTrue(Numbers.Pandigital1To9(39, 186, 7254));
            Assert.IsFalse(Numbers.Pandigital1To9(309, 186, 7254));
            Assert.IsTrue(Numbers.Pandigital1To9(319, 86, 7254));
            Assert.IsFalse(Numbers.Pandigital1To9(0, 39186, 7254));
        }
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
                Assert.AreEqual(i, PolygonalSieve.GetHexagonalIndex(lHexa));
                llHexas.Add(lHexa);
            }
            for (int i = 1; i < 2000; i++) {
                Assert.AreEqual(llHexas.Contains(i), PolygonalSieve.IsHexagonal(i));
            }
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
            
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            stopWatch.Start();

            for (int i = 1; i < 30000; i++) {
                lPenta = PolygonalSieve.GetPentagonal(i);
                ll.Add(lPenta);
            }
            ts = stopWatch.Elapsed;
            System.Diagnostics.Debug.WriteLine("Gen List: " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Restart();

            for (int i = 1; i < 30000; i++) {
                lPenta = PolygonalSieve.GetPentagonal(i);
                hl.Add(lPenta);
            }
            ts = stopWatch.Elapsed;
            System.Diagnostics.Debug.WriteLine("Gen Hash: " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Restart();

            //Test Correctness
            for (long i = 1; i < 3000; i++) {
                b = PolygonalSieve.IsPentagonal(i);
                Assert.AreEqual(b, ll.Contains(i));
                Assert.AreEqual(b, ll.BinarySearch(i) >= 0);
                Assert.AreEqual(b, hl.Contains(i));
            }
            ts = stopWatch.Elapsed;
            System.Diagnostics.Debug.WriteLine("Correctness: " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Restart();

            for (long i = 1; i < lTestTo; i++) {
                b = PolygonalSieve.IsPentagonal(i);
            }
            ts = stopWatch.Elapsed;
            System.Diagnostics.Debug.WriteLine("Static Numbers: " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Restart();

            //Clear loser, all other tests completely eclipse this one, commented out so that the test can give better numbers
            //for (int i = 1; i < iTestTo; i++) {
            //    b = ll.Contains(i);
            //}
            //ts = stopWatch.Elapsed;
            //System.Diagnostics.Debug.WriteLine("List Contains: " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            //stopWatch.Restart();

            for (long i = 1; i < lTestTo; i++) {
                b = ll.BinarySearch(i) >= 0;
            }
            ts = stopWatch.Elapsed;
            System.Diagnostics.Debug.WriteLine("List BinarySearch: " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Restart();

            for (long i = 1; i < lTestTo; i++) {
                b = hl.Contains(i);
            }
            ts = stopWatch.Elapsed;
            System.Diagnostics.Debug.WriteLine("Hash Contains: " + String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Stop();

        }
    }
}
