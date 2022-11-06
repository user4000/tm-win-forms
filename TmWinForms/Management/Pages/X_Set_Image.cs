using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class PagesManager
  {
    public bool SetImage(ushort id, Image image)
    {
      return SetImage(FindPage(id), image);
    }

    public bool SetImage(string uniquePageName, Image image)
    {
      return SetImage(FindPage(uniquePageName), image);
    }

    public bool SetImage<T>(Image image)
    {
      return SetImage(FindPage<T>(), image);
    }

    bool SetImage(RadPageViewPage page, Image image)
    {
      if (page == null) return false;
      page.Item.Image = image;
      return true;
    }
  }
}