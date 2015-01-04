using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using ProjectEuler.Extensions;

namespace ProjectEuler.Encryption {
    public class XORTransform :ICryptoTransform {
        byte[] Key {get;set;}
        public bool CanReuseTransform { get; protected set; }
        public bool CanTransformMultipleBlocks { get; protected set; }
        public int InputBlockSize { get; protected set; }
        public int OutputBlockSize { get; protected set; }

        public XORTransform(byte[] baKey) {
            Key = baKey;
        }
        public void Dispose() {
            Key = null;
        }
        public int TransformBlock(byte[] baInput, int iInputOffset, int iInputCount, byte[] baOutput, int iOutputOffset) {
            int iInputEnd = Math.Min(iInputOffset + iInputCount, baInput.Length);
            int iKeyIndex = 0;
            for (int i = iInputOffset; i < iInputEnd; i++) {
                baOutput[iOutputOffset] = (byte)(baInput[i] ^ Key[iKeyIndex]);
                iKeyIndex++;
                iOutputOffset++;
            }
            return iInputEnd - iInputOffset;
        }
        public byte[] TransformFinalBlock(byte[] baInput, int iInputOffset, int iInputCount) {
            int iInputEnd = Math.Min(iInputOffset + iInputCount, baInput.Length);
            int iLength = iInputEnd - iInputOffset;
            byte[] baBuffer = new byte[iLength];
            TransformBlock(baInput, iInputOffset, iInputCount, baBuffer, 0);
            return baBuffer;
        }
    }
}