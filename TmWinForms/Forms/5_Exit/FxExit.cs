using System;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms.Form
{
  public partial class FxExit : RadForm, IStartWork, IUserVisitedTheForm
  {
    public FxExit()
    {
      InitializeComponent();
    }

    public void EventStartWork()
    {
      ConfigureTextOfExitButton();
      BtnExit.MinimumSize = new System.Drawing.Size(250, 0);
      BtnExit.Click += new EventHandler(EventUserClickedExitButton);
    }


    void UserWantsToExit()
    {
      FrameworkManager.UserHasClickedExitButton = true;
      MainForm.Close();
    }

    void EventUserClickedExitButton(object sender, EventArgs e)
    {
      UserWantsToExit();
    }

    public void EventUserVisitedTheForm()
    {
      bool Confirmation = FrameworkSettings.ConfirmExit;

      BtnExit.Visible = Confirmation;
      BtnExit.Enabled = Confirmation;

      if (Confirmation)
      {
        ConfigureTextOfExitButton();
      }
      else
      {
        UserWantsToExit();
      }
    }

    public void ConfigureTextOfExitButton()
    {
      string text = FrameworkSettings.ConfirmExitButtonText;

      //RadMessageBox.Show($"TmWinForms.Form.FxExit  TEST:   ConfirmExitButtonText = {text}");

      if (string.IsNullOrWhiteSpace(text))
      {
        BtnExit.Text = "Click here to confirm exit";
      }
      else
      {
        if (BtnExit.Text != text) BtnExit.Text = text;
      }
    }
  }
}