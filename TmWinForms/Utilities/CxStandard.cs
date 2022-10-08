using System;
using System.Drawing;

namespace TmWinForms
{
  internal static class CxStandard
  {
    internal static char MessageHeaderSeparator { get; } = '|';

    internal static string MessageType1 { get; } = "O";
    internal static string MessageType2 { get; } = "i";
    internal static string MessageType3 { get; } = "a";
    internal static string MessageType4 { get; } = "@";
    internal static string MessageType5 { get; } = "x";
    internal static string MessageType6 { get; } = "r";

    internal static Size ZeroSize { get; } = new Size(0, 0);

    internal static Point ZeroPoint { get; } = new Point(0, 0);

    internal static string GridColumnPrefix { get; } = "Cc";

    internal static string GetGridColumnName(string ColumnName) => $"{GridColumnPrefix}{ColumnName}";
  }
}