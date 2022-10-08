using Newtonsoft.Json;

namespace TmWinForms.Tools
{
  internal class CxStandardJsonSerializerSetting
  {
    internal JsonSerializerSettings setting = new JsonSerializerSettings();

    internal CxStandardJsonSerializerSetting() // Constructor //
    {
      setting.Formatting = Formatting.Indented;
      setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      setting.PreserveReferencesHandling = PreserveReferencesHandling.All;
      setting.MaxDepth = 2;
      setting.DateTimeZoneHandling = DateTimeZoneHandling.Local;
      setting.DateFormatHandling = DateFormatHandling.IsoDateFormat;
      setting.DateParseHandling = DateParseHandling.DateTime;
    }
  }
}