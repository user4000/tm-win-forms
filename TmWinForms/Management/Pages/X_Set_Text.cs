using System;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool SetText(ushort id, string text) 
    {
      return SetText(FindPage(id), text);
    }

    public bool SetText(string uniquePageName, string text)
    {
      return SetText(FindPage(uniquePageName), text);
    }

    public bool SetText<T>(string text)
    {
      return SetText(FindPage<T>(), text);
    }

    bool SetText(RadPageViewPage page, string text)
    {
      if (page == null) return false;

      if (page.Item.Text != text)
      {
        page.Item.Text = text;        
      }
      return true;
    }
  }
}