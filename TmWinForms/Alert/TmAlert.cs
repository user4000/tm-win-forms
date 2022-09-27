using System.ComponentModel;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public class TmAlert : RadDesktopAlert
  {      
    internal TmAlert(IContainer container) : base(container)
    {
      AutoClose = true;
      FadeAnimationFrames = 1;
      FadeAnimationSpeed = 1;
      FadeAnimationType = FadeAnimationType.None;
      AutoSize = true;
      CanMove = true;
      PopupAnimation = false;
      ShowOptionsButton = false;
    }
  }
}