using System;
using System.Drawing;
using Newtonsoft.Json;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TmWinForms
{
  [Serializable]
  public class TmMessage
  {
    internal string Text { get; set; } = string.Empty;
    internal string Header { get; set; } = string.Empty;
    internal MsgType MessageType { get; set; } = MsgType.Debug;
    internal MsgPos AlertPosition { get; set; } = MsgPos.BottomRight;

    internal bool FlagTable { get; set; } = true;
    internal bool FlagAlert { get; set; } = true;
    internal bool FlagFile { get; set; } = false;
    internal bool FlagPinned { get; set; } = false;
    internal bool FlagShowPinButton { get; set; } = false;
    internal bool FlagCloseOnClick { get; set; } = false;
    internal bool FlagIcon { get; set; } = true;
    internal bool FlagRemovePreviousAlerts { get; set; } = false;
    internal int AutoCloseDelay { get; set; } = 0;

    [JsonIgnore]
    internal Control AlertControl { get; set; } = null;

    [JsonIgnore]
    internal RadElement AlertRadElement { get; set; } = null;


    internal Size AlertSize { get; set; } = CxStandard.ZeroSize;

    internal Point AlertOffset { get; set; } = CxStandard.ZeroPoint;

    public TmMessage Position(MsgPos position)
    {
      AlertPosition = position; return this;
    }

    public TmMessage Pos(MsgPos position) => Position(position);

    public TmMessage Size(Size size)
    {
      AlertSize = size; return this;
    }

    public TmMessage Size(int X, int Y) => Size(new Size(X, Y));

    public TmMessage Offset(Point offset)
    {
      AlertOffset = offset; return this;
    }

    public TmMessage Offset(int X, int Y) => Offset(new Point(X, Y));

    public TmMessage Control(Control control)
    {
      AlertControl = control; return this;
    }

    public TmMessage Wire(Control control) => Control(control);

    public TmMessage Single(Control control)
    {
      AlertControl = control;
      FlagCloseOnClick = true;
      FlagRemovePreviousAlerts = true;
      return this;
    }

    public TmMessage Single(MsgPos position)
    {
      AlertPosition = position;
      FlagCloseOnClick = true;
      FlagRemovePreviousAlerts = true;
      return this;
    }

    public TmMessage Delay(int seconds)
    {
      AutoCloseDelay = seconds; return this;
    }

    public TmMessage Table(bool SaveToTable)
    {
      FlagTable = SaveToTable; return this;
    }

    public TmMessage RemovePrevious(bool ImmediatelyClosePreviousAlerts = true)
    {
      FlagRemovePreviousAlerts = ImmediatelyClosePreviousAlerts; return this;
    }

    public TmMessage Alert(bool ShowAlert)
    {
      FlagAlert = ShowAlert; return this;
    }

    public TmMessage File(bool SaveToLogFile)
    {
      FlagFile = SaveToLogFile; return this;
    }

    public TmMessage Pin()
    {
      FlagPinned = true; FlagShowPinButton = true; return this;
    }

    public TmMessage PinButton()
    {
      FlagShowPinButton = true; return this;
    }

    public TmMessage NoIcon()
    {
      FlagIcon = false; return this;
    }

    public TmMessage CloseOnClick()
    {
      FlagCloseOnClick = true; return this;
    }

    public TmMessage ToFile() => File(true);

    public TmMessage NoAlert() => Alert(false);

    public TmMessage NoTable() => Table(false);

    public void Create() => FrameworkManager.Ms.ActionCreate(this);

    public void Debug(int delaySeconds = 0)
    {
      MessageType = MsgType.Debug;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Info(int delaySeconds = 0)
    {
      MessageType = MsgType.Info;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Ok(int delaySeconds = 0)
    {
      MessageType = MsgType.Ok;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Fail(int delaySeconds = 0)
    {
      MessageType = MsgType.Fail;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Warning(int delaySeconds = 0)
    {
      MessageType = MsgType.Warning;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }

    public void Error(int delaySeconds = 0)
    {
      MessageType = MsgType.Error;
      if (delaySeconds > 0) AutoCloseDelay = delaySeconds;
      Create();
    }
  }
}