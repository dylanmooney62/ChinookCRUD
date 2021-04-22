using System;

namespace Lib
{
    public static class TimeConvertor
    {
        public static string MinutesAndSeconds(long ms)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(ms);

            var humanFormat = $"{t.Minutes:D2}:{t.Seconds:D2}";

            return humanFormat;
        }
    }
}