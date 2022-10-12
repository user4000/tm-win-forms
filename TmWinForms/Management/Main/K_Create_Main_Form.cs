using System;
using System.Windows.Forms;

namespace TmWinForms
{
  public partial class FrameworkManager
  {
    static FxMain CreateMainForm()
    {
      MainForm = new FxMain();
     
      foreach(var page in MainForm.PvMain.Pages)
      {
        page.Item.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
      }




      #region Tune Icons ---------------------------------------------------------------------------------------------------------

      SetIconDefaultValuesIfTheyHaveNoAnyValue();

      MainForm.Icon = IconApplication;
      MainForm.NotifyIconMainForm.Icon = IconSystemTray;

      #endregion ----------------------------------------------------------------------------------------------------------------


      MainForm.Text = FrameworkSettings.MainFormCaption;

      MainForm.Visible = false;

      if (FlagServiceApplication()) MainForm.WindowState = FormWindowState.Minimized;

      MainForm.ShowMainPageView(false);

      Service.Configure(MainForm);

      Pages.Configure(MainForm);

      MainForm.Text = FrameworkSettings.MainFormCaption;

      MainForm.SetProperties();

      MainForm.SetEvents();

      MainForm.FormClosing += new FormClosingEventHandler(EventMainFormClosing);

      MainForm.FormClosed += new FormClosedEventHandler(EventMainFormClosed);

      MainForm.Shown += new EventHandler(EventMainFormShown);

      FrameworkSettings.RestoreMainFormLocationAndSize();


      // Если пользователь хочет применить тему приложения, то сделаем это по части имени темы //
      if (string.IsNullOrWhiteSpace(FrameworkSettings.ThemeName) == false)
      {
        ThemeManager.SetApplicationTheme(FrameworkSettings.ThemeName);
      }



      //Application.ApplicationExit += new EventHandler(EventApplicationExit);

      return MainForm;
    }
  }
}