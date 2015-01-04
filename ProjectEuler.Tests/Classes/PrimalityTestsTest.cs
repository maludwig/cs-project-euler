﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEuler.Primes;
using System.Diagnostics;
using ProjectEuler.Extensions;
using System.Numerics;

namespace MikesEuler.Tests.NumberTests {
    [TestClass]
    public class PrimalityTestsTest {
        List<int> liPrimes = new List<int>(new int[] { 2, 3, 5, 7, 11, 13, 17, 19 });


        PrimeGenerator pg = new SieveOfAtkin(10000);

        [TestMethod]
        public void BasicPrimesTest() {
            IPrimalityTest p = new BasicPrimes();
            TestAnInterface(p);
        }
        [TestMethod]
        public void TestMillerRabin() {
            IPrimalityTest p = new MillerRabin();
            TestAnInterface(p);
            BigInterfaceTest(p);
            Assert.IsTrue(p.IsPrime(2147483647));
        }
        [TestMethod]
        public void QuickLongMillerRabinTest() {
            long[] testList = new long[] { 5915587277L, 1500450271L, 3267000013L, 5754853343L, 4093082899L, 9576890767L,//
            3628273133L, 2860486313L, 5463458053L, 3367900313L, 9223372036854775783L };
            foreach (long lTestValue in testList) {
                Assert.IsTrue(MillerRabin.MillerRabinPass(2L, lTestValue));
            }
        }
        [TestMethod]
        public void QuickBigIntegerMillerRabinTest() {
            MillerRabin mr = new MillerRabin();
            BigInteger b;
            string[] saTestPrimes = new string[] {"5915587277", "1500450271", "3267000013", "5754853343", "4093082899", "9576890767", "3628273133", "2860486313", "5463458053", "3367900313", "48112959837082048697", "54673257461630679457", "29497513910652490397", "40206835204840513073", "12764787846358441471", "71755440315342536873", "45095080578985454453", "27542476619900900873", "66405897020462343733", "36413321723440003717", "671998030559713968361666935769", "282174488599599500573849980909", "521419622856657689423872613771", "362736035870515331128527330659", "115756986668303657898962467957", "590872612825179551336102196593", "564819669946735512444543556507", "513821217024129243948411056803", "416064700201658306196320137931", "280829369862134719390036617067", "2425967623052370772757633156976982469681", "1451730470513778492236629598992166035067", "6075380529345458860144577398704761614649", "3615415881585117908550243505309785526231", "5992830235524142758386850633773258681119", "4384165182867240584805930970951575013697", "5991810554633396517767024967580894321153", "6847944682037444681162770672798288913849", "4146162919458530168953357282201621124057", "5570373270183181665098052481109678989411", "22953686867719691230002707821868552601124472329079", "30762542250301270692051460539586166927291732754961", "29927402397991286489627837734179186385188296382227", "46484729803540183101830167875623788794533441216779", "95647806479275528135733781266203904794419563064407", "64495327731887693539738558691066839103388567300449", "58645563317564309847334478714939069495243200674793", "48705091355238882778842909230056712140813460157899", "15452417011775787851951047309563159388840946309807", "53542885039615245271174355315623704334284773568199", "622288097498926496141095869268883999563096063592498055290461", "610692533270508750441931226384209856405876657993997547171387", "668486051696691190102895306426999370394054817506916629001851", "313539589974026666385010319707341761012894704055733952484113", "470287785858076441566723507866751092927015824834881906763507", "361720912810755408215708460645842859722715865206816237944587", "378348910233465647859184421334615532543749747185321634086219", "669483106578092405936560831017556154622901950048903016651289", "351300033958683656629281197430236951045077917074227778834807", "511704374946917490638851104912462284144240813125071454126151", "4669523849932130508876392554713407521319117239637943224980015676156491", "4906275427767802358357703730938087362176142642699093827933107888253709", "2409130781894986571956777721649968801511465915451196376269177305066867", "7595009151080016652449223792726748985452052945413160073645842090827711", "3822535632033509464266159811805197854872067042990716005808372194664933", "5885903965180586669073549360644800583458138238012033647539649735017287", "5850725702766829291491370712136286009948642125131436113342815786444567", "4237080979868607742750808600846638318022863593147774739556427943294937", "3773180816219384606784189538899553110499442295782576702222280384917551", "9547848065153773335707495885453566120069130270246768806790708393909999", "18532395500947174450709383384936679868383424444311405679463280782405796233163977", "39688644836832882526173831577536117815818454437810437210221644553381995813014959", "44822481511601066098713481453161748979849764719554039096395688045048053310178487", "54875133386847519273109693154204970395475080920935355580245252923343305939004903", "40979218404449071854385509743772465043384063785613460568705289173181846900181503", "56181069873486948735852120493417527485226565150317825065106074926567306630125961", "19469495355310348270990592580191998639221450743640952620236903851789700309402857", "34263233064835421125264776608163440537925705997962346596977803462033841059628723", "14759984361802021245410475928101669395348791811705709117374129427051861355011151", "67120333368520272532940669112228025474970578938046280618394371551488988323794243", "282755483533707287054752184321121345766861480697448703443857012153264407439766013042402571", "370332600450952648802345609908335058273399487356359263038584017827194636172568988257769601", "463199005416013829210323411514132845972525641604435693287586851332821637442813833942427923", "374413471625854958269706803072259202131399386829497836277471117216044734280924224462969371", "664869143773196608462001772779382650311673568542237852546715913135688434614731717844868261", "309133826845331278722882330592890120369379620942948199356542318795450228858357445635314757", "976522637021306403150551933319006137720124048624544172072735055780411834104862667155922841", "635752334942676003169313626814655695963315290125751655287486460091602385142405742365191277", "625161793954624746211679299331621567931369768944205635791355694727774487677706013842058779", "204005728266090048777253207241416669051476369216501266754813821619984472224780876488344279", "2074722246773485207821695222107608587480996474721117292752992589912196684750549658310084416732550077", "2367495770217142995264827948666809233066409497699870112003149352380375124855230068487109373226251983", "1814159566819970307982681716822107016038920170504391457462563485198126916735167260215619523429714031", "5371393606024775251256550436773565977406724269152942136415762782810562554131599074907426010737503501", "6513516734600035718300327211250928237178281758494417357560086828416863929270451437126021949850746381", "5628290459057877291809182450381238927697314822133923421169378062922140081498734424133112032854812293", "2908511952812557872434704820397229928450530253990158990550731991011846571635621025786879881561814989", "2193992993218604310884461864618001945131790925282531768679169054389241527895222169476723691605898517", "5202642720986189087034837832337828472969800910926501361967872059486045713145450116712488685004691423", "7212610147295474909544523785043492409969382148186765460082500085393519556525921455588705423020751421"};
            for (int i = 0; i < saTestPrimes.Length; i++) {
                Debug.WriteLine(i + ": " + saTestPrimes[i]);
                b = BigInteger.Parse(saTestPrimes[i]);
                Assert.IsTrue(mr.IsPrime(b));
                Assert.IsFalse(mr.IsComposite(b));

                Assert.IsFalse(mr.IsPrime(b + 1));
                Assert.IsTrue(mr.IsComposite(b+1));
            }
            string[] saTestPseudoPrimes = new string[] { "2047", "1373653", "25326001", "3215031751", "2152302898747", "3474749660383", "341550071728321", "341550071728321"};//, "3825123056546413051", "3825123056546413051", "3825123056546413051" };
            for (int i = 0; i < saTestPseudoPrimes.Length - 1; i++) {
                b = BigInteger.Parse(saTestPseudoPrimes[i]);
                Assert.IsTrue(mr.IsComposite(b));
            }
        }
        [TestMethod]
        public void TestBailliePSW() {
            IPrimalityTest p = new BailliePSW();
            TestAnInterface(p);
        }
        public void TestAnInterface(IPrimalityTest p) {
            for (int i = 0; i <= liPrimes[liPrimes.Count - 1]; i++) {
                Assert.AreEqual(liPrimes.Contains(i), p.IsPrime(i));
            }
        }
        [TestMethod]
        public void QuickJacobiTest() {
            Assert.AreEqual(1, BailliePSW.JacobiSymbol(-1, 1));
            Assert.AreEqual(1, BailliePSW.JacobiSymbol(1, 3));
            Assert.AreEqual(-1, BailliePSW.JacobiSymbol(-1, 7));
            Assert.AreEqual(-1, BailliePSW.JacobiSymbol(8, 11));
        }
        [TestMethod]
        public void TestJacobiSymbol() {
            List<long> liModuli = new List<long>(new long[] { 1, 3, 5, 7, 9, 11 });
            for (long D = -1; D < 10; D++) {
                foreach (long lModulus in liModuli) {
                    Assert.AreEqual(BailliePSW.JacobiSymbol(D, lModulus), JacobiQuick(D, lModulus));
                }
            }
        }
        public short JacobiQuick(long lD, long lModulus) {
            short[][] laaJacobi = {
                                     new short[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},//Modulus = 1, Jacobi Symbol always = 1
                                     new short[] {-1, 0, 1, -1, 0, 1, -1, 0, 1, -1, 0, 1},//Modulus = 3, D varies
                                     new short[] {1, 0, 1, -1, -1, 1, 0, 1, -1, -1, 1, 0},//Modulus = 5, D varies
                                     new short[] {-1, 0, 1, 1, -1, 1, -1, -1, 0, 1, 1, -1},//Modulus = 7, D varies
                                     new short[] {1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1}, //Modulus = 9
                                     new short[] {-1, 0, 1, -1, 1, 1, 1, -1, -1, -1, 1, -1}, //Modulus = 11
                                 };
            return laaJacobi[(lModulus - 1) / 2][lD + 1];
        }

        [TestMethod]
        public void TestPowMod() {
            Assert.AreEqual(2L, 2L.ModPow(1L, 1000L));
            Assert.AreEqual(8, 2L.ModPow(3, 1000));
            Assert.AreEqual(2, 2L.ModPow(3, 6));
            Assert.AreEqual(1, 9L.ModPow(2, 80));
        }
        public void BigInterfaceTest(IPrimalityTest p) {
            for (int i = 0; i <= pg.largestPrime(); i++) {
                Assert.AreEqual(pg.IsPrime(i), p.IsPrime(i));
            }
        }
        [TestMethod]
        public void TestFindRoot() {
            int[] iaTestValues = new int[] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10 };
            for (long i = 1; i < 101; i++) {
                Assert.AreEqual(iaTestValues[i - 1], (long)Math.Sqrt(i));
            }
        }
        [TestMethod]
        public void RootSpeedTest() {
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            long lRoot;
            stopWatch.Start();
            for (long l = 1; l < 10000; l++) {
                lRoot = (long)Math.Sqrt(l);
            }
            ts = stopWatch.Elapsed;
            Debug.WriteLine(String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));
            stopWatch.Restart();
            for (long l = 1; l < 10000; l++) {
                lRoot = (long)Math.Sqrt(l);
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Debug.WriteLine(String.Format("{0:00}:{1:00}.{2:00}s", ts.Minutes, ts.Seconds, ts.Milliseconds / 10));

        }
        [TestMethod]
        public void TestIsSquare() {
            Assert.IsTrue(100L.IsSquare());
            Assert.IsTrue(!101L.IsSquare());
            Assert.IsTrue(400L.IsSquare());
            Assert.IsTrue(!1000L.IsSquare());
        }
    }
}
