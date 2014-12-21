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

        public ActionResult ProblemN() {
            ViewBag.Answer = 0;
            return View();
        }
    }
}