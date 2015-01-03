using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Classes;
using System.Numerics;
using System.Diagnostics;

namespace ProjectEuler.Tests.Classes {
    [TestClass]
    public class PalindromesTest {
        [TestMethod]
        public void ReverseTest() {
            BigInteger b, b2;
            Assert.AreEqual(1, Palindromes.Reverse(1));
            Assert.AreEqual(9, Palindromes.Reverse(9));
            Assert.AreEqual(0, Palindromes.Reverse(0));
            Assert.AreEqual(11, Palindromes.Reverse(11));
            Assert.AreEqual(13, Palindromes.Reverse(31));
            Assert.AreEqual(432113, Palindromes.Reverse(311234));

            b = 1234;
            b2 = 4321;
            Assert.AreEqual(b2, Palindromes.Reverse(b));

            b = 0;
            Assert.AreEqual(b, Palindromes.Reverse(b));

            Assert.AreEqual("asdfasdf", Palindromes.Reverse("fdsafdsa"));
        }
        
        [TestMethod]
        public void PalindromeTest() {
            BigInteger b;
            
            b = 123321;
            Assert.IsTrue(Palindromes.IsPalindrome("asdffdsa"));
            Assert.IsTrue(Palindromes.IsPalindrome(432234));
            Assert.IsTrue(Palindromes.IsPalindrome(4342434));
            Assert.IsTrue(Palindromes.IsPalindrome(b));
        }
        [TestMethod]
        public void SpeedTest() {
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            stopWatch.Start();
            for (int i = 0; i < 1000; i++) {
                ReverseTest();
            }
            ts = stopWatch.Elapsed;
            System.Diagnostics.Debug.WriteLine(String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Reset();
            for (int i = 0; i < 1000; i++) {
                PalindromeTest();
            }
            ts = stopWatch.Elapsed;
            stopWatch.Stop();
            System.Diagnostics.Debug.WriteLine(String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
        }
        
        [TestMethod]
        public void LychrelTest() {
            Assert.AreEqual(1, Palindromes.LychrelValue(56));
            Assert.AreEqual(2, Palindromes.LychrelValue(57));
            Assert.AreEqual(3, Palindromes.LychrelValue(59));
            Assert.AreEqual(24, Palindromes.LychrelValue(89));
            Assert.AreEqual(55, Palindromes.LychrelValue(10911));
            Assert.AreEqual(-1, Palindromes.LychrelValue(196));
            BigInteger b = BigInteger.Parse("1186060307891929990");
            Assert.AreEqual(261, Palindromes.CalculateLychrel(b, 280));
        }
    }
}
