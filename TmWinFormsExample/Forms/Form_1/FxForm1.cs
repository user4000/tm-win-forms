using System;
using TmWinForms;
using System.Media;
using Telerik.WinControls;
using System.Windows.Forms;
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
  }
}