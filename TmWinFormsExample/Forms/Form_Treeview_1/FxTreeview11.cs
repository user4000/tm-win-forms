using System;
using TmWinForms;
using Telerik.WinControls;
using TmWinForms.Extensions;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using static TmWinForms.FrameworkManager;

namespace TmWinFormsExample
{
  public partial class FxTreeview11 : RadForm, IStartWork, IEndWork, IUserLeftTheForm, IUserVisitedTheForm, INeedLocalization
  {
    public FxTreeview11()
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

    void Write(string msg)
    {
      Log.Save($"{this.GetType().FullName} ---- {msg}{Environment.NewLine}");
    }

    private void SetProperties()
    {
      
    }

    private void SetEvents()
    {
      BxTestEnablePage.Click += new EventHandler(EventTest1);
    }

    private async void EventTest1(object sender, EventArgs e)
    {
      BxTestEnablePage.Enabled = false;

      bool flag = TswEnabled.Value;

      //Print(flag.ToString());

      //TvNodes.Select("tv1").GotoForm<FxTreeview31>();

      //TvNodes.Select("tv1").ShowNode<FxTreeview31>(flag);

      //TvNodes.Select(this).GotoForm<FxTreeview31>();

      this.ZzTreeview().GotoForm<FxTreeview32>();

      await Task.Delay(1000);

      BxTestEnablePage.Enabled = true;
    }

    public void EventStartWork()
    {
      SetProperties();
      SetEvents();
      Print("EventStartWork");
    }

    public void EventEndWork()
    {
      //Write("EventEndWork");
    }

    public void EventUserVisitedTheForm()
    {
      //Print("User visited the form");      
    }

    public void EventUserLeftTheForm()
    {
      //Print("User left the form");
    }
  }
}