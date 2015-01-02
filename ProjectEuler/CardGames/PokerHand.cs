using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjectEuler.CardGames {
    public class PokerHand : Hand, IComparable, IComparable<PokerHand> {
        public const int HIGH_CARD = 1;
        public const int PAIR = 2;
        public const int TWO_PAIR = 3;
        public const int THREE_OF_A_KIND = 4;
        public const int STRAIGHT = 5;
        public const int FLUSH = 6;
        public const int FULL_HOUSE = 7;
        public const int FOUR_OF_A_KIND = 8;
        public const int STRAIGHT_FLUSH = 9;
        public const int ROYAL_FLUSH = 10;
        public int _iRank;
        public Card _cHighCard;

        public PokerHand(Hand h) {
            Tuple<int, Card> kic;
            _lcCards = new List<Card>(h.GetCards());
            if (_lcCards.Count != 5) throw new Exception("Poker hand doesn't have 5 cards");
            kic = HighestRankAndCard();
            _iRank = kic.Item1;
            _cHighCard = kic.Item2;
        }
        public PokerHand(Card[] caCards) : this(new Hand(caCards)) { }
        public PokerHand(string sInput) : this(new Hand(sInput)) { }

        public int GetRank() {
            return _iRank;
        }
        public Card GetHighCard() {
            return _cHighCard;
        }

        public bool IsFlush() { return AllSameSuit(); }

        public bool IsRoyalFlush() { return HighestRoyalFlush() != Card.NULL; }
        public bool IsStraightFlush() { return HighestStraightFlush() != Card.NULL; }
        public bool IsFourOfAKind() { return HighestFourOfAKind() != Card.NULL; }
        public bool IsFullHouse() { return HighestFullHouse() != Card.NULL; }
        public bool IsStraight() { return HighestStraight() != Card.NULL; }
        public bool IsThreeOfAKind() { return HighestThreeOfAKind() != Card.NULL; }
        public bool IsTwoPair() { return HighestTwoPair() != Card.NULL; }
        public bool IsPair() { return HighestPair() != Card.NULL; }

        public Card HighestRoyalFlush() {
            Card cStraight = HighestStraight();
            if (cStraight == Card.ACE && IsFlush()) return cStraight;
            return Card.NULL;
        }
        public Card HighestStraightFlush() {
            if (IsFlush()) return HighestStraight();
            return Card.NULL;
        }
        public Card HighestFourOfAKind() {
            if (CountCardsWithValue(_lcCards[0]) == 4) return _lcCards[0];
            if (CountCardsWithValue(_lcCards[1]) == 4) return _lcCards[1];
            return Card.NULL;
        }
        public Card HighestFullHouse() {
            int iCardsMatchingFirst = CountCardsWithValue(_lcCards[0]);
            int iCardsMatchingLast = CountCardsWithValue(_lcCards[4]);
            if (iCardsMatchingFirst == 3 && iCardsMatchingLast == 2) return _lcCards[0];
            if (iCardsMatchingLast == 3 && iCardsMatchingFirst == 2) return _lcCards[4];
            return Card.NULL;
        }
        public Card HighestFlush() {
            if (IsFlush()) return _lcCards[4];
            return Card.NULL;
        }
        public Card HighestStraight() {
            if (_lcCards[0].GetValue() == _lcCards[1].GetValue() - 1) {
                if (_lcCards[1].GetValue() == _lcCards[2].GetValue() - 1) {
                    if (_lcCards[2].GetValue() == _lcCards[3].GetValue() - 1) {
                        if (_lcCards[3].GetValue() == _lcCards[4].GetValue() - 1) {
                            return _lcCards[4];
                        }
                    }
                }
            }
            return Card.NULL;
        }
        public Card HighestThreeOfAKind() {
            if (CountCardsWithValue(_lcCards[2]) == 3) return _lcCards[2];
            return Card.NULL;
        }
        public Card HighestTwoPair() {
            if (CountCardsWithValue(_lcCards[1]) == 2) {
                if (CountCardsWithValue(_lcCards[3]) == 2) return _lcCards[3];
            }
            return Card.NULL;
        }
        public Card HighestPair() {
            if (CountCardsWithValue(_lcCards[3]) == 2) return _lcCards[3];
            if (CountCardsWithValue(_lcCards[1]) == 2) return _lcCards[1];
            return Card.NULL;
        }
        public Tuple<int, Card> HighestRankAndCard() {
            Card c;
            c = HighestRoyalFlush();
            if (c != Card.NULL) {
                return new Tuple<int, Card>(ROYAL_FLUSH, c);
            } else {
                c = HighestStraightFlush();
                if (c != Card.NULL) return new Tuple<int, Card>(STRAIGHT_FLUSH, c);
                else {
                    c = HighestFourOfAKind();
                    if (c != Card.NULL) return new Tuple<int, Card>(FOUR_OF_A_KIND, c);
                    else {
                        c = HighestFullHouse();
                        if (c != Card.NULL) return new Tuple<int, Card>(FULL_HOUSE, c);
                        else {
                            c = HighestFlush();
                            if (c != Card.NULL) return new Tuple<int, Card>(FLUSH, c);
                            else {
                                c = HighestStraight();
                                if (c != Card.NULL) return new Tuple<int, Card>(STRAIGHT, c);
                                else {
                                    c = HighestThreeOfAKind();
                                    if (c != Card.NULL) return new Tuple<int, Card>(THREE_OF_A_KIND, c);
                                    else {
                                        c = HighestTwoPair();
                                        if (c != Card.NULL) return new Tuple<int, Card>(TWO_PAIR, c);
                                        else {
                                            c = HighestPair();
                                            if (c != Card.NULL) return new Tuple<int, Card>(PAIR, c);
                                            else {
                                                c = HighestCard();
                                                return new Tuple<int, Card>(HIGH_CARD, c);
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

        //PokerHand comparisons
        public static bool operator ==(PokerHand left, PokerHand right) {
            return left.GetRank() == right.GetRank() && left.GetHighCard() == right.GetHighCard();
        }
        public static bool operator !=(PokerHand left, PokerHand right) {
            return left.GetRank() != right.GetRank() || left.GetHighCard() != right.GetHighCard();
        }
        public static bool operator <(PokerHand left, PokerHand right) {
            return left.CompareTo(right) < 0;
        }
        public static bool operator >(PokerHand left, PokerHand right) {
            return left.CompareTo(right) > 0;
        }
        public static bool operator <=(PokerHand left, PokerHand right) {
            return left.CompareTo(right) <= 0;
        }
        public static bool operator >=(PokerHand left, PokerHand right) {
            return left.CompareTo(right) >= 0;
        }

        public int CompareTo(Object h) {
            return CompareTo((PokerHand)h);
        }
        public int CompareTo(PokerHand h) {
            if (_iRank > h.GetRank()) return 1;
            if (_iRank < h.GetRank()) return -1;
            if (_cHighCard == h.GetHighCard()) {
                for (int i = _cHighCard; i >= 2; i--) {
                    if (ContainsCardWithValue(i)) {
                        if (!h.ContainsCardWithValue(i)) {
                            return 1;
                        }
                    } else {
                        if (h.ContainsCardWithValue(i)) {
                            return -1;
                        }
                    }
                }
            }
            return _cHighCard > h.GetHighCard() ? 1 : -1;
        }
    }
}