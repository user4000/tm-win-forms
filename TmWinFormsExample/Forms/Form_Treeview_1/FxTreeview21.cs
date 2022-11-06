using System;
using TmWinForms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinFormsExample
{
  public partial class FxTreeview21 : RadForm, IStartWork, IEndWork, IUserLeftTheForm, IUserVisitedTheForm, IEventUserForm
  {
    public FxTreeview21()
    {
      InitializeComponent();
    }

    string Time() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    void Print(string msg)
    {
      if (TxMessage.Text.Length > 10000) TxMessage.Clear();
      TxMessage.AppendText($"{Time()} ---- {this.GetType().FullName} ---- {msg}{Environment.NewLine}");
      Ms.Message(this.GetType().FullName, msg).NoAlert().ToFile().Debug();
    }

    private void SetProperties()
    {
      
    }

    private void SetEvents()
    {

    }


    public void EventStartWork()
    {
      SetProperties();
      SetEvents();
      Print("EventStartWork");
    }


    public void EventEndWork()
    {

    }

    public void EventUserVisitedTheForm()
    {
      //Print("User visited the form");
    }

    public void EventUserLeftTheForm()
    {
      //Print("User left the form");
    }

    public void EventUserForm(bool flag, string text, object arg)
    {
      Print("Event User Form TEST !!! " + text);
    }
  }
}