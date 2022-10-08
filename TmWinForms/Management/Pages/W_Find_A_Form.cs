using System;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public partial class PagesManager
  {
    public T GetForm<T>(ushort id) where T : RadForm
    {
      T result = null;

      foreach (var pair in Service.DicForms)
      {
        if ((pair.Value.IdForm == id) && (pair.Value.Form is T))
        {
          try { result = (T)(pair.Value.Form); } catch { };
          break;
        }
      }

      return result;
    }

    public T GetForm<T>(string uniquePageName) where T : RadForm
    {
      T result = null;

      foreach (var pair in Service.DicForms)
      {
        if ((pair.Key == uniquePageName) && (pair.Value.Form is T))
        {
          try { result = (T)(pair.Value.Form); } catch { };
          break;
        }
      }

      return result;
    }

    public T GetForm<T>() where T : RadForm
    {
      T result = null;

      foreach (var pair in Service.DicForms)
      {
        if (pair.Value.Form is T)
        {
          try { result = (T)(pair.Value.Form); } catch { };
          break;
        }
      }

      return result;
    }

    public T GetForm<T>(RadPageViewPage page) where T : RadForm
    {
      T result = null;

      if (Service.DicPages.TryGetValue(page, out RadForm form))
      {
        if (form is T) // if (form.GetType().IsAssignableFrom(typeof(T)))
        {
          try { result = (T)(form); } catch { };
        }
      }

      return result;
    }
  }
}