using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanGoShimmerLog
{
    public class Period : IComparable<Period>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeSpan Duration => End - Start;

        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"from {Start} till {End} with duration of {Duration.ToString(@"dd\.hh\:mm\:ss")} ({Duration.TotalSeconds,6} secs)";
        }

        public int CompareTo(Period? other)
        {
            return Duration.CompareTo(other?.Duration);
        }
    }
}
