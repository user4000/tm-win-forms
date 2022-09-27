using System;
using System.Drawing;

namespace TmWinForms
{
  public static class CxStandard
  {
    public static char MessageHeaderSeparator { get; } = '|';

    public static string MessageType1 { get; } = "O";
    public static string MessageType2 { get; } = "i";
    public static string MessageType3 { get; } = "a";
    public static string MessageType4 { get; } = "@";
    public static string MessageType5 { get; } = "x";
    public static string MessageType6 { get; } = "r";

    public static Size ZeroSize { get; } = new Size(0, 0);

    public static Point ZeroPoint { get; } = new Point(0, 0);

    public static string GridColumnPrefix { get; } = "Cc";

    public static string GetGridColumnName(string ColumnName) => $"{GridColumnPrefix}{ColumnName}";
  }
}