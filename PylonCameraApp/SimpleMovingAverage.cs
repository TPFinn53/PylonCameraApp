using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PylonCameraApp
{
    public class SimpleMovingAverage
    {
        private readonly int _k;
        private readonly int[] _values;

        private int _index = 0;
        private int _sum = 0;

        public int Index { get { return _index; } }
        public double Average { set; get; }
        public void Clear()
        {
            _index = 0;
            _sum = 0;

        }
        public SimpleMovingAverage(int k)
        {
            if (k <= 0) throw new ArgumentOutOfRangeException(nameof(k), "Must be greater than 0");

            _k = k;
            _values = new int[k];
        }

        public double Update(int nextInput)
        {
            // calculate the new sum
            _sum = _sum - _values[_index] + nextInput;

            // overwrite the old value with the new one
            _values[_index] = nextInput;

            // increment the index (wrapping back to 0)
            _index = (_index + 1) % _k;

            // calculate the average
            Average = ((double)_sum) / _k;
            return Average;
        }
    }
}
