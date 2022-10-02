using System;
using TmWinForms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TmWinForms.Form
{
  public partial class FxExit : RadForm, IStartWork, IUserVisitedTheForm
  {
    public FxExit()
    {
      InitializeComponent();
    }

    public bool ExitWithoutConfirmation { get => string.IsNullOrWhiteSpace(FrameworkManager.FrameworkSettings.ConfirmExitButtonText); }

    public void EventStartWork()
    {
      ConfigureExitButton();
      BtnExit.MinimumSize = new System.Drawing.Size(250, 0);
    }

    public void EventUserVisitedTheForm()
    {
      BtnExit.Visible = FrameworkManager.FrameworkSettings.ConfirmExit;

      if (FrameworkManager.FrameworkSettings.ConfirmExit)
      {
        ConfigureExitButton();
      }
      else
      {
        FrameworkManager.MainForm.Close();
      } 
    }

    public void ConfigureExitButton()
    {
      string text = FrameworkManager.FrameworkSettings.ConfirmExitButtonText;

      //RadMessageBox.Show($"TmWinForms.Form.FxExit  TEST:   ConfirmExitButtonText = {text}");

      if ( string.IsNullOrWhiteSpace(text) )
      {
        BtnExit.Text = "Click here to confirm exit";
      }
      else
      {
        if (BtnExit.Text != text) BtnExit.Text = text;
        BtnExit.Visible = true;
      }
    }
  }
}