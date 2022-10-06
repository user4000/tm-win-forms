using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TmWinForms
{
  partial class FrameworkManager
  {
    static void EventMainFormShown(object sender, EventArgs e)
    {
      MainForm.Shown -= new EventHandler(EventMainFormShown);

      Events.BeforeSubFormsAreCreated?.Invoke();

 

      Service.PlaceAllSubFormsToMainPageView();

  

      Events.BeforeMainFormBecomesVisible?.Invoke();

      MainForm.VisualEffectFadeIn();

      MainForm.Visible = true;




      bool startForm = Service.GotoStartForm();

      if (startForm == false) Service.GotoStartFormUsingStringCode();




      MainForm.ShowMainPageView(true);




      Events.MainFormShown?.Invoke();

      Events.Start?.Invoke();

      MainForm.LaunchStartTimer();

      MainForm.SetEventForSystemTrayIcon();

      if (FlagServiceApplication()) MainForm.ShowInTaskbar = false;
    }
  }
}