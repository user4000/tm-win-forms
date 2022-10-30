using System;
using TmWinForms;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;
using System.Threading.Tasks;

namespace TmWinForms
{
  public partial class FxTreeview : RadForm, IUserVisitedTheForm, IUserVisitedTheFormAsync, IUserLeftTheForm, IUserLeftTheFormAsync
  {
    HxTreeview MnForm { get; set; }

    FormTreeview MnTreeview { get; set; }

    public FxTreeview()
    {
      InitializeComponent();
    }

    public void Configure(FormTreeview formTreeview)
    {
      MnForm = HxTreeview.Create(this);
      MnTreeview = formTreeview;
    }


    public async Task EventUserLeftTheFormAsync()
    {
      await MnTreeview.EventUserLeftTheFormAsync();
    }

    public void EventUserLeftTheForm()
    {
      MnTreeview.EventUserLeftTheForm();
    }

    public async Task EventUserVisitedTheFormAsync()
    {
      await MnTreeview.EventUserVisitedTheFormAsync();
    }

    public void EventUserVisitedTheForm()
    {
      MnTreeview.EventUserVisitedTheForm();
    }
  }
}