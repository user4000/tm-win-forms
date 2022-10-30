using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FormTreeview
  {
    RadTreeNode NullNode { get; } = null;

    public RadTreeNode FindNode(ushort id)
    {
      foreach (var item in SubForms)
        if (item.IdForm == id)
          return item.NodeForm;

      return NullNode;
    }

    public RadTreeNode FindNode(string uniqueName)
    {
      foreach (var item in SubForms)
        if (item.UniqueName == uniqueName)
          return item.NodeForm;

      return NullNode;
    }

    public RadTreeNode FindNode<T>()
    {
      foreach (var item in SubForms)
        if (item.Form is T)
          return item.NodeForm;

      return NullNode;
    }
  }
}