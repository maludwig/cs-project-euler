using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.CardGames {
    public class Hand : IEnumerable<Card> {
        protected List<Card> _lcCards = new List<Card>();
        public Hand() {
            _lcCards = new List<Card>();
        }
        public Hand(List<Card> lcCards) {
            _lcCards = new List<Card>(lcCards);
            _lcCards.Sort();
        }
        public Hand(Card[] caCards) {
            _lcCards.AddRange(caCards);
            _lcCards.Sort();
        }
        public Hand(string sCards) {
            string[] saCards = sCards.Split(' ');
            _lcCards = new List<Card>();
            for (int i = 0; i < saCards.Length; i++) {
                _lcCards.Add(new Card(saCards[i]));
            }
            _lcCards.Sort();
        }
        public List<Card> GetCards() {
            return _lcCards;
        }
        public void Add(Card c) {
            _lcCards.Add(c);
            _lcCards.Sort();
        }
        public bool Remove(Card c) {
            return _lcCards.Remove(c);
        }
        public bool Contains(Card c) {
            return _lcCards.Contains(c);
        }
        public bool ContainsCardWithValue(int iVal) {
            foreach (Card c in _lcCards) {
                if (c.GetValue() == iVal) return true;
            }
            return false;
        }
        public bool ContainsCardWithSuit(Suits s) {
            foreach (Card c in _lcCards) {
                if (c.GetSuit() == s) return true;
            }
            return false;
        }
        public int CountCardsWithValue(int iVal) {
            int iCount = 0;
            foreach (Card c in _lcCards) {
                if (c.GetValue() == iVal) iCount++;
            }
            return iCount;
        }
        public int CountCardsWithSuit(Suits s) {
            int iCount = 0;
            foreach (Card c in _lcCards) {
                if (c.GetSuit() == s) iCount++;
            }
            return iCount;
        }
        public bool AllSameSuit() {
            Suits s;
            if (_lcCards.Count == 0) return true;
            s = _lcCards[0].GetSuit();
            for (int i = 1; i < _lcCards.Count; i++) {
                if (s != _lcCards[i].GetSuit()) return false;
            }
            return true;
        }
        public Card HighestCard() {
            return _lcCards[_lcCards.Count - 1];
        }

        public override string ToString() {
            return string.Join(" ", this);
        }
        public IEnumerator<Card> GetEnumerator() {
            return _lcCards.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return _lcCards.GetEnumerator();
        }
    }
}