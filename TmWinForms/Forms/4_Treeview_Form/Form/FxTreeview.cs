using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

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

    public void EventUserLeftTheForm()
    {
      MnTreeview.EventUserLeftTheForm();
    }

    public async Task EventUserLeftTheFormAsync()
    {
      await MnTreeview.EventUserLeftTheFormAsync();
    }

    public void EventUserVisitedTheForm()
    {
      MnTreeview.EventUserVisitedTheForm();
    }

    public async Task EventUserVisitedTheFormAsync()
    {
      await MnTreeview.EventUserVisitedTheFormAsync();
    }
  }
}