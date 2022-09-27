using System;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class FrameworkService
  {
    internal async Task MainExit()
    {
      await Task.Delay(1000);
    }
  }
}