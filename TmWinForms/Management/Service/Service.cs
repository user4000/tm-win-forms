using System;
using System.Drawing;
using TmWinForms.Form;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    public FxMain MainForm { get; private set; }

    public Dictionary<string, SubForm> DicForms { get; } = new Dictionary<string, SubForm>();

    public Dictionary<RadPageViewPage, RadForm> DicPages { get; } = new Dictionary<RadPageViewPage, RadForm>();

    internal Queue<SubForm> QueueForms { get; } = new Queue<SubForm>();


    internal StandardApplicationSettings ProjectDefaultApplicationSettings { get; private set; } = null;  // Default settings before loading from file //


    internal StandardApplicationSettings CurrentApplicationSettings { get; private set; } = null;


    public TmAlertService AlertService { get; private set; } = null;


    private ushort IdForm { get; set; }


    FrameworkService()
    {
      
    }

    internal static FrameworkService Create() => new FrameworkService();

    internal void Configure(FxMain mainForm)
    {
      MainForm = mainForm;
    }







    private byte CountOfMessageTypes { get; } = (byte)Enum.GetNames(typeof(MsgType)).Length;

    internal byte GetIndexByMessageType(MsgType type) => (byte)(((byte)type) % CountOfMessageTypes);

    internal Image GetImageByMessageType(MsgType MessageType) => FormLog.ImageIcons.Images[GetIndexByMessageType(MessageType)];




    public FxSettings FormSettings { get; private set; } = null;

    public FxLog FormLog { get; private set; } = null;

    public FxExit FormExit { get; private set; } = null;

  }
}