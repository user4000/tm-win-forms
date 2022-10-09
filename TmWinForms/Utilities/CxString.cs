using System;
using System.Linq;
using System.Globalization;

namespace TmWinForms.Tools
{
  internal static class CxString
  {
    internal static NumberFormatInfo Nfi { get; } = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

    private static Random MyRandom { get; } = new Random();

    internal const string Empty = "";

    static CxString()
    {
      Nfi.NumberGroupSeparator = " ";
    }

    internal static string RandomString(int length)
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzйцукенгшщзхъфывапролджэячсмитьбю";
      return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[MyRandom.Next(s.Length)]).ToArray());
    }

    internal static string RandomPhrase(int words)
    {
      string phrase = string.Empty;
      for (int i = 0; i < words; i++)
      {
        phrase += RandomString(MyRandom.Next(MyRandom.Next(MyRandom.Next(1, 7), 8), 12));
        if (i + 1 < words) phrase += " "; else phrase += ".";
      }
      return phrase;
    }
  }
}