using System;
using TmWinForms;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinFormsExample
{
  public partial class FxForm2 : RadForm, IStartWork, IUserLeftTheFormAsync, IUserVisitedTheFormAsync, INeedLocalization
  {
    public FxForm2()
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

    public async Task EventUserLeftTheFormAsync()
    {
      await Task.Delay(100);
      //Ms.Message("Form number 2 reports", "User left the page ASYNC !").Single(MsgPos.TopLeft).Fail(2);
    }

    public async Task EventUserVisitedTheFormAsync()
    {
      await Task.Delay(100);
      //Ms.Message("Form number 2 reports", "User visited the page ASYNC !").Single(MsgPos.TopLeft).Warning(2);
    }

    public void EventStartWork()
    {
      Print("Test EVENT start work");
      SetEvents();
    }

    private void SetEvents()
    {
      BxTestRaiseEvent.Click += new EventHandler(EventTestRaiseEvent);
    }

    private async void EventTestRaiseEvent(object sender, EventArgs e)
    {
      (sender as Control).Enabled = false;

      //Service.RaiseEventUserForm(true, "test event", this);

      Ms.Message("test", "EventTestRaiseEvent").Single(BxTestRaiseEvent).Debug(4);

      Service.RaiseEventLocalization(Program.Manager.Localizer);

      await Task.Delay(1000);
      (sender as Control).Enabled = true;
    }
  }
}