using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class SquareSpiral {
        public static int[] GetCorners(int iLayer) {
            int[] iaRet = new int[4];
            int iSideLen = (iLayer * 2) + 1;
            iaRet[0] = iSideLen * iSideLen;
            iaRet[1] = iaRet[0] + iSideLen - 1;
            iaRet[2] = iaRet[1] + iSideLen - 1;
            iaRet[3] = iaRet[2] + iSideLen - 1;
            return iaRet;
        }
    }
}