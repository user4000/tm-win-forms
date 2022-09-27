using System.IO;
using Newtonsoft.Json;

namespace TmWinForms
{
  public class StandardUserSettingsLoader<T> where T : StandardApplicationSettings
  {
    private const string DefaultTextFileName = StandardApplicationSettings.DefaultTextFileName;

    public static T LoadFromJsonFile(string FileName = DefaultTextFileName)
    {
      FileName = FrameworkManager.CheckIfSettingSubFolderIsSpecified(FileName);
      T t = default(T);
      using (StreamReader file = File.OpenText(FileName))
      {
        JsonSerializer serializer = new JsonSerializer();
        t = (T)serializer.Deserialize(file, typeof(T));
      }
      return t;
    }
  }
}