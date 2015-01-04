using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class SquareSpiral {
        public static int[] GetCorners(int iLayer) {
            int[] iaRet = new int[4];
            int iSideLen = (iLayer * 2) + 1;
            int iStep = iSideLen - 1;
            iaRet[0] = iSideLen * iSideLen;
            iaRet[1] = iaRet[0] - iStep;
            iaRet[2] = iaRet[1] - iStep;
            iaRet[3] = iaRet[2] - iStep;
            return iaRet;
        }
    }
}