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




      MainForm.Visible = false;

      if (FlagServiceApplication()) MainForm.WindowState = FormWindowState.Minimized;

      MainForm.ShowMainPageView(false);

      Service.Configure(MainForm);

      Pages.Configure(MainForm);

      MainForm.Text = string.Empty; // TODO: Form caption //

      MainForm.SetProperties();

      MainForm.SetEvents();

      MainForm.FormClosing += new FormClosingEventHandler(EventMainFormClosing);

      MainForm.FormClosed += new FormClosedEventHandler(EventMainFormClosed);

      MainForm.Shown += new EventHandler(EventMainFormShown);

      FrameworkSettings.RestoreMainFormLocationAndSize();

      //Application.ApplicationExit += new EventHandler(EventApplicationExit);

      return MainForm;
    }
  }
}