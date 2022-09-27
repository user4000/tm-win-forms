﻿using System;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Drawing;

namespace TmWinForms
{
  public partial class FxMain : RadForm
  {

    bool FadeIn { get; set; }

    public FxMain()
    {
      InitializeComponent();
    }

    internal void SetProperties()
    {
      FadeIn = FrameworkManager.FrameworkSettings.VisualEffectOnStart;

      if (FadeIn)
      {
        this.Opacity = 0;
      }

      this.Visible = false;

      AdjustFirstPage();
    }


    internal void AdjustFirstPage()
    {
      var page = this.PgFirst;
      page.ItemSize = new SizeF(120F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
      page.Item.MinSize = new Size(FrameworkManager.FrameworkSettings.TabMinimumWidth, 0);
    }


    internal void SetEvents()
    {
      this.Load += new EventHandler(EventFormLoad);

      this.Resize += new EventHandler(EventResize);

      this.ResizeBegin += new EventHandler(EventResizeBegin);

      this.ResizeEnd += new EventHandler(EventResizeEnd);

      // Эти важные события будут запрограммированы в классе FrameworkManager //
      //this.FormClosing += new FormClosingEventHandler(EventFormClosing);
      //this.FormClosed += new FormClosedEventHandler(EventFormClosed);
    }

    void EventFormClosed(object sender, FormClosedEventArgs e)
    {

    }

    void EventFormClosing(object sender, FormClosingEventArgs e)
    {

    }

    void EventResizeEnd(object sender, EventArgs e)
    {

    }

    void EventResizeBegin(object sender, EventArgs e)
    {
      
    }

    void EventResize(object sender, EventArgs e)
    {

    }

    public void EventFormLoad(object sender, EventArgs e)
    {

    }

    internal void VisualEffectFadeIn()
    {
      if (FadeIn == false) return;

      int duration = 500; // in milliseconds
      int steps = 20;
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
  }
}