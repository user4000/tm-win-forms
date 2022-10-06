using System;
using System.Windows.Forms;

namespace TmWinForms
{
  partial class FrameworkManager
  {
    private static void EventMainFormClosed(object sender, FormClosedEventArgs e)
    {
      Events.MainFormClosed?.Invoke(sender, e);     
    }
  }
}