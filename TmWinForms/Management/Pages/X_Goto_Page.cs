using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool GotoPage(ushort id)
    {
      var page = FindPage(id); if (page == null) return false;
      return GotoPage(page);
    }

    public bool GotoPage(string uniquePageName)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return GotoPage(page);
    }

    public bool GotoPage<T>()
    {
      var page = FindPage<T>(); if (page == null) return false;
      return GotoPage(page);
    }

    bool GotoPage(RadPageViewPage page)
    {
      bool result = true;
      try
      {
        MainForm.PvMain.SelectedPage = page;
      }
      catch
      {
        result = false;
      }
      return result;
    }
  }
}