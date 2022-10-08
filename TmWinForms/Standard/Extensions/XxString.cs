using System;

namespace TmWinForms.Extensions
{
  internal static class XxString
  {
    internal static string Left(this string value, int length)
    {
      if (string.IsNullOrEmpty(value)) return value;
      length = Math.Abs(length);
      return (value.Length <= length) ? value : value.Substring(0, length);
    }
  }
}