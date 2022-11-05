using System;

namespace TmWinForms
{
  partial class FrameworkManager
  {
    static async void EventMainFormShown(object sender, EventArgs e) // NOTE: Очень важное событие "Главная форма показывается пользователю" //
    {
      MainForm.Shown -= new EventHandler(EventMainFormShown);

      Events.BeforeSubFormsAreCreated?.Invoke();

      Service.PlaceAllSubFormsToMainPageView();
 
      Events.BeforeMainFormBecomesVisible?.Invoke();

      MainForm.VisualEffectFadeIn();

      MainForm.Visible = true;

      Service.GotoStartForm(); // Перейти на стартовую форму (если, конечно, такая форма была задана программистом) //

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