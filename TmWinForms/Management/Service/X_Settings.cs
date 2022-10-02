using System;
using System.Text;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FrameworkService
  {
    private void SetCurrentSettings(StandardApplicationSettings inputSettings) => CurrentApplicationSettings = inputSettings ?? CurrentApplicationSettings;

    internal void ConfigureApplicationSettings(StandardApplicationSettings settings)
    {
      ProjectDefaultApplicationSettings = settings;
      SetCurrentSettings(settings);
    }



    /// <summary>
    /// Use Assembly.GetExecutingAssembly().GetName().Name as an argument
    /// </summary>
    public void CreateApplicationSettings<T>(string SettingSubFolderName = "") where T : StandardApplicationSettings, new()
    {
      FrameworkManager.SetSubFolderForSettings(SettingSubFolderName);
      T settingsDefault = new T(); // Create instance of concrete user settings //
      T localSettingsCurrent = settingsDefault;

      /* Since JSON Serializer cannot save attributes of members of [Settings] class we need this workaround */
      try
      {
        localSettingsCurrent = StandardUserSettingsLoader<T>.LoadFromJsonFile();
      }
      catch
      {
        localSettingsCurrent = settingsDefault;
      }

      CurrentApplicationSettings = localSettingsCurrent;
      ConfigureApplicationSettings(localSettingsCurrent);
    }
  }
}