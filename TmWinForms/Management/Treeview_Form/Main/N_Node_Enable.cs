using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FormTreeview
  {
    public bool EnableNode(ushort id, bool enable)
    {
      return Enable(FindNode(id), enable);
    }

    public bool EnableNode(string uniqueName, bool enable)
    {
      return Enable(FindNode(uniqueName), enable);
    }

    public bool EnableNode<T>(bool enable)
    {     
      return Enable(FindNode<T>(), enable);
    }

    bool Enable(RadTreeNode node, bool enable)
    {
      if (node == null) return false;
      node.Enabled = enable;

      if (node is CxNode)
      {
        (node as CxNode).ForeColor = enable ? FrameworkManager.FrameworkSettings.ColorTreeviewSubFormNode : FrameworkManager.FrameworkSettings.ColorTreeviewSubFormNodeDisabled;
      }

      return true;
    }
  }
}