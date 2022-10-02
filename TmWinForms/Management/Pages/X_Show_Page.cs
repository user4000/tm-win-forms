using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool ShowPage(ushort id, bool visible)
    {
      var page = FindPage(id); if (page == null) return false;
      return ShowPage(page, visible);
    }

    public bool ShowPage(string uniquePageName, bool visible)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return ShowPage(page, visible);
    }

    public bool ShowPage<T>(bool visible)
    {
      var page = FindPage<T>(); if (page == null) return false;
      return ShowPage(page, visible);
    }

    bool ShowPage(RadPageViewPage page, bool visible)
    {
      page.Item.Visibility = visible ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;
      return true;
    }
  }
}