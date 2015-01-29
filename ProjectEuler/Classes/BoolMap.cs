using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectEuler.Classes {
    public class BoolMap {
        private byte[] _baMap;
        private int _iBitCount;
        private int _iWidth;
        public BoolMap(int iBits) {
            int iByteCount = ((iBits - 1) / 8) + 1;
            _baMap = new byte[iByteCount];
            _iBitCount = iBits;
        }
        public BoolMap(int iWidth, int iHeight) : this(iWidth * iHeight) {
            _iWidth = iWidth;
        }
        public int Length() {
            return _iBitCount;
        }
        public byte[] ToByteArray() {
            return _baMap;
        }
        public bool this[int iIndex] {
            get {
                return Get(iIndex);
            }
            set {
                Set(iIndex, value);
            }
        }
        public bool this[int iX, int iY] {
            get {
                return Get(iY * _iWidth + iX);
            }
            set {
                Set(iY * _iWidth + iX, value);
            }
        }
        public bool Get(int iIndex) {
            return ((_baMap[iIndex / 8] << (iIndex % 8)) & 128) == 128;
        }
        public void Set(int iIndex, bool bValue) {
            if (bValue) Enable(iIndex);
            else Disable(iIndex);
        }
        public void Enable(int iIndex) {
            _baMap[iIndex / 8] |= (byte)(128 >> (iIndex % 8));
        }
        public void Enable(int iX, int iY) {
            Enable(iY * _iWidth + iX);
        }
        public void Disable(int iIndex) {
            _baMap[iIndex / 8] &= (byte)((128 >> (iIndex % 8)) ^ 255);
        }
        public void Disable(int iX, int iY) {
            Disable(iY * _iWidth + iX);
        }
        public void Flip(int iIndex) {
            _baMap[iIndex / 8] ^= (byte)(128 >> (iIndex % 8));
        }
        public void Flip(int iX, int iY) {
            Flip(iY * _iWidth + iX);
        }
        public override string ToString() {
            StringBuilder sbOut = new StringBuilder("0x");
            sbOut.Append(ByteArrayToString(_baMap));
            sbOut.Append(" b");
            for (int i = _baMap.Length * 8 - 1; i >= 0; i--) {
                if (Get(i)) {
                    sbOut.Append("1");
                } else {
                    sbOut.Append("0");
                }
                if (i % 8 == 0) sbOut.Append(" ");
            }
            return sbOut.ToString();
        }
        public static string ByteArrayToString(byte[] ba) {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}