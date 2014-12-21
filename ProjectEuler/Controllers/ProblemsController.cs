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

        public ActionResult ProblemN() {
            ViewBag.Answer = 0;
            return View();
        }
    }
}