using System;
using TmWinForms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TmWinFormsExample
{
  public partial class FxTreeview12 : RadForm, IStartWork, IEndWork, IUserLeftTheForm, IUserVisitedTheForm
  {
    public FxTreeview12()
    {
      InitializeComponent();
    }

    string Time() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    void Print(string msg)
    {
      if (TxMessage.Text.Length > 10000) TxMessage.Clear();
      TxMessage.AppendText($"{Time()} ---- {this.GetType().FullName} ---- {msg}");
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
      Print("User visited the form");
    }

    public void EventUserLeftTheForm()
    {
      Print("User left the form");
    }
  }
}