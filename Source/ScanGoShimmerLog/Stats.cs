using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanGoShimmerLog
{
    public class Stats
    {
        public long PeriodsIncluded { get; set; }
        public long PeriodsNotIncluded { get; set; }
        public long? Min { get; set; }
        public long? Max { get; set; }
        public double? Average { get; set; }
        public double? Median { get; set; }

        public Stats(long periodsIncluded, long periodsNotIncluded, long? min, long? max, double? average, double? median)
        {
            PeriodsIncluded = periodsIncluded;
            PeriodsNotIncluded = periodsNotIncluded;
            Min = min;
            Max = max;
            Average = average;
            Median = median;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"PeriodsIncluded: {PeriodsIncluded}");
            sb.AppendLine($"PeriodsNotIncluded: {PeriodsNotIncluded}");
            sb.AppendLine($"Minimum: {TimeSpan.FromSeconds((int)Min)} ({Min,6} secs)");
            sb.AppendLine($"Maximum: {TimeSpan.FromSeconds((int)Max)} ({Max,6} secs)");
            sb.AppendLine($"Average: {TimeSpan.FromSeconds((int)Average)} ({Math.Round((decimal)Average,0),6} secs)");
            sb.AppendLine($"Median : {TimeSpan.FromSeconds((int)Median)} ({Math.Round((decimal)Median),6} secs)");

            return sb.ToString();
        }
    }
}
