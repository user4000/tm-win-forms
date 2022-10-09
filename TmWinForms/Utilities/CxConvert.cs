using System;
using Newtonsoft.Json;

namespace TmWinForms.Tools
{
  internal class CxConvert
  {
    internal const string Empty = "";

    internal static string StringSeparatorStandard { get; } = "|";

    internal static char CharSeparatorStandard { get; } = '|';

    internal static JsonSerializerSettings jsonSerializerSettings { get; } = null;

    static CxConvert()
    {
      StringSeparatorStandard = CharSeparatorStandard.ToString();
      if (StringSeparatorStandard != CharSeparatorStandard.ToString()) throw new Exception("Ошибка в данных класса TTConvert. StringSeparatorStandard должен быть равен CharSeparatorStandard");
      jsonSerializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
    }

    internal static string DateTimeFormat { get; } = "yyyy-MM-dd HH:mm:ss";

    internal static string Time { get => DateTime.Now.ToString(DateTimeFormat); }

    internal static int ValueInRange(int Value, int RangeMin, int RangeMax) => Math.Max(RangeMin, Math.Min(RangeMax, Value));
  }
}