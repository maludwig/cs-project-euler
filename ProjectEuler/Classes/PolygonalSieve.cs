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
                        _baaIsPoly[iVal ,iSides] = true;
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