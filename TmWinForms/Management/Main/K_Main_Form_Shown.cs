using System;
using System.Windows.Forms;

namespace TmWinForms
{
  partial class FrameworkManager
  {
    static void EventMainFormShown(object sender, EventArgs e)
    {
      MainForm.Shown -= new EventHandler(EventMainFormShown);

      Service.PlaceAllSubFormsToMainPageView();

      MainForm.VisualEffectFadeIn();

      MainForm.Visible = true;
    }
  }
}