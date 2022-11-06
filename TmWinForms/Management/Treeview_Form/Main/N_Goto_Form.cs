using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FormTreeview
  {
    public bool GotoForm(ushort id)
    {
      return GotoForm(FindNode(id));
    }

    public bool GotoForm(string uniqueName)
    {
      return GotoForm(FindNode(uniqueName));
    }

    public bool GotoForm<T>()
    {
      return GotoForm(FindNode<T>());
    }

    public bool GotoForm(RadTreeNode node)
    {
      if (node == null) return false;
      Form.TvMain.SelectedNode = node;
      return true;
    }
  }
}