using System;
using System.Windows.Forms;
using Telerik.WinControls;

namespace TmWinForms
{
  public interface IMessageSubsystem
  {
    TmMessage Message(string header, string message);

    TmMessage Message(string header, string message, Control control);

    TmMessage Message(string header, string message, RadElement element, bool fakeParameter);

    TmMessage Message(string header, string message, MsgPos position);

    TmMessage Message(string header, string message, MsgType type);

    TmMessage Message(MsgType type, string header, string message, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0);

    TmMessage ShortMessage(MsgType type, string message, int Width, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0);

    TmMessage ShortMessage(string message, int Width, Control control = null, MsgPos position = MsgPos.Unknown, int delay = 0);

    TmMessage Error(string header, Exception ex);
  }
}