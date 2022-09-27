using System;
using TmWinForms;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinFormsExample
{
  public partial class FxForm1 : RadForm, IStartWork, IEndWork
  {
    public FxForm1()
    {
      InitializeComponent();
    }


    public void EventStartWork()
    {
      SetProperties();
      SetEvents();
    }

    void SetProperties()
    {

    }

    void SetEvents()
    {
      BxTest1.Click += new EventHandler(EventTest1);
    }

    private void EventTest1(object sender, EventArgs e)
    {
      Ms.Message("test", "test").Single(BxTest3).Info(7);
    }

    public void EventEndWork()
    {

    }
  }
}