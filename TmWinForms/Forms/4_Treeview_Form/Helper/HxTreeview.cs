using System;
using TmWinForms;

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