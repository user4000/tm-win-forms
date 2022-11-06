using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TmWinForms
{
  public class CxMessageManager : IMessageSubsystem
  {

    CxMessageManager()
    {

    }

    public static CxMessageManager Create() => new CxMessageManager();




    public const string TextLeftMargin = " ";

    public int ShortMessageAlertHeight { get; } = 36;

    public TmMessage Message(string header, string message) => new TmMessage { Header = header, Text = message };

    public TmMessage Message(string header, string message, Control control) => new TmMessage { Header = header, Text = message, AlertControl = control };

    public TmMessage Message(string header, string message, RadElement element, bool fakeParameter) => new TmMessage { Header = header, Text = message, AlertRadElement = element };

    public TmMessage Message(string header, string message, MsgPos position) => new TmMessage { Header = header, Text = message, AlertPosition = position };

    public TmMessage Message(string header, string message, MsgType type) => new TmMessage { Header = header, Text = message, MessageType = type };

    public TmMessage Message(MsgType type, string header, string message, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0) => new TmMessage { Header = header, Text = message, MessageType = type, AlertControl = control, AlertPosition = position, AutoCloseDelay = delay };

    public TmMessage Error(string header, Exception ex)
    {
      string message =
        "An exception was encountered." +
        "\nType : " + ex.GetType().ToString() +
        "\nData : " + ex.Data +
        "\nInner : " + ex.InnerException +
        "\nMessage : " + ex.Message +
        "\nSource : " + ex.Source +
        "\nStackTrace : " + ex.StackTrace;

      return new TmMessage
      {
        Header = header,
        Text = message,
        MessageType = MsgType.Error,
        FlagFile = true
      };
    }

    public TmMessage ShortMessage(MsgType type, string ShortMessage, int Width, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0)
      =>
      new TmMessage
      {
        Header = TextLeftMargin + ShortMessage,
        MessageType = type,
        AlertControl = control,
        AlertPosition = position,
        AutoCloseDelay = delay,
        AlertSize = new Size(Width, ShortMessageAlertHeight),
        FlagIcon = false
      };

    public TmMessage ShortMessage(string ShortMessage, int Width, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0)
      =>
      new TmMessage
      {
        Header = TextLeftMargin + ShortMessage,
        MessageType = MsgType.Debug,
        AlertControl = control,
        AlertPosition = position,
        AutoCloseDelay = delay,
        AlertSize = new Size(Width, ShortMessageAlertHeight),
        FlagIcon = false
      };

    public Action<TmMessage> ActionCreate { get; private set; } = DoNothing;

    private static void DoNothing(TmMessage Message)
    {
      //Trace.WriteLine($"Do nothing !!! {Message.Header} {Message.Text}");
    }

    internal void InitMessageSubsystem(Action<TmMessage> MessageHandlerMethod)
    {
      /* if (ActionCreate == DoNothing) */
      ActionCreate = MessageHandlerMethod;
    }

    internal void TurnOffMessageSubsystem()
    {
      ActionCreate = DoNothing;
    }
  }
}