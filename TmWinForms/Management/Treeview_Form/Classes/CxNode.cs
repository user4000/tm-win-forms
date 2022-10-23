using System.Drawing;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public class CxNode : RadTreeNode
  {
    public TvForm MyForm { get; private set; }

    public Group MyGroup { get; private set; }

    public void SetGroup(Group group) => MyGroup = group;

    public void SetForm(TvForm form) => MyForm = form;

    public Color ColorDefault { get; set; } = Color.Black;

    public Color ColorDisabled { get; set; } = Color.Gray;


    public void SetColor()
    {
      this.ForeColor = this.Enabled ? ColorDefault : ColorDisabled;
    }

    public static void SetColor(RadTreeNode node)
    {
      CxNode customNode = GetNode(node);
      if (customNode == null) return;
      customNode.SetColor();
    }

    public static CxNode GetNode(RadTreeNode node)
    {
      CxNode result = null;
      if ((node is CxNode) == false) return result;
      result = node as CxNode;
      return result;
    }
  }
}
