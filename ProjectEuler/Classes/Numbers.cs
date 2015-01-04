using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace ProjectEuler.Classes {
    public class Numbers {
        static int[] _iaColChainLengths = new int[100000]; //First 100 000 chain lengths memoizer (0.4MB in RAM)
        //Performs one step of the Collatz Problem
        public static long CollatzStep(long lNum) {
            if (lNum % 2 == 0) {
                return lNum / 2;
            } else {
                return (3 * lNum) + 1;
            }
        }
        //Returns the length of the Collatz Chain starting at lNum
        public static int CollatzChainLength(long lNum) {
            if (lNum == 1) return 1;
            else if (lNum < _iaColChainLengths.Length) {
                if (_iaColChainLengths[lNum] == 0) _iaColChainLengths[lNum] = CollatzChainLength(CollatzStep(lNum)) + 1;
                return _iaColChainLengths[lNum];
            } else {
                return CollatzChainLength(CollatzStep(lNum)) + 1;
            }
        }


        //Returns true of all of the decimal digits are different (ex. 1234=true, 11=false)
        public static bool AllDigitsDifferent(int i) {
            bool[] b = new bool[10];
            int x;
            while (i > 0) {
                x = i % 10;
                if (b[x]) return false;
                b[x] = true;
                i = i / 10;
            }
            return true;
        }
        //Returns true of all of the decimal digits are different (ex. 1234=true, 11=false)
        public static bool AllDigitsDifferent(int z, int y) {
            bool[] b = new bool[10];
            int x;
            if (z == 0) b[0] = true;
            if (y == 0) {
                if (b[0]) return false;
                b[0] = true;
            }
            while (z > 0) {
                x = z % 10;
                if (b[x]) return false;
                b[x] = true;
                z = z / 10;
            }
            while (y > 0) {
                x = y % 10;
                if (b[x]) return false;
                b[x] = true;
                y = y / 10;
            }
            return true;
        }
        //Returns true of all of the decimal digits are different (ex. 1234=true, 11=false)
        public static bool AllDigitsDifferent(int z, int y, int k) {
            bool[] b = new bool[10];
            int x;
            if (z == 0) b[0] = true;
            if (y == 0) {
                if (b[0]) return false;
                b[0] = true;
            }
            if (k == 0) {
                if (b[0]) return false;
                b[0] = true;
            }
            while (z > 0) {
                x = z % 10;
                if (b[x]) return false;
                b[x] = true;
                z = z / 10;
            }
            while (y > 0) {
                x = y % 10;
                if (b[x]) return false;
                b[x] = true;
                y = y / 10;
            }
            while (k > 0) {
                x = k % 10;
                if (b[x]) return false;
                b[x] = true;
                k = k / 10;
            }
            return true;
        }

        public static bool IsPandigital(int i, int iTo, bool includeZero = false) {
            bool[] b = new bool[10];
            int x;
            while (i > 0) {
                x = i % 10;
                if (b[x]) return false;
                b[x] = true;
                i = i / 10;
            }
            for (x = 1; x <= iTo; x++) {
                if (!b[x]) return false;
            }
            for (x = iTo + 1; x < 10; x++) {
                if (b[x]) return false;
            }
            return b[0] == includeZero;
        }
        public static bool Pandigital1To9(int v, int y, int z) {
            bool[] b = new bool[10];
            int iRem;
            if (v == 0 || y == 0 || z == 0) return false;
            while (v > 0) {
                iRem = v % 10;
                if (b[iRem]) return false;
                b[iRem] = true;
                v = v / 10;
            }
            while (y > 0) {
                iRem = y % 10;
                if (b[iRem]) return false;
                b[iRem] = true;
                y = y / 10;
            }
            while (z > 0) {
                iRem = z % 10;
                if (b[iRem]) return false;
                b[iRem] = true;
                z = z / 10;
            }
            for (iRem = 1; iRem <= 9; iRem++) {
                if (!b[iRem]) return false;
            }
            return !b[0];
        }
        public static bool Pandigital1To9(int v) {
            bool[] b = new bool[10];
            int iRem;
            if (v == 0) return false;
            while (v > 0) {
                iRem = v % 10;
                if (b[iRem]) return false;
                b[iRem] = true;
                v = v / 10;
            }
            for (iRem = 1; iRem <= 9; iRem++) {
                if (!b[iRem]) return false;
            }
            return !b[0];
        }

        //Triangle quadratic is 1n^2+1n-(lTriangle * 2)=0
        //a = 1, b = 1, c = -lTriangle * 2
        public static long GetTriangle(int i) {
            return i * (i + 1) / 2;
        }
        public static int GetTriangleIndex(long lTri) {
            long lTop = 1 + (4 * lTri * 2);       //b^2-4ac
            lTop = -1 + (long)Math.Sqrt(lTop);    //-b + sqrt(lTop)
            return (int)(lTop / 2);               //lTop / 2a
        }
        public static bool IsTriangle(long lTri) {
            double lTop = 1 + (4 * lTri * 2);     //b^2-4ac
            lTop = -1 + Math.Sqrt(lTop);          //-b + sqrt(lTop)
            lTop /= 2;                            //lTop / 2a
            return lTop == Math.Floor(lTop);      
        }

        //Pentagonal quadratic is 3n^2-n-(lPenta * 2)=0
        //a = 3, b = -1, c = -lPenta * 2
        public static long GetPentagonal(int i) {
            return i * (3 * i - 1) / 2;
        }
        public static int GetPentagonalIndex(long lPenta) {
            long lTop = 1 + (4 * 3 * lPenta * 2);     //b^2-4ac
            lTop = 1 + (long)Math.Sqrt(lTop);         //-b + sqrt(lTop)
            return (int)(lTop / 6);                   //lTop / 2a
        }
        public static bool IsPentagonal(long lPenta) {
            double lTop = 1 + (4 * 3 * lPenta * 2);   //b^2-4ac
            lTop = (1 + Math.Sqrt(lTop)) / 6;         //-b + sqrt(lTop)
            return lTop == Math.Floor(lTop);          //lTop / 2a
        }


        //Hexagonal quadratic is 2n^2-n-lHexa=0
        //a = 2, b = -1, c = -lHexa
        public static long GetHexagonal(int i) {
            return i * (2 * i - 1);
        }
        public static int GetHexagonalIndex(long lHexa) {
            long lTop = 1 + (4 * 2 * lHexa);        //b^2-4ac
            lTop = 1 + (long)Math.Sqrt(lTop);       //-b + sqrt(lTop)
            return (int)(lTop / 4);                 //lTop / 2a
        }
        public static bool IsHexagonal(long lHexa) {
            double lTop = 1 + (4 * 2 * lHexa);        //b^2-4ac
            lTop = (1 + Math.Sqrt(lTop)) / 4;   //-b + sqrt(lTop)
            return lTop == Math.Floor(lTop);          //lTop / 2a
        }
    }
}