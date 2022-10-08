using System;
using System.IO;
using System.Drawing;

namespace TmWinForms.Tools
{
  internal static class CxTools // Auxiliary functions //
  {
    internal const string FormatDDMMYYYY = "dd-MM-yyyy HH:mm:ss";

    internal const string FormatYYYYMMDD = "yyyy-MM-dd HH:mm:ss";

    internal const string Empty = "";

    internal static CxStandardJsonSerializerSetting JsonSerializerSetting { get; } = new CxStandardJsonSerializerSetting();

    internal static string StringLeft(this string value, int length)
    {
      if (string.IsNullOrEmpty(value)) return value;
      length = Math.Abs(length);
      return (value.Length <= length ? value : value.Substring(0, length));
    }

    internal static void CreateDirectoryForFile(string FileNameWithFolder)
    {
      if (Directory.Exists(Path.GetDirectoryName(FileNameWithFolder)) == false)
        Directory.CreateDirectory(Path.GetDirectoryName(FileNameWithFolder));
    }

    internal static int SquareOfDistance(Point a, Point b)
    {
      return ((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
    }
  }
}