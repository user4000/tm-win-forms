using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool EnablePage(ushort id, bool enable)
    {
      return Enable(FindPage(id), enable);
    }

    public bool EnablePage(string uniquePageName, bool enable)
    {
      return Enable(FindPage(uniquePageName), enable);
    }

    public bool EnablePage<T>(bool enable)
    {
      return Enable(FindPage<T>(), enable);
    }

    bool Enable(RadPageViewPage page, bool enable)
    {
      if (page == null) return false;
      if (page.Item.Enabled != enable)
      {
        page.Item.Enabled = enable;
      }
      return true;
    }
  }
}