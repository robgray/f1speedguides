using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace atomicf1.common
{
    public static class Extensions
    {
        public static string ReplaceAt(this string content, int startPos, string oldText, string newText)
        {
            return content.Remove(startPos, oldText.Length)
                                    .Insert(startPos, newText);
        }

        public static string ToLapTime(this decimal lapTimeInSeconds)
        {
            return ToLapTime(lapTimeInSeconds, false);
        }

        public static string ToLapTime(this decimal lapTimeInSeconds, bool hideZero)
        {
            if (hideZero && lapTimeInSeconds == 0) return "";

            if (lapTimeInSeconds == decimal.MaxValue) return "* No Time *";
            if (lapTimeInSeconds == 0) return "0:00.000";

            int minutes = (int)lapTimeInSeconds / 60;
            int seconds = ((int)lapTimeInSeconds) % 60;
            int milliseconds = ((int)(lapTimeInSeconds * 1000)) - (((int)lapTimeInSeconds) * 1000);

            return string.Format("{0}:{1:00}.{2:000}", minutes, seconds, milliseconds);
        }

        public static decimal? ConvertToDecimalLapTime(this string time)
        {
            TimeSpan ts;

            if (TimeSpan.TryParseExact(time, "m\\:s\\.fff", null, out ts))
                return (decimal)ts.TotalSeconds;
            return null;
        }

        public static bool ContainsAnyOf(this string content, IEnumerable<string> startStrings)
        {
            return startStrings.Any(s => content.ToLowerInvariant().IndexOf(s.ToLowerInvariant()) > -1);
        }

        public static bool StartsWithAnyOf(this string content, IEnumerable<string> startStrings)
        {
            return startStrings.Any(s => content.ToLowerInvariant().StartsWith(s.ToLowerInvariant()));
        }
    }
}
