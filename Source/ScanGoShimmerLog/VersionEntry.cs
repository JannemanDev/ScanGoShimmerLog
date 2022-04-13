using ScanGoShimmerLog.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanGoShimmerLog
{
    public class VersionEntry
    {
        public int StartLineIndex { get; set; }
        public int EndLineIndex { get; set; }
        public string Version { get; set; }
        public Period Period { get; set; }
        public List<Period> UnsyncPeriods { get; set; } = new List<Period>();

        public VersionEntry(int startLineIndex, int endLineIndex, string version, Period period)
        {
            StartLineIndex = startLineIndex;
            EndLineIndex = endLineIndex;
            Version = version;
            Period = period;

        }

        public Stats CalcStats(TimeSpan minDuration)
        {
            List<Period> periods = UnsyncPeriods.Where(us => us.Duration >= minDuration).ToList();

            return new Stats(
                periods.Count, UnsyncPeriods.Count - periods.Count,
                periods.MinOrDefault(us => (long)Math.Round(us.Duration.TotalSeconds)),
                periods.MaxOrDefault(us => (long)Math.Round(us.Duration.TotalSeconds)),
                periods.AvgOrDefault(us => (long)Math.Round(us.Duration.TotalSeconds)),
                periods.Median(us => (long)Math.Round(us.Duration.TotalSeconds)));
        }

        public string ToString(TimeSpan minDuration)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Version} (log lines {StartLineIndex}-{EndLineIndex}) running {Period}");
            Stats stats = CalcStats(minDuration);

            string suffix = "";
            if (stats.PeriodsNotIncluded > 0) suffix = $"({stats.PeriodsNotIncluded}{(stats.PeriodsNotIncluded == 1 ? " is " : " are ")}not shown because duration is lower than {minDuration})";
            sb.AppendLine($"  Nr of unsyncs: {UnsyncPeriods.Count}x {suffix}");

            List<Period> periods = UnsyncPeriods.Where(us => us.Duration >= minDuration).ToList();

            foreach (var unsyncPeriod in periods)
            {
                sb.AppendLine($"    Unsyncperiod {unsyncPeriod}");
            }
            sb.AppendLine($"  Stats");
            sb.AppendLine($"{stats.ToString().IndentWithLevel(2)}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToString(TimeSpan.Zero);
        }
    }
}
