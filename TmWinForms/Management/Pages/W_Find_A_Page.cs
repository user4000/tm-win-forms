using System;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class PagesManager
  {
    public RadPageViewPage FindPage(ushort id)
    {
      RadPageViewPage result = null;

      foreach(var pair in Service.DicForms)
      {
        if (pair.Value.IdForm == id)
        {
          result = pair.Value.Page;
          break;
        }
      }

      return result;
    }

    public RadPageViewPage FindPage(string uniquePageName)
    {
      RadPageViewPage result = null;

      foreach (var pair in Service.DicForms)
      {
        if (pair.Key == uniquePageName)
        {
          result = pair.Value.Page;
          break;
        }
      }

      return result;
    }

    public RadPageViewPage FindPage<T>()
    {
      RadPageViewPage result = null;

      foreach (var pair in Service.DicForms)
      {
        if (pair.Value.TypeName == typeof(T).FullName)
        {
          result = pair.Value.Page;
          break;
        }
      }

      return result;
    }
  }
}