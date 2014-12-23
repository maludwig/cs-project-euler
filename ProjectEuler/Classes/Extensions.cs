using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public static class Extensions {
        /// <summary>
        /// Get the array slice between the two indexes.
        /// ... Inclusive for start index, exclusive for end index.
        /// </summary>
        public static T[] Slice<T>(this T[] source, int start, int end) {
            // Handles negative ends.
            if (end < 0) {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++) {
                res[i] = source[i + start];
            }
            return res;
        }
        /// <summary>
        /// Compare two enumerable objects to see if each item is equal
        /// </summary>
        public static bool EachItemEqual<T>(IEnumerable<T> list1, IEnumerable<T> list2) {
            if (list1.Count() != list2.Count()) return false;
            IEnumerator<T> enum1 = list1.GetEnumerator();
            IEnumerator<T> enum2 = list2.GetEnumerator();
            while (enum1.MoveNext()) {
                enum2.MoveNext();
                if (!enum1.Current.Equals(enum2.Current)) return false;
            }
            return true;
        }
    }
}