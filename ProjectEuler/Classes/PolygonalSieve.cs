using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class PolygonalSieve {
        bool[,] _baaIsPoly;
        public PolygonalSieve() : this(10000, 8) { }
        public PolygonalSieve(int iMaxPrecalculation, int iMaxSides) {
            int iVal;
            int iNMul;
            int iNAdd;
            _baaIsPoly = new bool[iMaxPrecalculation, iMaxSides];
            for (int iSides = 3; iSides < iMaxSides; iSides++) {
                if (iSides % 2 == 0) {
                    iNMul = (iSides - 2) / 2;
                    iNAdd = -((iSides - 4) / 2);
                    iVal = iNMul + iNAdd;
                    for (int iN = 1; iVal < iMaxPrecalculation; iN++) {
                        iVal = iN * (iNMul * iN + iNAdd);
                        _baaIsPoly[iVal, iSides] = true;
                    }
                } else {
                    iNMul = iSides - 2;
                    iNAdd = -(iSides - 4);
                    iVal = (iNMul + iNAdd) / 2;
                    for (int iN = 1; iVal < iMaxPrecalculation; iN++) {
                        iVal = (iN * (iNMul * iN + iNAdd)) / 2;
                        _baaIsPoly[iVal, iSides] = true;
                    }
                }
            }
        }
        public bool IsPolygonal(int iNum, int iOrder) {
            return _baaIsPoly[iNum, iOrder];
        }


        //Polygonal quadratic is (s-2)n^2+(4-s)n-(lPoly*2)=0
        public static int GetPoly(int iN, int iSides) {
            int iNMul = iSides - 2;
            int iNAdd = 4 - iSides;
            return (iN * (iNMul * iN + iNAdd)) / 2;
        }
        public static int GetPolyIndex(long lPoly, int iSides) {
            long lA = iSides - 2;
            long lB = 4 - iSides;
            long lC = lPoly * 2;
            long lTop = (lB * lB) + (4 * lA * lC);    //b^2-4ac
            lTop = -lB + (long)Math.Sqrt(lTop);       //-b + sqrt(lTop)
            return (int)(lTop / (2 * lA));            //lTop / 2a
        }
        public static bool IsPoly(long lPoly, int iSides) {
            long lA = iSides - 2;
            long lB = 4 - iSides;
            long lC = lPoly * 2;
            double lTop = (lB * lB) + (4 * lA * lC);    //b^2-4ac
            lTop = -lB + Math.Sqrt(lTop);               //-b + sqrt(lTop)
            lTop /= 2 * lA;                             //lTop / 2a
            return lTop == Math.Floor(lTop);
        }
        public static List<int> GeneratePolysBetween(long lMin, long lMax, int iSides) {
            List<int> llRet = new List<int>();
            int iFirstIndex = GetPolyIndex(lMin, iSides);
            int iLastIndex = GetPolyIndex(lMax, iSides);
            for (int i = iFirstIndex + 1; i <= iLastIndex; i++) {
                llRet.Add(GetPoly(i, iSides));
            }
            return llRet;
        }

        //Triangle quadratic is 1n^2+1n-(lTriangle * 2)=0
        //a = 1, b = 1, c = -lTriangle * 2
        public static int GetTriangle(int i) {
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
        public static int GetPentagonal(int i) {
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
        public static int GetHexagonal(int i) {
            return i * (2 * i - 1);
        }
        public static int GetHexagonalIndex(long lHexa) {
            long lTop = 1 + (4 * 2 * lHexa);        //b^2-4ac
            lTop = 1 + (long)Math.Sqrt(lTop);       //-b + sqrt(lTop)
            return (int)(lTop / 4);                 //lTop / 2a
        }
        public static bool IsHexagonal(long lHexa) {
            double lTop = 1 + (4 * 2 * lHexa);        //b^2-4ac
            lTop = (1 + Math.Sqrt(lTop)) / 4;         //-b + sqrt(lTop)
            return lTop == Math.Floor(lTop);          //lTop / 2a
        }

        //Heptagonal quadratic is 5n^2-3n-(lHepta * 2)=0
        //a = 5, b = -3, c = -lHepta * 2
        public static int GetHeptagonal(int i) {
            return (i * (5 * i - 3)) / 2;
        }
        public static int GetHeptagonalIndex(long lHexa) {
            long lTop = 9 + (4 * 5 * 2 * lHexa);        //b^2-4ac
            lTop = 3 + (long)Math.Sqrt(lTop);           //-b + sqrt(lTop)
            return (int)(lTop / 10);                    //lTop / 2a
        }
        public static bool IsHeptagonal(long lHexa) {
            double lTop = 9 + (4 * 5 * 2 * lHexa);      //b^2-4ac
            lTop = (3 + Math.Sqrt(lTop)) / 10;    //-b + sqrt(lTop)
            return lTop == Math.Floor(lTop);            //lTop / 2a
        }


        //Octagonal quadratic is 3n^2-2n-lHexa=0
        //a = 3, b = -2, c = -lHexa
        public static int GetOctagonal(int i) {
            return i * (3 * i - 2);
        }
        public static int GetOctagonalIndex(long lHexa) {
            long lTop = 4 + (4 * 3 * lHexa);        //b^2-4ac
            lTop = 2 + (long)Math.Sqrt(lTop);       //-b + sqrt(lTop)
            return (int)(lTop / 6);                 //lTop / 2a
        }
        public static bool IsOctagonal(long lHexa) {
            double lTop = 4 + (4 * 3 * lHexa);         //b^2-4ac
            lTop = (2 + Math.Sqrt(lTop)) / 6;    //-b + sqrt(lTop)
            return lTop == Math.Floor(lTop);           //lTop / 2a
        }
    }
}