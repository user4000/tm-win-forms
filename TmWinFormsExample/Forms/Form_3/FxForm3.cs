using System;
using TmWinForms;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinFormsExample
{
  public partial class FxForm3 : RadForm, IStartWork, IUserLeftTheForm, IUserVisitedTheForm
  {
    public FxForm3()
    {
      InitializeComponent();
    }

    string Time() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    void Print(string msg)
    {
      if (TxtMessage.Text.Length > 10000) TxtMessage.Clear();
      TxtMessage.AppendText($"{Time()} ---- {this.GetType().FullName} ---- {msg}{Environment.NewLine}");
      Ms.Message(this.GetType().FullName, msg).NoAlert().ToFile().Debug();
    }

    public void EventUserLeftTheForm()
    {
      //Ms.Message("Form number 3 reports", "User left the page  !").Pos(MsgPos.TopLeft).Debug(2);
    }

    public void EventUserVisitedTheForm()
    {
      //Ms.Message("Form number 3 reports", "User visited the page  !").Pos(MsgPos.TopLeft).Info(2);
    }

    public void EventStartWork()
    {
      Print("Test EVENT start work");
    }
  }
}