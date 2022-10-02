using System;
using System.Drawing;
using TmWinForms.Form;
using System.Diagnostics;
using Telerik.WinControls;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    bool FlagItIsTimeToAddStandardForms { get; set; } = false;

    public void CreateFormLog()
    {
      FxLog form = new FxLog();
      FormLog = form;
      AlertService = new TmAlertService(this, FormLog);
      AddForm(form, null, FrameworkSettings.HeaderFormLog, true, true);
    }

    public void CreateFormSetting()
    {
      FxSettings form = new FxSettings();
      FormSettings = form;

      StandardApplicationSettings loadedSettings = null;

      try
      {
        loadedSettings = CurrentApplicationSettings;
        SetCurrentSettings(loadedSettings); // Set just loaded settings as current settings //
      }
      catch 
      {
        ProjectDefaultApplicationSettings.LinkToPropertyGrid(FormSettings.GxProperty);
        //Log.Save(MsgType.Error, "An error has occured during loading application settings.", "");
        //Log.Save(ex, "method name = [IsSettingsForm]");
      }

      FormSettings.AcceptLoadedSettings(loadedSettings);

      AddForm(form, null, FrameworkSettings.HeaderFormSettings, true, true);
    }

    public void CreateFormExit()
    {
      FxExit form = new FxExit();
      FormExit = form;
      AddForm(form, null, FrameworkSettings.HeaderFormExit, true, true);
    }

    RadPageViewPage TryToFindExistingPage(RadForm form)
    {
      RadPageViewPage page = null;

      //Trace.WriteLine($"{form.GetType().FullName} --- {typeof(FxLog).FullName} --- {typeof(FxExit).FullName}");

      if (form.GetType().FullName == typeof(FxLog).FullName)
      {
        MainForm.PageLog.Text = FrameworkSettings.HeaderFormLog;
        return MainForm.PageLog;
      }

      if (form.GetType().FullName == typeof(FxExit).FullName)
      {
        MainForm.PageExit.Text = FrameworkSettings.HeaderFormExit;
        return MainForm.PageExit;
      }

      if (form.GetType().FullName == typeof(FxSettings).FullName)
      {
        MainForm.PageSettings.Text = FrameworkSettings.HeaderFormSettings;
        return MainForm.PageSettings;
      }

      return page;
    }
  }
}