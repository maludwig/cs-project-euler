using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class Graph {
        private Dictionary<int, HashSet<int>> _dihiConnections;
        public Graph() {
            _dihiConnections = new Dictionary<int, HashSet<int>>();
        }
        public void Connect(int iNodeA, int iNodeB) {
            ConnectAToB(iNodeA,iNodeB);
            ConnectAToB(iNodeB,iNodeA);
        }
        private void ConnectAToB(int iNodeA, int iNodeB) {
            if(_dihiConnections.ContainsKey(iNodeA)) {
                _dihiConnections[iNodeA].Add(iNodeB);
            } else {
                _dihiConnections.Add(iNodeA,new HashSet<int>{iNodeB});
            }
        }
        public bool AreConnected(int iNodeA, int iNodeB) {
            if (_dihiConnections.ContainsKey(iNodeA)) return _dihiConnections[iNodeA].Contains(iNodeB);
            return false;
        }
        public bool Disconnect(int iNodeA, int iNodeB) {
            DisconnectAFromB(iNodeA, iNodeB);
            return DisconnectAFromB(iNodeB, iNodeA);
        }
        private bool DisconnectAFromB(int iNodeA, int iNodeB) {
            if (_dihiConnections.ContainsKey(iNodeA)) {
                return _dihiConnections[iNodeA].Remove(iNodeB);
            }
            return false;
        }
        public void PruneWeak(int iRequiredConnections) {
            List<int> liRemovable = new List<int>();
            foreach (KeyValuePair<int, HashSet<int>> kvp in _dihiConnections) {
                if (kvp.Value.Count < iRequiredConnections) liRemovable.Add(kvp.Key);
            }
            foreach (int iNode in liRemovable) {
                foreach (int iNodeB in _dihiConnections[iNode]) {
                    _dihiConnections[iNodeB].Remove(iNode);
                }
                _dihiConnections.Remove(iNode);
            }
            if (liRemovable.Count > 0) PruneWeak(iRequiredConnections);
        }
    }
}