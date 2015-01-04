using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.CardGames;

namespace ProjectEuler.Tests.Cards {
    [TestClass]
    public class PokerTest {
        [TestMethod]
        public void PokerHandConstructorTest() {
            PokerHand h = new PokerHand("AS KS QS JS TS");
            Assert.AreEqual("TS JS QS KS AS", h.ToString());
            Assert.IsTrue(h.IsRoyalFlush());
            Assert.IsTrue(h.GetHighCard() == Card.ACE);
            Assert.AreEqual(PokerHand.ROYAL_FLUSH, h.GetRank());

            h = new PokerHand("AS 9S QS JS TS");
            Assert.AreEqual("9S TS JS QS AS", h.ToString());
            Assert.IsTrue(h.GetHighCard() == Card.ACE);
            Assert.AreEqual(PokerHand.FLUSH, h.GetRank());

            h = new PokerHand("5H 5C 6S 7S KD");
            Assert.AreEqual("5H 5C 6S 7S KD", h.ToString());
            Assert.IsTrue(h.GetHighCard() == 5);
            Assert.AreEqual(PokerHand.PAIR, h.GetRank());

            h = new PokerHand("3D 6D 7D TD QD");
            Assert.AreEqual("3D 6D 7D TD QD", h.ToString());
            Assert.IsTrue(h.GetHighCard() == Card.QUEEN);
            Assert.AreEqual(PokerHand.FLUSH, h.GetRank());
        }
        [TestMethod]
        public void PokerHandComparison() {
            PokerHand p1;
            PokerHand p2;
            p1 = new PokerHand("5H 5C 6S 7S KD");
            p2 = new PokerHand("2C 3S 8S 8D TD");
            P2Wins(p1, p2);

            p1 = new PokerHand("2D 9C AS AH AC");
            p2 = new PokerHand("3D 6D 7D TD QD");
            P2Wins(p1, p2);

            p1 = new PokerHand("5D 8C 9S JS AC");
            p2 = new PokerHand("2C 5C 7D 8S QH");
            P1Wins(p1, p2);

            p1 = new PokerHand("4D 6S 9H QH QC");
            p2 = new PokerHand("3D 6D 7H QD QS");
            P1Wins(p1, p2);

            p1 = new PokerHand("2H 2D 4C 4D 4S");
            p2 = new PokerHand("3C 3D 3S 9S 9D");
            P1Wins(p1, p2);

        }

        public void P1Wins(PokerHand p1, PokerHand p2) {
            Assert.IsTrue(p2 < p1);
            Assert.IsTrue(p2 <= p1);
            Assert.IsTrue(p1 > p2);
            Assert.IsTrue(p1 >= p2);
        }
        public void P2Wins(PokerHand p1, PokerHand p2) {
            Assert.IsTrue(p2 > p1);
            Assert.IsTrue(p2 >= p1);
            Assert.IsTrue(p1 < p2);
            Assert.IsTrue(p1 <= p2);
        }
    }
}
