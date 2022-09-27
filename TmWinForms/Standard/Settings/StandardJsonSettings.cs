using System.IO;
using Newtonsoft.Json;

namespace TmWinForms
{
  public class StandardJsonSettings<T> where T : new()
  {
    public const string DefaultFolderUserSettings = StandardApplicationSettings.DefaultFolderUserSettings; // "settings";

    public const string FrameworkSettingsFileName = DefaultFolderUserSettings + @"\framework_settings.txt";

    internal virtual void Save(string fileName = FrameworkSettingsFileName)
    {
      fileName = FrameworkManager.CheckIfSettingSubFolderIsSpecified(fileName);
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        serializer.Serialize(file, this);
      }
    }

    internal static void Save(T Settings, string fileName = FrameworkSettingsFileName)
    {
      fileName = FrameworkManager.CheckIfSettingSubFolderIsSpecified(fileName);
      using (StreamWriter file = File.CreateText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };
        serializer.Serialize(file, Settings);
      }
    }

    internal static T Load(string fileName = FrameworkSettingsFileName)
    {
      fileName = FrameworkManager.CheckIfSettingSubFolderIsSpecified(fileName);
      T t = default(T);
      using (StreamReader file = File.OpenText(fileName))
      {
        JsonSerializer serializer = new JsonSerializer();
        t = (T)serializer.Deserialize(file, typeof(T));
      }
      return t;
    }
  }
}