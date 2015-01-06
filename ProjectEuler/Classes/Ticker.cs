using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProjectEuler.Classes {
    public class Ticker {
        Stopwatch _stopWatch;
        TimeSpan _ts;
            
        public Ticker() {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }
        public void Tick(string sMsg) {
            _ts = _stopWatch.Elapsed;
            Debug.WriteLine(sMsg + ": " + String.Format("{0:00}:{1:00}.{2:00}s", _ts.Minutes, _ts.Seconds, _ts.Milliseconds / 10));
            _stopWatch.Restart();
        }
    }
}