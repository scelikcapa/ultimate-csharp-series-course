using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpIntermediate.Exercises
{
    public class Stopwatch
    {
        private bool _working;
        private readonly List<DateTime> _timeList;

        public DateTime LastStartTime
        {
            get { return _timeList[_timeList.Count-2]; }
        }

        public DateTime LastStopTime
        {
            get{ return _timeList.Last(); }
        }
        public TimeSpan LastDurationTotal
        {
            get { return LastStopTime - LastStartTime; }
        }

        public Stopwatch()
        {
            this._timeList = new List<DateTime>();
        }

        public void Start()
        {
            try
            {
                if (_working==false)
                {
                    this._working = true;
                    _timeList.Add(DateTime.Now);
                }
                else
                {
                    throw new InvalidOperationException("Stopwatch already working");
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void Stop()
        {
            this._working = false;
            _timeList.Add(DateTime.Now);
        }
        
    }
}