# Scan GoShimmer Log

Simple easy to use multi-platform console tool to show some stats about your GoShimmer node using it's logfile.

## How to use
```console
ScanGoShimmerLog c:\goshimmer\log\goshimmer.log
```

it will show some stats like unsynced time:
```console
v0.8.10 (log lines 0-17396) running from 19-Mar-22 17:44:36 till 23-Mar-22 11:21:00 with duration of 03.17:36:24 (322584 secs)
  Nr of unsyncs: 5x (3 are not shown because duration is lower than 00:00:10)
    Unsyncperiod from 20-Mar-22 08:48:37 till 20-Mar-22 08:48:57 with duration of 00.00:00:20 (    20 secs)
    Unsyncperiod from 21-Mar-22 11:06:37 till 23-Mar-22 11:21:00 with duration of 02.00:14:23 (173663 secs)
  Stats
    PeriodsIncluded: 2
    PeriodsNotIncluded: 3
    Minimum: 00:00:20 (    20 secs)
    Maximum: 2.00:14:23 (173663 secs)
    Average: 1.00:07:21 ( 86842 secs)
    Median : 1.00:07:21 ( 86842 secs)


v0.8.11 (log lines 17396-18726) running from 23-Mar-22 11:21:00 till 23-Mar-22 16:06:03 with duration of 00.04:45:03 ( 17103 secs)
  Nr of unsyncs: 1x
    Unsyncperiod from 23-Mar-22 11:49:04 till 23-Mar-22 12:07:27 with duration of 00.00:18:23 (  1103 secs)
  Stats
    PeriodsIncluded: 1
    PeriodsNotIncluded: 0
    Minimum: 00:18:23 (  1103 secs)
    Maximum: 00:18:23 (  1103 secs)
    Average: 00:18:23 (  1103 secs)
    Median : 00:18:23 (  1103 secs)


v0.8.11 (log lines 18726-22142) running from 23-Mar-22 16:06:03 till 24-Mar-22 08:30:13 with duration of 00.16:24:10 ( 59050 secs)
  Nr of unsyncs: 3x (1 is not shown because duration is lower than 00:00:10)
    Unsyncperiod from 24-Mar-22 06:08:25 till 24-Mar-22 06:09:59 with duration of 00.00:01:34 (    94 secs)
    Unsyncperiod from 24-Mar-22 07:06:06 till 24-Mar-22 07:06:43 with duration of 00.00:00:37 (    37 secs)
  Stats
    PeriodsIncluded: 2
    PeriodsNotIncluded: 1
    Minimum: 00:00:37 (    37 secs)
    Maximum: 00:01:34 (    94 secs)
    Average: 00:01:05 (    66 secs)
    Median : 00:01:05 (    66 secs)


v0.8.11 (log lines 22142-117847) running from 24-Mar-22 08:30:13 till 13-Apr-22 21:38:47 with duration of 20.13:08:34 (1775314 secs)
  Nr of unsyncs: 42x (16 are not shown because duration is lower than 00:00:10)
    Unsyncperiod from 28-Mar-22 18:40:14 till 28-Mar-22 18:40:44 with duration of 00.00:00:30 (    30 secs)
    Unsyncperiod from 28-Mar-22 21:16:53 till 28-Mar-22 21:17:41 with duration of 00.00:00:48 (    48 secs)
    Unsyncperiod from 29-Mar-22 09:33:47 till 29-Mar-22 09:34:08 with duration of 00.00:00:21 (    21 secs)
    Unsyncperiod from 29-Mar-22 11:06:45 till 29-Mar-22 11:07:34 with duration of 00.00:00:49 (    49 secs)
    Unsyncperiod from 30-Mar-22 12:25:43 till 30-Mar-22 12:25:54 with duration of 00.00:00:11 (    11 secs)
    Unsyncperiod from 30-Mar-22 16:16:14 till 30-Mar-22 16:22:41 with duration of 00.00:06:27 (   387 secs)
    Unsyncperiod from 30-Mar-22 17:42:14 till 30-Mar-22 17:43:57 with duration of 00.00:01:43 (   103 secs)
    Unsyncperiod from 30-Mar-22 17:46:14 till 30-Mar-22 17:46:25 with duration of 00.00:00:11 (    11 secs)
    Unsyncperiod from 30-Mar-22 20:23:34 till 30-Mar-22 20:24:04 with duration of 00.00:00:30 (    30 secs)
    Unsyncperiod from 31-Mar-22 07:26:14 till 31-Mar-22 07:28:09 with duration of 00.00:01:55 (   115 secs)
    Unsyncperiod from 31-Mar-22 08:48:14 till 31-Mar-22 08:53:00 with duration of 00.00:04:46 (   286 secs)
    Unsyncperiod from 31-Mar-22 09:37:07 till 31-Mar-22 09:37:20 with duration of 00.00:00:13 (    13 secs)
    Unsyncperiod from 31-Mar-22 18:38:14 till 31-Mar-22 18:45:37 with duration of 00.00:07:23 (   443 secs)
    Unsyncperiod from 01-Apr-22 15:56:14 till 01-Apr-22 15:58:02 with duration of 00.00:01:48 (   108 secs)
    Unsyncperiod from 04-Apr-22 00:06:14 till 04-Apr-22 00:07:38 with duration of 00.00:01:24 (    84 secs)
    Unsyncperiod from 04-Apr-22 11:24:14 till 04-Apr-22 11:24:36 with duration of 00.00:00:22 (    22 secs)
    Unsyncperiod from 04-Apr-22 16:38:14 till 04-Apr-22 16:39:43 with duration of 00.00:01:29 (    89 secs)
    Unsyncperiod from 04-Apr-22 16:52:14 till 04-Apr-22 16:57:08 with duration of 00.00:04:54 (   294 secs)
    Unsyncperiod from 05-Apr-22 07:16:14 till 05-Apr-22 07:17:16 with duration of 00.00:01:02 (    62 secs)
    Unsyncperiod from 05-Apr-22 09:20:14 till 05-Apr-22 09:55:48 with duration of 00.00:35:34 (  2134 secs)
    Unsyncperiod from 05-Apr-22 18:34:14 till 05-Apr-22 18:34:31 with duration of 00.00:00:17 (    17 secs)
    Unsyncperiod from 07-Apr-22 06:53:26 till 07-Apr-22 06:53:57 with duration of 00.00:00:31 (    31 secs)
    Unsyncperiod from 07-Apr-22 20:12:14 till 07-Apr-22 20:14:07 with duration of 00.00:01:53 (   113 secs)
    Unsyncperiod from 07-Apr-22 20:48:14 till 07-Apr-22 20:53:07 with duration of 00.00:04:53 (   293 secs)
    Unsyncperiod from 09-Apr-22 07:04:14 till 09-Apr-22 07:06:05 with duration of 00.00:01:51 (   111 secs)
    Unsyncperiod from 13-Apr-22 13:50:14 till 13-Apr-22 14:23:43 with duration of 00.00:33:29 (  2009 secs)
  Stats
    PeriodsIncluded: 26
    PeriodsNotIncluded: 16
    Minimum: 00:00:11 (    11 secs)
    Maximum: 00:35:34 (  2134 secs)
    Average: 00:04:25 (   266 secs)
    Median : 00:01:26 (    86 secs)
```
