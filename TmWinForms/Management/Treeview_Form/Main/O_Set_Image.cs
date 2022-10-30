using System.Drawing;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FormTreeview
  {
    public bool SetImage(ushort id, Image image)
    {
      return SetImage(FindNode(id), image);
    }

    public bool SetImage(string uniqueName, Image image)
    {
      return SetImage(FindNode(uniqueName), image);
    }

    public bool SetImage<T>(Image image)
    {
      return SetImage(FindNode<T>(), image);
    }

    bool SetImage(RadTreeNode node, Image image)
    {
      if (node == null) return false;

      node.Image = image;

      return true;
    }
  }
}