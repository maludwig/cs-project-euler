using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.CardGames;
using System.Collections.Generic;

namespace ProjectEuler.Tests.Cards {
    [TestClass]
    public class CardTest {
        [TestMethod]
        public void CardTesting() {
            Card c = "QS";
            Card cAceHearts = new Card(Card.ACE, Suits.HEARTS);
            Card[] ca = new Card[] { "7C", "2D", "AH" };

            Assert.AreEqual("AH", cAceHearts.ToString());
            Assert.AreEqual(Suits.HEARTS, cAceHearts.GetSuit());
            Assert.AreEqual(Card.ACE, cAceHearts.GetValue());

            Assert.AreEqual("QS", c.ToString());
            Assert.AreEqual(Suits.SPADES, c.GetSuit());
            Assert.AreEqual(Card.QUEEN, c.GetValue());

            Assert.AreEqual("7C", ca[0].ToString());
            Assert.AreEqual(Suits.CLUBS, ca[0].GetSuit());
            Assert.AreEqual(7, ca[0].GetValue());

            Assert.AreEqual("2D", ca[1].ToString());
            Assert.AreEqual(Suits.DIAMONDS, ca[1].GetSuit());
            Assert.AreEqual(2, ca[1].GetValue());

            Assert.AreEqual("AH", ca[2].ToString());
            Assert.AreEqual(Suits.HEARTS, ca[2].GetSuit());
            Assert.AreEqual(Card.ACE, ca[2].GetValue());

            Assert.IsTrue(c > ca[0]);
            Assert.IsTrue(c > ca[1]);
            Assert.IsFalse(c > ca[2]);

            Assert.IsTrue(c >= ca[0]);
            Assert.IsTrue(c >= ca[1]);
            Assert.IsFalse(c >= ca[2]);

            Assert.IsTrue(cAceHearts == ca[2]);
            Assert.IsFalse(cAceHearts == ca[1]);
            Assert.IsFalse(cAceHearts == ca[0]);

            List<Card> lc = new List<Card> { "AH", "7S", "5C", "5S", "4S", "3S", "5S", "2H", "KD" };
            lc.Sort();
            Assert.AreEqual("2H 3S 4S 5C 5S 5S 7S KD AH", string.Join(" ", lc));
            foreach (Card c1 in lc) {
                foreach (Card c2 in lc) {
                    Assert.AreEqual(c1 < c2, c2 > c1);
                    Assert.AreEqual(c1.Equals(c2), c2.Equals(c1));
                    Assert.AreEqual(c1 <= c2, c2 >= c1);
                    Assert.AreNotEqual(c1 == c2, c1 != c2);
                    if (c1.Equals(c2)) {
                        Assert.AreEqual(c1.ToString(), c2.ToString());
                    }
                }
            }
        }

        [TestMethod]
        public void HandTesting() {
            Hand h = new Hand();
            h.Add("AH");
            h.Add("QS");
            Assert.AreEqual("QS AH", h.ToString());
            h.Add(new Card(Card.JACK, Suits.DIAMONDS));
            Assert.AreEqual("JD QS AH", h.ToString());
            h.Add(new Card(3, Suits.DIAMONDS));
            Assert.AreEqual("3D JD QS AH", h.ToString());
            h.Add(new Card(6, Suits.DIAMONDS));
            Assert.AreEqual("3D 6D JD QS AH", h.ToString());
            h.Add(new Card(6, Suits.DIAMONDS));
            Assert.AreEqual("3D 6D 6D JD QS AH", h.ToString());
        }
    }
}
