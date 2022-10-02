using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool EnablePage(ushort id, bool enable)
    {
      var page = FindPage(id); if (page == null) return false;
      return Enable(page, enable);
    }

    public bool EnablePage(string uniquePageName, bool enable)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return Enable(page, enable);
    }

    public bool EnablePage<T>(bool enable)
    {
      var page = FindPage<T>(); if (page == null) return false;
      return Enable(page, enable);
    }

    bool Enable(RadPageViewPage page, bool enable)
    {
      if (page.Item.Enabled != enable) page.Item.Enabled = enable; return true;
    }
  }
}