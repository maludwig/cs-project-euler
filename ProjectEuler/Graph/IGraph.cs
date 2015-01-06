using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Graph {
    public interface IGraph<T> {
        bool AreConnected(T NodeA, T NodeB);
        void Connect(T NodeA, T NodeB);
        bool Disconnect(T Node);
        bool Disconnect(T NodeA, T NodeB);
        IEnumerable<T> ConnectionsFrom(T Node);
        int ConnectionCount(T Node);
        void Add(T Node);
        bool Remove(T Node);
        bool Exists(T Node);
        int Count();
    }
}
