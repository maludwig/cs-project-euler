using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.CardGames {
    public struct Card : IComparable, IComparable<Card>, IEquatable<Card> {
        public const int ACE = 14;
        public const int JACK = 11;
        public const int QUEEN = 12;
        public const int KING = 13;
        public static Card NULL = new Card(0, Suits.CLUBS);
        public static List<char> VALUEMAP = new List<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' });

        private int _iValue;
        private Suits _stSuit;
        public Card(int iValue, Suits stSuit) {
            this._iValue = iValue;
            this._stSuit = stSuit;
        }
        public Card(string s) {
            char[] ca = s.ToCharArray();
            if (s.Length != 2) throw new Exception("Bad Card Format: " + s);
            _iValue = GetValue(ca[0]);
            _stSuit = GetSuit(ca[1]);
        }
        public Suits GetSuit() {
            return _stSuit;
        }
        public int GetValue() {
            return _iValue;
        }
        public char GetValueChar() {
            return GetValueChar(_iValue);
        }
        public char GetSuitChar() {
            return GetSuitChar(_stSuit);
        }
        public override string ToString() {
            return new string(new char[] { GetValueChar(), GetSuitChar() });
        }

        //Card comparisons
        public static bool operator ==(Card left, Card right) {
            return left.CompareTo(right) == 0;
        }
        public static bool operator !=(Card left, Card right) {
            return left.CompareTo(right) != 0;
        }
        public static bool operator <(Card left, Card right) {
            return left.CompareTo(right) < 0;
        }
        public static bool operator >(Card left, Card right) {
            return left.CompareTo(right) > 0;
        }
        public static bool operator <=(Card left, Card right) {
            return left.CompareTo(right) <= 0;
        }
        public static bool operator >=(Card left, Card right) {
            return left.CompareTo(right) >= 0;
        }

        //int comparisons
        public static bool operator ==(Card left, int right) {
            return left.CompareTo(right) == 0;
        }
        public static bool operator !=(Card left, int right) {
            return left.CompareTo(right) != 0;
        }
        public static bool operator <(Card left, int right) {
            return left.CompareTo(right) < 0;
        }
        public static bool operator >(Card left, int right) {
            return left.CompareTo(right) > 0;
        }
        public static bool operator <=(Card left, int right) {
            return left.CompareTo(right) <= 0;
        }
        public static bool operator >=(Card left, int right) {
            return left.CompareTo(right) >= 0;
        }

        public int CompareTo(int i) {
            return _iValue.CompareTo(i);
        }
        public int CompareTo(Card c) {
            return _iValue.CompareTo(c.GetValue());
        }
        int IComparable.CompareTo(Object c) {
            return _iValue.CompareTo(((Card)c).GetValue());
        }
        int IComparable<Card>.CompareTo(Card c) {
            return _iValue.CompareTo(c.GetValue());
        }
        public bool Equals(Card c) {
            return _iValue == c.GetValue() && _stSuit == c.GetSuit();
        }
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            return obj is Card && Equals((Card)obj);
        }
        public override int GetHashCode() {
            return _iValue + (int)_stSuit;
        }


        public static implicit operator Card(string s) {
            if (s == null) return (Card)null;
            return new Card(s);
        }
        public static implicit operator int(Card c) {
            return c.GetValue();
        }
        public static int GetValue(char c) {
            int iVal = VALUEMAP.IndexOf(c);
            if (iVal >= 2 && iVal <= ACE) return iVal;
            throw new Exception("Bad Value Format" + c);
        }
        public static char GetValueChar(int iVal) {
            return VALUEMAP[iVal];
        }
        public static Suits GetSuit(char c) {
            if (c == 'S') return Suits.SPADES;
            else if (c == 'C') return Suits.CLUBS;
            else if (c == 'D') return Suits.DIAMONDS;
            else if (c == 'H') return Suits.HEARTS;
            throw new Exception("Bad Suit Format: " + c);
        }
        public static char GetSuitChar(Suits s) {
            if (s == Suits.SPADES) return 'S';
            if (s == Suits.CLUBS) return 'C';
            if (s == Suits.DIAMONDS) return 'D';
            else return 'H';
        }
    }
}