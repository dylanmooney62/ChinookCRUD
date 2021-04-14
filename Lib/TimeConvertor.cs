using System;

namespace Lib
{
    public static class TimeConvertor
    {
        public static string MinutesAndSeconds(long ms)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(ms);

            string humanFormat = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

            return humanFormat;
        }
    }
}