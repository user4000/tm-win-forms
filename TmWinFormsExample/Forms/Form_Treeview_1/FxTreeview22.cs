using System;
using TmWinForms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinFormsExample
{
  public partial class FxTreeview22 : RadForm, IStartWork, IEndWork, IUserLeftTheForm, IUserVisitedTheForm, IUserVisitedTreeviewForm, IUserLeftTreeviewForm
  {
    public FxTreeview22()
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

    public void EventUserVisitedTreeviewForm()
    {
      //Ms.Message(this.GetType().FullName, "user VISITED treeview form").Pos(MsgPos.BottomLeft).Ok(10);
    }

    public void EventUserLeftTreeviewForm()
    {
      //Ms.Message(this.GetType().FullName, "user LEFT treeview form").Pos(MsgPos.BottomLeft).Fail(10);
    }
  }
}