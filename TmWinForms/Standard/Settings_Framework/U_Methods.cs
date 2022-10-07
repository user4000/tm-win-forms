using System;
using System.IO;
using TmWinForms.Tools;
using System.Windows.Forms;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class StandardFrameworkSettings
  {
    private void GetMainFormLocation()
    {
      if (MainForm.WindowState != FormWindowState.Normal) return;

      this.MainFormSize = MainForm.Size;
      this.MainFormLocation = MainForm.Location;
    }

    private void CheckErrorFileNamedAsDirectory()
    {
      if (File.Exists(DefaultFolderUserSettings))
        try
        {
          File.Delete(DefaultFolderUserSettings);
        }
        catch (Exception ex)
        {
          string h = $"Could not delete file <<{DefaultFolderUserSettings}>> which prevents to save framework settings";
          FrameworkManager.SaveErrorToTextFile(h, ex);
          //Log.Save(ex, h, MsgType.Error);
          //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
        }
    }

    internal override void Save(string fileName = FrameworkSettingsFileName)
    {
      //if (RememberMainFormLocation == false) return;

      //if (MainForm.WindowState != FormWindowState.Normal) return;

      GetMainFormLocation();

      CheckErrorFileNamedAsDirectory();
      try
      {
        base.Save(fileName);
      }
      catch (Exception ex)
      {
        string h = $"Could not save framework settings file {fileName}";
        FrameworkManager.SaveErrorToTextFile(h, ex);
        //Log.Save(ex, h, MsgType.Error);
        //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
      }
    }

    internal void LoadFrameworkSettings()
    {
      StandardFrameworkSettings settings = null;

      try
      {
        settings = Load();
        SettingsLoadedFromFile = settings;
      }
      catch (Exception ex)
      {
        string h = "Could not load framework settings.";
        FrameworkManager.SaveErrorToTextFile(h, ex);
        //Log.Save(ex, h, MsgType.Fail);
        //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
      };


      if (settings == null)
        try
        {
          CxTools.CreateDirectoryForFile(FrameworkSettingsFileName);
        }
        catch (Exception ex)
        {
          string h = "Could not create directory for framework settings file.";
          FrameworkManager.SaveErrorToTextFile(h, ex);
          //Log.Save(ex, h, MsgType.Error);
          //Ms.Error(h, ex).Pos(MsgPos.BottomRight).Delay(10).Create();
        }


      RestoreValuesFromFile();
    }
  }
}