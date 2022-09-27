using System;
using System.IO;
using System.Drawing;

namespace TmWinForms.Tools
{
  public static class CxTools
  {
    public static string StringLeft(this string value, int string_Length)
    {
      if (string.IsNullOrEmpty(value)) return value;
      string_Length = Math.Abs(string_Length);
      return (value.Length <= string_Length ? value : value.Substring(0, string_Length));
    }

    public static void CreateDirectoryForFile(string FileNameWithFolder)
    {
      if (Directory.Exists(Path.GetDirectoryName(FileNameWithFolder)) == false)
        Directory.CreateDirectory(Path.GetDirectoryName(FileNameWithFolder));
    }

    public static int SquareOfDistance(Point a, Point b)
    {
      return ((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
    }
  }
}