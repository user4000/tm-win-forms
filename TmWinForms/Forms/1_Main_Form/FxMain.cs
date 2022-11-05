using System;
using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class FxMain : RadForm
  {
    System.Windows.Forms.Timer TmStartMainApplication { get; set; } = new System.Windows.Forms.Timer();

    System.Windows.Forms.Timer TmStartMainApplicationAsync { get; set; } = new System.Windows.Forms.Timer();


    public bool FlagSizeIsBeingChanged { get; private set; } = false;

  
    public FxMain()
    {
      InitializeComponent();
    }

    internal void SetProperties()
    {
      if (FrameworkSettings.VisualEffectOnStart)
      {
        this.Opacity = 0;
      }

      AdjustFirstPage();

      AdjustAboutProgramPage();

      AdjustScrollStripButtons();


      this.MinimumSize = new Size(800, 600);

      // TODO: Сделать также настроку для PvMain  ItemFitMode
      // https://docs.telerik.com/devtools/winforms/controls/pageview/stripview/fitting-items
    }

    void AdjustScrollStripButtons() // Настроим размеры небольших боковых кнопок, которые прокручивают полосу вкладок //
    {
      ((RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new Size(26, 26);
      ((RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).MinSize = new Size(26, 26);
    }


    internal void LaunchStartTimer()
    {
      if (FrameworkManager.Events.StartByTimer == null) return;

      int milliseconds = Math.Abs(FrameworkSettings.StartTimerIntervalMilliseconds);

      if (milliseconds == 0) return;

      TmStartMainApplication.Interval = milliseconds;
      TmStartMainApplication.Tick += new EventHandler(EventStartMainApplication);
      TmStartMainApplication.Start();
    }

    internal void LaunchStartTimerAsync()
    {
      if (FrameworkManager.Events.StartByTimerAsync == null) return;

      int milliseconds = Math.Abs(FrameworkSettings.StartTimerAsyncIntervalMilliseconds);

      if (milliseconds == 0) return;

      TmStartMainApplicationAsync.Interval = milliseconds;
      TmStartMainApplicationAsync.Tick += new EventHandler(EventStartMainApplicationAsync);
      TmStartMainApplicationAsync.Start();
    }


    void EventStartMainApplication(object sender, EventArgs e)
    {
      TmStartMainApplication.Stop();
      TmStartMainApplication.Tick -= new EventHandler(EventStartMainApplication);
      FrameworkManager.Events.StartByTimer?.Invoke();
    }

    async void EventStartMainApplicationAsync(object sender, EventArgs e)
    {
      TmStartMainApplicationAsync.Stop();
      TmStartMainApplicationAsync.Tick -= new EventHandler(EventStartMainApplicationAsync);
      if (FrameworkManager.Events.StartByTimerAsync != null) await FrameworkManager.Events.StartByTimerAsync();
    }

    internal void AdjustFirstPage()
    {
      var page = this.PageFirst;
      page.ItemSize = new SizeF(130F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
      page.Item.MinSize = new Size(FrameworkSettings.TabMinimumWidth, 0);
      page.Item.Visibility = ElementVisibility.Collapsed;
    }

    internal void AdjustAboutProgramPage()
    {
      var page = this.PageAboutProgram;
      page.ItemSize = new SizeF(130F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
      page.Item.MinSize = new Size(FrameworkSettings.TabMinimumWidth, 0);
      page.Item.Visibility = ElementVisibility.Collapsed;
    }

    internal void HideTabsOfAllPages()
    {
      foreach (var page in this.PvMain.Pages)
      {
        page.Item.Visibility = ElementVisibility.Hidden;
      }
    }

    internal void SetEvents()
    {
      if (FrameworkManager.Events.MainFormLoad != null)  this.Load += new EventHandler(EventFormLoad);

      if (FrameworkManager.Events.MainFormResize != null) this.Resize += new EventHandler(EventResize);

      if (FrameworkManager.Events.MainFormResizeBegin != null) this.ResizeBegin += new EventHandler(EventResizeBegin);

      if (FrameworkManager.Events.MainFormResizeEnd != null) this.ResizeEnd += new EventHandler(EventResizeEnd);


      NotifyIconMainForm.DoubleClick += new EventHandler(EventTrayIconDoubleClick);

      // Эти важные события будут запрограммированы в классе FrameworkManager //
      //this.FormClosing += new FormClosingEventHandler(EventFormClosing);
      //this.FormClosed += new FormClosedEventHandler(EventFormClosed);
    }


    internal void SetEventForSystemTrayIcon()
    {
      if (FrameworkSettings.FlagMinimizeMainFormToSystemTray == false) return;

      if (FlagSystemTrayIconIsConfigured == false)
      {
        // Приложение должно минимизироваться в трей, но программист не настроил иконку для системного лотка. Придётся сделать это за него //
        SetIconForSystemTray(null);
      };

      if (MainForm.NotifyIconMainForm.Icon == null) return; // Проверка на всякий случай - а то минимизируем главную форму а иконки нет в системном лотке //

      this.NotifyIconMainForm.Visible = true;
      this.Resize += new EventHandler(EventResizeCheckWindowState);
    }

    void EventTrayIconDoubleClick(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Normal;
      this.ShowInTaskbar = true;
    }

    void EventResizeCheckWindowState(object sender, EventArgs e)
    {
      if (UserHasClickedExitButton) return;

      if ((this.WindowState == FormWindowState.Minimized))
      {
        this.ShowInTaskbar = false;
        this.Hide();
      }
      else if (this.WindowState == FormWindowState.Normal)
      {
        this.Show();
        this.ShowInTaskbar = true;
      }
    }











    void EventResizeEnd(object sender, EventArgs e)
    {
      FlagSizeIsBeingChanged = false;
      FrameworkManager.Events.MainFormResizeEnd();
    }

    void EventResizeBegin(object sender, EventArgs e)
    {
      FlagSizeIsBeingChanged = true;
      FrameworkManager.Events.MainFormResizeBegin();
    }

    void EventResize(object sender, EventArgs e)
    {
      if (UserHasClickedExitButton) return;
      FrameworkManager.Events.MainFormResize();
    }

    public void EventFormLoad(object sender, EventArgs e)
    {
      FrameworkManager.Events.MainFormLoad();
    }

    internal void VisualEffectFadeIn()
    {
      if (FrameworkSettings.VisualEffectOnStart == false) return;
      if (FrameworkSettings.FlagMainFormStartMinimized) return;

      int duration = 500; // in milliseconds
      int steps = 25;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        this.Opacity = ((double)currentStep) / steps;
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          this.Opacity = 1;
        }
      };
      timer.Start();      
    }

    internal void VisualEffectFadeOut()
    {
      if (FrameworkSettings.VisualEffectOnExit == false) return;

      int duration = 500; // in milliseconds
      int steps = 25;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        this.Opacity = 1 - (((double)currentStep) / steps);
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          this.Opacity = 0;
        }
      };
      timer.Start();
    }

    internal void ShowMainPageView(bool show)
    {
      if (FrameworkSettings.HideMainPageViewBeforeMainFormIsShown == false) return;
      
      //MainForm.PvMain.Visible = show;

      ((RadPageViewStripElement)PvMain.ViewElement).ItemContainer.Visibility = show ? ElementVisibility.Visible : ElementVisibility.Collapsed;
    }

    public void ShowSystemTrayIcon(bool show)
    {
      if (NotifyIconMainForm.Icon == null) return;
      NotifyIconMainForm.Visible = show;
    }
  }
}