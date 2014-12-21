using ProjectEuler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProjectEuler.Controllers {
    public class ProblemsController : Controller {
        // GET: Problems
        public ActionResult Index(int id) {
            ViewBag.Problem = id;
            try {
                MethodInfo mi = this.GetType().GetMethod("Problem" + id);
                ActionResult res = (ActionResult)mi.Invoke(this, null);
            } catch {
                ViewBag.Problem = "ERROR";
                ViewBag.Answer = "Error in switch. Problem ID not found.";
            }
            return View();
        }

        public ActionResult Problem1() {
            int sum = 0;
            for (int i = 1; i < 1000; i++) {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }
            ViewBag.Answer = sum;
            return View();
        }

        public ActionResult Problem2() {
            int iCurr = 1, iNext = 2, iTemp = 0, sum = 0;
            while (iCurr < 4000000) {
                iTemp = iNext + iCurr;
                if (iCurr % 2 == 0) sum += iCurr;
                iCurr = iNext;
                iNext = iTemp;
            }
            ViewBag.Answer = sum;
            return View();
        }

        public ActionResult Problem3() {
            PrimeGenerator pg = new SieveOfEratosthenes(1000);

            ViewBag.Answer = pg.factor(600851475143).Last();
            return View();
        }

        public ActionResult Problem4() {
            int iMax = 0;
            for (int x = 999; x > 100; x--) {
                for (int y = 999; y > 100; y--) {
                    if (Palindromes.IsPalindrome(x * y)) {
                        iMax = Math.Max(x * y, iMax);
                    }
                }
            }
            ViewBag.Answer = iMax;

            return View();
        }

        public ActionResult Problem5() {
            PrimeGenerator pg = new SieveOfEratosthenes(1000);
            int[] iaFactors = new int[21];
            List<int> liFactors;
            int iNum = 1;
            for (int i = 1; i <= 20; i++) {
                liFactors = pg.factor(i);
                for (int f = 1; f <= 20; f++) {
                    iaFactors[f] = Math.Max(iaFactors[f], liFactors.Where(x => x == f).Count());
                }
            }
            for (int i = 1; i <= 20; i++) {
                for (int k = 0; k < iaFactors[i]; k++) {
                    iNum *= i;
                }
            }
            ViewBag.Answer = string.Join(",", iNum);
            return View();
        }

        public ActionResult Problem6() {
            int squareOfSum = Sums.sumNaturalsTo(100);
            squareOfSum *= squareOfSum;
            int sumOfSquares = 0;
            for (int i = 1; i <= 100; i++) {
                sumOfSquares += i * i;
            }
            ViewBag.Answer = squareOfSum - sumOfSquares;
            return View();
        }

        public ActionResult Problem7() {
            PrimeGenerator pg = new SieveOfEratosthenes(10001);
            ViewBag.Answer = pg.getPrime(10000);
            return View();
        }

        public ActionResult Problem8() {
            string sNum = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            long iMax = 0;
            long iCurr = 0;
            for (int i = 0; i < sNum.Length - 13; i++) {
                iCurr = 1;
                for (int k = 0; k < 13; k++) {
                    iCurr *= long.Parse(sNum.Substring(i + k, 1));
                }
                iMax = Math.Max(iCurr, iMax);
            }
            ViewBag.Answer = iMax;
            return View();
        }

        public ActionResult Problem9() {
            int c;
            for (int a = 1; a < 998; a++) {
                for (int b = a; a + b < 1000; b++) {
                    c = 1000 - a - b;
                    if (a * a + b * b == c * c) {
                        ViewBag.Answer = a * b * c;
                        return View();
                    }
                }
            }
            ViewBag.Answer = 0;
            return View();
        }

        public ActionResult Problem10() {
            PrimeGenerator pg = new SieveOfAtkin(20);
            //pg = new SieveOfAtkin(17389);
            //pg = new SieveOfAtkin(224737);
            //pg = new SieveOfAtkin(2750159);
            //pg = new SieveOfAtkin(373587883);
            ViewBag.Answer = "1 & 1: " + (byte)(1 & 1) + "\r\n";
            ViewBag.Answer += "2 & 1: " + (byte)(2 & 1) + "\r\n";
            ViewBag.Answer += "3 & 1: " + (byte)(3 & 1) + "\r\n";
            ViewBag.Answer += "255 & 1: " + (byte)(255 & 1) + "\r\n";
            ViewBag.Answer += "254 & 1: " + (byte)(254 & 1) + "\r\n";
            ViewBag.Answer += "253 & 1: " + (byte)(253 & 1) + "\r\n";
            ViewBag.Answer += "\r\n" + "\r\n";
            ViewBag.Answer += "1 << 1: " + (byte)(1 << 1) + "\r\n";
            ViewBag.Answer += "1 << 2: " + (byte)(1 << 2) + "\r\n";
            ViewBag.Answer += "1 << 3: " + (byte)(1 << 3) + "\r\n";
            ViewBag.Answer += "1 << 4: " + (byte)(1 << 4) + "\r\n";
            ViewBag.Answer += "1 << 5: " + (byte)(1 << 5) + "\r\n";
            ViewBag.Answer += "1 << 6: " + (byte)(1 << 6) + "\r\n";
            ViewBag.Answer += "1 << 7: " + (byte)(1 << 7) + "\r\n";
            ViewBag.Answer += "\r\n" + "\r\n";
            BoolMap m = new BoolMap(9);
            ViewBag.Answer += m.ToString() + "\r\n";
            m.Flip(0);
            ViewBag.Answer += "Flipped 0: " + m.ToString() + "\r\n";
            m.Flip(1);
            ViewBag.Answer += "Flipped 1: " + m.ToString() + "\r\n";
            m.Flip(1);
            ViewBag.Answer += "Flipped 1: " + m.ToString() + "\r\n";
            m.Flip(2);
            ViewBag.Answer += "Flipped 2: " + m.ToString() + "\r\n";
            m.Flip(3);
            ViewBag.Answer += "Flipped 3: " + m.ToString() + "\r\n";
            m.Flip(4);
            ViewBag.Answer += "Flipped 4: " + m.ToString() + "\r\n";
            m.Flip(5);
            ViewBag.Answer += "Flipped 5: " + m.ToString() + "\r\n";
            m.Flip(6);
            ViewBag.Answer += "Flipped 6: " + m.ToString() + "\r\n";
            m.Flip(7);
            ViewBag.Answer += "Flipped 7: " + m.ToString() + "\r\n";
            m.Flip(5);
            ViewBag.Answer += "Flipped 5: " + m.ToString() + "\r\n";
            ViewBag.Answer += "\r\n\r\n";
            m.Set(0, false);
            m.Set(1, false);
            m.Set(2, false);
            ViewBag.Answer += "Disabled 0,1,2: " + m.ToString() + "\r\n";
            m.Set(2, true);
            ViewBag.Answer += "Enabled 2: " + m.ToString() + "\r\n";
            m.Set(5, true);
            ViewBag.Answer += "Enabled 5: " + m.ToString() + "\r\n";
            m.Set(0, true);
            ViewBag.Answer += "Enabled 0: " + m.ToString() + "\r\n";
            m.Enable(10);
            ViewBag.Answer += "Enabled 10: " + m.ToString() + "\r\n";
            m.Enable(12);
            ViewBag.Answer += "Enabled 12: " + m.ToString() + "\r\n";
            m.Disable(10);
            ViewBag.Answer += "Disabled 10: " + m.ToString() + "\r\n";
            m.Disable(11);
            ViewBag.Answer += "Disabled 11: " + m.ToString() + "\r\n";
            m.Disable(12);
            ViewBag.Answer += "Disabled 12: " + m.ToString() + "\r\n";

            return View();
        }

        public ActionResult ProblemN() {
            ViewBag.Answer = 0;
            return View();
        }
    }
}