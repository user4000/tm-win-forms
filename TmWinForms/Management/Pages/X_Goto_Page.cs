using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool GotoPage(ushort id)
    {
      return GotoPage(FindPage(id));
    }

    public bool GotoPage(string uniquePageName)
    {
      return GotoPage(FindPage(uniquePageName));
    }

    public bool GotoPage<T>()
    {
      return GotoPage(FindPage<T>());
    }

    bool GotoPage(RadPageViewPage page)
    {
      if (page == null) return false;

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