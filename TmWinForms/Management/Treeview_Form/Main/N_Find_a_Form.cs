using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FormTreeview
  {
    public T GetForm<T>(ushort id) where T : RadForm
    {
      T result = null;

      foreach (var item in SubForms)
        if ((item.IdForm == id) && (item.Form is T))
        {
          return (item.Form as T);
        }

      return result;
    }

    public T GetForm<T>(string uniqueName) where T : RadForm
    {
      T result = null;

      foreach (var item in SubForms)
        if ((item.UniqueName == uniqueName) && (item.Form is T))
        {
          return (item.Form as T);
        }

      return result;
    }

    public T GetForm<T>() where T : RadForm
    {
      T result = null;

      foreach (var item in SubForms)
        if (item.Form is T)
        {
          return (item.Form as T);
        }

      return result;
    }

    public T GetForm<T>(RadTreeNode node) where T : RadForm
    {
      T result = null;

      foreach (var item in SubForms)
        if (item.NodeForm == node)
        {
          return (item.Form as T);
        }

      return result;
    }
  }
}