using ProjectEuler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using ProjectEuler.Primes;

namespace ProjectEuler.Controllers {
    public class ProblemsController : Controller {

        public void Problem1() {
            int sum = 0;
            for (int i = 1; i < 1000; i++) {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }
            ViewBag.Answer = sum;
            View();
        }
        public void Problem2() {
            int iCurr = 1, iNext = 2, iTemp = 0, sum = 0;
            while (iCurr < 4000000) {
                iTemp = iNext + iCurr;
                if (iCurr % 2 == 0) sum += iCurr;
                iCurr = iNext;
                iNext = iTemp;
            }
            ViewBag.Answer = sum;
        }
        public void Problem3() {
            PrimeGenerator pg = new SieveOfEratosthenes(1000);

            ViewBag.Answer = pg.factor(600851475143).Last();
        }
        public void Problem4() {
            int iMax = 0;
            for (int x = 999; x > 100; x--) {
                for (int y = 999; y > 100; y--) {
                    if (Palindromes.IsPalindrome(x * y)) {
                        iMax = Math.Max(x * y, iMax);
                    }
                }
            }
            ViewBag.Answer = iMax;

        }
        public void Problem5() {
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
        }
        public void Problem6() {
            int squareOfSum = Sums.sumNaturalsTo(100);
            squareOfSum *= squareOfSum;
            int sumOfSquares = 0;
            for (int i = 1; i <= 100; i++) {
                sumOfSquares += i * i;
            }
            ViewBag.Answer = squareOfSum - sumOfSquares;
        }
        public void Problem7() {
            PrimeGenerator pg = new SieveOfEratosthenes(10001);
            ViewBag.Answer = pg.getPrime(10000);
        }
        public void Problem8() {
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
        }
        public void Problem9() {
            int c;
            for (int a = 1; a < 998; a++) {
                for (int b = a; a + b < 1000; b++) {
                    c = 1000 - a - b;
                    if (a * a + b * b == c * c) {
                        ViewBag.Answer = a * b * c;
                        return;
                    }
                }
            }
            ViewBag.Answer = 0;
        }
        public void Problem10() {
            PrimeGenerator pg = new SieveOfAtkin(2000000);
            long lSum = 0;
            for (int i = 0; i < pg.Count(); i++) lSum += pg.getPrime(i);
            ViewBag.Answer = lSum;
        }
        public void Problem11() {
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
                    iMax = Math.Max(iaaNums[y][x] * iaaNums[y][x + 1] * iaaNums[y][x + 2] * iaaNums[y][x + 3], iMax);
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
                    iMax = Math.Max(iaaNums[y + 3][x] * iaaNums[y + 2][x + 1] * iaaNums[y + 1][x + 2] * iaaNums[y][x + 3], iMax);
                }
            }
            ViewBag.Answer = iMax;
        }
        public void Problem12() {
            PrimeGenerator pg = new SieveOfAtkin();
            long lTri = 1;
            List<int> liFactors;
            int iLastFactor = 0;
            int iCurrDivCount;
            int iLastDivCount;
            for (int i = 2; i < 1000000; i++) {
                lTri += i;
                liFactors = pg.factor(lTri);
                iCurrDivCount = 1;
                iLastDivCount = 1;
                foreach (int iFactor in liFactors) {
                    if (iFactor != iLastFactor) {
                        iLastDivCount = iCurrDivCount;
                        iLastFactor = iFactor;
                    }
                    iCurrDivCount += iLastDivCount;
                }
                if (iCurrDivCount > 500) {
                    ViewBag.Answer = lTri;
                    break;
                }
            }
        }
        public void Problem13() {
            string[] saNums = new string[] {
                "37107287533902102798797998220837590246510135740250",
                "46376937677490009712648124896970078050417018260538",
                "74324986199524741059474233309513058123726617309629",
                "91942213363574161572522430563301811072406154908250",
                "23067588207539346171171980310421047513778063246676",
                "89261670696623633820136378418383684178734361726757",
                "28112879812849979408065481931592621691275889832738",
                "44274228917432520321923589422876796487670272189318",
                "47451445736001306439091167216856844588711603153276",
                "70386486105843025439939619828917593665686757934951",
                "62176457141856560629502157223196586755079324193331",
                "64906352462741904929101432445813822663347944758178",
                "92575867718337217661963751590579239728245598838407",
                "58203565325359399008402633568948830189458628227828",
                "80181199384826282014278194139940567587151170094390",
                "35398664372827112653829987240784473053190104293586",
                "86515506006295864861532075273371959191420517255829",
                "71693888707715466499115593487603532921714970056938",
                "54370070576826684624621495650076471787294438377604",
                "53282654108756828443191190634694037855217779295145",
                "36123272525000296071075082563815656710885258350721",
                "45876576172410976447339110607218265236877223636045",
                "17423706905851860660448207621209813287860733969412",
                "81142660418086830619328460811191061556940512689692",
                "51934325451728388641918047049293215058642563049483",
                "62467221648435076201727918039944693004732956340691",
                "15732444386908125794514089057706229429197107928209",
                "55037687525678773091862540744969844508330393682126",
                "18336384825330154686196124348767681297534375946515",
                "80386287592878490201521685554828717201219257766954",
                "78182833757993103614740356856449095527097864797581",
                "16726320100436897842553539920931837441497806860984",
                "48403098129077791799088218795327364475675590848030",
                "87086987551392711854517078544161852424320693150332",
                "59959406895756536782107074926966537676326235447210",
                "69793950679652694742597709739166693763042633987085",
                "41052684708299085211399427365734116182760315001271",
                "65378607361501080857009149939512557028198746004375",
                "35829035317434717326932123578154982629742552737307",
                "94953759765105305946966067683156574377167401875275",
                "88902802571733229619176668713819931811048770190271",
                "25267680276078003013678680992525463401061632866526",
                "36270218540497705585629946580636237993140746255962",
                "24074486908231174977792365466257246923322810917141",
                "91430288197103288597806669760892938638285025333403",
                "34413065578016127815921815005561868836468420090470",
                "23053081172816430487623791969842487255036638784583",
                "11487696932154902810424020138335124462181441773470",
                "63783299490636259666498587618221225225512486764533",
                "67720186971698544312419572409913959008952310058822",
                "95548255300263520781532296796249481641953868218774",
                "76085327132285723110424803456124867697064507995236",
                "37774242535411291684276865538926205024910326572967",
                "23701913275725675285653248258265463092207058596522",
                "29798860272258331913126375147341994889534765745501",
                "18495701454879288984856827726077713721403798879715",
                "38298203783031473527721580348144513491373226651381",
                "34829543829199918180278916522431027392251122869539",
                "40957953066405232632538044100059654939159879593635",
                "29746152185502371307642255121183693803580388584903",
                "41698116222072977186158236678424689157993532961922",
                "62467957194401269043877107275048102390895523597457",
                "23189706772547915061505504953922979530901129967519",
                "86188088225875314529584099251203829009407770775672",
                "11306739708304724483816533873502340845647058077308",
                "82959174767140363198008187129011875491310547126581",
                "97623331044818386269515456334926366572897563400500",
                "42846280183517070527831839425882145521227251250327",
                "55121603546981200581762165212827652751691296897789",
                "32238195734329339946437501907836945765883352399886",
                "75506164965184775180738168837861091527357929701337",
                "62177842752192623401942399639168044983993173312731",
                "32924185707147349566916674687634660915035914677504",
                "99518671430235219628894890102423325116913619626622",
                "73267460800591547471830798392868535206946944540724",
                "76841822524674417161514036427982273348055556214818",
                "97142617910342598647204516893989422179826088076852",
                "87783646182799346313767754307809363333018982642090",
                "10848802521674670883215120185883543223812876952786",
                "71329612474782464538636993009049310363619763878039",
                "62184073572399794223406235393808339651327408011116",
                "66627891981488087797941876876144230030984490851411",
                "60661826293682836764744779239180335110989069790714",
                "85786944089552990653640447425576083659976645795096",
                "66024396409905389607120198219976047599490197230297",
                "64913982680032973156037120041377903785566085089252",
                "16730939319872750275468906903707539413042652315011",
                "94809377245048795150954100921645863754710598436791",
                "78639167021187492431995700641917969777599028300699",
                "15368713711936614952811305876380278410754449733078",
                "40789923115535562561142322423255033685442488917353",
                "44889911501440648020369068063960672322193204149535",
                "41503128880339536053299340368006977710650566631954",
                "81234880673210146739058568557934581403627822703280",
                "82616570773948327592232845941706525094512325230608",
                "22918802058777319719839450180888072429661980811197",
                "77158542502016545090413245809786882778948721859617",
                "72107838435069186155435662884062257473692284509516",
                "20849603980134001723930671666823555245252804609722",
                "53503534226472524250874054075591789781264330331690"
            };
            BigInteger bSum = BigInteger.Zero;
            for (int i = 0; i < saNums.Length; i++) {
                bSum = BigInteger.Add(bSum, BigInteger.Parse(saNums[i]));
            }
            ViewBag.Answer = bSum.ToString().Substring(0, 10);
        }
        public void Problem14() {
            int iMaxChain = 1;
            int iMaxNum = 1;
            int iChain;
            for (int i = 2; i < 1000000; i++) {
                iChain = Numbers.CollatzChainLength(i);
                if (iChain > iMaxChain) {
                    iMaxChain = iChain;
                    iMaxNum = i;
                }
            }
            ViewBag.Answer = iMaxNum;
        }
        public void Problem15() {
            long[,] iaaPaths = new long[21, 21];
            for (int i = 0; i < 21; i++) {
                iaaPaths[0, i] = 1;
                iaaPaths[i, 0] = 1;
            }
            for (int x = 1; x < 21; x++) {
                for (int y = 1; y < 21; y++) {
                    iaaPaths[x, y] = iaaPaths[x - 1, y] + iaaPaths[x, y - 1];
                }
            }
            ViewBag.Answer = iaaPaths[20, 20];
        }
        public void Problem16() {
            BigInteger bPower = BigInteger.Pow(new BigInteger(2), 1000);
            ViewBag.Answer = Sums.sumDigits(bPower.ToString());
        }
        public void Problem17() {
            string[] ones = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = new string[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            int[] names = new int[1000];
            int one, ten, hun, r, iSum = 0;
            for (var x = 0; x < 20; x++) {
                names[x] = ones[x].Length;
            }
            for (var x = 20; x < 100; x++) {
                one = x % 10;
                ten = (x - one) / 10;
                names[x] = tens[ten].Length + ones[one].Length;
            }
            names[0] = -3; //compensate for the "and"
            for (var x = 100; x < 1000; x++) {
                r = x % 100;
                hun = (x - r) / 100;
                names[x] = ones[hun].Length + "hundredand".Length + names[r];
            }
            for (var x = 1; x < 1000; x++) {
                iSum += names[x];
            }
            ViewBag.Answer = iSum + "onethousand".Length;
        }
        public void Problem18() {
            int[][] src = {
                new int[] {75},
                new int[] {95, 64},
                new int[] {17, 47, 82},
                new int[] {18, 35, 87, 10},
                new int[] {20, 04, 82, 47, 65},
                new int[] {19, 01, 23, 75, 03, 34},
                new int[] {88, 02, 77, 73, 07, 63, 67},
                new int[] {99, 65, 04, 28, 06, 16, 70, 92},
                new int[] {41, 41, 26, 56, 83, 40, 80, 70, 33},
                new int[] {41, 48, 72, 33, 47, 32, 37, 16, 94, 29},
                new int[] {53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14},
                new int[] {70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57},
                new int[] {91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48},
                new int[] {63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31},
                new int[] {04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23}
            };
            int[,] solve = new int[src.Length, src.Length];
            int end = 0;
            int iMax = 0;
            solve[0, 0] = src[0][0];
            for (int y = 1; y < src.Length; y++) {
                solve[y, 0] = src[y][0] + solve[y - 1, 0];
                end = src[y].Length - 1;
                solve[y, end] = src[y][end] + solve[y - 1, end - 1];
                for (int x = 1; x < src[y].Length - 1; x++) {
                    solve[y, x] = Math.Max(solve[y - 1, x], solve[y - 1, x - 1]) + src[y][x];
                }
            }
            for (int x = 0; x < src.Length; x++) iMax = Math.Max(solve[src.Length - 1, x], iMax);
            ViewBag.Answer = iMax;
        }
        public void Problem19() {
            DateTime dt = new DateTime(1901, 1, 1);
            DateTime dtEnd = new DateTime(2000, 12, 31);
            int iSundayCount = 0;
            while (dt < dtEnd) {
                dt = dt.AddMonths(1);
                if (dt.DayOfWeek == DayOfWeek.Sunday) iSundayCount++;
            }
            ViewBag.Answer = iSundayCount;
        }
        public void Problem20() {
            BigInteger b = BigInteger.One;
            for (int i = 2; i <= 100; i++) b = BigInteger.Multiply(b, new BigInteger(i));
            ViewBag.Answer = Sums.sumDigits(b);
        }
        public void Problem21() {
            PrimeGenerator pg = new SieveOfAtkin();
            int iDivSum = 0;
            int iAmicableSum = 0;
            for (int i = 2; i < 10000; i++) {
                iDivSum = pg.properDivisors(i).Sum();
                if (iDivSum != i) {
                    if (pg.properDivisors(iDivSum).Sum() == i) {
                        iAmicableSum += i;
                    }
                }
            }
            ViewBag.Answer = iAmicableSum;
        }
        public void Problem22() {
            List<string> lsNames = new List<string>(System.IO.File.ReadAllLines(Server.MapPath(@"~/App_Data/names.txt")));
            long lSum = 0;
            long lWordSum = 0;
            lsNames.Sort();
            for (int i = 0; i < lsNames.Count(); i++) {
                lWordSum = 0;
                foreach (char c in lsNames[i]) {
                    lWordSum += (long)c + 1;
                    lWordSum -= (long)'A';
                }
                lSum += (i + 1) * lWordSum;
            }
            ViewBag.Answer = lSum;
        }
        public void Problem23() {
            List<int> liAbundants = new List<int>();
            PrimeGenerator pg = new SieveOfAtkin();
            bool bCanBeSumOfTwo;
            int iSum = 0;
            for (int i = 0; i < 28123; i++) {
                if (pg.perfection(i) == PerfectionLevel.ABUNDANT) liAbundants.Add(i);
                bCanBeSumOfTwo = false;
                foreach (int iAbundant in liAbundants) {
                    if (liAbundants.BinarySearch(i - iAbundant) >= 0) {
                        bCanBeSumOfTwo = true;
                        break;
                    }
                }
                if (!bCanBeSumOfTwo) {
                    iSum += i;
                }
            }
            ViewBag.Answer = iSum;
        }
        public void Problem24() {
            string sRemainingDigits = "0123456789";
            int iPerm = 1000000 - 1;
            int iFactorial;
            string sResult = "";
            while (sRemainingDigits.Length != 0) {
                iFactorial = Numbers.factorial(sRemainingDigits.Length - 1);
                sResult += sRemainingDigits.Substring(iPerm / iFactorial, 1);
                sRemainingDigits = sRemainingDigits.Substring(0, iPerm / iFactorial) + sRemainingDigits.Substring((iPerm / iFactorial) + 1);
                iPerm %= iFactorial;
            }
            ViewBag.Answer = sResult;
        }
        public void Problem25() {
            BigInteger b1 = BigInteger.One, b2 = BigInteger.One, bNext;
            int i;
            for (i = 1; b1.ToString().Length < 1000; i++) {
                bNext = BigInteger.Add(b1, b2);
                b1 = b2;
                b2 = bNext;
            }
            ViewBag.Answer = i;
        }
        public void Problem26() {
            //1000 decimal digits of precision
            BigDecimal bd1 = new BigDecimal(1, 0, 1000);
            BigDecimal bd2 = new BigDecimal(1, 0, 1000);
            string someChars;
            string sNum;
            int iMaxCycle = 0;
            int iMaxNum = 0;
            int iCycle = 0;
            for (int i = 2; i < 1000; i++) {
                bd2++;
                sNum = (bd1 / bd2).ToString();
                if (sNum.Length == 1002) {
                    someChars = sNum.Substring(980);
                    iCycle = 980 - sNum.LastIndexOf(someChars, 1000);
                    if (iCycle != -1) {
                        if (iMaxCycle < iCycle) {
                            iMaxCycle = iCycle;
                            iMaxNum = i;
                        }
                    }
                }
            }
            ViewBag.Answer = iMaxNum;
        }
        public void Problem27() {
            PrimeGenerator pg = new SieveOfAtkin(1000000);
            int[] iaPrimes = pg.getPrimesTo(1000).ToArray();
            //b must be positive and prime, in order for n^2+an+b to produce a prime when n=0
            int b, n;
            int iMaxA = 0, iMaxB = 0, iMaxN = 0;
            for (int a = -1000; a < 1000; a++) {
                for (int i = 0; i < iaPrimes.Length; i++) {
                    b = iaPrimes[i];
                    for (n = 1; n < 100; n++) {
                        if (pg.findPrime(n * n + a * n + b) == -1) {
                            break;
                        }
                    }
                    if (n > iMaxN) {
                        iMaxA = a;
                        iMaxB = b;
                        iMaxN = n;
                    }
                }
            }
            ViewBag.Answer = iMaxA + ", " + iMaxB + ": " + iMaxA * iMaxB;
        }
        public void Problem28() {
            long lSum = 1;
            for (int i = 3; i <= 1001; i += 2) {
                lSum += (4 * i * i) - (6 * i) + 6;
            }
            ViewBag.Answer = lSum;
        }
        public void Problem29() {
            HashSet<BigInteger> hb = new HashSet<BigInteger>();
            for (int a = 2; a <= 100; a++) {
                for (int b = 2; b <= 100; b++) {
                    hb.Add(BigInteger.Pow(a, b));
                }
            }
            ViewBag.Answer = hb.Count();
        }
        public void Problem30() {
            int[] iaPows = new int[10];
            int a, b, c, d, v;
            int iKey;

            Dictionary<int, List<int>> diiLookup = new Dictionary<int, List<int>>();
            List<int> liMantissae;
            int iSum = 0;

            //Precalculate powers of single integers for speed
            for (int i = 0; i < 10; i++) {
                iaPows[i] = (int)Math.Pow(i, 5);
            }
            //Precalculate last 3 digits, to make things a simple Dictionary lookup (Hash-based O(1) runtime)
            for (b = 0; b < 10; b++) {
                for (c = 0; c < 10; c++) {
                    for (d = 0; d < 10; d++) {
                        v = b * 100 + c * 10 + d;
                        iKey = iaPows[b] + iaPows[c] + iaPows[d] - v;
                        if (diiLookup.ContainsKey(iKey)) {
                            diiLookup[iKey].Add(v);
                        } else {
                            diiLookup.Add(iKey, new List<int>(new int[] { v }));
                        }
                    }
                }
            }

            for (a = 0; a < 10; a++) {
                for (b = 0; b < 10; b++) {
                    for (c = 0; c < 10; c++) {
                        v = a * 100000 + b * 10000 + c * 1000 - iaPows[a] - iaPows[b] - iaPows[c];
                        if (diiLookup.TryGetValue(v, out liMantissae)) {
                            foreach (int iMantissa in liMantissae) {
                                iSum += a * 100000 + b * 10000 + c * 1000 + iMantissa;
                            }
                        }
                    }
                }
            }
            ViewBag.Answer = iSum - 1; //1^5 is not considered a sum
        }
        int[] iaCoins = new int[] { 200, 100, 50, 20, 10, 5, 2, 1 };
        public void Problem31() {
            ViewBag.Answer = CoinCombs(200, 0);
        }
        //n = number to get combinations for
        //maxCoin = the index of the biggest coin that can be used.
        private int CoinCombs(int n, int maxCoin) {
            if (n <= 1) return 1;
            if (maxCoin >= iaCoins.Length - 1) return 1; //If all pennies

            int iCombSum = 1; //Account for all pennies case
            //For each type of coin
            for (int i = iaCoins.Length - 2; i >= maxCoin && iaCoins[i] <= n; i--) {
                //For each count of the coin
                for (int c = 1; iaCoins[i] * c <= n; c++) {
                    iCombSum += CoinCombs(n - (iaCoins[i] * c), i + 1);
                }
            }
            return iCombSum;
        }
        public void Problem32() {
            HashSet<int> hiProducts = new HashSet<int>();
            for (int x = 1; x < 2000; x++) {
                if (Numbers.AllDigitsDifferent(x)) {
                    for (int y = x + 1; y < 2000; y++) {
                        if (Numbers.Pandigital1To9(x, y, x * y)) {
                            System.Diagnostics.Debug.WriteLine(x + "*" + y + "=" + x * y);
                            hiProducts.Add(x * y);
                        }
                    }
                }
            }
            ViewBag.Answer = hiProducts.Sum();
        }
        public void Problem33() {
            int n1, n2, d1, d2;
            float f1, f2;
            int allNume = 1, allDeno = 1;
            for (int n = 10; n < 100; n++) {
                n1 = n / 10;
                n2 = n % 10;
                if (n2 == 0) continue;
                for (int d = n + 1; d < 100; d++) {
                    d1 = d / 10;
                    d2 = d % 10;
                    if (d2 == 0) continue;
                    f1 = n;
                    f1 /= d;
                    if (d1 == n2) {
                        f2 = n1;
                        f2 /= d2;
                        if (f1 == f2) {
                            allNume *= n1;
                            allDeno *= d2;
                        }
                    }
                }
            }
            ViewBag.Answer = allDeno / allNume;
        }
        public void Problem34() {
            int d;
            int iCopy;
            int iFactSum;
            int iAnswer = 0;
            for (int i = 3; i < 50000; i++) {
                iCopy = i;
                iFactSum = 0;
                while (iCopy > 0) {
                    d = iCopy % 10;
                    iFactSum += Numbers.factorial(d);
                    iCopy /= 10;
                }
                if (iFactSum == i) {
                    System.Diagnostics.Debug.WriteLine(i);
                    iAnswer += i;
                }
            }
            ViewBag.Answer = iAnswer;
        }
        public void Problem35() {
            int iCount = 0;
            PrimeGenerator pg = new SieveOfAtkin();
            for (int i = 0; pg.getPrime(i) < 1000000; i++) {
                if (pg.IsCircularPrime(pg.getPrime(i))) {
                    iCount++;
                }
            }
            ViewBag.Answer = iCount;
        }
        public void Problem36() {
            int iSum = 0;
            for (int i = 1; i < 1000000; i++) {
                if (i.ToString().IsPalindrome()) {
                    if (i.ToBinaryString().IsPalindrome()) {
                        iSum += i;
                    }
                }
            }
            ViewBag.Answer = iSum;
        }
        public void Problem37() {
            int iSum = 0;
            PrimeGenerator pg = new SieveOfAtkin();
            for (int i = 5; pg.getPrime(i) < 1000000; i++) {
                if (pg.IsTruncatablePrime(pg.getPrime(i))) {
                    iSum += pg.getPrime(i);
                }
            }
            ViewBag.Answer = iSum;
        }
        public void Problem38() {
            //We know the largest Pandigital is at least 918273645
            //Since the first digit of this given pandigital is 9, and the number is of fixed length, as it is 1-9 pandigital
            //And since the first digit is the first digit of x*1, we know that x must begin with 9, and that x!=9.
            int iConProd;
            int iConProdMax = 0;
            for (int i = 90; i < 100; i++) {
                iConProd = ConProdPandigital(i);
                if (iConProd != -1) {
                    if (iConProdMax < iConProd) {
                        iConProdMax = iConProd;
                    }
                }
            }
            for (int i = 900; i < 1000; i++) {
                iConProd = ConProdPandigital(i);
                if (iConProd != -1) {
                    if (iConProdMax < iConProd) {
                        iConProdMax = iConProd;
                    }
                }
            }
            for (int i = 9000; i < 10000; i++) {
                iConProd = ConProdPandigital(i);
                if (iConProd != -1) {
                    if (iConProdMax < iConProd) {
                        iConProdMax = iConProd;
                    }
                }
            }
            ViewBag.Answer = iConProdMax;
        }
        public int ConProdPandigital(int i) {
            string sNum;
            int iRet;

            sNum = i.ToString();
            for (int x = 2; sNum.Length < 9; x++) {
                sNum = sNum + (x * i);
            }
            if (sNum.Length == 9) {
                iRet = int.Parse(sNum);
                if (Numbers.Pandigital1To9(iRet)) {
                    return iRet;
                }
            }
            return -1;
        }
        public void Problem39() {
            int iMaxSols = 0;
            int[] iaSols = new int[1001];
            double c;
            for (int a = 1; a <= 998; a++) {
                for (int b = a; a + b <= 999; b++) {
                    c = Math.Sqrt(a * a + b * b);
                    if (c == Math.Floor(c)) {
                        if (a + b + c <= 1000) {
                            iaSols[a + b + (int)c]++;
                            if (iaSols[a + b + (int)c] > iaSols[iMaxSols]) {
                                iMaxSols = a + b + (int)c;
                            }
                        }
                    }
                }
            }
            ViewBag.Answer = iMaxSols;
        }
        public void Problem40() {
            int[] iaDigitIndicies = new int[] { 1, 10, 100, 1000, 10000, 100000, 1000000 };
            int iProduct = 1;
            foreach (int i in iaDigitIndicies) {
                iProduct *= GetDigitOfWeirdIrrational(i);
            }
            ViewBag.Answer = iProduct;
        }
        public int GetDigitOfWeirdIrrational(int iIndex) {
            int iTotal = 0;
            int iDigitCount = 0;
            int iTermSize;
            int iTerm;
            int iFirstTerm;
            string sDigit;
            if (iIndex < 10) return iIndex;
            iIndex--;
            for (iTermSize = 1; iTotal < iIndex; iTermSize++) {
                iDigitCount = iTermSize * ((int)Math.Pow(10, iTermSize - 1) * 9);
                iTotal += iDigitCount;
            }
            iTotal -= iDigitCount;
            iTermSize--;
            //iTotal now contains the index of the beginning of the sequence of terms
            //iTermSize contains the size of sub-terms at the current point
            iFirstTerm = (int)Math.Pow(10, iTermSize - 1);
            iTerm = ((iIndex - iTotal) / iTermSize) + iFirstTerm;
            sDigit = iTerm.ToString().Substring((iIndex - iTotal) % iTermSize, 1);
            return int.Parse(sDigit);
        }
        public void Problem41() {
            //Since any power of 10^n = 3k+1 for some k (ex. 1000 = 3(333)+1)
            //Then we know for any x(10^n) = x(3k+1) = 3kx+x  (ex. 800 = 3(33*8)+8)
            //Therefore if the sum of the digits of a number are divisible by 3, then the number must be divisible by 3
            //    ex. 813 = 3(33*8)+8 + 3(3*1)+1 + 3 = 3(33*8 + 3*1) + 8 + 1 + 3 = 3(277) + 8+1+3 = 3(277) + 3(4)

            //Therefore, since 1+2+3+4+5+6+7+8+9 is divisible by 3, and 1+2+3+4+5+6+7+8 is divisible by 3, all permutations of them will be divisible by 3.
            PrimeGenerator pg = new SieveOfAtkin(10000000);
            int iPrime = 0;

            for (int i = pg.Count()-1; i > 0; i--) {
                iPrime = pg.getPrime(i);
                if (Numbers.IsPandigital(iPrime, iPrime.ToString().Length)) {
                    break;
                }
            }
            ViewBag.Answer = iPrime;
        }
        public void Problem42() {

            List<string> lsWords = new List<string>(System.IO.File.ReadAllLines(Server.MapPath(@"~/App_Data/words.txt")));
            int iCount = 0;
            int iSum = 0;
            List<int> liTriangles = new List<int>();
            char[] ca;
            for (int i = 1; i < 100; i++) {
                iSum += i;
                liTriangles.Add(iSum);
            }
            foreach (string sWord in lsWords) {
                ca = sWord.ToCharArray();
                iSum = 0;
                foreach (char c in ca) {
                    iSum += (int)c - (int)'A' + 1;
                }
                if (liTriangles.Contains(iSum)) {
                    iCount++;
                }
            }
            ViewBag.Answer = iCount;
        }
        public void Problem43() {
            List<int> liTails = new List<int>();
            int iSeed = 10.Pow(6); //10^RequiredDigits
            int iSecondSeed = 10.Pow(4);
            long lSum = 0;
            //Precalculate possible tails
            for (int i = iSeed / 10; i < iSeed; i++) {
                if (i.GetDigits(3) % 17 == 0) {
                    if (i.GetDigits(4, 3) % 13 == 0) {
                        if (i.GetDigits(5, 3) % 11 == 0) {
                            if (i.GetDigits(6, 3) % 7 == 0) {
                                if (i.GetDigit(5) % 5 == 0) {
                                    if (Numbers.AllDigitsDifferent(i)) {
                                        for (int k = iSecondSeed / 10; k < iSecondSeed; k += 2) {
                                            if ((k.GetDigits(2) + i.GetDigit(6)) % 3 == 0) {
                                                if (Numbers.AllDigitsDifferent(k, i)) {
                                                    //If all the digits are different, and there are 10 digits, it's Palindromic
                                                    lSum += long.Parse(k.ToString() + i);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ViewBag.Answer = lSum;
        }
        public void Problem44() {
            //Heavily optimized
            //See PentaSpeedTest() in NumbersTest for details
            long lXPenta, lYPenta;
            for (int x = 1; true; x++) {
                lXPenta = Numbers.GetPentagonal(x);
                for (int y = 1; y < x; y++) {
                    lYPenta = Numbers.GetPentagonal(y);
                    if (Numbers.IsPentagonal(lXPenta + lYPenta)) {
                        if (Numbers.IsPentagonal(lXPenta + (2 * lYPenta))) {
                            ViewBag.Answer = lXPenta;
                            return;
                        }
                    }
                }
            }
        }
        public void Problem45() {
            long lHexa;
            for (int h = 145; true; h++) {
                lHexa = Numbers.GetHexagonal(h);
                if (Numbers.IsPentagonal(lHexa)) {
                    if (Numbers.IsTriangle(lHexa)) {
                        ViewBag.Answer = lHexa;
                        return;
                    }
                }
            }

            ViewBag.Answer = 0;
        }
        public void Problem46() {
            bool bWritable;
            PrimeGenerator pg = new SieveOfAtkin();
            for (int i = 9; true; i += 2) {
                if (!pg.IsPrime(i)) {
                    bWritable = false;
                    for (int sq = 1; 2 * sq * sq < i; sq++) {
                        if (pg.IsPrime(i - 2 * sq * sq)) {
                            bWritable = true;
                            break;
                        }
                    }
                    if (!bWritable) {
                        ViewBag.Answer = i;
                        return;
                    }
                }
            }
        }
        public void ProblemN() {
            ViewBag.Answer = 0;
        }

        // GET: Problems
        public ActionResult Index(int id) {
            MethodInfo mi;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            stopWatch.Start();

            ViewBag.MaxProblem = 1;
            for (int i = 1; i < 1000; i++) {
                mi = this.GetType().GetMethod("Problem" + i);
                if (mi == null) {
                    i--;
                    ViewBag.MaxProblem = i;
                    if (id == 0) id = i;
                    break;
                }
            }
            ViewBag.Problem = id;

            try {
                mi = this.GetType().GetMethod("Problem" + id);
                mi.Invoke(this, null);
            } catch {
                ViewBag.Problem = "ERROR";
                ViewBag.Answer = "Error in switch. Problem ID not found.";
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            ViewBag.ElapsedTime = String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            return View();
        }
    }
}