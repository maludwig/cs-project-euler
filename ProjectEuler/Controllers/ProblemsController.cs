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
            PrimeGenerator pg = new SieveOfAtkin(2000000);
            long lSum = 0;
            for (int i = 0; i < pg.Count(); i++) lSum += pg.getPrime(i);
            ViewBag.Answer = lSum;
            return View();
        }

        public ActionResult Problem11() {
            int[][] iaaNums = {
                new int[] {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                new int[] {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 8 , 43, 69, 48, 04, 56, 62, 00},
                new int[] {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                new int[] {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                new int[] {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                new int[] {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                new int[] {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                new int[] {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                new int[] {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                new int[] {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                new int[] {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                new int[] {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                new int[] {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                new int[] {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                new int[] {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                new int[] {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                new int[] {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                new int[] {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                new int[] {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                new int[] {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}
            };
            int iMax = 0;
            //Horizontals
            for (int y = 0; y < 20; y++) {
                for (int x = 0; x < 17; x++) {
                    iMax = Math.Max(iaaNums[y][x] * iaaNums[y][x + 1] * iaaNums[y][x + 2] * iaaNums[y][x + 3],iMax);
                }
            }
            //Verticals
            for (int y = 0; y < 17; y++) {
                for (int x = 0; x < 20; x++) {
                    iMax = Math.Max(iaaNums[y][x] * iaaNums[y + 1][x] * iaaNums[y + 2][x] * iaaNums[y + 3][x], iMax);
                }
            }
            //Down-right
            for (int y = 0; y < 17; y++) {
                for (int x = 0; x < 17; x++) {
                    iMax = Math.Max(iaaNums[y][x] * iaaNums[y + 1][x + 1] * iaaNums[y + 2][x + 2] * iaaNums[y + 3][x + 3], iMax);
                }
            }
            //Up-right
            for (int y = 0; y < 17; y++) {
                for (int x = 0; x < 17; x++) {
                    iMax = Math.Max(iaaNums[y+3][x] * iaaNums[y + 2][x + 1] * iaaNums[y + 1][x + 2] * iaaNums[y][x + 3], iMax);
                }
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