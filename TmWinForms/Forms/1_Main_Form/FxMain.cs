using System;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FxMain : RadForm
  {
    public FxMain()
    {
      InitializeComponent();
    }

    internal void SetProperties()
    {
      this.Opacity = 0;
      this.Visible = false;      
    }

    internal void SetEvents()
    {
      this.Load += new EventHandler(EventFormLoad);
      this.Shown += new EventHandler(EventFormShown);
      this.Resize += new EventHandler(EventResize);
      this.ResizeBegin += new EventHandler(EventResizeBegin);
      this.ResizeEnd += new EventHandler(EventResizeEnd);

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

    void EventFormShown(object sender, EventArgs e)
    {
      this.Shown -= new EventHandler(EventFormShown);

      VisualEffectFadeIn();

      this.Visible = true;
    }

    public void EventFormLoad(object sender, EventArgs e)
    {

    }



    internal void VisualEffectFadeIn()
    {
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