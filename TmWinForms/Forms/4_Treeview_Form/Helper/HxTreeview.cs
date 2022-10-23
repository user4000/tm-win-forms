using System;
using TmWinForms;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  internal class HxTreeview
  {
    FxTreeview Form { get; set; }

    HxTreeview()
    {

    }

    HxTreeview(FxTreeview form)
    {
      Form = form;
    }

    internal static HxTreeview Create(FxTreeview form)
    {
      HxTreeview helper = new HxTreeview(form);
      return helper;
    }
  }
}