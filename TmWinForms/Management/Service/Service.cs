using System;
using System.Drawing;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    public FxMain MainForm { get; private set; }

    public Dictionary<string, SubForm> DicForms { get; } = new Dictionary<string, SubForm>();

    internal Queue<SubForm> QueueForms { get; } = new Queue<SubForm>();


    internal StandardApplicationSettings ProjectDefaultApplicationSettings { get; private set; } = null;  // Default settings before loading from file //


    internal StandardApplicationSettings CurrentApplicationSettings { get; private set; } = null;


    private ushort IdForm { get; set; }



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