using Telerik.WinControls.UI;

namespace TmWinForms
{
  public partial class FormTreeview
  {
    public bool SetText(ushort id, string text)
    {
      return SetText(FindNode(id), text);
    }

    public bool SetText(string uniqueName, string text)
    {
      return SetText(FindNode(uniqueName), text);
    }

    public bool SetText<T>(string text)
    {
      return SetText(FindNode<T>(), text);
    }

    bool SetText(RadTreeNode node, string text)
    {
      if (node == null) return false;

      if (node.Text != text) node.Text = (text ?? string.Empty);

      return true;
    }
  }
}