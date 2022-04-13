using ScanGoShimmerLog;

//Todo:
// use commandline package
// give warning (plus duration) when version ended unsynced and dont show/use in stats

string versionLineContains = "GoShimmer version ";
string syncChangedLineContains = "Sync changed: ";
TimeSpan minUnsyncDuration = TimeSpan.FromSeconds(10);

string[] arguments = Environment.GetCommandLineArgs();
if (arguments.Length <= 1)
{
    Console.WriteLine("Parameter is missing: No GoShimmer logfile given!");
    Environment.Exit(1);
}

List<string> lines = File
    .ReadAllLines(arguments[1])
    .ToList();

List<int> versionLineIndexes = new List<int>();
for (int i = 0; i < lines.Count; i++)
{
    string versionLine = lines[i].ToLower();
    if (versionLine.Contains(versionLineContains.ToLower()))
    {
        versionLineIndexes.Add(i);
    }
}
versionLineIndexes.Add(lines.Count - 1); //always add last lineIndex

List<VersionEntry> versionEntries = new List<VersionEntry>();
for (int i = 0; i < versionLineIndexes.Count - 1; i++) //last one doesn't contain a version
{
    string[] columns;
    int startLineIndex = versionLineIndexes[i];
    string versionLine = lines[startLineIndex];
    columns = versionLine.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

    DateTime start = DateTime.Parse(columns[0]);

    string version = columns[4].ToLower().Replace(versionLineContains.ToLower(), "").Replace(" ...", "");
    int endLineIndex = versionLineIndexes[i + 1];
    string next = lines[endLineIndex];
    columns = next.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

    DateTime end = DateTime.Parse(columns[0]);

    VersionEntry versionEntry = new VersionEntry(startLineIndex, endLineIndex, version, new Period(start, end));
    versionEntries.Add(versionEntry);
}

lines = lines
    .Where(line => line.ToLower().Contains(syncChangedLineContains.ToLower()))
    .ToList();

for (int i = 0; i < lines.Count; i++)
{
    //search sync false
    string lineUnsynced = lines[i].ToLower();
    if (lineUnsynced.Contains($"{syncChangedLineContains.ToLower()}false"))
    {
        //search sync true
        for (int j = i + 1; j < lines.Count; j++)
        {
            string lineSyncedAgain = lines[j].ToLower();
            if (lineSyncedAgain.Contains($"{syncChangedLineContains.ToLower()}true"))
            {
                string[] columns;
                columns = lineUnsynced.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                DateTime start = DateTime.Parse(columns[0]);

                columns = lineSyncedAgain.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                DateTime end = DateTime.Parse(columns[0]);

                Period unsyncPeriod = new Period(start, end);

                VersionEntry versionEntry = SearchVersionByPeriod(unsyncPeriod);
                if (versionEntry == null)
                {
                    versionEntry = SearchVersionByDateTime(unsyncPeriod.Start);
                    unsyncPeriod.End = versionEntry.Period.End;
                }
                versionEntry.UnsyncPeriods.Add(unsyncPeriod);

                break;
            }
        }
    }
}

foreach (var versionEntry in versionEntries)
{
    Console.WriteLine(versionEntry.ToString(minUnsyncDuration));
}

VersionEntry SearchVersionByPeriod(Period unsyncedPeriod)
{
    return versionEntries.SingleOrDefault(versionEntry => unsyncedPeriod.Start >= versionEntry.Period.Start && unsyncedPeriod.End <= versionEntry.Period.End);
}

VersionEntry SearchVersionByDateTime(DateTime dateTime)
{
    return versionEntries.Single(versionEntry => dateTime >= versionEntry.Period.Start && dateTime <= versionEntry.Period.End);
}