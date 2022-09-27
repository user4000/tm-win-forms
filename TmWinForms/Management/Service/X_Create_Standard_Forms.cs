using System;
using System.Drawing;
using TmWinForms.Form;
using System.Diagnostics;
using Telerik.WinControls;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;

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
      AddForm(form, null, FrameworkManager.FrameworkSettings.HeaderFormLog, true, true);
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

      AddForm(form, null, FrameworkManager.FrameworkSettings.HeaderFormSettings, true, true);
    }

    public void CreateFormExit()
    {
      FxExit form = new FxExit();
      FormExit = form;
      FormExit.BtnExit.Click += new EventHandler(EventButtonExitClick);

      AddForm(form, null, FrameworkManager.FrameworkSettings.HeaderFormExit, true, true);
    }

    private void EventButtonExitClick(object sender, EventArgs e)
    {
      RadMessageBox.Show("Hey you !");
    }

    RadPageViewPage TryToSelectExistingPage(RadForm form)
    {
      RadPageViewPage page = null;

      //Trace.WriteLine($"{form.GetType().FullName} --- {typeof(FxLog).FullName} --- {typeof(FxExit).FullName}");

      if (form.GetType().FullName == typeof(FxLog).FullName) return MainForm.PageLog;
      if (form.GetType().FullName == typeof(FxExit).FullName) return MainForm.PageExit;
      if (form.GetType().FullName == typeof(FxSettings).FullName) return MainForm.PageSettings;

      return page;
    }
  }
}