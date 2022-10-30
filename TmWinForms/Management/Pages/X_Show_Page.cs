using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool ShowPage(ushort id, bool visible)
    {
      return ShowPage(FindPage(id), visible);
    }

    public bool ShowPage(string uniquePageName, bool visible)
    {
      return ShowPage(FindPage(uniquePageName), visible);
    }

    public bool ShowPage<T>(bool visible)
    {
      return ShowPage(FindPage<T>(), visible);
    }

    bool ShowPage(RadPageViewPage page, bool visible)
    {
      if (page == null) return false;
      page.Item.Visibility = visible ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;
      return true;
    }
  }
}