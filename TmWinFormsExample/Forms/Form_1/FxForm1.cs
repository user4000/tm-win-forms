using System;
using TmWinForms;
using System.Media;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinFormsExample
{
  public partial class FxForm1 : RadForm, IStartWork, IEndWork, IEventUserForm, INeedLocalization
  {
    public FxForm1()
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


    public void EventStartWork()
    {
      Print("Test EVENT start work");
      SetProperties();
      SetEvents();
      //Log.Save($"{this.GetType().FullName} ---> EventStartWork()");
    }

    void SetProperties()
    {

    }

    void SetEvents()
    {
      BxTest1.Click += new EventHandler(EventTest1);
      BxTestNavigation.Click += new EventHandler(EventTestNavigation);
    }

    private void EventTestNavigation(object sender, EventArgs e)
    {
      Pages.EnablePage<FxForm3>(false);
      
    }

    private void EventTest1(object sender, EventArgs e)
    {
      Ms.Message("test", "test").Single(BxTest3).Sound(SystemSounds.Question).Info(3);
    }

    public void EventEndWork()
    {
      //Log.Save($"{this.GetType().FullName} ---> EventEndWork()");
    }

    public void EventUserForm(bool flag, string text, object arg)
    {
      Print("Event User Form TEST !!! " + text);
    }
  }
}