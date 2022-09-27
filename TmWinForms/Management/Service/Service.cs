using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    FxMain MainForm { get; set; }

    Dictionary<string, SubForm> DicForms { get; } = new Dictionary<string, SubForm>();


    internal StandardApplicationSettings ProjectDefaultApplicationSettings { get; private set; } = null;  // Default settings before loading from file //


    internal StandardApplicationSettings CurrentApplicationSettings { get; private set; } = null;


    FrameworkService()
    {
      
    }


    internal void Configure(FxMain mainForm)
    {
      MainForm = mainForm;
    }


    internal static FrameworkService Create() => new FrameworkService();







  }
}