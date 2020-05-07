[![Build status](https://ci.appveyor.com/api/projects/status/3gvk0o9id7ctlywk/branch/master?svg=true)](https://ci.appveyor.com/project/jeme/adv-parsers/branch/master)
[![Black Duck Security Risk](https://copilot.blackducksoftware.com/github/repos/dotJEM/adv-parsers/branches/master/badge-risk.svg)](https://copilot.blackducksoftware.com/github/repos/dotJEM/adv-parsers/branches/master)

# adv-parsers
Small package of a few simple parsers I have reused on multiple occasions by now. 

Currently it contains two parsers, a TimeSpanParser and a ByteCountParser.

# TimeSpanParser

The timespan parser can parse timespans from a more human readable format (english only).

Supported units:

| Unit         | Text |
| ------------ | ---- | 
| Days         | d, day, days | 
| Hours        | h, hour, hours | 
| Minutes      | m, min, minute, minutes | 
| Seconds      | s, sec, second, seconds | 
| Milliseconds | f, frac, fraction, fractions, ms, millisecond, milliseconds | 


## Examples

The following sections has examples of supported inputs for the parser.

**Fully formated values**

| Input value | Timespan Equivalent Result |
| --- | --- | 
| `2d 12h 30m` | `new TimeSpan(2, 12, 30, 0, 0)` | 
| `2 d 12 h 30 m` | `new TimeSpan(2, 12, 30, 0, 0)` | 
| `2days 12hours 30minutes` | `new TimeSpan(2, 12, 30, 0, 0)` | 
| `2d 12h 30m 45s 500f` | `new TimeSpan(2, 12, 30, 45, 500)` | 

**Overflowing values**

| Input value | Timespan Equivalent Result |
| --- | --- | 
| `2000f` | `TimeSpan.FromSeconds(2)` | 
| `5000ms` | `TimeSpan.FromSeconds(5)` | 
| `300s` | `TimeSpan.FromMinutes(5)` | 
| `300m` | `TimeSpan.FromHours(5)` | 
| `125h` | `new TimeSpan(5, 5, 0, 0, 0)` | 
| `2d 12h 120m` | `new TimeSpan(2, 14, 0, 0, 0)` |
| `2d 36h 120m` | `new TimeSpan(3, 14, 0, 0, 0)` |

**Built-in Formats**

| Input value | Timespan Equivalent Result |
| --- | --- | 
| `2:30` | `TimeSpan.Parse("2:30")` | 
| `2:30:55` | `TimeSpan.Parse("2:30:55")` |

# ByteCountParser

The byte count parser can parse byte counts from a more human readable format (english only).

Supported units:

| Unit         | Text |
| ------------ | ---- | 
| Terabytes    | tb, terabyte, terabytes | 
| Gigabytes    | gb, gigabyte, gigabytes | 
| Megabytes    | mb, megabyte, megabytes | 
| Kilobytes    | kb, kilobyte, kilobytes | 
| Bytes        | b, byte, bytes | 

## Examples

The following sections has examples of supported inputs for the parser.

| Input value | Equivalent Calculation |
| --- | --- | 
| `2 gigabytes` | `2 * 1024 * 1024 * 1024` | 
| `2mb 512kb` | `( ( 2 * 1024 ) + 512 ) * 1024` | 
| `4gb 16mb 32kb 64b` | `( ( ( ( ( 4 * 1024 ) + 16 ) * 1024 ) + 32 ) * 1024 ) + 64 ) * 1024` | 
