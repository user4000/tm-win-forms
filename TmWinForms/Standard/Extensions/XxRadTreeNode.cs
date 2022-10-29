using Telerik.WinControls.UI;

namespace TmWinForms.Extensions
{
  internal static class XxRadTreeNode
  {
    internal static CxNode ZzGetCustomNode(this RadTreeNode node)
    {
      return (node as CxNode);
    }

    internal static Group ZzGetGroup(this RadTreeNode node)
    {
      if ((node is CxNode) == false) return null;
      return ((node as CxNode).MyGroup);
    }

    internal static TvForm ZzGetSubForm(this RadTreeNode node)
    {
      return ((node as CxNode).MyForm);
    }
  }
}