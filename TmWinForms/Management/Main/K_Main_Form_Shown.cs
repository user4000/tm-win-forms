using System;

namespace TmWinForms
{
  partial class FrameworkManager
  {
    static async void EventMainFormShown(object sender, EventArgs e)
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

      if (Events.StartAsync != null)
      {
        await Events.StartAsync();
      }

      MainForm.LaunchStartTimer();

      MainForm.LaunchStartTimerAsync();

      MainForm.SetEventForSystemTrayIcon();

      if (FlagServiceApplication()) MainForm.ShowInTaskbar = false; // Если это серверное приложение то не показывать его на панели задач //
    }
  }
}