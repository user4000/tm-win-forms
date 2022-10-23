using System;
using TmWinForms;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class FxTreeview : RadForm
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
  }
}