using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FormTreeview
  {
    public bool ShowNode(ushort id, bool enable)
    {
      return Show(FindNode(id), enable);
    }

    public bool ShowNode(string uniqueName, bool enable)
    {
      return Show(FindNode(uniqueName), enable);
    }

    public bool ShowNode<T>(bool enable)
    {
      return Show(FindNode<T>(), enable);
    }

    bool Show(RadTreeNode node, bool enable)
    {
      if (node == null) return false;
      node.Visible = enable;
      return true;
    }
  }
}