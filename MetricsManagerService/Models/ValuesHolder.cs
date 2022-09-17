using System;
using System.Collections.Generic;

namespace MetricsManagerService.Models
{
    public class ValuesHolder
    {
        private List<TimeSpan> _valuesTime;

        private List<int> _valuesTemp;

        public ValuesHolder()
        {
            _valuesTime = new List<TimeSpan>();
            _valuesTemp = new List<int>();
        }

        public void Add(TimeSpan newValueTime, int newValueTemp)
        {
            _valuesTime.Add(newValueTime);
            _valuesTemp.Add(newValueTemp);
        }

        public string Get()
        {
            string buf = string.Empty;
            for (int i = 0; i < _valuesTime.Count; i++)
            {
                buf += $"{_valuesTime[i]}\tТемпература({_valuesTemp[i]}℃)\n";
            }

            return buf;
        }

        public List<TimeSpan> ValuesTime
        {
            get { return _valuesTime; }
            set { _valuesTime = value; }
        }

        public List<int> ValuesTemp
        {
            get { return _valuesTemp; }
            set { _valuesTemp = value; }
        }
    }
}
