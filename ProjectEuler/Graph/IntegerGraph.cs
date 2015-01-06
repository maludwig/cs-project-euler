using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjectEuler.Graph {
    public class IntegerGraph : IGraph<int>, IEnumerable<int>, ICloneable {
        private Dictionary<int, HashSet<int>> _dihiConnections;
        public IntegerGraph() {
            _dihiConnections = new Dictionary<int, HashSet<int>>();
        }
        public IntegerGraph(Dictionary<int, HashSet<int>> Data) {
            HashSet<int> hi;
            _dihiConnections = new Dictionary<int, HashSet<int>>();
            foreach (KeyValuePair<int, HashSet<int>> kvp in Data) {
                hi = new HashSet<int>();
                foreach (int iConnectedNode in kvp.Value) {
                    hi.Add(iConnectedNode);
                }
                _dihiConnections.Add(kvp.Key, hi);
            }
        }
        public void Add(int iNode) {
            if (!Exists(iNode)) {
                _dihiConnections.Add(iNode, new HashSet<int>());
            }
        }
        public bool AreConnected(int iNodeA, int iNodeB) {
            if (_dihiConnections.ContainsKey(iNodeA)) return _dihiConnections[iNodeA].Contains(iNodeB);
            return false;
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
        public bool Remove(int iNode) {
            if (!Exists(iNode)) return false;
            foreach (int iConnectedNode in ConnectionsFrom(iNode)) {
                DisconnectAFromB(iConnectedNode, iNode);
            }
            _dihiConnections.Remove(iNode);
            return true;
        }
        public bool Exists(int iNode) {
            return _dihiConnections.ContainsKey(iNode);
        }
        //Returns true if a connection was severed from the node
        public bool Disconnect(int iNode) {
            bool bRet = false;
            if (!Exists(iNode)) return false;
            foreach (int iConnectedNode in ConnectionsFrom(iNode)) {
                bRet |= DisconnectAFromB(iConnectedNode, iNode);
            }
            _dihiConnections[iNode] = new HashSet<int>();
            return bRet;
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
        public IEnumerable<int> ConnectionsFrom(int Node) {
            return _dihiConnections[Node];
        }
        public int ConnectionCount(int Node) {
            HashSet<int> hi;
            if(_dihiConnections.TryGetValue(Node,out hi)) {
                return hi.Count;
            }
            return 0;
        }
        public int Count() {
            return _dihiConnections.Count;
        }
        public object Clone() {
            return new IntegerGraph(_dihiConnections);
        }
        public void PruneWeak(int iRequiredConnections) {
            List<int> liRemovable = new List<int>();
            foreach (int iNode in this) {
                if (ConnectionCount(iNode) < iRequiredConnections) liRemovable.Add(iNode);
            }
            foreach (int iNode in liRemovable) {
                Remove(iNode);
            }
            if (liRemovable.Count > 0) PruneWeak(iRequiredConnections);
        }
        public IntegerGraph SubGraphConnectedTo(int iNode) {
            IntegerGraph g = new IntegerGraph();
            HashSet<int> hiDirectConnections;
            if(!Exists(iNode)) return g;
            hiDirectConnections = _dihiConnections[iNode];
            foreach (int iAdjacentNode in hiDirectConnections) {
                g.Connect(iNode, iAdjacentNode);
                foreach (int iPossibleNode in ConnectionsFrom(iAdjacentNode)) {
                    if (hiDirectConnections.Contains(iPossibleNode)) {
                        g.Connect(iAdjacentNode, iPossibleNode);
                    }
                }
            }
            return g;
        }
        public bool MightHaveNClique(int iNode, int iN) {
            HashSet<int> hi = _dihiConnections[iNode];
            IntegerGraph g;
            if (hi.Count < iN - 1) return false;
            g = SubGraphConnectedTo(iNode);
            g.PruneWeak(iN - 1);
            if (g.Count() < iN) return false;
            return true;
        }
        public void PruneCantHaveNClique(int iN) {
            List<int> liRemovable = new List<int>();
            foreach (int iNode in this) {
                if (!MightHaveNClique(iNode,iN)) liRemovable.Add(iNode);
            }
            foreach (int iNode in liRemovable) {
                Remove(iNode);
            }
            if (liRemovable.Count > 0) PruneCantHaveNClique(iN);
        }
        public int HighestDegreeNode() {
            KeyValuePair<int, HashSet<int>> kvpFirst;
            int iMaxNode = 0;
            int iMaxDegree = 0;
            kvpFirst = _dihiConnections.First();
            iMaxNode = kvpFirst.Key;
            iMaxDegree = kvpFirst.Value.Count;
            foreach (KeyValuePair<int, HashSet<int>> kvp in _dihiConnections) {
                if (kvp.Value.Count > iMaxDegree) {
                    iMaxDegree = kvp.Value.Count;
                    iMaxNode = kvp.Key;
                }
            }
            return iMaxNode;
        }
        public IEnumerator<int> GetEnumerator() {
            foreach (int iNodeB in _dihiConnections.Keys) {
                yield return iNodeB;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (int iNode in this) {
                sb.Append("{" + iNode + ":[");
                sb.Append(string.Join(",",ConnectionsFrom(iNode)));
                sb.Append("]},");
            }
            return sb.ToString();
        }
    }
}